using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.AdoNet;
using VF.Macros.Data.Entity;
using VF.Macros.Data.Repositories;

namespace VF.Macros.Data.SqlServer.Repositories
{

    /// <summary>
    /// The Sql Server Label Data Repository
    /// </summary>
    public class SqlServerLabelDataRepository : BaseAdoNetDataRepository, ILabelDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqlServerLabelDataRepository));

        /// <summary>
        /// Initialize SQL Server Label Data Repository
        /// </summary>
        /// <param name="dbManager">The Database Manager</param>
        public SqlServerLabelDataRepository(IDbManager dbManager) : base(DEFAULT_CONNECTION_STRING_NAME, dbManager) {}

        /// <summary>
        /// Get All Labels
        /// </summary>
        /// <returns>The Labels</returns>
        public IEnumerable<ILabel> GetAllLabels()
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} " +
                    $" FROM " +
                    $"      {SQLServerDataContract.Labels.TABLE_NAME} L " +
                    $" ORDER BY " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        var results = new List<ILabel>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SqlServerLabelImpl(reader));
                            }
                        }

                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting All Labels", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Top Level Labels
        /// </summary>
        /// <returns>The Labels</returns>
        public IEnumerable<ILabel> GetTopLevelLabels()
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} " +
                    $" FROM " +
                    $"      {SQLServerDataContract.Labels.TABLE_NAME} L " +
                    $" WHERE " +
                    $"      {SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME} IS NULL " +
                    $" ORDER BY " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        var results = new List<ILabel>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SqlServerLabelImpl(reader));
                            }
                        }

                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Top Level Labels", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Child Labels
        /// </summary>
        /// <param name="parentID">The Parent Label ID</param>
        /// <returns>The Child Labels</returns>
        public IEnumerable<ILabel> GetChildLabels(long parentID)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} " +
                    $" FROM " +
                    $"      {SQLServerDataContract.Labels.TABLE_NAME} L " +
                    $" WHERE " +
                    $"      {SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME} = @parentID " +
                    $" ORDER BY " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@parentID", parentID));

                        var results = new List<ILabel>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SqlServerLabelImpl(reader));
                            }
                        }

                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Child Labels", caught);
                throw;
            }
        }

        /// <summary>
        /// Get Label by ID
        /// </summary>
        /// <param name="id">The Label ID</param>
        /// <returns>The Label</returns>
        public IEnumerable<ILabel> GetLabelByID(long id)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME}, " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} " +
                    $" FROM " +
                    $"      {SQLServerDataContract.Labels.TABLE_NAME} L " +
                    $" WHERE " +
                    $"      {SQLServerDataContract.Labels.COLUMN_ID_NAME} = @id " +
                    $" ORDER BY " +
                    $"      L.{SQLServerDataContract.Labels.COLUMN_NAME_NAME} ASC; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", id));

                        var results = new List<ILabel>();

                        using (var reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                results.Add(new Entity.SqlServerLabelImpl(reader));
                            }
                        }

                        return results;
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Label By ID", caught);
                throw;
            }
        }
        
        /// <summary>
        /// Create Label
        /// </summary>
        /// <param name="parentID">The Parent Label ID *Null Means Top Level Label*</param>
        /// <param name="name">The Label Name</param>
        public ILabel CreateLabel(long? parentID, string name)
        {
            try
            {
                string sql =
                    $" INSERT INTO {SQLServerDataContract.Labels.TABLE_NAME} ( " +
                    $"      {SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME}, " +
                    $"      {SQLServerDataContract.Labels.COLUMN_NAME_NAME} " +
                    $" ) output INSERTED.ID VALUES ( " +
                    $"      @parentID, " +
                    $"      @name " +
                    $" ); ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@parentID", parentID == null ? DBNull.Value : parentID.Value as object));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", name));

                        //int recordsAffected = command.ExecuteNonQuery();
                        //logger.Info($"Created Label - {recordsAffected} records affected");
                        long labelID = (long)command.ExecuteScalar();
                        return GetLabelByID(labelID).FirstOrDefault();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Creating Label", caught);
                throw;
            }
        }

        /// <summary>
        /// Update Label
        /// </summary>
        /// <param name="label">The Label</param>
        public void UpdateLabel(ILabel label)
        {
            try
            {
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                string sql =
                    $" UPDATE {SQLServerDataContract.Labels.TABLE_NAME} SET " +
                    $"      {SQLServerDataContract.Labels.COLUMN_PARENT_ID_NAME} = @parentID, " +
                    $"      {SQLServerDataContract.Labels.COLUMN_NAME_NAME} = @name " +
                    $" WHERE " +
                    $"      {SQLServerDataContract.Labels.COLUMN_ID_NAME} = @id; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", label.ID));
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@parentID", label.ParentID == null ? DBNull.Value : label.ParentID.Value as object));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", label.Name));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Updated Label - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating Label", caught);
                throw;
            }
        }

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="label">The Label</param>
        public void DeleteLabel(ILabel label)
        {
            try
            {
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                string sql =
                    $" DELETE FROM {SQLServerDataContract.Labels.TABLE_NAME} WHERE {SQLServerDataContract.Labels.COLUMN_ID_NAME} = @id; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.Int64, "@id", label.ID));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Deleted Label - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting Label", caught);
                throw;
            }
        }
        
    }
}
