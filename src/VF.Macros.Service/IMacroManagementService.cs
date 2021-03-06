﻿/*
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

using Models = VF.Macros.Common.Models;

namespace VF.Macros.Service
{

    /// <summary>
    /// The Macro Management Service Contract
    /// </summary>
    public interface IMacroManagementService
    {

        /// <summary>
        /// Gets All Macros
        /// </summary>
        /// <returns>The Macros</returns>
        IEnumerable<Models.Macro.Macro> GetAllMacros();

        /// <summary>
        /// Gets Macro by Qualified Name
        /// </summary>
        /// <param name="provider">The Provider</param>
        /// <param name="qualifiedName">The Macro Qualfiied Name</param>
        /// <returns>The Macro</returns>
        IEnumerable<Models.Macro.Macro> GetMacroByQualifiedName(Models.Metadata.ExternalProvider provider, string qualifiedName);

        /// <summary>
        /// Get Macros by Label
        /// </summary>
        /// <param name="label">The Label</param>
        /// <returns></returns>
        IEnumerable<Models.Macro.Macro> GetMacrosByLabel(Models.Metadata.Label label);

        /// <summary>
        /// Create Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <remarks>The Created Macro</remarks>
        Models.Macro.Macro CreateMacro(Models.Macro.Macro macro);

        /// <summary>
        /// Update Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        void UpdateMacro(Models.Macro.Macro macro);

        /// <summary>
        /// Delete Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        void DeleteMacro(Models.Macro.Macro macro);

    }
}
