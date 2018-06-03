namespace VF.Macros.Client.Controls
{
    partial class NavigationTreeView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NavigationTreeView));
            this.TreeView = new System.Windows.Forms.TreeView();
            this.ContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.createLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.modifyLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteLabelToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.createMacroToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TreeViewImageList = new System.Windows.Forms.ImageList(this.components);
            this.ContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // TreeView
            // 
            this.TreeView.ContextMenuStrip = this.ContextMenu;
            this.TreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeView.HideSelection = false;
            this.TreeView.ImageIndex = 0;
            this.TreeView.ImageList = this.TreeViewImageList;
            this.TreeView.Location = new System.Drawing.Point(0, 0);
            this.TreeView.Name = "TreeView";
            this.TreeView.SelectedImageIndex = 0;
            this.TreeView.Size = new System.Drawing.Size(200, 400);
            this.TreeView.TabIndex = 0;
            this.TreeView.BeforeExpand += new System.Windows.Forms.TreeViewCancelEventHandler(this.HandleTreeViewBeforeExpand);
            this.TreeView.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.HandleTreeViewBeforeSelect);
            this.TreeView.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.HandleTreeVewAfterSelect);
            // 
            // ContextMenu
            // 
            this.ContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createLabelToolStripMenuItem,
            this.toolStripMenuItem1,
            this.modifyLabelToolStripMenuItem,
            this.deleteLabelToolStripMenuItem,
            this.toolStripMenuItem2,
            this.createMacroToolStripMenuItem});
            this.ContextMenu.Name = "ContextMenu";
            this.ContextMenu.Size = new System.Drawing.Size(146, 104);
            // 
            // createLabelToolStripMenuItem
            // 
            this.createLabelToolStripMenuItem.Name = "createLabelToolStripMenuItem";
            this.createLabelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.createLabelToolStripMenuItem.Text = "Create Label";
            this.createLabelToolStripMenuItem.Click += new System.EventHandler(this.HandleCreateLabelContextMenuClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(142, 6);
            // 
            // modifyLabelToolStripMenuItem
            // 
            this.modifyLabelToolStripMenuItem.Name = "modifyLabelToolStripMenuItem";
            this.modifyLabelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.modifyLabelToolStripMenuItem.Text = "Modify Label";
            this.modifyLabelToolStripMenuItem.Click += new System.EventHandler(this.HandleModifyLabelContextMenuClick);
            // 
            // deleteLabelToolStripMenuItem
            // 
            this.deleteLabelToolStripMenuItem.Name = "deleteLabelToolStripMenuItem";
            this.deleteLabelToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.deleteLabelToolStripMenuItem.Text = "Delete Label";
            this.deleteLabelToolStripMenuItem.Click += new System.EventHandler(this.HandleDeleteLabelContextMenuClick);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(142, 6);
            // 
            // createMacroToolStripMenuItem
            // 
            this.createMacroToolStripMenuItem.Name = "createMacroToolStripMenuItem";
            this.createMacroToolStripMenuItem.Size = new System.Drawing.Size(145, 22);
            this.createMacroToolStripMenuItem.Text = "Create Macro";
            this.createMacroToolStripMenuItem.Click += new System.EventHandler(this.HandleCreateMacroContextMenuClick);
            // 
            // TreeViewImageList
            // 
            this.TreeViewImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("TreeViewImageList.ImageStream")));
            this.TreeViewImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.TreeViewImageList.Images.SetKeyName(0, "folder.png");
            this.TreeViewImageList.Images.SetKeyName(1, "tag.png");
            this.TreeViewImageList.Images.SetKeyName(2, "macro.png");
            // 
            // NavigationTreeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.TreeView);
            this.Name = "NavigationTreeView";
            this.Size = new System.Drawing.Size(200, 400);
            this.Load += new System.EventHandler(this.HandleControlLoad);
            this.ContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView TreeView;
        private System.Windows.Forms.ImageList TreeViewImageList;
        private System.Windows.Forms.ContextMenuStrip ContextMenu;
        private System.Windows.Forms.ToolStripMenuItem createLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modifyLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteLabelToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem createMacroToolStripMenuItem;
    }
}
