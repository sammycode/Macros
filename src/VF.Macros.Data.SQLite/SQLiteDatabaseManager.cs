using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Common.Settings;
using VF.Macros.Data.AdoNet;

namespace VF.Macros.Data.SQLite
{

    /// <summary>
    /// The SQLite Database Manager
    /// </summary>
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
                _connectionStringSettings = AdoNetSettings.GetConnectionStringSettings(DataSettings.ConnectionStringName);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Database Manager", caught);
                throw;
            }
        }

        /// <summary>
        /// Determine if Database Exists
        /// </summary>
        /// <returns>True if database file exists</returns>
        public bool DatabaseExists()
        {
            try
            {
                var connectionStringSettings = DataSettings.ConnectionStringSettings;
                var filePath = GetDatabaseFilePath(connectionStringSettings);
                return File.Exists(filePath);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error determining if Database Exists", caught);
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
                logger.Info("Initializing Local Database");

                var connectionStringSettings = DataSettings.ConnectionStringSettings;
                var filePath = GetDatabaseFilePath(connectionStringSettings);
                CreateDatabaseFile(filePath);

                using (var connection = new SQLiteConnection(connectionStringSettings.ConnectionString))
                {
                    connection.Open();
                    logger.Info("Initializing Database Schema");
                    CreateLabelsTable(connection);
                    CreateMacrosTable(connection);
                    CreateMacroAssemblyActionsTable(connection);
                    CreateExternalProvidersTable(connection);
                    CreateExternalMacroSourcesTable(connection);

                    logger.Info("Seeding Initial Data");
                    //TODO: Implement Seeding Initial Data Methods
                    //SeedMacroCategories(connection);

                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Database", caught);
                throw;
            }
        }

        #region [Filesystem Helpers]

        /// <summary>
        /// Get Database FilePath
        /// </summary>
        /// <param name="connectionStringSettings">The Connection String Settings</param>
        /// <returns>The Database FilePath</returns>
        private string GetDatabaseFilePath(ConnectionStringSettings connectionStringSettings)
        {
            try
            {
                if (connectionStringSettings == null)
                {
                    throw new ArgumentNullException("connectionStringSettings");
                }
                var connectionString = connectionStringSettings.ConnectionString;
                var connectionStringTok = connectionString.Split(new[] { ":", ";" }, StringSplitOptions.RemoveEmptyEntries);

                if (connectionStringTok.Length != 2)
                {
                    throw new ApplicationException("Expecting Connection String format to be - URI=file:<filename>");
                }
                var filename = connectionStringTok[1];
                return filename;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Fatabase FilePath", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Database File
        /// </summary>
        /// <param name="filePath">The FilePath</param>
        private void CreateDatabaseFile(string filePath)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    throw new ApplicationException("File already exists");
                }

                SQLiteConnection.CreateFile(filePath);
                logger.Info($"Created Database File: {filePath}");
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Database File", caught);
                throw;
            }
        }

        #endregion

        #region [Schema Initialization Helpers]

        /// <summary>
        /// Create Labels Table
        /// </summary>
        /// <param name="connection">The Connection</param>
        private void CreateLabelsTable(SQLiteConnection connection)
        {
            try
            {
                var sql =
                    $" CREATE TABLE {SQLiteDataContract.Labels.TABLE_NAME} ( " +
                    $"    {SQLiteDataContract.Labels.COLUMN_ID_NAME} INTEGER PRIMARY KEY AUTOINCREMENT" +
                    $"    , {SQLiteDataContract.Labels.COLUMN_PARENT_ID_NAME} INTEGER NULL " +
                    $"    , {SQLiteDataContract.Labels.COLUMN_NAME_NAME} TEXT NOT NULL " +
                    $" ); ";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    var recordsAffected = command.ExecuteNonQuery();
                    logger.Info($"Created Labels Table - {recordsAffected} records affected");
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Labels Table", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Macros Table
        /// </summary>
        /// <param name="connection">The Connection</param>
        private void CreateMacrosTable(SQLiteConnection connection)
        {
            try
            {
                var sql =
                    $" CREATE TABLE {SQLiteDataContract.Macros.TABLE_NAME} ( " +
                    $"    {SQLiteDataContract.Macros.COLUMN_ID_NAME} INTEGER PRIMARY KEY AUTOINCREMENT" +
                    $"    , {SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME} INTEGER NULL " +
                    $"    , {SQLiteDataContract.Macros.COLUMN_NAME_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME} DATETIME NOT NULL " +
                    $"    , {SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} INTEGER NOT NULL " +
                    $" ); ";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    var recordsAffected = command.ExecuteNonQuery();
                    logger.Info($"Created Macros Table - {recordsAffected} records affected");
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Macros Table", caught);
                throw;
            }
        }

        /// <summary>
        /// Creaet Macro Assembly Actions Table
        /// </summary>
        /// <param name="connection">The Connection</param>
        private void CreateMacroAssemblyActionsTable(SQLiteConnection connection)
        {
            try
            {
                var sql =
                    $" CREATE TABLE {SQLiteDataContract.MacroAssemblyActions.TABLE_NAME} ( " +
                    $"    {SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME} INTEGER PRIMARY KEY AUTOINCREMENT" +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_TYPE_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_HEIGHT_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_WIDTH_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_X_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_Y_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} INTEGER NOT NULL " +
                    $" ); ";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    var recordsAffected = command.ExecuteNonQuery();
                    logger.Info($"Created Macro Assembly Actions Table - {recordsAffected} records affected");
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Macro Assembly Actions Table", caught);
                throw;
            }
        }

        /// <summary>
        /// Create External Providers Table
        /// </summary>
        /// <param name="connection">The Connection</param>
        private void CreateExternalProvidersTable(SQLiteConnection connection)
        {
            try
            {
                var sql =
                    $" CREATE TABLE {SQLiteDataContract.ExternalProviders.TABLE_NAME} ( " +
                    $"    {SQLiteDataContract.ExternalProviders.COLUMN_CODE_NAME} TEXT PRIMARY KEY" +
                    $"    , {SQLiteDataContract.ExternalProviders.COLUMN_NAME_NAME} TEXT NOT NULL " +
                    $" ); ";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    var recordsAffected = command.ExecuteNonQuery();
                    logger.Info($"Created External Sources Table - {recordsAffected} records affected");
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating External Providers Table", caught);
                throw;
            }
        }

        /// <summary>
        /// Create External Sources Table
        /// </summary>
        /// <param name="connection">The Connection</param>
        private static void CreateExternalMacroSourcesTable(SQLiteConnection connection)
        {
            try
            {
                var sql =
                    $" CREATE TABLE {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} ( " +
                    $"    {SQLiteDataContract.ExternalMacroSource.COLUMN_ID_NAME} INTEGER PRIMARY KEY AUTOINCREMENT" +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME} INTEGER NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_CREATE_DATE_NAME} DATETIME NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_EXTERNAL_SOURCE_CODE_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_QUALIFIED_NAME_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_ACCELERATOR_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_INTERVAL_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_MODE_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_PLAY_SECONDS_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_REPEAT_TIMES_NAME} TEXT NOT NULL " +
                    $"    , {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_SOURCE_NAME} TEXT NOT NULL " +
                    $" ); ";
                using (var command = new SQLiteCommand(sql, connection))
                {
                    var recordsAffected = command.ExecuteNonQuery();
                    logger.Info($"Created External Macro Sources Table - {recordsAffected} records affected");
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating External Macro Sources Table", caught);
                throw;
            }
        }

        #endregion

        #region [Seed Data Helpers]



        #endregion

    }
}
