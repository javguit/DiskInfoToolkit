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

using BlackSharp.Core.Interop.Windows.Utilities;
using DiskInfoToolkit.Interop.Enums;
using DiskInfoToolkit.Interop.Structures;
using DiskInfoToolkit.Logging;

namespace DiskInfoToolkit.Interop.Modules
{
    internal sealed class AMDRC2Module : ModuleBase
    {
        #region Delegates

        internal delegate uint A_AMD_RC2_UINT();
        internal delegate bool A_AMD_RC2_GetIdentify(ref AMD_RC2_IDENTIFY identify);
        internal delegate bool A_AMD_RC2_GetSmartData(uint diskNum, byte[] smartReadData, uint smartReadDataLength, byte[] smartReadDataThreshold, uint smartReadDataThresholdLength);

        #endregion

        #region Fields

        internal A_AMD_RC2_UINT AMD_RC2_Init;
        internal A_AMD_RC2_UINT AMD_RC2_GetStatus;
        internal A_AMD_RC2_UINT AMD_RC2_GetDrives;
        internal A_AMD_RC2_UINT AMD_RC2_Reload;
        internal A_AMD_RC2_GetIdentify AMD_RC2_GetIdentify;
        internal A_AMD_RC2_GetSmartData AMD_RC2_GetSmartData;

        #endregion

        #region Protected

        protected override string GetModuleFilename()
        {
            if (IntPtr.Size == 4)
            {
                //32-bit
                return "AMD_RC2t7x86.dll";
            }
            else
            {
                //64-bit
                return "AMD_RC2t7x64.dll";
            }
        }

        protected override bool LoadLibraryFunctions()
        {
            if (IsModuleLoaded)
            {
                return true;
            }

            AMD_RC2_Init         = GetDelegate<A_AMD_RC2_UINT        >("AMD_RC2_Init"        );
            AMD_RC2_GetStatus    = GetDelegate<A_AMD_RC2_UINT        >("AMD_RC2_GetStatus"   );
            AMD_RC2_GetDrives    = GetDelegate<A_AMD_RC2_UINT        >("AMD_RC2_GetDrives"   );
            AMD_RC2_Reload       = GetDelegate<A_AMD_RC2_UINT        >("AMD_RC2_Reload"      );
            AMD_RC2_GetIdentify  = GetDelegate<A_AMD_RC2_GetIdentify >("AMD_RC2_GetIdentify" );
            AMD_RC2_GetSmartData = GetDelegate<A_AMD_RC2_GetSmartData>("AMD_RC2_GetSmartData");

            if (AMD_RC2_Init         == null
             || AMD_RC2_GetStatus    == null
             || AMD_RC2_GetDrives    == null
             || AMD_RC2_Reload       == null
             || AMD_RC2_GetIdentify  == null
             || AMD_RC2_GetSmartData == null)
            {
                return false;
            }

            var status = AMD_RC2_Init();

            if (status != (uint)AMD_RC2_ERROR_CODE.AMD_RC2_loaded)
            {
                LogSimple.LogWarn($"{nameof(AMDRC2Module)}: Could not load (error code: {(AMD_RC2_ERROR_CODE)status}).");
                return false;
            }

            return true;
        }

        #endregion
    }
}
