using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct SCSI_ADDRESS
    {
        public uint Length;
        public byte PortNumber;
        public byte PathId;
        public byte TargetId;
        public byte Lun;
    }
}
