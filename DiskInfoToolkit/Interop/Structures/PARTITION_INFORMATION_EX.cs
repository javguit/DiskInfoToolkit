using DiskInfoToolkit.Interop.Enums;
using DiskInfoToolkit.Structures.Interop;
using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Explicit)]
    internal unsafe struct PARTITION_INFORMATION_EX
    {
        public PARTITION_INFORMATION_EX()
        {
            Layout = new();
        }

        [FieldOffset( 0)] public int PartitionStyle;
        [FieldOffset( 8)] public long StartingOffset;
        [FieldOffset(16)] public long PartitionLength;
        [FieldOffset(24)] public uint PartitionNumber;
        [FieldOffset(28)] public byte RewritePartition;

        //#if (NTDDI_VERSION >= NTDDI_WIN10_RS3)  /* ABRACADABRA_WIN10_RS3 */
        [FieldOffset(29)] public byte IsServicePartition;

        [FieldOffset(32)] public PartitionInformationUnion Layout;

        //public long StartingOffset => StartingOffsetRaw.QuadPart;

        //public long PartitionLength => PartitionLengthRaw.QuadPart;
    }
}
