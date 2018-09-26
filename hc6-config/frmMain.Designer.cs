namespace hc6_config
{
    partial class frmMain
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.grpSerial = new System.Windows.Forms.GroupBox();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.btnConnect = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSerialBaud = new System.Windows.Forms.TextBox();
            this.txtSerialPort = new System.Windows.Forms.TextBox();
            this.grpStatus = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtStatus = new System.Windows.Forms.TextBox();
            this.grpBluetooth = new System.Windows.Forms.GroupBox();
            this.btnDevUpdate = new System.Windows.Forms.Button();
            this.cmbDevParity = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDevPassword = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cmbDevBaud = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtDevName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.bwDevInfo = new System.ComponentModel.BackgroundWorker();
            this.tmDevProbe = new System.Windows.Forms.Timer(this.components);
            this.bwDevUpdate = new System.ComponentModel.BackgroundWorker();
            this.grpSerial.SuspendLayout();
            this.grpStatus.SuspendLayout();
            this.grpBluetooth.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSerial
            // 
            this.grpSerial.Controls.Add(this.btnDisconnect);
            this.grpSerial.Controls.Add(this.btnConnect);
            this.grpSerial.Controls.Add(this.label2);
            this.grpSerial.Controls.Add(this.label1);
            this.grpSerial.Controls.Add(this.txtSerialBaud);
            this.grpSerial.Controls.Add(this.txtSerialPort);
            this.grpSerial.Location = new System.Drawing.Point(12, 12);
            this.grpSerial.Name = "grpSerial";
            this.grpSerial.Size = new System.Drawing.Size(181, 106);
            this.grpSerial.TabIndex = 0;
            this.grpSerial.TabStop = false;
            this.grpSerial.Text = "Serial port parameters";
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnDisconnect.Enabled = false;
            this.btnDisconnect.Location = new System.Drawing.Point(11, 71);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(75, 23);
            this.btnDisconnect.TabIndex = 5;
            this.btnDisconnect.Text = "&Disconnect";
            this.btnDisconnect.UseVisualStyleBackColor = true;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // btnConnect
            // 
            this.btnConnect.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnConnect.Location = new System.Drawing.Point(92, 71);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "&Connect";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "&Speed:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Serial &line:";
            // 
            // txtSerialBaud
            // 
            this.txtSerialBaud.Location = new System.Drawing.Point(67, 45);
            this.txtSerialBaud.Name = "txtSerialBaud";
            this.txtSerialBaud.Size = new System.Drawing.Size(100, 20);
            this.txtSerialBaud.TabIndex = 1;
            this.txtSerialBaud.Text = "9600";
            // 
            // txtSerialPort
            // 
            this.txtSerialPort.Location = new System.Drawing.Point(67, 19);
            this.txtSerialPort.Name = "txtSerialPort";
            this.txtSerialPort.Size = new System.Drawing.Size(100, 20);
            this.txtSerialPort.TabIndex = 0;
            this.txtSerialPort.Text = "COM5";
            // 
            // grpStatus
            // 
            this.grpStatus.Controls.Add(this.label3);
            this.grpStatus.Controls.Add(this.label4);
            this.grpStatus.Controls.Add(this.txtVersion);
            this.grpStatus.Controls.Add(this.txtStatus);
            this.grpStatus.Location = new System.Drawing.Point(199, 12);
            this.grpStatus.Name = "grpStatus";
            this.grpStatus.Size = new System.Drawing.Size(233, 106);
            this.grpStatus.TabIndex = 1;
            this.grpStatus.TabStop = false;
            this.grpStatus.Text = "Status";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(45, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "&Version:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(64, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Connec&tion:";
            // 
            // txtVersion
            // 
            this.txtVersion.Location = new System.Drawing.Point(76, 45);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.ReadOnly = true;
            this.txtVersion.Size = new System.Drawing.Size(143, 20);
            this.txtVersion.TabIndex = 5;
            // 
            // txtStatus
            // 
            this.txtStatus.Location = new System.Drawing.Point(76, 19);
            this.txtStatus.Name = "txtStatus";
            this.txtStatus.ReadOnly = true;
            this.txtStatus.Size = new System.Drawing.Size(143, 20);
            this.txtStatus.TabIndex = 4;
            // 
            // grpBluetooth
            // 
            this.grpBluetooth.Controls.Add(this.btnDevUpdate);
            this.grpBluetooth.Controls.Add(this.cmbDevParity);
            this.grpBluetooth.Controls.Add(this.label8);
            this.grpBluetooth.Controls.Add(this.txtDevPassword);
            this.grpBluetooth.Controls.Add(this.label7);
            this.grpBluetooth.Controls.Add(this.cmbDevBaud);
            this.grpBluetooth.Controls.Add(this.label6);
            this.grpBluetooth.Controls.Add(this.txtDevName);
            this.grpBluetooth.Controls.Add(this.label5);
            this.grpBluetooth.Enabled = false;
            this.grpBluetooth.Location = new System.Drawing.Point(12, 124);
            this.grpBluetooth.Name = "grpBluetooth";
            this.grpBluetooth.Size = new System.Drawing.Size(420, 107);
            this.grpBluetooth.TabIndex = 2;
            this.grpBluetooth.TabStop = false;
            this.grpBluetooth.Text = "HC6 parameters";
            // 
            // btnDevUpdate
            // 
            this.btnDevUpdate.Location = new System.Drawing.Point(331, 72);
            this.btnDevUpdate.Name = "btnDevUpdate";
            this.btnDevUpdate.Size = new System.Drawing.Size(75, 23);
            this.btnDevUpdate.TabIndex = 11;
            this.btnDevUpdate.Text = "&Update";
            this.btnDevUpdate.UseVisualStyleBackColor = true;
            this.btnDevUpdate.Click += new System.EventHandler(this.btnDevUpdate_Click);
            // 
            // cmbDevParity
            // 
            this.cmbDevParity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevParity.FormattingEnabled = true;
            this.cmbDevParity.Items.AddRange(new object[] {
            "Off",
            "Odd",
            "Even"});
            this.cmbDevParity.Location = new System.Drawing.Point(302, 45);
            this.cmbDevParity.Name = "cmbDevParity";
            this.cmbDevParity.Size = new System.Drawing.Size(104, 21);
            this.cmbDevParity.TabIndex = 10;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(212, 48);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(69, 13);
            this.label8.TabIndex = 9;
            this.label8.Text = "Parit&y check:";
            // 
            // txtDevPassword
            // 
            this.txtDevPassword.Location = new System.Drawing.Point(302, 19);
            this.txtDevPassword.MaxLength = 4;
            this.txtDevPassword.Name = "txtDevPassword";
            this.txtDevPassword.Size = new System.Drawing.Size(104, 20);
            this.txtDevPassword.TabIndex = 8;
            this.txtDevPassword.Text = "1234";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(212, 22);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(76, 13);
            this.label7.TabIndex = 7;
            this.label7.Text = "&Pair password:";
            // 
            // cmbDevBaud
            // 
            this.cmbDevBaud.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbDevBaud.FormattingEnabled = true;
            this.cmbDevBaud.Items.AddRange(new object[] {
            "1200",
            "2400",
            "4800",
            "9600",
            "19200",
            "38400",
            "57600",
            "115200",
            "230400",
            "460800",
            "921600",
            "1382400"});
            this.cmbDevBaud.Location = new System.Drawing.Point(96, 45);
            this.cmbDevBaud.Name = "cmbDevBaud";
            this.cmbDevBaud.Size = new System.Drawing.Size(104, 21);
            this.cmbDevBaud.TabIndex = 6;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 48);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(61, 13);
            this.label6.TabIndex = 5;
            this.label6.Text = "&BAUD rate:";
            // 
            // txtDevName
            // 
            this.txtDevName.Location = new System.Drawing.Point(96, 19);
            this.txtDevName.MaxLength = 20;
            this.txtDevName.Name = "txtDevName";
            this.txtDevName.Size = new System.Drawing.Size(104, 20);
            this.txtDevName.TabIndex = 4;
            this.txtDevName.Text = "My Device";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 22);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 13);
            this.label5.TabIndex = 3;
            this.label5.Text = "Bluetooth &name:";
            // 
            // bwDevInfo
            // 
            this.bwDevInfo.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDevInfo_DoWork);
            this.bwDevInfo.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDevInfo_RunWorkerCompleted);
            // 
            // tmDevProbe
            // 
            this.tmDevProbe.Interval = 1200;
            this.tmDevProbe.Tick += new System.EventHandler(this.tmDevProbe_Tick);
            // 
            // bwDevUpdate
            // 
            this.bwDevUpdate.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwDevUpdate_DoWork);
            this.bwDevUpdate.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwDevUpdate_RunWorkerCompleted);
            // 
            // frmMain
            // 
            this.AcceptButton = this.btnConnect;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnDisconnect;
            this.ClientSize = new System.Drawing.Size(444, 243);
            this.Controls.Add(this.grpBluetooth);
            this.Controls.Add(this.grpStatus);
            this.Controls.Add(this.grpSerial);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HC6 Configuration Utility";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.grpSerial.ResumeLayout(false);
            this.grpSerial.PerformLayout();
            this.grpStatus.ResumeLayout(false);
            this.grpStatus.PerformLayout();
            this.grpBluetooth.ResumeLayout(false);
            this.grpBluetooth.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSerial;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSerialBaud;
        private System.Windows.Forms.TextBox txtSerialPort;
        private System.Windows.Forms.GroupBox grpStatus;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtStatus;
        private System.Windows.Forms.GroupBox grpBluetooth;
        private System.Windows.Forms.ComboBox cmbDevBaud;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtDevName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnDevUpdate;
        private System.Windows.Forms.ComboBox cmbDevParity;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDevPassword;
        private System.Windows.Forms.Label label7;
        private System.ComponentModel.BackgroundWorker bwDevInfo;
        private System.Windows.Forms.Timer tmDevProbe;
        private System.ComponentModel.BackgroundWorker bwDevUpdate;
    }
}

