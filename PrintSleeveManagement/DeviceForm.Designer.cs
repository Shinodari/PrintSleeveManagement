namespace PrintSleeveManagement
{
    partial class DeviceForm
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
            this.labelActiveSerialPort = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxSerialPort = new System.Windows.Forms.ListBox();
            this.buttonActivate = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active COM Port :";
            // 
            // labelActiveSerialPort
            // 
            this.labelActiveSerialPort.AutoSize = true;
            this.labelActiveSerialPort.Location = new System.Drawing.Point(159, 13);
            this.labelActiveSerialPort.Name = "labelActiveSerialPort";
            this.labelActiveSerialPort.Size = new System.Drawing.Size(37, 13);
            this.labelActiveSerialPort.TabIndex = 1;
            this.labelActiveSerialPort.Text = "COM0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(141, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Select COM Port of Device :";
            // 
            // listBoxSerialPort
            // 
            this.listBoxSerialPort.FormattingEnabled = true;
            this.listBoxSerialPort.Location = new System.Drawing.Point(159, 36);
            this.listBoxSerialPort.Name = "listBoxSerialPort";
            this.listBoxSerialPort.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.listBoxSerialPort.Size = new System.Drawing.Size(89, 95);
            this.listBoxSerialPort.TabIndex = 3;
            // 
            // buttonActivate
            // 
            this.buttonActivate.Location = new System.Drawing.Point(159, 138);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(75, 23);
            this.buttonActivate.TabIndex = 4;
            this.buttonActivate.Text = "&Activate";
            this.buttonActivate.UseVisualStyleBackColor = true;
            this.buttonActivate.Click += new System.EventHandler(this.buttonActivate_Click);
            // 
            // DeviceForm
            // 
            this.AcceptButton = this.buttonActivate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(609, 176);
            this.Controls.Add(this.buttonActivate);
            this.Controls.Add(this.listBoxSerialPort);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.labelActiveSerialPort);
            this.Controls.Add(this.label1);
            this.Name = "DeviceForm";
            this.Text = "DeviceForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelActiveSerialPort;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBoxSerialPort;
        private System.Windows.Forms.Button buttonActivate;
    }
}