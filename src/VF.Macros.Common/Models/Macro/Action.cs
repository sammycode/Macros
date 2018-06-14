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

namespace VF.Macros.Common.Models.Macro
{

    /// <summary>
    /// The Action Data Contract
    /// </summary>
    public class Action
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(Action));

        /// <summary>
        /// The Action Type
        /// </summary>
        public ActionType ActionType { get; set; }

        /// <summary>
        /// The Screen Resolution
        /// </summary>
        public Dimensions ScreenResolution { get; set; }

        /// <summary>
        /// The Screen Position
        /// </summary>
        public Dimensions ScreenPosition { get; set; }

        /// <summary>
        /// The Action Delay
        /// </summary>
        public int ActionDelay { get; set; }

        /// <summary>
        /// Initialize Action Data Contract
        /// </summary>
        public Action()
        {
            try
            {
                ActionType = ActionType.Screen;
                ScreenResolution = new Dimensions { X = 720, Y = 1280 };
                ScreenPosition = new Dimensions { X = 0, Y = 0 };
                ActionDelay = 1;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Action", caught);
                throw;
            }
        }

    }
}
