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
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.Data.AdoNet
{

    /// <summary>
    /// The Base ADO.NET Data Repository
    /// </summary>
    public class BaseAdoNetDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(BaseAdoNetDataRepository));

        /// <summary>
        /// The Connection String Settings
        /// </summary>
        private ConnectionStringSettings _connectionStringSettings;

        /// <summary>
        /// The Database Provider Factory
        /// </summary>
        private DbProviderFactory _databaseProviderFactory;

        /// <summary>
        /// The Database Manager
        /// </summary>
        protected IDbManager _databaseManager { get; set; }

        /// <summary>
        /// Initialize Base ADO.NET Data Repository
        /// </summary>
        /// <param name="connectionStringName">The Connection String Name</param>
        /// <param name="dbManager">The Database Manager</param>
        protected BaseAdoNetDataRepository(string connectionStringName, IDbManager dbManager)
        {
            try
            {
                _connectionStringSettings = AdoNetSettings.GetConnectionStringSettings(connectionStringName);
                _databaseProviderFactory = GetDbProviderFactory(_connectionStringSettings);

                _databaseManager = dbManager;
                InitializeRepository();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Base ADO.NET Data Repository", caught);
                throw;
            }
        }

        #region [Provider Factory Helpers]

        /// <summary>
        /// Get Database Provider Factory
        /// </summary>
        /// <returns>The Database Provider Factory</returns>
        protected static DbProviderFactory GetDbProviderFactory(ConnectionStringSettings connectionStringSettings)
        {
            try
            {
                if (connectionStringSettings == null)
                {
                    throw new ArgumentNullException("connectionStringSettings");
                }
                var dbProviderFactory = DbProviderFactories.GetFactory(connectionStringSettings.ProviderName);
                return dbProviderFactory;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Database Provider Facotry", caught);
                throw;
            }
        }

        #endregion

        #region [Repository Initialization Helpers]

        /// <summary>
        /// Initialize Repository
        /// </summary>
        internal void InitializeRepository()
        {
            try
            {
                if (_databaseManager == null)
                {
                    logger.Warn("Database Manager Not Registered, Unable to Initialize Repository");
                    return;
                }

                if (!_databaseManager.DatabaseExists())
                {
                    logger.Warn("Repository does not exist... Initializing");
                    _databaseManager.CreateDatabase();
                    logger.Warn("Repository Initialized");
                }
                
            }
            catch (Exception caught)
            {
                logger.Error("Unexpecetd Error Initializing Repository", caught);
                throw;
            }
        }

        #endregion

        #region [Repository Helpers]

        /// <summary>
        /// Create Connection
        /// </summary>
        /// <returns>The Connection</returns>
        protected DbConnection CreateConnection()
        {
            try
            {
                var connection = _databaseProviderFactory.CreateConnection();
                connection.ConnectionString = _connectionStringSettings.ConnectionString;
                return connection;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Connection", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Command
        /// </summary>
        /// <param name="connection">The Connection</param>
        /// <param name="commandType">The Command Type</param>
        /// <param name="commandText">The Command Text</param>
        /// <returns>The Command</returns>
        protected DbCommand CreateCommand(DbConnection connection, CommandType commandType, string commandText)
        {
            try
            {
                var command = _databaseProviderFactory.CreateCommand();
                command.Connection = connection;
                command.CommandType = commandType;
                command.CommandText = commandText;
                return command;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Command", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Parameter
        /// </summary>
        /// <param name="dbType">The Data Type</param>
        /// <param name="name">The Parameter Name</param>
        /// <param name="value">The Parameter Value</param>
        /// <returns>The Parameter</returns>
        protected DbParameter CreateParameter(DbType dbType, string name, object value)
        {
            try
            {
                var parameter = _databaseProviderFactory.CreateParameter();
                parameter.DbType = dbType;
                parameter.ParameterName = name;
                parameter.Value = value;
                return parameter;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Parameter", caught);
                throw;
            }
        }

        #endregion

    }
}
