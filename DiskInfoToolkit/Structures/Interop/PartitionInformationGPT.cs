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
using System.Text;

namespace DiskInfoToolkit.Structures.Interop
{
    [StructLayout(LayoutKind.Sequential)]
    public unsafe struct PartitionInformationGPT
    {
        public Guid PartitionType;
        public Guid PartitionId;
        public ulong Attributes;
        public fixed byte Name[72];

        public string NameStr
        {
            get
            {
                fixed (byte* ptr = Name)
                {
                    return Encoding.Unicode.GetString(ptr, 72).Trim('\0');
                }
            }
        }
    }
}
