using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Auto)]
    internal struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        public int cbSize;
        //[MarshalAs(UnmanagedType.ByValTStr, SizeConst = 256)]
        //public string DevicePath;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 256)]
        public byte[] DevicePath;
    }
}
