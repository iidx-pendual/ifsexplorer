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
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.listboxImages = new System.Windows.Forms.ListBox();
            this.pictureboxPreview = new System.Windows.Forms.PictureBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.updownIndexSelect = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPreview)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownIndexSelect)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(12, 12);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(60, 23);
            this.buttonBrowse.TabIndex = 0;
            this.buttonBrowse.Text = "&Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.buttonBrowse_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // listboxImages
            // 
            this.listboxImages.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.listboxImages.FormattingEnabled = true;
            this.listboxImages.Location = new System.Drawing.Point(12, 41);
            this.listboxImages.Name = "listboxImages";
            this.listboxImages.Size = new System.Drawing.Size(131, 225);
            this.listboxImages.TabIndex = 1;
            this.listboxImages.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // pictureboxPreview
            // 
            this.pictureboxPreview.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureboxPreview.Location = new System.Drawing.Point(149, 41);
            this.pictureboxPreview.Name = "pictureboxPreview";
            this.pictureboxPreview.Size = new System.Drawing.Size(518, 227);
            this.pictureboxPreview.TabIndex = 3;
            this.pictureboxPreview.TabStop = false;
            this.pictureboxPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pictureBox1_Paint);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(146, 17);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(184, 13);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.Text = "Choose an .ifs file by clicking Browse.";
            // 
            // updownIndexSelect
            // 
            this.updownIndexSelect.Location = new System.Drawing.Point(78, 15);
            this.updownIndexSelect.Name = "updownIndexSelect";
            this.updownIndexSelect.Size = new System.Drawing.Size(65, 20);
            this.updownIndexSelect.TabIndex = 5;
            this.updownIndexSelect.Visible = false;
            this.updownIndexSelect.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(679, 280);
            this.Controls.Add(this.updownIndexSelect);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.pictureboxPreview);
            this.Controls.Add(this.listboxImages);
            this.Controls.Add(this.buttonBrowse);
            this.Name = "MainForm";
            this.Text = "Bemani IFS Extractor";
            ((System.ComponentModel.ISupportInitialize)(this.pictureboxPreview)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.updownIndexSelect)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox listboxImages;
        private System.Windows.Forms.PictureBox pictureboxPreview;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.NumericUpDown updownIndexSelect;
    }
}

