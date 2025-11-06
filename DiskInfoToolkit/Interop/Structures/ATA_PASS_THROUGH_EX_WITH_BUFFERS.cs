using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ATA_PASS_THROUGH_EX_WITH_BUFFERS
    {
        public ATA_PASS_THROUGH_EX_WITH_BUFFERS()
        {
            Apt = new();
            Buf = new byte[512];
        }

        public ATA_PASS_THROUGH_EX Apt;
        public uint Filler;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] Buf;
    }
}
