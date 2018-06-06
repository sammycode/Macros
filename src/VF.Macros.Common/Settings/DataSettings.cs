using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.Common.Settings
{
    
    /// <summary>
    /// The Data Settings
    /// </summary>
    /// <remarks>
    /// This contains managed wrappers around Data Specific Settings.
    /// This used in a few areas.
    /// 1 - The Application Context uses this to assemble the Application Composition, as the composition is made up through a
    ///     dependancy injection framework.  So the data provider for example, will have an impact on which underlying
    ///     database implementation is initialized with the App.
    /// 2 - The Data Components themselves use this to grab important information, such as the underlying ADO.NET provider,
    ///     as well as connection string information, which it uses to connect to, or create the database if it needs to.
    /// </remarks>
    public class DataSettings
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(DataSettings));

        #region [AppSettings Keys]

        /// <summary>
        /// The Data Provider AppSetting Key
        /// </summary>
        public const string KEY_DATA_PROVIDER = "DATA.PROVIDER";

        /// <summary>
        /// The Connection String Name AppSetting Key
        /// </summary>
        public const string KEY_DATA_CONNECTION_STRING_NAME = "DATA.CONNECTIONSTRING";

        #endregion

        #region [Default Settings Values]

        /// <summary>
        /// The Default Data Provider Setting Value
        /// </summary>
        public const string DEFAULTVALUE_DATA_PROVIDER = "SQLite";

        /// <summary>
        /// The Default Connection String Setting Value
        /// </summary>
        public const string DEFAULTVALUE_CONNETION_STRING_NAME = "DefaultConnection";

        #endregion

        #region [Valid Values]

        /// <summary>
        /// The SQL Server Configuration Value
        /// </summary>
        public const string PROVIDER_SQL_SERVER = "SQLServer";

        /// <summary>
        /// The SQLite Configuration Value
        /// </summary>
        public const string PROVIDER_SQLITE = "SQLite";

        /// <summary>
        /// The Valid Data Providers
        /// </summary>
        private static readonly string[] VALID_DATA_PROVIDERS = { PROVIDER_SQLITE, PROVIDER_SQL_SERVER };

        #endregion

        /// <summary>
        /// Gets Data Provider
        /// </summary>
        public static string DataProvider {
            get {
                return GetDataProvider();
            }
        }

        /// <summary>
        /// Gets Connection String Settings
        /// </summary>
        public static ConnectionStringSettings ConnectionStringSettings {
            get {
                return GetConnectionStringSettings();
            }
        }

        #region [Data Provider Helpers]

        /// <summary>
        /// Get Data Provider
        /// </summary>
        /// <returns>The Data Provider</returns>
        private static string GetDataProvider() {
            try
            {
                /*
                 * Making the assumption that the Data Provider is configured.
                 * If it's not, or if it's set to an unexpected value, just giving it a default
                 * value, this make's it "safe" to not have the setting present in the app settings.
                 */
                var configuredDataProvider = ConfigurationManager.AppSettings[KEY_DATA_PROVIDER];
                if (string.IsNullOrWhiteSpace(configuredDataProvider) || !VALID_DATA_PROVIDERS.Contains(configuredDataProvider))
                {
                    configuredDataProvider = DEFAULTVALUE_DATA_PROVIDER;
                }
                return configuredDataProvider;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Data Provider", caught);
                throw;
            }
        }

        #endregion

        #region [Connection String Helpers]

        /// <summary>
        /// Get Connection String Name
        /// </summary>
        /// <returns>The Connection String Name</returns>
        private static string GetConnectionStringName()
        {
            try
            {
                /*
                 * The effect I wanted here, is to use the Default Connection string name if it's not configured.
                 * But I don't want to inforce the default connection string name, should an alternate one be provided,
                 * I think that might invite some unhappy people who changed their connection string to preserve an existing
                 * data set, but didn't actually configure the connection string.
                 */
                var connectionStringName = ConfigurationManager.AppSettings[KEY_DATA_CONNECTION_STRING_NAME];
                if (string.IsNullOrWhiteSpace(connectionStringName))
                {
                    connectionStringName = DEFAULTVALUE_CONNETION_STRING_NAME;
                }
                return connectionStringName;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Connection String Name", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Connection String Settings
        /// </summary>
        /// <returns>The Connection String Settings</returns>
        private static ConnectionStringSettings GetConnectionStringSettings()
        {
            try
            {
                var connectionStringName = GetConnectionStringName();
                var connectionStringSettings = ConfigurationManager.ConnectionStrings[connectionStringName];
                if (connectionStringSettings == null)
                {
                    logger.Warn($"A connection string named {connectionStringName} is configured, but the Connection String configuration is not present.");
                    throw new ApplicationException("Connection String is Not Configured");
                }
                return connectionStringSettings;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Connection String", caught);
                throw;
            }
        } 

        #endregion

    }
}
