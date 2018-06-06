using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.AdoNet;
using VF.Macros.Data.SQLite;
using VF.Macros.Data.Entity;
using VF.Macros.Data.Repositories;

namespace VF.Macros.Data.SQLite.Repositories
{

    /// <summary>
    /// The SQLite Macro Data Repository
    /// </summary>
    public class SQLiteMacroDataRepository : BaseAdoNetDataRepository, IMacroDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteMacroDataRepository));

        /// <summary>
        /// Initialize SQLite Macro Data Repository
        /// </summary>
        /// <param name="dbManager">The Database Manager</param>
        public SQLiteMacroDataRepository(IDbManager dbManager) : base(DEFAULT_CONNECTION_STRING_NAME, dbManager) {}

        /// <summary>
        /// Get All Macros
        /// </summary>
        /// <returns>The Macros</returns>
        public IEnumerable<IMacro> GetAllMacros()
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_NAME_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME}," +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} " +
                    $" FROM" +
                    $"      {SQLiteDataContract.Macros.TABLE_NAME} M " +
                    $" ORDER BY" +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        var results = new List<IMacro>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SQLiteMacroImpl(reader));
                            }
                        }
                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting All Macros", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macro By ID
        /// </summary>
        /// <param name="macroID">The Macro ID</param>
        /// <returns>The Macro</returns>
        public IEnumerable<IMacro> GetMacroByID(long macroID)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_NAME_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} " +
                    $" FROM " +
                    $"      {SQLiteDataContract.Macros.TABLE_NAME} M " +
                    $" WHERE " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ID_NAME} = @id " +
                    $" ORDER BY" +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {

                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", macroID));

                        var results = new List<IMacro>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SQLiteMacroImpl(reader));
                            }
                        }
                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macro by ID", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macro by Qualified Name
        /// </summary>
        /// <param name="qualifiedName">The Qualified Macro Name</param>
        /// <returns>The Macro</returns>
        public IEnumerable<IMacro> GetMacroByQualifiedName(string qualifiedName)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_NAME_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} " +
                    $" FROM " +
                    $"      {SQLiteDataContract.Macros.TABLE_NAME} M " +
                    $"      INNER JOIN {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} MS ON MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME} = M.{SQLiteDataContract.Macros.COLUMN_ID_NAME} " +
                    $" WHERE " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_QUALIFIED_NAME_NAME} = @qualifiedName " +
                    $" ORDER BY" +
                    $"      {SQLiteDataContract.Macros.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {

                        command.Parameters.Add(CreateParameter(DbType.String, "@qualifiedName", qualifiedName));

                        var results = new List<IMacro>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SQLiteMacroImpl(reader));
                            }
                        }
                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macro by Qualified Name", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macros By LabelID
        /// </summary>
        /// <param name="labelID">The LabelID</param>
        /// <returns></returns>
        public IEnumerable<IMacro> GetMacrosByLabelID(long? labelID)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_NAME_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME}, " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} " +
                    $" FROM " +
                    $"      {SQLiteDataContract.Macros.TABLE_NAME} M " +
                    $" WHERE " +
                    $"      M.{SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME} = @labelID " +
                    $" ORDER BY" +
                    $"      {SQLiteDataContract.Macros.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {

                        command.Parameters.Add(CreateParameter(DbType.Int64, "@labelID", labelID == null ? DBNull.Value : labelID.Value as object));

                        var results = new List<IMacro>();
                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SQLiteMacroImpl(reader));
                            }
                        }
                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macros by LabelID", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Macro
        /// </summary>
        /// <param name="labelID">The Label ID</param>
        /// <param name="name">The Macro Name</param>
        /// <param name="listOrder">The List Order</param>
        /// <param name="createDate">The Create Date</param>
        /// <param name="enabled">Is Macro Enabled</param>
        /// <remarks>The Created Macro</remarks>
        public IMacro CreateMacro(
            long? labelID,
            string name,
            int listOrder,
            DateTime createDate,
            bool enabled)
        {
            try
            {
                string sql =
                    $" INSERT INTO {SQLiteDataContract.Macros.TABLE_NAME} ( " +
                    $"      {SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME}," +
                    $"      {SQLiteDataContract.Macros.COLUMN_NAME_NAME}, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME}, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME}, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} " +
                    $" )  VALUES ( " +
                    $"      @labelID, " +
                    $"      @qualifiedName, " +
                    $"      @name, " +
                    $"      @listOrder, " +
                    $"      @createDate, " +
                    $"      @enabled " +
                    $" ); ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@labelID", labelID == null ? DBNull.Value : labelID.Value as object));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", name));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@listOrder", listOrder));
                        command.Parameters.Add(CreateParameter(DbType.DateTime, "@createDate", createDate));
                        command.Parameters.Add(CreateParameter(DbType.Boolean, "@enabled", enabled));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Inserted Macro - {recordsAffected} records affected");

                        long macroID = connection.GetLastInsertedID();
                        return GetMacroByID(macroID).FirstOrDefault();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Macro", caught);
                throw;
            }
        }

        /// <summary>
        /// Update Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        public void UpdateMacro(IMacro macro)
        {
            try
            {

                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                string sql =
                    $" UPDATE {SQLiteDataContract.Macros.TABLE_NAME} SET " +
                    $"      {SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME} = @labelID, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_NAME_NAME} = @friendlyName, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME} = @listOrder, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME} = @createDate, " +
                    $"      {SQLiteDataContract.Macros.COLUMN_ENABLED_NAME} = @enabled " +
                    $" WHERE {SQLiteDataContract.Macros.COLUMN_ID_NAME} = @id; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", macro.ID));
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@labelID", macro.LabelID == null ? DBNull.Value : macro.LabelID as object));
                        command.Parameters.Add(CreateParameter(DbType.String, "@friendlyName", macro.Name));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@listOrder", macro.ListOrder));
                        command.Parameters.Add(CreateParameter(DbType.DateTime, "@createDate", macro.CreateDate));
                        command.Parameters.Add(CreateParameter(DbType.Boolean, "@enabled", macro.Enabled));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Updated Macro - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating Macro", caught);
                throw;
            }
        }

        /// <summary>
        /// Delete Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        public void DeleteMacro(IMacro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                string sql =
                    // This deletes the MacroSoruce
                    $" DELETE FROM {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} " +
                    $" WHERE {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME} = @macroID; " +

                    // And the Macro.  The source shouldn't exist without the header.. you know?
                    $" DELETE FROM {SQLiteDataContract.Macros.TABLE_NAME} " +
                    $" WHERE {SQLiteDataContract.Macros.COLUMN_ID_NAME} = @id; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", macro.ID));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Deleted Macro - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting Macro", caught);
                throw;
            }
        }

        /// <summary>
        /// Gets Macro Source
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <returns>The Macro Source</returns>
        public IEnumerable<IExternalMacroSource> GetExternalMacroSource(IMacro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                var sql =
                    $" SELECT" +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_ID_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_CREATE_DATE_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_EXTERNAL_SOURCE_CODE_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_ACCELERATOR_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_INTERVAL_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MODE_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_PLAY_SECONDS_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_REPEAT_TIMES_NAME}, " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_SOURCE_NAME}, " +
                    $" FROM " +
                    $"      {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} MS " +
                    $" WHERE " +
                    $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME} = @macroID; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", macro.ID));

                        var results = new List<IExternalMacroSource>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SQLiteExternalMacroSourceImpl(reader));
                            }
                        }

                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macro Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Gets External Macro Source by ID
        /// </summary>
        /// <param name="id">The External Macro Source ID</param>
        /// <returns>The External Macro Source</returns>
        public IEnumerable<IExternalMacroSource> GetExternalMacroSourceByID(long id)
        {
            try
            {
                var sql =
                   $" SELECT" +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_ID_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_CREATE_DATE_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_EXTERNAL_SOURCE_CODE_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_ACCELERATOR_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_INTERVAL_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MODE_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_PLAY_SECONDS_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_REPEAT_TIMES_NAME}, " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_SOURCE_NAME}, " +
                   $" FROM " +
                   $"      {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} MS " +
                   $" WHERE " +
                   $"      MS.{SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME} = @macroID; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", id));

                        var results = new List<IExternalMacroSource>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SQLiteExternalMacroSourceImpl(reader));
                            }
                        }

                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting External Macro Source by ID", caught);
                throw;
            }
        }

        /// <summary>
        /// Creates Macro Source
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <param name="createDate">The Create Date</param>
        /// <param name="externalSourceCode">The External Source Code</param>
        /// <param name="acceleratorName">The Accelerator</param>
        /// <param name="interval">The Interval</param>
        /// <param name="mode">The Mode</param>
        /// <param name="playSeconds">The Play Seconds</param>
        /// <param name="playTimes">The PLay Times</param>
        /// <param name="source">The Macro Source</param>
        public IExternalMacroSource CreateExternalMacroSource(IMacro macro, DateTime createDate, string externalSourceCode, string acceleratorName, string interval, string mode, string playSeconds, string playTimes, string source)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException();
                }

                string sql =
                    $" INSERT INTO {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} ( " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_CREATE_DATE_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_EXTERNAL_SOURCE_CODE_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_ACCELERATOR_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_INTERVAL_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_MODE_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_PLAY_SECONDS_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_REPEAT_TIMES_NAME}, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_SOURCE_NAME} " +
                    $" ) VALUES ( " +
                    $"     @macroID,   " +
                    $"     @createDate,   " +
                    $"     @externalSourceCode,   " +
                    $"     @acceleratorName,   " +
                    $"     @interval,   " +
                    $"     @mode,   " +
                    $"     @playSeconds,   " +
                    $"     @repeatTimes,   " +
                    $"     @macroSource   " +
                    $" ); ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", macro.ID));
                        command.Parameters.Add(CreateParameter(DbType.DateTime, "@createDate", createDate));
                        command.Parameters.Add(CreateParameter(DbType.String, "@externalSourceCode", externalSourceCode));
                        command.Parameters.Add(CreateParameter(DbType.String, "@acceleratorName", acceleratorName));
                        command.Parameters.Add(CreateParameter(DbType.String, "@interval", interval));
                        command.Parameters.Add(CreateParameter(DbType.String, "@mode", mode));
                        command.Parameters.Add(CreateParameter(DbType.String, "@playSeconds", playSeconds));
                        command.Parameters.Add(CreateParameter(DbType.String, "@playTimes", playTimes));
                        command.Parameters.Add(CreateParameter(DbType.String, "@macroSource", source));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Created MacroSource - {recordsAffected} records affected");

                        long externalMacroSourceID = connection.GetLastInsertedID();
                        return GetExternalMacroSourceByID(externalMacroSourceID).FirstOrDefault();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating MacroSource", caught);
                throw;
            }
        }

        /// <summary>
        /// Update Macro Source
        /// </summary>
        /// <param name="externalMacroSource">The External Macro Source</param>
        public void UpdateExternalMacroSource(IExternalMacroSource externalMacroSource)
        {
            try
            {
                if (externalMacroSource == null)
                {
                    throw new ArgumentNullException("externalMacroSource");
                }

                string sql =
                    $" UPDATE {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} SET " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_ID_NAME} = @macroID, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_CREATE_DATE_NAME} = @createDate, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_QUALIFIED_NAME_NAME} = @qualifiedName, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_EXTERNAL_SOURCE_CODE_NAME} = @externalSourceCode, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_ACCELERATOR_NAME} = @accelerator, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_INTERVAL_NAME} = @interval, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_MODE_NAME} = @mode, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_PLAY_SECONDS_NAME} = @playSeconds, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_REPEAT_TIMES_NAME} = @repeatTimes, " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_MACRO_SOURCE_NAME} = @macroSource " +
                    $" WHERE " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_ID_NAME} = @id; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", externalMacroSource.ID));
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", externalMacroSource.MacroID));
                        command.Parameters.Add(CreateParameter(DbType.DateTime, "@createDate", externalMacroSource.CreateDate));
                        command.Parameters.Add(CreateParameter(DbType.String, "@qualifiedName", externalMacroSource.QualifiedName));
                        command.Parameters.Add(CreateParameter(DbType.String, "@externalSourceCode", externalMacroSource.ExternalSourceCode));
                        command.Parameters.Add(CreateParameter(DbType.String, "@accelerator", externalMacroSource.Accelerator));
                        command.Parameters.Add(CreateParameter(DbType.String, "@interval", externalMacroSource.Interval));
                        command.Parameters.Add(CreateParameter(DbType.String, "@mode", externalMacroSource.Mode));
                        command.Parameters.Add(CreateParameter(DbType.String, "@playSeconds", externalMacroSource.PlaySeconds));
                        command.Parameters.Add(CreateParameter(DbType.String, "@repeatTimes", externalMacroSource.RepeatTimes));
                        command.Parameters.Add(CreateParameter(DbType.String, "@macroSource", externalMacroSource.MacroSource));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Updated MacroSource - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating Macro Soruce", caught);
                throw;
            }
        }

        /// <summary>
        /// Deletes External Macro Source
        /// </summary>
        /// <param name="externalMacroSource">The External Macro Source</param>
        public void DeleteExternalMacroSource(IExternalMacroSource externalMacroSource)
        {
            try
            {
                if (externalMacroSource == null)
                {
                    throw new ArgumentNullException("externalMacroSource");
                }

                string sql =
                    $" DELETE FROM {SQLiteDataContract.ExternalMacroSource.TABLE_NAME} " +
                    $" WHERE " +
                    $"      {SQLiteDataContract.ExternalMacroSource.COLUMN_ID_NAME} = @id; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", externalMacroSource.ID));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Deleted MacroSource - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting External Macro Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Lookup External Source
        /// </summary>
        /// <param name="code">The Lookup Code</param>
        /// <returns>The External Source</returns>
        public IExternalSource LookupExternalSource(string code)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      S.{SQLiteDataContract.ExternalSources.COLUMN_CODE_NAME}, " +
                    $"      S.{SQLiteDataContract.ExternalSources.COLUMN_NAME_NAME} " +
                    $" FROM " +
                    $"      {SQLiteDataContract.ExternalSources.TABLE_NAME} S " +
                    $" WHERE " +
                    $"      S.{SQLiteDataContract.ExternalSources.COLUMN_CODE_NAME} = @code; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", code));

                        var results = new List<IExternalSource>();
                        using (var reader = command.ExecuteReader())
                        {
                            results.Add(new Entity.SQLiteExternalSourceImpl(reader));
                        }
                        return results.FirstOrDefault();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Looking Up External Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Create External Source
        /// </summary>
        /// <param name="code">The Lookup Code</param>
        /// <param name="name">The External Source Name</param>
        /// <returns>The External Source</returns>
        public IExternalSource CreateExternalSource(string code, string name)
        {
            try
            {
                string sql =
                    $" INSERT INTO {SQLiteDataContract.ExternalSources.TABLE_NAME} ( " +
                    $"      {SQLiteDataContract.ExternalSources.COLUMN_CODE_NAME}," +
                    $"      {SQLiteDataContract.ExternalSources.COLUMN_NAME_NAME} " +
                    $" ) VALUES ( " +
                    $"      @code, @name " +
                    $" );";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", code));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", name));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Created External Source - {recordsAffected} records affected");

                        return LookupExternalSource(code);
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating External Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Update External Source
        /// </summary>
        /// <param name="externalSource">The External Source</param>
        public void UpdateExternalSource(IExternalSource externalSource)
        {
            try
            {
                if (externalSource == null)
                {
                    throw new ArgumentNullException("externalSource");
                }

                string sql =
                    $" UPDATE {SQLiteDataContract.ExternalSources.TABLE_NAME} SET " +
                    $"      {SQLiteDataContract.ExternalSources.COLUMN_NAME_NAME} = @name " +
                    $" WHERE " +
                    $"      {SQLiteDataContract.ExternalSources.COLUMN_CODE_NAME} = @code; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", externalSource.Code));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", externalSource.Name));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Updated External Source - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating External Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Delete External Source
        /// </summary>
        /// <param name="externalSource">The External Source</param>
        public void DeleteExternalSource(IExternalSource externalSource)
        {
            try
            {
                if (externalSource == null)
                {
                    throw new ArgumentNullException("externalSource");
                }

                string sql =
                    $" DELETE FROM {SQLiteDataContract.ExternalSources.TABLE_NAME} " +
                    $" WHERE " +
                    $"      {SQLiteDataContract.ExternalSources.COLUMN_CODE_NAME} = @code; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", externalSource.Code));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Deleted External Source - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting External Source", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macro Assembly
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <returns>The Macro Assembly</returns>
        public IEnumerable<IMacroAssemblyAction> GetMacroAssembly(IMacro macro)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                string sql =
                    $" SELECT " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_TYPE_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_HEIGHT_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_WIDTH_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_X_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_Y_NAME}, " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} " +
                    $" FROM " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.TABLE_NAME} MA " +
                    $" WHERE " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME} = @macroID " +
                    $" ORDER BY " +
                    $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", macro.ID));

                        var results = new List<IMacroAssemblyAction>();
                        using (var reader = command.ExecuteReader())
                        {
                            results.Add(new Entity.SQLiteMacroAssemblyActionImpl(reader));
                        }
                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macro Assembly", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Macro Assembly Action
        /// </summary>
        /// <param name="id">The Macro Assembly Action Identifier</param>
        /// <returns>The Macro Assmbly Action</returns>
        public IMacroAssemblyAction GetMacroAssemblyAction(long id)
        {
            try
            {
                string sql =
                   $" SELECT " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_TYPE_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_HEIGHT_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_WIDTH_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_X_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_Y_NAME}, " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} " +
                   $" FROM " +
                   $"      {SQLiteDataContract.MacroAssemblyActions.TABLE_NAME} MA " +
                   $" WHERE " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME} = @id " +
                   $" ORDER BY " +
                   $"      MA.{SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", id));

                        var results = new List<IMacroAssemblyAction>();
                        using (var reader = command.ExecuteReader())
                        {
                            results.Add(new Entity.SQLiteMacroAssemblyActionImpl(reader));
                        }
                        return results.FirstOrDefault();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Macro Assembly Action", caught);
                throw;
            }
        }

        /// <summary>
        /// Create Macro Assembly Action
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <param name="actionType">The Action Type</param>
        /// <param name="screenHeight">The Screen Height</param>
        /// <param name="screenWidth">The Screen Width</param>
        /// <param name="positionX">The X Position</param>
        /// <param name="positionY">The Y Position</param>
        /// <param name="actionDelay">The Action Delay</param>
        /// <returns>The Macro Assembly Action</returns>
        public IMacroAssemblyAction CreateMacroAssemblyAction(IMacro macro, int actionType, int screenHeight, int screenWidth, int positionX, int positionY, int actionDelay)
        {
            try
            {
                if (macro == null)
                {
                    throw new ArgumentNullException("macro");
                }

                string sql =
                    $" INSERT INTO {SQLiteDataContract.MacroAssemblyActions.TABLE_NAME} ( " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME}, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_TYPE_NAME}, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_HEIGHT_NAME}, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_WIDTH_NAME}, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_X_NAME}, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_Y_NAME}, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} " +
                    $" ) VALUES ( " +
                    $"      @macroID," +
                    $"      @actionType,  " +
                    $"      @screenHeight," +
                    $"      @screenWidth," +
                    $"      @positionX," +
                    $"      @positionY," +
                    $"      @actionDelay" +
                    $" ); ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", macro.ID));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@actionType", actionType));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@screenHeight", screenHeight));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@screenWidth", screenWidth));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@positionX", positionX));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@positionY", positionY));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@actionDelay", actionDelay));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Inserted Macro Assembly Action - {recordsAffected} records affected");

                        long macroAssemblyActionID = connection.GetLastInsertedID();
                        return GetMacroAssemblyAction(macroAssemblyActionID);
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Macro Assembly Action", caught);
                throw;
            }
        }

        /// <summary>
        /// Update Macro Assembly Action
        /// </summary>
        /// <param name="assemblyAction">The Macro Assembly Action</param>
        public void UpdateMacroAssemblyAction(IMacroAssemblyAction assemblyAction)
        {
            try
            {
                if (assemblyAction == null)
                {
                    throw new ArgumentNullException("assemblyAction");
                }


                string sql =
                    $" UPDATE {SQLiteDataContract.MacroAssemblyActions.TABLE_NAME} SET " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME} = @macroID, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_TYPE_NAME} = @actionType, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_HEIGHT_NAME} = @screenHeight, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_WIDTH_NAME} = @screenWidth, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_X_NAME} = @positionX, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_Y_NAME} = @positionY, " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME} = @actionDelay " +
                    $" WHERE " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME} = @id " +
                    $" ); ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", assemblyAction.ID));
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@macroID", assemblyAction.ID));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@actionType", assemblyAction.ActionType));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@screenHeight", assemblyAction.ScreenHeight));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@screenWidth", assemblyAction.ScreenWidth));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@positionX", assemblyAction.PositionX));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@positionY", assemblyAction.PositionY));
                        command.Parameters.Add(CreateParameter(DbType.Int32, "@actionDelay", assemblyAction.ActionDelay));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Updated Macro Assembly Action - {recordsAffected} records affected");
                    }
                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating Macro Assembly Action", caught);
                throw;
            }
        }

        /// <summary>
        /// Delete Macro Assembly Action
        /// </summary>
        /// <param name="assemblyAction">The Macro Assembly Action</param>
        public void DeleteMacroAssemblyAction(IMacroAssemblyAction assemblyAction)
        {
            try
            {
                if (assemblyAction == null)
                {
                    throw new ArgumentNullException("assemblyAction");
                }

                string sql =
                    $" DELETE FROM {SQLiteDataContract.MacroAssemblyActions.TABLE_NAME} " +
                    $" WHERE " +
                    $"      {SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME} = @id " +
                    $" ); ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", assemblyAction.ID));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Deleted Macro Assembly Action - {recordsAffected} records affected");
                    }
                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting Macro Assembly Action", caught);
                throw;
            }
        }
    }
}
