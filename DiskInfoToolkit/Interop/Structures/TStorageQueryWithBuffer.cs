using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    internal struct TStorageQueryWithBuffer
    {
        public TStoragePropertyQuery Query;
        public TStorageProtocolSpecificData ProtocolSpecific;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4096)]
        public byte[] Buffer;
    }
}
