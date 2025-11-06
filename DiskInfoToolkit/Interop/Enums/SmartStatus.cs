namespace DiskInfoToolkit.Interop.Enums
{
    [Flags]
    internal enum SmartStatus : byte
    {
        Nothing            = 0x0,
        IsSmartSupported   = 0x1,
        IsSmartEnabled     = 0x2,
        IsSmartCorrect     = 0x4,
        IsThresholdCorrect = 0x8,
        IsThresholdBug     = 0x10,
    }
}
