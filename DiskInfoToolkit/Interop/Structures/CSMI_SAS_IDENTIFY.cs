using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 8)]
    internal struct CSMI_SAS_IDENTIFY
    {
        public CSMI_SAS_IDENTIFY()
        {
            bRestricted2 = new byte[8];
            bSASAddress  = new byte[8];
            bReserved    = new byte[6];
        }

        public byte bDeviceType;
		public byte bRestricted;
		public byte bInitiatorPortProtocol;
		public byte bTargetPortProtocol;
		public byte[] bRestricted2;
		public byte[] bSASAddress;
		public byte bPhyIdentifier;
		public byte bSignalClass;
		public byte[] bReserved;
    }
}
