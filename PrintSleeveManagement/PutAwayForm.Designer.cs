namespace PrintSleeveManagement
{
    partial class PutAwayForm
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
            this.groupBoxReceipt = new System.Windows.Forms.GroupBox();
            this.buttonCommit = new System.Windows.Forms.Button();
            this.dataGridViewReceipt = new System.Windows.Forms.DataGridView();
            this.buttonPOBrowse = new System.Windows.Forms.Button();
            this.textBoxPONo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPrintSleeve = new System.Windows.Forms.GroupBox();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxLotNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.labelPartNo = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelReceived = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).BeginInit();
            this.groupBoxPrintSleeve.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReceipt
            // 
            this.groupBoxReceipt.Controls.Add(this.buttonCommit);
            this.groupBoxReceipt.Controls.Add(this.dataGridViewReceipt);
            this.groupBoxReceipt.Controls.Add(this.buttonPOBrowse);
            this.groupBoxReceipt.Controls.Add(this.textBoxPONo);
            this.groupBoxReceipt.Controls.Add(this.label1);
            this.groupBoxReceipt.Location = new System.Drawing.Point(12, 12);
            this.groupBoxReceipt.Name = "groupBoxReceipt";
            this.groupBoxReceipt.Size = new System.Drawing.Size(464, 479);
            this.groupBoxReceipt.TabIndex = 0;
            this.groupBoxReceipt.TabStop = false;
            this.groupBoxReceipt.Text = "Receipt";
            // 
            // buttonCommit
            // 
            this.buttonCommit.Location = new System.Drawing.Point(241, 19);
            this.buttonCommit.Name = "buttonCommit";
            this.buttonCommit.Size = new System.Drawing.Size(75, 23);
            this.buttonCommit.TabIndex = 4;
            this.buttonCommit.Text = "&Commit";
            this.buttonCommit.UseVisualStyleBackColor = true;
            this.buttonCommit.Click += new System.EventHandler(this.buttonCommit_Click);
            // 
            // dataGridViewReceipt
            // 
            this.dataGridViewReceipt.AllowUserToAddRows = false;
            this.dataGridViewReceipt.AllowUserToDeleteRows = false;
            this.dataGridViewReceipt.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewReceipt.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewReceipt.Location = new System.Drawing.Point(6, 47);
            this.dataGridViewReceipt.Name = "dataGridViewReceipt";
            this.dataGridViewReceipt.ReadOnly = true;
            this.dataGridViewReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReceipt.Size = new System.Drawing.Size(450, 413);
            this.dataGridViewReceipt.TabIndex = 3;
            // 
            // buttonPOBrowse
            // 
            this.buttonPOBrowse.Location = new System.Drawing.Point(160, 18);
            this.buttonPOBrowse.Name = "buttonPOBrowse";
            this.buttonPOBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonPOBrowse.TabIndex = 2;
            this.buttonPOBrowse.Text = "&Browse...";
            this.buttonPOBrowse.UseVisualStyleBackColor = true;
            // 
            // textBoxPONo
            // 
            this.textBoxPONo.Location = new System.Drawing.Point(54, 19);
            this.textBoxPONo.Name = "textBoxPONo";
            this.textBoxPONo.Size = new System.Drawing.Size(100, 20);
            this.textBoxPONo.TabIndex = 1;
            this.textBoxPONo.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPONo_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "PONo :";
            // 
            // groupBoxPrintSleeve
            // 
            this.groupBoxPrintSleeve.Controls.Add(this.label7);
            this.groupBoxPrintSleeve.Controls.Add(this.labelReceived);
            this.groupBoxPrintSleeve.Controls.Add(this.label6);
            this.groupBoxPrintSleeve.Controls.Add(this.label4);
            this.groupBoxPrintSleeve.Controls.Add(this.labelPartNo);
            this.groupBoxPrintSleeve.Controls.Add(this.textBoxQuantity);
            this.groupBoxPrintSleeve.Controls.Add(this.textBoxLotNo);
            this.groupBoxPrintSleeve.Controls.Add(this.label5);
            this.groupBoxPrintSleeve.Controls.Add(this.label3);
            this.groupBoxPrintSleeve.Controls.Add(this.label2);
            this.groupBoxPrintSleeve.Controls.Add(this.dateTimePickerExpiredDate);
            this.groupBoxPrintSleeve.Location = new System.Drawing.Point(482, 12);
            this.groupBoxPrintSleeve.Name = "groupBoxPrintSleeve";
            this.groupBoxPrintSleeve.Size = new System.Drawing.Size(1170, 391);
            this.groupBoxPrintSleeve.TabIndex = 1;
            this.groupBoxPrintSleeve.TabStop = false;
            this.groupBoxPrintSleeve.Text = "PrintSleeve";
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(105, 161);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantity.TabIndex = 3;
            this.textBoxQuantity.Text = "200";
            // 
            // textBoxLotNo
            // 
            this.textBoxLotNo.Location = new System.Drawing.Point(105, 135);
            this.textBoxLotNo.Name = "textBoxLotNo";
            this.textBoxLotNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxLotNo.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 164);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Quantity (M/Roll) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 138);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "LotNo :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expired Date :";
            // 
            // dateTimePickerExpiredDate
            // 
            this.dateTimePickerExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerExpiredDate.Location = new System.Drawing.Point(105, 109);
            this.dateTimePickerExpiredDate.Name = "dateTimePickerExpiredDate";
            this.dateTimePickerExpiredDate.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerExpiredDate.TabIndex = 0;
            this.dateTimePickerExpiredDate.Value = new System.DateTime(2022, 11, 12, 0, 0, 0, 0);
            // 
            // labelPartNo
            // 
            this.labelPartNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPartNo.Location = new System.Drawing.Point(9, 20);
            this.labelPartNo.Name = "labelPartNo";
            this.labelPartNo.Size = new System.Drawing.Size(1155, 75);
            this.labelPartNo.TabIndex = 4;
            this.labelPartNo.Text = "labelPartNo";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(211, 109);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(335, 73);
            this.label4.TabIndex = 4;
            this.label4.Text = "Received :";
            // 
            // labelReceived
            // 
            this.labelReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelReceived.Location = new System.Drawing.Point(552, 109);
            this.labelReceived.Name = "labelReceived";
            this.labelReceived.Size = new System.Drawing.Size(183, 72);
            this.labelReceived.TabIndex = 4;
            this.labelReceived.Text = "9999";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(218, 193);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(328, 73);
            this.label6.TabIndex = 4;
            this.label6.Text = "Available :";
            // 
            // label7
            // 
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label7.Location = new System.Drawing.Point(552, 193);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(183, 72);
            this.label7.TabIndex = 4;
            this.label7.Text = "9999";
            // 
            // PutAwayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 861);
            this.Controls.Add(this.groupBoxPrintSleeve);
            this.Controls.Add(this.groupBoxReceipt);
            this.Name = "PutAwayForm";
            this.Text = "Put Away";
            this.Load += new System.EventHandler(this.PutAwayForm_Load);
            this.groupBoxReceipt.ResumeLayout(false);
            this.groupBoxReceipt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).EndInit();
            this.groupBoxPrintSleeve.ResumeLayout(false);
            this.groupBoxPrintSleeve.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxReceipt;
        private System.Windows.Forms.Button buttonPOBrowse;
        private System.Windows.Forms.TextBox textBoxPONo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewReceipt;
        private System.Windows.Forms.GroupBox groupBoxPrintSleeve;
        private System.Windows.Forms.TextBox textBoxQuantity;
        private System.Windows.Forms.TextBox textBoxLotNo;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dateTimePickerExpiredDate;
        private System.Windows.Forms.Button buttonCommit;
        private System.Windows.Forms.Label labelPartNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label labelReceived;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
    }
}