using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MEGARAID_DCOMD_IOCTL
    {
        public MEGARAID_DCOMD_IOCTL()
        {
            SrbIoCtrl = new();
            Mpt = new();
            SenseBuf = new byte[120];
            DataBuf = new byte[4096];
        }

        public SRB_IO_CONTROL SrbIoCtrl;
        public MEGARAID_DCOMD Mpt;
        public byte[] SenseBuf;
        public byte[] DataBuf;
    }
}
