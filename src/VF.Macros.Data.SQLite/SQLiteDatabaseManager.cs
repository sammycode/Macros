using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.AdoNet;

namespace VF.Macros.Data.SQLite
{

    /// <summary>
    /// The SQLite Database Manager
    /// </summary>
    /// <remarks>
    /// This has to be implemented in it's entirety...
    /// </remarks>
    public class SQLiteDatabaseManager : IDbManager
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteDatabaseManager));

        /// <summary>
        /// The Connection String Settings
        /// </summary>
        private ConnectionStringSettings _connectionStringSettings;

        /// <summary>
        /// Initialize SQLite Database Manager
        /// </summary>
        public SQLiteDatabaseManager()
        {
            try
            {
                _connectionStringSettings = AdoNetSettings.GetConnectionStringSettings(BaseAdoNetDataRepository.DEFAULT_CONNECTION_STRING_NAME);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Database Manager", caught);
                throw;
            }
        }
        
        public void CreateDatabase()
        {
            throw new NotImplementedException();
        }

        public bool DatabaseExists()
        {
            throw new NotImplementedException();
        }
    }
}
