namespace PrintSleeveManagement
{
    partial class MoveForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.labelLocation = new System.Windows.Forms.Label();
            this.buttonSelecteLocation = new System.Windows.Forms.Button();
            this.labelResult = new System.Windows.Forms.Label();
            this.buttonMovePrintSleeve = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(246, 55);
            this.label1.TabIndex = 0;
            this.label1.Text = "Move To..";
            // 
            // labelLocation
            // 
            this.labelLocation.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelLocation.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelLocation.Location = new System.Drawing.Point(12, 68);
            this.labelLocation.Name = "labelLocation";
            this.labelLocation.Size = new System.Drawing.Size(1160, 59);
            this.labelLocation.TabIndex = 1;
            this.labelLocation.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // buttonSelecteLocation
            // 
            this.buttonSelecteLocation.Location = new System.Drawing.Point(1022, 130);
            this.buttonSelecteLocation.Name = "buttonSelecteLocation";
            this.buttonSelecteLocation.Size = new System.Drawing.Size(150, 50);
            this.buttonSelecteLocation.TabIndex = 2;
            this.buttonSelecteLocation.Text = "Selecte Location Manually";
            this.buttonSelecteLocation.UseVisualStyleBackColor = true;
            this.buttonSelecteLocation.Click += new System.EventHandler(this.buttonSelecteLocation_Click);
            // 
            // labelResult
            // 
            this.labelResult.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.labelResult.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(222)));
            this.labelResult.Location = new System.Drawing.Point(12, 183);
            this.labelResult.Name = "labelResult";
            this.labelResult.Size = new System.Drawing.Size(1160, 256);
            this.labelResult.TabIndex = 3;
            // 
            // buttonMovePrintSleeve
            // 
            this.buttonMovePrintSleeve.Location = new System.Drawing.Point(1022, 442);
            this.buttonMovePrintSleeve.Name = "buttonMovePrintSleeve";
            this.buttonMovePrintSleeve.Size = new System.Drawing.Size(150, 50);
            this.buttonMovePrintSleeve.TabIndex = 4;
            this.buttonMovePrintSleeve.Text = "Move Printsleeve Manually";
            this.buttonMovePrintSleeve.UseVisualStyleBackColor = true;
            this.buttonMovePrintSleeve.Click += new System.EventHandler(this.buttonSelectePrintSleeve_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.textBoxInput);
            this.groupBox1.Location = new System.Drawing.Point(12, 498);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1160, 52);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Input";
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(7, 20);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(1147, 20);
            this.textBoxInput.TabIndex = 0;
            // 
            // MoveForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 559);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.buttonMovePrintSleeve);
            this.Controls.Add(this.labelResult);
            this.Controls.Add(this.buttonSelecteLocation);
            this.Controls.Add(this.labelLocation);
            this.Controls.Add(this.label1);
            this.Name = "MoveForm";
            this.Text = "Move";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelLocation;
        private System.Windows.Forms.Button buttonSelecteLocation;
        private System.Windows.Forms.Label labelResult;
        private System.Windows.Forms.Button buttonMovePrintSleeve;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox textBoxInput;
    }
}