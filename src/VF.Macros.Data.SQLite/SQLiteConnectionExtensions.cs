using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.Data.SQLite
{

    /// <summary>
    /// The SQLite Connection Extensions Class
    /// </summary>
    internal static class SQLiteConnectionExtensions
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteConnectionExtensions));

        /// <summary>
        /// Gets Last Inserted ID by this connection
        /// </summary>
        /// <param name="connection">The Connection</param>
        /// <returns>The Last Inserted ID</returns>
        public static long GetLastInsertedID(this DbConnection connection)
        {
            try
            {
                if (connection == null)
                {
                    throw new ArgumentNullException("connection");
                }
                var sqliteConnection = connection as SQLiteConnection;
                if (sqliteConnection == null)
                {
                    throw new ApplicationException("Unable to treat connection as SQLite Connection");
                }
                var lastInserteID = sqliteConnection.LastInsertRowId;
                return lastInserteID;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Last Inserted ID", caught);
                throw;
            }
        }

    }
}
