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
    public struct NVME_CMD_GET_LOG_PAGE
    {
        public NVME_GET_LOG_PAGE_CDW10 CDW10;
        public uint CDW11;
        public uint CDW12;
        public uint CDW13;
        public uint CDW14;
        public uint CDW15;
    }
}
