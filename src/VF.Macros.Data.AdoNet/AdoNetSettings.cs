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
