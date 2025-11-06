using DiskInfoToolkit.Interop.Enums;
using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    internal struct TStorageProtocolSpecificData
    {
        public TStorageProtocolType ProtocolType;
        public uint DataType;
        public uint ProtocolDataRequestValue;
        public uint ProtocolDataRequestSubValue;
        public uint ProtocolDataOffset;
        public uint ProtocolDataLength;
        public uint FixedProtocolReturnData;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 3)]
        public uint[] Reserved;
    }
}
