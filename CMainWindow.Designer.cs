namespace ZusiTCPDemoApp
{
    partial class CMainWindow
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
                MyTCPConnection.Dispose();
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
            this.lblSifa = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.lblMeter = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.Panel();
            this.lblBrh = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.grpVerbindung = new System.Windows.Forms.GroupBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.lblFlag = new System.Windows.Forms.Label();
            this.pnlDebug = new System.Windows.Forms.Panel();
            this.grpDebug = new System.Windows.Forms.GroupBox();
            this.lblDebugVreached = new System.Windows.Forms.Label();
            this.lblDebugSchleudern = new System.Windows.Forms.Label();
            this.lblDebugBremsen = new System.Windows.Forms.Label();
            this.lblDebugScharf = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tbVerz = new System.Windows.Forms.TextBox();
            this.btnFlag = new System.Windows.Forms.Button();
            this.btnDebugpanel = new System.Windows.Forms.Button();
            this.pnlRight = new System.Windows.Forms.Panel();
            this.timerFlag = new System.Windows.Forms.Timer(this.components);
            this.btnNacht = new System.Windows.Forms.Button();
            this.lblHlldruck = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblBzdruck = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlData.SuspendLayout();
            this.pnlSettings.SuspendLayout();
            this.grpVerbindung.SuspendLayout();
            this.pnlDebug.SuspendLayout();
            this.grpDebug.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSifa
            // 
            this.lblSifa.BackColor = System.Drawing.Color.DarkGray;
            this.lblSifa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSifa.Location = new System.Drawing.Point(8, 19);
            this.lblSifa.Name = "lblSifa";
            this.lblSifa.Size = new System.Drawing.Size(96, 51);
            this.lblSifa.TabIndex = 0;
            this.lblSifa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV.Location = new System.Drawing.Point(3, 21);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(31, 24);
            this.lblV.TabIndex = 1;
            this.lblV.Text = "---";
            // 
            // lblMeter
            // 
            this.lblMeter.AutoSize = true;
            this.lblMeter.Location = new System.Drawing.Point(3, 53);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new System.Drawing.Size(16, 13);
            this.lblMeter.TabIndex = 3;
            this.lblMeter.Text = "---";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 29);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(32, 13);
            this.label4.TabIndex = 4;
            this.label4.Text = "km/h";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(15, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "m";
            // 
            // pnlData
            // 
            this.pnlData.Controls.Add(this.label6);
            this.pnlData.Controls.Add(this.lblBzdruck);
            this.pnlData.Controls.Add(this.label5);
            this.pnlData.Controls.Add(this.lblHlldruck);
            this.pnlData.Controls.Add(this.lblBrh);
            this.pnlData.Controls.Add(this.label2);
            this.pnlData.Controls.Add(this.lblV);
            this.pnlData.Controls.Add(this.label1);
            this.pnlData.Controls.Add(this.label4);
            this.pnlData.Controls.Add(this.lblMeter);
            this.pnlData.Location = new System.Drawing.Point(8, 99);
            this.pnlData.Name = "pnlData";
            this.pnlData.Size = new System.Drawing.Size(101, 116);
            this.pnlData.TabIndex = 6;
            // 
            // lblBrh
            // 
            this.lblBrh.AutoSize = true;
            this.lblBrh.Location = new System.Drawing.Point(4, 75);
            this.lblBrh.Name = "lblBrh";
            this.lblBrh.Size = new System.Drawing.Size(16, 13);
            this.lblBrh.TabIndex = 7;
            this.lblBrh.Text = "---";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(60, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "BrH";
            // 
            // btnSettings
            // 
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(8, 291);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(103, 26);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Einstellungen";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSettings.Controls.Add(this.grpVerbindung);
            this.pnlSettings.Location = new System.Drawing.Point(3, 3);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(138, 303);
            this.pnlSettings.TabIndex = 10;
            // 
            // grpVerbindung
            // 
            this.grpVerbindung.Controls.Add(this.tbServer);
            this.grpVerbindung.Controls.Add(this.tbPort);
            this.grpVerbindung.Controls.Add(this.btnConnect);
            this.grpVerbindung.Location = new System.Drawing.Point(7, 3);
            this.grpVerbindung.Name = "grpVerbindung";
            this.grpVerbindung.Size = new System.Drawing.Size(121, 114);
            this.grpVerbindung.TabIndex = 12;
            this.grpVerbindung.TabStop = false;
            this.grpVerbindung.Text = "Verbindung";
            // 
            // tbServer
            // 
            this.tbServer.Location = new System.Drawing.Point(7, 26);
            this.tbServer.Name = "tbServer";
            this.tbServer.Size = new System.Drawing.Size(74, 20);
            this.tbServer.TabIndex = 13;
            this.tbServer.Text = "127.0.0.1";
            // 
            // tbPort
            // 
            this.tbPort.Location = new System.Drawing.Point(7, 52);
            this.tbPort.Name = "tbPort";
            this.tbPort.Size = new System.Drawing.Size(74, 20);
            this.tbPort.TabIndex = 12;
            this.tbPort.Text = "1435";
            // 
            // btnConnect
            // 
            this.btnConnect.Location = new System.Drawing.Point(6, 78);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(75, 23);
            this.btnConnect.TabIndex = 11;
            this.btnConnect.Text = "Verbinden";
            this.btnConnect.UseVisualStyleBackColor = true;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // lblFlag
            // 
            this.lblFlag.BackColor = System.Drawing.Color.Orange;
            this.lblFlag.Location = new System.Drawing.Point(8, 74);
            this.lblFlag.Name = "lblFlag";
            this.lblFlag.Size = new System.Drawing.Size(96, 19);
            this.lblFlag.TabIndex = 11;
            this.lblFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFlag.Visible = false;
            // 
            // pnlDebug
            // 
            this.pnlDebug.Controls.Add(this.grpDebug);
            this.pnlDebug.Location = new System.Drawing.Point(170, 2);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(111, 303);
            this.pnlDebug.TabIndex = 12;
            this.pnlDebug.Visible = false;
            // 
            // grpDebug
            // 
            this.grpDebug.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpDebug.Controls.Add(this.lblDebugVreached);
            this.grpDebug.Controls.Add(this.lblDebugSchleudern);
            this.grpDebug.Controls.Add(this.lblDebugBremsen);
            this.grpDebug.Controls.Add(this.lblDebugScharf);
            this.grpDebug.Controls.Add(this.label13);
            this.grpDebug.Controls.Add(this.label12);
            this.grpDebug.Controls.Add(this.tbVerz);
            this.grpDebug.Controls.Add(this.btnFlag);
            this.grpDebug.Location = new System.Drawing.Point(3, 3);
            this.grpDebug.Name = "grpDebug";
            this.grpDebug.Size = new System.Drawing.Size(103, 299);
            this.grpDebug.TabIndex = 12;
            this.grpDebug.TabStop = false;
            this.grpDebug.Text = "Debug";
            // 
            // lblDebugVreached
            // 
            this.lblDebugVreached.AutoSize = true;
            this.lblDebugVreached.Location = new System.Drawing.Point(8, 229);
            this.lblDebugVreached.Name = "lblDebugVreached";
            this.lblDebugVreached.Size = new System.Drawing.Size(63, 13);
            this.lblDebugVreached.TabIndex = 27;
            this.lblDebugVreached.Text = "(vReached)";
            // 
            // lblDebugSchleudern
            // 
            this.lblDebugSchleudern.AutoSize = true;
            this.lblDebugSchleudern.Location = new System.Drawing.Point(7, 213);
            this.lblDebugSchleudern.Name = "lblDebugSchleudern";
            this.lblDebugSchleudern.Size = new System.Drawing.Size(65, 13);
            this.lblDebugSchleudern.TabIndex = 26;
            this.lblDebugSchleudern.Text = "(schleudern)";
            // 
            // lblDebugBremsen
            // 
            this.lblDebugBremsen.AutoSize = true;
            this.lblDebugBremsen.Location = new System.Drawing.Point(6, 199);
            this.lblDebugBremsen.Name = "lblDebugBremsen";
            this.lblDebugBremsen.Size = new System.Drawing.Size(53, 13);
            this.lblDebugBremsen.TabIndex = 22;
            this.lblDebugBremsen.Text = "(bremsen)";
            // 
            // lblDebugScharf
            // 
            this.lblDebugScharf.AutoSize = true;
            this.lblDebugScharf.Location = new System.Drawing.Point(6, 184);
            this.lblDebugScharf.Name = "lblDebugScharf";
            this.lblDebugScharf.Size = new System.Drawing.Size(42, 13);
            this.lblDebugScharf.TabIndex = 21;
            this.lblDebugScharf.Text = "(scharf)";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(3, 133);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "max. Verzögerung";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 156);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "m/s²";
            // 
            // tbVerz
            // 
            this.tbVerz.Location = new System.Drawing.Point(6, 149);
            this.tbVerz.Name = "tbVerz";
            this.tbVerz.Size = new System.Drawing.Size(36, 20);
            this.tbVerz.TabIndex = 18;
            this.tbVerz.Text = "0,5";
            // 
            // btnFlag
            // 
            this.btnFlag.Location = new System.Drawing.Point(6, 25);
            this.btnFlag.Name = "btnFlag";
            this.btnFlag.Size = new System.Drawing.Size(60, 23);
            this.btnFlag.TabIndex = 11;
            this.btnFlag.Text = "flag";
            this.btnFlag.UseVisualStyleBackColor = true;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // btnDebugpanel
            // 
            this.btnDebugpanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.btnDebugpanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugpanel.Location = new System.Drawing.Point(147, 121);
            this.btnDebugpanel.Name = "btnDebugpanel";
            this.btnDebugpanel.Size = new System.Drawing.Size(17, 81);
            this.btnDebugpanel.TabIndex = 13;
            this.btnDebugpanel.Text = "DEBUG";
            this.btnDebugpanel.UseVisualStyleBackColor = true;
            this.btnDebugpanel.Click += new System.EventHandler(this.btnDebugpanel_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.AutoSize = true;
            this.pnlRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRight.Controls.Add(this.pnlSettings);
            this.pnlRight.Controls.Add(this.btnDebugpanel);
            this.pnlRight.Controls.Add(this.pnlDebug);
            this.pnlRight.Location = new System.Drawing.Point(118, 13);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(284, 309);
            this.pnlRight.TabIndex = 14;
            // 
            // timerFlag
            // 
            this.timerFlag.Enabled = true;
            this.timerFlag.Interval = 1000;
            this.timerFlag.Tick += new System.EventHandler(this.timerFlag_Tick);
            // 
            // btnNacht
            // 
            this.btnNacht.Location = new System.Drawing.Point(8, 226);
            this.btnNacht.Name = "btnNacht";
            this.btnNacht.Size = new System.Drawing.Size(94, 23);
            this.btnNacht.TabIndex = 15;
            this.btnNacht.Text = "Nachtmodus";
            this.btnNacht.UseVisualStyleBackColor = true;
            this.btnNacht.Click += new System.EventHandler(this.btnNacht_Click);
            // 
            // lblHlldruck
            // 
            this.lblHlldruck.AutoSize = true;
            this.lblHlldruck.Location = new System.Drawing.Point(4, 88);
            this.lblHlldruck.Name = "lblHlldruck";
            this.lblHlldruck.Size = new System.Drawing.Size(16, 13);
            this.lblHlldruck.TabIndex = 8;
            this.lblHlldruck.Text = "---";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(60, 88);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "bar Hll";
            // 
            // lblBzdruck
            // 
            this.lblBzdruck.AutoSize = true;
            this.lblBzdruck.Location = new System.Drawing.Point(4, 101);
            this.lblBzdruck.Name = "lblBzdruck";
            this.lblBzdruck.Size = new System.Drawing.Size(16, 13);
            this.lblBzdruck.TabIndex = 10;
            this.lblBzdruck.Text = "---";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(60, 101);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "bar Bz";
            // 
            // CMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(409, 329);
            this.Controls.Add(this.btnNacht);
            this.Controls.Add(this.lblSifa);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.lblFlag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CMainWindow";
            this.Text = "ZusiMeter - v0.2";
            this.TopMost = true;
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.pnlSettings.ResumeLayout(false);
            this.grpVerbindung.ResumeLayout(false);
            this.grpVerbindung.PerformLayout();
            this.pnlDebug.ResumeLayout(false);
            this.grpDebug.ResumeLayout(false);
            this.grpDebug.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSifa;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.Label lblMeter;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlData;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Panel pnlSettings;
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.GroupBox grpVerbindung;
        private System.Windows.Forms.TextBox tbServer;
        private System.Windows.Forms.TextBox tbPort;
        private System.Windows.Forms.Label lblFlag;
        private System.Windows.Forms.Panel pnlDebug;
        private System.Windows.Forms.GroupBox grpDebug;
        private System.Windows.Forms.Label lblDebugBremsen;
        private System.Windows.Forms.Label lblDebugScharf;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbVerz;
        private System.Windows.Forms.Button btnFlag;
        private System.Windows.Forms.Button btnDebugpanel;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Label lblDebugSchleudern;
        private System.Windows.Forms.Label lblDebugVreached;
        private System.Windows.Forms.Label lblBrh;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer timerFlag;
        private System.Windows.Forms.Button btnNacht;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label lblHlldruck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lblBzdruck;

    }
}

