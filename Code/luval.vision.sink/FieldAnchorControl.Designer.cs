
namespace luval.vision.app
{
    partial class FieldAnchorControl
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkUseLast = new System.Windows.Forms.CheckBox();
            this.fieldAnchorBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtExpectedIndex = new System.Windows.Forms.NumericUpDown();
            this.patternGrid = new System.Windows.Forms.DataGridView();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.stringForGridBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldAnchorBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpectedIndex)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternGrid)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stringForGridBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.chkUseLast, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtExpectedIndex, 1, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(364, 51);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(185, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(176, 25);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expected Index";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Use Last";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkUseLast
            // 
            this.chkUseLast.AutoSize = true;
            this.chkUseLast.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.fieldAnchorBindingSource, "UseLast", true));
            this.chkUseLast.Location = new System.Drawing.Point(3, 28);
            this.chkUseLast.Name = "chkUseLast";
            this.chkUseLast.Size = new System.Drawing.Size(15, 14);
            this.chkUseLast.TabIndex = 2;
            this.chkUseLast.UseVisualStyleBackColor = true;
            // 
            // fieldAnchorBindingSource
            // 
            this.fieldAnchorBindingSource.DataSource = typeof(luval.vision.core.FieldAnchor);
            // 
            // txtExpectedIndex
            // 
            this.txtExpectedIndex.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.fieldAnchorBindingSource, "ExpectedIndex", true));
            this.txtExpectedIndex.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtExpectedIndex.Location = new System.Drawing.Point(185, 28);
            this.txtExpectedIndex.Name = "txtExpectedIndex";
            this.txtExpectedIndex.Size = new System.Drawing.Size(176, 20);
            this.txtExpectedIndex.TabIndex = 3;
            // 
            // patternGrid
            // 
            this.patternGrid.AutoGenerateColumns = false;
            this.patternGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.patternGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.valueDataGridViewTextBoxColumn});
            this.patternGrid.DataSource = this.stringForGridBindingSource;
            this.patternGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.patternGrid.Location = new System.Drawing.Point(0, 51);
            this.patternGrid.Name = "patternGrid";
            this.patternGrid.Size = new System.Drawing.Size(364, 144);
            this.patternGrid.TabIndex = 1;
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Pattern";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // stringForGridBindingSource
            // 
            this.stringForGridBindingSource.DataSource = typeof(luval.vision.app.StringForGrid);
            this.stringForGridBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.stringForGridBindingSource_ListChanged);
            // 
            // FieldAnchorControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.patternGrid);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "FieldAnchorControl";
            this.Size = new System.Drawing.Size(364, 195);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.fieldAnchorBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.txtExpectedIndex)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.patternGrid)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stringForGridBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox chkUseLast;
        private System.Windows.Forms.NumericUpDown txtExpectedIndex;
        private System.Windows.Forms.BindingSource fieldAnchorBindingSource;
        private System.Windows.Forms.DataGridView patternGrid;
        private System.Windows.Forms.BindingSource stringForGridBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}
