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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBoxReceipt = new System.Windows.Forms.GroupBox();
            this.buttonClear = new System.Windows.Forms.Button();
            this.buttonCommit = new System.Windows.Forms.Button();
            this.dataGridViewReceipt = new System.Windows.Forms.DataGridView();
            this.buttonPOBrowse = new System.Windows.Forms.Button();
            this.textBoxPONo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxPrintSleeve = new System.Windows.Forms.GroupBox();
            this.buttonAddPrintSleeve = new System.Windows.Forms.Button();
            this.labelAvailable = new System.Windows.Forms.Label();
            this.labelReceived = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.labelPartNo = new System.Windows.Forms.Label();
            this.textBoxQuantity = new System.Windows.Forms.TextBox();
            this.textBoxLotNo = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dateTimePickerExpiredDate = new System.Windows.Forms.DateTimePicker();
            this.groupBoxLocation = new System.Windows.Forms.GroupBox();
            this.dataGridViewLocation = new System.Windows.Forms.DataGridView();
            this.buttonSelectLocation = new System.Windows.Forms.Button();
            this.labelLocation = new System.Windows.Forms.Label();
            this.groupBoxStatus = new System.Windows.Forms.GroupBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.groupBoxAvailable = new System.Windows.Forms.GroupBox();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridViewAvailable = new System.Windows.Forms.DataGridView();
            this.groupBoxInputDevice = new System.Windows.Forms.GroupBox();
            this.textBoxInputData = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBoxReceipt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewReceipt)).BeginInit();
            this.groupBoxPrintSleeve.SuspendLayout();
            this.groupBoxLocation.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocation)).BeginInit();
            this.groupBoxStatus.SuspendLayout();
            this.groupBoxAvailable.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailable)).BeginInit();
            this.groupBoxInputDevice.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxReceipt
            // 
            this.groupBoxReceipt.Controls.Add(this.buttonClear);
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
            // buttonClear
            // 
            this.buttonClear.Location = new System.Drawing.Point(322, 19);
            this.buttonClear.Name = "buttonClear";
            this.buttonClear.Size = new System.Drawing.Size(75, 23);
            this.buttonClear.TabIndex = 4;
            this.buttonClear.Text = "C&lear";
            this.buttonClear.UseVisualStyleBackColor = true;
            this.buttonClear.Click += new System.EventHandler(this.buttonClear_Click);
            // 
            // buttonCommit
            // 
            this.buttonCommit.Location = new System.Drawing.Point(241, 19);
            this.buttonCommit.Name = "buttonCommit";
            this.buttonCommit.Size = new System.Drawing.Size(75, 23);
            this.buttonCommit.TabIndex = 3;
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
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewReceipt.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewReceipt.Location = new System.Drawing.Point(6, 47);
            this.dataGridViewReceipt.Name = "dataGridViewReceipt";
            this.dataGridViewReceipt.ReadOnly = true;
            this.dataGridViewReceipt.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewReceipt.Size = new System.Drawing.Size(450, 413);
            this.dataGridViewReceipt.TabIndex = 5;
            // 
            // buttonPOBrowse
            // 
            this.buttonPOBrowse.Location = new System.Drawing.Point(160, 18);
            this.buttonPOBrowse.Name = "buttonPOBrowse";
            this.buttonPOBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonPOBrowse.TabIndex = 2;
            this.buttonPOBrowse.Text = "&Browse...";
            this.buttonPOBrowse.UseVisualStyleBackColor = true;
            this.buttonPOBrowse.Click += new System.EventHandler(this.buttonPOBrowse_Click);
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
            this.groupBoxPrintSleeve.Controls.Add(this.buttonAddPrintSleeve);
            this.groupBoxPrintSleeve.Controls.Add(this.labelAvailable);
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
            this.groupBoxPrintSleeve.Location = new System.Drawing.Point(482, 65);
            this.groupBoxPrintSleeve.Name = "groupBoxPrintSleeve";
            this.groupBoxPrintSleeve.Size = new System.Drawing.Size(1170, 313);
            this.groupBoxPrintSleeve.TabIndex = 1;
            this.groupBoxPrintSleeve.TabStop = false;
            this.groupBoxPrintSleeve.Text = "PrintSleeve";
            // 
            // buttonAddPrintSleeve
            // 
            this.buttonAddPrintSleeve.Location = new System.Drawing.Point(9, 227);
            this.buttonAddPrintSleeve.Name = "buttonAddPrintSleeve";
            this.buttonAddPrintSleeve.Size = new System.Drawing.Size(196, 60);
            this.buttonAddPrintSleeve.TabIndex = 4;
            this.buttonAddPrintSleeve.Text = "&Add PrintSleeve Manuanlly";
            this.buttonAddPrintSleeve.UseVisualStyleBackColor = true;
            this.buttonAddPrintSleeve.Click += new System.EventHandler(this.buttonAddPrintSleeve_Click);
            // 
            // labelAvailable
            // 
            this.labelAvailable.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelAvailable.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelAvailable.Location = new System.Drawing.Point(607, 227);
            this.labelAvailable.Name = "labelAvailable";
            this.labelAvailable.Size = new System.Drawing.Size(205, 72);
            this.labelAvailable.TabIndex = 4;
            this.labelAvailable.Text = "0";
            this.labelAvailable.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // labelReceived
            // 
            this.labelReceived.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelReceived.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelReceived.Location = new System.Drawing.Point(606, 142);
            this.labelReceived.Name = "labelReceived";
            this.labelReceived.Size = new System.Drawing.Size(205, 72);
            this.labelReceived.TabIndex = 4;
            this.labelReceived.Text = "0";
            this.labelReceived.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label6.Location = new System.Drawing.Point(305, 228);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(267, 73);
            this.label6.TabIndex = 4;
            this.label6.Text = "Moved :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label4.Location = new System.Drawing.Point(355, 142);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(217, 73);
            this.label4.TabIndex = 4;
            this.label4.Text = "Total :";
            // 
            // labelPartNo
            // 
            this.labelPartNo.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelPartNo.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelPartNo.Location = new System.Drawing.Point(9, 20);
            this.labelPartNo.Name = "labelPartNo";
            this.labelPartNo.Size = new System.Drawing.Size(1155, 99);
            this.labelPartNo.TabIndex = 4;
            // 
            // textBoxQuantity
            // 
            this.textBoxQuantity.Location = new System.Drawing.Point(105, 196);
            this.textBoxQuantity.Name = "textBoxQuantity";
            this.textBoxQuantity.Size = new System.Drawing.Size(100, 20);
            this.textBoxQuantity.TabIndex = 3;
            this.textBoxQuantity.Text = "200";
            // 
            // textBoxLotNo
            // 
            this.textBoxLotNo.Location = new System.Drawing.Point(105, 170);
            this.textBoxLotNo.Name = "textBoxLotNo";
            this.textBoxLotNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxLotNo.TabIndex = 1;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 199);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 13);
            this.label5.TabIndex = 2;
            this.label5.Text = "Quantity (M/Roll) :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(57, 173);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(42, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "LotNo :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 150);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Expired Date :";
            // 
            // dateTimePickerExpiredDate
            // 
            this.dateTimePickerExpiredDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dateTimePickerExpiredDate.Location = new System.Drawing.Point(105, 144);
            this.dateTimePickerExpiredDate.Name = "dateTimePickerExpiredDate";
            this.dateTimePickerExpiredDate.Size = new System.Drawing.Size(100, 20);
            this.dateTimePickerExpiredDate.TabIndex = 2;
            this.dateTimePickerExpiredDate.Value = new System.DateTime(2022, 11, 12, 0, 0, 0, 0);
            // 
            // groupBoxLocation
            // 
            this.groupBoxLocation.Controls.Add(this.dataGridViewLocation);
            this.groupBoxLocation.Controls.Add(this.buttonSelectLocation);
            this.groupBoxLocation.Controls.Add(this.labelLocation);
            this.groupBoxLocation.Location = new System.Drawing.Point(488, 384);
            this.groupBoxLocation.Name = "groupBoxLocation";
            this.groupBoxLocation.Size = new System.Drawing.Size(1170, 329);
            this.groupBoxLocation.TabIndex = 2;
            this.groupBoxLocation.TabStop = false;
            this.groupBoxLocation.Text = "Location";
            // 
            // dataGridViewLocation
            // 
            this.dataGridViewLocation.AllowUserToAddRows = false;
            this.dataGridViewLocation.AllowUserToDeleteRows = false;
            this.dataGridViewLocation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewLocation.Enabled = false;
            this.dataGridViewLocation.Location = new System.Drawing.Point(7, 95);
            this.dataGridViewLocation.Name = "dataGridViewLocation";
            this.dataGridViewLocation.ReadOnly = true;
            this.dataGridViewLocation.Size = new System.Drawing.Size(952, 228);
            this.dataGridViewLocation.TabIndex = 6;
            // 
            // buttonSelectLocation
            // 
            this.buttonSelectLocation.Location = new System.Drawing.Point(965, 23);
            this.buttonSelectLocation.Name = "buttonSelectLocation";
            this.buttonSelectLocation.Size = new System.Drawing.Size(196, 60);
            this.buttonSelectLocation.TabIndex = 5;
            this.buttonSelectLocation.Text = "&Select Location Manuanlly";
            this.buttonSelectLocation.UseVisualStyleBackColor = true;
            this.buttonSelectLocation.Click += new System.EventHandler(this.buttonSelectLocation_Click);
            // 
            // labelLocation
            // 
            this.labelLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelLocation.Location = new System.Drawing.Point(6, 16);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(953, 75);
            this.labelLocation.TabIndex = 4;
            // 
            // groupBoxStatus
            // 
            this.groupBoxStatus.Controls.Add(this.labelStatus);
            this.groupBoxStatus.Location = new System.Drawing.Point(482, 719);
            this.groupBoxStatus.Name = "groupBoxStatus";
            this.groupBoxStatus.Size = new System.Drawing.Size(1170, 130);
            this.groupBoxStatus.TabIndex = 3;
            this.groupBoxStatus.TabStop = false;
            this.groupBoxStatus.Text = "Status";
            // 
            // labelStatus
            // 
            this.labelStatus.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 72F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelStatus.Location = new System.Drawing.Point(6, 16);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(1155, 103);
            this.labelStatus.TabIndex = 4;
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBoxAvailable
            // 
            this.groupBoxAvailable.Controls.Add(this.buttonDelete);
            this.groupBoxAvailable.Controls.Add(this.dataGridViewAvailable);
            this.groupBoxAvailable.Location = new System.Drawing.Point(12, 497);
            this.groupBoxAvailable.Name = "groupBoxAvailable";
            this.groupBoxAvailable.Size = new System.Drawing.Size(464, 352);
            this.groupBoxAvailable.TabIndex = 4;
            this.groupBoxAvailable.TabStop = false;
            this.groupBoxAvailable.Text = "Available";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(383, 323);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 1;
            this.buttonDelete.Text = "Delete";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // dataGridViewAvailable
            // 
            this.dataGridViewAvailable.AllowUserToAddRows = false;
            this.dataGridViewAvailable.AllowUserToDeleteRows = false;
            this.dataGridViewAvailable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAvailable.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewAvailable.Name = "dataGridViewAvailable";
            this.dataGridViewAvailable.ReadOnly = true;
            this.dataGridViewAvailable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewAvailable.Size = new System.Drawing.Size(449, 297);
            this.dataGridViewAvailable.TabIndex = 0;
            // 
            // groupBoxInputDevice
            // 
            this.groupBoxInputDevice.Controls.Add(this.textBoxInputData);
            this.groupBoxInputDevice.Controls.Add(this.label7);
            this.groupBoxInputDevice.Location = new System.Drawing.Point(482, 17);
            this.groupBoxInputDevice.Name = "groupBoxInputDevice";
            this.groupBoxInputDevice.Size = new System.Drawing.Size(1170, 42);
            this.groupBoxInputDevice.TabIndex = 5;
            this.groupBoxInputDevice.TabStop = false;
            this.groupBoxInputDevice.Text = "Input Device:";
            // 
            // textBoxInputData
            // 
            this.textBoxInputData.Enabled = false;
            this.textBoxInputData.Location = new System.Drawing.Point(75, 15);
            this.textBoxInputData.Name = "textBoxInputData";
            this.textBoxInputData.Size = new System.Drawing.Size(1086, 20);
            this.textBoxInputData.TabIndex = 1;
            this.textBoxInputData.TextChanged += new System.EventHandler(this.textBoxInputData_TextChanged);
            this.textBoxInputData.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxInputData_KeyPress);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 19);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(63, 13);
            this.label7.TabIndex = 0;
            this.label7.Text = "Input Data :";
            // 
            // PutAwayForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 861);
            this.Controls.Add(this.groupBoxInputDevice);
            this.Controls.Add(this.groupBoxAvailable);
            this.Controls.Add(this.groupBoxStatus);
            this.Controls.Add(this.groupBoxLocation);
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
            this.groupBoxLocation.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewLocation)).EndInit();
            this.groupBoxStatus.ResumeLayout(false);
            this.groupBoxAvailable.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAvailable)).EndInit();
            this.groupBoxInputDevice.ResumeLayout(false);
            this.groupBoxInputDevice.PerformLayout();
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
        private System.Windows.Forms.Label labelAvailable;
        private System.Windows.Forms.Label labelReceived;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBoxLocation;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.GroupBox groupBoxStatus;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.GroupBox groupBoxAvailable;
        private System.Windows.Forms.DataGridView dataGridViewAvailable;
        private System.Windows.Forms.Button buttonClear;
        private System.Windows.Forms.Button buttonAddPrintSleeve;
        private System.Windows.Forms.Button buttonSelectLocation;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridView dataGridViewLocation;
        private System.Windows.Forms.GroupBox groupBoxInputDevice;
        private System.Windows.Forms.TextBox textBoxInputData;
        private System.Windows.Forms.Label label7;
    }
}