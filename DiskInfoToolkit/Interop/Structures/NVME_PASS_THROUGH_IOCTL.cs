using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct NVME_PASS_THROUGH_IOCTL
    {
        public NVME_PASS_THROUGH_IOCTL()
        {
            SrbIoCtrl = new();

            VendorSpecific = new uint[InteropConstants.NVME_IOCTL_VENDOR_SPECIFIC_DW_SIZE];
            NVMeCmd        = new uint[InteropConstants.NVME_IOCTL_CMD_DW_SIZE];
            CplEntry       = new uint[InteropConstants.NVME_IOCTL_COMPLETE_DW_SIZE];
            DataBuffer     = new byte[4096];
        }

        public SRB_IO_CONTROL SrbIoCtrl;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = InteropConstants.NVME_IOCTL_VENDOR_SPECIFIC_DW_SIZE)]
        public uint[]        VendorSpecific;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = InteropConstants.NVME_IOCTL_CMD_DW_SIZE)]
        public uint[]        NVMeCmd;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = InteropConstants.NVME_IOCTL_COMPLETE_DW_SIZE)]
        public uint[]        CplEntry;
        public uint          Direction;
        public uint          QueueId;
        public uint          DataBufferLen;
        public uint          MetaDataLen;
        public uint          ReturnBufferLen;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[]        DataBuffer;
    }
}
