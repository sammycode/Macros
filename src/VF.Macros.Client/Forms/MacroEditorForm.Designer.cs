namespace VF.Macros.Client.Forms
{
    partial class MacroEditorForm
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
            this.EnabledCheckbox = new System.Windows.Forms.CheckBox();
            this.SortOrderUpDown = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.NameTextbox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.EditorTabControl = new System.Windows.Forms.TabControl();
            this.macroDesignerTabPage = new System.Windows.Forms.TabPage();
            this.MacroActionsFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.AddMacroActionButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.macroSourceTabPage = new System.Windows.Forms.TabPage();
            this.MacroSourceTextbox = new System.Windows.Forms.TextBox();
            this.ProviderSelectionPanel = new System.Windows.Forms.Panel();
            this.ExternalProviderCombobox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ErrorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.SortOrderUpDown)).BeginInit();
            this.EditorTabControl.SuspendLayout();
            this.macroDesignerTabPage.SuspendLayout();
            this.macroSourceTabPage.SuspendLayout();
            this.ProviderSelectionPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // EnabledCheckbox
            // 
            this.EnabledCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.EnabledCheckbox.AutoSize = true;
            this.EnabledCheckbox.Checked = true;
            this.EnabledCheckbox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.EnabledCheckbox.Location = new System.Drawing.Point(720, 10);
            this.EnabledCheckbox.Name = "EnabledCheckbox";
            this.EnabledCheckbox.Size = new System.Drawing.Size(90, 27);
            this.EnabledCheckbox.TabIndex = 9;
            this.EnabledCheckbox.Text = "Enabled";
            this.EnabledCheckbox.UseVisualStyleBackColor = true;
            // 
            // SortOrderUpDown
            // 
            this.SortOrderUpDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SortOrderUpDown.Location = new System.Drawing.Point(640, 7);
            this.SortOrderUpDown.Name = "SortOrderUpDown";
            this.SortOrderUpDown.Size = new System.Drawing.Size(61, 31);
            this.SortOrderUpDown.TabIndex = 8;
            this.SortOrderUpDown.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(560, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 23);
            this.label2.TabIndex = 7;
            this.label2.Text = "Order";
            // 
            // NameTextbox
            // 
            this.NameTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.NameTextbox.Location = new System.Drawing.Point(133, 6);
            this.NameTextbox.Margin = new System.Windows.Forms.Padding(5);
            this.NameTextbox.Name = "NameTextbox";
            this.NameTextbox.Size = new System.Drawing.Size(393, 31);
            this.NameTextbox.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(14, 9);
            this.label1.Margin = new System.Windows.Forms.Padding(5, 0, 5, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 23);
            this.label1.TabIndex = 5;
            this.label1.Text = "Macro Name";
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.CancelButton.Location = new System.Drawing.Point(597, 503);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(103, 43);
            this.CancelButton.TabIndex = 10;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.HandleCancelClick);
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.OKButton.Location = new System.Drawing.Point(706, 503);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(103, 43);
            this.OKButton.TabIndex = 11;
            this.OKButton.Text = "OK";
            this.OKButton.UseVisualStyleBackColor = true;
            this.OKButton.Click += new System.EventHandler(this.HandleOKClick);
            // 
            // EditorTabControl
            // 
            this.EditorTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.EditorTabControl.Controls.Add(this.macroDesignerTabPage);
            this.EditorTabControl.Controls.Add(this.macroSourceTabPage);
            this.EditorTabControl.Location = new System.Drawing.Point(12, 45);
            this.EditorTabControl.Name = "EditorTabControl";
            this.EditorTabControl.SelectedIndex = 0;
            this.EditorTabControl.Size = new System.Drawing.Size(798, 452);
            this.EditorTabControl.TabIndex = 12;
            this.EditorTabControl.SelectedIndexChanged += new System.EventHandler(this.HandleTabIndexChanged);
            // 
            // macroDesignerTabPage
            // 
            this.macroDesignerTabPage.Controls.Add(this.MacroActionsFlowPanel);
            this.macroDesignerTabPage.Controls.Add(this.AddMacroActionButton);
            this.macroDesignerTabPage.Controls.Add(this.label3);
            this.macroDesignerTabPage.Location = new System.Drawing.Point(4, 32);
            this.macroDesignerTabPage.Name = "macroDesignerTabPage";
            this.macroDesignerTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.macroDesignerTabPage.Size = new System.Drawing.Size(790, 416);
            this.macroDesignerTabPage.TabIndex = 1;
            this.macroDesignerTabPage.Tag = "DESIGN";
            this.macroDesignerTabPage.Text = "Designer";
            this.macroDesignerTabPage.UseVisualStyleBackColor = true;
            // 
            // MacroActionsFlowPanel
            // 
            this.MacroActionsFlowPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.MacroActionsFlowPanel.AutoScroll = true;
            this.MacroActionsFlowPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.MacroActionsFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.MacroActionsFlowPanel.Location = new System.Drawing.Point(10, 29);
            this.MacroActionsFlowPanel.Name = "MacroActionsFlowPanel";
            this.MacroActionsFlowPanel.Size = new System.Drawing.Size(675, 381);
            this.MacroActionsFlowPanel.TabIndex = 2;
            this.MacroActionsFlowPanel.WrapContents = false;
            // 
            // AddMacroActionButton
            // 
            this.AddMacroActionButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.AddMacroActionButton.Location = new System.Drawing.Point(691, 29);
            this.AddMacroActionButton.Name = "AddMacroActionButton";
            this.AddMacroActionButton.Size = new System.Drawing.Size(88, 40);
            this.AddMacroActionButton.TabIndex = 1;
            this.AddMacroActionButton.Text = "Add";
            this.AddMacroActionButton.UseVisualStyleBackColor = true;
            this.AddMacroActionButton.Click += new System.EventHandler(this.HandleAddActionClick);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 3);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 23);
            this.label3.TabIndex = 0;
            this.label3.Text = "Actions";
            // 
            // macroSourceTabPage
            // 
            this.macroSourceTabPage.Controls.Add(this.MacroSourceTextbox);
            this.macroSourceTabPage.Controls.Add(this.ProviderSelectionPanel);
            this.macroSourceTabPage.Location = new System.Drawing.Point(4, 32);
            this.macroSourceTabPage.Name = "macroSourceTabPage";
            this.macroSourceTabPage.Padding = new System.Windows.Forms.Padding(3);
            this.macroSourceTabPage.Size = new System.Drawing.Size(790, 416);
            this.macroSourceTabPage.TabIndex = 0;
            this.macroSourceTabPage.Tag = "SOURCE";
            this.macroSourceTabPage.Text = "Source";
            this.macroSourceTabPage.UseVisualStyleBackColor = true;
            // 
            // MacroSourceTextbox
            // 
            this.MacroSourceTextbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MacroSourceTextbox.Location = new System.Drawing.Point(3, 37);
            this.MacroSourceTextbox.Multiline = true;
            this.MacroSourceTextbox.Name = "MacroSourceTextbox";
            this.MacroSourceTextbox.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.MacroSourceTextbox.Size = new System.Drawing.Size(784, 376);
            this.MacroSourceTextbox.TabIndex = 0;
            // 
            // ProviderSelectionPanel
            // 
            this.ProviderSelectionPanel.Controls.Add(this.ExternalProviderCombobox);
            this.ProviderSelectionPanel.Controls.Add(this.label4);
            this.ProviderSelectionPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.ProviderSelectionPanel.Location = new System.Drawing.Point(3, 3);
            this.ProviderSelectionPanel.Name = "ProviderSelectionPanel";
            this.ProviderSelectionPanel.Size = new System.Drawing.Size(784, 34);
            this.ProviderSelectionPanel.TabIndex = 1;
            // 
            // ExternalProviderCombobox
            // 
            this.ExternalProviderCombobox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ExternalProviderCombobox.FormattingEnabled = true;
            this.ExternalProviderCombobox.Items.AddRange(new object[] {
            "Nox"});
            this.ExternalProviderCombobox.Location = new System.Drawing.Point(154, 0);
            this.ExternalProviderCombobox.Name = "ExternalProviderCombobox";
            this.ExternalProviderCombobox.Size = new System.Drawing.Size(630, 31);
            this.ExternalProviderCombobox.TabIndex = 1;
            // 
            // label4
            // 
            this.label4.Dock = System.Windows.Forms.DockStyle.Left;
            this.label4.Location = new System.Drawing.Point(0, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(154, 34);
            this.label4.TabIndex = 0;
            this.label4.Text = "External Provider";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ErrorProvider
            // 
            this.ErrorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.ErrorProvider.ContainerControl = this;
            // 
            // MacroEditorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(821, 558);
            this.Controls.Add(this.EditorTabControl);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.EnabledCheckbox);
            this.Controls.Add(this.SortOrderUpDown);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.NameTextbox);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MinimumSize = new System.Drawing.Size(600, 400);
            this.Name = "MacroEditorForm";
            this.Text = "MacroEditorForm";
            this.Load += new System.EventHandler(this.HandleFormLoad);
            this.ResizeBegin += new System.EventHandler(this.HandleResizeBegin);
            this.ResizeEnd += new System.EventHandler(this.HandleResizeEnd);
            ((System.ComponentModel.ISupportInitialize)(this.SortOrderUpDown)).EndInit();
            this.EditorTabControl.ResumeLayout(false);
            this.macroDesignerTabPage.ResumeLayout(false);
            this.macroDesignerTabPage.PerformLayout();
            this.macroSourceTabPage.ResumeLayout(false);
            this.macroSourceTabPage.PerformLayout();
            this.ProviderSelectionPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ErrorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox EnabledCheckbox;
        private System.Windows.Forms.NumericUpDown SortOrderUpDown;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox NameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TabControl EditorTabControl;
        private System.Windows.Forms.TabPage macroDesignerTabPage;
        private System.Windows.Forms.FlowLayoutPanel MacroActionsFlowPanel;
        private System.Windows.Forms.Button AddMacroActionButton;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage macroSourceTabPage;
        private System.Windows.Forms.TextBox MacroSourceTextbox;
        private System.Windows.Forms.Panel ProviderSelectionPanel;
        private System.Windows.Forms.ComboBox ExternalProviderCombobox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ErrorProvider ErrorProvider;
    }
}