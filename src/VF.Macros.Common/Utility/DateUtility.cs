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
