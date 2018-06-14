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
