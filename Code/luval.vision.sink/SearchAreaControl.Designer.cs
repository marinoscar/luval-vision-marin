
namespace luval.vision.app
{
    partial class SearchAreaControl
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
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtX = new System.Windows.Forms.TextBox();
            this.ocrRelativeSearchLocationBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.txtTopX = new System.Windows.Forms.TextBox();
            this.txtY = new System.Windows.Forms.TextBox();
            this.txtTopY = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.table1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ocrRelativeSearchLocationBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // table1
            // 
            this.table1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.table1.ColumnCount = 4;
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.table1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table1.Controls.Add(this.label4, 2, 1);
            this.table1.Controls.Add(this.label3, 0, 1);
            this.table1.Controls.Add(this.label2, 2, 0);
            this.table1.Controls.Add(this.txtX, 1, 0);
            this.table1.Controls.Add(this.txtTopX, 3, 0);
            this.table1.Controls.Add(this.txtY, 1, 1);
            this.table1.Controls.Add(this.txtTopY, 3, 1);
            this.table1.Controls.Add(this.label1, 0, 0);
            this.table1.Location = new System.Drawing.Point(3, 29);
            this.table1.Name = "table1";
            this.table1.RowCount = 2;
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.table1.Size = new System.Drawing.Size(564, 53);
            this.table1.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label4.Location = new System.Drawing.Point(285, 26);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 27);
            this.label4.TabIndex = 7;
            this.label4.Text = "Relative Top Y";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label3.Location = new System.Drawing.Point(3, 26);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(94, 27);
            this.label3.TabIndex = 6;
            this.label3.Text = "Relative Y";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label2.Location = new System.Drawing.Point(285, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 26);
            this.label2.TabIndex = 5;
            this.label2.Text = "Relative Top X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtX
            // 
            this.txtX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ocrRelativeSearchLocationBindingSource, "X", true));
            this.txtX.Dock = System.Windows.Forms.DockStyle.Top;
            this.txtX.Location = new System.Drawing.Point(103, 3);
            this.txtX.Name = "txtX";
            this.txtX.Size = new System.Drawing.Size(176, 20);
            this.txtX.TabIndex = 0;
            this.txtX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // ocrRelativeSearchLocationBindingSource
            // 
            this.ocrRelativeSearchLocationBindingSource.DataSource = typeof(luval.vision.core.OcrRelativeSearchLocation);
            // 
            // txtTopX
            // 
            this.txtTopX.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ocrRelativeSearchLocationBindingSource, "XBound", true));
            this.txtTopX.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopX.Location = new System.Drawing.Point(385, 3);
            this.txtTopX.Name = "txtTopX";
            this.txtTopX.Size = new System.Drawing.Size(176, 20);
            this.txtTopX.TabIndex = 1;
            this.txtTopX.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // txtY
            // 
            this.txtY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ocrRelativeSearchLocationBindingSource, "Y", true));
            this.txtY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtY.Location = new System.Drawing.Point(103, 29);
            this.txtY.Name = "txtY";
            this.txtY.Size = new System.Drawing.Size(176, 20);
            this.txtY.TabIndex = 2;
            this.txtY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // txtTopY
            // 
            this.txtTopY.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.ocrRelativeSearchLocationBindingSource, "Y", true));
            this.txtTopY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtTopY.Location = new System.Drawing.Point(385, 29);
            this.txtTopY.Name = "txtTopY";
            this.txtTopY.Size = new System.Drawing.Size(176, 20);
            this.txtTopY.TabIndex = 3;
            this.txtTopY.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Text_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Location = new System.Drawing.Point(3, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 26);
            this.label1.TabIndex = 4;
            this.label1.Text = "Relative X";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.Location = new System.Drawing.Point(6, 2);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(558, 23);
            this.label5.TabIndex = 1;
            this.label5.Text = "Enter the relative location of the area to evaluate";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTest
            // 
            this.btnTest.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTest.Location = new System.Drawing.Point(481, 88);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(86, 24);
            this.btnTest.TabIndex = 2;
            this.btnTest.Text = "Show Area";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // SearchAreaControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnTest);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.table1);
            this.Name = "SearchAreaControl";
            this.Size = new System.Drawing.Size(570, 118);
            this.table1.ResumeLayout(false);
            this.table1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ocrRelativeSearchLocationBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel table1;
        private System.Windows.Forms.TextBox txtX;
        private System.Windows.Forms.TextBox txtTopX;
        private System.Windows.Forms.TextBox txtY;
        private System.Windows.Forms.TextBox txtTopY;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.BindingSource ocrRelativeSearchLocationBindingSource;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnTest;
    }
}
