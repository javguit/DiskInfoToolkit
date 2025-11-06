using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct SmartThreshold
    {
        public SmartThreshold()
        {
            Reserved = new byte[10];
        }

        public byte ID;
        public byte ThresholdValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
        public byte[] Reserved;
    }
}
