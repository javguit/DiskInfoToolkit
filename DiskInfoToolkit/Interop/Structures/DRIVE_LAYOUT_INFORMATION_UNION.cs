using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Explicit)]
    internal struct DRIVE_LAYOUT_INFORMATION_UNION
    {
        public DRIVE_LAYOUT_INFORMATION_UNION()
        {
            Mbr = new();
            Gpt = new();
        }

        [FieldOffset(0)] public DRIVE_LAYOUT_INFORMATION_MBR Mbr;
        [FieldOffset(0)] public DRIVE_LAYOUT_INFORMATION_GPT Gpt;
    }
}
