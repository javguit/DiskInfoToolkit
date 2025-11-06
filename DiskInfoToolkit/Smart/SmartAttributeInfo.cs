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

using DiskInfoToolkit.Interop.Enums;

namespace DiskInfoToolkit.Smart
{
    /// <summary>
    /// Represents SMART attribute information.
    /// </summary>
    public sealed class SmartAttributeInfo
    {
        #region Constructor

        internal SmartAttributeInfo(byte id, SmartAttributeType type, string name)
        {
            ID   = id;
            Type = type;
            Name = name;
        }

        #endregion

        #region Properties

        /// <summary>
        /// ID of attribute.
        /// </summary>
        public byte ID { get; set; }

        /// <summary>
        /// Attribute type.
        /// </summary>
        public SmartAttributeType Type { get; set; }

        /// <summary>
        /// Name of attribute.
        /// </summary>
        public string Name { get; set; }

        #endregion
    }
}
