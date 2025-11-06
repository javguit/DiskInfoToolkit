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
    internal sealed class JMS56X : ModuleBase
    {
        #region Delegates

        internal delegate uint _GetDllVersionJMS56X(out byte major, out byte minor, out byte revision, out byte release);
        internal delegate int  _GetControllerCountJMS56X();
        internal delegate bool _GetSmartInfoJMS56X(int index, byte port, ref UNION_SMART_ATTRIBUTE attribute, ref UNION_SMART_THRESHOLD threshold);
        internal delegate bool _GetIdentifyInfoJMS56X(int index, byte port, ref UNION_IDENTIFY_DEVICE identify);

        #endregion

        #region Fields

        internal _GetDllVersionJMS56X      GetDllVersionJMS56X     ;
        internal _GetControllerCountJMS56X GetControllerCountJMS56X;
        internal _GetSmartInfoJMS56X       GetSmartInfoJMS56X      ;
        internal _GetIdentifyInfoJMS56X    GetIdentifyInfoJMS56X   ;

        #endregion

        #region Protected

        protected override string GetModuleFilename()
        {
            if (IntPtr.Size == 4)
            {
                //32-bit
                return "JMS56x86.dll";
            }
            else if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                //64-bit ARM
                return "JMS56xA64.dll";
            }
            else
            {
                //64-bit
                return "JMS56x64.dll";
            }
        }

        protected override bool LoadLibraryFunctions()
        {
            if (IsModuleLoaded)
            {
                return true;
            }

            GetDllVersionJMS56X      = GetDelegate<_GetDllVersionJMS56X     >("GetDllVersion"     );
            GetControllerCountJMS56X = GetDelegate<_GetControllerCountJMS56X>("GetControllerCount");
            GetSmartInfoJMS56X       = GetDelegate<_GetSmartInfoJMS56X      >("GetSmartInfoFx"    );
            GetIdentifyInfoJMS56X    = GetDelegate<_GetIdentifyInfoJMS56X   >("GetIdentifyInfoFx" );

            if (GetDllVersionJMS56X      == null
             || GetControllerCountJMS56X == null
             || GetSmartInfoJMS56X       == null
             || GetIdentifyInfoJMS56X    == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
