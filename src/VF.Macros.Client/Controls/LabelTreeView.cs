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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using log4net;

using Model = VF.Macros.Common.Models;
using VF.Macros.Service;

namespace VF.Macros.Client.Controls
{

    /// <summary>
    /// The Label TreeView
    /// </summary>
    /// <remarks>
    /// This is a simplified control, which will render just labels, and 
    /// will allow the container form or control to view which label is selected. 
    /// or emit a null if no label is selected
    /// </remarks>
    public partial class LabelTreeView : UserControl
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(LabelTreeView));

        /// <summary>
        /// The Selected Label
        /// </summary>
        public Model.Metadata.Label SelectedLabel { get; private set; }

        /// <summary>
        /// Initialize Label TreeView
        /// </summary>
        public LabelTreeView()
        {
            try
            {
                InitializeComponent();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Label TreeView", caught);
                throw;
            }
        }
    }
}
