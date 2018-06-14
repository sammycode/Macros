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

namespace VF.Macros.Data.SQLite.Entity
{

    /// <summary>
    /// The SQLite Macro Assembly Action Implementation
    /// </summary>
    public class SQLiteMacroAssemblyActionImpl : IMacroAssemblyAction
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(SQLiteMacroAssemblyActionImpl));

        #region [Fields]

        /// <summary>
        /// The Macro Assembly Action Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        public long MacroID { get; set; }

        /// <summary>
        /// The Action Type
        /// </summary>
        public int ActionType { get; set; }

        /// <summary>
        /// The Screen Height
        /// </summary>
        public int ScreenHeight { get; set; }

        /// <summary>
        /// The Screen Width
        /// </summary>
        public int ScreenWidth { get; set; }

        /// <summary>
        /// The Action X Position
        /// </summary>
        public int PositionX { get; set; }

        /// <summary>
        /// The Action Y Position
        /// </summary>
        public int PositionY { get; set; }

        /// <summary>
        /// The Action Delay
        /// </summary>
        public int ActionDelay { get; set; }

        #endregion

        #region [Bindings]

        /// <summary>
        /// Flag to indicate fields are already mapped
        /// </summary>
        private static bool _mapped = false;

        /// <summary>
        /// The ID Index
        /// </summary>
        private static int _indexID;

        /// <summary>
        /// The MacroID Index
        /// </summary>
        private static int _indexMacroID;

        /// <summary>
        /// The ActionType Index
        /// </summary>
        private static int _indexActionType;

        /// <summary>
        /// The ScreenHeight Index
        /// </summary>
        private static int _indexScreenHeight;

        /// <summary>
        /// The ScreenWidth Index
        /// </summary>
        private static int _indexScreenWidth;

        /// <summary>
        /// The XPosition Index
        /// </summary>
        private static int _indexPositionX;

        /// <summary>
        /// The YPosition Index
        /// </summary>
        private static int _indexPositionY;

        /// <summary>
        /// The Action Delay
        /// </summary>
        private static int _indexActionDelay;

        #endregion

        /// <summary>
        /// Initalize SQLite Macro Assembly Action Implementation
        /// </summary>
        public SQLiteMacroAssemblyActionImpl() {}

        /// <summary>
        /// Initialize SQLite Macro Assembly Action Implementation
        /// </summary>
        /// <param name="reader"></param>
        public SQLiteMacroAssemblyActionImpl(IDataReader reader)
        {
            try
            {
                RealizeColumnMappings(reader);

                ID = reader.GetInt64(_indexID);
                MacroID = reader.GetInt64(_indexMacroID);
                ActionType = reader.GetInt32(_indexActionType);
                ScreenHeight = reader.GetInt32(_indexScreenHeight);
                ScreenWidth = reader.GetInt32(_indexScreenWidth);
                PositionX = reader.GetInt32(_indexPositionX);
                PositionY = reader.GetInt32(_indexPositionY);
                ActionDelay = reader.GetInt32(_indexActionDelay);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing SQLite Macro Assembly Action Implementaiton", caught);
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
                if (_mapped)
                {
                    return;
                }

                if (reader == null)
                {
                    throw new ArgumentNullException("reader");
                }

                _indexID = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_ID_NAME);
                _indexMacroID = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_MACRO_ID_NAME);
                _indexActionType = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_TYPE_NAME);
                _indexScreenHeight = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_HEIGHT_NAME);
                _indexScreenWidth = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_SCREEN_WIDTH_NAME);
                _indexPositionX = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_X_NAME);
                _indexPositionY = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_POSITION_Y_NAME);
                _indexActionDelay = reader.GetOrdinal(SQLiteDataContract.MacroAssemblyActions.COLUMN_ACTION_DELAY_NAME);
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
