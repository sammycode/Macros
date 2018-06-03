namespace VF.Macros.Client.Forms
{
    partial class MainFormOld
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            
            // 
            // MenuStrip
            // 
            this.MenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.MenuStrip.Location = new System.Drawing.Point(0, 0);
            this.MenuStrip.Name = "MenuStrip";
            this.MenuStrip.Size = new System.Drawing.Size(784, 24);
            this.MenuStrip.TabIndex = 0;
            this.MenuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.importMacrosToolStripMenuItem,
            this.exportMacrosToolStripMenuItem,
            this.toolStripMenuItem1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // importMacrosToolStripMenuItem
            // 
            this.importMacrosToolStripMenuItem.Name = "importMacrosToolStripMenuItem";
            this.importMacrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.importMacrosToolStripMenuItem.Text = "Import Macros";
            this.importMacrosToolStripMenuItem.Click += new System.EventHandler(this.HandleFileImportMacrosMenuClick);
            // 
            // exportMacrosToolStripMenuItem
            // 
            this.exportMacrosToolStripMenuItem.Name = "exportMacrosToolStripMenuItem";
            this.exportMacrosToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exportMacrosToolStripMenuItem.Text = "Export Macros";
            this.exportMacrosToolStripMenuItem.Click += new System.EventHandler(this.HandleFileExportMacrosMenuClick);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(177, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.HandleFileExitMenuClick);
            // 
            // StatusStrip
            // 
            this.StatusStrip.Location = new System.Drawing.Point(0, 539);
            this.StatusStrip.Name = "StatusStrip";
            this.StatusStrip.Size = new System.Drawing.Size(784, 22);
            this.StatusStrip.TabIndex = 1;
            this.StatusStrip.Text = "statusStrip1";
            // 
            // NavigatePanel
            // 
            this.NavigatePanel.Controls.Add(this.NavigationTreeView);
            this.NavigatePanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.NavigatePanel.Location = new System.Drawing.Point(0, 24);
            this.NavigatePanel.MaximumSize = new System.Drawing.Size(300, 0);
            this.NavigatePanel.MinimumSize = new System.Drawing.Size(100, 0);
            this.NavigatePanel.Name = "NavigatePanel";
            this.NavigatePanel.Size = new System.Drawing.Size(300, 515);
            this.NavigatePanel.TabIndex = 2;
            // 
            // NavigationTreeView
            // 
            this.NavigationTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.NavigationTreeView.Location = new System.Drawing.Point(0, 0);
            this.NavigationTreeView.Margin = new System.Windows.Forms.Padding(5);
            this.NavigationTreeView.Name = "NavigationTreeView";
            this.NavigationTreeView.Size = new System.Drawing.Size(300, 515);
            this.NavigationTreeView.TabIndex = 0;
            this.NavigationTreeView.LabelSelected += new System.Action<object, VF.Macros.Client.Controls.LabelEventArgs>(this.HandleLabelSelected);
            this.NavigationTreeView.AllMacrosSelected += new System.Action<object, System.EventArgs>(this.HandleAllMacrosSelected);
            // 
            // NavigationPaneSplitter
            // 
            this.NavigationPaneSplitter.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.NavigationPaneSplitter.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NavigationPaneSplitter.Location = new System.Drawing.Point(300, 24);
            this.NavigationPaneSplitter.Name = "NavigationPaneSplitter";
            this.NavigationPaneSplitter.Size = new System.Drawing.Size(3, 515);
            this.NavigationPaneSplitter.TabIndex = 3;
            this.NavigationPaneSplitter.TabStop = false;
            // 
            // ContentPanel
            // 
            this.ContentPanel.Controls.Add(this.MacrosListView);
            this.ContentPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ContentPanel.Location = new System.Drawing.Point(303, 24);
            this.ContentPanel.Name = "ContentPanel";
            this.ContentPanel.Size = new System.Drawing.Size(481, 515);
            this.ContentPanel.TabIndex = 4;
            // 
            // MacrosListView
            // 
            this.MacrosListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MacrosListView.Location = new System.Drawing.Point(0, 0);
            this.MacrosListView.Margin = new System.Windows.Forms.Padding(5);
            this.MacrosListView.Name = "MacrosListView";
            this.MacrosListView.Size = new System.Drawing.Size(481, 515);
            this.MacrosListView.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.ContentPanel);
            this.Controls.Add(this.NavigationPaneSplitter);
            this.Controls.Add(this.NavigatePanel);
            this.Controls.Add(this.StatusStrip);
            this.Controls.Add(this.MenuStrip);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MainMenuStrip = this.MenuStrip;
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MainForm";
            this.Text = "Macros!";
            this.MenuStrip.ResumeLayout(false);
            this.MenuStrip.PerformLayout();
            this.NavigatePanel.ResumeLayout(false);
            this.ContentPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip MenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.StatusStrip StatusStrip;
        private System.Windows.Forms.Panel NavigatePanel;
        private System.Windows.Forms.Splitter NavigationPaneSplitter;
        private System.Windows.Forms.Panel ContentPanel;
        private Controls.NavigationTreeView NavigationTreeView;
        private Controls.MacrosListView MacrosListView;
        private System.Windows.Forms.ToolStripMenuItem importMacrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exportMacrosToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
    }
}