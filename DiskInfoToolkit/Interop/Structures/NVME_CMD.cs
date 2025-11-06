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
    public struct NVME_CMD
    {
        public NVME_CDW0 CDW0;
        public uint NSID;
        public uint Rsvd1;
        public uint Rsvd2;
        public ulong MPTR;
        public ulong PRP1;
        public ulong PRP2;
        public NVME_CMD_UNION u;
    }
}
