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

namespace DiskInfoToolkit.Interop.Modules
{
    internal static class ModuleManager
    {
        #region Properties

        static AMDRC2Module _AMDRC2Module;
        public static AMDRC2Module AMDRC2Module
        {
            get
            {
                if (_AMDRC2Module == null)
                {
                    _AMDRC2Module = new AMDRC2Module();
                }

                return _AMDRC2Module;
            }
        }

        static JMS56X _JMS56XModule;
        public static JMS56X JMS56XModule
        {
            get
            {
                if (_JMS56XModule == null)
                {
                    _JMS56XModule = new JMS56X();
                }

                return _JMS56XModule;
            }
        }

        static JMB39X _JMB39XModule;
        public static JMB39X JMB39XModule
        {
            get
            {
                if (_JMB39XModule == null)
                {
                    _JMB39XModule = new JMB39X();
                }

                return _JMB39XModule;
            }
        }

        static JMS586_20 _JMS586_20Module;
        public static JMS586_20 JMS586_20Module
        {
            get
            {
                if (_JMS586_20Module == null)
                {
                    _JMS586_20Module = new JMS586_20();
                }

                return _JMS586_20Module;
            }
        }

        static JMS586_40 _JMS586_40Module;
        public static JMS586_40 JMS586_40Module
        {
            get
            {
                if (_JMS586_40Module == null)
                {
                    _JMS586_40Module = new JMS586_40();
                }

                return _JMS586_40Module;
            }
        }

        #endregion
    }
}
