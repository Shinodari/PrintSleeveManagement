﻿namespace PrintSleeveManagement
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
            this.buttonActivate = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBoxOutgoingPort = new System.Windows.Forms.ComboBox();
            this.comboBoxIncomingPort = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBoxInputMode = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 46);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Active COM Port :";
            // 
            // labelActiveSerialPort
            // 
            this.labelActiveSerialPort.AutoSize = true;
            this.labelActiveSerialPort.Location = new System.Drawing.Point(107, 46);
            this.labelActiveSerialPort.Name = "labelActiveSerialPort";
            this.labelActiveSerialPort.Size = new System.Drawing.Size(37, 13);
            this.labelActiveSerialPort.TabIndex = 1;
            this.labelActiveSerialPort.Text = "COM0";
            // 
            // buttonActivate
            // 
            this.buttonActivate.Location = new System.Drawing.Point(107, 116);
            this.buttonActivate.Name = "buttonActivate";
            this.buttonActivate.Size = new System.Drawing.Size(75, 23);
            this.buttonActivate.TabIndex = 4;
            this.buttonActivate.Text = "&Activate";
            this.buttonActivate.UseVisualStyleBackColor = true;
            this.buttonActivate.Click += new System.EventHandler(this.buttonActivate_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(23, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Outgoing Port :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(23, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(78, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Incoming Port :";
            // 
            // comboBoxOutgoingPort
            // 
            this.comboBoxOutgoingPort.FormattingEnabled = true;
            this.comboBoxOutgoingPort.Location = new System.Drawing.Point(110, 62);
            this.comboBoxOutgoingPort.Name = "comboBoxOutgoingPort";
            this.comboBoxOutgoingPort.Size = new System.Drawing.Size(166, 21);
            this.comboBoxOutgoingPort.TabIndex = 7;
            // 
            // comboBoxIncomingPort
            // 
            this.comboBoxIncomingPort.FormattingEnabled = true;
            this.comboBoxIncomingPort.Location = new System.Drawing.Point(110, 89);
            this.comboBoxIncomingPort.Name = "comboBoxIncomingPort";
            this.comboBoxIncomingPort.Size = new System.Drawing.Size(166, 21);
            this.comboBoxIncomingPort.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 13);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Input Mode :";
            // 
            // comboBoxInputMode
            // 
            this.comboBoxInputMode.FormattingEnabled = true;
            this.comboBoxInputMode.Location = new System.Drawing.Point(110, 10);
            this.comboBoxInputMode.Name = "comboBoxInputMode";
            this.comboBoxInputMode.Size = new System.Drawing.Size(166, 21);
            this.comboBoxInputMode.TabIndex = 9;
            // 
            // DeviceForm
            // 
            this.AcceptButton = this.buttonActivate;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(288, 151);
            this.Controls.Add(this.comboBoxInputMode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBoxIncomingPort);
            this.Controls.Add(this.comboBoxOutgoingPort);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.buttonActivate);
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
        private System.Windows.Forms.Button buttonActivate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBoxOutgoingPort;
        private System.Windows.Forms.ComboBox comboBoxIncomingPort;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBoxInputMode;
    }
}