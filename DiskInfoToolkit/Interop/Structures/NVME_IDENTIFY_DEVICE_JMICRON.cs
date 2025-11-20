using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    internal unsafe struct NVME_IDENTIFY_DEVICE_JMICRON
    {
        public fixed byte Reserved1[4];     // 0–3
        public fixed byte SerialNumber[20]; // 4–23
        public fixed byte Model[40];        //24–63
        public fixed byte FirmwareRev[8];   //64–71
        public fixed byte Reserved2[9];     //72–80
        public byte        MinorVersion;    // 81
        public short       MajorVersion;    //82–83
        public fixed byte Reserved3[428];   //84–511
    }
}
