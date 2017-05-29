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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabPicture = new System.Windows.Forms.TabPage();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.tabVision = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.resultText = new System.Windows.Forms.TextBox();
            this.tabVisionJson = new System.Windows.Forms.TabPage();
            this.treeJsonVision = new System.Windows.Forms.TreeView();
            this.btnClear = new System.Windows.Forms.Button();
            this.grpResults = new System.Windows.Forms.GroupBox();
            this.rdNumbers = new System.Windows.Forms.RadioButton();
            this.rdWords = new System.Windows.Forms.RadioButton();
            this.rdCodes = new System.Windows.Forms.RadioButton();
            this.rdDates = new System.Windows.Forms.RadioButton();
            this.rdAmounts = new System.Windows.Forms.RadioButton();
            this.rdVision = new System.Windows.Forms.RadioButton();
            this.rdResult = new System.Windows.Forms.RadioButton();
            this.btnDemo = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.lblProfile = new System.Windows.Forms.ToolStripStatusLabel();
            this.mnuLoadProfile = new System.Windows.Forms.ToolStripMenuItem();
            this.panelResult = new System.Windows.Forms.Panel();
            this.splitterPicture = new System.Windows.Forms.Splitter();
            this.listResult = new System.Windows.Forms.ListView();
            this.colAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.panelResultHeader = new System.Windows.Forms.Panel();
            this.lblMouseCoordinates = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblInstructions = new System.Windows.Forms.Label();
            this.txtLineText = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtLineValue = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAnchorText = new System.Windows.Forms.TextBox();
            this.btnApplyMap = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.mainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.mainTab.SuspendLayout();
            this.tabPicture.SuspendLayout();
            this.panelPicture.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tabVision.SuspendLayout();
            this.tabText.SuspendLayout();
            this.tabVisionJson.SuspendLayout();
            this.grpResults.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.panelResult.SuspendLayout();
            this.panelResultHeader.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.toolsToolStripMenuItem});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(1008, 24);
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
            this.openMenu.Size = new System.Drawing.Size(152, 22);
            this.openMenu.Text = "&Open";
            this.openMenu.Click += new System.EventHandler(this.openMenu_Click);
            // 
            // mnuSaveResult
            // 
            this.mnuSaveResult.Name = "mnuSaveResult";
            this.mnuSaveResult.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveResult.Text = "Save Result";
            this.mnuSaveResult.Click += new System.EventHandler(this.mnuSaveResult_Click);
            // 
            // mnuSaveImage
            // 
            this.mnuSaveImage.Name = "mnuSaveImage";
            this.mnuSaveImage.Size = new System.Drawing.Size(152, 22);
            this.mnuSaveImage.Text = "Save Image";
            this.mnuSaveImage.Click += new System.EventHandler(this.mnuSaveImage_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(149, 6);
            // 
            // exitMenu
            // 
            this.exitMenu.Name = "exitMenu";
            this.exitMenu.Size = new System.Drawing.Size(152, 22);
            this.exitMenu.Text = "E&xit";
            this.exitMenu.Click += new System.EventHandler(this.exitMenu_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(149, 6);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.customizeToolStripMenuItem,
            this.optionsToolStripMenuItem});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.toolsToolStripMenuItem.Text = "&Tools";
            // 
            // customizeToolStripMenuItem
            // 
            this.customizeToolStripMenuItem.Name = "customizeToolStripMenuItem";
            this.customizeToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.customizeToolStripMenuItem.Text = "&Customize";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(130, 22);
            this.optionsToolStripMenuItem.Text = "&Options";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.statusStrip);
            this.panel1.Controls.Add(this.btnClear);
            this.panel1.Controls.Add(this.grpResults);
            this.panel1.Controls.Add(this.btnDemo);
            this.panel1.Controls.Add(this.processBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 655);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1008, 88);
            this.panel1.TabIndex = 1;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(-1, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(700, 595);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            this.pictureBox.MouseHover += new System.EventHandler(this.pictureBox_MouseHover);
            this.pictureBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseMove);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 631);
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
            this.mainTab.Size = new System.Drawing.Size(1005, 631);
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
            this.tabPicture.Size = new System.Drawing.Size(997, 605);
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
            this.panelPicture.Size = new System.Drawing.Size(701, 599);
            this.panelPicture.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.tabVision);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(997, 605);
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
            this.tabVision.Size = new System.Drawing.Size(991, 599);
            this.tabVision.TabIndex = 5;
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.resultText);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(983, 573);
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
            this.resultText.Size = new System.Drawing.Size(977, 567);
            this.resultText.TabIndex = 5;
            // 
            // tabVisionJson
            // 
            this.tabVisionJson.Controls.Add(this.treeJsonVision);
            this.tabVisionJson.Location = new System.Drawing.Point(4, 22);
            this.tabVisionJson.Name = "tabVisionJson";
            this.tabVisionJson.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisionJson.Size = new System.Drawing.Size(698, 468);
            this.tabVisionJson.TabIndex = 1;
            this.tabVisionJson.Text = "Vision";
            this.tabVisionJson.UseVisualStyleBackColor = true;
            // 
            // treeJsonVision
            // 
            this.treeJsonVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeJsonVision.Location = new System.Drawing.Point(3, 3);
            this.treeJsonVision.Name = "treeJsonVision";
            this.treeJsonVision.Size = new System.Drawing.Size(692, 462);
            this.treeJsonVision.TabIndex = 0;
            // 
            // btnClear
            // 
            this.btnClear.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnClear.Enabled = false;
            this.btnClear.Location = new System.Drawing.Point(834, 22);
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
            this.grpResults.Size = new System.Drawing.Size(816, 43);
            this.grpResults.TabIndex = 9;
            this.grpResults.TabStop = false;
            this.grpResults.Text = "Result Options";
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
            this.btnDemo.Location = new System.Drawing.Point(888, 22);
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
            this.processBtn.Location = new System.Drawing.Point(942, 22);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(54, 23);
            this.processBtn.TabIndex = 7;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblProfile,
            this.lblMouseCoordinates});
            this.statusStrip.Location = new System.Drawing.Point(0, 66);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1008, 22);
            this.statusStrip.TabIndex = 11;
            this.statusStrip.Text = "statusStrip1";
            // 
            // lblProfile
            // 
            this.lblProfile.Name = "lblProfile";
            this.lblProfile.Size = new System.Drawing.Size(85, 17);
            this.lblProfile.Text = "Profile: Default";
            // 
            // mnuLoadProfile
            // 
            this.mnuLoadProfile.Name = "mnuLoadProfile";
            this.mnuLoadProfile.Size = new System.Drawing.Size(152, 22);
            this.mnuLoadProfile.Text = "Load Profile";
            this.mnuLoadProfile.Click += new System.EventHandler(this.mnuLoadProfile_Click);
            // 
            // panelResult
            // 
            this.panelResult.Controls.Add(this.listResult);
            this.panelResult.Controls.Add(this.panelResultHeader);
            this.panelResult.Dock = System.Windows.Forms.DockStyle.Right;
            this.panelResult.Location = new System.Drawing.Point(707, 3);
            this.panelResult.Name = "panelResult";
            this.panelResult.Size = new System.Drawing.Size(287, 599);
            this.panelResult.TabIndex = 1;
            // 
            // splitterPicture
            // 
            this.splitterPicture.Dock = System.Windows.Forms.DockStyle.Right;
            this.splitterPicture.Location = new System.Drawing.Point(704, 3);
            this.splitterPicture.Name = "splitterPicture";
            this.splitterPicture.Size = new System.Drawing.Size(3, 599);
            this.splitterPicture.TabIndex = 2;
            this.splitterPicture.TabStop = false;
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttribute,
            this.colValue});
            this.listResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listResult.FullRowSelect = true;
            this.listResult.Location = new System.Drawing.Point(0, 237);
            this.listResult.MultiSelect = false;
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(287, 362);
            this.listResult.TabIndex = 8;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            this.listResult.DoubleClick += new System.EventHandler(this.listResult_DoubleClick);
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
            // panelResultHeader
            // 
            this.panelResultHeader.Controls.Add(this.btnCancel);
            this.panelResultHeader.Controls.Add(this.btnApplyMap);
            this.panelResultHeader.Controls.Add(this.label3);
            this.panelResultHeader.Controls.Add(this.txtAnchorText);
            this.panelResultHeader.Controls.Add(this.label2);
            this.panelResultHeader.Controls.Add(this.txtLineValue);
            this.panelResultHeader.Controls.Add(this.label1);
            this.panelResultHeader.Controls.Add(this.txtLineText);
            this.panelResultHeader.Controls.Add(this.lblInstructions);
            this.panelResultHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelResultHeader.Location = new System.Drawing.Point(0, 0);
            this.panelResultHeader.Name = "panelResultHeader";
            this.panelResultHeader.Size = new System.Drawing.Size(287, 237);
            this.panelResultHeader.TabIndex = 9;
            // 
            // lblMouseCoordinates
            // 
            this.lblMouseCoordinates.Name = "lblMouseCoordinates";
            this.lblMouseCoordinates.Size = new System.Drawing.Size(118, 17);
            this.lblMouseCoordinates.Text = "toolStripStatusLabel1";
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Blue;
            this.lblInstructions.Location = new System.Drawing.Point(6, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(276, 75);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Waiting for results";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLineText
            // 
            this.txtLineText.Location = new System.Drawing.Point(9, 91);
            this.txtLineText.Name = "txtLineText";
            this.txtLineText.ReadOnly = true;
            this.txtLineText.Size = new System.Drawing.Size(273, 20);
            this.txtLineText.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 75);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(51, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Item Text";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 118);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(57, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Item Value";
            // 
            // txtLineValue
            // 
            this.txtLineValue.Location = new System.Drawing.Point(9, 134);
            this.txtLineValue.Name = "txtLineValue";
            this.txtLineValue.ReadOnly = true;
            this.txtLineValue.Size = new System.Drawing.Size(273, 20);
            this.txtLineValue.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 166);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Anchor Text";
            // 
            // txtAnchorText
            // 
            this.txtAnchorText.Location = new System.Drawing.Point(9, 182);
            this.txtAnchorText.Name = "txtAnchorText";
            this.txtAnchorText.ReadOnly = true;
            this.txtAnchorText.Size = new System.Drawing.Size(273, 20);
            this.txtAnchorText.TabIndex = 5;
            // 
            // btnApplyMap
            // 
            this.btnApplyMap.Enabled = false;
            this.btnApplyMap.Location = new System.Drawing.Point(187, 208);
            this.btnApplyMap.Name = "btnApplyMap";
            this.btnApplyMap.Size = new System.Drawing.Size(95, 23);
            this.btnApplyMap.TabIndex = 7;
            this.btnApplyMap.Text = "Apply Mapping";
            this.btnApplyMap.UseVisualStyleBackColor = true;
            this.btnApplyMap.Click += new System.EventHandler(this.btnApplyMap_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(120, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(61, 23);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1008, 743);
            this.Controls.Add(this.mainTab);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.mainMenu);
            this.MainMenuStrip = this.mainMenu;
            this.Name = "MainForm";
            this.Text = "Ocr Tool";
            this.mainMenu.ResumeLayout(false);
            this.mainMenu.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.mainTab.ResumeLayout(false);
            this.tabPicture.ResumeLayout(false);
            this.panelPicture.ResumeLayout(false);
            this.panelPicture.PerformLayout();
            this.tabResult.ResumeLayout(false);
            this.tabVision.ResumeLayout(false);
            this.tabText.ResumeLayout(false);
            this.tabText.PerformLayout();
            this.tabVisionJson.ResumeLayout(false);
            this.grpResults.ResumeLayout(false);
            this.grpResults.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.panelResult.ResumeLayout(false);
            this.panelResultHeader.ResumeLayout(false);
            this.panelResultHeader.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem customizeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtLineValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtLineText;
        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Button btnApplyMap;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAnchorText;
        private System.Windows.Forms.Button btnCancel;
    }
}

