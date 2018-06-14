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

namespace VF.Macros.Service
{

    /// <summary>
    /// The Label Management Service Contract
    /// </summary>
    public interface ILabelManagementService
    {

        /// <summary>
        /// Get All Labels
        /// </summary>
        /// <returns>The Labels</returns>
        IEnumerable<DataContract.Metadata.Label> GetAllLabels();

        /// <summary>
        /// Get Top Level Labels
        /// </summary>
        /// <returns>The Top Level Labels</returns>
        IEnumerable<DataContract.Metadata.Label> GetTopLevelLabels();

        /// <summary>
        /// Get Child Labels
        /// </summary>
        /// <param name="parentLabel">The Parent Label</param>
        /// <returns>The Labels</returns>
        IEnumerable<DataContract.Metadata.Label> GetChildLabels(DataContract.Metadata.Label parentLabel);

        /// <summary>
        /// Create Label
        /// </summary>
        /// <param name="label">The Label</param>
        DataContract.Metadata.Label CreateLabel(DataContract.Metadata.Label label);

        /// <summary>
        /// Update Label
        /// </summary>
        /// <param name="label">The Label</param>
        void UpdateLabel(DataContract.Metadata.Label label);

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="label">The Label</param>
        void DeleteLabel(DataContract.Metadata.Label label);

    }
}
