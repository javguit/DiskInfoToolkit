using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct ATA_PASS_THROUGH_EX
    {
        public ATA_PASS_THROUGH_EX()
        {
            PreviousTaskFile = new();
            CurrentTaskFile = new();
        }

        public ushort Length;
        public ushort AtaFlags;
        public byte PathId;
        public byte TargetId;
        public byte Lun;
        public byte ReservedAsUchar;
        public uint DataTransferLength;
        public uint TimeOutValue;
        public uint ReservedAsUlong;
        public uint padding;
        public ulong DataBufferOffset;
        public IDEREGS PreviousTaskFile;
        public IDEREGS CurrentTaskFile;
    }
}
