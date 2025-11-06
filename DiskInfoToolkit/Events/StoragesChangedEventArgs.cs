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

namespace DiskInfoToolkit.Events
{
    /// <summary>
    /// Identifies how a device has changed.
    /// </summary>
    public enum StorageChangeIdentifier
    {
        /// <summary>
        /// A device has been added.
        /// </summary>
        Added,

        /// <summary>
        /// A device has been removed.
        /// </summary>
        Removed,
    }

    /// <summary>
    /// Used for when devices changed.
    /// </summary>
    public class StoragesChangedEventArgs : EventArgs
    {
        /// <summary>
        /// Identifies what kind of change has happened.
        /// </summary>
        public StorageChangeIdentifier StorageChangeIdentifier { get; set; }

        /// <summary>
        /// Identifies the device which has changed.
        /// </summary>
        public Storage Storage { get; set; }
    }
}
