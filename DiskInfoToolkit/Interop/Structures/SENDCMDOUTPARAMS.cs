using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SENDCMDOUTPARAMS
    {
        public SENDCMDOUTPARAMS()
        {
            DriverStatus = new();
            bBuffer = new byte[1];
        }

        public uint cBufferSize;
        public DRIVERSTATUS DriverStatus;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] bBuffer;
    }
}
