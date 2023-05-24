namespace PrintSleeveManagement
{
    partial class OverviewForm
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
            this.SuspendLayout();
            // 
            // OverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.ClientSize = new System.Drawing.Size(1664, 632);
            this.ControlBox = false;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverviewForm";
            this.Text = "Overview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.OverviewForm_Activated);
            this.Load += new System.EventHandler(this.OverviewForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
    }
}