﻿/*
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
