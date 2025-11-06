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

namespace DiskInfoToolkit.Usb
{
    internal class UsbDevice
    {
        #region Constructor

        public UsbDevice(int id, string name)
        {
            ID = id;
            Name = name;
        }

        #endregion

        #region Properties

        public int ID { get; }
        public string Name { get; }

        public List<UsbInterface> Interfaces { get; } = new();

        #endregion
    }
}
