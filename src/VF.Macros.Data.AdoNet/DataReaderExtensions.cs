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
