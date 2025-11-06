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
    /// Identifies a "raw" storage controller and its child devices.
    /// </summary>
    internal class StorageController
    {
        public string Name { get; set; }
        public string HardwareID { get; set; }
        public List<StorageDevice> StorageDeviceIDs { get; set; } = new();
    }
}
