using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct CSMI_SAS_STP_PASSTHRU
    {
        public CSMI_SAS_STP_PASSTHRU()
        {
            bDestinationSASAddress = new byte[8];
            bReserved2             = new byte[4];
            bCommandFIS            = new byte[20];
        }

        public byte bPhyIdentifier;
        public byte bPortIdentifier;
        public byte bConnectionRate;
        public byte bReserved;
        public byte[] bDestinationSASAddress;
        public byte[] bReserved2;
        public byte[] bCommandFIS;
        public uint uFlags;
        public uint uDataLength;
    }
}
