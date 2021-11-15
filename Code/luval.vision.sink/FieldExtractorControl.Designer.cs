
namespace luval.vision.app
{
    partial class FieldExtractorControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.table2 = new System.Windows.Forms.TableLayoutPanel();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.fieldExtractorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtExpected = new System.Windows.Forms.NumericUpDown();
            this.table3 = new System.Windows.Forms.TableLayoutPanel();
            this.label4 = new System.Windows.Forms.Label();
            this.chkArea = new System.Windows.Forms.CheckBox();
            this.externalOptions1 = new luval.vision.app.ExternalOptions();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabExtractor = new System.Windows.Forms.TabPage();
            this.extractorData = new luval.vision.app.ExternalOptions();
            this.tabProcessor = new System.Windows.Forms.TabPage();
            this.postProccesor = new luval.vision.app.ExternalOptions();
            this.table2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldExtractorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpected)).BeginInit();
            this.table3.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabExtractor.SuspendLayout();
            this.tabProcessor.SuspendLayout();
            this.SuspendLayout();
            // 
            // table2
            // 
            this.table2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table2.ColumnCount = 2;
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table2.Controls.Add(this.label3, 1, 0);
            this.table2.Controls.Add(this.label2, 0, 0);
            this.table2.Controls.Add(this.checkBox1, 0, 1);
            this.table2.Controls.Add(this.txtExpected, 1, 1);
            this.table2.Location = new System.Drawing.Point(0, 2);
            this.table2.Name = "table2";
            this.table2.RowCount = 2;
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table2.Size = new System.Drawing.Size(434, 51);
            this.table2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(220, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(211, 25);
            this.label3.TabIndex = 3;
            this.label3.Text = "Expected Index";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(211, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Use Last";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.fieldExtractorBindingSource, "UseLast", true));
            this.checkBox1.Location = new System.Drawing.Point(3, 28);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // fieldExtractorBindingSource
            // 
            this.fieldExtractorBindingSource.DataSource = typeof(luval.vision.core.FieldExtractor);
            // 
            // txtExpected
            // 
            this.txtExpected.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fieldExtractorBindingSource, "ExpectedIndex", true));
            this.txtExpected.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpected.Location = new System.Drawing.Point(220, 28);
            this.txtExpected.Name = "txtExpected";
            this.txtExpected.Size = new System.Drawing.Size(211, 20);
            this.txtExpected.TabIndex = 4;
            // 
            // table3
            // 
            this.table3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table3.ColumnCount = 2;
            this.table3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table3.Controls.Add(this.label4, 0, 0);
            this.table3.Controls.Add(this.chkArea, 0, 1);
            this.table3.Location = new System.Drawing.Point(-2, 55);
            this.table3.Name = "table3";
            this.table3.RowCount = 2;
            this.table3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table3.Size = new System.Drawing.Size(437, 54);
            this.table3.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(3, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 27);
            this.label4.TabIndex = 2;
            this.label4.Text = "Use All Area";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkArea
            // 
            this.chkArea.AutoSize = true;
            this.chkArea.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.fieldExtractorBindingSource, "UseAllArea", true));
            this.chkArea.Location = new System.Drawing.Point(3, 30);
            this.chkArea.Name = "chkArea";
            this.chkArea.Size = new System.Drawing.Size(15, 14);
            this.chkArea.TabIndex = 3;
            this.chkArea.UseVisualStyleBackColor = true;
            // 
            // externalOptions1
            // 
            this.externalOptions1.Location = new System.Drawing.Point(0, 0);
            this.externalOptions1.Name = "externalOptions1";
            this.externalOptions1.NameLabel = "Name";
            this.externalOptions1.Size = new System.Drawing.Size(518, 150);
            this.externalOptions1.TabIndex = 0;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl.Controls.Add(this.tabExtractor);
            this.tabControl.Controls.Add(this.tabProcessor);
            this.tabControl.Location = new System.Drawing.Point(1, 111);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(436, 223);
            this.tabControl.TabIndex = 4;
            // 
            // tabExtractor
            // 
            this.tabExtractor.Controls.Add(this.extractorData);
            this.tabExtractor.Location = new System.Drawing.Point(4, 22);
            this.tabExtractor.Name = "tabExtractor";
            this.tabExtractor.Padding = new System.Windows.Forms.Padding(3);
            this.tabExtractor.Size = new System.Drawing.Size(428, 197);
            this.tabExtractor.TabIndex = 0;
            this.tabExtractor.Text = "Extractor";
            this.tabExtractor.UseVisualStyleBackColor = true;
            // 
            // extractorData
            // 
            this.extractorData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.extractorData.Location = new System.Drawing.Point(3, 3);
            this.extractorData.Name = "extractorData";
            this.extractorData.NameLabel = "Extractor Name";
            this.extractorData.Size = new System.Drawing.Size(422, 191);
            this.extractorData.TabIndex = 4;
            this.extractorData.DataChanged += new luval.vision.app.ExternalOptions.DataChangedEventHandler(this.extractorData_DataChanged);
            // 
            // tabProcessor
            // 
            this.tabProcessor.Controls.Add(this.postProccesor);
            this.tabProcessor.Location = new System.Drawing.Point(4, 22);
            this.tabProcessor.Name = "tabProcessor";
            this.tabProcessor.Padding = new System.Windows.Forms.Padding(3);
            this.tabProcessor.Size = new System.Drawing.Size(428, 197);
            this.tabProcessor.TabIndex = 1;
            this.tabProcessor.Text = "PostProcessor";
            this.tabProcessor.UseVisualStyleBackColor = true;
            // 
            // postProccesor
            // 
            this.postProccesor.Dock = System.Windows.Forms.DockStyle.Fill;
            this.postProccesor.Location = new System.Drawing.Point(3, 3);
            this.postProccesor.Name = "postProccesor";
            this.postProccesor.NameLabel = "Processor Qualified Name";
            this.postProccesor.Size = new System.Drawing.Size(422, 191);
            this.postProccesor.TabIndex = 0;
            this.postProccesor.DataChanged += new luval.vision.app.ExternalOptions.DataChangedEventHandler(this.postProccesor_DataChanged);
            // 
            // FieldExtractorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.table3);
            this.Controls.Add(this.table2);
            this.Name = "FieldExtractorControl";
            this.Size = new System.Drawing.Size(437, 333);
            this.Load += new System.EventHandler(this.FieldExtractorControl_Load);
            this.table2.ResumeLayout(false);
            this.table2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldExtractorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpected)).EndInit();
            this.table3.ResumeLayout(false);
            this.table3.PerformLayout();
            this.tabControl.ResumeLayout(false);
            this.tabExtractor.ResumeLayout(false);
            this.tabProcessor.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table2;
        private System.Windows.Forms.TableLayoutPanel table3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.NumericUpDown txtExpected;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.CheckBox chkArea;
        private ExternalOptions externalOptions1;
        private System.Windows.Forms.BindingSource fieldExtractorBindingSource;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabExtractor;
        private ExternalOptions extractorData;
        private System.Windows.Forms.TabPage tabProcessor;
        private ExternalOptions postProccesor;
    }
}
