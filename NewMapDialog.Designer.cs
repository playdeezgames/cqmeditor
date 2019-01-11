namespace CQMEditor
{
    partial class NewMapDialog
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
            this.widthLabel = new System.Windows.Forms.Label();
            this.heightLabel = new System.Windows.Forms.Label();
            this.fillValue = new System.Windows.Forms.Label();
            this.widthComboBox = new System.Windows.Forms.ComboBox();
            this.heightComboBox = new System.Windows.Forms.ComboBox();
            this.fillComboBox = new System.Windows.Forms.ComboBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // widthLabel
            // 
            this.widthLabel.AutoSize = true;
            this.widthLabel.Location = new System.Drawing.Point(12, 15);
            this.widthLabel.Name = "widthLabel";
            this.widthLabel.Size = new System.Drawing.Size(38, 13);
            this.widthLabel.TabIndex = 0;
            this.widthLabel.Text = "Width:";
            // 
            // heightLabel
            // 
            this.heightLabel.AutoSize = true;
            this.heightLabel.Location = new System.Drawing.Point(12, 42);
            this.heightLabel.Name = "heightLabel";
            this.heightLabel.Size = new System.Drawing.Size(41, 13);
            this.heightLabel.TabIndex = 1;
            this.heightLabel.Text = "Height:";
            // 
            // fillValue
            // 
            this.fillValue.AutoSize = true;
            this.fillValue.Location = new System.Drawing.Point(12, 69);
            this.fillValue.Name = "fillValue";
            this.fillValue.Size = new System.Drawing.Size(22, 13);
            this.fillValue.TabIndex = 2;
            this.fillValue.Text = "Fill:";
            // 
            // widthComboBox
            // 
            this.widthComboBox.FormattingEnabled = true;
            this.widthComboBox.Location = new System.Drawing.Point(59, 12);
            this.widthComboBox.Name = "widthComboBox";
            this.widthComboBox.Size = new System.Drawing.Size(108, 21);
            this.widthComboBox.TabIndex = 3;
            // 
            // heightComboBox
            // 
            this.heightComboBox.FormattingEnabled = true;
            this.heightComboBox.Location = new System.Drawing.Point(59, 39);
            this.heightComboBox.Name = "heightComboBox";
            this.heightComboBox.Size = new System.Drawing.Size(108, 21);
            this.heightComboBox.TabIndex = 4;
            // 
            // fillComboBox
            // 
            this.fillComboBox.FormattingEnabled = true;
            this.fillComboBox.Location = new System.Drawing.Point(59, 66);
            this.fillComboBox.Name = "fillComboBox";
            this.fillComboBox.Size = new System.Drawing.Size(108, 21);
            this.fillComboBox.TabIndex = 5;
            // 
            // okButton
            // 
            this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.okButton.Location = new System.Drawing.Point(12, 93);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 6;
            this.okButton.Text = "&Ok";
            this.okButton.UseVisualStyleBackColor = true;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(93, 93);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 7;
            this.cancelButton.Text = "&Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            // 
            // NewMapDialog
            // 
            this.AcceptButton = this.okButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(179, 130);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.fillComboBox);
            this.Controls.Add(this.heightComboBox);
            this.Controls.Add(this.widthComboBox);
            this.Controls.Add(this.fillValue);
            this.Controls.Add(this.heightLabel);
            this.Controls.Add(this.widthLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewMapDialog";
            this.Text = "Specify Size";
            this.Load += new System.EventHandler(this.NewMapDialog_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label widthLabel;
        private System.Windows.Forms.Label heightLabel;
        private System.Windows.Forms.Label fillValue;
        private System.Windows.Forms.ComboBox widthComboBox;
        private System.Windows.Forms.ComboBox heightComboBox;
        private System.Windows.Forms.ComboBox fillComboBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
    }
}