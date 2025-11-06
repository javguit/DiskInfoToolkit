using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal struct NVME_IDENTIFY_DEVICE_JMICRON
    {
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 4)]
        public byte[] Reserved1;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] SerialNumber;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 40)]
        public byte[] Model;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 8)]
        public byte[] FirmwareRev;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 9)]
        public byte[] Reserved2;
        public byte MinorVersion;
        public short MajorVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 428)]
        public byte[] Reserved3;
    }
}
