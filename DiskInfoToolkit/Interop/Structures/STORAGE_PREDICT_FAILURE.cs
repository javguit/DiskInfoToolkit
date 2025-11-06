using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential)]
    internal struct STORAGE_PREDICT_FAILURE
    {
        public STORAGE_PREDICT_FAILURE()
        {
            VendorSpecific = new byte[512];
        }

        public uint PredictFailure;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 512)]
        public byte[] VendorSpecific;
    }
}
