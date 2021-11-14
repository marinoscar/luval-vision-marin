
namespace luval.vision.app
{
    partial class LineResolverControl
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
            this.externalOptions = new luval.vision.app.ExternalOptions();
            this.SuspendLayout();
            // 
            // externalOptions
            // 
            this.externalOptions.Dock = System.Windows.Forms.DockStyle.Fill;
            this.externalOptions.Location = new System.Drawing.Point(0, 0);
            this.externalOptions.Name = "externalOptions";
            this.externalOptions.NameLabel = "Line Resolver Qualified Name";
            this.externalOptions.Size = new System.Drawing.Size(479, 242);
            this.externalOptions.TabIndex = 0;
            this.externalOptions.DataChanged += new luval.vision.app.ExternalOptions.DataChangedEventHandler(this.externalOptions_DataChanged);
            // 
            // LineResolverControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.externalOptions);
            this.Name = "LineResolverControl";
            this.Size = new System.Drawing.Size(479, 242);
            this.ResumeLayout(false);

        }

        #endregion

        private ExternalOptions externalOptions;
    }
}
