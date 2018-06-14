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

using VF.Macros.External.Models;

namespace VF.Macros.External.Nox.Models
{

    /// <summary>
    /// The Nox External Macro Model Implementation
    /// </summary>
    public class NoxExternalMacroModelImpl : IExternalMacroModel
    {

        /// <summary>
        /// The Qualified Name
        /// </summary>
        public string QualifiedName { get; set; }

        /// <summary>
        /// The Friendly Name
        /// </summary>
        public string FriendlyName { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        public int ListOrder { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        public DateTime CreateDate { get; set; }

        /// <summary>
        /// The Source FileName
        /// </summary>
        public string SourceFileName { get; set; }

        /// <summary>
        /// The Macro Source
        /// </summary>
        public string MacroSource { get; set; }

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

        /// <summary>
        /// Assembler Supported
        /// </summary>
        public bool AssemblerSupported { get; set; }
    }
}
