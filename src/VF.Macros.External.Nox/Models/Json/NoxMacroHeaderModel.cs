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
    /// The Nox Macro Header Model
    /// </summary>
    internal class NoxMacroHeaderModel
    {

        /// <summary>
        /// The Macro Name
        /// </summary>
        public string name { get; set; }

        /// <summary>
        /// New Macro
        /// </summary>
        public string New { get; set; }

        /// <summary>
        /// The PlaySet Configuration
        /// </summary>
        public NoxMacroPlaySetModel playSet { get; set; }

        /// <summary>
        /// The Priority
        /// </summary>
        /// <remarks>
        /// This appears to map to the order it appears in the list
        /// </remarks>
        public string priority { get; set; }

        /// <summary>
        /// The Create Date/Time (This is stored in epoch)
        /// </summary>
        public string time { get; set; }

    }

}
