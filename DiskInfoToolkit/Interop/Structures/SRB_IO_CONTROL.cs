using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    internal struct SRB_IO_CONTROL
    {
        public SRB_IO_CONTROL()
        {
            Signature = new byte[8];
        }

        public uint HeaderLength;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] Signature;
        public uint Timeout;
        public uint ControlCode;
        public uint ReturnCode;
        public uint Length;
    }
}
