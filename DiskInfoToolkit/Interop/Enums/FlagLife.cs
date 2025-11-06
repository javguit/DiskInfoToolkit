namespace DiskInfoToolkit.Interop.Enums
{
    [Flags]
    internal enum FlagLife
    {
        FlagLifeRawValue          = 0x01,
        FlagLifeRawValueIncrement = 0x02,
        FlagLifeSanDiskUsbMemory  = 0x04,
        FlagLifeSanDisk0_1        = 0x08,
        FlagLifeSanDisk1          = 0x10,
        FlagLifeSanDiskCloud      = 0x20,
        FlagLifeSanDiskLenovo     = 0x40,
    }
}
