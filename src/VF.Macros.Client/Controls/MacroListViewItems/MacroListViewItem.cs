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
