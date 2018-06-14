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

namespace VF.Macros.Common.Models.Metadata
{

    /// <summary>
    /// The Label Data Contract
    /// </summary>
    public class Label
    {

        /// <summary>
        /// The Label Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Parent Label Identifier (Null for top level label)
        /// </summary>
        public long? ParentID { get; set; }

        /// <summary>
        /// The Label Name
        /// </summary>
        public string Name { get; set; }

    }
}
