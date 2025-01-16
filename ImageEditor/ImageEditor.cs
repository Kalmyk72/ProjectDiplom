using Emgu.CV;
using Emgu.CV.Structure;
using System.CodeDom.Compiler;
using Emgu.CV.CvEnum;
using Emgu.CV.Util;
using System.Windows.Forms;

namespace ImageEditor
{
    public partial class ImageEditor : Form
    {

        /// <summary>
        /// RGB изображение
        /// </summary>
        Image<Rgb, byte> ImgInput { get; set; }
        /// <summary>
        /// HSV изображение
        /// </summary>
        Image<Hsv, byte> HSVImg { get; set; }
        /// <summary>
        /// Gray изображение
        /// </summary>
        Image<Gray, byte> GrayImg { get; set; }
        /// <summary>
        /// Входное изображение с повышением яркости
        /// </summary>
        Image<Rgb, byte> RGBImg { get; set; }
        /// <summary>
        /// HSV настроенное
        /// </summary>
        Image<Hsv, byte> Temp { get; set; }
        /// <summary>
        /// копия Temp
        /// </summary>
        Image<Hsv, byte> TempImg { get; set; }
        public ImageEditor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Открыть изображение
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_open_image_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Изображения (*.jpg;*.png;*.bmp)|*.jpg;*.png;*.bmp;";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                ImgInput = new Image<Rgb, byte>(openFileDialog.FileName);
                if (ImgInput != null)
                {
                    HSVImg = ImgInput.Convert<Hsv, byte>();                    
                    picbox_unedit_image.Image = HSVImg.AsBitmap();
                }

            }
        }
        /// <summary>
        /// Конверация hsv в rgb
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_color_transform_Click(object sender, EventArgs e)
        {
            try
            {
                TempImg = Temp.Copy();
                if (TempImg != null)
                {
                    RGBImg = TempImg.Convert<Rgb, byte>();

                    picbox_type_transform.Image = RGBImg.AsBitmap();
                }
            }
            catch (Exception ex) 
            { 
                MessageBox.Show(ex.Message);
            }
            
            
        }
        /// <summary>
        /// Изменить насыщенность
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void HSV_Trackbar(object sender, EventArgs e)
        {
            if (HSVImg != null)
            {
                Temp = HSVImg.Copy();
                Temp[2] += trackbar_changeSaturation.Value;
                picbox_unedit_image.Image = Temp.AsBitmap();
            }
        }

        private void btn_Crop_Click(object sender, EventArgs e)
        {
            if (RGBImg != null)
            {
                GrayImg = RGBImg.SmoothGaussian(5).Convert<Gray, byte>().ThresholdBinary(new Gray(215),new Gray(255)).Not();

                Mat structureElement = CvInvoke.GetStructuringElement(ElementShape.Rectangle, new Size(3, 3), new Point(0, 0));
                CvInvoke.MorphologyEx(GrayImg, GrayImg, MorphOp.Close, structureElement, new Point(0, 0), 5, BorderType.Default, new MCvScalar(255, 0, 0));

                VectorOfVectorOfPoint contour = new VectorOfVectorOfPoint();
                Mat hierarchy = new Mat();

                CvInvoke.FindContours(GrayImg,contour, hierarchy, RetrType.External, ChainApproxMethod.ChainApproxSimple);
                //pictureBox1.Image = GrayImg.AsBitmap();


                if (contour.Size > 0) 
                {                    
                    Rectangle bbox = CvInvoke.BoundingRectangle(contour[0]);
                    if (bbox.Width > 100)
                    {
                        RGBImg.ROI = bbox;
                        var img = RGBImg.Copy();
                        RGBImg.ROI = Rectangle.Empty;

                        pictureBox1.Image = img.AsBitmap();
                    }                   
                }                                    
            }
        }
           
    }
}
