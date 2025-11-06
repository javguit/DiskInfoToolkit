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
using System.Text;

namespace DiskInfoToolkit.Interop.Realtek
{
    internal class RealtekMethods
    {
        #region Public

        public static bool RealtekRAIDMode(Storage storage, IntPtr handle)
        {
            var sptwb = new SCSI_PASS_THROUGH_WITH_BUFFERS();

            sptwb.Spt.Length = (ushort)Marshal.SizeOf<SCSI_PASS_THROUGH>();
            sptwb.Spt.PathId = 0;
            sptwb.Spt.TargetId = 0;
            sptwb.Spt.Lun = 0;
            sptwb.Spt.CdbLength = 16;
            sptwb.Spt.SenseInfoLength = 32;
            sptwb.Spt.DataIn = InteropConstants.SCSI_IOCTL_DATA_IN;
            sptwb.Spt.DataTransferLength = 1;
            sptwb.Spt.TimeOutValue = 2;
            sptwb.Spt.DataBufferOffset = (ulong)Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.DataBuf)).ToInt64();
            sptwb.Spt.SenseInfoOffset = (uint)Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.SenseBuf)).ToInt32();

            sptwb.Spt.Cdb[0] = 0xE2;
            sptwb.Spt.Cdb[4] = 0xD3;
            sptwb.Spt.Cdb[12] = 0x01;

            var size = (int)(Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.DataBuf)).ToInt32() + sptwb.Spt.DataTransferLength);
            var ptrSize = Marshal.SizeOf<SCSI_PASS_THROUGH_WITH_BUFFERS>();

            var ptr = Marshal.AllocHGlobal(ptrSize);
            Marshal.StructureToPtr(sptwb, ptr, false);

            if (!Kernel32.DeviceIoControl(handle, Kernel32.IOCTL_SCSI_PASS_THROUGH, ptr, size, ptr, size, out _, IntPtr.Zero))
            {
                Marshal.FreeHGlobal(ptr);

                return false;
            }

            sptwb = Marshal.PtrToStructure<SCSI_PASS_THROUGH_WITH_BUFFERS>(ptr);

            sptwb.Spt.Cdb[0] = 0xE2;
            sptwb.Spt.Cdb[4] = 0xD2;
            sptwb.Spt.Cdb[12] = 0x01;

            Marshal.StructureToPtr(sptwb, ptr, false);

            if (!Kernel32.DeviceIoControl(handle, Kernel32.IOCTL_SCSI_PASS_THROUGH, ptr, size, ptr, size, out _, IntPtr.Zero))
            {
                Marshal.FreeHGlobal(ptr);

                return false;
            }

            sptwb = Marshal.PtrToStructure<SCSI_PASS_THROUGH_WITH_BUFFERS>(ptr);

            if (false == sptwb.DataBuf.Any(b => b != 0))
            {
                Marshal.FreeHGlobal(ptr);

                return false;
            }

            Marshal.FreeHGlobal(ptr);

            return sptwb.DataBuf[0] > 0;
        }

        public static bool RealtekSwitchMode(Storage storage, IntPtr handle, bool dir, byte mode)
        {
            var sptwb = new SCSI_PASS_THROUGH_WITH_BUFFERS();

            sptwb.Spt.Length = (ushort)Marshal.SizeOf<SCSI_PASS_THROUGH>();
            sptwb.Spt.PathId = 0;
            sptwb.Spt.TargetId = 0;
            sptwb.Spt.Lun = 0;
            sptwb.Spt.CdbLength = 16;
            sptwb.Spt.SenseInfoLength = 16;
            sptwb.Spt.DataIn = InteropConstants.SCSI_IOCTL_DATA_OUT;
            sptwb.Spt.DataTransferLength = 0;
            sptwb.Spt.TimeOutValue = 2;
            sptwb.Spt.DataBufferOffset = (ulong)Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.DataBuf)).ToInt64();
            sptwb.Spt.SenseInfoOffset = (uint)Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.SenseBuf)).ToInt32();

            if (dir)
            {
                //Set
                sptwb.Spt.Cdb[0] = 0xE3;
                sptwb.Spt.Cdb[4] = 0x53;
            }
            else
            {
                //Read
                sptwb.Spt.Cdb[0] = 0xE2;
                sptwb.Spt.Cdb[4] = 0xD4;
            }

            sptwb.Spt.Cdb[6] = mode;

            var size = (int)(Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.DataBuf)).ToInt32() + sptwb.Spt.DataTransferLength);
            var ptrSize = Marshal.SizeOf<SCSI_PASS_THROUGH_WITH_BUFFERS>();

            var ptr = Marshal.AllocHGlobal(ptrSize);
            Marshal.StructureToPtr(sptwb, ptr, false);

            if (!Kernel32.DeviceIoControl(handle, Kernel32.IOCTL_SCSI_PASS_THROUGH, ptr, size, ptr, size, out _, IntPtr.Zero))
            {
                Marshal.FreeHGlobal(ptr);

                return false;
            }

            sptwb = Marshal.PtrToStructure<SCSI_PASS_THROUGH_WITH_BUFFERS>(ptr);

            if (false == sptwb.DataBuf.Any(b => b != 0))
            {
                Marshal.FreeHGlobal(ptr);

                return false;
            }

            Marshal.FreeHGlobal(ptr);

            return true;
        }

        public static bool IsRealtekProduct(Storage storage, IntPtr handle)
        {
            var sptwb = new SCSI_PASS_THROUGH_WITH_BUFFERS();

            sptwb.Spt.Length = (ushort)Marshal.SizeOf<SCSI_PASS_THROUGH>();
            sptwb.Spt.PathId = 0;
            sptwb.Spt.TargetId = 0;
            sptwb.Spt.Lun = 0;
            sptwb.Spt.CdbLength = 16;
            sptwb.Spt.SenseInfoLength = 32;
            sptwb.Spt.DataIn = InteropConstants.SCSI_IOCTL_DATA_IN;
            sptwb.Spt.DataTransferLength = InteropConstants.IDENTIFY_BUFFER_SIZE;
            sptwb.Spt.TimeOutValue = 2;
            sptwb.Spt.DataBufferOffset = (ulong)Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.DataBuf)).ToInt64();
            sptwb.Spt.SenseInfoOffset = (uint)Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.SenseBuf)).ToInt32();

            sptwb.Spt.Cdb[0] = 0x12;
            sptwb.Spt.Cdb[1] = 0x0;
            sptwb.Spt.Cdb[2] = 0x0;
            sptwb.Spt.Cdb[3] = (512 >> 8);
            sptwb.Spt.Cdb[4] = 512 & 0xFF;
            sptwb.Spt.Cdb[5] = 0x0;

            var size = (int)(Marshal.OffsetOf<SCSI_PASS_THROUGH_WITH_BUFFERS>(nameof(sptwb.DataBuf)).ToInt32() + sptwb.Spt.DataTransferLength);
            var ptrSize = Marshal.SizeOf<SCSI_PASS_THROUGH_WITH_BUFFERS>();

            var ptr = Marshal.AllocHGlobal(ptrSize);
            Marshal.StructureToPtr(sptwb, ptr, false);

            if (!Kernel32.DeviceIoControl(handle, Kernel32.IOCTL_SCSI_PASS_THROUGH, ptr, size, ptr, size, out _, IntPtr.Zero))
            {
                Marshal.FreeHGlobal(ptr);

                return false;
            }

            sptwb = Marshal.PtrToStructure<SCSI_PASS_THROUGH_WITH_BUFFERS>(ptr);

            var version = Encoding.ASCII.GetString(sptwb.DataBuf, 32, 4);
            var model   = Encoding.ASCII.GetString(sptwb.DataBuf, 8, 17);

            bool ok = false;

            if (version.Equals("1.01", StringComparison.OrdinalIgnoreCase))
            {
                ok = true;
            }
            else if (model.Equals("Realtek RTL9220DP", StringComparison.OrdinalIgnoreCase))
            {
                ok = true;
            }

            Marshal.FreeHGlobal(ptr);

            return ok;
        }

        #endregion
    }
}
