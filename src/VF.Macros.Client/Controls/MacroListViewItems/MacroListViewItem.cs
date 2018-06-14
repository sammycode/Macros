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

namespace VF.Macros.Client.Controls.MacroListViewItems
{

    /// <summary>
    /// The Macro ListView Items
    /// </summary>
    public class MacroListViewItem : ListViewItem
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MacroListViewItem));

        /// <summary>
        /// The Bound Macro
        /// </summary>
        public DataContract.Macro.Macro BoundMacro { get; private set; }

        /// <summary>
        /// Initialize Macro ListViewItem
        /// </summary>
        public MacroListViewItem()
        {
            try
            {
                ImageIndex = 0;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macro ListViewItem", caught);
                throw;
            }
        }

        /// <summary>
        /// Initialize Macro ListViewItem
        /// </summary>
        /// <param name="macro">The Macro</param>
        public MacroListViewItem(DataContract.Macro.Macro macro) : this()
        {
            try
            {
                BoundMacro = macro;
                RefreshMacroInformation();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializingt Macro ListViewItem", caught);
                throw;
            }
        }

        /// <summary>
        /// Refresh Macro Information
        /// </summary>
        public void RefreshMacroInformation()
        {
            try
            {
                Text = BoundMacro.Name;

                //TODO: Get back to this after structure
                //SubItems.AddRange(new[] {
                //    BoundMacro.ExternalProvider,
                //    BoundMacro.Enabled ? "Enabled" : "Disabled"
                //});
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Refreshing Macro Information", caught);
                throw;
            }
        }

    }
}
