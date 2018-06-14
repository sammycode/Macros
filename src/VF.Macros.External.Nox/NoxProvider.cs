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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.External.Nox
{

    /// <summary>
    /// The Nox Provider
    /// </summary>
    public class NoxProvider : IProvider
    {

        /// <summary>
        /// The Nox Provider
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(NoxProvider));

        /// <summary>
        /// The Provider Code
        /// </summary>
        public string ProviderCode => ProviderSettings.PROVIDER_CODE;

        /// <summary>
        /// The Provider Name
        /// </summary>
        public string ProviderName => ProviderSettings.PROVIDER_NAME;

        /// <summary>
        /// The Assembler
        /// </summary>
        public IMacroAssembler Assembler { get; private set; }

        /// <summary>
        /// The Importer
        /// </summary>
        public IMacroImporter Importer { get; private set; }

        /// <summary>
        /// Initialize Nox Provider
        /// </summary>
        public NoxProvider()
        {
            try
            {
                Assembler = new NoxMacroAssembler();
                Importer = new NoxMacroImporter();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Nox Provider", caught);
                throw;
            }
        }

        /// <summary>
        /// Generate Qualified Name
        /// </summary>
        /// <returns></returns>
        public string GenerateQualifiedName()
        {
            try
            {
                var nameGuid = Guid.NewGuid();
                var formattedGuid = nameGuid.ToString("N");
                return formattedGuid;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Generating Qualified Name", caught);
                throw;
            }
        }

    }
}
