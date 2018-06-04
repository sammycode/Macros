﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

using VF.Macros.Data.AdoNet;
using VF.Macros.Data.Entity;

namespace VF.Macros.Data.SQLite.Entity
{

    /// <summary>
    /// The SQLite Label Implementation
    /// </summary>
    public class SQLiteLabelImpl : ILabel
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteLabelImpl));

        #region [Fields]

        /// <summary>
        /// The Label Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Parent Label Identifier
        /// </summary>
        public long? ParentID { get; set; }

        /// <summary>
        /// The Label Name
        /// </summary>
        public string Name { get; set; }

        #endregion

        #region [Bindings]

        /// <summary>
        /// Flag to indicate fields are already mapped
        /// </summary>
        private static bool _mapped = false;

        /// <summary>
        /// The ID Column Index
        /// </summary>
        private static int _indexID;

        /// <summary>
        /// The Parent ID Column Index
        /// </summary>
        private static int _indexParentID;

        /// <summary>
        /// The Name Column Index
        /// </summary>
        private static int _indexName;

        #endregion

        /// <summary>
        /// Initialize SQLite Label Implementation
        /// </summary>
        public SQLiteLabelImpl() {}

        /// <summary>
        /// Initialize SQLite Label Imeplementation
        /// </summary>
        /// <param name="reader">The Data Reader</param>
        public SQLiteLabelImpl(IDataReader reader)
        {
            try
            {
                RealizeColumnMappings(reader);

                ID = reader.GetInt64(_indexID);
                ParentID = reader.GetNullableLong(_indexParentID);
                Name = reader.GetString(_indexName);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Label Imeplementation with DtaReader", caught);
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

                _indexID = reader.GetOrdinal(SQLiteDataContract.Labels.COLUMN_ID_NAME);
                _indexParentID = reader.GetOrdinal(SQLiteDataContract.Labels.COLUMN_PARENT_ID_NAME);
                _indexName = reader.GetOrdinal(SQLiteDataContract.Labels.COLUMN_NAME_NAME);
                _mapped = true;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Realizing Column Bindings", caught);
                throw;
            }
        }

        #endregion

    }
}
