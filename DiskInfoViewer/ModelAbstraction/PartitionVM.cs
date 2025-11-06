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
using DiskInfoToolkit;
using DiskInfoToolkit.Enums.Interop;
using DiskInfoViewer.ViewModels;

namespace DiskInfoViewer.ModelAbstraction
{
    public partial class PartitionVM : ViewModelBase
    {
        #region Properties

        [ObservableProperty]
        PartitionStyle _partitionStyle;

        [ObservableProperty]
        long _startingOffset;

        [ObservableProperty]
        long _partitionLength;

        [ObservableProperty]
        uint _partitionNumber;

        [ObservableProperty]
        char? _driveLetter;

        [ObservableProperty]
        ulong? _availableFreeSpace;

        #endregion

        #region Public

        public void Update(Partition partition)
        {
            PartitionStyle     = partition.PartitionStyle    ;
            StartingOffset     = partition.StartingOffset    ;
            PartitionLength    = partition.PartitionLength   ;
            PartitionNumber    = partition.PartitionNumber   ;
            DriveLetter        = partition.DriveLetter       ;
            AvailableFreeSpace = partition.AvailableFreeSpace;
        }

        #endregion
    }
}
