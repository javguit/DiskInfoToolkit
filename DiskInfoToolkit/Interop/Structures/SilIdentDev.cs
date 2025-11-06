using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SilIdentDev
    {
        public SilIdentDev()
        {
            sic = new();

            unknown = new uint[5];
            id_data = new short[256];
        }

        public SRB_IO_CONTROL sic;
        public ushort port;
        public ushort maybe_always1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public uint[] unknown;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public short[] id_data;
    }
}
