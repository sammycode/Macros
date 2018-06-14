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

namespace VF.Macros.Data.Entity
{

    /// <summary>
    /// The Macro Contract
    /// </summary>
    /// <remarks>
    /// For the time being, not sure what to do with the time,
    /// this is stamped in Nox as Time, and in Memu a timestamp is used to mark the qualified name
    /// for a particular macro.
    /// So, I'll capture it, but it's notable that in Memu, it might be undesirable to actually ever
    /// modify it.  I guess maybe we never will need to really modify it...
    /// </remarks>
    public interface IMacro
    {

        /// <summary>
        /// The Macro Identifier
        /// </summary>
        long ID { get; set; }

        /// <summary>
        /// The Label ID
        /// </summary>
        long? LabelID { get; set; }

        /// <summary>
        /// The is a Friendly Name for the Macro
        /// </summary>
        string Name { get; set; }

        /// <summary>
        /// The List Order
        /// </summary>
        /// <remarks>
        /// For Nox, this is the Priority Field
        /// For Memu, I believe this is the order in which it appears in the INI file
        /// </remarks>
        int ListOrder { get; set; }

        /// <summary>
        /// The Create Date
        /// </summary>
        /// <remarks>
        /// In Nox, this is an epoch timestamp.
        /// In memu this is dirived from the Qualified Macro Name. *Might end up with some special handling there*
        /// </remarks>
        DateTime CreateDate { get; set; }

        /// <summary>
        /// Macro Enabled
        /// </summary>
        bool Enabled { get; set; }

    }
}
