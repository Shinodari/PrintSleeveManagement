namespace PrintSleeveManagement
{
    partial class ShipForm
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
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.dataGridViewShip = new System.Windows.Forms.DataGridView();
            this.buttonShip = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShip)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.Location = new System.Drawing.Point(418, 12);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(75, 23);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.Text = "&Refresh";
            this.buttonRefresh.UseVisualStyleBackColor = true;
            this.buttonRefresh.Click += new System.EventHandler(this.buttonRefresh_Click);
            // 
            // dataGridViewShip
            // 
            this.dataGridViewShip.AllowUserToAddRows = false;
            this.dataGridViewShip.AllowUserToDeleteRows = false;
            this.dataGridViewShip.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewShip.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewShip.Location = new System.Drawing.Point(12, 42);
            this.dataGridViewShip.MultiSelect = false;
            this.dataGridViewShip.Name = "dataGridViewShip";
            this.dataGridViewShip.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridViewShip.Size = new System.Drawing.Size(481, 479);
            this.dataGridViewShip.TabIndex = 1;
            // 
            // buttonShip
            // 
            this.buttonShip.Location = new System.Drawing.Point(12, 12);
            this.buttonShip.Name = "buttonShip";
            this.buttonShip.Size = new System.Drawing.Size(75, 23);
            this.buttonShip.TabIndex = 2;
            this.buttonShip.Text = "&Ship";
            this.buttonShip.UseVisualStyleBackColor = true;
            this.buttonShip.Click += new System.EventHandler(this.buttonShip_Click);
            // 
            // ShipForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(505, 533);
            this.Controls.Add(this.buttonShip);
            this.Controls.Add(this.dataGridViewShip);
            this.Controls.Add(this.buttonRefresh);
            this.Name = "ShipForm";
            this.Text = "Ship";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewShip)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonRefresh;
        private System.Windows.Forms.DataGridView dataGridViewShip;
        private System.Windows.Forms.Button buttonShip;
    }
}