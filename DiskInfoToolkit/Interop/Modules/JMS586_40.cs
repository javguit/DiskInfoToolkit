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
    internal sealed class JMS586_40 : ModuleBase
    {
        #region Delegates

        internal delegate uint _GetDllVersionJMS586_40(out byte major, out byte minor, out byte revision, out byte release);
        internal delegate int  _GetControllerCountJMS586_40();
        internal delegate bool _GetSmartInfoJMS586_40(int index, byte port, ref UNION_SMART_ATTRIBUTE attribute, ref UNION_SMART_THRESHOLD threshold);
        internal delegate bool _GetIdentifyInfoJMS586_40(int index, byte port, ref UNION_IDENTIFY_DEVICE identify);

        internal delegate bool _GetNVMePortInfoJMS586_40(int index, char port, ref NVME_PORT_40 nvmePort);
        internal delegate bool _GetNVMeSmartInfoJMS586_40(int index, char port, ref UNION_SMART_ATTRIBUTE attribute);
        internal delegate bool _GetNVMeIdInfoJMS586_40(int index, char port, ref NVME_ID nvmeID);
        internal delegate bool _ControllerSerialNum2IdJMS586_40(byte csn, byte[] cid);

        #endregion

        #region Fields

        internal _GetDllVersionJMS586_40      GetDllVersionJMS586_40     ;
        internal _GetControllerCountJMS586_40 GetControllerCountJMS586_40;
        internal _GetSmartInfoJMS586_40       GetSmartInfoJMS586_40      ;
        internal _GetIdentifyInfoJMS586_40    GetIdentifyInfoJMS586_40   ;
        
        internal _GetNVMePortInfoJMS586_40        GetNVMePortInfoJMS586_40       ;
        internal _GetNVMeSmartInfoJMS586_40       GetNVMeSmartInfoJMS586_40      ;
        internal _GetNVMeIdInfoJMS586_40          GetNVMeIdInfoJMS586_40         ;
        internal _ControllerSerialNum2IdJMS586_40 ControllerSerialNum2IdJMS586_40;

        #endregion

        #region Protected

        protected override string GetModuleFilename()
        {
            if (IntPtr.Size == 4)
            {
                //32-bit
                return "JMS586_40x86.dll";
            }
            else if (RuntimeInformation.ProcessArchitecture == Architecture.Arm64)
            {
                //64-bit ARM
                return "JMS586_40xA64.dll";
            }
            else
            {
                //64-bit
                return "JMS586_40x64.dll";
            }
        }

        protected override bool LoadLibraryFunctions()
        {
            if (IsModuleLoaded)
            {
                return true;
            }

            GetDllVersionJMS586_40      = GetDelegate<_GetDllVersionJMS586_40     >("GetDllVersion"     );
            GetControllerCountJMS586_40 = GetDelegate<_GetControllerCountJMS586_40>("GetControllerCount");
            GetSmartInfoJMS586_40       = GetDelegate<_GetSmartInfoJMS586_40      >("GetSmartInfoFx"    );
            GetIdentifyInfoJMS586_40    = GetDelegate<_GetIdentifyInfoJMS586_40   >("GetIdentifyInfoFx" );
            
            GetNVMePortInfoJMS586_40        = GetDelegate<_GetNVMePortInfoJMS586_40       >("GetNVMePortInfoFx" );
            GetNVMeSmartInfoJMS586_40       = GetDelegate<_GetNVMeSmartInfoJMS586_40      >("GetNVMeSmartInfoFx");
            GetNVMeIdInfoJMS586_40          = GetDelegate<_GetNVMeIdInfoJMS586_40         >("GetNVMeIdInfoFx");
            ControllerSerialNum2IdJMS586_40 = GetDelegate<_ControllerSerialNum2IdJMS586_40>("ControllerSerialNum2IdFx");

            if (GetDllVersionJMS586_40      == null
             || GetControllerCountJMS586_40 == null
             || GetSmartInfoJMS586_40       == null
             || GetIdentifyInfoJMS586_40    == null

             || GetNVMePortInfoJMS586_40        == null
             || GetNVMeSmartInfoJMS586_40       == null
             || GetNVMeIdInfoJMS586_40          == null
             || ControllerSerialNum2IdJMS586_40 == null)
            {
                return false;
            }

            return true;
        }

        #endregion
    }
}
