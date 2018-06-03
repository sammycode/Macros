namespace VF.Macros.Client.Controls
{
    partial class MacroActionEditorControl
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
            this.DuplicateActionButton = new System.Windows.Forms.Button();
            this.RemoveActionButton = new System.Windows.Forms.Button();
            this.KnownPositionComboBox = new System.Windows.Forms.ComboBox();
            this.label10 = new System.Windows.Forms.Label();
            this.ActionDelayTextbox = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.TapXTextBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.TapYTextbox = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.ScreenWidthTextbox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ScreenHeightTextBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // DuplicateActionButton
            // 
            this.DuplicateActionButton.Location = new System.Drawing.Point(507, 64);
            this.DuplicateActionButton.Name = "DuplicateActionButton";
            this.DuplicateActionButton.Size = new System.Drawing.Size(75, 23);
            this.DuplicateActionButton.TabIndex = 37;
            this.DuplicateActionButton.Text = "Duplicate";
            this.DuplicateActionButton.UseVisualStyleBackColor = true;
            this.DuplicateActionButton.Click += new System.EventHandler(this.HandleDuplicateActionClick);
            // 
            // RemoveActionButton
            // 
            this.RemoveActionButton.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.RemoveActionButton.Location = new System.Drawing.Point(563, 4);
            this.RemoveActionButton.Name = "RemoveActionButton";
            this.RemoveActionButton.Size = new System.Drawing.Size(19, 23);
            this.RemoveActionButton.TabIndex = 36;
            this.RemoveActionButton.Text = "X";
            this.RemoveActionButton.UseVisualStyleBackColor = true;
            this.RemoveActionButton.Click += new System.EventHandler(this.HandleRemoveActionClick);
            // 
            // KnownPositionComboBox
            // 
            this.KnownPositionComboBox.FormattingEnabled = true;
            this.KnownPositionComboBox.Location = new System.Drawing.Point(357, 35);
            this.KnownPositionComboBox.Name = "KnownPositionComboBox";
            this.KnownPositionComboBox.Size = new System.Drawing.Size(137, 22);
            this.KnownPositionComboBox.TabIndex = 35;
            this.KnownPositionComboBox.TabStop = false;
            this.KnownPositionComboBox.SelectedIndexChanged += new System.EventHandler(this.HandleKnownPositionIndexChanged);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(354, 14);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(97, 15);
            this.label10.TabIndex = 34;
            this.label10.Text = "Known Positions";
            // 
            // ActionDelayTextbox
            // 
            this.ActionDelayTextbox.Location = new System.Drawing.Point(206, 64);
            this.ActionDelayTextbox.Name = "ActionDelayTextbox";
            this.ActionDelayTextbox.Size = new System.Drawing.Size(44, 22);
            this.ActionDelayTextbox.TabIndex = 33;
            this.ActionDelayTextbox.Text = "0";
            this.ActionDelayTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(257, 67);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(23, 14);
            this.label8.TabIndex = 32;
            this.label8.Text = "ms";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(8, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 15);
            this.label9.TabIndex = 31;
            this.label9.Text = "Action Delay";
            // 
            // TapXTextBox
            // 
            this.TapXTextBox.Location = new System.Drawing.Point(304, 35);
            this.TapXTextBox.Name = "TapXTextBox";
            this.TapXTextBox.Size = new System.Drawing.Size(44, 22);
            this.TapXTextBox.TabIndex = 30;
            this.TapXTextBox.Text = "0";
            this.TapXTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(256, 38);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(13, 14);
            this.label5.TabIndex = 29;
            this.label5.Text = "X";
            // 
            // TapYTextbox
            // 
            this.TapYTextbox.Location = new System.Drawing.Point(206, 35);
            this.TapYTextbox.Name = "TapYTextbox";
            this.TapYTextbox.Size = new System.Drawing.Size(44, 22);
            this.TapYTextbox.TabIndex = 28;
            this.TapYTextbox.Text = "0";
            this.TapYTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(158, 38);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(13, 14);
            this.label6.TabIndex = 27;
            this.label6.Text = "Y";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(8, 38);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 15);
            this.label7.TabIndex = 26;
            this.label7.Text = "Tap Position";
            // 
            // ScreenWidthTextbox
            // 
            this.ScreenWidthTextbox.Location = new System.Drawing.Point(304, 6);
            this.ScreenWidthTextbox.Name = "ScreenWidthTextbox";
            this.ScreenWidthTextbox.ReadOnly = true;
            this.ScreenWidthTextbox.Size = new System.Drawing.Size(44, 22);
            this.ScreenWidthTextbox.TabIndex = 25;
            this.ScreenWidthTextbox.Text = "1280";
            this.ScreenWidthTextbox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(256, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(40, 14);
            this.label4.TabIndex = 24;
            this.label4.Text = "Width";
            // 
            // ScreenHeightTextBox
            // 
            this.ScreenHeightTextBox.Location = new System.Drawing.Point(206, 6);
            this.ScreenHeightTextBox.Name = "ScreenHeightTextBox";
            this.ScreenHeightTextBox.ReadOnly = true;
            this.ScreenHeightTextBox.Size = new System.Drawing.Size(44, 22);
            this.ScreenHeightTextBox.TabIndex = 23;
            this.ScreenHeightTextBox.Text = "1280";
            this.ScreenHeightTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(158, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 14);
            this.label3.TabIndex = 22;
            this.label3.Text = "Height";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(105, 15);
            this.label2.TabIndex = 21;
            this.label2.Text = "Screen Resolution";
            // 
            // MacroActionEditorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.DuplicateActionButton);
            this.Controls.Add(this.RemoveActionButton);
            this.Controls.Add(this.KnownPositionComboBox);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.ActionDelayTextbox);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.TapXTextBox);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.TapYTextbox);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.ScreenWidthTextbox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.ScreenHeightTextBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MacroActionEditorControl";
            this.Size = new System.Drawing.Size(591, 91);
            this.Load += new System.EventHandler(this.HandleControlLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button DuplicateActionButton;
        private System.Windows.Forms.Button RemoveActionButton;
        private System.Windows.Forms.ComboBox KnownPositionComboBox;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox ActionDelayTextbox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox TapXTextBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox TapYTextbox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox ScreenWidthTextbox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox ScreenHeightTextBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
    }
}
