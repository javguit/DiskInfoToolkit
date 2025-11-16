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

using System.IO.Compression;

namespace DiskInfoToolkit.Utilities
{
    internal static class ResourceExtractor
    {
        #region Public

        public static GZipStream GetResourceFileGZipStream(string resourceName)
        {
            var assemblyWithDriverResource = typeof(ResourceExtractor).Assembly;

            try
            {
                Stream stream = assemblyWithDriverResource.GetManifestResourceStream(resourceName);

                //Resource is good
                if (stream != null)
                {
                    return new GZipStream(stream, CompressionMode.Decompress);
                }
            }
            catch (Exception)
            {
                return null;
            }

            return null;
        }

        #endregion
    }
}
