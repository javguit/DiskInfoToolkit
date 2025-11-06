using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal class NVME_PORT_40
    {
        public NVME_PORT_40()
        {
            ModelName    = new byte[41];
            SerialNumber = new byte[21];
        }

        public byte[] ModelName;         /* Model name of disk     */
        public byte[] SerialNumber;      /* Serial number of disk  */
        public uint SectorSize;          /* 512 bytes or 4K        */
        public uint Capacity;            /* Disk capacity          */
        public uint CapacityOffset;      /* Disk capacity          */
        public byte DeviceState;         /* Device State           */
        public byte RaidIndex;           /* RAID Index             */
        public byte MemberIndex;         /* Member Index           */
        public byte PortType;            /* Port Type              */
        public byte PCIeSpeed;           /* PCIe Speed             */
        public byte PCIeLANE;            /* PCIe LANE              */
        public ushort PortErrorStatus;   /* NVMe port error status */
        public byte DiskType;
    }
}
