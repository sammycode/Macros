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
    /// The Navigation TreeView
    /// </summary>
    public partial class NavigationTreeView : UserControl
    {

        /// <summary>
        /// The Logger
        /// </summary>
        private static readonly ILog logger = LogManager.GetLogger(typeof(NavigationTreeView));

        /// <summary>
        /// The Label Management Service
        /// </summary>
        private ILabelManagementService _labelManagementService;

        /// <summary>
        /// The Macro Management Service
        /// </summary>
        private IMacroManagementService _macroManagementService;

        /// <summary>
        /// The External Integration Service
        /// </summary>
        private IExternalIntegrationService _externalIntegrationService;

        /// <summary>
        /// The Root Labels TreeNode
        /// </summary>
        private NavigationTreeNodes.RootSectionTreeNode _rootLabelsTreeNode;

        /// <summary>
        /// The Root All Macros TreeNode
        /// </summary>
        private NavigationTreeNodes.RootSectionTreeNode _rootAllMacrosTreeNode;

        /// <summary>
        /// The Label Selected Event
        /// </summary>
        public event Action<object, LabelEventArgs> LabelSelected;

        /// <summary>
        /// All Macros Selected
        /// </summary>
        public event Action<object, EventArgs> AllMacrosSelected;

        /// <summary>
        /// Leaving the default constructor, but making it less accessable,
        /// I think the designer might get cranky at me if I dont....
        /// </summary>
        protected NavigationTreeView() { InitializeComponent(); }

        /// <summary>
        /// Initialize Navigation TreeView
        /// </summary>
        /// <param name="labelManagementService">Injected Label Management Service</param>
        /// <param name="macroManagementService">Injected Macro Management Service</param>
        /// <param name="externalIntegrationService">Injected External Integration Service</param>
        public NavigationTreeView(ILabelManagementService labelManagementService, IMacroManagementService macroManagementService,
            IExternalIntegrationService externalIntegrationService)
        {
            try
            {
                InitializeComponent();
                _labelManagementService = labelManagementService;
                _macroManagementService = macroManagementService;
                _externalIntegrationService = externalIntegrationService;
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Initializing Navigation TreeView", caught);
                throw;
            }
        }

        #region [Fill Helpers]

        /// <summary>
        /// Clear TreeView
        /// </summary>
        private void ClearTreeView()
        {
            try
            {
                _rootLabelsTreeNode.Nodes.Clear();
                _rootAllMacrosTreeNode.Nodes.Clear();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Clearing TreeView", caught);
                throw;
            }
        }

        /// <summary>
        /// Refresh Top Level TreeView
        /// </summary>
        private void RefreshTopLevelTreeView()
        {
            try
            {
                RefreshRootLabelNode();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Refreshing Top Level TreeView", caught);
                throw;
            }
        }

        /// <summary>
        /// Refresh Root LabelNode
        /// </summary>
        private void RefreshRootLabelNode()
        {
            try
            {
                TreeView.SuspendLayout();

                _rootLabelsTreeNode.Nodes.Clear();
                var topLevelLabels = _labelManagementService.GetTopLevelLabels();
                foreach (var label in topLevelLabels)
                {
                    var labelTreeNode = new NavigationTreeNodes.LabelTreeNode(label);
                    _rootLabelsTreeNode.Nodes.Add(labelTreeNode);
                    PrefetchChildTreeNodes(labelTreeNode);
                }
                _rootLabelsTreeNode.Expand();

                TreeView.ResumeLayout();
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Refreshing Root LabelNode", caught);
                throw;
            }
        }

        /// <summary>
        /// Remove Deleted Child TreeNodes
        /// </summary>
        /// <param name="parentNode">The Parent TreeNode</param>
        /// <remarks>
        /// If a label has been deleted, we want to remove it from the tree node,
        /// and have it as little akward as possible.
        /// To do this, rather than clear the tree nodes as we refresh them, I'm taking more of a merge appraoch.
        /// So this will allow us to remove nodes we no longer need, without having the navigation bounce around,
        /// collapse etc.
        /// </remarks>
        private void RemoveDeletedChildTreeNodes(NavigationTreeNodes.LabelTreeNode parentNode)
        {
            try
            {
                /*
                 * Checking for null here, because if the cast wont work, eg an incompatible node is selected, this should
                 * exit pretty gracefully
                 */
                if (parentNode == null)
                {
                    return;
                }
                var pulledChildLabels = _labelManagementService.GetChildLabels(parentNode.BoundLabel);
                var keysToRemove = new List<string>();
                var nodeEnumerator = parentNode.Nodes.GetEnumerator();
                while (nodeEnumerator.MoveNext())
                {
                    var currentNode = nodeEnumerator.Current as TreeNode;
                    if (!pulledChildLabels.Any(l => Convert.ToString(l.ID) == currentNode.Name))
                    {
                        keysToRemove.Add(currentNode.Name);
                    }
                }
                foreach (var key in keysToRemove)
                {
                    parentNode.Nodes.RemoveByKey(key);
                }

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Removing Deleted Child TreeNodes", caught);
                throw;
            }
        }

        /// <summary>
        /// Prefetch Child Treenodes
        /// </summary>
        /// <param name="parentNode">The Parent Label TreeNode</param>
        private void PrefetchChildTreeNodes(NavigationTreeNodes.LabelTreeNode parentNode)
        {
            try
            {
                /*
                 * Checking for null here, because if the cast wont work, eg an incompatible node is selected, this should
                 * exit pretty gracefully
                 */
                if (parentNode == null)
                {
                    return;
                }

                TreeView.SuspendLayout();

                //parentNode.Nodes.Clear();
                var pulledChildLabels = _labelManagementService.GetChildLabels(parentNode.BoundLabel);
                foreach (var childLabel in pulledChildLabels)
                {

                    NavigationTreeNodes.LabelTreeNode labelTreeNode = null;
                    if (parentNode.Nodes.ContainsKey(Convert.ToString(childLabel.ID)))
                    {
                        labelTreeNode = parentNode.Nodes[Convert.ToString(childLabel.ID)] as NavigationTreeNodes.LabelTreeNode;
                    }
                    else
                    {
                        labelTreeNode = new NavigationTreeNodes.LabelTreeNode(childLabel);
                        parentNode.Nodes.Add(labelTreeNode);
                    }

                    //Testing this out, doing a very explicit pull of the secondary label level
                    var secondLevelChildLabels = _labelManagementService.GetChildLabels(labelTreeNode.BoundLabel);
                    foreach (var secondChildLevel in secondLevelChildLabels)
                    {
                        if (!labelTreeNode.Nodes.ContainsKey(Convert.ToString(secondChildLevel.ID)))
                        {
                            var secondLevelTreeNode = new NavigationTreeNodes.LabelTreeNode(secondChildLevel);
                            labelTreeNode.Nodes.Add(secondLevelTreeNode);
                        }
                    }
                }

                TreeView.ResumeLayout();

                //TODO: Implement Label to Macro Join Table, and supporting service interfaces

                //TODO: OK, we need to create a macro list view for the right side pane.  Then we can trigger an event or something to have that know to fill.

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Prefetching Child TreeNodes", caught);
                throw;
            }
        }

        /// <summary>
        /// Attach Child Label to TreeNode
        /// </summary>
        /// <param name="parentNode">The Parent TreeNode</param>
        /// <param name="label">The Child Label</param>
        private void AttachChildLabelToNode(TreeNode parentNode, DataContract.Metadata.Label label)
        {
            try
            {
                if (parentNode == null)
                {
                    throw new ArgumentNullException("parentNode");
                }
                if (label == null)
                {
                    throw new ArgumentNullException("label");
                }

                var newChildLabelNode = new NavigationTreeNodes.LabelTreeNode(label);
                parentNode.Nodes.Add(newChildLabelNode);
                TreeView.SelectedNode = newChildLabelNode;

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Attaching Child Label to TreeNode", caught);
                throw;
            }
        }

        #endregion

        #region [TreeView Event Handlers]

        /// <summary>
        /// Handles TreeView Before Select
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleTreeViewBeforeSelect(object sender, TreeViewCancelEventArgs e)
        {

        }

        /// <summary>
        /// Handles TreeView After Select
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        /// <remarks>
        /// This is almost there, I guess we only want to do this once, and then after which, maybe force it by a double click?
        /// 
        /// it might make sense to only allow a refresh using a context menu function
        /// 
        /// </remarks>
        private void HandleTreeVewAfterSelect(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Node == _rootAllMacrosTreeNode)
                {
                    OnAllMacrosSelected(this, new EventArgs());
                    return;
                }
                if (e.Node is NavigationTreeNodes.LabelTreeNode node)
                {
                    RemoveDeletedChildTreeNodes(e.Node as NavigationTreeNodes.LabelTreeNode);
                    PrefetchChildTreeNodes(e.Node as NavigationTreeNodes.LabelTreeNode);
                    OnLabelSelected(this, new LabelEventArgs { Label = node.BoundLabel });
                    return;
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling TreeView BeforeSelect", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles TreeView Before Expand
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleTreeViewBeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            try
            {
                var node = e.Node as NavigationTreeNodes.LabelTreeNode;
                if (node != null)
                {
                    RemoveDeletedChildTreeNodes(e.Node as NavigationTreeNodes.LabelTreeNode);
                    PrefetchChildTreeNodes(e.Node as NavigationTreeNodes.LabelTreeNode);
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling TreeView BeforeExpand", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Control Load
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleControlLoad(object sender, EventArgs e)
        {
            try
            {

                //_labelManagementService = IoC.GetComponent<ILabelManagementService>();
                //_macroManagementService = IoC.GetComponent<IMacroManagementService>();

                _rootLabelsTreeNode = new NavigationTreeNodes.RootSectionTreeNode { Text = "Categorized Macros" };
                _rootAllMacrosTreeNode = new NavigationTreeNodes.RootSectionTreeNode { Text = "All Macros" };
                //TODO: Add Macros Which are Not Yet Categorized
                TreeView.Nodes.Add(_rootLabelsTreeNode);
                TreeView.Nodes.Add(_rootAllMacrosTreeNode);

                RefreshTopLevelTreeView();

            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Control Load", caught);
                throw;
            }
        }

        #endregion

        #region [Events Implementation]

        /// <summary>
        /// Submit Label Selected Event
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        protected virtual void OnLabelSelected(object sender, LabelEventArgs args)
        {
            try
            {
                LabelSelected?.Invoke(sender, args);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Submitting Label Selected Event", caught);
                throw;
            }
        }

        /// <summary>
        /// Submit All Macros Selected Event
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="args">The Event Arguments</param>
        protected virtual void OnAllMacrosSelected(object sender, EventArgs args)
        {
            try
            {
                AllMacrosSelected?.Invoke(sender, args);
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Submitting All Macros Selected Event", caught);
                throw;
            }
        }

        #endregion

        #region [Context Menu Event Handlers]

        /// <summary>
        /// Handles Context->Create Label MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleCreateLabelContextMenuClick(object sender, EventArgs e)
        {
            try
            {
                //Just exit if the selected node is null
                if (TreeView.SelectedNode == null)
                {
                    return;
                }
                using (var editLabelForm = new Forms.EditLabelForm())
                {
                    //Make sure to set the parent id of the new label, to the id of the selected node.
                    //If we arent on a label, we can assume this is a top-level label
                    if (TreeView.SelectedNode.GetType() == typeof(NavigationTreeNodes.LabelTreeNode))
                    {
                        editLabelForm.BoundLabel.ParentID = (TreeView.SelectedNode as NavigationTreeNodes.LabelTreeNode).BoundLabel.ID;
                    }
                    if (editLabelForm.ShowDialog() == DialogResult.OK)
                    {
                        var label = _labelManagementService.CreateLabel(editLabelForm.BoundLabel);
                        AttachChildLabelToNode(TreeView.SelectedNode, label);
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handlign Create Label ContextMenu Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handles Context->Modify Label MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleModifyLabelContextMenuClick(object sender, EventArgs e)
        {
            try
            {
                /*
                 * I think if anything, we might have to be careful that the label is removed from here,
                 * and then re-attached to the parent label, and if the Parent Label ID is null, it should be attached
                 * to the rood node for that
                 */

                //Just exit if the selected node is null
                if (TreeView.SelectedNode == null)
                {
                    return;
                }

                // We are only interested in editing Labels
                if (TreeView.SelectedNode.GetType() == typeof(NavigationTreeNodes.LabelTreeNode)) {
                    var labelToEdit = (TreeView.SelectedNode as NavigationTreeNodes.LabelTreeNode).BoundLabel;
                    
                    long? originalParent = labelToEdit.ParentID == null ? null as long? : labelToEdit.ParentID.Value;
                    using (var editLabelForm = new Forms.EditLabelForm(labelToEdit))
                    {
                        if (editLabelForm.ShowDialog() == DialogResult.OK)
                        {
                            _labelManagementService.UpdateLabel(editLabelForm.BoundLabel);
                            if (originalParent != editLabelForm.BoundLabel.ParentID)
                            {
                                // Remove the Label from it's current position if the parent changed
                                TreeView.Nodes.RemoveByKey(labelToEdit.Name);

                                //Add it to the correct parent
                                if (editLabelForm.BoundLabel.ParentID == null)
                                {
                                    _rootLabelsTreeNode.Nodes.Add(new NavigationTreeNodes.LabelTreeNode(editLabelForm.BoundLabel));
                                }
                                else
                                {
                                    var newParentNode = TreeView.Nodes[editLabelForm.BoundLabel.ParentID.ToString()];
                                    newParentNode.Nodes.Add(new NavigationTreeNodes.LabelTreeNode(editLabelForm.BoundLabel));
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error handling Modify Label ContextMenu Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Context->Delete Label MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleDeleteLabelContextMenuClick(object sender, EventArgs e)
        {
            try
            {
                //We can only delete label nodes
                if (TreeView.SelectedNode == null || TreeView.SelectedNode.GetType() != typeof(NavigationTreeNodes.LabelTreeNode))
                {
                    return;
                }
                var labelToDelete = ((NavigationTreeNodes.LabelTreeNode)TreeView.SelectedNode).BoundLabel;
                var result = MessageBox.Show($"Are you sure you would like to delete the {labelToDelete.Name} label?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
                if (result == DialogResult.Yes)
                {
                    //TODO: Delete Label
                }
            }
            catch (Exception caught)
            {
                logger.Error("Unexpected Error Handling Delete Label ContextMenu Click", caught);
                throw;
            }
        }

        /// <summary>
        /// Handle Context->Create Macro Context MenuClick
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Arguments</param>
        private void HandleCreateMacroContextMenuClick(object sender, EventArgs e)
        {
            //TODO: do this right, this is just here for testing purposes
            var createMacroForm = new Forms.MacroEditorForm(_externalIntegrationService);
            createMacroForm.ShowDialog();
        }

        #endregion

    }
}
