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
using DiskInfoToolkit.Interop.Structures;
using System.Runtime.InteropServices;

namespace DiskInfoToolkit.Interop.Modules
{
    internal sealed class JMB39X : ModuleBase
    {
        #region Delegates

        internal delegate uint _GetDllVersionJMB39X(out byte major, out byte minor, out byte revision, out byte release);
        internal delegate int  _GetControllerCountJMB39X();
        internal delegate bool _GetSmartInfoJMB39X(int index, byte port, ref UNION_SMART_ATTRIBUTE attribute, ref UNION_SMART_THRESHOLD threshold);
        internal delegate bool _GetIdentifyInfoJMB39X(int index, byte port, ref UNION_IDENTIFY_DEVICE identify);

        #endregion

        #region Fields

        internal _GetDllVersionJMB39X      GetDllVersionJMB39X     ;
        internal _GetControllerCountJMB39X GetControllerCountJMB39X;
        internal _GetSmartInfoJMB39X       GetSmartInfoJMB39X      ;
        internal _GetIdentifyInfoJMB39X    GetIdentifyInfoJMB39X   ;

        #endregion

        #region Protected

        protected override string GetModuleFilename()
        {
            if (IntPtr.Size == 4)
            {
                //32-bit
                return "JMB39x86.dll";
            }
            else if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                //64-bit ARM
                return "JMB39xA64.dll";
            }
            else
            {
                //64-bit
                return "JMB39x64.dll";
            }
        }

        protected override bool LoadLibraryFunctions()
        {
            if (IsModuleLoaded)
            {
                return true;
            }

            GetDllVersionJMB39X      = GetDelegate<_GetDllVersionJMB39X     >("GetDllVersion"     );
            GetControllerCountJMB39X = GetDelegate<_GetControllerCountJMB39X>("GetControllerCount");
            GetSmartInfoJMB39X       = GetDelegate<_GetSmartInfoJMB39X      >("GetSmartInfoFx"    );
            GetIdentifyInfoJMB39X    = GetDelegate<_GetIdentifyInfoJMB39X   >("GetIdentifyInfoFx" );

            if (GetDllVersionJMB39X      == null
             || GetControllerCountJMB39X == null
             || GetSmartInfoJMB39X       == null
             || GetIdentifyInfoJMB39X    == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
