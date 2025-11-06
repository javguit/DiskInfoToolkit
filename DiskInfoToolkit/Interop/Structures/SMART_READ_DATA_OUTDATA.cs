using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SMART_READ_DATA_OUTDATA
    {
        public SMART_READ_DATA_OUTDATA()
        {
            SendCmdOutParam = new();
            Data = new byte[InteropConstants.READ_ATTRIBUTE_BUFFER_SIZE - 1];
        }

        public SENDCMDOUTPARAMS SendCmdOutParam;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = InteropConstants.READ_ATTRIBUTE_BUFFER_SIZE - 1)]
        public byte[] Data;
    }
}
