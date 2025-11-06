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

using System.Runtime.InteropServices;
using System.Text;

namespace DiskInfoToolkit.Interop
{
    internal static class CfgMgr32
    {
        const string DLLNAME = "cfgmgr32.dll";

        [DllImport(DLLNAME, SetLastError = true)]
        public static extern int CM_Get_Parent(out uint pdnDevInst, uint dnDevInst, uint ulFlags);

        [DllImport(DLLNAME, SetLastError = true)]
        public static extern int CM_Get_Child(out uint pdnDevInst, uint dnDevInst, uint ulFlags);

        [DllImport(DLLNAME, SetLastError = true)]
        public static extern int CM_Get_Sibling(out uint pdnDevInst, uint dnDevInst, uint ulFlags);

        [DllImport(DLLNAME, SetLastError = true)]
        public static extern int CM_Get_Device_ID(uint dnDevInst, StringBuilder Buffer, int BufferLen, uint ulFlags);

        [DllImport(DLLNAME, SetLastError = true)]
        public static extern int CM_Get_Class_Name(ref Guid guid, StringBuilder Buffer, int BufferLen, uint ulFlags);
    }
}
