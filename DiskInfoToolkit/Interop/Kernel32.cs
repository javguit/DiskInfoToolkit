/*
 * This Source Code Form is subject to the terms of the Mozilla Public
 * License, v. 2.0. If a copy of the MPL was not distributed with this
 * file, You can obtain one at https://mozilla.org/MPL/2.0/.
 *
 * Copyright (c) 2025 Florian K.
 *
 * Code inspiration, improvements and fixes are from, but not limited to, following projects:
 * CrystalDiskInfo
 */

using DiskInfoToolkit.Interop.Structures;
using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop
{
    internal class Kernel32
    {
        const string DLL_NAME = "kernel32.dll";

        public const uint IOCTL_DISK_GET_DRIVE_GEOMETRY_EX = 0x000700A0;
        public const uint IOCTL_STORAGE_QUERY_PROPERTY = 0x002D1400;
        public const uint IOCTL_STORAGE_GET_DEVICE_NUMBER = 0x002D1080;
        public const uint IOCTL_SMART_GET_VERSION = 0x00074080;
        public const uint IOCTL_SCSI_PASS_THROUGH = 0x04d004;
        public const uint IOCTL_SCSI_MINIPORT = 0x04d008;
        public const uint IOCTL_INTEL_NVME_PASS_THROUGH = 0xF0002808;
        public const uint IOCTL_SCSI_GET_ADDRESS = 0x41018;
        public const uint IOCTL_SCSI_MINIPORT_IDENTIFY = 0x1B0501;
        public const uint IOCTL_DISK_GET_DRIVE_LAYOUT_EX = 0x70050;
        public const uint IOCTL_VOLUME_GET_VOLUME_DISK_EXTENTS = 0x560000;
        public const uint IOCTL_ATA_PASS_THROUGH = 0x0004D02C; // XP SP2 and 2003 or later
        public const uint IOCTL_IDE_PASS_THROUGH = 0x0004D028; // 2000 or later
        public const uint IOCTL_SCSI_MINIPORT_READ_SMART_ATTRIBS = 0x1B0502;
        public const uint IOCTL_SCSI_MINIPORT_READ_SMART_THRESHOLDS = 0x1B0503;
        public const uint IOCTL_SCSI_MINIPORT_ENABLE_SMART  = 0x1B0504;
        public const uint IOCTL_SCSI_MINIPORT_DISABLE_SMART = 0x1B0505;
        public const uint IOCTL_STORAGE_PREDICT_FAILURE = 0x2D1100;

        public const uint DFP_SEND_DRIVE_COMMAND = 0x0007C084;
        public const uint DFP_RECEIVE_DRIVE_DATA = 0x0007C088;

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            int nInBufferSize,
            IntPtr lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesReturned,
            IntPtr lpOverlapped);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool DeviceIoControl(
            IntPtr hDevice,
            uint dwIoControlCode,
            IntPtr lpInBuffer,
            int nInBufferSize,
            out STORAGE_DEVICE_NUMBER lpOutBuffer,
            int nOutBufferSize,
            out int lpBytesReturned,
            IntPtr lpOverlapped);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool SetFilePointerEx(IntPtr hFile, long liDistanceToMove,
            IntPtr distanceToMoveHigh, uint dwMoveMethod);

        [DllImport(DLL_NAME, SetLastError = true)]
        public static extern bool ReadFile(IntPtr hFile, byte[] buffer, uint numberOfBytesToRead,
            out uint numberOfBytesRead, IntPtr lpOverlapped);

        [DllImport(DLL_NAME, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern IntPtr GetModuleHandle(string lpModuleName);

        [DllImport(DLL_NAME, CharSet = CharSet.Unicode, SetLastError = true)]
        [DefaultDllImportSearchPaths(DllImportSearchPath.System32)]
        public static extern IntPtr LoadLibrary(string lpFileName);

        [DllImport(DLL_NAME, CharSet = CharSet.Unicode, SetLastError = true)]
        public static extern bool GetDiskFreeSpaceEx(
            string lpDirectoryName,
            out ulong lpFreeBytesAvailable,
            out ulong lpTotalNumberOfBytes,
            out ulong lpTotalNumberOfFreeBytes);
    }
}
