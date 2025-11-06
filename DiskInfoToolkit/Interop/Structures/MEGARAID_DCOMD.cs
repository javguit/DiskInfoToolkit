using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct MEGARAID_DCOMD
    {
        public MEGARAID_DCOMD()
        {
            Reserved1 = new byte[4];
            Mbox = new byte[12];
        }

        public byte Cmd;
        public byte Reserved0;
        public byte CmdStatus;
        public byte[] Reserved1;
        public byte SenseInfoLength;

        public uint Context;
        public uint Padding0;

        public ushort Flags;
        public ushort TimeOutValue;

        public uint DataTransferLength;
        public uint Opcode;

        public byte[] Mbox;
    }
}
