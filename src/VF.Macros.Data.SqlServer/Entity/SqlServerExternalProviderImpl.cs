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
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.Entity;

namespace VF.Macros.Data.SqlServer.Entity
{

    /// <summary>
    /// The Sql Server External Provider Implementation
    /// </summary>
    public class SqlServerExternalProviderImpl : IExternalProvider
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SqlServerExternalProviderImpl));

        #region [Fields]

        /// <summary>
        /// The Lookup Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The External Provider Name
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region [Binding]

        /// <summary>
        /// Flag to indicate fields are already mapped
        /// </summary>
        private static bool _mapped = false;

        /// <summary>
        /// The Lookup Code Column Index
        /// </summary>
        private static int _indexCode;

        /// <summary>
        /// The External Name Column Index
        /// </summary>
        private static int _indexName;

        #endregion

        /// <summary>
        /// Initialize Sql Server External Provider Implementation
        /// </summary>
        public SqlServerExternalProviderImpl() {}

        /// <summary>
        /// Initialize SQL Server External Provider Implementation with DataReader
        /// </summary>
        /// <param name="reader"></param>
        public SqlServerExternalProviderImpl(IDataReader reader)
        {
            try
            {
                RealizeColumnMappings(reader);

                Code = reader.GetString(_indexCode);
                Name = reader.GetString(_indexName);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Sql Server External Source Implementation", caught);
                throw;
            }
        }

        #region [Binding Helpers]

        /// <summary>
        /// Realize Column Mappings
        /// </summary>
        /// <param name="reader">The Data Reader</param>
        private static void RealizeColumnMappings(IDataReader reader)
        {
            try
            {
                //We only want to map once
                if (_mapped)
                {
                    return;
                }

                if (reader == null)
                {
                    throw new ArgumentNullException("reader");
                }

                _indexCode = reader.GetOrdinal(SQLServerDataContract.ExternalProviders.COLUMN_CODE_NAME);
                _indexName = reader.GetOrdinal(SQLServerDataContract.ExternalProviders.COLUMN_NAME_NAME);
                _mapped = true;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Realizing Column Mappings", caught);
                throw;
            }
        }

        #endregion

    }
}
