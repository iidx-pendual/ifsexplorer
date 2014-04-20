namespace IFSExplorer
{
    partial class AboutBox
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.linklabelYuki = new System.Windows.Forms.LinkLabel();
            this.linklabelGitHub = new System.Windows.Forms.LinkLabel();
            this.linklabelPublicDomain = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonOK.Location = new System.Drawing.Point(174, 87);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // linklabelYuki
            // 
            this.linklabelYuki.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linklabelYuki.LinkArea = new System.Windows.Forms.LinkArea(24, 10);
            this.linklabelYuki.Location = new System.Drawing.Point(12, 17);
            this.linklabelYuki.Name = "linklabelYuki";
            this.linklabelYuki.Size = new System.Drawing.Size(399, 17);
            this.linklabelYuki.TabIndex = 1;
            this.linklabelYuki.TabStop = true;
            this.linklabelYuki.Text = "Bemani IFS Extractor by Yuki Izumi.";
            this.linklabelYuki.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linklabelYuki.UseCompatibleTextRendering = true;
            this.linklabelYuki.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelYuki_LinkClicked);
            // 
            // linklabelGitHub
            // 
            this.linklabelGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linklabelGitHub.LinkArea = new System.Windows.Forms.LinkArea(32, 6);
            this.linklabelGitHub.Location = new System.Drawing.Point(12, 34);
            this.linklabelGitHub.Name = "linklabelGitHub";
            this.linklabelGitHub.Size = new System.Drawing.Size(399, 17);
            this.linklabelGitHub.TabIndex = 2;
            this.linklabelGitHub.TabStop = true;
            this.linklabelGitHub.Text = "The source code can be found on GitHub.";
            this.linklabelGitHub.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linklabelGitHub.UseCompatibleTextRendering = true;
            this.linklabelGitHub.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelGitHub_LinkClicked);
            // 
            // linklabelPublicDomain
            // 
            this.linklabelPublicDomain.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.linklabelPublicDomain.LinkArea = new System.Windows.Forms.LinkArea(24, 13);
            this.linklabelPublicDomain.Location = new System.Drawing.Point(12, 51);
            this.linklabelPublicDomain.Name = "linklabelPublicDomain";
            this.linklabelPublicDomain.Size = new System.Drawing.Size(399, 17);
            this.linklabelPublicDomain.TabIndex = 3;
            this.linklabelPublicDomain.TabStop = true;
            this.linklabelPublicDomain.Text = "This software is in the public domain: you are free to do with it as you wish.";
            this.linklabelPublicDomain.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.linklabelPublicDomain.UseCompatibleTextRendering = true;
            this.linklabelPublicDomain.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linklabelPublicDomain_LinkClicked);
            // 
            // AboutBox
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonOK;
            this.ClientSize = new System.Drawing.Size(423, 125);
            this.Controls.Add(this.linklabelPublicDomain);
            this.Controls.Add(this.linklabelGitHub);
            this.Controls.Add(this.linklabelYuki);
            this.Controls.Add(this.buttonOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "AboutBox";
            this.Text = "About Bemani IFS Extractor";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.LinkLabel linklabelYuki;
        private System.Windows.Forms.LinkLabel linklabelGitHub;
        private System.Windows.Forms.LinkLabel linklabelPublicDomain;
    }
}