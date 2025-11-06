using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Explicit, Pack = 1)]
    internal struct UNION_SMART_THRESHOLD
    {
        public UNION_SMART_THRESHOLD()
        {
            T = new();
            B = new();
        }

        [FieldOffset(0)] public SMART_READ_THRESHOLD T;
        [FieldOffset(0)] public BYTE512 B;
    }
}
