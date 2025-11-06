using DiskInfoToolkit.Interop;
using DiskInfoToolkit.Interop.Structures;
using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Disk
{
    internal class IdentifyDevice : IDisposable
    {
        #region Constructor

        static IdentifyDevice()
        {
            var sizeA = Marshal.SizeOf<ATA_IDENTIFY_DEVICE >();
            var sizeN = Marshal.SizeOf<NVME_IDENTIFY_DEVICE>();
            var sizeB = Marshal.SizeOf<BIN_IDENTIFY_DEVICE >();

            if (sizeA != InteropConstants.IDENTIFY_BUFFER_SIZE || sizeN != sizeB)
            {
                throw new Exception($"Internal structures of {nameof(IdentifyDevice)} are not of proper size.");
            }
        }

        public IdentifyDevice()
        {
            PtrSize = Marshal.SizeOf<BIN_IDENTIFY_DEVICE>();
            IdentifyDevicePtr = Marshal.AllocHGlobal(PtrSize);
        }

        ~IdentifyDevice()
        {
            Dispose();
        }

        #endregion

        #region Fields

        bool _Disposed;

        public IntPtr IdentifyDevicePtr;
        public int PtrSize;

        #endregion

        #region Public

        public void Dispose()
        {
            if (!_Disposed)
            {
                Marshal.FreeHGlobal(IdentifyDevicePtr);

                _Disposed = true;
            }
        }

        public ATA_IDENTIFY_DEVICE ToATA()
        {
            return Marshal.PtrToStructure<ATA_IDENTIFY_DEVICE>(IdentifyDevicePtr);
        }

        public NVME_IDENTIFY_DEVICE ToNVME()
        {
            return Marshal.PtrToStructure<NVME_IDENTIFY_DEVICE>(IdentifyDevicePtr);
        }

        public BIN_IDENTIFY_DEVICE ToBIN()
        {
            return Marshal.PtrToStructure<BIN_IDENTIFY_DEVICE>(IdentifyDevicePtr);
        }

        #endregion
    }
}
