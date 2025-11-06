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

namespace DiskInfoToolkit.Interop
{
    internal static class Mappings
    {
        public static IReadOnlyDictionary<COMMAND_TYPE, string> CommandTypeStringMapping { get; } = new Dictionary<COMMAND_TYPE, string>()
        {
            { COMMAND_TYPE.CMD_TYPE_UNKNOWN              , "un" },
            { COMMAND_TYPE.CMD_TYPE_PHYSICAL_DRIVE       , "pd" },
            { COMMAND_TYPE.CMD_TYPE_SCSI_MINIPORT        , "sm" },
            { COMMAND_TYPE.CMD_TYPE_SILICON_IMAGE        , "si" },
            { COMMAND_TYPE.CMD_TYPE_SAT                  , "sa" },
            { COMMAND_TYPE.CMD_TYPE_SUNPLUS              , "sp" },
            { COMMAND_TYPE.CMD_TYPE_IO_DATA              , "io" },
            { COMMAND_TYPE.CMD_TYPE_LOGITEC              , "lo" },
            { COMMAND_TYPE.CMD_TYPE_PROLIFIC             , "pr" },
            { COMMAND_TYPE.CMD_TYPE_JMICRON              , "jm" },
            { COMMAND_TYPE.CMD_TYPE_CYPRESS              , "cy" },
            { COMMAND_TYPE.CMD_TYPE_SAT_ASM1352R         , "ar" }, // ASM1352R
            { COMMAND_TYPE.CMD_TYPE_SAT_REALTEK9220DP    , "rr" }, // Realtek 9220DP
            { COMMAND_TYPE.CMD_TYPE_CSMI                 , "cs" },
            { COMMAND_TYPE.CMD_TYPE_CSMI_PHYSICAL_DRIVE  , "cp" },
            { COMMAND_TYPE.CMD_TYPE_WMI                  , "wm" },
            { COMMAND_TYPE.CMD_TYPE_NVME_SAMSUNG         , "ns" }, // NVMe Samsung
            { COMMAND_TYPE.CMD_TYPE_NVME_INTEL           , "ni" }, // NVMe Intel
            { COMMAND_TYPE.CMD_TYPE_NVME_STORAGE_QUERY   , "sq" }, // NVMe Storage Query
            { COMMAND_TYPE.CMD_TYPE_NVME_JMICRON         , "nj" }, // NVMe JMicron
            { COMMAND_TYPE.CMD_TYPE_NVME_ASMEDIA         , "na" }, // NVMe ASMedia
            { COMMAND_TYPE.CMD_TYPE_NVME_REALTEK         , "nr" }, // NVMe Realtek
            { COMMAND_TYPE.CMD_TYPE_NVME_REALTEK9220DP   , "nr" },
            { COMMAND_TYPE.CMD_TYPE_NVME_INTEL_RST       , "nt" }, // NVMe Intel RST
            { COMMAND_TYPE.CMD_TYPE_NVME_INTEL_VROC      , "iv" }, // NVMe Intel VROC
            { COMMAND_TYPE.CMD_TYPE_MEGARAID             , "mr" }, // MegaRAID SAS
            { COMMAND_TYPE.CMD_TYPE_AMD_RC2              , "rc" }, // +AMD RC2
            { COMMAND_TYPE.CMD_TYPE_JMS56X               , "j5" }, // JMS56X
            { COMMAND_TYPE.CMD_TYPE_JMB39X               , "j3" }, // JMB39X
            { COMMAND_TYPE.CMD_TYPE_JMS586_20            , "j6" }, // JMS586_20
            { COMMAND_TYPE.CMD_TYPE_JMS586_40            , "j4" }, // JMS586_40
            { COMMAND_TYPE.CMD_TYPE_DEBUG                , "dg" }, // Debug
        };
    }
}
