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
using VF.Macros.Data.AdoNet;

namespace VF.Macros.Data.SQLite.Entity
{

    /// <summary>
    /// The SQLite Macro Implementation
    /// </summary>
    public class SQLiteMacroImpl : IMacro
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteMacroImpl));

        #region [Fields]

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Label ID
        /// </summary>
        public long? LabelID { get; set; }

        ///// <summary>
        ///// The Qualified Macro Name
        ///// </summary>
        //public string QualifiedName { get; set; }

        /// <summary>
        /// The Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        public int ListOrder { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The Enabled Flag
        /// </summary>
        public bool Enabled { get; set; }

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
        /// The LabelID Index
        /// </summary>
        private static int _indexLabelID;

        /// <summary>
        /// The Friendly Name Column Index
        /// </summary>
        private static int _indexName;

        /// <summary>
        /// The List Order Column Index
        /// </summary>
        private static int _indexListOrder;

        /// <summary>
        /// The CreateDate Column Index
        /// </summary>
        private static int _indexCreateDate;

        /// <summary>
        /// The Enabled Column Index
        /// </summary>
        private static int _indexEnabled;

        #endregion

        /// <summary>
        /// Initialize SQLite Macro Implementation
        /// </summary>
        public SQLiteMacroImpl() {}

        /// <summary>
        /// Initialize SQLite Macro Implementation with DataReader
        /// </summary>
        /// <param name="reader">The Data Reader</param>
        public SQLiteMacroImpl(IDataReader reader)
        {
            try
            {
                RealizeColumnMappings(reader);

                ID = reader.GetInt64(_indexID);
                LabelID = reader.GetNullableLong(_indexLabelID);
                Name = reader.GetString(_indexName);
                ListOrder = reader.GetInt32(_indexListOrder);
                CreateDate = reader.GetDateTime(_indexCreateDate);
                Enabled = reader.GetBoolean(_indexEnabled);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Macro Implementation with DataReader", caught);
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

                _indexID = reader.GetOrdinal(SQLiteDataContract.Macros.COLUMN_ID_NAME);
                _indexLabelID = reader.GetOrdinal(SQLiteDataContract.Macros.COLUMN_LABEL_ID_NAME);
                _indexName = reader.GetOrdinal(SQLiteDataContract.Macros.COLUMN_NAME_NAME);
                _indexListOrder = reader.GetOrdinal(SQLiteDataContract.Macros.COLUMN_LIST_ORDER_NAME);
                _indexCreateDate = reader.GetOrdinal(SQLiteDataContract.Macros.COLUMN_CREATE_DATE_NAME);
                _indexEnabled = reader.GetOrdinal(SQLiteDataContract.Macros.COLUMN_ENABLED_NAME);
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
