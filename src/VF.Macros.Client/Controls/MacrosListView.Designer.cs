namespace VF.Macros.Client.Controls
{
    partial class MacrosListView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MacrosListView));
            this.ListView = new System.Windows.Forms.ListView();
            this.macroNameColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExternalProviderColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.StatusColumnHeader = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // ListView
            // 
            this.ListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.macroNameColumnHeader,
            this.ExternalProviderColumnHeader,
            this.StatusColumnHeader});
            this.ListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ListView.FullRowSelect = true;
            this.ListView.HideSelection = false;
            this.ListView.Location = new System.Drawing.Point(0, 0);
            this.ListView.Name = "ListView";
            this.ListView.Size = new System.Drawing.Size(600, 400);
            this.ListView.SmallImageList = this.ImageList;
            this.ListView.TabIndex = 0;
            this.ListView.UseCompatibleStateImageBehavior = false;
            this.ListView.View = System.Windows.Forms.View.Details;
            // 
            // macroNameColumnHeader
            // 
            this.macroNameColumnHeader.Text = "Name";
            this.macroNameColumnHeader.Width = 200;
            // 
            // ExternalProviderColumnHeader
            // 
            this.ExternalProviderColumnHeader.Text = "Provider";
            this.ExternalProviderColumnHeader.Width = 100;
            // 
            // StatusColumnHeader
            // 
            this.StatusColumnHeader.Text = "Status";
            this.StatusColumnHeader.Width = 100;
            // 
            // ImageList
            // 
            this.ImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImageList.ImageStream")));
            this.ImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImageList.Images.SetKeyName(0, "macro.png");
            // 
            // MacrosListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ListView);
            this.Name = "MacrosListView";
            this.Size = new System.Drawing.Size(600, 400);
            this.Load += new System.EventHandler(this.HandleControlLoad);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView ListView;
        private System.Windows.Forms.ColumnHeader macroNameColumnHeader;
        private System.Windows.Forms.ColumnHeader ExternalProviderColumnHeader;
        private System.Windows.Forms.ColumnHeader StatusColumnHeader;
        private System.Windows.Forms.ImageList ImageList;
    }
}
