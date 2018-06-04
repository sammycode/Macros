﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.Entity;

namespace VF.Macros.Data.SQLite.Entity
{

    /// <summary>
    /// The SQLite External Source Implementation
    /// </summary>
    public class SQLiteExternalSourceImpl : IExternalSource
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteExternalSourceImpl));

        #region [Fields]

        /// <summary>
        /// The Lookup Code
        /// </summary>
        public string Code { get; set; }

        /// <summary>
        /// The External Source Name
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
        /// Initialize SQLite External Source Implementation
        /// </summary>
        public SQLiteExternalSourceImpl() {}

        /// <summary>
        /// Initialize SQLite External Source Implementation with DataReader
        /// </summary>
        /// <param name="reader">The DataReader</param>
        public SQLiteExternalSourceImpl(IDataReader reader)
        {
            try
            {
                RealizeColumnMappings(reader);

                Code = reader.GetString(_indexCode);
                Name = reader.GetString(_indexName);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite External Source Implementation with Datareader", caught);
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

                _indexCode = reader.GetOrdinal(SQLiteDataContract.ExternalSources.COLUMN_CODE_NAME);
                _indexName = reader.GetOrdinal(SQLiteDataContract.ExternalSources.COLUMN_NAME_NAME);
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
