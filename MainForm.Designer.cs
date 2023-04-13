namespace AC_Image
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.testConnectionToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.txtUsername = new System.Windows.Forms.ToolStripTextBox();
            this.ctxRightClickImage = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.detailCtxRightClickImage = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.autoGenerateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciGenerateAll = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciGenerateContents = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.crxRciGenerateTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciGenerateDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciGenerateKeywords = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciGenerateHashtags = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem11 = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciCopyTitle = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciCopyLink = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciCopyDescription = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciCopyKeywords = new System.Windows.Forms.ToolStripMenuItem();
            this.crxRciCopyHashtags = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tpUploadImage = new System.Windows.Forms.TabPage();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tpMyImages = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvImages = new System.Windows.Forms.ListView();
            this.colImagesName = new System.Windows.Forms.ColumnHeader();
            this.colImagesSize = new System.Windows.Forms.ColumnHeader();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.gbAlbums = new System.Windows.Forms.GroupBox();
            this.lvAlbums = new System.Windows.Forms.ListView();
            this.colAlbumName = new System.Windows.Forms.ColumnHeader();
            this.colAlbumImageCount = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.menuStrip1.SuspendLayout();
            this.ctxRightClickImage.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tpUploadImage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.tpMyImages.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.gbAlbums.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.BackColor = System.Drawing.SystemColors.Control;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.testConnectionToolStripMenuItem,
            this.txtUsername});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 5, 0, 9);
            this.menuStrip1.Size = new System.Drawing.Size(1501, 49);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // testConnectionToolStripMenuItem
            // 
            this.testConnectionToolStripMenuItem.Name = "testConnectionToolStripMenuItem";
            this.testConnectionToolStripMenuItem.Padding = new System.Windows.Forms.Padding(6, 3, 6, 3);
            this.testConnectionToolStripMenuItem.Size = new System.Drawing.Size(130, 35);
            this.testConnectionToolStripMenuItem.Text = "Test Connection";
            // 
            // txtUsername
            // 
            this.txtUsername.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.txtUsername.BackColor = System.Drawing.SystemColors.Control;
            this.txtUsername.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUsername.Font = new System.Drawing.Font("Segoe UI", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.txtUsername.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.txtUsername.Margin = new System.Windows.Forms.Padding(1, 5, 15, 5);
            this.txtUsername.Name = "txtUsername";
            this.txtUsername.ReadOnly = true;
            this.txtUsername.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtUsername.Size = new System.Drawing.Size(114, 25);
            this.txtUsername.Text = "Tes";
            // 
            // ctxRightClickImage
            // 
            this.ctxRightClickImage.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.ctxRightClickImage.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.detailCtxRightClickImage,
            this.toolStripSeparator1,
            this.autoGenerateToolStripMenuItem,
            this.toolStripSeparator3,
            this.toolStripMenuItem11,
            this.crxRciCopyTitle,
            this.crxRciCopyLink,
            this.crxRciCopyDescription,
            this.crxRciCopyKeywords,
            this.crxRciCopyHashtags});
            this.ctxRightClickImage.Name = "contextMenuStrip1";
            this.ctxRightClickImage.Size = new System.Drawing.Size(193, 208);
            this.ctxRightClickImage.Opening += new System.ComponentModel.CancelEventHandler(this.ctxRightClickImage_Opening);
            // 
            // detailCtxRightClickImage
            // 
            this.detailCtxRightClickImage.Name = "detailCtxRightClickImage";
            this.detailCtxRightClickImage.Size = new System.Drawing.Size(192, 24);
            this.detailCtxRightClickImage.Text = "Detail";
            this.detailCtxRightClickImage.Click += new System.EventHandler(this.detailCtxRightClickImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(189, 6);
            // 
            // autoGenerateToolStripMenuItem
            // 
            this.autoGenerateToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.crxRciGenerateAll,
            this.crxRciGenerateContents,
            this.toolStripSeparator2,
            this.crxRciGenerateTitle,
            this.crxRciGenerateDescription,
            this.crxRciGenerateKeywords,
            this.crxRciGenerateHashtags});
            this.autoGenerateToolStripMenuItem.Name = "autoGenerateToolStripMenuItem";
            this.autoGenerateToolStripMenuItem.Size = new System.Drawing.Size(192, 24);
            this.autoGenerateToolStripMenuItem.Text = "Generate";
            // 
            // crxRciGenerateAll
            // 
            this.crxRciGenerateAll.Name = "crxRciGenerateAll";
            this.crxRciGenerateAll.Size = new System.Drawing.Size(172, 26);
            this.crxRciGenerateAll.Text = "All";
            // 
            // crxRciGenerateContents
            // 
            this.crxRciGenerateContents.Name = "crxRciGenerateContents";
            this.crxRciGenerateContents.Size = new System.Drawing.Size(172, 26);
            this.crxRciGenerateContents.Text = "All Contents";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(169, 6);
            // 
            // crxRciGenerateTitle
            // 
            this.crxRciGenerateTitle.Name = "crxRciGenerateTitle";
            this.crxRciGenerateTitle.Size = new System.Drawing.Size(172, 26);
            this.crxRciGenerateTitle.Text = "Title";
            // 
            // crxRciGenerateDescription
            // 
            this.crxRciGenerateDescription.Name = "crxRciGenerateDescription";
            this.crxRciGenerateDescription.Size = new System.Drawing.Size(172, 26);
            this.crxRciGenerateDescription.Text = "Description";
            // 
            // crxRciGenerateKeywords
            // 
            this.crxRciGenerateKeywords.Name = "crxRciGenerateKeywords";
            this.crxRciGenerateKeywords.Size = new System.Drawing.Size(172, 26);
            this.crxRciGenerateKeywords.Text = "Keywords";
            // 
            // crxRciGenerateHashtags
            // 
            this.crxRciGenerateHashtags.Name = "crxRciGenerateHashtags";
            this.crxRciGenerateHashtags.Size = new System.Drawing.Size(172, 26);
            this.crxRciGenerateHashtags.Text = "Hashtags";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(189, 6);
            // 
            // toolStripMenuItem11
            // 
            this.toolStripMenuItem11.Enabled = false;
            this.toolStripMenuItem11.Name = "toolStripMenuItem11";
            this.toolStripMenuItem11.Size = new System.Drawing.Size(192, 24);
            this.toolStripMenuItem11.Text = "Copy";
            // 
            // crxRciCopyTitle
            // 
            this.crxRciCopyTitle.Name = "crxRciCopyTitle";
            this.crxRciCopyTitle.Size = new System.Drawing.Size(192, 24);
            this.crxRciCopyTitle.Text = "Copy Title";
            this.crxRciCopyTitle.Click += new System.EventHandler(this.crxRciCopyTitle_Click);
            // 
            // crxRciCopyLink
            // 
            this.crxRciCopyLink.Name = "crxRciCopyLink";
            this.crxRciCopyLink.Size = new System.Drawing.Size(192, 24);
            this.crxRciCopyLink.Text = "Copy Link";
            this.crxRciCopyLink.Click += new System.EventHandler(this.crxRciCopyLink_Click);
            // 
            // crxRciCopyDescription
            // 
            this.crxRciCopyDescription.Name = "crxRciCopyDescription";
            this.crxRciCopyDescription.Size = new System.Drawing.Size(192, 24);
            this.crxRciCopyDescription.Text = "Copy Description";
            this.crxRciCopyDescription.Click += new System.EventHandler(this.crxRciCopyDescription_Click);
            // 
            // crxRciCopyKeywords
            // 
            this.crxRciCopyKeywords.Name = "crxRciCopyKeywords";
            this.crxRciCopyKeywords.Size = new System.Drawing.Size(192, 24);
            this.crxRciCopyKeywords.Text = "Copy Keywords";
            this.crxRciCopyKeywords.Click += new System.EventHandler(this.crxRciCopyKeywords_Click);
            // 
            // crxRciCopyHashtags
            // 
            this.crxRciCopyHashtags.Name = "crxRciCopyHashtags";
            this.crxRciCopyHashtags.Size = new System.Drawing.Size(192, 24);
            this.crxRciCopyHashtags.Text = "Copy Hastags";
            this.crxRciCopyHashtags.Click += new System.EventHandler(this.crxRciCopyHashtags_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tpUploadImage);
            this.tabControl1.Controls.Add(this.tpMyImages);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 49);
            this.tabControl1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.Padding = new System.Drawing.Point(9, 5);
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.tabControl1.RightToLeftLayout = true;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1501, 784);
            this.tabControl1.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;
            this.tabControl1.TabIndex = 3;
            // 
            // tpUploadImage
            // 
            this.tpUploadImage.Controls.Add(this.splitContainer1);
            this.tpUploadImage.Location = new System.Drawing.Point(4, 33);
            this.tpUploadImage.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpUploadImage.Name = "tpUploadImage";
            this.tpUploadImage.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpUploadImage.Size = new System.Drawing.Size(1493, 747);
            this.tpUploadImage.TabIndex = 0;
            this.tpUploadImage.Text = "Upload Images";
            this.tpUploadImage.UseVisualStyleBackColor = true;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 4);
            this.splitContainer1.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.groupBox1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(1487, 739);
            this.splitContainer1.SplitterDistance = 1201;
            this.splitContainer1.SplitterWidth = 5;
            this.splitContainer1.TabIndex = 0;
            // 
            // tpMyImages
            // 
            this.tpMyImages.Controls.Add(this.groupBox2);
            this.tpMyImages.Controls.Add(this.statusStrip1);
            this.tpMyImages.Controls.Add(this.gbAlbums);
            this.tpMyImages.Location = new System.Drawing.Point(4, 33);
            this.tpMyImages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpMyImages.Name = "tpMyImages";
            this.tpMyImages.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.tpMyImages.Size = new System.Drawing.Size(1493, 747);
            this.tpMyImages.TabIndex = 1;
            this.tpMyImages.Text = "My Images";
            this.tpMyImages.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvImages);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(293, 4);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox2.Size = new System.Drawing.Size(1197, 715);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Images";
            // 
            // lvImages
            // 
            this.lvImages.Activation = System.Windows.Forms.ItemActivation.TwoClick;
            this.lvImages.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colImagesName,
            this.colImagesSize});
            this.lvImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvImages.FullRowSelect = true;
            this.lvImages.Location = new System.Drawing.Point(3, 24);
            this.lvImages.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvImages.MultiSelect = false;
            this.lvImages.Name = "lvImages";
            this.lvImages.Size = new System.Drawing.Size(1191, 687);
            this.lvImages.TabIndex = 0;
            this.lvImages.UseCompatibleStateImageBehavior = false;
            this.lvImages.SelectedIndexChanged += new System.EventHandler(this.lvImages_SelectedIndexChanged);
            this.lvImages.MouseUp += new System.Windows.Forms.MouseEventHandler(this.lvImages_MouseUp);
            // 
            // colImagesName
            // 
            this.colImagesName.Text = "Name";
            // 
            // colImagesSize
            // 
            this.colImagesSize.Text = "Size";
            this.colImagesSize.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(293, 719);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Padding = new System.Windows.Forms.Padding(16, 0, 1, 0);
            this.statusStrip1.Size = new System.Drawing.Size(1197, 24);
            this.statusStrip1.TabIndex = 9;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.AutoSize = false;
            this.toolStripStatusLabel1.Margin = new System.Windows.Forms.Padding(2, 3, 0, 2);
            this.toolStripStatusLabel1.MergeAction = System.Windows.Forms.MergeAction.Replace;
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel1.Padding = new System.Windows.Forms.Padding(10, 0, 50, 0);
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(124, 19);
            this.toolStripStatusLabel1.Text = "300000 Album";
            this.toolStripStatusLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.AutoSize = false;
            this.toolStripStatusLabel2.Margin = new System.Windows.Forms.Padding(30, 3, 0, 2);
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Overflow = System.Windows.Forms.ToolStripItemOverflow.Never;
            this.toolStripStatusLabel2.Padding = new System.Windows.Forms.Padding(10, 0, 50, 0);
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(152, 19);
            this.toolStripStatusLabel2.Text = "10 Images Show";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // gbAlbums
            // 
            this.gbAlbums.Controls.Add(this.lvAlbums);
            this.gbAlbums.Dock = System.Windows.Forms.DockStyle.Left;
            this.gbAlbums.Location = new System.Drawing.Point(3, 4);
            this.gbAlbums.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAlbums.Name = "gbAlbums";
            this.gbAlbums.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.gbAlbums.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.gbAlbums.Size = new System.Drawing.Size(290, 739);
            this.gbAlbums.TabIndex = 8;
            this.gbAlbums.TabStop = false;
            this.gbAlbums.Text = "My Albums";
            // 
            // lvAlbums
            // 
            this.lvAlbums.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAlbumName,
            this.colAlbumImageCount});
            this.lvAlbums.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAlbums.FullRowSelect = true;
            this.lvAlbums.Location = new System.Drawing.Point(3, 24);
            this.lvAlbums.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.lvAlbums.Name = "lvAlbums";
            this.lvAlbums.Size = new System.Drawing.Size(284, 711);
            this.lvAlbums.TabIndex = 0;
            this.lvAlbums.UseCompatibleStateImageBehavior = false;
            this.lvAlbums.View = System.Windows.Forms.View.Details;
            this.lvAlbums.SelectedIndexChanged += new System.EventHandler(this.lvAlbums_SelectedIndexChanged);
            // 
            // colAlbumName
            // 
            this.colAlbumName.Text = "Name";
            this.colAlbumName.Width = 200;
            // 
            // colAlbumImageCount
            // 
            this.colAlbumImageCount.Text = "Count";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.groupBox1.Size = new System.Drawing.Size(281, 739);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Local Images";
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(3, 23);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(275, 713);
            this.treeView1.TabIndex = 0;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1501, 833);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.MdiChildrenMinimizedAnchorBottom = false;
            this.Name = "MainForm";
            this.RightToLeftLayout = true;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "DC Image";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ctxRightClickImage.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tpUploadImage.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.tpMyImages.ResumeLayout(false);
            this.tpMyImages.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.gbAlbums.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private MenuStrip menuStrip1;
        private ToolStripMenuItem testConnectionToolStripMenuItem;
        private ColumnHeader colImagesIcon;
        private ToolStripTextBox txtUsername;
        private ContextMenuStrip ctxRightClickImage;
        private ToolStripMenuItem detailCtxRightClickImage;
        private ToolStripMenuItem autoGenerateToolStripMenuItem;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripMenuItem crxRciCopyLink;
        private ToolStripMenuItem crxRciGenerateAll;
        private ToolStripMenuItem crxRciGenerateContents;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripMenuItem crxRciGenerateTitle;
        private ToolStripMenuItem crxRciGenerateDescription;
        private ToolStripMenuItem crxRciGenerateKeywords;
        private ToolStripMenuItem crxRciGenerateHashtags;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripMenuItem toolStripMenuItem11;
        private ToolStripMenuItem crxRciCopyTitle;
        private ToolStripMenuItem crxRciCopyDescription;
        private ToolStripMenuItem crxRciCopyKeywords;
        private ToolStripMenuItem crxRciCopyHashtags;
        private TabControl tabControl1;
        private TabPage tpUploadImage;
        private TabPage tpMyImages;
        private GroupBox groupBox2;
        private ListView lvImages;
        private ColumnHeader colImagesName;
        private ColumnHeader colImagesSize;
        private StatusStrip statusStrip1;
        private ToolStripStatusLabel toolStripStatusLabel1;
        private ToolStripStatusLabel toolStripStatusLabel2;
        private GroupBox gbAlbums;
        private ListView lvAlbums;
        private ColumnHeader colAlbumName;
        private ColumnHeader colAlbumImageCount;
        private SplitContainer splitContainer1;
        private GroupBox groupBox1;
        private TreeView treeView1;
    }
}