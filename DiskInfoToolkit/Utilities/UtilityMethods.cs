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

namespace DiskInfoToolkit.Utilities
{
    internal static class UtilityMethods
    {
        #region Public

        public static TimeUnitType GetTimeUnitType(Storage storage, uint major, TransferMode transferMode)
        {
            bool firmwareFloatOK = float.TryParse(storage.Firmware, out var firmwareFloat);

            if (Storage.ModelContains(storage, "FUJITSU"))
            {
                if (major >= 8)
                {
                    return TimeUnitType.PowerOnHours;
                }
                else
                {
                    return TimeUnitType.PowerOnSeconds;
                }
            }
            else if (Storage.ModelContains(storage, "HITACHI_DK"))
            {
                return TimeUnitType.PowerOnMinutes;
            }
            else if (Storage.ModelContains(storage, "MAXTOR"))
            {
                if (transferMode >= TransferMode.TransferModeSata300
                 || Storage.ModelContains(storage, "MAXTOR 6H"   ) // Maxtor DiamondMax 11 family
                 || Storage.ModelContains(storage, "MAXTOR 7H500") // Maxtor MaXLine Pro 500 family
                 || Storage.ModelContains(storage, "MAXTOR 6L0"  ) // Maxtor DiamondMax Plus D740X family
                 || Storage.ModelContains(storage, "MAXTOR 4K"   ) // Maxtor DiamondMax D540X-4K family
                 )
                {
                    return TimeUnitType.PowerOnHours;
                }
                else
                {
                    return TimeUnitType.PowerOnMinutes;
                }
            }
            else if (Storage.ModelContains(storage, "SAMSUNG"))
            {
                var firmwareSubStr = storage.Firmware.Length < 3 ?
                    storage.Firmware :
                    storage.Firmware.Substring(storage.Firmware.Length - 3, 3);

                bool firmwareIntOK = int.TryParse(firmwareSubStr, out var firmwareInt);

                if (transferMode >= TransferMode.TransferModeSata300)
                {
                    return TimeUnitType.PowerOnHours;
                }
                else if (firmwareIntOK && (-23 >= firmwareInt) && (firmwareInt >= -39))
                {
                    return TimeUnitType.PowerOnHalfMinutes;
                }
                else if (Storage.ModelContains(storage, "SAMSUNG SV")
                      || Storage.ModelContains(storage, "SAMSUNG SP")
                      || Storage.ModelContains(storage, "SAMSUNG HM")
                      || Storage.ModelContains(storage, "SAMSUNG MP")
                      )
                {
                    return TimeUnitType.PowerOnHalfMinutes;
                }
                else
                {
                    return TimeUnitType.PowerOnHours;
                }
            }
            else if (
                        (
                            (
                                Storage.ModelContains(storage, "CFD_CSSD-S6TM128NMPQ")
                             || Storage.ModelContains(storage, "CFD_CSSD-S6TM256NMPQ")
                            )
                         &&
                            (
                                storage.Firmware.Contains("VM21")
                             || storage.Firmware.Contains("VN21")
                            )
                        )
                     || (
                            (
                                Storage.ModelContains(storage, "PX-128M2P")
                             || Storage.ModelContains(storage, "PX-256M2P")
                            )
                         && (firmwareFloatOK && (firmwareFloat < 1.059f))
                        )
                     || (
                            Storage.ModelContains(storage, "Corsair Performance Pro")
                         && (firmwareFloatOK && (firmwareFloat < 1.059f))
                        )
                  )
            {
                return TimeUnitType.PowerOn10Minutes;
            }
            else if ( (Storage.ModelContains(storage, "INTEL SSDSC2CW") && Storage.ModelContains(storage, "A3")) // Intel SSD 520 Series
                  ||  (Storage.ModelContains(storage, "INTEL SSDSC2BW") && Storage.ModelContains(storage, "A3")) // Intel SSD 520 Series
                  ||  (Storage.ModelContains(storage, "INTEL SSDSC2CT") && Storage.ModelContains(storage, "A3")) // Intel SSD 330 Series
                  )
            {
                return TimeUnitType.PowerOnMilliSeconds;
            }
            else
            {
                return TimeUnitType.PowerOnHours;
            }
        }

        public static uint GetAtaMajorVersion(ushort w80)
        {
            if (w80 == 0x0000 || w80 == 0xFFFF)
            {
                return 0;
            }

            uint major = 0;

            for (int i = 14; i > 0; --i)
            {
                if (((w80 >> i) & 0x1) != 0)
                {
                    major = (uint)i;
                    break;
                }
            }

            return major;
        }

        public static TransferMode GetTransferMode(ushort w63, ushort w76, ushort w77, ushort w88)
        {
            var tm = TransferMode.TransferModeUnknown;

            // Multiword DMA or PIO
            if ((w63 & 0x0700) != 0)
            {
                tm = TransferMode.TransferModePioDma;
            }

            if ((w88 & 0x7F) != 0)
            {
                //InterfaceType = PATA
            }

            // Ultara DMA Max Transfer Mode
                 if ((w88 & 0x0040) != 0) { tm = TransferMode.TransferModeUltraDma133; }
            else if ((w88 & 0x0020) != 0) { tm = TransferMode.TransferModeUltraDma100; }
            else if ((w88 & 0x0010) != 0) { tm = TransferMode.TransferModeUltraDma66 ; }
            else if ((w88 & 0x0008) != 0) { tm = TransferMode.TransferModeUltraDma44 ; }
            else if ((w88 & 0x0004) != 0) { tm = TransferMode.TransferModeUltraDma33 ; }
            else if ((w88 & 0x0002) != 0) { tm = TransferMode.TransferModeUltraDma25 ; }
            else if ((w88 & 0x0001) != 0) { tm = TransferMode.TransferModeUltraDma16 ; }

            // Serial ATA
            if (w76 != 0x0000 && w76 != 0xFFFF)
            {
                //InterfaceType = SATA
            }

                 if ((w76 & 0x0010) != 0) { tm = TransferMode.TransferModeUnknown; }
            else if ((w76 & 0x0008) != 0) { tm = TransferMode.TransferModeSata600; }
            else if ((w76 & 0x0004) != 0) { tm = TransferMode.TransferModeSata300; }
            else if ((w76 & 0x0002) != 0) { tm = TransferMode.TransferModeSata150; }

            return tm;
        }

        #endregion
    }
}
