using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal struct UNION_IDENTIFY_DEVICE
    {
        public UNION_IDENTIFY_DEVICE()
        {
            I = new();
            N = new();
            B = new();
        }

        [FieldOffset(0)] public IDENTIFY_DEVICE_JMICRON I;
        [FieldOffset(0)] public NVME_IDENTIFY_DEVICE_JMICRON N;
        [FieldOffset(0)] public BYTE512 B;
    }
}
