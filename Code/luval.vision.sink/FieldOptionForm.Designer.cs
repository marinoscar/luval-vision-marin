
namespace luval.vision.app
{
    partial class FieldOptionForm
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
            luval.vision.core.FieldAnchor fieldAnchor1 = new luval.vision.core.FieldAnchor();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FieldOptionForm));
            luval.vision.core.FieldExtractor fieldExtractor1 = new luval.vision.core.FieldExtractor();
            luval.vision.core.OcrRelativeSearchLocation ocrRelativeSearchLocation1 = new luval.vision.core.OcrRelativeSearchLocation();
            this.table1 = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtFieldName = new System.Windows.Forms.TextBox();
            this.fieldOptionBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tabOptions = new System.Windows.Forms.TabControl();
            this.tabAnchor = new System.Windows.Forms.TabPage();
            this.anchorControl = new luval.vision.app.FieldAnchorControl();
            this.tabExtractor = new System.Windows.Forms.TabPage();
            this.extractorControl = new luval.vision.app.FieldExtractorControl();
            this.tabArea = new System.Windows.Forms.TabPage();
            this.searchAreaControl1 = new luval.vision.app.SearchAreaControl();
            this.tabLineResolver = new System.Windows.Forms.TabPage();
            this.btnOk = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lineResolverControl1 = new luval.vision.app.LineResolverControl();
            this.table1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOptionBindingSource)).BeginInit();
            this.tabOptions.SuspendLayout();
            this.tabAnchor.SuspendLayout();
            this.tabExtractor.SuspendLayout();
            this.tabArea.SuspendLayout();
            this.tabLineResolver.SuspendLayout();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table1.ColumnCount = 2;
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.Controls.Add(this.label1, 0, 0);
            this.table1.Controls.Add(this.txtFieldName, 1, 0);
            this.table1.Location = new System.Drawing.Point(12, 12);
            this.table1.Name = "table1";
            this.table1.RowCount = 1;
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 26F));
            this.table1.Size = new System.Drawing.Size(776, 26);
            this.table1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 26);
            this.label1.TabIndex = 0;
            this.label1.Text = "Field Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtFieldName
            // 
            this.txtFieldName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.fieldOptionBindingSource, "FieldName", true));
            this.txtFieldName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFieldName.Location = new System.Drawing.Point(72, 3);
            this.txtFieldName.Name = "txtFieldName";
            this.txtFieldName.Size = new System.Drawing.Size(701, 20);
            this.txtFieldName.TabIndex = 1;
            // 
            // fieldOptionBindingSource
            // 
            this.fieldOptionBindingSource.DataSource = typeof(luval.vision.core.FieldOption);
            // 
            // tabOptions
            // 
            this.tabOptions.Controls.Add(this.tabAnchor);
            this.tabOptions.Controls.Add(this.tabExtractor);
            this.tabOptions.Controls.Add(this.tabArea);
            this.tabOptions.Controls.Add(this.tabLineResolver);
            this.tabOptions.Location = new System.Drawing.Point(12, 44);
            this.tabOptions.Name = "tabOptions";
            this.tabOptions.SelectedIndex = 0;
            this.tabOptions.Size = new System.Drawing.Size(773, 367);
            this.tabOptions.TabIndex = 1;
            // 
            // tabAnchor
            // 
            this.tabAnchor.Controls.Add(this.anchorControl);
            this.tabAnchor.Location = new System.Drawing.Point(4, 22);
            this.tabAnchor.Name = "tabAnchor";
            this.tabAnchor.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnchor.Size = new System.Drawing.Size(765, 341);
            this.tabAnchor.TabIndex = 0;
            this.tabAnchor.Text = "Anchor";
            this.tabAnchor.UseVisualStyleBackColor = true;
            // 
            // anchorControl
            // 
            fieldAnchor1.ExpectedIndex = 0;
            fieldAnchor1.Patterns = ((System.Collections.Generic.List<string>)(resources.GetObject("fieldAnchor1.Patterns")));
            fieldAnchor1.UseLast = false;
            this.anchorControl.FieldAnchor = fieldAnchor1;
            this.anchorControl.Location = new System.Drawing.Point(21, 22);
            this.anchorControl.Name = "anchorControl";
            this.anchorControl.Size = new System.Drawing.Size(699, 289);
            this.anchorControl.TabIndex = 0;
            // 
            // tabExtractor
            // 
            this.tabExtractor.Controls.Add(this.extractorControl);
            this.tabExtractor.Location = new System.Drawing.Point(4, 22);
            this.tabExtractor.Name = "tabExtractor";
            this.tabExtractor.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtractor.Size = new System.Drawing.Size(765, 341);
            this.tabExtractor.TabIndex = 1;
            this.tabExtractor.Text = "Extractor";
            this.tabExtractor.UseVisualStyleBackColor = true;
            // 
            // extractorControl
            // 
            fieldExtractor1.Direction = Direction.None;
            fieldExtractor1.ExpectedIndex = 0;
            fieldExtractor1.ExtractorName = null;
            fieldExtractor1.ExtractorOptions = ((System.Collections.Generic.Dictionary<string, string>)(resources.GetObject("fieldExtractor1.ExtractorOptions")));
            fieldExtractor1.PostProcessing = null;
            fieldExtractor1.UseAllArea = false;
            fieldExtractor1.UseLast = false;
            this.extractorControl.FieldExtractor = fieldExtractor1;
            this.extractorControl.Location = new System.Drawing.Point(6, 6);
            this.extractorControl.Name = "extractorControl";
            this.extractorControl.Size = new System.Drawing.Size(756, 329);
            this.extractorControl.TabIndex = 0;
            // 
            // tabArea
            // 
            this.tabArea.Controls.Add(this.searchAreaControl1);
            this.tabArea.Location = new System.Drawing.Point(4, 22);
            this.tabArea.Name = "tabArea";
            this.tabArea.Size = new System.Drawing.Size(765, 341);
            this.tabArea.TabIndex = 2;
            this.tabArea.Text = "Area";
            this.tabArea.UseVisualStyleBackColor = true;
            // 
            // searchAreaControl1
            // 
            this.searchAreaControl1.Location = new System.Drawing.Point(3, 3);
            this.searchAreaControl1.Name = "searchAreaControl1";
            ocrRelativeSearchLocation1.X = 0D;
            ocrRelativeSearchLocation1.XBound = 0D;
            ocrRelativeSearchLocation1.Y = 0D;
            ocrRelativeSearchLocation1.YBound = 0D;
            this.searchAreaControl1.SearchLocation = ocrRelativeSearchLocation1;
            this.searchAreaControl1.Size = new System.Drawing.Size(759, 118);
            this.searchAreaControl1.TabIndex = 0;
            // 
            // tabLineResolver
            // 
            this.tabLineResolver.Controls.Add(this.lineResolverControl1);
            this.tabLineResolver.Location = new System.Drawing.Point(4, 22);
            this.tabLineResolver.Name = "tabLineResolver";
            this.tabLineResolver.Size = new System.Drawing.Size(765, 341);
            this.tabLineResolver.TabIndex = 3;
            this.tabLineResolver.Text = "Line Resolver";
            this.tabLineResolver.UseVisualStyleBackColor = true;
            // 
            // btnOk
            // 
            this.btnOk.Location = new System.Drawing.Point(625, 417);
            this.btnOk.Name = "btnOk";
            this.btnOk.Size = new System.Drawing.Size(75, 23);
            this.btnOk.TabIndex = 2;
            this.btnOk.Text = "&Ok";
            this.btnOk.UseVisualStyleBackColor = true;
            this.btnOk.Click += new System.EventHandler(this.btnOk_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(706, 417);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 3;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            // 
            // lineResolverControl1
            // 
            this.lineResolverControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lineResolverControl1.LineResolver = null;
            this.lineResolverControl1.Location = new System.Drawing.Point(0, 0);
            this.lineResolverControl1.Name = "lineResolverControl1";
            this.lineResolverControl1.Size = new System.Drawing.Size(765, 341);
            this.lineResolverControl1.TabIndex = 0;
            // 
            // FieldOptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOk);
            this.Controls.Add(this.tabOptions);
            this.Controls.Add(this.table1);
            this.Name = "FieldOptionForm";
            this.Text = "Field Option";
            this.table1.ResumeLayout(false);
            this.table1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldOptionBindingSource)).EndInit();
            this.tabOptions.ResumeLayout(false);
            this.tabAnchor.ResumeLayout(false);
            this.tabExtractor.ResumeLayout(false);
            this.tabArea.ResumeLayout(false);
            this.tabLineResolver.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtFieldName;
        private System.Windows.Forms.BindingSource fieldOptionBindingSource;
        private System.Windows.Forms.TabControl tabOptions;
        private System.Windows.Forms.TabPage tabAnchor;
        private System.Windows.Forms.TabPage tabExtractor;
        private System.Windows.Forms.TabPage tabArea;
        private System.Windows.Forms.TabPage tabLineResolver;
        private System.Windows.Forms.Button btnOk;
        private System.Windows.Forms.Button btnCancel;
        private FieldExtractorControl extractorControl;
        private FieldAnchorControl anchorControl;
        private SearchAreaControl searchAreaControl1;
        private LineResolverControl lineResolverControl1;
    }
}