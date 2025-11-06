using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct INTEL_NVME_PAYLOAD
    {
        public byte     Version;         // 0x001C
        public byte     PathId;          // 0x001D
        public byte     TargetID;        // 0x001E
        public byte     Lun;             // 0x001F
        public NVME_CMD Cmd;             // 0x0020 ~ 0x005F
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[]   CplEntry;        // 0x0060 ~ 0x006F
        public uint     QueueId;         // 0x0070 ~ 0x0073
        public uint     ParamBufLen;     // 0x0074
        public uint     ReturnBufferLen; // 0x0078
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 0x28)]
        public byte[]   __rsvd2;         // 0x007C ~ 0xA3

        public INTEL_NVME_PAYLOAD()
        {
            Cmd = new();

            CplEntry = new uint[4];
            __rsvd2 = new byte[0x28];
        }
    }
}
