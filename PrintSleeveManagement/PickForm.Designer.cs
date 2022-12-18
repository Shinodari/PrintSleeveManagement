namespace PrintSleeveManagement
{
    partial class PickForm
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
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.buttonStage = new System.Windows.Forms.Button();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.buttonView = new System.Windows.Forms.Button();
            this.textBoxOrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxDevice = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.buttonInputManually = new System.Windows.Forms.Button();
            this.groupBoxStage = new System.Windows.Forms.GroupBox();
            this.dataGridViewPick = new System.Windows.Forms.DataGridView();
            this.groupBoxOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.groupBoxDevice.SuspendLayout();
            this.groupBoxStage.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPick)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.buttonStage);
            this.groupBoxOrder.Controls.Add(this.dataGridViewOrder);
            this.groupBoxOrder.Controls.Add(this.buttonBrowse);
            this.groupBoxOrder.Controls.Add(this.buttonView);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderNo);
            this.groupBoxOrder.Controls.Add(this.label1);
            this.groupBoxOrder.Location = new System.Drawing.Point(13, 13);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(1373, 635);
            this.groupBoxOrder.TabIndex = 0;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Order";
            // 
            // buttonStage
            // 
            this.buttonStage.Location = new System.Drawing.Point(1241, 13);
            this.buttonStage.Name = "buttonStage";
            this.buttonStage.Size = new System.Drawing.Size(126, 55);
            this.buttonStage.TabIndex = 4;
            this.buttonStage.Text = "Stage";
            this.buttonStage.UseVisualStyleBackColor = true;
            this.buttonStage.Click += new System.EventHandler(this.buttonStage_Click);
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.AllowUserToAddRows = false;
            this.dataGridViewOrder.AllowUserToDeleteRows = false;
            this.dataGridViewOrder.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewOrder.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 26F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewOrder.DefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridViewOrder.Enabled = false;
            this.dataGridViewOrder.Location = new System.Drawing.Point(6, 74);
            this.dataGridViewOrder.MultiSelect = false;
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.ReadOnly = true;
            this.dataGridViewOrder.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewOrder.Size = new System.Drawing.Size(1361, 555);
            this.dataGridViewOrder.TabIndex = 3;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(256, 17);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(75, 23);
            this.buttonBrowse.TabIndex = 2;
            this.buttonBrowse.Text = "Browse..";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            // 
            // buttonView
            // 
            this.buttonView.Location = new System.Drawing.Point(175, 17);
            this.buttonView.Name = "buttonView";
            this.buttonView.Size = new System.Drawing.Size(75, 23);
            this.buttonView.TabIndex = 2;
            this.buttonView.Text = "View";
            this.buttonView.UseVisualStyleBackColor = true;
            this.buttonView.Click += new System.EventHandler(this.buttonView_Click);
            // 
            // textBoxOrderNo
            // 
            this.textBoxOrderNo.Location = new System.Drawing.Point(69, 19);
            this.textBoxOrderNo.Name = "textBoxOrderNo";
            this.textBoxOrderNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxOrderNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order No :";
            // 
            // groupBoxDevice
            // 
            this.groupBoxDevice.Controls.Add(this.textBox1);
            this.groupBoxDevice.Controls.Add(this.label2);
            this.groupBoxDevice.Location = new System.Drawing.Point(1392, 13);
            this.groupBoxDevice.Name = "groupBoxDevice";
            this.groupBoxDevice.Size = new System.Drawing.Size(470, 49);
            this.groupBoxDevice.TabIndex = 1;
            this.groupBoxDevice.TabStop = false;
            this.groupBoxDevice.Text = "Input Device";
            // 
            // textBox1
            // 
            this.textBox1.Enabled = false;
            this.textBox1.Location = new System.Drawing.Point(87, 19);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(377, 20);
            this.textBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 23);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(74, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Input Device :";
            // 
            // buttonInputManually
            // 
            this.buttonInputManually.Location = new System.Drawing.Point(319, 520);
            this.buttonInputManually.Name = "buttonInputManually";
            this.buttonInputManually.Size = new System.Drawing.Size(144, 54);
            this.buttonInputManually.TabIndex = 2;
            this.buttonInputManually.Text = "Input RollNo Manually..";
            this.buttonInputManually.UseVisualStyleBackColor = true;
            this.buttonInputManually.Click += new System.EventHandler(this.buttonInputManually_Click);
            // 
            // groupBoxStage
            // 
            this.groupBoxStage.Controls.Add(this.buttonInputManually);
            this.groupBoxStage.Controls.Add(this.dataGridViewPick);
            this.groupBoxStage.Location = new System.Drawing.Point(1393, 68);
            this.groupBoxStage.Name = "groupBoxStage";
            this.groupBoxStage.Size = new System.Drawing.Size(469, 580);
            this.groupBoxStage.TabIndex = 2;
            this.groupBoxStage.TabStop = false;
            this.groupBoxStage.Text = "Stage";
            // 
            // dataGridViewPick
            // 
            this.dataGridViewPick.AllowUserToAddRows = false;
            this.dataGridViewPick.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewPick.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPick.Location = new System.Drawing.Point(6, 19);
            this.dataGridViewPick.MultiSelect = false;
            this.dataGridViewPick.Name = "dataGridViewPick";
            this.dataGridViewPick.ReadOnly = true;
            this.dataGridViewPick.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewPick.Size = new System.Drawing.Size(457, 495);
            this.dataGridViewPick.TabIndex = 0;
            // 
            // PickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1874, 658);
            this.Controls.Add(this.groupBoxStage);
            this.Controls.Add(this.groupBoxDevice);
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "PickForm";
            this.Text = "Pick";
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.groupBoxDevice.ResumeLayout(false);
            this.groupBoxDevice.PerformLayout();
            this.groupBoxStage.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPick)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Button buttonView;
        private System.Windows.Forms.TextBox textBoxOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.GroupBox groupBoxDevice;
        private System.Windows.Forms.Button buttonInputManually;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBoxStage;
        private System.Windows.Forms.DataGridView dataGridViewPick;
        private System.Windows.Forms.Button buttonStage;
    }
}