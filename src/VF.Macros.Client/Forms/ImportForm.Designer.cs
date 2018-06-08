namespace VF.Macros.Client.Forms
{
    partial class ImportForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ImportForm));
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.ExternalProvidersComboBox = new System.Windows.Forms.ComboBox();
            this.ImportButton = new System.Windows.Forms.Button();
            this.ImportedMacrosListView = new System.Windows.Forms.ListView();
            this.FriendlyNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ExternalProviderColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QualifiedNameColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CreateDateColumn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ImportedMacrosImageList = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(551, 505);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(103, 43);
            this.CancelButton.TabIndex = 12;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.HandleCancelClick);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(660, 505);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(103, 43);
            this.OKButton.TabIndex = 13;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.HandleOKClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(142, 23);
            this.label1.TabIndex = 14;
            this.label1.Text = "External Provider";
            // 
            // ExternalProvidersComboBox
            // 
            this.ExternalProvidersComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ExternalProvidersComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ExternalProvidersComboBox.FormattingEnabled = true;
            this.ExternalProvidersComboBox.Location = new System.Drawing.Point(163, 19);
            this.ExternalProvidersComboBox.Name = "ExternalProvidersComboBox";
            this.ExternalProvidersComboBox.Size = new System.Drawing.Size(483, 31);
            this.ExternalProvidersComboBox.TabIndex = 15;
            // 
            // ImportButton
            // 
            this.ImportButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportButton.Location = new System.Drawing.Point(660, 12);
            this.ImportButton.Name = "ImportButton";
            this.ImportButton.Size = new System.Drawing.Size(103, 43);
            this.ImportButton.TabIndex = 16;
            this.ImportButton.Text = "Import";
            this.ImportButton.UseVisualStyleBackColor = true;
            this.ImportButton.Click += new System.EventHandler(this.HandleImportClick);
            // 
            // ImportedMacrosListView
            // 
            this.ImportedMacrosListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ImportedMacrosListView.CheckBoxes = true;
            this.ImportedMacrosListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.FriendlyNameColumn,
            this.ExternalProviderColumn,
            this.QualifiedNameColumn,
            this.CreateDateColumn});
            this.ImportedMacrosListView.FullRowSelect = true;
            this.ImportedMacrosListView.HideSelection = false;
            this.ImportedMacrosListView.LargeImageList = this.ImportedMacrosImageList;
            this.ImportedMacrosListView.Location = new System.Drawing.Point(19, 94);
            this.ImportedMacrosListView.Name = "ImportedMacrosListView";
            this.ImportedMacrosListView.Size = new System.Drawing.Size(744, 405);
            this.ImportedMacrosListView.SmallImageList = this.ImportedMacrosImageList;
            this.ImportedMacrosListView.TabIndex = 17;
            this.ImportedMacrosListView.UseCompatibleStateImageBehavior = false;
            this.ImportedMacrosListView.View = System.Windows.Forms.View.Details;
            // 
            // FriendlyNameColumn
            // 
            this.FriendlyNameColumn.Text = "Name";
            this.FriendlyNameColumn.Width = 200;
            // 
            // ExternalProviderColumn
            // 
            this.ExternalProviderColumn.Text = "Provider";
            this.ExternalProviderColumn.Width = 120;
            // 
            // QualifiedNameColumn
            // 
            this.QualifiedNameColumn.Text = "Qualified Name";
            this.QualifiedNameColumn.Width = 200;
            // 
            // CreateDateColumn
            // 
            this.CreateDateColumn.Text = "Created";
            this.CreateDateColumn.Width = 125;
            // 
            // ImportedMacrosImageList
            // 
            this.ImportedMacrosImageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ImportedMacrosImageList.ImageStream")));
            this.ImportedMacrosImageList.TransparentColor = System.Drawing.Color.Transparent;
            this.ImportedMacrosImageList.Images.SetKeyName(0, "macro.png");
            // 
            // ImportForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(775, 560);
            this.Controls.Add(this.ImportedMacrosListView);
            this.Controls.Add(this.ImportButton);
            this.Controls.Add(this.ExternalProvidersComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "ImportForm";
            this.Text = "Import Macros";
            this.Load += new System.EventHandler(this.HandleFormLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ExternalProvidersComboBox;
        private System.Windows.Forms.Button ImportButton;
        private System.Windows.Forms.ListView ImportedMacrosListView;
        private System.Windows.Forms.ColumnHeader ExternalProviderColumn;
        private System.Windows.Forms.ColumnHeader FriendlyNameColumn;
        private System.Windows.Forms.ColumnHeader QualifiedNameColumn;
        private System.Windows.Forms.ColumnHeader CreateDateColumn;
        private System.Windows.Forms.ImageList ImportedMacrosImageList;
    }
}