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

using VF.Macros.Data.Entity;

namespace VF.Macros.Data.Repositories
{
    /// <summary>
    /// The Label Data Repository
    /// </summary>
    public interface ILabelDataRepository
    {

        /// <summary>
        /// Get All Labels
        /// </summary>
        /// <returns>The Labels</returns>
        IEnumerable<ILabel> GetAllLabels();

        /// <summary>
        /// Get Top Level Labels
        /// </summary>
        /// <returns>The Labels</returns>
        IEnumerable<ILabel> GetTopLevelLabels();

        /// <summary>
        /// Get Child Labels
        /// </summary>
        /// <param name="parentID">The Parent Label ID</param>
        /// <returns>The Labels</returns>
        IEnumerable<ILabel> GetChildLabels(long parentID);

        /// <summary>
        /// Get Label by ID
        /// </summary>
        /// <param name="id">The LabelID</param>
        /// <returns>The Label</returns>
        IEnumerable<ILabel> GetLabelByID(long id);

        /// <summary>
        /// Create Label
        /// </summary>
        /// <param name="parentID">The Parent Label ID *NULL FOR TOP LEVEL LABEL*</param>
        /// <param name="name">The Label Name</param>
        ILabel CreateLabel(long? parentID, string name);

        /// <summary>
        /// Update Label
        /// </summary>
        /// <param name="label">The Label</param>
        void UpdateLabel(ILabel label);

        /// <summary>
        /// Delete Label
        /// </summary>
        /// <param name="label">The Label</param>
        void DeleteLabel(ILabel label);

    }
}
