namespace PrintSleeveManagement
{
    partial class ScrapDialog
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
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.buttonScrap = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.labelItemNo = new System.Windows.Forms.Label();
            this.labelPartNo = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(12, 42);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView.Size = new System.Drawing.Size(711, 417);
            this.dataGridView.TabIndex = 0;
            // 
            // buttonScrap
            // 
            this.buttonScrap.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.buttonScrap.ForeColor = System.Drawing.Color.Red;
            this.buttonScrap.Location = new System.Drawing.Point(730, 12);
            this.buttonScrap.Name = "buttonScrap";
            this.buttonScrap.Size = new System.Drawing.Size(100, 50);
            this.buttonScrap.TabIndex = 1;
            this.buttonScrap.Text = "Scrap";
            this.buttonScrap.UseVisualStyleBackColor = true;
            this.buttonScrap.Click += new System.EventHandler(this.buttonIssue_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(730, 68);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(100, 50);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // labelItemNo
            // 
            this.labelItemNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelItemNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelItemNo.Location = new System.Drawing.Point(13, 13);
            this.labelItemNo.Name = "labelItemNo";
            this.labelItemNo.Size = new System.Drawing.Size(132, 23);
            this.labelItemNo.TabIndex = 2;
            this.labelItemNo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelPartNo
            // 
            this.labelPartNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPartNo.Location = new System.Drawing.Point(151, 13);
            this.labelPartNo.Name = "labelPartNo";
            this.labelPartNo.Size = new System.Drawing.Size(573, 23);
            this.labelPartNo.TabIndex = 2;
            // 
            // ScrapDialog
            // 
            this.AcceptButton = this.buttonScrap;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(842, 471);
            this.Controls.Add(this.labelPartNo);
            this.Controls.Add(this.labelItemNo);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonScrap);
            this.Controls.Add(this.dataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ScrapDialog";
            this.Text = "Scrap";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.Button buttonScrap;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Label labelItemNo;
        private System.Windows.Forms.Label labelPartNo;
    }
}