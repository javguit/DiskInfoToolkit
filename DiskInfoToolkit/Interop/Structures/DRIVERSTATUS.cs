using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct DRIVERSTATUS
    {
        public DRIVERSTATUS()
        {
            bReserved = new byte[2];
            dwReserved = new uint[2];
        }

        public byte bDriverError;
        public byte bIDEError;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] bReserved;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public uint[] dwReserved;
    }
}
