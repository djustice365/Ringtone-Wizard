namespace RingtoneWizard
{
    partial class RingtoneWizard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RingtoneWizard));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.createRingtone = new System.Windows.Forms.Button();
            this.preview = new System.Windows.Forms.Button();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.statusBar = new System.Windows.Forms.Label();
            this.customTrackbar1 = new CustomTrackbar();
            this.axWindowsMediaPlayer1 = new AxWMPLib.AxWindowsMediaPlayer();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1192, 24);
            this.menuStrip1.TabIndex = 4;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(103, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.open);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // createRingtone
            // 
            this.createRingtone.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.createRingtone.Enabled = false;
            this.createRingtone.Location = new System.Drawing.Point(172, 540);
            this.createRingtone.Name = "createRingtone";
            this.createRingtone.Size = new System.Drawing.Size(101, 23);
            this.createRingtone.TabIndex = 10;
            this.createRingtone.Text = "Create Ringtone";
            this.createRingtone.UseVisualStyleBackColor = true;
            this.createRingtone.Click += new System.EventHandler(this.createRingtone_Click);
            // 
            // preview
            // 
            this.preview.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.preview.Enabled = false;
            this.preview.Location = new System.Drawing.Point(279, 540);
            this.preview.Name = "preview";
            this.preview.Size = new System.Drawing.Size(101, 23);
            this.preview.TabIndex = 11;
            this.preview.Text = "Preview";
            this.preview.UseVisualStyleBackColor = true;
            this.preview.Click += new System.EventHandler(this.preview_Click);
            // 
            // statusBar
            // 
            this.statusBar.BackColor = System.Drawing.SystemColors.Control;
            this.statusBar.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.statusBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.statusBar.Location = new System.Drawing.Point(0, 605);
            this.statusBar.Name = "statusBar";
            this.statusBar.Size = new System.Drawing.Size(1192, 20);
            this.statusBar.TabIndex = 12;
            this.statusBar.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // customTrackbar1
            // 
            this.customTrackbar1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.customTrackbar1.AutoSize = true;
            this.customTrackbar1.firstPoint = false;
            this.customTrackbar1.Location = new System.Drawing.Point(172, 417);
            this.customTrackbar1.Name = "customTrackbar1";
            this.customTrackbar1.Size = new System.Drawing.Size(894, 52);
            this.customTrackbar1.TabIndex = 9;
            this.customTrackbar1.waitingForNext = false;
            this.customTrackbar1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.customTrackBarDown);
            this.customTrackbar1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.customTrackBarMove);
            this.customTrackbar1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.customTrackBarUp);
            // 
            // axWindowsMediaPlayer1
            // 
            this.axWindowsMediaPlayer1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.axWindowsMediaPlayer1.Enabled = true;
            this.axWindowsMediaPlayer1.Location = new System.Drawing.Point(172, 32);
            this.axWindowsMediaPlayer1.Name = "axWindowsMediaPlayer1";
            this.axWindowsMediaPlayer1.OcxState = ((System.Windows.Forms.AxHost.State)(resources.GetObject("axWindowsMediaPlayer1.OcxState")));
            this.axWindowsMediaPlayer1.Size = new System.Drawing.Size(894, 351);
            this.axWindowsMediaPlayer1.TabIndex = 3;
            this.axWindowsMediaPlayer1.MediaError += new AxWMPLib._WMPOCXEvents_MediaErrorEventHandler(this.axWindowsMediaPlayer1_MediaError);
            // 
            // RingtoneWizard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ClientSize = new System.Drawing.Size(1192, 625);
            this.Controls.Add(this.statusBar);
            this.Controls.Add(this.preview);
            this.Controls.Add(this.createRingtone);
            this.Controls.Add(this.customTrackbar1);
            this.Controls.Add(this.axWindowsMediaPlayer1);
            this.Controls.Add(this.menuStrip1);
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "RingtoneWizard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ringtone Wizard";
            this.Load += new System.EventHandler(this.RingtoneWizard_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.keyDown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.axWindowsMediaPlayer1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private CustomTrackbar customTrackbar1;
        private System.Windows.Forms.Button createRingtone;
        private System.Windows.Forms.Button preview;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Label statusBar;
        private AxWMPLib.AxWindowsMediaPlayer axWindowsMediaPlayer1;
    }
}

