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
    public struct SMART_READ_THRESHOLD
    {
        public SMART_READ_THRESHOLD()
        {
            Revision = new byte[2];
            Threshold = new SMART_THRESHOLD[30];
            Reserved = new byte[150];
        }

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 2)]
        public byte[] Revision;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
        public SMART_THRESHOLD[] Threshold;

        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 150)]
        public byte[] Reserved;
    }
}
