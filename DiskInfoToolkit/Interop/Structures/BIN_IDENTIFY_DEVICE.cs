using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    /// <summary>
    /// 4096 bytes.
    /// </summary>
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct BIN_IDENTIFY_DEVICE
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] Bin;
    }
}
