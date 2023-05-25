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
            this.groupBoxExpiredDate = new System.Windows.Forms.GroupBox();
            this.groupBoxExpired = new System.Windows.Forms.GroupBox();
            this.groupBoxExpiredDate.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxExpiredDate
            // 
            this.groupBoxExpiredDate.Controls.Add(this.groupBoxExpired);
            this.groupBoxExpiredDate.Location = new System.Drawing.Point(13, 13);
            this.groupBoxExpiredDate.Name = "groupBoxExpiredDate";
            this.groupBoxExpiredDate.Size = new System.Drawing.Size(830, 478);
            this.groupBoxExpiredDate.TabIndex = 0;
            this.groupBoxExpiredDate.TabStop = false;
            this.groupBoxExpiredDate.Text = "Expired Date Report";
            // 
            // groupBoxExpired
            // 
            this.groupBoxExpired.ForeColor = System.Drawing.Color.Red;
            this.groupBoxExpired.Location = new System.Drawing.Point(7, 20);
            this.groupBoxExpired.Name = "groupBoxExpired";
            this.groupBoxExpired.Size = new System.Drawing.Size(437, 452);
            this.groupBoxExpired.TabIndex = 0;
            this.groupBoxExpired.TabStop = false;
            this.groupBoxExpired.Text = "Expired";
            // 
            // OverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1664, 632);
            this.ControlBox = false;
            this.Controls.Add(this.groupBoxExpiredDate);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "OverviewForm";
            this.Text = "Overview";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.OverviewForm_Activated);
            this.Load += new System.EventHandler(this.OverviewForm_Load);
            this.groupBoxExpiredDate.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxExpiredDate;
        private System.Windows.Forms.GroupBox groupBoxExpired;
    }
}