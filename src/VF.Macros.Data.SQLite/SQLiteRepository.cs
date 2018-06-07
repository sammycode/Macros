using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;
using VF.Macros.Data.Repositories;
using VF.Macros.Data.AdoNet;

namespace VF.Macros.Data.SQLite
{

    /// <summary>
    /// The SQLite Repository
    /// </summary>
    public class SQLiteRepository : IDataRepository
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteRepository));

        // <summary>
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
        /// Initialize SQLite Repository
        /// </summary>
        /// <param name="dbManager">The Database Manager</param>
        public SQLiteRepository(IDbManager dbManager)
        {
            try
            {
                _databaseManager = dbManager;
                MacroRepository = new Repositories.SQLiteMacroDataRepository(_databaseManager);
                LabelRepository = new Repositories.SQLiteLabelDataRepository(_databaseManager);
                ExternalProviderRepository = new Repositories.SQLiteExternalProviderDataRepository(_databaseManager);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Repository", caught);
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
        public void Dispose() {}

    }
}
