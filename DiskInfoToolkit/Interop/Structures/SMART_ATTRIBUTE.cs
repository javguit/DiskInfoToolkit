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
    public struct SMART_ATTRIBUTE
    {
        public SMART_ATTRIBUTE()
        {
            RawValue = new byte[6];
        }

        public byte Id;
        public ushort StatusFlags;
        public byte CurrentValue;
        public byte WorstValue;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
        public byte[] RawValue;

        public byte Reserved;
    }
}
