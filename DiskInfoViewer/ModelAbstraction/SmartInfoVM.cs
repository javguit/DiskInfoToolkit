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

using BlackSharp.Core.Collections;
using CommunityToolkit.Mvvm.ComponentModel;
using DiskInfoToolkit;
using DiskInfoToolkit.Enums.Interop;
using DiskInfoViewer.ViewModels;

namespace DiskInfoViewer.ModelAbstraction
{
    public partial class SmartInfoVM : ViewModelBase
    {
        #region Constructor

        public SmartInfoVM(SmartInfo smartInfo)
        {
            SmartInfo = smartInfo;
        }

        #endregion

        #region Fields

        readonly SmartInfo SmartInfo;

        #endregion

        #region Properties

        [ObservableProperty]
        DiskStatus _diskStatus;

        [ObservableProperty]
        int? _temperature;

        [ObservableProperty]
        int? _temperatureWarning;

        [ObservableProperty]
        int? _temperatureCritical;

        [ObservableProperty]
        sbyte? _life;

        [ObservableProperty]
        ulong? _hostReads;

        [ObservableProperty]
        ulong? _hostWrites;

        [ObservableProperty]
        ulong _powerOnCount;

        [ObservableProperty]
        ulong _measuredPowerOnHours;

        //Can add more

        [ObservableProperty]
        ObservableCollectionEx<SmartAttributeVM> _smartAttributes = new();

        #endregion

        #region Public

        public void Update()
        {
            DiskStatus           = SmartInfo.DiskStatus          ;
            Temperature          = SmartInfo.Temperature         ;
            TemperatureWarning   = SmartInfo.TemperatureWarning  ;
            TemperatureCritical  = SmartInfo.TemperatureCritical ;
            Life                 = SmartInfo.Life                ;
            HostReads            = SmartInfo.HostReads           ;
            HostWrites           = SmartInfo.HostWrites          ;
            PowerOnCount         = SmartInfo.PowerOnCount        ;
            MeasuredPowerOnHours = SmartInfo.MeasuredPowerOnHours;

            //Update attributes
            foreach (var attribute in SmartInfo.SmartAttributes)
            {
                //Try to find attribute
                var found = SmartAttributes.Find(sa => sa.ID == attribute.Info.ID);

                //Found attribute, update it
                if (found != null)
                {
                    found.Value = attribute.Attribute.RawValueULong;
                }
                else //Not found, add it
                {
                    var vm = new SmartAttributeVM()
                    {
                        ID    = attribute.Info.ID,
                        Name  = attribute.Info.Name,
                        Value = attribute.Attribute.RawValueULong,
                    };

                    SmartAttributes.Add(vm);
                }
            }
        }

        #endregion
    }
}
