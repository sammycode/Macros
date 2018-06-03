using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using log4net;

namespace VF.Macros.Common.Utility
{

    /// <summary>
    /// The Date Utility 
    /// </summary>
    public static class DateUtility
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(DateUtility));

        /// <summary>
        /// Convert Epoch to DateTime
        /// </summary>
        /// <param name="epoch">The Epoch</param>
        /// <returns>The DateTime</returns>
        public static DateTime EpochToDate(double epoch)
        {
            try
            {
                var dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(epoch);
                return dateTime.ToLocalTime();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Converting Epoch to DateTime", caught);
                throw;
            }
        }

        /// <summary>
        /// Convert DateTime to Epoch
        /// </summary>
        /// <param name="date">The DateTime</param>
        /// <returns>The Epoch</returns>
        public static double DateToEpoch(DateTime date)
        {
            try
            {
                var epoch = (date.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
                return epoch;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Converting DateTime to Epoch", caught);
                throw;
            }
        }

    }
}
