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

using DiskInfoToolkit.Utilities;
using System.Globalization;
using System.Text.RegularExpressions;

namespace DiskInfoToolkit.PCI
{
    internal static class PCIIDReader
    {
        #region Constructor

        static PCIIDReader()
        {
            ReadPCIIDs();
        }

        #endregion

        #region Fields

        const string PCIIDFileName = "pci.ids.gz";

        static Regex _RegexNormal = new Regex(@"^([0-9A-Fa-f]+|\d+)\s\s(.+)$");
        static Regex _RegexSub    = new Regex(@"^([0-9A-Fa-f]+|\d+)\s([0-9A-Fa-f]+|\d+)\s\s(.+)$");

        #endregion

        #region Properties

        static List<PCIVendor> _Vendors = new();
        public static IReadOnlyList<PCIVendor> Vendors => _Vendors;

        #endregion

        #region Private

        static void ReadPCIIDs()
        {
            string resourceName = $"{nameof(DiskInfoToolkit)}.Resources.{PCIIDFileName}";

            try
            {
                using (var stream = ResourceExtractor.GetResourceFileGZipStream(resourceName))
                {
                    //Resource is good
                    if (stream != null)
                    {
                        using (var reader = new StreamReader(stream))
                        {
                            string rawLine = null;

                            PCIVendor vendor = null;
                            PCIDevice device = null;

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

                                if (rawLine.StartsWith("\t\t")) //SubDevice
                                {
                                    if (device != null)
                                    {
                                        device.SubDevices.Add(new(lineValues.Item1, lineValues.Item2, lineValues.Item3));
                                    }
                                }
                                else if (rawLine.StartsWith("\t")) //Device
                                {
                                    if (vendor != null)
                                    {
                                        device = new(lineValues.Item1, lineValues.Item3);

                                        vendor.Devices.Add(device);
                                    }
                                }
                                else //Vendor
                                {
                                    vendor = new(lineValues.Item1, lineValues.Item3);

                                    _Vendors.Add(vendor);
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

        static Tuple<int, int, string> GetLineValues(string line)
        {
            var match = _RegexNormal.Match(line);

            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, NumberStyles.HexNumber, null, out var vendor);

                return new(vendor, -1, match.Groups[2].Value);
            }

            match = _RegexSub.Match(line);

            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, NumberStyles.HexNumber, null, out var vendor);
                int.TryParse(match.Groups[2].Value, NumberStyles.HexNumber, null, out var device);

                return new(vendor, device, match.Groups[3].Value);
            }

            return null;
        }

        #endregion
    }
}
