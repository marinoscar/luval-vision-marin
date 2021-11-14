
namespace luval.vision.app
{
    partial class ExternalOptions
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
            this.table1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.externalCallAndOptionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.optionsBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.grpBox = new System.Windows.Forms.GroupBox();
            this.optionsGrid = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.valueDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.table1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.externalCallAndOptionsBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBindingSource)).BeginInit();
            this.grpBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.optionsGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.ColumnCount = 2;
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.Controls.Add(this.lblName, 0, 0);
            this.table1.Controls.Add(this.txtName, 1, 0);
            this.table1.Dock = System.Windows.Forms.DockStyle.Top;
            this.table1.Location = new System.Drawing.Point(0, 0);
            this.table1.Name = "table1";
            this.table1.RowCount = 1;
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            this.table1.Size = new System.Drawing.Size(518, 27);
            this.table1.TabIndex = 0;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Dock = System.Windows.Forms.DockStyle.Left;
            this.lblName.Location = new System.Drawing.Point(3, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 27);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Name";
            this.lblName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtName
            // 
            this.txtName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.externalCallAndOptionsBindingSource, "Name", true));
            this.txtName.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtName.Location = new System.Drawing.Point(44, 3);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(471, 20);
            this.txtName.TabIndex = 1;
            // 
            // externalCallAndOptionsBindingSource
            // 
            this.externalCallAndOptionsBindingSource.DataSource = typeof(luval.vision.app.ExternalCallAndOptions);
            this.externalCallAndOptionsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.externalCallAndOptionsBindingSource_ListChanged);
            // 
            // optionsBindingSource
            // 
            this.optionsBindingSource.DataMember = "Options";
            this.optionsBindingSource.DataSource = this.externalCallAndOptionsBindingSource;
            this.optionsBindingSource.ListChanged += new System.ComponentModel.ListChangedEventHandler(this.optionsBindingSource_ListChanged);
            // 
            // grpBox
            // 
            this.grpBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.grpBox.Controls.Add(this.optionsGrid);
            this.grpBox.Location = new System.Drawing.Point(6, 33);
            this.grpBox.Name = "grpBox";
            this.grpBox.Size = new System.Drawing.Size(509, 219);
            this.grpBox.TabIndex = 1;
            this.grpBox.TabStop = false;
            this.grpBox.Text = "Options";
            // 
            // optionsGrid
            // 
            this.optionsGrid.AutoGenerateColumns = false;
            this.optionsGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.optionsGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.valueDataGridViewTextBoxColumn});
            this.optionsGrid.DataSource = this.optionsBindingSource;
            this.optionsGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.optionsGrid.Location = new System.Drawing.Point(3, 16);
            this.optionsGrid.Name = "optionsGrid";
            this.optionsGrid.Size = new System.Drawing.Size(503, 200);
            this.optionsGrid.TabIndex = 2;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            // 
            // valueDataGridViewTextBoxColumn
            // 
            this.valueDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.valueDataGridViewTextBoxColumn.DataPropertyName = "Value";
            this.valueDataGridViewTextBoxColumn.HeaderText = "Value";
            this.valueDataGridViewTextBoxColumn.Name = "valueDataGridViewTextBoxColumn";
            // 
            // ExternalOptions
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.grpBox);
            this.Controls.Add(this.table1);
            this.Name = "ExternalOptions";
            this.Size = new System.Drawing.Size(518, 255);
            this.table1.ResumeLayout(false);
            this.table1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.externalCallAndOptionsBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.optionsBindingSource)).EndInit();
            this.grpBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.optionsGrid)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table1;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.BindingSource externalCallAndOptionsBindingSource;
        private System.Windows.Forms.BindingSource optionsBindingSource;
        private System.Windows.Forms.GroupBox grpBox;
        private System.Windows.Forms.DataGridView optionsGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueDataGridViewTextBoxColumn;
    }
}
