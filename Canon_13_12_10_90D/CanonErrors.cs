using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Canon_13_12_10_90D
{
    class CanonError
    {
        public ulong Code;
        public string DescriptionEng;

        public CanonError(ulong code,string descr)
        {
            Code = code;
            DescriptionEng = descr;
        }
    }

    public class CanonErrors
    {
        List<CanonError> errors = new List<CanonError>();

        public string GetErrorByCode(ulong code)
        {
            return errors.Where(x => x.Code == code).FirstOrDefault()?.DescriptionEng ?? code.ToString();
        }

        public CanonErrors()
        {
            errors.Add(new CanonError(0x80000000, "EDS_ISSPECIFIC_MASK"));
            errors.Add(new CanonError(0x7F000000, "EDS_COMPONENTID_MASK"));
            errors.Add(new CanonError(0x00FF0000, "EDS_RESERVED_MASK"));
            errors.Add(new CanonError(0x0000FFFF, "EDS_ERRORID_MASK"));
            errors.Add(new CanonError(0x01000000, "EDS_CMP_ID_CLIENT_COMPONENTID"));
            errors.Add(new CanonError(0x02000000, "EDS_CMP_ID_LLSDK_COMPONENTID"));
            errors.Add(new CanonError(0x03000000, "EDS_CMP_ID_HLSDK_COMPONENTID"));
            errors.Add(new CanonError(0x00000000, "EDS_ERR_OK"));
            errors.Add(new CanonError(0x00000001, "EDS_ERR_UNIMPLEMENTED"));
            errors.Add(new CanonError(0x00000002, "EDS_ERR_INTERNAL_ERROR"));
            errors.Add(new CanonError(0x00000003, "EDS_ERR_MEM_ALLOC_FAILED"));
            errors.Add(new CanonError(0x00000004, "EDS_ERR_MEM_FREE_FAILED"));
            errors.Add(new CanonError(0x00000005, "EDS_ERR_OPERATION_CANCELLED"));
            errors.Add(new CanonError(0x00000006, "EDS_ERR_INCOMPATIBLE_VERSION"));
            errors.Add(new CanonError(0x00000007, "EDS_ERR_NOT_SUPPORTED"));
            errors.Add(new CanonError(0x00000008, "EDS_ERR_UNEXPECTED_EXCEPTION"));
            errors.Add(new CanonError(0x00000009, "EDS_ERR_PROTECTION_VIOLATION"));
            errors.Add(new CanonError(0x0000000A, "EDS_ERR_MISSING_SUBCOMPONENT"));
            errors.Add(new CanonError(0x0000000B, "EDS_ERR_SELECTION_UNAVAILABLE"));
            errors.Add(new CanonError(0x00000020, "EDS_ERR_FILE_IO_ERROR"));
            errors.Add(new CanonError(0x00000021, "EDS_ERR_FILE_TOO_MANY_OPEN"));
            errors.Add(new CanonError(0x00000022, "EDS_ERR_FILE_NOT_FOUND"));
            errors.Add(new CanonError(0x00000023, "EDS_ERR_FILE_OPEN_ERROR"));
            errors.Add(new CanonError(0x00000024, "EDS_ERR_FILE_CLOSE_ERROR"));
            errors.Add(new CanonError(0x00000025, "EDS_ERR_FILE_SEEK_ERROR"));
            errors.Add(new CanonError(0x00000026, "EDS_ERR_FILE_TELL_ERROR"));
            errors.Add(new CanonError(0x00000027, "EDS_ERR_FILE_READ_ERROR"));
            errors.Add(new CanonError(0x00000028, "EDS_ERR_FILE_WRITE_ERROR"));
            errors.Add(new CanonError(0x00000029, "EDS_ERR_FILE_PERMISSION_ERROR"));
            errors.Add(new CanonError(0x0000002A, "EDS_ERR_FILE_DISK_FULL_ERROR"));
            errors.Add(new CanonError(0x0000002B, "EDS_ERR_FILE_ALREADY_EXISTS"));
            errors.Add(new CanonError(0x0000002C, "EDS_ERR_FILE_FORMAT_UNRECOGNIZED"));
            errors.Add(new CanonError(0x0000002D, "EDS_ERR_FILE_DATA_CORRUPT"));
            errors.Add(new CanonError(0x0000002E, "EDS_ERR_FILE_NAMING_NA"));
            errors.Add(new CanonError(0x00000040, "EDS_ERR_DIR_NOT_FOUND"));
            errors.Add(new CanonError(0x00000041, "EDS_ERR_DIR_IO_ERROR"));
            errors.Add(new CanonError(0x00000042, "EDS_ERR_DIR_ENTRY_NOT_FOUND"));
            errors.Add(new CanonError(0x00000043, "EDS_ERR_DIR_ENTRY_EXISTS"));
            errors.Add(new CanonError(0x00000044, "EDS_ERR_DIR_NOT_EMPTY"));
            errors.Add(new CanonError(0x00000050, "EDS_ERR_PROPERTIES_UNAVAILABLE"));
            errors.Add(new CanonError(0x00000051, "EDS_ERR_PROPERTIES_MISMATCH"));
            errors.Add(new CanonError(0x00000053, "EDS_ERR_PROPERTIES_NOT_LOADED"));
            errors.Add(new CanonError(0x00000060, "EDS_ERR_INVALID_PARAMETER"));
            errors.Add(new CanonError(0x00000061, "EDS_ERR_INVALID_HANDLE"));
            errors.Add(new CanonError(0x00000062, "EDS_ERR_INVALID_POINTER"));
            errors.Add(new CanonError(0x00000063, "EDS_ERR_INVALID_INDEX"));
            errors.Add(new CanonError(0x00000064, "EDS_ERR_INVALID_LENGTH"));
            errors.Add(new CanonError(0x00000065, "EDS_ERR_INVALID_FN_POINTER"));
            errors.Add(new CanonError(0x00000066, "EDS_ERR_INVALID_SORT_FN"));
            errors.Add(new CanonError(0x00000080, "EDS_ERR_DEVICE_NOT_FOUND"));
            errors.Add(new CanonError(0x00000081, "EDS_ERR_DEVICE_BUSY"));
            errors.Add(new CanonError(0x00000082, "EDS_ERR_DEVICE_INVALID"));
            errors.Add(new CanonError(0x00000083, "EDS_ERR_DEVICE_EMERGENCY"));
            errors.Add(new CanonError(0x00000084, "EDS_ERR_DEVICE_MEMORY_FULL"));
            errors.Add(new CanonError(0x00000085, "EDS_ERR_DEVICE_INTERNAL_ERROR"));
            errors.Add(new CanonError(0x00000086, "EDS_ERR_DEVICE_INVALID_PARAMETER"));
            errors.Add(new CanonError(0x00000087, "EDS_ERR_DEVICE_NO_DISK"));
            errors.Add(new CanonError(0x00000088, "EDS_ERR_DEVICE_DISK_ERROR"));
            errors.Add(new CanonError(0x00000089, "EDS_ERR_DEVICE_CF_GATE_CHANGED"));
            errors.Add(new CanonError(0x0000008A, "EDS_ERR_DEVICE_DIAL_CHANGED"));
            errors.Add(new CanonError(0x0000008B, "EDS_ERR_DEVICE_NOT_INSTALLED"));
            errors.Add(new CanonError(0x0000008C, "EDS_ERR_DEVICE_STAY_AWAKE"));
            errors.Add(new CanonError(0x0000008D, "EDS_ERR_DEVICE_NOT_RELEASED"));
            errors.Add(new CanonError(0x000000A0, "EDS_ERR_STREAM_IO_ERROR"));
            errors.Add(new CanonError(0x000000A1, "EDS_ERR_STREAM_NOT_OPEN"));
            errors.Add(new CanonError(0x000000A2, "EDS_ERR_STREAM_ALREADY_OPEN"));
            errors.Add(new CanonError(0x000000A3, "EDS_ERR_STREAM_OPEN_ERROR"));
            errors.Add(new CanonError(0x000000A4, "EDS_ERR_STREAM_CLOSE_ERROR"));
            errors.Add(new CanonError(0x000000A5, "EDS_ERR_STREAM_SEEK_ERROR"));
            errors.Add(new CanonError(0x000000A6, "EDS_ERR_STREAM_TELL_ERROR"));
            errors.Add(new CanonError(0x000000A7, "EDS_ERR_STREAM_READ_ERROR"));
            errors.Add(new CanonError(0x000000A8, "EDS_ERR_STREAM_WRITE_ERROR"));
            errors.Add(new CanonError(0x000000A9, "EDS_ERR_STREAM_PERMISSION_ERROR"));
            errors.Add(new CanonError(0x000000AA, "EDS_ERR_STREAM_COULDNT_BEGIN_THREAD"));
            errors.Add(new CanonError(0x000000AB, "EDS_ERR_STREAM_BAD_OPTIONS"));
            errors.Add(new CanonError(0x000000AC, "EDS_ERR_STREAM_END_OF_STREAM"));
            errors.Add(new CanonError(0x000000C0, "EDS_ERR_COMM_PORT_IS_IN_USE"));
            errors.Add(new CanonError(0x000000C1, "EDS_ERR_COMM_DISCONNECTED"));
            errors.Add(new CanonError(0x000000C2, "EDS_ERR_COMM_DEVICE_INCOMPATIBLE"));
            errors.Add(new CanonError(0x000000C3, "EDS_ERR_COMM_BUFFER_FULL"));
            errors.Add(new CanonError(0x000000C4, "EDS_ERR_COMM_USB_BUS_ERR"));
            errors.Add(new CanonError(0x000000D0, "EDS_ERR_USB_DEVICE_LOCK_ERROR"));
            errors.Add(new CanonError(0x000000D1, "EDS_ERR_USB_DEVICE_UNLOCK_ERROR"));
            errors.Add(new CanonError(0x000000E0, "EDS_ERR_STI_UNKNOWN_ERROR"));
            errors.Add(new CanonError(0x000000E1, "EDS_ERR_STI_INTERNAL_ERROR"));
            errors.Add(new CanonError(0x000000E2, "EDS_ERR_STI_DEVICE_CREATE_ERROR"));
            errors.Add(new CanonError(0x000000E3, "EDS_ERR_STI_DEVICE_RELEASE_ERROR"));
            errors.Add(new CanonError(0x000000E4, "EDS_ERR_DEVICE_NOT_LAUNCHED"));
            errors.Add(new CanonError(0x000000F0, "EDS_ERR_ENUM_NA"));
            errors.Add(new CanonError(0x000000F1, "EDS_ERR_INVALID_FN_CALL"));
            errors.Add(new CanonError(0x000000F2, "EDS_ERR_HANDLE_NOT_FOUND"));
            errors.Add(new CanonError(0x000000F3, "EDS_ERR_INVALID_ID"));
            errors.Add(new CanonError(0x000000F4, "EDS_ERR_WAIT_TIMEOUT_ERROR"));
            errors.Add(new CanonError(0x00002003, "EDS_ERR_SESSION_NOT_OPEN"));
            errors.Add(new CanonError(0x00002004, "EDS_ERR_INVALID_TRANSACTIONID"));
            errors.Add(new CanonError(0x00002007, "EDS_ERR_INCOMPLETE_TRANSFER"));
            errors.Add(new CanonError(0x00002008, "EDS_ERR_INVALID_STRAGEID"));
            errors.Add(new CanonError(0x0000200A, "EDS_ERR_DEVICEPROP_NOT_SUPPORTED"));
            errors.Add(new CanonError(0x0000200B, "EDS_ERR_INVALID_OBJECTFORMATCODE"));
            errors.Add(new CanonError(0x00002011, "EDS_ERR_SELF_TEST_FAILED"));
            errors.Add(new CanonError(0x00002012, "EDS_ERR_PARTIAL_DELETION"));
            errors.Add(new CanonError(0x00002014, "EDS_ERR_SPECIFICATION_BY_FORMAT_UNSUPPORTED"));
            errors.Add(new CanonError(0x00002015, "EDS_ERR_NO_VALID_OBJECTINFO"));
            errors.Add(new CanonError(0x00002016, "EDS_ERR_INVALID_CODE_FORMAT"));
            errors.Add(new CanonError(0x00002017, "EDS_ERR_UNKNOWN_VENDER_CODE"));
            errors.Add(new CanonError(0x00002018, "EDS_ERR_CAPTURE_ALREADY_TERMINATED"));
            errors.Add(new CanonError(0x0000201A, "EDS_ERR_INVALID_PARENTOBJECT"));
            errors.Add(new CanonError(0x0000201B, "EDS_ERR_INVALID_DEVICEPROP_FORMAT"));
            errors.Add(new CanonError(0x0000201C, "EDS_ERR_INVALID_DEVICEPROP_VALUE"));
            errors.Add(new CanonError(0x0000201E, "EDS_ERR_SESSION_ALREADY_OPEN"));
            errors.Add(new CanonError(0x0000201F, "EDS_ERR_TRANSACTION_CANCELLED"));
            errors.Add(new CanonError(0x00002020, "EDS_ERR_SPECIFICATION_OF_DESTINATION_UNSUPPORTED"));
            errors.Add(new CanonError(0x0000A001, "EDS_ERR_UNKNOWN_COMMAND"));
            errors.Add(new CanonError(0x0000A005, "EDS_ERR_OPERATION_REFUSED"));
            errors.Add(new CanonError(0x0000A006, "EDS_ERR_LENS_COVER_CLOSE"));
            errors.Add(new CanonError(0x0000A101, "EDS_ERR_LOW_BATTERY"));
            errors.Add(new CanonError(0x0000A102, "EDS_ERR_OBJECT_NOTREADY"));
            errors.Add(new CanonError(0x00008D01, "EDS_ERR_TAKE_PICTURE_AF_NG"));
            errors.Add(new CanonError(0x00008D02, "EDS_ERR_TAKE_PICTURE_RESERVED"));
            errors.Add(new CanonError(0x00008D03, "EDS_ERR_TAKE_PICTURE_MIRROR_UP_NG"));
            errors.Add(new CanonError(0x00008D04, "EDS_ERR_TAKE_PICTURE_SENSOR_CLEANING_NG"));
            errors.Add(new CanonError(0x00008D05, "EDS_ERR_TAKE_PICTURE_SILENCE_NG"));
            errors.Add(new CanonError(0x00008D06, "EDS_ERR_TAKE_PICTURE_NO_CARD_NG"));
            errors.Add(new CanonError(0x00008D07, "EDS_ERR_TAKE_PICTURE_CARD_NG"));
            errors.Add(new CanonError(0x00008D08, "EDS_ERR_TAKE_PICTURE_CARD_PROTECT_NG"));
            errors.Add(new CanonError(0x000000F5, "EDS_ERR_LAST_GENERIC_ERROR_PLUS_ONE"));
            errors.Add(new CanonError(0x000000F5, "EDS_ERR_LAST_GENERIC_ERROR_PLUS_ONE"));
        }
    }
}
