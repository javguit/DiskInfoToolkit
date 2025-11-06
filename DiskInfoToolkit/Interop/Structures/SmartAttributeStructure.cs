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

using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public struct SmartAttributeStructure
    {
        public SmartAttributeStructure()
        {
            RawValue = new byte[16];
        }

        public const int MaxAttribute = 30;
        public const int NvmeAttribute = 15;

        public byte ID;
        public short StatusFlags;
        public byte CurrentValue;
        public byte WorstValue;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] RawValue;
        /// <summary>
        /// Original: Reserved
        /// </summary>
        public byte Threshold;

        public int RawValueInt => BitConverter.ToInt32(RawValue, 0);
        public uint RawValueUInt => BitConverter.ToUInt32(RawValue, 0);

        public ulong RawValueULong
        {
            get
            {
                if (RawValue.Length == 16)
                {
                    return BitConverter.ToUInt64(RawValue, 0);
                }
                else
                {
                    var pad = new byte[8];
                    Array.Copy(RawValue, pad, 6);

                    return BitConverter.ToUInt64(pad, 0);
                }
            }
        }
    }
}
