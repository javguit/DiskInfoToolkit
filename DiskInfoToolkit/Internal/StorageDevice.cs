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

namespace DiskInfoToolkit.Internal
{
    /// <summary>
    /// Identifies a "raw" storage device.
    /// </summary>
    internal class StorageDevice
    {
        public string DeviceID { get; set; }
        public string HardwareID { get; set; }
        public string PhysicalPath { get; set; }
        public string VolumePath { get; set; }
        public int DriveNumber { get; set; }
    }
}
