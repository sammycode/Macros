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
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.Data.AdoNet
{

    /// <summary>
    /// The ADO.NET Settings
    /// </summary>
    public static class AdoNetSettings
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(AdoNetSettings));

        /// <summary>
        /// Get Connection String Settings
        /// </summary>
        /// <param name="connectionStringName">The Connection String Name</param>
        /// <returns>The Connection String Settings</returns>
        public static ConnectionStringSettings GetConnectionStringSettings(string connectionStringName)
        {
            try
            {
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
                if (connectionStringSettings == null)
                {
                    throw new ApplicationException($"The Connection String {connectionStringName} is not configured");
                }
                return connectionStringSettings;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Connection String Settings", caught);
                throw;
            }
        }

    }
}
