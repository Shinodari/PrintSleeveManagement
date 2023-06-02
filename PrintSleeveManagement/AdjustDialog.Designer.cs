namespace PrintSleeveManagement
{
    partial class AdjustDialog
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
            this.dataGridViewAjust = new System.Windows.Forms.DataGridView();
            this.labelIssueNo = new System.Windows.Forms.Label();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonExtend = new System.Windows.Forms.Button();
            this.buttonScrap = new System.Windows.Forms.Button();
            this.buttonAdjust = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAjust)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewAjust
            // 
            this.dataGridViewAjust.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAjust.Location = new System.Drawing.Point(13, 40);
            this.dataGridViewAjust.Name = "dataGridViewAjust";
            this.dataGridViewAjust.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAjust.Size = new System.Drawing.Size(697, 435);
            this.dataGridViewAjust.TabIndex = 0;
            this.dataGridViewAjust.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAjust_CellContentClick);
            // 
            // labelIssueNo
            // 
            this.labelIssueNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelIssueNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelIssueNo.Location = new System.Drawing.Point(12, 9);
            this.labelIssueNo.Name = "labelIssueNo";
            this.labelIssueNo.Size = new System.Drawing.Size(132, 23);
            this.labelIssueNo.TabIndex = 6;
            this.labelIssueNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(787, 425);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 50);
            this.buttonCancel.TabIndex = 3;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonExtend
            // 
            this.buttonExtend.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonExtend.Location = new System.Drawing.Point(716, 40);
            this.buttonExtend.Name = "buttonExtend";
            this.buttonExtend.Size = new System.Drawing.Size(171, 50);
            this.buttonExtend.TabIndex = 4;
            this.buttonExtend.Text = "Extend Expired Date";
            this.buttonExtend.UseVisualStyleBackColor = true;
            this.buttonExtend.Click += new System.EventHandler(this.buttonExtend_Click);
            // 
            // buttonScrap
            // 
            this.buttonScrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonScrap.ForeColor = System.Drawing.Color.Red;
            this.buttonScrap.Location = new System.Drawing.Point(716, 96);
            this.buttonScrap.Name = "buttonScrap";
            this.buttonScrap.Size = new System.Drawing.Size(171, 50);
            this.buttonScrap.TabIndex = 7;
            this.buttonScrap.Text = "Scrap";
            this.buttonScrap.UseVisualStyleBackColor = true;
            this.buttonScrap.Click += new System.EventHandler(this.buttonScrap_Click);
            // 
            // buttonAdjust
            // 
            this.buttonAdjust.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonAdjust.Location = new System.Drawing.Point(787, 369);
            this.buttonAdjust.Name = "buttonAdjust";
            this.buttonAdjust.Size = new System.Drawing.Size(100, 50);
            this.buttonAdjust.TabIndex = 8;
            this.buttonAdjust.Text = "Adjust";
            this.buttonAdjust.UseVisualStyleBackColor = true;
            this.buttonAdjust.Click += new System.EventHandler(this.buttonAdjust_Click);
            // 
            // AdjustDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(899, 487);
            this.Controls.Add(this.buttonAdjust);
            this.Controls.Add(this.buttonScrap);
            this.Controls.Add(this.labelIssueNo);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonExtend);
            this.Controls.Add(this.dataGridViewAjust);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "AdjustDialog";
            this.Text = "Adjust";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAjust)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewAjust;
        private System.Windows.Forms.Label labelIssueNo;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonExtend;
        private System.Windows.Forms.Button buttonScrap;
        private System.Windows.Forms.Button buttonAdjust;
    }
}