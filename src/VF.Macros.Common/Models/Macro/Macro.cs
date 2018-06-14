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

namespace VF.Macros.Common.Models.Macro
{

    /// <summary>
    /// The Macro Data Contract
    /// </summary>
    public class Macro
    {

        /// <summary>
        /// The Macro ID
        /// </summary>
        /// <remarks>
        /// I think the Macro Identifier is going to be super important now that
        /// the primary way of keying them will no longer be by the 'Qualified Name', 
        /// which was specific to the external provider
        /// </remarks>
        public long ID { get; set; }

        /// <summary>
        /// The Label
        /// </summary>
        public Metadata.Label Label { get; set; }

        /// <summary>
        /// The Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        public int ListOrder { get; set; }

        /// <summary>
        /// The Enabled Flag
        /// </summary>
        public bool Enabled { get; set; }

        /// <summary>
        /// The External Sources
        /// </summary>
        public List<MacroExternalSource> ExternalSources { get; set; }

        /// <summary>
        /// The Macro Assembly
        /// </summary>
        public List<Action> Assembly { get; set; }

        /// <summary>
        /// Initialize Macro Data Contract
        /// </summary>
        public Macro()
        {
            ExternalSources = new List<MacroExternalSource>();
            Assembly = new List<Action>();
        }

    }
}
