using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Common.Settings;
using VF.Macros.Data.AdoNet;

namespace VF.Macros.Data.SqlServer
{

    /// <summary>
    /// The SQL Server Database Manager
    /// </summary>
    public class SqlServerDatabaseMangaer : IDbManager
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqlServerDatabaseMangaer));

        /// <summary>
        /// The Connection String Settings
        /// </summary>
        private ConnectionStringSettings _connectionStringSettings;

        /// <summary>
        /// Initialize SQL Server Database Manager
        /// </summary>
        public SqlServerDatabaseMangaer()
        {
            try
            {
                _connectionStringSettings = AdoNetSettings.GetConnectionStringSettings(DataSettings.ConnectionStringName);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQL Server Database Manager", caught);
                throw;
            }
        }

        /// <summary>
        /// Determine if Database Exists
        /// </summary>
        /// <returns>True if database exists</returns>
        public bool DatabaseExists()
        {
            try
            {
                //TODO: Break Apart the connection string,
                //Issue SQL Server Specific commands, OR API if available to determine if database exists

                return true;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Determining if Database Exists", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Database
        /// </summary>
        public void CreateDatabase()
        {
            try
            {

                //TODO: Create Database
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Database", caught);
                throw;
            }
        }

        #region [Connection String Helpers]

        #endregion

        #region [Schema Initialization Helpers]

        #endregion

        #region [Seed Data Helpers]

        #endregion

    }
}
