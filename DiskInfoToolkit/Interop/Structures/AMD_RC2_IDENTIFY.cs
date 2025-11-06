using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct AMD_RC2_IDENTIFY
    {
        public AMD_RC2_IDENTIFY()
        {
            sModel        = new byte[41];
            sSerialNumber = new byte[21];
            sFirmwareRev  = new byte[ 9];
            sSpeed        = new byte[60];
            reserved3     = new byte[93];
        }

        public uint uStructSize;
        public uint uStructVersion;
        public uint uDiskNum;
        public int iPhysicalDrive;
        public ulong uDriveSize64;
        public uint uDriveSize;
        public byte isSSD;
        public byte isNVMe;
        public byte reserved1;
        public byte reserved2;
        public byte[] sModel;
        public byte[] sSerialNumber;
        public byte[] sFirmwareRev;
        public byte[] sSpeed;
        public byte[] reserved3;
    }
}
