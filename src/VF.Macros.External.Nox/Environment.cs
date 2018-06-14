/*
 * Copyright (C) 2018  Mike Jamer
 * 
 * This program is free software; you can redistribute it and/or
 * modify it under the terms of the GNU General Public License
 * as published by the Free Software Foundation; either version 2
 * of the License, or (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301, USA.
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.External.Nox
{

    /// <summary>
    /// The Nox Environment
    /// </summary>
    internal class Environment
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Environment));

        /// <summary>
        /// Gets Nox Data Directory
        /// </summary>
        /// <returns>The Nox Data Directory</returns>
        public static string GetNoxMacroDirectory()
        {
            try
            {
                var localAppDataDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.LocalApplicationData);
                var noxMacroDirectory = Path.Combine(localAppDataDirectory, "Nox", "record");
                return noxMacroDirectory;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Nox DataDirectory", caught);
                throw;
            }
        }

        /// <summary>
        /// Gets Nox Macro Records FilePath
        /// </summary>
        /// <returns>The Nox Macro Records FilePath</returns>
        public static string GetNoxMacroRecordsFilePath()
        {
            try
            {
                var noxMacroDirectory = GetNoxMacroDirectory();
                var noxRecordsFilePath = Path.Combine(noxMacroDirectory, "records");
                return noxRecordsFilePath;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Nox Macro Records FilePath", caught);
                throw;
            }
        }

    }
}
