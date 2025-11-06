using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct CSMI_SAS_STP_PASSTHRU_BUFFER
    {
        public CSMI_SAS_STP_PASSTHRU_BUFFER()
        {
            IoctlHeader = new();
            Parameters = new();
            Status = new();
            bDataBuffer = new byte[1];
        }

        public SRB_IO_CONTROL IoctlHeader;
        public CSMI_SAS_STP_PASSTHRU Parameters;
        public CSMI_SAS_STP_PASSTHRU_STATUS Status;
        public byte[] bDataBuffer;
    }
}
