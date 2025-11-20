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
    public unsafe struct SMART_READ_DATA
    {
        public fixed byte Revision[2];

        //TODO
        public SMART_ATTRIBUTE Attribute01;
        public SMART_ATTRIBUTE Attribute02;
        public SMART_ATTRIBUTE Attribute03;
        public SMART_ATTRIBUTE Attribute04;
        public SMART_ATTRIBUTE Attribute05;
        public SMART_ATTRIBUTE Attribute06;
        public SMART_ATTRIBUTE Attribute07;
        public SMART_ATTRIBUTE Attribute08;
        public SMART_ATTRIBUTE Attribute09;
        public SMART_ATTRIBUTE Attribute10;
        public SMART_ATTRIBUTE Attribute11;
        public SMART_ATTRIBUTE Attribute12;
        public SMART_ATTRIBUTE Attribute13;
        public SMART_ATTRIBUTE Attribute14;
        public SMART_ATTRIBUTE Attribute15;
        public SMART_ATTRIBUTE Attribute16;
        public SMART_ATTRIBUTE Attribute17;
        public SMART_ATTRIBUTE Attribute18;
        public SMART_ATTRIBUTE Attribute19;
        public SMART_ATTRIBUTE Attribute20;
        public SMART_ATTRIBUTE Attribute21;
        public SMART_ATTRIBUTE Attribute22;
        public SMART_ATTRIBUTE Attribute23;
        public SMART_ATTRIBUTE Attribute24;
        public SMART_ATTRIBUTE Attribute25;
        public SMART_ATTRIBUTE Attribute26;
        public SMART_ATTRIBUTE Attribute27;
        public SMART_ATTRIBUTE Attribute28;
        public SMART_ATTRIBUTE Attribute29;
        public SMART_ATTRIBUTE Attribute30;

        public fixed byte Reserved[150];
    }
}
