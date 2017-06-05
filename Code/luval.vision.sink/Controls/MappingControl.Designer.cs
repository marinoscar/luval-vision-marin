namespace luval.vision.sink.Controls
{
    partial class MappingControl
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
            this.lblInstructions = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtValueElement = new System.Windows.Forms.TextBox();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtAnchorText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtLines = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboQuality = new System.Windows.Forms.ComboBox();
            this.btnMapValue = new System.Windows.Forms.Button();
            this.btnMapAnchor = new System.Windows.Forms.Button();
            this.cboAttribute = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblInstructions
            // 
            this.lblInstructions.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblInstructions.ForeColor = System.Drawing.Color.Blue;
            this.lblInstructions.Location = new System.Drawing.Point(-4, 0);
            this.lblInstructions.Name = "lblInstructions";
            this.lblInstructions.Size = new System.Drawing.Size(314, 57);
            this.lblInstructions.TabIndex = 0;
            this.lblInstructions.Text = "Instructions";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 94);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Value Element";
            // 
            // txtValueElement
            // 
            this.txtValueElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValueElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueElement.Location = new System.Drawing.Point(0, 111);
            this.txtValueElement.Name = "txtValueElement";
            this.txtValueElement.ReadOnly = true;
            this.txtValueElement.Size = new System.Drawing.Size(280, 20);
            this.txtValueElement.TabIndex = 2;
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(0, 157);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(310, 20);
            this.txtValue.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 140);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Element Value";
            // 
            // txtAnchorText
            // 
            this.txtAnchorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnchorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnchorText.Location = new System.Drawing.Point(0, 201);
            this.txtAnchorText.Name = "txtAnchorText";
            this.txtAnchorText.ReadOnly = true;
            this.txtAnchorText.Size = new System.Drawing.Size(280, 20);
            this.txtAnchorText.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(3, 184);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Anchor Text";
            // 
            // txtLines
            // 
            this.txtLines.Location = new System.Drawing.Point(0, 251);
            this.txtLines.Name = "txtLines";
            this.txtLines.Size = new System.Drawing.Size(101, 20);
            this.txtLines.TabIndex = 7;
            this.txtLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLines_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 235);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(98, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Lines Not Identified";
            // 
            // txtPercentage
            // 
            this.txtPercentage.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtPercentage.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPercentage.Location = new System.Drawing.Point(107, 251);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.ReadOnly = true;
            this.txtPercentage.Size = new System.Drawing.Size(203, 20);
            this.txtPercentage.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(107, 235);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Accuracy Percentage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(3, 286);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Image Category";
            // 
            // cboQuality
            // 
            this.cboQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboQuality.FormattingEnabled = true;
            this.cboQuality.Items.AddRange(new object[] {
            "Bad Image Quality",
            "Regular Data Quality",
            "Machine Learning Required",
            "High Accuracy / High Confidence"});
            this.cboQuality.Location = new System.Drawing.Point(3, 302);
            this.cboQuality.Name = "cboQuality";
            this.cboQuality.Size = new System.Drawing.Size(307, 21);
            this.cboQuality.TabIndex = 12;
            // 
            // btnMapValue
            // 
            this.btnMapValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapValue.Location = new System.Drawing.Point(287, 107);
            this.btnMapValue.Name = "btnMapValue";
            this.btnMapValue.Size = new System.Drawing.Size(23, 23);
            this.btnMapValue.TabIndex = 13;
            this.btnMapValue.Text = "...";
            this.btnMapValue.UseVisualStyleBackColor = true;
            // 
            // btnMapAnchor
            // 
            this.btnMapAnchor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapAnchor.Location = new System.Drawing.Point(286, 198);
            this.btnMapAnchor.Name = "btnMapAnchor";
            this.btnMapAnchor.Size = new System.Drawing.Size(23, 23);
            this.btnMapAnchor.TabIndex = 14;
            this.btnMapAnchor.Text = "...";
            this.btnMapAnchor.UseVisualStyleBackColor = true;
            // 
            // cboAttribute
            // 
            this.cboAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAttribute.FormattingEnabled = true;
            this.cboAttribute.Items.AddRange(new object[] {
            "Bad Image Quality",
            "Regular Data Quality",
            "Machine Learning Required",
            "High Accuracy / High Confidence"});
            this.cboAttribute.Location = new System.Drawing.Point(0, 61);
            this.cboAttribute.Name = "cboAttribute";
            this.cboAttribute.Size = new System.Drawing.Size(310, 21);
            this.cboAttribute.TabIndex = 16;
            this.cboAttribute.SelectedValueChanged += new System.EventHandler(this.cboAttribute_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 44);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 15;
            this.label7.Text = "Select Attribute";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(234, 339);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 17;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MappingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboAttribute);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.btnMapAnchor);
            this.Controls.Add(this.btnMapValue);
            this.Controls.Add(this.cboQuality);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLines);
            this.Controls.Add(this.txtAnchorText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtValue);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtValueElement);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lblInstructions);
            this.Name = "MappingControl";
            this.Size = new System.Drawing.Size(313, 377);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtValueElement;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtAnchorText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtLines;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboQuality;
        private System.Windows.Forms.Button btnMapValue;
        private System.Windows.Forms.Button btnMapAnchor;
        private System.Windows.Forms.ComboBox cboAttribute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnSave;
    }
}
