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

using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.External
{

    /// <summary>
    /// The Macro Assembler Contract
    /// </summary>
    public interface IMacroAssembler
    {

        /// <summary>
        /// Build Macro from Source
        /// </summary>
        /// <param name="source">The Macro Source</param>
        /// <returns>The Macro Assembly</returns>
        IEnumerable<DataContract.Macro.Action> Build(string source);

        /// <summary>
        /// Disassemble Macro to Source
        /// </summary>
        /// <param name="assembly">The Macro Assembly</param>
        /// <returns>The Macro Source</returns>
        string Disassemble(IEnumerable<DataContract.Macro.Action> assembly);

    }
}
