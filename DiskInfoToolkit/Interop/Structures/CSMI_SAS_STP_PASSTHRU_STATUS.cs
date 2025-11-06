using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct CSMI_SAS_STP_PASSTHRU_STATUS
    {
        public CSMI_SAS_STP_PASSTHRU_STATUS()
        {
            bReserved  = new byte[3];
            bStatusFIS = new byte[20];
            uSCR       = new uint[16];
        }

        public byte bConnectionStatus;
        public byte[] bReserved;
        public byte[] bStatusFIS;
        public uint[] uSCR;
        public uint uDataBytes;
    }
}
