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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.mainMenu = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSaveResult = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitMenu = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExtractFormValues = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuLoadConfiguration = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuRunOCR = new System.Windows.Forms.ToolStripMenuItem();
            this.extractFormValuesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExportToExcel = new System.Windows.Forms.ToolStripMenuItem();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chkOcrResult = new System.Windows.Forms.CheckBox();
            this.btnDemo = new System.Windows.Forms.Button();
            this.processBtn = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.mainTab = new System.Windows.Forms.TabControl();
            this.tabPicture = new System.Windows.Forms.TabPage();
            this.panelPicture = new System.Windows.Forms.Panel();
            this.tabResult = new System.Windows.Forms.TabPage();
            this.tabVision = new System.Windows.Forms.TabControl();
            this.tabText = new System.Windows.Forms.TabPage();
            this.resultText = new System.Windows.Forms.TextBox();
            this.cmenText = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.mnuTextCopy = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSelectAllTxt = new System.Windows.Forms.ToolStripMenuItem();
            this.tabVisionJson = new System.Windows.Forms.TabPage();
            this.treeJsonVision = new System.Windows.Forms.TreeView();
            this.listResult = new System.Windows.Forms.ListView();
            this.colAttribute = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnuDrawArea = new System.Windows.Forms.ToolStripMenuItem();
            this.mainMenu.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.mainTab.SuspendLayout();
            this.tabPicture.SuspendLayout();
            this.panelPicture.SuspendLayout();
            this.tabResult.SuspendLayout();
            this.tabVision.SuspendLayout();
            this.tabText.SuspendLayout();
            this.cmenText.SuspendLayout();
            this.tabVisionJson.SuspendLayout();
            this.SuspendLayout();
            // 
            // mainMenu
            // 
            this.mainMenu.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.mainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.mnuExtractFormValues});
            this.mainMenu.Location = new System.Drawing.Point(0, 0);
            this.mainMenu.Name = "mainMenu";
            this.mainMenu.Size = new System.Drawing.Size(832, 24);
            this.mainMenu.TabIndex = 0;
            this.mainMenu.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openMenu,
            this.mnuSaveResult,
            this.toolStripSeparator1,
            this.exitMenu});
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
            // mnuExtractFormValues
            // 
            this.mnuExtractFormValues.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuLoadConfiguration,
            this.mnuRunOCR,
            this.extractFormValuesToolStripMenuItem,
            this.mnuExportToExcel,
            this.mnuDrawArea});
            this.mnuExtractFormValues.Name = "mnuExtractFormValues";
            this.mnuExtractFormValues.Size = new System.Drawing.Size(46, 20);
            this.mnuExtractFormValues.Text = "&Tools";
            // 
            // mnuLoadConfiguration
            // 
            this.mnuLoadConfiguration.Name = "mnuLoadConfiguration";
            this.mnuLoadConfiguration.Size = new System.Drawing.Size(180, 22);
            this.mnuLoadConfiguration.Text = "&Load Configuration";
            this.mnuLoadConfiguration.Click += new System.EventHandler(this.mnuLoadConfiguration_Click);
            // 
            // mnuRunOCR
            // 
            this.mnuRunOCR.Name = "mnuRunOCR";
            this.mnuRunOCR.Size = new System.Drawing.Size(180, 22);
            this.mnuRunOCR.Text = "Run OCR";
            this.mnuRunOCR.Click += new System.EventHandler(this.mnuRunOCR_Click);
            // 
            // extractFormValuesToolStripMenuItem
            // 
            this.extractFormValuesToolStripMenuItem.Name = "extractFormValuesToolStripMenuItem";
            this.extractFormValuesToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.extractFormValuesToolStripMenuItem.Text = "Extract Form Values";
            this.extractFormValuesToolStripMenuItem.Click += new System.EventHandler(this.extractFormValuesToolStripMenuItem_Click);
            // 
            // mnuExportToExcel
            // 
            this.mnuExportToExcel.Name = "mnuExportToExcel";
            this.mnuExportToExcel.Size = new System.Drawing.Size(180, 22);
            this.mnuExportToExcel.Text = "Export To Excel";
            this.mnuExportToExcel.Click += new System.EventHandler(this.mnuExportToExcel_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.chkOcrResult);
            this.panel1.Controls.Add(this.btnDemo);
            this.panel1.Controls.Add(this.processBtn);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 547);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(832, 50);
            this.panel1.TabIndex = 1;
            // 
            // chkOcrResult
            // 
            this.chkOcrResult.AutoSize = true;
            this.chkOcrResult.Location = new System.Drawing.Point(12, 16);
            this.chkOcrResult.Name = "chkOcrResult";
            this.chkOcrResult.Size = new System.Drawing.Size(112, 17);
            this.chkOcrResult.TabIndex = 2;
            this.chkOcrResult.Text = "Show OCR Result";
            this.chkOcrResult.UseVisualStyleBackColor = true;
            this.chkOcrResult.CheckedChanged += new System.EventHandler(this.chkOcrResult_CheckedChanged);
            // 
            // btnDemo
            // 
            this.btnDemo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDemo.Location = new System.Drawing.Point(664, 12);
            this.btnDemo.Name = "btnDemo";
            this.btnDemo.Size = new System.Drawing.Size(75, 23);
            this.btnDemo.TabIndex = 1;
            this.btnDemo.Text = "&Demo";
            this.btnDemo.UseVisualStyleBackColor = true;
            this.btnDemo.Visible = false;
            this.btnDemo.Click += new System.EventHandler(this.btnDemo_Click);
            // 
            // processBtn
            // 
            this.processBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.processBtn.Location = new System.Drawing.Point(745, 12);
            this.processBtn.Name = "processBtn";
            this.processBtn.Size = new System.Drawing.Size(75, 23);
            this.processBtn.TabIndex = 0;
            this.processBtn.Text = "Process";
            this.processBtn.UseVisualStyleBackColor = true;
            this.processBtn.Visible = false;
            this.processBtn.Click += new System.EventHandler(this.processBtn_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(815, 445);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            this.pictureBox.DoubleClick += new System.EventHandler(this.pictureBox_DoubleClick);
            this.pictureBox.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.pictureBox_MouseDoubleClick);
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 24);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 523);
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
            this.mainTab.Size = new System.Drawing.Size(829, 523);
            this.mainTab.TabIndex = 6;
            // 
            // tabPicture
            // 
            this.tabPicture.Controls.Add(this.panelPicture);
            this.tabPicture.Location = new System.Drawing.Point(4, 22);
            this.tabPicture.Name = "tabPicture";
            this.tabPicture.Padding = new System.Windows.Forms.Padding(3);
            this.tabPicture.Size = new System.Drawing.Size(821, 497);
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
            this.panelPicture.Size = new System.Drawing.Size(815, 491);
            this.panelPicture.TabIndex = 0;
            // 
            // tabResult
            // 
            this.tabResult.Controls.Add(this.tabVision);
            this.tabResult.Controls.Add(this.listResult);
            this.tabResult.Location = new System.Drawing.Point(4, 22);
            this.tabResult.Name = "tabResult";
            this.tabResult.Padding = new System.Windows.Forms.Padding(3);
            this.tabResult.Size = new System.Drawing.Size(821, 497);
            this.tabResult.TabIndex = 1;
            this.tabResult.Text = "Results";
            this.tabResult.UseVisualStyleBackColor = true;
            // 
            // tabVision
            // 
            this.tabVision.Controls.Add(this.tabText);
            this.tabVision.Controls.Add(this.tabVisionJson);
            this.tabVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabVision.Location = new System.Drawing.Point(288, 3);
            this.tabVision.Name = "tabVision";
            this.tabVision.SelectedIndex = 0;
            this.tabVision.Size = new System.Drawing.Size(530, 491);
            this.tabVision.TabIndex = 5;
            // 
            // tabText
            // 
            this.tabText.Controls.Add(this.resultText);
            this.tabText.Location = new System.Drawing.Point(4, 22);
            this.tabText.Name = "tabText";
            this.tabText.Padding = new System.Windows.Forms.Padding(3);
            this.tabText.Size = new System.Drawing.Size(522, 465);
            this.tabText.TabIndex = 0;
            this.tabText.Text = "Text";
            this.tabText.UseVisualStyleBackColor = true;
            // 
            // resultText
            // 
            this.resultText.ContextMenuStrip = this.cmenText;
            this.resultText.Dock = System.Windows.Forms.DockStyle.Fill;
            this.resultText.Font = new System.Drawing.Font("Courier New", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.resultText.Location = new System.Drawing.Point(3, 3);
            this.resultText.Multiline = true;
            this.resultText.Name = "resultText";
            this.resultText.Size = new System.Drawing.Size(516, 459);
            this.resultText.TabIndex = 5;
            // 
            // cmenText
            // 
            this.cmenText.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.cmenText.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTextCopy,
            this.mnuSelectAllTxt});
            this.cmenText.Name = "cmenText";
            this.cmenText.Size = new System.Drawing.Size(165, 48);
            // 
            // mnuTextCopy
            // 
            this.mnuTextCopy.Name = "mnuTextCopy";
            this.mnuTextCopy.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.mnuTextCopy.Size = new System.Drawing.Size(164, 22);
            this.mnuTextCopy.Text = "Copy";
            this.mnuTextCopy.Click += new System.EventHandler(this.mnuTextCopy_Click);
            // 
            // mnuSelectAllTxt
            // 
            this.mnuSelectAllTxt.Name = "mnuSelectAllTxt";
            this.mnuSelectAllTxt.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.mnuSelectAllTxt.Size = new System.Drawing.Size(164, 22);
            this.mnuSelectAllTxt.Text = "Select All";
            this.mnuSelectAllTxt.Click += new System.EventHandler(this.mnuSelectAllTxt_Click);
            // 
            // tabVisionJson
            // 
            this.tabVisionJson.Controls.Add(this.treeJsonVision);
            this.tabVisionJson.Location = new System.Drawing.Point(4, 22);
            this.tabVisionJson.Name = "tabVisionJson";
            this.tabVisionJson.Padding = new System.Windows.Forms.Padding(3);
            this.tabVisionJson.Size = new System.Drawing.Size(522, 465);
            this.tabVisionJson.TabIndex = 1;
            this.tabVisionJson.Text = "Vision";
            this.tabVisionJson.UseVisualStyleBackColor = true;
            // 
            // treeJsonVision
            // 
            this.treeJsonVision.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeJsonVision.Location = new System.Drawing.Point(3, 3);
            this.treeJsonVision.Name = "treeJsonVision";
            this.treeJsonVision.Size = new System.Drawing.Size(516, 459);
            this.treeJsonVision.TabIndex = 0;
            // 
            // listResult
            // 
            this.listResult.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.colAttribute,
            this.colValue});
            this.listResult.Dock = System.Windows.Forms.DockStyle.Left;
            this.listResult.HideSelection = false;
            this.listResult.Location = new System.Drawing.Point(3, 3);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(285, 491);
            this.listResult.TabIndex = 6;
            this.listResult.UseCompatibleStateImageBehavior = false;
            this.listResult.View = System.Windows.Forms.View.Details;
            // 
            // colAttribute
            // 
            this.colAttribute.Text = "Attribute";
            // 
            // colValue
            // 
            this.colValue.Text = "Value";
            // 
            // mnuDrawArea
            // 
            this.mnuDrawArea.Name = "mnuDrawArea";
            this.mnuDrawArea.Size = new System.Drawing.Size(180, 22);
            this.mnuDrawArea.Text = "Draw Area";
            this.mnuDrawArea.Click += new System.EventHandler(this.mnuDrawArea_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(832, 597);
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
            this.cmenText.ResumeLayout(false);
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
        private System.Windows.Forms.ToolStripMenuItem mnuExtractFormValues;
        private System.Windows.Forms.ToolStripMenuItem mnuLoadConfiguration;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button processBtn;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Splitter splitter1;
        private System.Windows.Forms.TabControl mainTab;
        private System.Windows.Forms.TabPage tabPicture;
        private System.Windows.Forms.Panel panelPicture;
        private System.Windows.Forms.TabPage tabResult;
        private System.Windows.Forms.Button btnDemo;
        private System.Windows.Forms.TabControl tabVision;
        private System.Windows.Forms.TabPage tabText;
        private System.Windows.Forms.TextBox resultText;
        private System.Windows.Forms.TabPage tabVisionJson;
        private System.Windows.Forms.TreeView treeJsonVision;
        private System.Windows.Forms.ListView listResult;
        private System.Windows.Forms.ColumnHeader colAttribute;
        private System.Windows.Forms.ColumnHeader colValue;
        private System.Windows.Forms.CheckBox chkOcrResult;
        private System.Windows.Forms.ToolStripMenuItem mnuSaveResult;
        private System.Windows.Forms.ContextMenuStrip cmenText;
        private System.Windows.Forms.ToolStripMenuItem mnuTextCopy;
        private System.Windows.Forms.ToolStripMenuItem mnuSelectAllTxt;
        private System.Windows.Forms.ToolStripMenuItem mnuRunOCR;
        private System.Windows.Forms.ToolStripMenuItem extractFormValuesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuExportToExcel;
        private System.Windows.Forms.ToolStripMenuItem mnuDrawArea;
    }
}

