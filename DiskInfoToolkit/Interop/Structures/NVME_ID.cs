using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class NVME_ID
    {
        public NVME_ID()
        {
            FirmwareRevision = new byte[ 8];
            FGUID            = new byte[16];
            IeeeOuiID        = new byte[ 3];
        }

        public ushort PCIeVID;
        public ushort PCIeSubSysVID;
        public byte ControllerMultIO;
        public byte MaxTransferSize;
        public ushort ControllerID;
        public byte[] FirmwareRevision;
        public byte[] FGUID;
        public ushort WarnTemperatureThreshold;
        public ushort CriticalTemperatureThreshold;
        public ushort MinThermalTemperature;
        public ushort MaxThermalTemperature;
        public uint NumOFNamespace;
        public byte[] IeeeOuiID;
    }
}
