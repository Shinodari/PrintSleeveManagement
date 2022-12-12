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
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.buttonDeleteOrder = new System.Windows.Forms.Button();
            this.buttonImportOrder = new System.Windows.Forms.Button();
            this.buttonCreateOrder = new System.Windows.Forms.Button();
            this.textBoxOrderNo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBoxOrderDetail = new System.Windows.Forms.GroupBox();
            this.dataGridViewOrder = new System.Windows.Forms.DataGridView();
            this.groupBoxAllocate = new System.Windows.Forms.GroupBox();
            this.dataGridViewAllocate = new System.Windows.Forms.DataGridView();
            this.buttonAllocate = new System.Windows.Forms.Button();
            this.groupBoxOrder.SuspendLayout();
            this.groupBoxOrderDetail.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).BeginInit();
            this.groupBoxAllocate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllocate)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.buttonDeleteOrder);
            this.groupBoxOrder.Controls.Add(this.buttonImportOrder);
            this.groupBoxOrder.Controls.Add(this.buttonCreateOrder);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderNo);
            this.groupBoxOrder.Controls.Add(this.label1);
            this.groupBoxOrder.Location = new System.Drawing.Point(13, 13);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(481, 77);
            this.groupBoxOrder.TabIndex = 0;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Order";
            // 
            // buttonDeleteOrder
            // 
            this.buttonDeleteOrder.Location = new System.Drawing.Point(174, 46);
            this.buttonDeleteOrder.Name = "buttonDeleteOrder";
            this.buttonDeleteOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonDeleteOrder.TabIndex = 2;
            this.buttonDeleteOrder.Text = "&Delete";
            this.buttonDeleteOrder.UseVisualStyleBackColor = true;
            // 
            // buttonImportOrder
            // 
            this.buttonImportOrder.Location = new System.Drawing.Point(255, 17);
            this.buttonImportOrder.Name = "buttonImportOrder";
            this.buttonImportOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonImportOrder.TabIndex = 2;
            this.buttonImportOrder.Text = "&Import..";
            this.buttonImportOrder.UseVisualStyleBackColor = true;
            // 
            // buttonCreateOrder
            // 
            this.buttonCreateOrder.Location = new System.Drawing.Point(174, 17);
            this.buttonCreateOrder.Name = "buttonCreateOrder";
            this.buttonCreateOrder.Size = new System.Drawing.Size(75, 23);
            this.buttonCreateOrder.TabIndex = 2;
            this.buttonCreateOrder.Text = "&Create";
            this.buttonCreateOrder.UseVisualStyleBackColor = true;
            this.buttonCreateOrder.Click += new System.EventHandler(this.buttonCreateOrder_Click);
            // 
            // textBoxOrderNo
            // 
            this.textBoxOrderNo.Location = new System.Drawing.Point(68, 19);
            this.textBoxOrderNo.Name = "textBoxOrderNo";
            this.textBoxOrderNo.Size = new System.Drawing.Size(100, 20);
            this.textBoxOrderNo.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Order No :";
            // 
            // groupBoxOrderDetail
            // 
            this.groupBoxOrderDetail.Controls.Add(this.dataGridViewOrder);
            this.groupBoxOrderDetail.Location = new System.Drawing.Point(13, 96);
            this.groupBoxOrderDetail.Name = "groupBoxOrderDetail";
            this.groupBoxOrderDetail.Size = new System.Drawing.Size(481, 439);
            this.groupBoxOrderDetail.TabIndex = 1;
            this.groupBoxOrderDetail.TabStop = false;
            this.groupBoxOrderDetail.Text = "Order Detail";
            // 
            // dataGridViewOrder
            // 
            this.dataGridViewOrder.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrder.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewOrder.MultiSelect = false;
            this.dataGridViewOrder.Name = "dataGridViewOrder";
            this.dataGridViewOrder.Size = new System.Drawing.Size(468, 413);
            this.dataGridViewOrder.TabIndex = 0;
            this.dataGridViewOrder.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewOrder_CellValueChanged);
            // 
            // groupBoxAllocate
            // 
            this.groupBoxAllocate.Controls.Add(this.dataGridViewAllocate);
            this.groupBoxAllocate.Location = new System.Drawing.Point(500, 96);
            this.groupBoxAllocate.Name = "groupBoxAllocate";
            this.groupBoxAllocate.Size = new System.Drawing.Size(564, 439);
            this.groupBoxAllocate.TabIndex = 2;
            this.groupBoxAllocate.TabStop = false;
            this.groupBoxAllocate.Text = "Allocate";
            // 
            // dataGridViewAllocate
            // 
            this.dataGridViewAllocate.AllowUserToAddRows = false;
            this.dataGridViewAllocate.AllowUserToDeleteRows = false;
            this.dataGridViewAllocate.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewAllocate.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAllocate.Location = new System.Drawing.Point(7, 20);
            this.dataGridViewAllocate.Name = "dataGridViewAllocate";
            this.dataGridViewAllocate.Size = new System.Drawing.Size(546, 413);
            this.dataGridViewAllocate.TabIndex = 0;
            this.dataGridViewAllocate.CellValueChanged += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridViewAllocate_CellValueChanged);
            // 
            // buttonAllocate
            // 
            this.buttonAllocate.Location = new System.Drawing.Point(928, 23);
            this.buttonAllocate.Name = "buttonAllocate";
            this.buttonAllocate.Size = new System.Drawing.Size(136, 59);
            this.buttonAllocate.TabIndex = 1;
            this.buttonAllocate.Text = "&Allocate";
            this.buttonAllocate.UseVisualStyleBackColor = true;
            this.buttonAllocate.Click += new System.EventHandler(this.buttonAllocate_Click);
            // 
            // PickForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 547);
            this.Controls.Add(this.groupBoxAllocate);
            this.Controls.Add(this.buttonAllocate);
            this.Controls.Add(this.groupBoxOrderDetail);
            this.Controls.Add(this.groupBoxOrder);
            this.Name = "PickForm";
            this.Text = "Allocate";
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            this.groupBoxOrderDetail.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrder)).EndInit();
            this.groupBoxAllocate.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAllocate)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.Button buttonDeleteOrder;
        private System.Windows.Forms.Button buttonImportOrder;
        private System.Windows.Forms.Button buttonCreateOrder;
        private System.Windows.Forms.TextBox textBoxOrderNo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBoxOrderDetail;
        private System.Windows.Forms.DataGridView dataGridViewOrder;
        private System.Windows.Forms.GroupBox groupBoxAllocate;
        private System.Windows.Forms.DataGridView dataGridViewAllocate;
        private System.Windows.Forms.Button buttonAllocate;
    }
}