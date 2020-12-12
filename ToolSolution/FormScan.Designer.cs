
namespace ToolSolution
{
    partial class FormScan
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
            this.textBoxScan = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxScan
            // 
            this.textBoxScan.Location = new System.Drawing.Point(12, 12);
            this.textBoxScan.Multiline = true;
            this.textBoxScan.Name = "textBoxScan";
            this.textBoxScan.Size = new System.Drawing.Size(183, 42);
            this.textBoxScan.TabIndex = 0;
            this.textBoxScan.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxScan_KeyDown);
            // 
            // FormScan
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(207, 67);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxScan);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormScan";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FormScan";
            this.Load += new System.EventHandler(this.FormScan_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox textBoxScan;
    }
}