using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using EDSDKLib;
using static System.Net.Mime.MediaTypeNames;
using Image = System.Drawing.Image;

namespace Canon_13_12_10_90D
{
    public delegate void ImageReadyHandler(Image image);
    public class CanonCamera :IDisposable
    {
        CanonErrors errors = new CanonErrors();
        public RotateFlipType rotateDirection = RotateFlipType.Rotate90FlipNone; //Поворот отснятого снимка
        public event ImageReadyHandler ImageReady;

        uint err;
        IntPtr camList, camDev, stream, evfImage, streamPtr;
        int camCount;
        EDSDK.EdsDeviceInfo devInfo;
        uint outputDev, length;
        EDSDK.EdsObjectEventHandler ev;
        IntPtr fStream;

        bool isSaveToSetted = false;
        bool isShooting = false;
        int tryCount = 0;
        
        public Image GetLiveView()
        {
            
            try
            {
                if(camDev == IntPtr.Zero)
                    Init();

                Do(EDSDK.EdsCreateMemoryStream(0, out stream), "Create stream");

                Set_EvfImage();
                //Thread.Sleep(3000);
                Do(EDSDK.EdsDownloadEvfImage(camDev, evfImage), "Download Evf image");

                Do(EDSDK.EdsGetPointer(stream, out streamPtr), "Get Pointer");

                ulong lenghtLong;
                Do(EDSDK.EdsGetLength(stream, out lenghtLong), "Get Length");

                byte[] im = new byte[lenghtLong];
                Image img;

                Marshal.Copy(streamPtr, im, 0, (int)lenghtLong);
                using (MemoryStream ms = new MemoryStream(im))
                {
                    img = (Bitmap)Image.FromStream(ms);
                    img.RotateFlip(rotateDirection);
                    //Graphics g = Graphics.FromImage(img);

                    ms.Close();
                }
                //Close();
                return img;

            }
            finally
            {
                if (stream != null)
                {
                    err = EDSDK.EdsRelease(stream);
                }

                if (evfImage != null)
                {
                    EDSDK.EdsRelease(evfImage);
                }
            }            
        }

        private void Set_EvfImage()
        {
            tryCount = 0;
            Exception e=null;
            while (tryCount < 5)
            {
                try
                {
                    Do(EDSDK.EdsCreateEvfImageRef(stream, out evfImage), "Create Evf Image Ref");
                    return;
                }
                catch (Exception e1)
                {
                    e = e1;
                    Thread.Sleep(200);
                    tryCount++;
                }
            }
            throw e;
        }

        public void Init()
        {
            Do(EDSDK.EdsInitializeSDK(), "Init");

            Do(EDSDK.EdsGetCameraList(out camList), "Cam list");

            Do(EDSDK.EdsGetChildCount(camList, out camCount), "Child count");
            if (camCount == 0)
                throw new Exception("Камера не подключена");

            Do(EDSDK.EdsGetChildAtIndex(camList, 0, out camDev), "Get child");

            Do(EDSDK.EdsOpenSession(camDev), "Open session");

            Do(EDSDK.EdsGetDeviceInfo(camDev, out devInfo), "Get Device Info");

            //ISO устанавливаем
            //SetPropertyData(EDSDK.PropID_ISOSpeed, 0x00000058, "ISO set error");//400
            uint r;
            //Размер изображения
            //SetPropertyData(EDSDK.PropID_ImageQuality, (uint)EDSDK.ImageQuality.EdsImageQuality_LJF, "Установка качества"); //M low
            //SetPropertyData(EDSDK.PropID_ EdsTargetImageType
            r = EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_ImageQuality, 0, out outputDev);
            
            
            //Режим видоискателя
            Do(EDSDK.EdsSetPropertyData(camDev, EDSDK.PropID_Evf_Mode, 0, Marshal.SizeOf(typeof(uint)), (uint)1), "Evf mode set");

            //Куда выводится изображение
            r = EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_Evf_OutputDevice, 0, out outputDev);
            //В комп
            outputDev = outputDev | EDSDK.EvfOutputDevice_PC;
            Do(EDSDK.EdsSetPropertyData(camDev, EDSDK.PropID_Evf_OutputDevice, 0, Marshal.SizeOf(typeof(uint)),
                (uint)outputDev), "Evf output");

            r = EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_Evf_OutputDevice, 0, out outputDev);
        }

        byte secTryCount = 3;
        public void SetPropertyData(uint Property, uint value,string ErrorText)
        {
            DateTime startTime = DateTime.Now;
            uint rez = EDSDK.EdsSetPropertyData(camDev, Property, 0, Marshal.SizeOf(typeof(int)), (uint)value);

            while (rez != EDSDK.EDS_ERR_OK && (DateTime.Now-startTime).TotalSeconds < secTryCount)
            {
                Thread.Sleep(300);
                rez = EDSDK.EdsSetPropertyData(camDev, Property, 0, Marshal.SizeOf(typeof(int)), (uint)value);
            }            

            Do(rez,ErrorText);
        }

        public void GetImage()
        {
            try
            {
                if (!isShooting)
                {
                    isShooting = true;
                    if (camDev == IntPtr.Zero)
                        Init();

                    ev = HandleObjectEvent;

                    if (!isSaveToSetted)
                    {
                        EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_SaveTo, 0, out outputDev);

                        //Включить один раз
                        Do(EDSDK.EdsSetPropertyData(camDev, EDSDK.PropID_SaveTo, 0, Marshal.SizeOf(typeof(int)), (int)2), "SaveTo error ");

                        EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_SaveTo, 0, out outputDev);
                        isSaveToSetted = true;
                        Thread.Sleep(150);


                        EDSDK.EdsCapacity capacity = new EDSDK.EdsCapacity();
                        capacity.NumberOfFreeClusters = 0x7FFFFFFF;
                        capacity.BytesPerSector = 0x1000;
                        capacity.Reset = 1;
                        Do(EDSDK.EdsSetCapacity(camDev, capacity), "Capacity error");
                    }
                    EDSDK.EdsGetPropertyData(camDev, EDSDK.ObjectEvent_All, 0, out outputDev);

                    //EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_ImageQuality, 0, out outputDev);
                    //Do(EDSDK.EdsSetPropertyData(camDev, EDSDK.PropID_ImageQuality, 0, Marshal.SizeOf(typeof(int)), (int)26), "Image Quality");
                    //EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_ImageQuality, 0, out outputDev);


                    Do(EDSDK.EdsSetObjectEventHandler(camDev, EDSDK.ObjectEvent_All, ev, IntPtr.Zero), "Event handler set error");
                    Thread.Sleep(50);


                    
                    Thread.Sleep(150);
                    Do(EDSDK.EdsSendCommand(camDev, EDSDK.CameraCommand_TakePicture, 0), "Take error");

                    Thread.Sleep(150);

                }
                else
                    throw new Exception("is shooting");
            }
            catch (Exception e1)
            {
                isShooting = false;

                throw e1;
            }
        }

        private void Do(uint result, string p2)
        {
            if (result == EDSDK.EDS_ERR_COMM_DISCONNECTED)
                throw new Exception(p2 + "\r\nВозможно, камера не подключена\r\n" + errors.GetErrorByCode(result));
            if (result != EDSDK.EDS_ERR_OK)
                throw new Exception(p2 +"\r\n" + errors.GetErrorByCode(result));
        }

        private uint HandleObjectEvent(uint objectEvent, IntPtr sender, IntPtr context)//send = dirItem
        {
            if (objectEvent == EDSDK.ObjectEvent_DirItemRequestTransfer)
            {
                GC.Collect();
                EDSDK.EdsDirectoryItemInfo dirInfo;
                err = EDSDK.EdsGetDirectoryItemInfo(sender, out dirInfo);
                Thread.Sleep(100);
                //if (dirInfo.szFileName.IndexOf(".JPG") != -1)
                {
                    string Path = System.IO.Path.GetTempFileName();

                    Do(EDSDK.EdsCreateFileStream(Path, EDSDK.EdsFileCreateDisposition.CreateAlways,
                         EDSDK.EdsAccess.ReadWrite, out fStream), "Create File Stream");
                    Thread.Sleep(100);
                    Do(EDSDK.EdsDownload(sender, dirInfo.Size, fStream), "Download");
                    Thread.Sleep(100);
                    Do(EDSDK.EdsDownloadComplete(sender),"Download complete");
                    Thread.Sleep(100);
                    Do(EDSDK.EdsRelease(fStream), "Release");
                    fStream = IntPtr.Zero;
                    Thread.Sleep(10);

                    if (dirInfo.szFileName.IndexOf(".JPG") != -1)
                    {
                        Image img = Image.FromFile(Path);
                        //File.Delete(Path);
                        img.RotateFlip(rotateDirection);

                        if (ImageReady != null)
                            ImageReady(img);
                    }
                    isShooting = false;
                }
                try
                {
                    Do(EDSDK.EdsDeleteDirectoryItem(sender), "Delete Directory Item");
                    Thread.Sleep(100);
                }
                catch
                {
                    Debug.Print("Delete Error");
                }
            }

            return EDSDK.EDS_ERR_OK;
        }

        private void DeleteAll()
        {

        }

        public void Close()
        {
            Do(EDSDK.EdsCloseSession(camDev), "Close Session");
            Do(EDSDK.EdsTerminateSDK(),"Terminate SDK");
        }

        public void Dispose()
        {
            Close();
        }

        public ISO iso
        {
            set
            {
                if (camDev == IntPtr.Zero)
                    Init();
                SetPropertyData(EDSDK.PropID_ISOSpeed, (uint)value, "ISO set error");
            }
        }
        public TV tv
        {
            set
            {
                if (camDev == IntPtr.Zero)
                    Init();
                SetPropertyData(EDSDK.PropID_Tv, (uint)value, "TV set error");
            }
        }
        public AV av
        {
            set
            {
                if (camDev == IntPtr.Zero)
                    Init();
                SetPropertyData(EDSDK.PropID_Av, (uint)value, "AV set error");
            }
        }
        public enum PropertyId : uint
        {
            // Camera Setting Properties
            Unknown = 0x0000ffff,
            ProductName = 0x00000002,
            BodyID = 0x00000003,
            OwnerName = 0x00000004,
            MakerName = 0x00000005,
            DateTime = 0x00000006,
            FirmwareVersion = 0x00000007,
            BatteryLevel = 0x00000008,
            CFn = 0x00000009,
            SaveTo = 0x0000000b,
            CurrentStorage = 0x0000000c,
            CurrentFolder = 0x0000000d,
            MyMenu = 0x0000000e,
            BatteryQuality = 0x00000010,
            BodyIDEx = 0x00000015,
            HDDirectoryStructure = 0x00000020,
            QuickReviewTime = 0x0000000f,

            // Image Properties
            ImageQuality = 0x00000100,
            JpegQuality = 0x00000101,
            Orientation = 0x00000102,
            ICCProfile = 0x00000103,
            FocusInfo = 0x00000104,
            DigitalExposure = 0x00000105,
            WhiteBalance = 0x00000106,
            ColorTemperature = 0x00000107,
            WhiteBalanceShift = 0x00000108,
            Contrast = 0x00000109,
            ColorSaturation = 0x0000010a,
            ColorTone = 0x0000010b,
            Sharpness = 0x0000010c,
            ColorSpace = 0x0000010d,
            ToneCurve = 0x0000010e,
            PhotoEffect = 0x0000010f,
            FilterEffect = 0x00000110,
            ToningEffect = 0x00000111,
            ParameterSet = 0x00000112,
            ColorMatrix = 0x00000113,
            PictureStyle = 0x00000114,
            PictureStyleDesc = 0x00000115,
            PictureStyleCaption = 0x00000200,

            // Image Processing Properties
            Linear = 0x00000300,
            ClickWBPoint = 0x00000301,
            WBCoeffs = 0x00000302,

            // Property Mask
            AtCapture_Flag = 0x80000000,

            // Capture Properties
            AEMode = 0x00000400,
            DriveMode = 0x00000401,
            ISOSpeed = 0x00000402,
            MeteringMode = 0x00000403,
            AFMode = 0x00000404,
            Av = 0x00000405,
            Tv = 0x00000406,
            ExposureCompensation = 0x00000407,
            FlashCompensation = 0x00000408,
            FocalLength = 0x00000409,
            AvailableShots = 0x0000040a,
            Bracket = 0x0000040b,
            WhiteBalanceBracket = 0x0000040c,
            LensName = 0x0000040d,
            AEBracket = 0x0000040e,
            FEBracket = 0x0000040f,
            ISOBracket = 0x00000410,
            NoiseReduction = 0x00000411,
            FlashOn = 0x00000412,
            RedEye = 0x00000413,
            FlashMode = 0x00000414,
            LensStatus = 0x00000416,
            Artist = 0x00000418,
            Copyright = 0x00000419,
            DepthOfField = 0x0000041b,
            EFCompensation = 0x0000041e,

            // LiveView Properties
            LiveViewOutputDevice = 0x00000500,
            LiveViewMode = 0x00000501,
            LiveViewWhiteBalance = 0x00000502,
            LiveViewColorTemperature = 0x00000503,
            LiveViewDepthOfFieldPreview = 0x00000504,

            // LiveView IMAGE DATA Properties
            LiveViewZoom = 0x00000507,
            LiveViewZoomPosition = 0x00000508,
            LiveViewFocusAid = 0x00000509,
            LiveViewHistogram = 0x0000050A,
            LiveViewImagePosition = 0x0000050B,
            LiveViewHistogramStatus = 0x0000050C,
            LiveViewAFMode = 0x0000050E,

            LiveViewCoordinateSystem = 0x00000540,
            LiveViewZoomRectangle = 0x00000541,

            // Image GPS Properties
            GPSVersionID = 0x00000800,
            GPSLatitudeRef = 0x00000801,
            GPSLatitude = 0x00000802,
            GPSLongitudeRef = 0x00000803,
            GPSLongitude = 0x00000804,
            GPSAltitudeRef = 0x00000805,
            GPSAltitude = 0x00000806,
            GPSTimeStamp = 0x00000807,
            GPSSatellites = 0x00000808,
            GPSStatus = 0x00000809,
            GPSMapDatum = 0x00000812,
            GPSDateStamp = 0x0000081D,
        }

        protected StructureType GetStructProperty<StructureType>(PropertyId propertyId, int additionalInformation = 0)
            where StructureType : struct
        {
            Type structureType = typeof(StructureType);
            int bufferSize = Marshal.SizeOf(structureType); ;

            IntPtr structurePointer = GetProperty(propertyId, bufferSize, additionalInformation);

            try
            {
                StructureType data = (StructureType)Marshal.PtrToStructure(structurePointer, structureType);
                return data;
            }
            finally
            {
                // If buffer was allocated
                if (structurePointer != IntPtr.Zero)
                {
                    // Release him
                    Marshal.FreeHGlobal(structurePointer);
                    structurePointer = IntPtr.Zero;
                }
            }
        }

        private IntPtr GetProperty(PropertyId propertyId, int bufferSize, int additionalInformation = 0)
        {
            IntPtr allocatedBufferPointer = Marshal.AllocHGlobal(bufferSize);

            //try
            //{
            //    UInt32 returnValue = EDSDKInvokes.GetPropertyData(this.Handle, (UInt32)propertyId, additionalInformation, bufferSize, allocatedBufferPointer);
            //    ReturnValueManager.HandleFunctionReturnValue(returnValue);

            //}
            //// If Caught any exception during the native call
            //catch
            //{
            //    // If buffer was allocated
            //    if (allocatedBufferPointer != IntPtr.Zero)
            //    {
            //        // Release him
            //        Marshal.FreeHGlobal(allocatedBufferPointer);
            //        allocatedBufferPointer = IntPtr.Zero;
            //    }

            //    // Eventually, throw the caught exception
            //    throw;
            //}

            // Return the allocated buffer
            return allocatedBufferPointer;
        }

        public void focus()
        {
            //EDSDK.EdsFocusInfo fi;
            //uint r, o;
            //EDSDK.getP
            //r = EDSDK.EdsGetPropertyData(camDev, EDSDK.PropID_FocusInfo, 0, out o);
            
        }
    }
}