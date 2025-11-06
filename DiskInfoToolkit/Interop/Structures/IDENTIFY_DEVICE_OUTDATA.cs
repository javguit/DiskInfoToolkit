using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct IDENTIFY_DEVICE_OUTDATA
    {
        public IDENTIFY_DEVICE_OUTDATA()
        {
            SendCmdOutParam = new();

            Data = new byte[InteropConstants.IDENTIFY_BUFFER_SIZE - 1];
        }

        public SENDCMDOUTPARAMS SendCmdOutParam;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = InteropConstants.IDENTIFY_BUFFER_SIZE - 1)]
        public byte[] Data;
    }
}
