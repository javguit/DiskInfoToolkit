using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SENDCMDINPARAMS
    {
        public SENDCMDINPARAMS()
        {
            irDriveRegs = new();

            bReserved  = new byte[5];
            dwReserved = new uint[4];
            bBuffer    = new byte[1];
        }

        public uint cBufferSize;
        public IDEREGS irDriveRegs;
        public byte bDriveNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 5)]
        public byte[] bReserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public uint[] dwReserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public byte[] bBuffer;
    }
}
