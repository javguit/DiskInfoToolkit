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
using System.Collections.ObjectModel;

namespace DiskInfoViewer.ModelAbstraction
{
    public partial class StorageVM : ViewModelBase
    {
        #region Constructor

        public StorageVM(Storage storage)
        {
            Storage = storage;

            StorageController = Storage.StorageController;
            VendorID          = Storage.VendorID         ;
            DriveNumber       = Storage.DriveNumber      ;
            BusType           = Storage.BusType          ;
            Vendor            = Storage.Vendor           ;
            TotalSize         = Storage.TotalSize        ;
            Model             = Storage.Model            ;
            Firmware          = Storage.Firmware         ;
            FirmwareRev       = Storage.FirmwareRev      ;
            SerialNumber      = Storage.SerialNumber     ;

            Smart = new(storage.Smart);
        }

        #endregion

        #region Properties

        public Storage Storage { get; }

        #region Fixed

        public string         StorageController { get; }
        public ushort?        VendorID          { get; }
        public int            DriveNumber       { get; }
        public StorageBusType BusType           { get; }
        public string         Vendor            { get; }
        public ulong          TotalSize         { get; }
        public string         Model             { get; }
        public string         Firmware          { get; }
        public string         FirmwareRev       { get; }
        public string         SerialNumber      { get; }

        [ObservableProperty]
        bool _showSerialNumber = false;

        //Can add more

        #endregion

        #region Volatile

        [ObservableProperty]
        SmartInfoVM _smart;

        [ObservableProperty]
        ObservableCollection<PartitionVM> _partitions = new();

        #endregion

        #endregion

        #region Public

        public void Update()
        {
            //Update actual Storage object
            Storage.Update();

            //Update VM
            Smart.Update();

            //Partitions can be changed, added or removed

            //Get added partitions
            var added = Storage.Partitions
                .Where(p => !Partitions.Any(vm => vm.PartitionNumber == p.PartitionNumber))
                .ToList();

            //Get removed partitions
            var removed = Partitions
                .Where(vm => !Storage.Partitions.Any(p => p.PartitionNumber == vm.PartitionNumber))
                .ToList();

            //Update existing first
            foreach (var partition in Partitions)
            {
                var found = Storage.Partitions.Find(p => p.PartitionNumber == partition.PartitionNumber);

                //Exists
                if (found != null)
                {
                    partition.Update(found);
                }
            }

            //Add new partitions
            foreach (var newPart in added)
            {
                var partition = new PartitionVM();
                partition.Update(newPart);

                Partitions.Add(partition);
            }

            //Remove partitions
            foreach (var remove in removed)
            {
                Partitions.Remove(remove);
            }
        }

        #endregion
    }
}
