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
    /// The Macro TreeNode
    /// </summary>
    public class MacroTreeNode : TreeNode
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(MacroTreeNode));

        /// <summary>
        /// The Macro TreeNode
        /// </summary>
        public MacroTreeNode()
        {
            try
            {
                ImageIndex = 2;
                SelectedImageIndex = 2;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Macro TreeNode", caught);
                throw;
            }
        }

    }
}
