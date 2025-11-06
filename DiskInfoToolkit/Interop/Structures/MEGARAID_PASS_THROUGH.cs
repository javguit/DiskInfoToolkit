using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MEGARAID_PASS_THROUGH
    {
        public MEGARAID_PASS_THROUGH()
        {
            Cdb = new byte[16];
        }

        public byte Cmd;
        public byte SenseLength;
        public byte CmdStatus;
        public byte ScsiStatus;

        public byte TargetId;
        public byte Lun;
        public byte CdbLength;
        public byte SenseInfoLength;

        public uint Context;
        public uint Padding0;

        public ushort Flags;
        public ushort TimeOutValue;
        public uint DataTransferLength;

        public uint SenseInfoOffsetLo;
        public uint SenseInfoOffsetHi;

        public byte[] Cdb;
    }
}
