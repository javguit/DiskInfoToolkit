using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SCSI_PASS_THROUGH_WITH_BUFFERS24
    {
        public SCSI_PASS_THROUGH_WITH_BUFFERS24()
        {
            Spt = new();

            SenseBuf = new byte[24];
            DataBuf  = new byte[4096];
        }

        public SCSI_PASS_THROUGH Spt;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 24)]
        public byte[] SenseBuf;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] DataBuf;
    }
}
