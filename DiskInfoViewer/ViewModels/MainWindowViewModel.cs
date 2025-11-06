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

using BlackSharp.Core.Asynchronous;
using BlackSharp.Core.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using DiskInfoToolkit;
using DiskInfoToolkit.Events;

namespace DiskInfoViewer.ViewModels
{
    public partial class MainWindowViewModel : ViewModelBase
    {
        #region Constructor

        public MainWindowViewModel()
        {
            StorageManager.StoragesChanged += OnStoragesChanged;
        }

        #endregion

        #region Properties

        [ObservableProperty]
        ObservableCollectionEx<StorageViewModel> _storageVMs;

        [ObservableProperty]
        bool _isBusy;

        [ObservableProperty]
        string _busyMessage = "Please wait";

        #endregion

        #region Commands

        [RelayCommand]
        void RefreshStorages()
        {
            IsBusy = true;

            Executor.Run(() =>
            {
                StorageManager.ReloadStorages();

                var storages = new ObservableCollectionEx<StorageViewModel>(
                                    StorageManager.Storages
                                        .OrderBy(s => s.DriveNumber)
                                        .Select(s => new StorageViewModel(new(s))));

                return () =>
                {
                    StorageVMs = storages;

                    IsBusy = false;
                };
            });
        }

        #endregion

        #region Private

        void OnStoragesChanged(StoragesChangedEventArgs e)
        {
            switch (e.StorageChangeIdentifier)
            {
                case StorageChangeIdentifier.Added:
                    StorageVMs.Add(new(new(e.Storage)));
                    break;
                case StorageChangeIdentifier.Removed:
                    var removed = StorageVMs.FirstOrDefault(s => s.Storage.Storage == e.Storage);
                    if (removed != null)
                    {
                        StorageVMs.Remove(removed);
                    }
                    break;
            }
        }

        #endregion
    }
}
