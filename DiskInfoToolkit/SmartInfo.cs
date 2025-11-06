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

using DiskInfoToolkit.Enums.Interop;
using DiskInfoToolkit.Interop.Enums;

namespace DiskInfoToolkit
{
    /// <summary>
    /// Contains basic SMART information and attributes.
    /// </summary>
    public class SmartInfo
    {
        #region Properties

        /// <summary>
        /// Current status of disk, available after first update.
        /// </summary>
        public DiskStatus DiskStatus { get; set; }

        /// <summary>
        /// Temperature of disk in celsius.
        /// </summary>
        public int? Temperature { get; internal set; }

        /// <summary>
        /// Minimum temperature warning threshold in celsius.
        /// </summary>
        public int? TemperatureWarning { get; internal set; }

        /// <summary>
        /// Minimum temperature critical threshold in celsius.
        /// </summary>
        public int? TemperatureCritical { get; internal set; }

        /// <summary>
        /// Current life of disk where 100 is best and 0 worst value.
        /// </summary>
        public sbyte? Life { get; internal set; }

        /// <summary>
        /// Lifetime host reads in gigabyte.
        /// </summary>
        public ulong? HostReads { get; internal set; }

        /// <summary>
        /// Lifetime host writes in gigabyte.
        /// </summary>
        public ulong? HostWrites { get; internal set; }

        /// <summary>
        /// Counter of how many times the device was powered on.
        /// </summary>
        public ulong PowerOnCount { get; internal set; }

        /// <summary>
        /// Measured power on hours.
        /// </summary>
        public ulong MeasuredPowerOnHours { get; internal set; }

        /// <summary>
        /// Detected power on hours.
        /// </summary>
        public ulong DetectedPowerOnHours { get; internal set; }

        /// <summary>
        /// Total NAND writes.
        /// </summary>
        public int? NandWrites { get; internal set; }

        /// <summary>
        /// Total gigabytes erased.
        /// </summary>
        public int? GBytesErased { get; internal set; }

        /// <summary>
        /// Wear leveling count.
        /// </summary>
        public int? WearLevelingCount { get; internal set; }

        /// <summary>
        /// A collection of read <see cref="SmartAttribute"/>s for current device.
        /// </summary>
        public List<SmartAttribute> SmartAttributes { get; internal set; } = new();

        #region Internal

        internal SmartStatus Status { get; set; }

        #endregion

        #endregion

        #region Internal

        internal void Clear()
        {
            Temperature          = null;
            Life                 = 0;
            HostReads            = 0;
            HostWrites           = 0;
            PowerOnCount         = 0;
            MeasuredPowerOnHours = 0;
            DetectedPowerOnHours = 0;

            NandWrites        = null;
            GBytesErased      = null;
            WearLevelingCount = null;

            SmartAttributes.Clear();

            Status = SmartStatus.Nothing;
        }

        #endregion
    }
}
