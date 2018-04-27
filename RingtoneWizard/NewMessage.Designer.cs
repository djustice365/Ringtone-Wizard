namespace RingtoneWizard
{
    partial class NewMessage
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
            this.message = new System.Windows.Forms.Label();
            this.dismiss = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // message
            // 
            this.message.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.message.Dock = System.Windows.Forms.DockStyle.Fill;
            this.message.Location = new System.Drawing.Point(0, 0);
            this.message.Name = "message";
            this.message.Size = new System.Drawing.Size(300, 150);
            this.message.TabIndex = 0;
            this.message.Text = "label1";
            this.message.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dismiss
            // 
            this.dismiss.Location = new System.Drawing.Point(111, 115);
            this.dismiss.Name = "dismiss";
            this.dismiss.Size = new System.Drawing.Size(75, 23);
            this.dismiss.TabIndex = 1;
            this.dismiss.Text = "Dismiss";
            this.dismiss.UseVisualStyleBackColor = true;
            this.dismiss.Click += new System.EventHandler(this.dismiss_Click);
            // 
            // NewMessage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 150);
            this.Controls.Add(this.dismiss);
            this.Controls.Add(this.message);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "NewMessage";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NewMessage";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label message;
        private System.Windows.Forms.Button dismiss;

    }
}