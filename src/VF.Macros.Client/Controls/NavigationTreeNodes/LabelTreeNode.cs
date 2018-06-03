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
