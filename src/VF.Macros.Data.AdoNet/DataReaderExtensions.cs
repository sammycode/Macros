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

namespace VF.Macros.Data.AdoNet
{

    /// <summary>
    /// Common Data Reader Extension Methods
    /// </summary>
    /// <remarks>
    /// This is just a bucket to add common things, like translating DBNulls to CLR null values,
    /// and implicitly handling nullable columns without making a big deal about it where readers are used...
    /// </remarks>
    public static class DataReaderExtensions
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(DataReaderExtensions));

        /// <summary>
        /// Get Nullable Long Value
        /// </summary>
        /// <param name="reader">The Data Reader</param>
        /// <param name="columnIndex">The Column Index</param>
        /// <returns>The Long Value, or Null</returns>
        public static long? GetNullableLong(this IDataReader reader, int columnIndex)
        {
            try
            {
                if (reader == null)
                {
                    throw new ArgumentNullException("reader");
                }

                var returnValue = reader.IsDBNull(columnIndex) ? null as long? : reader.GetInt64(columnIndex);
                return returnValue;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Getting Nullable Long Value", caught);
                throw;
            }
        }

    }
}
