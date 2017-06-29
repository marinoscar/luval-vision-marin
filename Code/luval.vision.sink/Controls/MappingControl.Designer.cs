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
            this.txtLines = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPercentage = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.cboQuality = new System.Windows.Forms.ComboBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkNotFound = new System.Windows.Forms.CheckBox();
            this.cboAttribute = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.btnMapAnchor = new System.Windows.Forms.Button();
            this.btnMapValue = new System.Windows.Forms.Button();
            this.txtAnchorText = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtValue = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtValueElement = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtComments = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.chkNotCaptured = new System.Windows.Forms.CheckBox();
            this.groupBox2.SuspendLayout();
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
            this.lblInstructions.TabIndex = 2;
            this.lblInstructions.Text = "Attribute Mapping";
            this.lblInstructions.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtLines
            // 
            this.txtLines.Location = new System.Drawing.Point(10, 324);
            this.txtLines.Name = "txtLines";
            this.txtLines.Size = new System.Drawing.Size(95, 20);
            this.txtLines.TabIndex = 0;
            this.txtLines.TextChanged += new System.EventHandler(this.txtLines_TextChanged);
            this.txtLines.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtLines_KeyDown);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(7, 308);
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
            this.txtPercentage.Location = new System.Drawing.Point(111, 324);
            this.txtPercentage.Name = "txtPercentage";
            this.txtPercentage.ReadOnly = true;
            this.txtPercentage.Size = new System.Drawing.Size(197, 20);
            this.txtPercentage.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(108, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(110, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Accuracy Percentage";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(7, 359);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Image Category";
            // 
            // cboQuality
            // 
            this.cboQuality.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboQuality.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboQuality.FormattingEnabled = true;
            this.cboQuality.Items.AddRange(new object[] {
            "Bad Image Quality",
            "Regular Data Quality",
            "Machine Learning Required",
            "High Accuracy / High Confidence"});
            this.cboQuality.Location = new System.Drawing.Point(10, 375);
            this.cboQuality.Name = "cboQuality";
            this.cboQuality.Size = new System.Drawing.Size(298, 21);
            this.cboQuality.TabIndex = 2;
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(226, 483);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Location = new System.Drawing.Point(108, 434);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(8, 8);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkNotCaptured);
            this.groupBox2.Controls.Add(this.chkNotFound);
            this.groupBox2.Controls.Add(this.cboAttribute);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.btnMapAnchor);
            this.groupBox2.Controls.Add(this.btnMapValue);
            this.groupBox2.Controls.Add(this.txtAnchorText);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.txtValue);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.txtValueElement);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Location = new System.Drawing.Point(1, 60);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(309, 235);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Attribute Based Values";
            // 
            // chkNotFound
            // 
            this.chkNotFound.AutoSize = true;
            this.chkNotFound.Location = new System.Drawing.Point(9, 204);
            this.chkNotFound.Name = "chkNotFound";
            this.chkNotFound.Size = new System.Drawing.Size(76, 17);
            this.chkNotFound.TabIndex = 3;
            this.chkNotFound.Text = "Not Found";
            this.chkNotFound.UseVisualStyleBackColor = true;
            this.chkNotFound.Click += new System.EventHandler(this.chkNotFound_Click);
            // 
            // cboAttribute
            // 
            this.cboAttribute.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cboAttribute.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboAttribute.FormattingEnabled = true;
            this.cboAttribute.Location = new System.Drawing.Point(9, 38);
            this.cboAttribute.Name = "cboAttribute";
            this.cboAttribute.Size = new System.Drawing.Size(291, 21);
            this.cboAttribute.TabIndex = 0;
            this.cboAttribute.SelectionChangeCommitted += new System.EventHandler(this.cboAttribute_SelectedValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(79, 13);
            this.label7.TabIndex = 25;
            this.label7.Text = "Select Attribute";
            // 
            // btnMapAnchor
            // 
            this.btnMapAnchor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapAnchor.Location = new System.Drawing.Point(277, 175);
            this.btnMapAnchor.Name = "btnMapAnchor";
            this.btnMapAnchor.Size = new System.Drawing.Size(23, 23);
            this.btnMapAnchor.TabIndex = 2;
            this.btnMapAnchor.Text = "...";
            this.btnMapAnchor.UseVisualStyleBackColor = true;
            this.btnMapAnchor.Click += new System.EventHandler(this.btnMapAnchor_Click);
            // 
            // btnMapValue
            // 
            this.btnMapValue.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnMapValue.Location = new System.Drawing.Point(277, 86);
            this.btnMapValue.Name = "btnMapValue";
            this.btnMapValue.Size = new System.Drawing.Size(23, 23);
            this.btnMapValue.TabIndex = 1;
            this.btnMapValue.Text = "...";
            this.btnMapValue.UseVisualStyleBackColor = true;
            this.btnMapValue.Click += new System.EventHandler(this.btnMapValue_Click);
            // 
            // txtAnchorText
            // 
            this.txtAnchorText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAnchorText.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtAnchorText.Location = new System.Drawing.Point(9, 178);
            this.txtAnchorText.Name = "txtAnchorText";
            this.txtAnchorText.ReadOnly = true;
            this.txtAnchorText.Size = new System.Drawing.Size(262, 20);
            this.txtAnchorText.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 161);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 21;
            this.label3.Text = "Anchor Text";
            // 
            // txtValue
            // 
            this.txtValue.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValue.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValue.Location = new System.Drawing.Point(9, 134);
            this.txtValue.Name = "txtValue";
            this.txtValue.ReadOnly = true;
            this.txtValue.Size = new System.Drawing.Size(291, 20);
            this.txtValue.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 117);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 13);
            this.label2.TabIndex = 19;
            this.label2.Text = "Element Value";
            // 
            // txtValueElement
            // 
            this.txtValueElement.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtValueElement.BackColor = System.Drawing.SystemColors.Control;
            this.txtValueElement.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtValueElement.Location = new System.Drawing.Point(9, 88);
            this.txtValueElement.Name = "txtValueElement";
            this.txtValueElement.ReadOnly = true;
            this.txtValueElement.Size = new System.Drawing.Size(262, 20);
            this.txtValueElement.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 71);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(75, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Value Element";
            // 
            // txtComments
            // 
            this.txtComments.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComments.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtComments.Location = new System.Drawing.Point(10, 415);
            this.txtComments.Multiline = true;
            this.txtComments.Name = "txtComments";
            this.txtComments.Size = new System.Drawing.Size(291, 62);
            this.txtComments.TabIndex = 19;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(11, 399);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 13);
            this.label8.TabIndex = 20;
            this.label8.Text = "Comments";
            // 
            // chkNotCaptured
            // 
            this.chkNotCaptured.AutoSize = true;
            this.chkNotCaptured.Location = new System.Drawing.Point(107, 204);
            this.chkNotCaptured.Name = "chkNotCaptured";
            this.chkNotCaptured.Size = new System.Drawing.Size(154, 17);
            this.chkNotCaptured.TabIndex = 26;
            this.chkNotCaptured.Text = "Element Text Not Captured";
            this.chkNotCaptured.UseVisualStyleBackColor = true;
            this.chkNotCaptured.Click += new System.EventHandler(this.chkNotCaptured_Click);
            // 
            // MappingControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtComments);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.cboQuality);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtPercentage);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtLines);
            this.Controls.Add(this.lblInstructions);
            this.Enabled = false;
            this.Name = "MappingControl";
            this.Size = new System.Drawing.Size(313, 520);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblInstructions;
        private System.Windows.Forms.TextBox txtLines;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPercentage;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cboQuality;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox chkNotFound;
        private System.Windows.Forms.ComboBox cboAttribute;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnMapAnchor;
        private System.Windows.Forms.Button btnMapValue;
        private System.Windows.Forms.TextBox txtAnchorText;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtValue;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtValueElement;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtComments;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.CheckBox chkNotCaptured;
    }
}
