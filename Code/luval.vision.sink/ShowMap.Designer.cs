namespace luval.vision.sink
{
    partial class ShowMap
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnchor = new System.Windows.Forms.TextBox();
            this.btnShow = new System.Windows.Forms.Button();
            this.btnShowVal = new System.Windows.Forms.Button();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Anchor";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 63);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Value";
            // 
            // txtAnchor
            // 
            this.txtAnchor.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnchor.Location = new System.Drawing.Point(12, 30);
            this.txtAnchor.Name = "txtAnchor";
            this.txtAnchor.ReadOnly = true;
            this.txtAnchor.Size = new System.Drawing.Size(892, 20);
            this.txtAnchor.TabIndex = 4;
            // 
            // btnShow
            // 
            this.btnShow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShow.Location = new System.Drawing.Point(910, 28);
            this.btnShow.Name = "btnShow";
            this.btnShow.Size = new System.Drawing.Size(27, 23);
            this.btnShow.TabIndex = 5;
            this.btnShow.Text = "...";
            this.btnShow.UseVisualStyleBackColor = true;
            this.btnShow.Click += new System.EventHandler(this.btnShow_Click);
            // 
            // btnShowVal
            // 
            this.btnShowVal.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnShowVal.Location = new System.Drawing.Point(910, 77);
            this.btnShowVal.Name = "btnShowVal";
            this.btnShowVal.Size = new System.Drawing.Size(27, 23);
            this.btnShowVal.TabIndex = 7;
            this.btnShowVal.Text = "...";
            this.btnShowVal.UseVisualStyleBackColor = true;
            this.btnShowVal.Click += new System.EventHandler(this.btnShowVal_Click);
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Location = new System.Drawing.Point(12, 79);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(892, 20);
            this.txtValue.TabIndex = 6;
            // 
            // ShowMap
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(943, 322);
            this.Controls.Add(this.btnShowVal);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.btnShow);
            this.Controls.Add(this.txtAnchor);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ShowMap";
            this.Text = "ShowMap";
            this.Load += new System.EventHandler(this.ShowMap_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnchor;
        private System.Windows.Forms.Button btnShow;
        private System.Windows.Forms.Button btnShowVal;
        private System.Windows.Forms.TextBox txtValue;
    }
}