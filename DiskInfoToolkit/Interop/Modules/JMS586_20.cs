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
    internal sealed class JMS586_20 : ModuleBase
    {
        #region Delegates

        internal delegate uint _GetDllVersionJMS586_20(out byte major, out byte minor, out byte revision, out byte release);
        internal delegate int  _GetControllerCountJMS586_20();
        internal delegate bool _GetSmartInfoJMS586_20(int index, byte port, ref UNION_SMART_ATTRIBUTE attribute, ref UNION_SMART_THRESHOLD threshold);
        internal delegate bool _GetIdentifyInfoJMS586_20(int index, byte port, ref UNION_IDENTIFY_DEVICE identify);

        internal delegate bool _GetNVMePortInfoJMS586_20(int index, char port, ref NVME_PORT_20 nvmePort);
        internal delegate bool _GetNVMeSmartInfoJMS586_20(int index, char port, ref UNION_SMART_ATTRIBUTE attribute);

        #endregion

        #region Fields

        internal _GetDllVersionJMS586_20      GetDllVersionJMS586_20     ;
        internal _GetControllerCountJMS586_20 GetControllerCountJMS586_20;
        internal _GetSmartInfoJMS586_20       GetSmartInfoJMS586_20      ;
        internal _GetIdentifyInfoJMS586_20    GetIdentifyInfoJMS586_20   ;
        
        internal _GetNVMePortInfoJMS586_20    GetNVMePortInfoJMS586_20 ;
        internal _GetNVMeSmartInfoJMS586_20   GetNVMeSmartInfoJMS586_20;

        #endregion

        #region Protected

        protected override string GetModuleFilename()
        {
            if (IntPtr.Size == 4)
            {
                //32-bit
                return "JMS586x86.dll";
            }
            else if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                //64-bit ARM
                return "JMS586xA64.dll";
            }
            else
            {
                //64-bit
                return "JMS586x64.dll";
            }
        }

        protected override bool LoadLibraryFunctions()
        {
            if (IsModuleLoaded)
            {
                return true;
            }

            GetDllVersionJMS586_20      = GetDelegate<_GetDllVersionJMS586_20     >("GetDllVersion"     );
            GetControllerCountJMS586_20 = GetDelegate<_GetControllerCountJMS586_20>("GetControllerCount");
            GetSmartInfoJMS586_20       = GetDelegate<_GetSmartInfoJMS586_20      >("GetSmartInfoFx"    );
            GetIdentifyInfoJMS586_20    = GetDelegate<_GetIdentifyInfoJMS586_20   >("GetIdentifyInfoFx" );
            
            GetNVMePortInfoJMS586_20  = GetDelegate<_GetNVMePortInfoJMS586_20 >("GetNVMePortInfoFx" );
            GetNVMeSmartInfoJMS586_20 = GetDelegate<_GetNVMeSmartInfoJMS586_20>("GetNVMeSmartInfoFx");

            if (GetDllVersionJMS586_20      == null
             || GetControllerCountJMS586_20 == null
             || GetSmartInfoJMS586_20       == null
             || GetIdentifyInfoJMS586_20    == null

             || GetNVMePortInfoJMS586_20  == null
             || GetNVMeSmartInfoJMS586_20 == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
