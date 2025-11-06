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

namespace DiskInfoToolkit.Structures.Interop
{
    [StructLayout(LayoutKind.Explicit)]
    public struct PartitionInformationMBR
    {

        [FieldOffset(0)] public byte PartitionType;
        [FieldOffset(1)] public bool BootIndicator;
        [FieldOffset(2)] public bool RecognizedPartition;
        [FieldOffset(3)] public byte Padding;
        [FieldOffset(4)] public uint HiddenSectors;

        //#if (NTDDI_VERSION >= NTDDI_WINBLUE)    /* ABRACADABRA_THRESHOLD */
        [FieldOffset(8)] public Guid PartitionId;
    }
}
