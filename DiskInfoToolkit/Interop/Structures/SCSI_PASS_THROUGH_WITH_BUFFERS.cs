using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SCSI_PASS_THROUGH_WITH_BUFFERS
    {
        public SCSI_PASS_THROUGH_WITH_BUFFERS()
        {
            Spt = new();

            SenseBuf = new byte[32];
            DataBuf  = new byte[4096];
        }

        public SCSI_PASS_THROUGH Spt;
        public uint Filler;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 32)]
        public byte[] SenseBuf;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] DataBuf;
    }
}
