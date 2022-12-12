namespace PrintSleeveManagement
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripPutAway = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonPick = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonStage = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonShip = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTransfer = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonBalance = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonTransaction = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripConnectDevice = new System.Windows.Forms.ToolStripButton();
            this.toolStripDevice = new System.Windows.Forms.ToolStripButton();
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusMain = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusDevice = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusUser = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStrip1.SuspendLayout();
            this.statusStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButton1,
            this.toolStripPutAway,
            this.toolStripButtonPick,
            this.toolStripButtonStage,
            this.toolStripButtonShip,
            this.toolStripButtonTransfer,
            this.toolStripButtonBalance,
            this.toolStripButtonTransaction,
            this.toolStripSeparator1,
            this.toolStripConnectDevice,
            this.toolStripDevice});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Padding = new System.Windows.Forms.Padding(0, 5, 1, 5);
            this.toolStrip1.Size = new System.Drawing.Size(1664, 58);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButton1.Size = new System.Drawing.Size(85, 45);
            this.toolStripButton1.Text = "&Receipt";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripPutAway
            // 
            this.toolStripPutAway.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripPutAway.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripPutAway.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripPutAway.Image = ((System.Drawing.Image)(resources.GetObject("toolStripPutAway.Image")));
            this.toolStripPutAway.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripPutAway.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripPutAway.Name = "toolStripPutAway";
            this.toolStripPutAway.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripPutAway.Size = new System.Drawing.Size(95, 45);
            this.toolStripPutAway.Text = "&PutAway";
            this.toolStripPutAway.Click += new System.EventHandler(this.toolStripPutAway_Click);
            // 
            // toolStripButtonPick
            // 
            this.toolStripButtonPick.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonPick.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonPick.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonPick.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonPick.Image")));
            this.toolStripButtonPick.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonPick.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButtonPick.Name = "toolStripButtonPick";
            this.toolStripButtonPick.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButtonPick.Size = new System.Drawing.Size(62, 45);
            this.toolStripButtonPick.Text = "Pic&k";
            this.toolStripButtonPick.Click += new System.EventHandler(this.toolStripButtonPick_Click);
            // 
            // toolStripButtonStage
            // 
            this.toolStripButtonStage.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonStage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStage.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonStage.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStage.Image")));
            this.toolStripButtonStage.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStage.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButtonStage.Name = "toolStripButtonStage";
            this.toolStripButtonStage.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButtonStage.Size = new System.Drawing.Size(72, 45);
            this.toolStripButtonStage.Text = "&Stage";
            this.toolStripButtonStage.Click += new System.EventHandler(this.toolStripButtonStage_Click);
            // 
            // toolStripButtonShip
            // 
            this.toolStripButtonShip.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonShip.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonShip.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonShip.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonShip.Image")));
            this.toolStripButtonShip.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonShip.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButtonShip.Name = "toolStripButtonShip";
            this.toolStripButtonShip.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButtonShip.Size = new System.Drawing.Size(65, 45);
            this.toolStripButtonShip.Text = "Shi&p";
            // 
            // toolStripButtonTransfer
            // 
            this.toolStripButtonTransfer.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonTransfer.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTransfer.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonTransfer.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTransfer.Image")));
            this.toolStripButtonTransfer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransfer.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButtonTransfer.Name = "toolStripButtonTransfer";
            this.toolStripButtonTransfer.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButtonTransfer.Size = new System.Drawing.Size(90, 45);
            this.toolStripButtonTransfer.Text = "&Transfer";
            // 
            // toolStripButtonBalance
            // 
            this.toolStripButtonBalance.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonBalance.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonBalance.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonBalance.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonBalance.Image")));
            this.toolStripButtonBalance.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonBalance.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButtonBalance.Name = "toolStripButtonBalance";
            this.toolStripButtonBalance.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButtonBalance.Size = new System.Drawing.Size(87, 45);
            this.toolStripButtonBalance.Text = "&Balance";
            // 
            // toolStripButtonTransaction
            // 
            this.toolStripButtonTransaction.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripButtonTransaction.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonTransaction.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripButtonTransaction.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonTransaction.Image")));
            this.toolStripButtonTransaction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonTransaction.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripButtonTransaction.Name = "toolStripButtonTransaction";
            this.toolStripButtonTransaction.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripButtonTransaction.Size = new System.Drawing.Size(113, 45);
            this.toolStripButtonTransaction.Text = "Transactio&n";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 48);
            // 
            // toolStripConnectDevice
            // 
            this.toolStripConnectDevice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripConnectDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripConnectDevice.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripConnectDevice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripConnectDevice.Image")));
            this.toolStripConnectDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripConnectDevice.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripConnectDevice.Name = "toolStripConnectDevice";
            this.toolStripConnectDevice.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripConnectDevice.Size = new System.Drawing.Size(141, 45);
            this.toolStripConnectDevice.Text = "&Connect Device";
            this.toolStripConnectDevice.Click += new System.EventHandler(this.toolStripConnectDevice_Click);
            // 
            // toolStripDevice
            // 
            this.toolStripDevice.BackColor = System.Drawing.SystemColors.ControlDark;
            this.toolStripDevice.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripDevice.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.toolStripDevice.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDevice.Image")));
            this.toolStripDevice.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDevice.Margin = new System.Windows.Forms.Padding(10, 1, 0, 2);
            this.toolStripDevice.Name = "toolStripDevice";
            this.toolStripDevice.Padding = new System.Windows.Forms.Padding(10);
            this.toolStripDevice.Size = new System.Drawing.Size(133, 45);
            this.toolStripDevice.Text = "&Device Setting";
            this.toolStripDevice.Click += new System.EventHandler(this.toolStripDevice_Click);
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusMain,
            this.toolStripStatusDevice,
            this.toolStripStatusUser});
            this.statusStrip.Location = new System.Drawing.Point(0, 917);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.Size = new System.Drawing.Size(1664, 24);
            this.statusStrip.TabIndex = 3;
            this.statusStrip.Text = "StatusBar";
            // 
            // toolStripStatusMain
            // 
            this.toolStripStatusMain.AutoSize = false;
            this.toolStripStatusMain.Name = "toolStripStatusMain";
            this.toolStripStatusMain.Size = new System.Drawing.Size(1200, 19);
            this.toolStripStatusMain.Text = "Welcome to Print Sleeve Management";
            this.toolStripStatusMain.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // toolStripStatusDevice
            // 
            this.toolStripStatusDevice.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusDevice.Name = "toolStripStatusDevice";
            this.toolStripStatusDevice.Size = new System.Drawing.Size(80, 19);
            this.toolStripStatusDevice.Text = "Input Device:";
            // 
            // toolStripStatusUser
            // 
            this.toolStripStatusUser.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Left;
            this.toolStripStatusUser.Name = "toolStripStatusUser";
            this.toolStripStatusUser.Size = new System.Drawing.Size(59, 19);
            this.toolStripStatusUser.Text = "User By : ";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1664, 941);
            this.Controls.Add(this.statusStrip);
            this.Controls.Add(this.toolStrip1);
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "Print Sleeve Management";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusMain;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusUser;
        private System.Windows.Forms.ToolStripButton toolStripPutAway;
        private System.Windows.Forms.ToolStripButton toolStripDevice;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusDevice;
        private System.Windows.Forms.ToolStripButton toolStripConnectDevice;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonPick;
        private System.Windows.Forms.ToolStripButton toolStripButtonStage;
        private System.Windows.Forms.ToolStripButton toolStripButtonShip;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransfer;
        private System.Windows.Forms.ToolStripButton toolStripButtonBalance;
        private System.Windows.Forms.ToolStripButton toolStripButtonTransaction;
    }
}

