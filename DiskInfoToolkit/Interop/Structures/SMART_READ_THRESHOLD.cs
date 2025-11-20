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

namespace DiskInfoToolkit.Interop.Structures
{
    [StructLayout(LayoutKind.Sequential, Pack = 1)]
    public unsafe struct SMART_READ_THRESHOLD
    {
        public fixed byte Revision[2];

        //TODO
        public SMART_THRESHOLD Threshold01;
        public SMART_THRESHOLD Threshold02;
        public SMART_THRESHOLD Threshold03;
        public SMART_THRESHOLD Threshold04;
        public SMART_THRESHOLD Threshold05;
        public SMART_THRESHOLD Threshold06;
        public SMART_THRESHOLD Threshold07;
        public SMART_THRESHOLD Threshold08;
        public SMART_THRESHOLD Threshold09;
        public SMART_THRESHOLD Threshold10;
        public SMART_THRESHOLD Threshold11;
        public SMART_THRESHOLD Threshold12;
        public SMART_THRESHOLD Threshold13;
        public SMART_THRESHOLD Threshold14;
        public SMART_THRESHOLD Threshold15;
        public SMART_THRESHOLD Threshold16;
        public SMART_THRESHOLD Threshold17;
        public SMART_THRESHOLD Threshold18;
        public SMART_THRESHOLD Threshold19;
        public SMART_THRESHOLD Threshold20;
        public SMART_THRESHOLD Threshold21;
        public SMART_THRESHOLD Threshold22;
        public SMART_THRESHOLD Threshold23;
        public SMART_THRESHOLD Threshold24;
        public SMART_THRESHOLD Threshold25;
        public SMART_THRESHOLD Threshold26;
        public SMART_THRESHOLD Threshold27;
        public SMART_THRESHOLD Threshold28;
        public SMART_THRESHOLD Threshold29;
        public SMART_THRESHOLD Threshold30;

        public fixed byte Reserved[150];
    }
}
