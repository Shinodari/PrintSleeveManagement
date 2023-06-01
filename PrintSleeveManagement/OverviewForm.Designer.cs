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
            this.groupBoxInProcess = new System.Windows.Forms.GroupBox();
            this.dataGridViewInProcess = new System.Windows.Forms.DataGridView();
            this.groupBoxPriorExpiredNextMonth = new System.Windows.Forms.GroupBox();
            this.dataGridViewPriorExpiredNextMonth = new System.Windows.Forms.DataGridView();
            this.groupBoxPriorExpired = new System.Windows.Forms.GroupBox();
            this.dataGridViewPriorExpired = new System.Windows.Forms.DataGridView();
            this.groupBoxExpired = new System.Windows.Forms.GroupBox();
            this.buttonIssueIRS = new System.Windows.Forms.Button();
            this.dataGridViewExpired = new System.Windows.Forms.DataGridView();
            this.buttonIssuePriorExpredSheet = new System.Windows.Forms.Button();
            this.buttonAdjust = new System.Windows.Forms.Button();
            this.groupBoxExpiredDate.SuspendLayout();
            this.groupBoxInProcess.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInProcess)).BeginInit();
            this.groupBoxPriorExpiredNextMonth.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriorExpiredNextMonth)).BeginInit();
            this.groupBoxPriorExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriorExpired)).BeginInit();
            this.groupBoxExpired.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpired)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxExpiredDate
            // 
            this.groupBoxExpiredDate.Controls.Add(this.groupBoxInProcess);
            this.groupBoxExpiredDate.Controls.Add(this.groupBoxPriorExpiredNextMonth);
            this.groupBoxExpiredDate.Controls.Add(this.groupBoxPriorExpired);
            this.groupBoxExpiredDate.Controls.Add(this.groupBoxExpired);
            this.groupBoxExpiredDate.Location = new System.Drawing.Point(13, 13);
            this.groupBoxExpiredDate.Name = "groupBoxExpiredDate";
            this.groupBoxExpiredDate.Size = new System.Drawing.Size(1337, 831);
            this.groupBoxExpiredDate.TabIndex = 0;
            this.groupBoxExpiredDate.TabStop = false;
            this.groupBoxExpiredDate.Text = "Expired Date Report";
            // 
            // groupBoxInProcess
            // 
            this.groupBoxInProcess.Controls.Add(this.buttonAdjust);
            this.groupBoxInProcess.Controls.Add(this.dataGridViewInProcess);
            this.groupBoxInProcess.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxInProcess.Location = new System.Drawing.Point(6, 19);
            this.groupBoxInProcess.Name = "groupBoxInProcess";
            this.groupBoxInProcess.Size = new System.Drawing.Size(659, 400);
            this.groupBoxInProcess.TabIndex = 1;
            this.groupBoxInProcess.TabStop = false;
            this.groupBoxInProcess.Text = "In Process for Extend Expired Date";
            // 
            // dataGridViewInProcess
            // 
            this.dataGridViewInProcess.AllowUserToAddRows = false;
            this.dataGridViewInProcess.AllowUserToDeleteRows = false;
            this.dataGridViewInProcess.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewInProcess.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewInProcess.Name = "dataGridViewInProcess";
            this.dataGridViewInProcess.ReadOnly = true;
            this.dataGridViewInProcess.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewInProcess.Size = new System.Drawing.Size(646, 318);
            this.dataGridViewInProcess.TabIndex = 0;
            // 
            // groupBoxPriorExpiredNextMonth
            // 
            this.groupBoxPriorExpiredNextMonth.Controls.Add(this.dataGridViewPriorExpiredNextMonth);
            this.groupBoxPriorExpiredNextMonth.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxPriorExpiredNextMonth.Location = new System.Drawing.Point(672, 425);
            this.groupBoxPriorExpiredNextMonth.Name = "groupBoxPriorExpiredNextMonth";
            this.groupBoxPriorExpiredNextMonth.Size = new System.Drawing.Size(659, 400);
            this.groupBoxPriorExpiredNextMonth.TabIndex = 2;
            this.groupBoxPriorExpiredNextMonth.TabStop = false;
            this.groupBoxPriorExpiredNextMonth.Text = "Prior Expired (Nex month)";
            // 
            // dataGridViewPriorExpiredNextMonth
            // 
            this.dataGridViewPriorExpiredNextMonth.AllowUserToAddRows = false;
            this.dataGridViewPriorExpiredNextMonth.AllowUserToDeleteRows = false;
            this.dataGridViewPriorExpiredNextMonth.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPriorExpiredNextMonth.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewPriorExpiredNextMonth.Name = "dataGridViewPriorExpiredNextMonth";
            this.dataGridViewPriorExpiredNextMonth.ReadOnly = true;
            this.dataGridViewPriorExpiredNextMonth.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPriorExpiredNextMonth.Size = new System.Drawing.Size(646, 374);
            this.dataGridViewPriorExpiredNextMonth.TabIndex = 0;
            // 
            // groupBoxPriorExpired
            // 
            this.groupBoxPriorExpired.Controls.Add(this.buttonIssuePriorExpredSheet);
            this.groupBoxPriorExpired.Controls.Add(this.dataGridViewPriorExpired);
            this.groupBoxPriorExpired.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBoxPriorExpired.Location = new System.Drawing.Point(6, 425);
            this.groupBoxPriorExpired.Name = "groupBoxPriorExpired";
            this.groupBoxPriorExpired.Size = new System.Drawing.Size(659, 400);
            this.groupBoxPriorExpired.TabIndex = 1;
            this.groupBoxPriorExpired.TabStop = false;
            this.groupBoxPriorExpired.Text = "Prior Expired (less 30 Days)";
            // 
            // dataGridViewPriorExpired
            // 
            this.dataGridViewPriorExpired.AllowUserToAddRows = false;
            this.dataGridViewPriorExpired.AllowUserToDeleteRows = false;
            this.dataGridViewPriorExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPriorExpired.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewPriorExpired.Name = "dataGridViewPriorExpired";
            this.dataGridViewPriorExpired.ReadOnly = true;
            this.dataGridViewPriorExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPriorExpired.Size = new System.Drawing.Size(646, 318);
            this.dataGridViewPriorExpired.TabIndex = 0;
            // 
            // groupBoxExpired
            // 
            this.groupBoxExpired.Controls.Add(this.buttonIssueIRS);
            this.groupBoxExpired.Controls.Add(this.dataGridViewExpired);
            this.groupBoxExpired.ForeColor = System.Drawing.Color.Red;
            this.groupBoxExpired.Location = new System.Drawing.Point(672, 19);
            this.groupBoxExpired.Name = "groupBoxExpired";
            this.groupBoxExpired.Size = new System.Drawing.Size(659, 400);
            this.groupBoxExpired.TabIndex = 0;
            this.groupBoxExpired.TabStop = false;
            this.groupBoxExpired.Text = "Expired";
            // 
            // buttonIssueIRS
            // 
            this.buttonIssueIRS.ForeColor = System.Drawing.Color.Blue;
            this.buttonIssueIRS.Location = new System.Drawing.Point(553, 344);
            this.buttonIssueIRS.Name = "buttonIssueIRS";
            this.buttonIssueIRS.Size = new System.Drawing.Size(100, 50);
            this.buttonIssueIRS.TabIndex = 1;
            this.buttonIssueIRS.Text = "Issue IRS";
            this.buttonIssueIRS.UseVisualStyleBackColor = true;
            this.buttonIssueIRS.Click += new System.EventHandler(this.buttonIssueIRS_Click);
            // 
            // dataGridViewExpired
            // 
            this.dataGridViewExpired.AllowUserToAddRows = false;
            this.dataGridViewExpired.AllowUserToDeleteRows = false;
            this.dataGridViewExpired.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewExpired.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewExpired.Name = "dataGridViewExpired";
            this.dataGridViewExpired.ReadOnly = true;
            this.dataGridViewExpired.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewExpired.Size = new System.Drawing.Size(646, 318);
            this.dataGridViewExpired.TabIndex = 0;
            // 
            // buttonIssuePriorExpredSheet
            // 
            this.buttonIssuePriorExpredSheet.ForeColor = System.Drawing.Color.Blue;
            this.buttonIssuePriorExpredSheet.Location = new System.Drawing.Point(512, 344);
            this.buttonIssuePriorExpredSheet.Name = "buttonIssuePriorExpredSheet";
            this.buttonIssuePriorExpredSheet.Size = new System.Drawing.Size(141, 50);
            this.buttonIssuePriorExpredSheet.TabIndex = 1;
            this.buttonIssuePriorExpredSheet.Text = "Issue Prior Expired Sheet";
            this.buttonIssuePriorExpredSheet.UseVisualStyleBackColor = true;
            this.buttonIssuePriorExpredSheet.Click += new System.EventHandler(this.buttonIssuePriorExpredSheet_Click);
            // 
            // buttonAdjust
            // 
            this.buttonAdjust.ForeColor = System.Drawing.Color.Blue;
            this.buttonAdjust.Location = new System.Drawing.Point(553, 344);
            this.buttonAdjust.Name = "buttonAdjust";
            this.buttonAdjust.Size = new System.Drawing.Size(100, 50);
            this.buttonAdjust.TabIndex = 1;
            this.buttonAdjust.Text = "Adjust";
            this.buttonAdjust.UseVisualStyleBackColor = true;
            this.buttonAdjust.Click += new System.EventHandler(this.buttonAdjust_Click);
            // 
            // OverviewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDark;
            this.ClientSize = new System.Drawing.Size(1664, 961);
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
            this.groupBoxInProcess.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewInProcess)).EndInit();
            this.groupBoxPriorExpiredNextMonth.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriorExpiredNextMonth)).EndInit();
            this.groupBoxPriorExpired.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPriorExpired)).EndInit();
            this.groupBoxExpired.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewExpired)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxExpiredDate;
        private System.Windows.Forms.GroupBox groupBoxExpired;
        private System.Windows.Forms.DataGridView dataGridViewExpired;
        private System.Windows.Forms.GroupBox groupBoxPriorExpired;
        private System.Windows.Forms.DataGridView dataGridViewPriorExpired;
        private System.Windows.Forms.GroupBox groupBoxPriorExpiredNextMonth;
        private System.Windows.Forms.DataGridView dataGridViewPriorExpiredNextMonth;
        private System.Windows.Forms.GroupBox groupBoxInProcess;
        private System.Windows.Forms.DataGridView dataGridViewInProcess;
        private System.Windows.Forms.Button buttonIssueIRS;
        private System.Windows.Forms.Button buttonAdjust;
        private System.Windows.Forms.Button buttonIssuePriorExpredSheet;
    }
}