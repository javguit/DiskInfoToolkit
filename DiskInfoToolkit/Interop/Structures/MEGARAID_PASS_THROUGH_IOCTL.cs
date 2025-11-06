using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MEGARAID_PASS_THROUGH_IOCTL
    {
        public MEGARAID_PASS_THROUGH_IOCTL()
        {
            SrbIoCtrl = new();
            Mpt = new();
            SenseBuf = new byte[112];
            DataBuf = new byte[4096];
        }

        public SRB_IO_CONTROL SrbIoCtrl;
        public MEGARAID_PASS_THROUGH Mpt;
        public byte[] SenseBuf;
        public byte[] DataBuf;
    }
}
