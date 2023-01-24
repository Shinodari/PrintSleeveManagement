namespace PrintSleeveManagement.Models
{
    partial class BalanceForm
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
            this.dataGridViewBalance = new System.Windows.Forms.DataGridView();
            this.buttonFilter = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridViewBalance
            // 
            this.dataGridViewBalance.AllowUserToAddRows = false;
            this.dataGridViewBalance.AllowUserToDeleteRows = false;
            this.dataGridViewBalance.AllowUserToOrderColumns = true;
            this.dataGridViewBalance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridViewBalance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBalance.Location = new System.Drawing.Point(13, 41);
            this.dataGridViewBalance.Name = "dataGridViewBalance";
            this.dataGridViewBalance.ReadOnly = true;
            this.dataGridViewBalance.Size = new System.Drawing.Size(1626, 808);
            this.dataGridViewBalance.TabIndex = 0;
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(1564, 12);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(75, 23);
            this.buttonFilter.TabIndex = 1;
            this.buttonFilter.Text = "Filter..";
            this.buttonFilter.UseVisualStyleBackColor = true;
            // 
            // BalanceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 861);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.dataGridViewBalance);
            this.Name = "BalanceForm";
            this.Text = "Balance";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBalance)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridViewBalance;
        private System.Windows.Forms.Button buttonFilter;
    }
}