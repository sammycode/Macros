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
    /// The Macro External Source
    /// </summary>
    public class MacroExternalSource
    {

        /// <summary>
        /// The Macro External Source Identifier
        /// </summary>
        public long ID { get; set; }

        /// <summary>
        /// The Macro Header
        /// </summary>
        public Macro Macro { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The Qualified Name
        /// </summary>
        public string QualifiedName { get; set; }

        /// <summary>
        /// The External Provider
        /// </summary>
        public Metadata.ExternalProvider Provider { get; set; }

        /// <summary>
        /// The Macro Source
        /// </summary>
        public string MacroSource { get; set; }
        
        /// <summary>
        /// Is the Designer Supported?
        /// </summary>
        public bool DesignerSupported { get; set; }

        /// <summary>
        /// The Accelerator
        /// </summary>
        public string Accelerator { get; set; }

        /// <summary>
        /// The Interval
        /// </summary>
        public string Interval { get; set; }

        /// <summary>
        /// The Mode
        /// </summary>
        public string Mode { get; set; }

        /// <summary>
        /// The Play Seconds
        /// </summary>
        public string PlaySeconds { get; set; }

        /// <summary>
        /// The Repeat Times
        /// </summary>
        public string RepeatTimes { get; set; }

    }
}
