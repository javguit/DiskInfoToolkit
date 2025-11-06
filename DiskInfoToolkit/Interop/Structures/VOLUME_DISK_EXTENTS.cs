using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct VOLUME_DISK_EXTENTS
    {
        public uint NumberOfDiskExtents;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 1)]
        public DISK_EXTENT[] Extents;
    }
}
