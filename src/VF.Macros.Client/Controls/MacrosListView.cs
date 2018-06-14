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
using Ninject;

using DataContract = VF.Macros.Common.Models;
using VF.Macros.Service;

namespace VF.Macros.Client.Controls
{

    /// <summary>
    /// The Macros ListView
    /// </summary>
    /// <remarks>
    /// This control will work a little bit differently than the listview, it will have to have it's data refreshes 
    /// requested by the container form.
    /// </remarks>
    public partial class MacrosListView : UserControl
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MacrosListView));

        /// <summary>
        /// The Macro Management Service
        /// </summary>
        private IMacroManagementService _macroManagementService;

        /// <summary>
        /// Leaving the Default constructor, to keep the designer happy, I think this is needed
        /// </summary>
        protected MacrosListView() { InitializeComponent(); }

        /// <summary>
        /// Initialize Macros ListView
        /// </summary>
        /// <param name="macroManagementService">Injected MacroManagement Service</param>
        public MacrosListView(IMacroManagementService macroManagementService)
        {
            try
            {
                InitializeComponent();
                _macroManagementService = macroManagementService;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macros ListView", caught);
                throw;
            }
        }

        #region [Fill Helpers]

        /// <summary>
        /// Refresh for All Macros
        /// </summary>
        public void RefreshMacros()
        {
            try
            {

                ListView.SuspendLayout();

                var allMacros = _macroManagementService.GetAllMacros();
                ListView.Items.Clear();
                foreach (var macro in allMacros)
                {
                    var macroListItem = new MacroListViewItems.MacroListViewItem(macro);
                    ListView.Items.Add(macroListItem);
                }

                ListView.ResumeLayout();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Refreshing All Macros", caught);
                throw;
            }
        }

        /// <summary>
        /// Refresh Macros For A Particular Label
        /// </summary>
        /// <param name="label">The Label</param>
        public void RefreshMacros(DataContract.Metadata.Label label)
        {
            try
            {
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                ListView.SuspendLayout();
                var macrosByLabel = _macroManagementService.GetMacrosByLabel(label);
                ListView.Items.Clear();
                
                foreach (var macro in macrosByLabel)
                {
                    var macroListItem = new MacroListViewItems.MacroListViewItem(macro);
                    ListView.Items.Add(macroListItem);
                }

                ListView.ResumeLayout();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Refreshing Macros For Label", caught);
                throw;
            }
        }

        #endregion

        #region [Event Handlers]

        /// <summary>
        /// Handle Control Load
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleControlLoad(object sender, EventArgs e)
        {
            try
            {
                //_macroManagementService = IoC.GetComponent<IMacroManagementService>();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Control Load", caught);
                throw;
            }
        }

        #endregion

    }
}
