using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DRIVE_LAYOUT_INFORMATION_EX
    {
        public DRIVE_LAYOUT_INFORMATION_EX()
        {
            Layout = new();
        }

        public uint PartitionStyle;
        public uint PartitionCount;

        public DRIVE_LAYOUT_INFORMATION_UNION Layout;

        //This is dynamic array
        public PARTITION_INFORMATION_EX PartitionInformation;
    }
}
