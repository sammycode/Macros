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

namespace VF.Macros.Client.Controls.NavigationTreeNodes
{

    /// <summary>
    /// The Root Section TreeNode
    /// </summary>
    public class RootSectionTreeNode : TreeNode
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(RootSectionTreeNode));

        /// <summary>
        /// Initialize Root Section TreeNode
        /// </summary>
        public RootSectionTreeNode()
        {
            try
            {
                ImageIndex = 0;
                SelectedImageIndex = 0;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing RootSection TreeNode", caught);
                throw;

            }
        }

    }
}
