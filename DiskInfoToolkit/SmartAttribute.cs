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

using DiskInfoToolkit.Interop.Structures;
using DiskInfoToolkit.Smart;

namespace DiskInfoToolkit
{
    /// <summary>
    /// Represents a SMART attribute.
    /// </summary>
    public sealed class SmartAttribute
    {
        #region Properties

        /// <summary>
        /// Information regarding the attribute.
        /// </summary>
        public SmartAttributeInfo Info { get; set; }

        /// <summary>
        /// The attribute as it has been read.
        /// </summary>
        public SmartAttributeStructure Attribute { get; set; }

        #endregion
    }
}
