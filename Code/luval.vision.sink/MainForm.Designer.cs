namespace luval.vision.sink
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveResult = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveImage = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadForMapping = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSkip = new System.Windows.Forms.ToolStripMenuItem();
            this.consolidateResultsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportCsv = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportSql = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblProfile = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMouseCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblElementText = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblProgress = new System.Windows.Forms.ToolStripStatusLabel();
            this.pbProgress = new System.Windows.Forms.ToolStripProgressBar();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.lblImageDetails = new System.Windows.Forms.Label();
            this.rdNumbers = new System.Windows.Forms.RadioButton();
            this.rdWords = new System.Windows.Forms.RadioButton();
            this.rdCodes = new System.Windows.Forms.RadioButton();
            this.rdDates = new System.Windows.Forms.RadioButton();
            this.rdAmounts = new System.Windows.Forms.RadioButton();
            this.rdVision = new System.Windows.Forms.RadioButton();
            this.rdResult = new System.Windows.Forms.RadioButton();
            this.btnDemo = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabPicture = new System.Windows.Forms.TabPage();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.splitterPicture = new System.Windows.Forms.Splitter();
            this.panelResult = new System.Windows.Forms.Panel();
            this.listResult = new System.Windows.Forms.ListView();
            this.colAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colScore = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelResultHeader = new System.Windows.Forms.Panel();
            this.mappingControl = new luval.vision.sink.Controls.MappingControl();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.tabVision = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.resultText = new System.Windows.Forms.TextBox();
            this.tabVisionJson = new System.Windows.Forms.TabPage();
            this.treeJsonVision = new System.Windows.Forms.TreeView();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.grpResults.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.mainTab.SuspendLayout();
            this.tabPicture.SuspendLayout();
            this.panelPicture.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.panelResultHeader.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tabVision.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabVisionJson.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.mnuAbout});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1083, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.mnuSaveResult,
            this.mnuSaveImage,
            this.mnuLoadProfile,
            this.toolStripSeparator1,
            this.exitMenu,
            this.toolStripSeparator2});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openMenu
            // 
            this.openMenu.Image = ((System.Drawing.Image)(resources.GetObject("openMenu.Image")));
            this.openMenu.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.openMenu.Name = "openMenu";
            this.openMenu.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openMenu.Size = new System.Drawing.Size(146, 22);
            this.openMenu.Text = "&Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // mnuSaveResult
            // 
            this.mnuSaveResult.Name = "mnuSaveResult";
            this.mnuSaveResult.Size = new System.Drawing.Size(146, 22);
            this.mnuSaveResult.Text = "Save Result";
            this.mnuSaveResult.Click += new System.EventHandler(this.mnuSaveResult_Click);
            // 
            // mnuSaveImage
            // 
            this.mnuSaveImage.Name = "mnuSaveImage";
            this.mnuSaveImage.Size = new System.Drawing.Size(146, 22);
            this.mnuSaveImage.Text = "Save Image";
            this.mnuSaveImage.Click += new System.EventHandler(this.mnuSaveImage_Click);
            // 
            // mnuLoadProfile
            // 
            this.mnuLoadProfile.Name = "mnuLoadProfile";
            this.mnuLoadProfile.Size = new System.Drawing.Size(146, 22);
            this.mnuLoadProfile.Text = "Load Profile";
            this.mnuLoadProfile.Click += new System.EventHandler(this.mnuLoadProfile_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(143, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(146, 22);
            this.exitMenu.Text = "E&xit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(143, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoadForMapping,
            this.mnuSkip,
            this.consolidateResultsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // mnuLoadForMapping
            // 
            this.mnuLoadForMapping.Name = "mnuLoadForMapping";
            this.mnuLoadForMapping.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.mnuLoadForMapping.Size = new System.Drawing.Size(190, 22);
            this.mnuLoadForMapping.Text = "Load For Mapping";
            this.mnuLoadForMapping.Click += new System.EventHandler(this.mnuLoadForMapping_Click);
            // 
            // mnuSkip
            // 
            this.mnuSkip.Name = "mnuSkip";
            this.mnuSkip.ShortcutKeys = System.Windows.Forms.Keys.F10;
            this.mnuSkip.Size = new System.Drawing.Size(190, 22);
            this.mnuSkip.Text = "Skip Image";
            // 
            // consolidateResultsToolStripMenuItem
            // 
            this.consolidateResultsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuExportCsv,
            this.mnuExportSql});
            this.consolidateResultsToolStripMenuItem.Name = "consolidateResultsToolStripMenuItem";
            this.consolidateResultsToolStripMenuItem.Size = new System.Drawing.Size(190, 22);
            this.consolidateResultsToolStripMenuItem.Text = "Consolidate Results";
            // 
            // mnuExportCsv
            // 
            this.mnuExportCsv.Name = "mnuExportCsv";
            this.mnuExportCsv.Size = new System.Drawing.Size(116, 22);
            this.mnuExportCsv.Text = "CSV File";
            this.mnuExportCsv.Click += new System.EventHandler(this.mnuExportCsv_Click);
            // 
            // mnuExportSql
            // 
            this.mnuExportSql.Name = "mnuExportSql";
            this.mnuExportSql.Size = new System.Drawing.Size(116, 22);
            this.mnuExportSql.Text = "Sql File";
            this.mnuExportSql.Click += new System.EventHandler(this.mnuExportSql_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.grpResults);
            this.panel1.Controls.Add(this.btnDemo);
            this.panel1.Controls.Add(this.processBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 716);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1083, 88);
            this.panel1.TabIndex = 1;
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProfile,
            this.lblMouseCoordinates,
            this.lblStatus,
            this.lblElementText,
            this.lblProgress,
            this.pbProgress});
            this.statusStrip.Location = new System.Drawing.Point(0, 64);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1083, 24);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblProfile
            // 
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(85, 19);
            this.lblProfile.Text = "Profile: Default";
            // 
            // lblMouseCoordinates
            // 
            this.lblMouseCoordinates.Name = "lblMouseCoordinates";
            this.lblMouseCoordinates.Size = new System.Drawing.Size(0, 19);
            // 
            // lblStatus
            // 
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 19);
            // 
            // lblElementText
            // 
            this.lblElementText.BorderSides = ((System.Windows.Forms.ToolStripStatusLabelBorderSides)((((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left | System.Windows.Forms.ToolStripStatusLabelBorderSides.Top) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Right) 
            | System.Windows.Forms.ToolStripStatusLabelBorderSides.Bottom)));
            this.lblElementText.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.lblElementText.Name = "lblElementText";
            this.lblElementText.Size = new System.Drawing.Size(158, 19);
            this.lblElementText.Text = "Click on Element to get Text";
            this.lblElementText.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblProgress
            // 
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(101, 19);
            this.lblProgress.Text = "Progress Message";
            this.lblProgress.Visible = false;
            // 
            // pbProgress
            // 
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(100, 18);
            this.pbProgress.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(909, 22);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 23);
            this.btnClear.TabIndex = 10;
            this.btnClear.Text = "&Clear";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // grpResults
            // 
            this.grpResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpResults.Controls.Add(this.lblImageDetails);
            this.grpResults.Controls.Add(this.rdNumbers);
            this.grpResults.Controls.Add(this.rdWords);
            this.grpResults.Controls.Add(this.rdCodes);
            this.grpResults.Controls.Add(this.rdDates);
            this.grpResults.Controls.Add(this.rdAmounts);
            this.grpResults.Controls.Add(this.rdVision);
            this.grpResults.Controls.Add(this.rdResult);
            this.grpResults.Enabled = false;
            this.grpResults.Location = new System.Drawing.Point(12, 14);
            this.grpResults.Name = "grpResults";
            this.grpResults.Size = new System.Drawing.Size(891, 43);
            this.grpResults.TabIndex = 9;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Result Options";
            // 
            // lblImageDetails
            // 
            this.lblImageDetails.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblImageDetails.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblImageDetails.Location = new System.Drawing.Point(581, 13);
            this.lblImageDetails.Name = "lblImageDetails";
            this.lblImageDetails.Size = new System.Drawing.Size(310, 18);
            this.lblImageDetails.TabIndex = 12;
            this.lblImageDetails.Text = "Size: Quality";
            this.lblImageDetails.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lblImageDetails.Visible = false;
            // 
            // rdNumbers
            // 
            this.rdNumbers.AutoSize = true;
            this.rdNumbers.Location = new System.Drawing.Point(260, 17);
            this.rdNumbers.Name = "rdNumbers";
            this.rdNumbers.Size = new System.Drawing.Size(67, 17);
            this.rdNumbers.TabIndex = 11;
            this.rdNumbers.TabStop = true;
            this.rdNumbers.Text = "Numbers";
            this.rdNumbers.UseVisualStyleBackColor = true;
            this.rdNumbers.Click += new System.EventHandler(this.rdNumbers_Click);
            // 
            // rdWords
            // 
            this.rdWords.AutoSize = true;
            this.rdWords.Location = new System.Drawing.Point(452, 17);
            this.rdWords.Name = "rdWords";
            this.rdWords.Size = new System.Drawing.Size(56, 17);
            this.rdWords.TabIndex = 10;
            this.rdWords.TabStop = true;
            this.rdWords.Text = "Words";
            this.rdWords.UseVisualStyleBackColor = true;
            this.rdWords.Click += new System.EventHandler(this.rdWords_Click);
            // 
            // rdCodes
            // 
            this.rdCodes.AutoSize = true;
            this.rdCodes.Location = new System.Drawing.Point(391, 18);
            this.rdCodes.Name = "rdCodes";
            this.rdCodes.Size = new System.Drawing.Size(55, 17);
            this.rdCodes.TabIndex = 9;
            this.rdCodes.TabStop = true;
            this.rdCodes.Text = "Codes";
            this.rdCodes.UseVisualStyleBackColor = true;
            this.rdCodes.Click += new System.EventHandler(this.rdCodes_Click);
            // 
            // rdDates
            // 
            this.rdDates.AutoSize = true;
            this.rdDates.Location = new System.Drawing.Point(332, 18);
            this.rdDates.Name = "rdDates";
            this.rdDates.Size = new System.Drawing.Size(53, 17);
            this.rdDates.TabIndex = 8;
            this.rdDates.TabStop = true;
            this.rdDates.Text = "Dates";
            this.rdDates.UseVisualStyleBackColor = true;
            this.rdDates.Click += new System.EventHandler(this.rdDates_Click);
            // 
            // rdAmounts
            // 
            this.rdAmounts.AutoSize = true;
            this.rdAmounts.Location = new System.Drawing.Point(189, 17);
            this.rdAmounts.Name = "rdAmounts";
            this.rdAmounts.Size = new System.Drawing.Size(66, 17);
            this.rdAmounts.TabIndex = 7;
            this.rdAmounts.TabStop = true;
            this.rdAmounts.Text = "Amounts";
            this.rdAmounts.UseVisualStyleBackColor = true;
            this.rdAmounts.Click += new System.EventHandler(this.rdAmounts_Click);
            // 
            // rdVision
            // 
            this.rdVision.AutoSize = true;
            this.rdVision.Location = new System.Drawing.Point(97, 18);
            this.rdVision.Name = "rdVision";
            this.rdVision.Size = new System.Drawing.Size(86, 17);
            this.rdVision.TabIndex = 6;
            this.rdVision.TabStop = true;
            this.rdVision.Text = "Vision Result";
            this.rdVision.UseVisualStyleBackColor = true;
            this.rdVision.Click += new System.EventHandler(this.rdVision_Click);
            // 
            // rdResult
            // 
            this.rdResult.AutoSize = true;
            this.rdResult.Location = new System.Drawing.Point(6, 19);
            this.rdResult.Name = "rdResult";
            this.rdResult.Size = new System.Drawing.Size(85, 17);
            this.rdResult.TabIndex = 5;
            this.rdResult.TabStop = true;
            this.rdResult.Text = "Parse Result";
            this.rdResult.UseVisualStyleBackColor = true;
            this.rdResult.Click += new System.EventHandler(this.rdResult_Click);
            // 
            // btnDemo
            // 
            this.btnDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemo.Location = new System.Drawing.Point(963, 22);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(48, 23);
            this.btnDemo.TabIndex = 8;
            this.btnDemo.Text = "&Demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // processBtn
            // 
            this.processBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.processBtn.Location = new System.Drawing.Point(1017, 22);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(54, 23);
            this.processBtn.TabIndex = 7;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(735, 655);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.Click += new System.EventHandler(this.pictureBox_Click);
            this.pictureBox.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseClick);
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.pictureBox.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 692);
            this.splitter1.TabIndex = 3;
            this.splitter1.TabStop = false;
            // 
            // mainTab
            // 
            this.mainTab.Controls.Add(this.tabPicture);
            this.mainTab.Controls.Add(this.tabResult);
            this.mainTab.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainTab.Location = new System.Drawing.Point(3, 24);
            this.mainTab.Name = "mainTab";
            this.mainTab.SelectedIndex = 0;
            this.mainTab.Size = new System.Drawing.Size(1080, 692);
            this.mainTab.TabIndex = 6;
            // 
            // tabPicture
            // 
            this.tabPicture.Controls.Add(this.panelPicture);
            this.tabPicture.Controls.Add(this.splitterPicture);
            this.tabPicture.Controls.Add(this.panelResult);
            this.tabPicture.Location = new System.Drawing.Point(4, 22);
            this.tabPicture.Name = "tabPicture";
            this.tabPicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPicture.Size = new System.Drawing.Size(1072, 666);
            this.tabPicture.TabIndex = 0;
            this.tabPicture.Text = "Document";
            this.tabPicture.UseVisualStyleBackColor = true;
            // 
            // panelPicture
            // 
            this.panelPicture.AutoScroll = true;
            this.panelPicture.Controls.Add(this.pictureBox);
            this.panelPicture.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPicture.Location = new System.Drawing.Point(3, 3);
            this.panelPicture.Name = "panelPicture";
            this.panelPicture.Size = new System.Drawing.Size(735, 660);
            this.panelPicture.TabIndex = 0;
            // 
            // splitterPicture
            // 
            this.splitterPicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterPicture.Location = new System.Drawing.Point(738, 3);
            this.splitterPicture.Name = "splitterPicture";
            this.splitterPicture.Size = new System.Drawing.Size(3, 660);
            this.splitterPicture.TabIndex = 2;
            this.splitterPicture.TabStop = false;
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.listResult);
            this.panelResult.Controls.Add(this.panelResultHeader);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelResult.Location = new System.Drawing.Point(741, 3);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(328, 660);
            this.panelResult.TabIndex = 1;
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttribute,
            this.colValue,
            this.colScore});
            this.listResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listResult.FullRowSelect = true;
            this.listResult.Location = new System.Drawing.Point(0, 519);
            this.listResult.MultiSelect = false;
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(328, 141);
            this.listResult.TabIndex = 8;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            // 
            // colAttribute
            // 
            this.colAttribute.Text = "Attribute";
            this.colAttribute.Width = 51;
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            this.colValue.Width = 230;
            // 
            // colScore
            // 
            this.colScore.Text = "Score";
            // 
            // panelResultHeader
            // 
            this.panelResultHeader.Controls.Add(this.mappingControl);
            this.panelResultHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResultHeader.Location = new System.Drawing.Point(0, 0);
            this.panelResultHeader.Name = "panelResultHeader";
            this.panelResultHeader.Size = new System.Drawing.Size(328, 519);
            this.panelResultHeader.TabIndex = 9;
            // 
            // mappingControl
            // 
            this.mappingControl.Enabled = false;
            this.mappingControl.Location = new System.Drawing.Point(2, 3);
            this.mappingControl.Name = "mappingControl";
            this.mappingControl.SelectedAttribute = null;
            this.mappingControl.SelectedMapping = null;
            this.mappingControl.Size = new System.Drawing.Size(325, 520);
            this.mappingControl.TabIndex = 0;
            this.mappingControl.ValueMappingSelected += new System.EventHandler(this.mappingControl_ValueMappingSelected);
            this.mappingControl.AnchorMappingSelected += new System.EventHandler(this.mappingControl_AnchorMappingSelected);
            this.mappingControl.SaveAndNew += new System.EventHandler(this.mappingControl_SaveAndNew);
            this.mappingControl.Load += new System.EventHandler(this.mappingControl_Load);
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.tabVision);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(1072, 666);
            this.tabResult.TabIndex = 1;
            this.tabResult.Text = "Metadata";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // tabVision
            // 
            this.tabVision.Controls.Add(this.tabText);
            this.tabVision.Controls.Add(this.tabVisionJson);
            this.tabVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVision.Location = new System.Drawing.Point(3, 3);
            this.tabVision.Name = "tabVision";
            this.tabVision.SelectedIndex = 0;
            this.tabVision.Size = new System.Drawing.Size(1066, 660);
            this.tabVision.TabIndex = 5;
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.resultText);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(1058, 634);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // resultText
            // 
            this.resultText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultText.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultText.Location = new System.Drawing.Point(3, 3);
            this.resultText.Multiline = true;
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(1052, 628);
            this.resultText.TabIndex = 5;
            // 
            // tabVisionJson
            // 
            this.tabVisionJson.Controls.Add(this.treeJsonVision);
            this.tabVisionJson.Location = new System.Drawing.Point(4, 22);
            this.tabVisionJson.Name = "tabVisionJson";
            this.tabVisionJson.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisionJson.Size = new System.Drawing.Size(178, 42);
            this.tabVisionJson.TabIndex = 1;
            this.tabVisionJson.Text = "Vision";
            this.tabVisionJson.UseVisualStyleBackColor = true;
            // 
            // treeJsonVision
            // 
            this.treeJsonVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeJsonVision.Location = new System.Drawing.Point(3, 3);
            this.treeJsonVision.Name = "treeJsonVision";
            this.treeJsonVision.Size = new System.Drawing.Size(172, 36);
            this.treeJsonVision.TabIndex = 0;
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(52, 20);
            this.mnuAbout.Text = "&About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1083, 804);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Oscar Marin Machine Learning  OCR Tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.mainTab.ResumeLayout(false);
            this.tabPicture.ResumeLayout(false);
            this.panelPicture.ResumeLayout(false);
            this.panelPicture.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResultHeader.ResumeLayout(false);
            this.tabResult.ResumeLayout(false);
            this.tabVision.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.tabVisionJson.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip mainMenu;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openMenu;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitMenu;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage tabPicture;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.TabControl tabVision;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.TabPage tabVisionJson;
        private System.Windows.Forms.TreeView treeJsonVision;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveResult;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveImage;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel lblProfile;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.GroupBox grpResults;
        private System.Windows.Forms.RadioButton rdNumbers;
        private System.Windows.Forms.RadioButton rdWords;
        private System.Windows.Forms.RadioButton rdCodes;
        private System.Windows.Forms.RadioButton rdDates;
        private System.Windows.Forms.RadioButton rdAmounts;
        private System.Windows.Forms.RadioButton rdVision;
        private System.Windows.Forms.RadioButton rdResult;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadProfile;
        private System.Windows.Forms.Splitter splitterPicture;
        private System.Windows.Forms.Panel panelResult;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader colAttribute;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.Panel panelResultHeader;
        private System.Windows.Forms.ToolStripStatusLabel lblMouseCoordinates;
        private Controls.MappingControl mappingControl;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadForMapping;
        private System.Windows.Forms.ToolStripMenuItem mnuSkip;
        private System.Windows.Forms.ToolStripStatusLabel lblStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblElementText;
        private System.Windows.Forms.ToolStripMenuItem consolidateResultsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExportCsv;
        private System.Windows.Forms.ToolStripMenuItem mnuExportSql;
        private System.Windows.Forms.ToolStripStatusLabel lblProgress;
        private System.Windows.Forms.ToolStripProgressBar pbProgress;
        private System.Windows.Forms.ColumnHeader colScore;
        private System.Windows.Forms.Label lblImageDetails;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
    }
}

