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

using VF.Macros.Data.Entity;

namespace VF.Macros.Data.Repositories
{

    /// <summary>
    /// The Macro Data Respository
    /// </summary>
    public interface IMacroDataRepository
    {

        #region [Macro Headers]

        /// <summary>
        /// Gets All Macros
        /// </summary>
        /// <returns>The Macros</returns>
        IEnumerable<IMacro> GetAllMacros();

        /// <summary>
        /// Gets Macro By ID
        /// </summary>
        /// <param name="macroID">The Macro ID</param>
        /// <returns>The Macro</returns>
        IEnumerable<IMacro> GetMacroByID(long macroID);

        /// <summary>
        /// Gets Macro by Qualified Name
        /// </summary>
        /// <param name="providerCode">The External Provider Code</param>
        /// <param name="qualifiedName">The Qualified Name</param>
        /// <returns>The Macro</returns>
        IEnumerable<IMacro> GetMacroByQualifiedName(string providerCode, string qualifiedName);

        /// <summary>
        /// Get Macros By LabelID
        /// </summary>
        /// <param name="labelID">The LabelID</param>
        /// <returns></returns>
        IEnumerable<IMacro> GetMacrosByLabelID(long? labelID);

        /// <summary>
        /// Create Macro
        /// </summary>
        /// <param name="labelID">The Label ID</param>
        /// <param name="name">The Macro Name</param>
        /// <param name="listOrder">The List Order</param>
        /// <param name="createDate">The Create Date</param>
        /// <param name="enabled">Is Macro Enabled</param>
        IMacro CreateMacro(
            long? labelID, 
            string name, 
            int listOrder, 
            DateTime createDate, 
            bool enabled);

        /// <summary>
        /// Update Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        void UpdateMacro(IMacro macro);

        /// <summary>
        /// Delete Macro
        /// </summary>
        /// <param name="macro">The Macro</param>
        void DeleteMacro(IMacro macro);

        #endregion

        #region [Macro Source]

        /// <summary>
        /// Gets External Macro Source
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <returns>The External Macro Source</returns>
        IEnumerable<IExternalMacroSource> GetExternalMacroSource(IMacro macro);

        /// <summary>
        /// Gets External Macro Source by ID
        /// </summary>
        /// <param name="id">The External Macro Source ID</param>
        /// <returns>The External Macro Source</returns>
        IEnumerable<IExternalMacroSource> GetExternalMacroSourceByID(long id);

        /// <summary>
        /// Creates Macro Source
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <param name="createDate">The Create Date</param>
        /// <param name="externalSourceCode">The External Source Code</param>
        /// <param name="acceleratorName">The Accelerator</param>
        /// <param name="interval">The Interval</param>
        /// <param name="mode">The Mode</param>
        /// <param name="playSeconds">The Play Seconds</param>
        /// <param name="playTimes">The PLay Times</param>
        /// <param name="source">The Macro Source</param>
        /// <remarks>The External Macro Source</remarks>
        IExternalMacroSource CreateExternalMacroSource(IMacro macro, DateTime createDate, string externalSourceCode, string acceleratorName, string interval, string mode, string playSeconds, string playTimes, string source);

        /// <summary>
        /// Updates External Macro Source
        /// </summary>
        /// <param name="externalMacroSource">The External Macro Source</param>
        void UpdateExternalMacroSource(IExternalMacroSource externalMacroSource);

        /// <summary>
        /// Deletes External Macro Source
        /// </summary>
        /// <param name="externalMacroSource">The External Macro Source</param>
        void DeleteExternalMacroSource(IExternalMacroSource externalMacroSource);

        #endregion

        #region [Macro Assembly]

        /// <summary>
        /// Get Macro Assembly
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <returns>The Macro Assembly</returns>
        IEnumerable<IMacroAssemblyAction> GetMacroAssembly(IMacro macro);

        /// <summary>
        /// Get Macro Assembly Action
        /// </summary>
        /// <param name="id">The Macro Assembly Action Identifier</param>
        /// <returns>The Macro Assmbly Action</returns>
        IMacroAssemblyAction GetMacroAssemblyAction(long id);

        /// <summary>
        /// Create Macro Assembly Action
        /// </summary>
        /// <param name="macro">The Macro</param>
        /// <param name="actionType">The Action Type</param>
        /// <param name="screenHeight">The Screen Height</param>
        /// <param name="screenWidth">The Screen Width</param>
        /// <param name="positionX">The X Position</param>
        /// <param name="positionY">The Y Position</param>
        /// <param name="actionDelay">The Action Delay</param>
        /// <returns>The Macro Assembly Action</returns>
        IMacroAssemblyAction CreateMacroAssemblyAction(IMacro macro, int actionType, int screenHeight, int screenWidth, int positionX, int positionY, int actionDelay);

        /// <summary>
        /// Update Macro Assembly Action
        /// </summary>
        /// <param name="assemblyAction">The Macro Assembly Action</param>
        void UpdateMacroAssemblyAction(IMacroAssemblyAction assemblyAction);

        /// <summary>
        /// Delete Macro Assembly Action
        /// </summary>
        /// <param name="assemblyAction">The Macro Assembly Action</param>
        void DeleteMacroAssemblyAction(IMacroAssemblyAction assemblyAction);

        #endregion

    }
}
