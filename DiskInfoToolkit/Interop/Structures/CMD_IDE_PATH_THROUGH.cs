using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct CMD_IDE_PATH_THROUGH
    {
        public CMD_IDE_PATH_THROUGH()
        {
            reg = new();
            buffer = new byte[1];
        }

        public IDEREGS reg;
        public uint length;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] buffer;
    }
}
