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
