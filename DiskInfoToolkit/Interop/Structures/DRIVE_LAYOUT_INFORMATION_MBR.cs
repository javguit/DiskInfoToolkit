using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct DRIVE_LAYOUT_INFORMATION_MBR
    {
        public uint Signature;

        //#if (NTDDI_VERSION >= NTDDI_WIN10_RS1)  /* ABRACADABRA_WIN10_RS1 */
        public uint CheckSum;
    }
}
