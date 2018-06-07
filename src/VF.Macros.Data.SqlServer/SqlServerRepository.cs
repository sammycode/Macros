using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using VF.Macros.Data.Repositories;
using VF.Macros.Data.AdoNet;

namespace VF.Macros.Data.SqlServer
{

    /// <summary>
    /// The SQL Server Repository
    /// </summary>
    public class SqlServerRepository : IDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqlServerRepository));

        /// <summary>
        /// The Database Manager
        /// </summary>
        private IDbManager _databaseManager;

        /// <summary>
        /// The Macro Data Repository
        /// </summary>
        public IMacroDataRepository MacroRepository { get; private set; }

        /// <summary>
        /// The Label Repository
        /// </summary>
        public ILabelDataRepository LabelRepository { get; private set; }

        /// <summary>
        /// The External Provider Repository
        /// </summary>
        public IExternalProviderDataRepository ExternalProviderRepository { get; private set; }

        /// <summary>
        /// Initialize Sql Server Repository
        /// </summary>
        public SqlServerRepository(IDbManager databaseManager)
        {
            try
            {
                //TODO: Consider Infering repositories from the IoC Container
                _databaseManager = databaseManager;
                MacroRepository = new Repositories.SqlServerMacroDataRepository(_databaseManager);
                LabelRepository = new Repositories.SqlServerLabelDataRepository(_databaseManager);
                ExternalProviderRepository = new Repositories.SqlServerExternalProviderDataRepository(_databaseManager);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SqlServer Repository", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Dispose
        /// </summary>
        /// <remarks>
        /// This is here to satisfy the contract,
        /// but this repository is pretty stateless.
        /// </remarks>
        public void Dispose() { }
    }
}
