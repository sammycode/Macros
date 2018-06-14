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
using System.Windows.Forms;

using log4net;

using DataContract = VF.Macros.Common.Models;

namespace VF.Macros.Client.Controls.NavigationTreeNodes
{

    /// <summary>
    /// The Label TreeNode
    /// </summary>
    public class LabelTreeNode : TreeNode
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(LabelTreeNode));

        /// <summary>
        /// The Bound Label
        /// </summary>
        public DataContract.Metadata.Label BoundLabel { get; private set; }

        /// <summary>
        /// The Label TreeNode
        /// </summary>
        public LabelTreeNode()
        {
            try
            {
                ImageIndex = 1;
                SelectedImageIndex = 1;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Label TreeNode", caught);
                throw;
            }
        }

        /// <summary>
        /// Initialize Label TreeNode
        /// </summary>
        /// <param name="label">The Label</param>
        public LabelTreeNode(DataContract.Metadata.Label label) : this()
        {
            try
            {
                BoundLabel = label ?? throw new ArgumentNullException("label");
                Text = BoundLabel.Name;
                Name = Convert.ToString(BoundLabel.ID);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Label TreeNode", caught);
                throw;
            }
        }

    }
}
