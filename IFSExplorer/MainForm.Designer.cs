namespace IFSExplorer
{
    partial class MainForm
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
            if (disposing && (components != null)) {
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
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listboxImages = new System.Windows.Forms.ListBox();
            this.pictureboxPreview = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.updownIndexSelect = new System.Windows.Forms.NumericUpDown();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.browseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveSelectedImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutBemaniIFSExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownIndexSelect)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // openFileDialog
            // 
            this.openFileDialog.Filter = "IFS files|*.ifs";
            this.openFileDialog.InitialDirectory = "C:\\LDJ\\data\\graphic";
            // 
            // listboxImages
            // 
            this.listboxImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listboxImages.FormattingEnabled = true;
            this.listboxImages.IntegralHeight = false;
            this.listboxImages.Location = new System.Drawing.Point(13, 53);
            this.listboxImages.Name = "listboxImages";
            this.listboxImages.Size = new System.Drawing.Size(131, 247);
            this.listboxImages.TabIndex = 1;
            this.listboxImages.SelectedIndexChanged += new System.EventHandler(this.listboxImages_SelectedIndexChanged);
            // 
            // pictureboxPreview
            // 
            this.pictureboxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureboxPreview.Location = new System.Drawing.Point(150, 53);
            this.pictureboxPreview.Name = "pictureboxPreview";
            this.pictureboxPreview.Size = new System.Drawing.Size(518, 247);
            this.pictureboxPreview.TabIndex = 3;
            this.pictureboxPreview.TabStop = false;
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(150, 29);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(311, 13);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Choose an .ifs file by clicking Browse from the File menu (Ctrl+O).";
            // 
            // updownIndexSelect
            // 
            this.updownIndexSelect.Enabled = false;
            this.updownIndexSelect.Location = new System.Drawing.Point(13, 27);
            this.updownIndexSelect.Name = "updownIndexSelect";
            this.updownIndexSelect.Size = new System.Drawing.Size(131, 20);
            this.updownIndexSelect.TabIndex = 5;
            this.updownIndexSelect.ValueChanged += new System.EventHandler(this.updownIndexSelect_ValueChanged);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(679, 24);
            this.menuStrip.TabIndex = 7;
            this.menuStrip.Text = "menuStrip";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.browseToolStripMenuItem,
            this.saveSelectedImageToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // browseToolStripMenuItem
            // 
            this.browseToolStripMenuItem.Name = "browseToolStripMenuItem";
            this.browseToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.browseToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.browseToolStripMenuItem.Text = "&Browse...";
            this.browseToolStripMenuItem.Click += new System.EventHandler(this.browseToolStripMenuItem_Click);
            // 
            // saveSelectedImageToolStripMenuItem
            // 
            this.saveSelectedImageToolStripMenuItem.Name = "saveSelectedImageToolStripMenuItem";
            this.saveSelectedImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveSelectedImageToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.saveSelectedImageToolStripMenuItem.Text = "&Save selected image...";
            this.saveSelectedImageToolStripMenuItem.Click += new System.EventHandler(this.saveSelectedImageToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(226, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(229, 22);
            this.exitToolStripMenuItem.Text = "E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutBemaniIFSExplorerToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutBemaniIFSExplorerToolStripMenuItem
            // 
            this.aboutBemaniIFSExplorerToolStripMenuItem.Name = "aboutBemaniIFSExplorerToolStripMenuItem";
            this.aboutBemaniIFSExplorerToolStripMenuItem.Size = new System.Drawing.Size(213, 22);
            this.aboutBemaniIFSExplorerToolStripMenuItem.Text = "&About Bemani IFS Explorer";
            this.aboutBemaniIFSExplorerToolStripMenuItem.Click += new System.EventHandler(this.aboutBemaniIFSExplorerToolStripMenuItem_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 312);
            this.Controls.Add(this.updownIndexSelect);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureboxPreview);
            this.Controls.Add(this.listboxImages);
            this.Controls.Add(this.menuStrip);
            this.DoubleBuffered = true;
            this.MainMenuStrip = this.menuStrip;
            this.Name = "MainForm";
            this.Text = "Bemani IFS Explorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownIndexSelect)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listboxImages;
        private System.Windows.Forms.PictureBox pictureboxPreview;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.NumericUpDown updownIndexSelect;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem browseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveSelectedImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.SaveFileDialog saveFileDialog;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutBemaniIFSExplorerToolStripMenuItem;
    }
}

