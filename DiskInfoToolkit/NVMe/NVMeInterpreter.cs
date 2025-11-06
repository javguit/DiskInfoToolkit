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
using DiskInfoToolkit.Interop.Structures;
using DiskInfoToolkit.Smart;

namespace DiskInfoToolkit.NVMe
{
    /// <summary>
    /// NVMe disks have a standard for SMART data, so we need to "translate" these values here.
    /// </summary>
    internal static class NVMeInterpreter
    {
        #region Public

        public static void NVMeSmart(SmartInfo smart, byte[] smartReadDataBuffer)
        {
            smart.SmartAttributes.Clear();

            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.CriticalWarning                             , smartReadDataBuffer,   0,  1));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.CompositeTemperature                        , smartReadDataBuffer,   1,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.AvailableSpare                              , smartReadDataBuffer,   3,  1));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.AvailableSpareThreshold                     , smartReadDataBuffer,   4,  1));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.PercentageUsed                              , smartReadDataBuffer,   5,  1));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.HostDataRead                                , smartReadDataBuffer,  32, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.HostDataWritten                             , smartReadDataBuffer,  48, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.HostReadCommands                            , smartReadDataBuffer,  64, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.HostWriteCommands                           , smartReadDataBuffer,  80, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.ControllerBusyTime                          , smartReadDataBuffer,  96, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.PowerCycleCount                             , smartReadDataBuffer, 112, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.PowerOnHours                                , smartReadDataBuffer, 128, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.UnsafeShutdownCount                         , smartReadDataBuffer, 144, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.MediaAndDataIntegrityErrors                 , smartReadDataBuffer, 160, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.NumberOfErrorInformationLogEntries          , smartReadDataBuffer, 176, 16));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.WarningCompositeTemperatureTime             , smartReadDataBuffer, 192,  4));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.CriticalCompositeTemperatureTime            , smartReadDataBuffer, 196,  4));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor1                          , smartReadDataBuffer, 200,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor2                          , smartReadDataBuffer, 202,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor3                          , smartReadDataBuffer, 204,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor4                          , smartReadDataBuffer, 206,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor5                          , smartReadDataBuffer, 208,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor6                          , smartReadDataBuffer, 210,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor7                          , smartReadDataBuffer, 212,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TemperatureSensor8                          , smartReadDataBuffer, 214,  2));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.ThermalManagementTemperature1TransitionCount, smartReadDataBuffer, 216,  4));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.ThermalManagementTemperature2TransitionCount, smartReadDataBuffer, 220,  4));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TotalTimeThermalManagementTemperature1      , smartReadDataBuffer, 224,  4));
            smart.SmartAttributes.Add(NewAttribute(SmartAttributeType.TotalTimeThermalManagementTemperature2      , smartReadDataBuffer, 228,  4));
        }

        #endregion

        #region Private

        static SmartAttribute NewAttribute(SmartAttributeType smartAttributeType, byte[] smartReadDataBuffer, int start, int length)
        {
            var buf = new byte[16];

            if (length <= buf.Length)
            {
                if (BitConverter.IsLittleEndian)
                {
                    Array.Copy(smartReadDataBuffer, start, buf, 0, length);
                }
                else
                {
                    Array.Copy(smartReadDataBuffer, start, buf, buf.Length - length, length);
                }
            }

            var attr = new SmartAttributeStructure();
            Array.Copy(buf, attr.RawValue, attr.RawValue.Length);

            var info = SmartAttributeInfoMapping.Mapping[SmartKey.NVMe];
            if (info != null)
            {
                var attrInfo = info.Find(sai => sai.Type == smartAttributeType);

                if (attrInfo != null)
                {
                    return new()
                    {
                        Info = attrInfo,
                        Attribute = attr,
                    };
                }
            }

            return null;
        }

        #endregion
    }
}
