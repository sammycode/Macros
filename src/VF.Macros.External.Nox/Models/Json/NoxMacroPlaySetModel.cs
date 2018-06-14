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

namespace VF.Macros.External.Nox.Models.Json
{

    /// <summary>
    /// The Nox Macro PlaySet Model
    /// </summary>
    internal class NoxMacroPlaySetModel
    {

        /// <summary>
        /// The Acceleration
        /// </summary>
        public string accelerator { get; set; }

        /// <summary>
        /// The Loop Interval
        /// </summary>
        public string interval { get; set; }

        /// <summary>
        /// The Play/Mode
        /// </summary>
        /// <remarks>
        /// I'm not really using this yet.  But I think in nox this is the 
        /// radio button, where it can be set to loop X times,
        /// Loop until stop button is pressed
        /// or Loop for a time duration
        /// 
        /// The subsequent fields appear to be related to that.
        /// </remarks>
        public string mode { get; set; }

        /// <summary>
        /// The Play Seconds
        /// </summary>
        public string playSeconds { get; set; }

        /// <summary>
        /// The Repeat Times
        /// </summary>
        public string repeatTimes { get; set; }

    }

}
