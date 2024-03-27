namespace OSMtoPicture
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.webView = new Microsoft.Web.WebView2.WinForms.WebView2();
            this.menuStrip = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changeOutputFolderToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeOffsetInPictureNamesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.closeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reloadOSMToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.savePicturesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel_OutputFolder = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker_save = new System.ComponentModel.BackgroundWorker();
            ((System.ComponentModel.ISupportInitialize)(this.webView)).BeginInit();
            this.menuStrip.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // webView
            // 
            this.webView.AllowExternalDrop = true;
            this.webView.CreationProperties = null;
            this.webView.DefaultBackgroundColor = System.Drawing.Color.White;
            this.webView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webView.Location = new System.Drawing.Point(0, 24);
            this.webView.Name = "webView";
            this.webView.Size = new System.Drawing.Size(800, 426);
            this.webView.TabIndex = 0;
            this.webView.ZoomFactor = 1D;
            this.webView.NavigationCompleted += new System.EventHandler<Microsoft.Web.WebView2.Core.CoreWebView2NavigationCompletedEventArgs>(this.webView_NavigationCompleted);
            // 
            // menuStrip
            // 
            this.menuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.reloadOSMToolStripMenuItem,
            this.savePicturesToolStripMenuItem});
            this.menuStrip.Location = new System.Drawing.Point(0, 0);
            this.menuStrip.Name = "menuStrip";
            this.menuStrip.Size = new System.Drawing.Size(800, 24);
            this.menuStrip.TabIndex = 1;
            this.menuStrip.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.changeOutputFolderToolStripMenuItem,
            this.removeOffsetInPictureNamesToolStripMenuItem,
            this.closeToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // changeOutputFolderToolStripMenuItem
            // 
            this.changeOutputFolderToolStripMenuItem.Name = "changeOutputFolderToolStripMenuItem";
            this.changeOutputFolderToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.changeOutputFolderToolStripMenuItem.Text = "Change output folder";
            this.changeOutputFolderToolStripMenuItem.Click += new System.EventHandler(this.changeOutputFolderToolStripMenuItem_Click);
            // 
            // removeOffsetInPictureNamesToolStripMenuItem
            // 
            this.removeOffsetInPictureNamesToolStripMenuItem.Name = "removeOffsetInPictureNamesToolStripMenuItem";
            this.removeOffsetInPictureNamesToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.removeOffsetInPictureNamesToolStripMenuItem.Text = "Remove offset in picture names";
            this.removeOffsetInPictureNamesToolStripMenuItem.Click += new System.EventHandler(this.removeOffsetInPictureNamesToolStripMenuItem_Click);
            // 
            // closeToolStripMenuItem
            // 
            this.closeToolStripMenuItem.Name = "closeToolStripMenuItem";
            this.closeToolStripMenuItem.Size = new System.Drawing.Size(241, 22);
            this.closeToolStripMenuItem.Text = "Close";
            this.closeToolStripMenuItem.Click += new System.EventHandler(this.closeToolStripMenuItem_Click);
            // 
            // reloadOSMToolStripMenuItem
            // 
            this.reloadOSMToolStripMenuItem.Name = "reloadOSMToolStripMenuItem";
            this.reloadOSMToolStripMenuItem.Size = new System.Drawing.Size(84, 20);
            this.reloadOSMToolStripMenuItem.Text = "Reload OSM";
            this.reloadOSMToolStripMenuItem.Click += new System.EventHandler(this.reloadOSMToolStripMenuItem_Click);
            // 
            // savePicturesToolStripMenuItem
            // 
            this.savePicturesToolStripMenuItem.Name = "savePicturesToolStripMenuItem";
            this.savePicturesToolStripMenuItem.Size = new System.Drawing.Size(88, 20);
            this.savePicturesToolStripMenuItem.Text = "Save pictures";
            this.savePicturesToolStripMenuItem.Click += new System.EventHandler(this.savePicturesToolStripMenuItem_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel,
            this.toolStripStatusLabel_OutputFolder});
            this.statusStrip.Location = new System.Drawing.Point(0, 428);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(800, 22);
            this.statusStrip.TabIndex = 2;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(118, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel1";
            // 
            // toolStripStatusLabel_OutputFolder
            // 
            this.toolStripStatusLabel_OutputFolder.Name = "toolStripStatusLabel_OutputFolder";
            this.toolStripStatusLabel_OutputFolder.Size = new System.Drawing.Size(667, 17);
            this.toolStripStatusLabel_OutputFolder.Spring = true;
            this.toolStripStatusLabel_OutputFolder.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // backgroundWorker_save
            // 
            this.backgroundWorker_save.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_save_DoWork);
            this.backgroundWorker_save.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_save_RunWorkerCompleted);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.webView);
            this.Controls.Add(this.menuStrip);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "OSM to picture";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.webView)).EndInit();
            this.menuStrip.ResumeLayout(false);
            this.menuStrip.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Microsoft.Web.WebView2.WinForms.WebView2 webView;
        private System.Windows.Forms.MenuStrip menuStrip;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.ComponentModel.BackgroundWorker backgroundWorker_save;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem closeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reloadOSMToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem savePicturesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem changeOutputFolderToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel_OutputFolder;
        private System.Windows.Forms.ToolStripMenuItem removeOffsetInPictureNamesToolStripMenuItem;
    }
}

