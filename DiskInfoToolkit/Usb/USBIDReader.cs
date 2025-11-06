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

using System.Globalization;
using System.Text.RegularExpressions;

namespace DiskInfoToolkit.Usb
{
    internal static class USBIDReader
    {
        #region Constructor

        static USBIDReader()
        {
            ReadUSBIDs();
        }

        #endregion

        #region Fields

        const string USBIDFileName = "usb.ids";

        static Regex _Regex = new Regex(@"^([0-9A-Fa-f]+|\d+)\s\s(.+)$");

        #endregion

        #region Properties

        static List<UsbVendor> _UsbVendors = new();
        public static IReadOnlyList<UsbVendor> UsbVendors => _UsbVendors;

        #endregion

        #region Private

        static void ReadUSBIDs()
        {
            string resourceName = $"{nameof(DiskInfoToolkit)}.Resources.{USBIDFileName}";

            var assemblyWithResource = typeof(USBIDReader).Assembly;

            try
            {
                using (var stream = assemblyWithResource.GetManifestResourceStream(resourceName))
                {
                    //Resource is good
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            string rawLine = null;

                            UsbVendor vendor = null;
                            UsbDevice device = null;

                            while ((rawLine = reader.ReadLine()) != null)
                            {
                                //Skip comments and empty lines
                                if (rawLine.StartsWith("#") || rawLine.Length == 0)
                                {
                                    continue;
                                }

                                var lineValues = GetLineValues(rawLine.Trim());

                                if (lineValues == null)
                                {
                                    continue;
                                }

                                if (rawLine.StartsWith("\t\t")) //Interface
                                {
                                    if (device != null)
                                    {
                                        device.Interfaces.Add(new(lineValues.Item1, lineValues.Item2));
                                    }
                                }
                                else if (rawLine.StartsWith("\t")) //Device
                                {
                                    if (vendor != null)
                                    {
                                        device = new(lineValues.Item1, lineValues.Item2);

                                        vendor.Devices.Add(device);
                                    }
                                }
                                else //Vendor
                                {
                                    vendor = new(lineValues.Item1, lineValues.Item2);

                                    _UsbVendors.Add(vendor);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        static Tuple<int, string> GetLineValues(string line)
        {
            var match = _Regex.Match(line);

            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, NumberStyles.HexNumber, null, out var value);

                return new(value, match.Groups[2].Value);
            }

            return null;
        }

        #endregion
    }
}
