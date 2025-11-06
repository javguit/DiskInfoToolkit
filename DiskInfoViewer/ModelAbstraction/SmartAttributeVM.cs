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

using CommunityToolkit.Mvvm.ComponentModel;
using DiskInfoViewer.ViewModels;

namespace DiskInfoViewer.ModelAbstraction
{
    public partial class SmartAttributeVM : ViewModelBase
    {
        #region Properties

        [ObservableProperty]
        byte _ID;

        [ObservableProperty]
        string _name;

        [ObservableProperty]
        ulong _value;

        #endregion
    }
}
