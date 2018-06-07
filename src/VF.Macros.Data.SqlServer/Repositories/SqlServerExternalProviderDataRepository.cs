using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Common.Settings;
using VF.Macros.Data.AdoNet;
using VF.Macros.Data.Entity;
using VF.Macros.Data.Repositories;

namespace VF.Macros.Data.SqlServer.Repositories
{

    /// <summary>
    /// The SQL Server External Provider Data Repository
    /// </summary>
    public class SqlServerExternalProviderDataRepository : BaseAdoNetDataRepository, IExternalProviderDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqlServerExternalProviderDataRepository));

        /// <summary>
        /// Initialize SQLite External Provider Data Repository
        /// </summary>
        /// <param name="dbManager"></param>
        public SqlServerExternalProviderDataRepository(IDbManager dbManager) : base(DataSettings.ConnectionStringName, dbManager) { }

        /// <summary>
        /// Lookup External Provider
        /// </summary>
        /// <param name="code">The Lookup Code</param>
        /// <returns>The External Provider</returns>
        public IExternalProvider LookupExternalProvider(string code)
        {
            try
            {
                string sql =
                    $" SELECT " +
                    $"      S.{SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME}, " +
                    $"      S.{SQLServerDataContract.ExternalProviders.COLUMN_NAME_NAME} " +
                    $" FROM " +
                    $"      {SQLServerDataContract.ExternalProviders.TABLE_NAME} S " +
                    $" WHERE " +
                    $"      S.{SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME} = @code; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", code));

                        var results = new List<IExternalProvider>();
                        using (var reader = command.ExecuteReader())
                        {
                            results.Add(new Entity.SqlServerExternalProviderImpl(reader));
                        }
                        return results.FirstOrDefault();
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Looking Up External Provider", caught);
                throw;
            }
        }

        /// <summary>
        /// Create External Provider
        /// </summary>
        /// <param name="code">The Lookup Code</param>
        /// <param name="name">The Provider Name</param>
        /// <returns>The External Provider</returns>
        public IExternalProvider CreateExternalProvider(string code, string name)
        {
            try
            {
                string sql =
                    $" INSERT INTO {SQLServerDataContract.ExternalProviders.TABLE_NAME} ( " +
                    $"      {SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME}," +
                    $"      {SQLServerDataContract.ExternalProviders.COLUMN_NAME_NAME} " +
                    $" ) output INSERTED.{SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME} VALUES ( " +
                    $"      @code, @name " +
                    $" );";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", code));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", name));

                        //int recordsAffected = command.ExecuteNonQuery();
                        //logger.Info($"Created External Source - {recordsAffected} records affected");
                        string externalSourceCode = (string)command.ExecuteScalar();
                        return LookupExternalProvider(externalSourceCode);
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
        /// Update External Provider
        /// </summary>
        /// <param name="externalProvider">The External Provider</param>
        public void UpdateExternalProvider(IExternalProvider externalProvider)
        {
            try
            {
                if (externalProvider == null)
                {
                    throw new ArgumentNullException("externalSource");
                }

                string sql =
                    $" UPDATE {SQLServerDataContract.ExternalProviders.TABLE_NAME} SET " +
                    $"      {SQLServerDataContract.ExternalProviders.COLUMN_NAME_NAME} = @name " +
                    $" WHERE " +
                    $"      {SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME} = @code; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", externalProvider.Code));
                        command.Parameters.Add(CreateParameter(DbType.String, "@name", externalProvider.Name));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Updated External Provider - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Updating External Provider", caught);
                throw;
            }
        }

        /// <summary>
        /// Delete External Provider
        /// </summary>
        /// <param name="externalProvider">The External Provider</param>
        public void DeleteExternalProvider(IExternalProvider externalProvider)
        {
            try
            {
                if (externalProvider == null)
                {
                    throw new ArgumentNullException("externalSource");
                }

                string sql =
                    $" DELETE FROM {SQLServerDataContract.ExternalProviders.TABLE_NAME} " +
                    $" WHERE " +
                    $"      {SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME} = @code; ";
                using (var connection = CreateConnection())
                {
                    connection.Open();
                    using (var command = CreateCommand(connection, CommandType.Text, sql))
                    {
                        command.Parameters.Add(CreateParameter(DbType.String, "@code", externalProvider.Code));

                        int recordsAffected = command.ExecuteNonQuery();
                        logger.Info($"Deleted External Provider - {recordsAffected} records affected");
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Deleting External Provider", caught);
                throw;
            }
        }

    }
}
