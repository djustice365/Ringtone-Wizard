namespace RingtoneWizard
{
    partial class OptionsPane
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.deletePointButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.xText = new System.Windows.Forms.TextBox();
            this.yText = new System.Windows.Forms.TextBox();
            this.xLabel = new System.Windows.Forms.Label();
            this.yLabel = new System.Windows.Forms.Label();
            this.saveButton = new System.Windows.Forms.Button();
            this.cancelEditButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cancelButton);
            this.panel1.Controls.Add(this.cancelEditButton);
            this.panel1.Controls.Add(this.saveButton);
            this.panel1.Controls.Add(this.yLabel);
            this.panel1.Controls.Add(this.xLabel);
            this.panel1.Controls.Add(this.yText);
            this.panel1.Controls.Add(this.xText);
            this.panel1.Controls.Add(this.editButton);
            this.panel1.Controls.Add(this.deletePointButton);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 0;
            // 
            // deletePointButton
            // 
            this.deletePointButton.Location = new System.Drawing.Point(11, 11);
            this.deletePointButton.Name = "deletePointButton";
            this.deletePointButton.Size = new System.Drawing.Size(75, 23);
            this.deletePointButton.TabIndex = 0;
            this.deletePointButton.Text = "Delete";
            this.deletePointButton.UseVisualStyleBackColor = true;
            this.deletePointButton.Click += new System.EventHandler(this.deletePointButton_Click);
            // 
            // editButton
            // 
            this.editButton.Location = new System.Drawing.Point(11, 49);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(75, 23);
            this.editButton.TabIndex = 1;
            this.editButton.Text = "Edit";
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // xText
            // 
            this.xText.Location = new System.Drawing.Point(87, 13);
            this.xText.Name = "xText";
            this.xText.Size = new System.Drawing.Size(100, 20);
            this.xText.TabIndex = 2;
            // 
            // yText
            // 
            this.yText.Location = new System.Drawing.Point(87, 51);
            this.yText.Name = "yText";
            this.yText.Size = new System.Drawing.Size(100, 20);
            this.yText.TabIndex = 3;
            // 
            // xLabel
            // 
            this.xLabel.AutoSize = true;
            this.xLabel.Location = new System.Drawing.Point(28, 16);
            this.xLabel.Name = "xLabel";
            this.xLabel.Size = new System.Drawing.Size(43, 13);
            this.xLabel.TabIndex = 4;
            this.xLabel.Text = "X(float):";
            // 
            // yLabel
            // 
            this.yLabel.AutoSize = true;
            this.yLabel.Location = new System.Drawing.Point(28, 54);
            this.yLabel.Name = "yLabel";
            this.yLabel.Size = new System.Drawing.Size(43, 13);
            this.yLabel.TabIndex = 5;
            this.yLabel.Text = "Y(float):";
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(21, 72);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 6;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // cancelEditButton
            // 
            this.cancelEditButton.Location = new System.Drawing.Point(102, 72);
            this.cancelEditButton.Name = "cancelEditButton";
            this.cancelEditButton.Size = new System.Drawing.Size(75, 23);
            this.cancelEditButton.TabIndex = 7;
            this.cancelEditButton.Text = "Cancel";
            this.cancelEditButton.UseVisualStyleBackColor = true;
            this.cancelEditButton.Click += new System.EventHandler(this.cancelEditButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(102, 72);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 8;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // OptionsPane
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(200, 100);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OptionsPane";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Options";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button deletePointButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Label yLabel;
        private System.Windows.Forms.Label xLabel;
        private System.Windows.Forms.TextBox yText;
        private System.Windows.Forms.TextBox xText;
        private System.Windows.Forms.Button cancelEditButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button cancelButton;
    }
}