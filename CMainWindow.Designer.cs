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
            this.lblbarbz = new System.Windows.Forms.Label();
            this.lblBzdruck = new System.Windows.Forms.Label();
            this.lblbarhll = new System.Windows.Forms.Label();
            this.lblHlldruck = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.tabEinstellungen = new System.Windows.Forms.TabControl();
            this.tabAnzeigen = new System.Windows.Forms.TabPage();
            this.grpVisibledata = new System.Windows.Forms.GroupBox();
            this.cbBrh = new System.Windows.Forms.CheckBox();
            this.cbDruckbz = new System.Windows.Forms.CheckBox();
            this.cbDruckhll = new System.Windows.Forms.CheckBox();
            this.cbStreckenmeter = new System.Windows.Forms.CheckBox();
            this.cbGeschwindigkeit = new System.Windows.Forms.CheckBox();
            this.tabDarstellung = new System.Windows.Forms.TabPage();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.grpVerbindung = new System.Windows.Forms.GroupBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDebugpanel = new System.Windows.Forms.Button();
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
            this.pnlRight = new System.Windows.Forms.Panel();
            this.timerFlag = new System.Windows.Forms.Timer(this.components);
            this.btnNacht = new System.Windows.Forms.Button();
            this.lblm = new System.Windows.Forms.Label();
            this.lblBrh = new System.Windows.Forms.Label();
            this.lblbremsh = new System.Windows.Forms.Label();
            this.lblMeter = new System.Windows.Forms.Label();
            this.lblkmh = new System.Windows.Forms.Label();
            this.lblV = new System.Windows.Forms.Label();
            this.pnlData = new System.Windows.Forms.TableLayoutPanel();
            this.pnlSettings.SuspendLayout();
            this.tabEinstellungen.SuspendLayout();
            this.tabAnzeigen.SuspendLayout();
            this.grpVisibledata.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.grpVerbindung.SuspendLayout();
            this.pnlDebug.SuspendLayout();
            this.grpDebug.SuspendLayout();
            this.pnlRight.SuspendLayout();
            this.pnlData.SuspendLayout();
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
            // lblbarbz
            // 
            this.lblbarbz.AutoSize = true;
            this.lblbarbz.Location = new System.Drawing.Point(40, 50);
            this.lblbarbz.Name = "lblbarbz";
            this.lblbarbz.Size = new System.Drawing.Size(37, 13);
            this.lblbarbz.TabIndex = 11;
            this.lblbarbz.Text = "bar Bz";
            // 
            // lblBzdruck
            // 
            this.lblBzdruck.AutoSize = true;
            this.lblBzdruck.Location = new System.Drawing.Point(3, 50);
            this.lblBzdruck.Name = "lblBzdruck";
            this.lblBzdruck.Size = new System.Drawing.Size(16, 13);
            this.lblBzdruck.TabIndex = 10;
            this.lblBzdruck.Text = "---";
            // 
            // lblbarhll
            // 
            this.lblbarhll.AutoSize = true;
            this.lblbarhll.Location = new System.Drawing.Point(40, 37);
            this.lblbarhll.Name = "lblbarhll";
            this.lblbarhll.Size = new System.Drawing.Size(37, 13);
            this.lblbarhll.TabIndex = 9;
            this.lblbarhll.Text = "bar Hll";
            // 
            // lblHlldruck
            // 
            this.lblHlldruck.AutoSize = true;
            this.lblHlldruck.Location = new System.Drawing.Point(3, 37);
            this.lblHlldruck.Name = "lblHlldruck";
            this.lblHlldruck.Size = new System.Drawing.Size(16, 13);
            this.lblHlldruck.TabIndex = 8;
            this.lblHlldruck.Text = "---";
            // 
            // btnSettings
            // 
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(8, 235);
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
            this.pnlSettings.Controls.Add(this.tabEinstellungen);
            this.pnlSettings.Location = new System.Drawing.Point(3, 3);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(211, 248);
            this.pnlSettings.TabIndex = 10;
            // 
            // tabEinstellungen
            // 
            this.tabEinstellungen.Controls.Add(this.tabAnzeigen);
            this.tabEinstellungen.Controls.Add(this.tabDarstellung);
            this.tabEinstellungen.Controls.Add(this.tabSystem);
            this.tabEinstellungen.Location = new System.Drawing.Point(4, 4);
            this.tabEinstellungen.Name = "tabEinstellungen";
            this.tabEinstellungen.SelectedIndex = 0;
            this.tabEinstellungen.Size = new System.Drawing.Size(203, 244);
            this.tabEinstellungen.TabIndex = 0;
            // 
            // tabAnzeigen
            // 
            this.tabAnzeigen.BackColor = System.Drawing.SystemColors.Control;
            this.tabAnzeigen.Controls.Add(this.grpVisibledata);
            this.tabAnzeigen.Location = new System.Drawing.Point(4, 22);
            this.tabAnzeigen.Name = "tabAnzeigen";
            this.tabAnzeigen.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnzeigen.Size = new System.Drawing.Size(195, 218);
            this.tabAnzeigen.TabIndex = 0;
            this.tabAnzeigen.Text = "Anzeigen";
            // 
            // grpVisibledata
            // 
            this.grpVisibledata.Controls.Add(this.cbBrh);
            this.grpVisibledata.Controls.Add(this.cbDruckbz);
            this.grpVisibledata.Controls.Add(this.cbDruckhll);
            this.grpVisibledata.Controls.Add(this.cbStreckenmeter);
            this.grpVisibledata.Controls.Add(this.cbGeschwindigkeit);
            this.grpVisibledata.Location = new System.Drawing.Point(6, 6);
            this.grpVisibledata.Name = "grpVisibledata";
            this.grpVisibledata.Size = new System.Drawing.Size(155, 121);
            this.grpVisibledata.TabIndex = 13;
            this.grpVisibledata.TabStop = false;
            this.grpVisibledata.Text = "Anzeige";
            // 
            // cbBrh
            // 
            this.cbBrh.AutoSize = true;
            this.cbBrh.Checked = true;
            this.cbBrh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBrh.Location = new System.Drawing.Point(7, 92);
            this.cbBrh.Name = "cbBrh";
            this.cbBrh.Size = new System.Drawing.Size(107, 17);
            this.cbBrh.TabIndex = 4;
            this.cbBrh.Text = "Bremshundertstel";
            this.cbBrh.UseVisualStyleBackColor = true;
            this.cbBrh.CheckedChanged += new System.EventHandler(this.cbBrh_CheckedChanged);
            // 
            // cbDruckbz
            // 
            this.cbDruckbz.AutoSize = true;
            this.cbDruckbz.Checked = true;
            this.cbDruckbz.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDruckbz.Location = new System.Drawing.Point(7, 74);
            this.cbDruckbz.Name = "cbDruckbz";
            this.cbDruckbz.Size = new System.Drawing.Size(122, 17);
            this.cbDruckbz.TabIndex = 3;
            this.cbDruckbz.Text = "Druck Bremszylinder";
            this.cbDruckbz.UseVisualStyleBackColor = true;
            this.cbDruckbz.CheckedChanged += new System.EventHandler(this.cbDruckbz_CheckedChanged);
            // 
            // cbDruckhll
            // 
            this.cbDruckhll.AutoSize = true;
            this.cbDruckhll.Checked = true;
            this.cbDruckhll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDruckhll.Location = new System.Drawing.Point(7, 59);
            this.cbDruckhll.Name = "cbDruckhll";
            this.cbDruckhll.Size = new System.Drawing.Size(70, 17);
            this.cbDruckhll.TabIndex = 2;
            this.cbDruckhll.Text = "Druck Hll";
            this.cbDruckhll.UseVisualStyleBackColor = true;
            this.cbDruckhll.CheckedChanged += new System.EventHandler(this.cbDruckhll_CheckedChanged);
            // 
            // cbStreckenmeter
            // 
            this.cbStreckenmeter.AutoSize = true;
            this.cbStreckenmeter.Checked = true;
            this.cbStreckenmeter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStreckenmeter.Location = new System.Drawing.Point(7, 36);
            this.cbStreckenmeter.Name = "cbStreckenmeter";
            this.cbStreckenmeter.Size = new System.Drawing.Size(95, 17);
            this.cbStreckenmeter.TabIndex = 1;
            this.cbStreckenmeter.Text = "Streckenmeter";
            this.cbStreckenmeter.UseVisualStyleBackColor = true;
            this.cbStreckenmeter.CheckedChanged += new System.EventHandler(this.cbStreckenmeter_CheckedChanged);
            // 
            // cbGeschwindigkeit
            // 
            this.cbGeschwindigkeit.AutoSize = true;
            this.cbGeschwindigkeit.Checked = true;
            this.cbGeschwindigkeit.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGeschwindigkeit.Location = new System.Drawing.Point(7, 20);
            this.cbGeschwindigkeit.Name = "cbGeschwindigkeit";
            this.cbGeschwindigkeit.Size = new System.Drawing.Size(104, 17);
            this.cbGeschwindigkeit.TabIndex = 0;
            this.cbGeschwindigkeit.Text = "Geschwindigkeit";
            this.cbGeschwindigkeit.UseVisualStyleBackColor = true;
            this.cbGeschwindigkeit.CheckedChanged += new System.EventHandler(this.cbGeschwindigkeit_CheckedChanged);
            // 
            // tabDarstellung
            // 
            this.tabDarstellung.BackColor = System.Drawing.SystemColors.Control;
            this.tabDarstellung.Location = new System.Drawing.Point(4, 22);
            this.tabDarstellung.Name = "tabDarstellung";
            this.tabDarstellung.Padding = new System.Windows.Forms.Padding(3);
            this.tabDarstellung.Size = new System.Drawing.Size(304, 338);
            this.tabDarstellung.TabIndex = 1;
            this.tabDarstellung.Text = "Darstellung";
            // 
            // tabSystem
            // 
            this.tabSystem.BackColor = System.Drawing.SystemColors.Control;
            this.tabSystem.Controls.Add(this.grpVerbindung);
            this.tabSystem.Controls.Add(this.btnDebugpanel);
            this.tabSystem.Location = new System.Drawing.Point(4, 22);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Size = new System.Drawing.Size(195, 218);
            this.tabSystem.TabIndex = 2;
            this.tabSystem.Text = "System";
            // 
            // grpVerbindung
            // 
            this.grpVerbindung.Controls.Add(this.tbServer);
            this.grpVerbindung.Controls.Add(this.tbPort);
            this.grpVerbindung.Controls.Add(this.btnConnect);
            this.grpVerbindung.Location = new System.Drawing.Point(3, 4);
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
            // btnDebugpanel
            // 
            this.btnDebugpanel.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Salmon;
            this.btnDebugpanel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDebugpanel.Location = new System.Drawing.Point(130, 4);
            this.btnDebugpanel.Name = "btnDebugpanel";
            this.btnDebugpanel.Size = new System.Drawing.Size(58, 29);
            this.btnDebugpanel.TabIndex = 13;
            this.btnDebugpanel.Text = "DEBUG";
            this.btnDebugpanel.UseVisualStyleBackColor = true;
            this.btnDebugpanel.Click += new System.EventHandler(this.btnDebugpanel_Click);
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
            this.pnlDebug.AutoSize = true;
            this.pnlDebug.Controls.Add(this.grpDebug);
            this.pnlDebug.Location = new System.Drawing.Point(220, 3);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(106, 248);
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
            this.grpDebug.Size = new System.Drawing.Size(100, 242);
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
            // pnlRight
            // 
            this.pnlRight.AutoSize = true;
            this.pnlRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRight.Controls.Add(this.pnlSettings);
            this.pnlRight.Controls.Add(this.pnlDebug);
            this.pnlRight.Location = new System.Drawing.Point(118, 13);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(329, 254);
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
            this.btnNacht.Location = new System.Drawing.Point(8, 190);
            this.btnNacht.Name = "btnNacht";
            this.btnNacht.Size = new System.Drawing.Size(94, 23);
            this.btnNacht.TabIndex = 15;
            this.btnNacht.Text = "Nachtmodus";
            this.btnNacht.UseVisualStyleBackColor = true;
            this.btnNacht.Click += new System.EventHandler(this.btnNacht_Click);
            // 
            // lblm
            // 
            this.lblm.AutoSize = true;
            this.lblm.Location = new System.Drawing.Point(40, 24);
            this.lblm.Name = "lblm";
            this.lblm.Size = new System.Drawing.Size(15, 13);
            this.lblm.TabIndex = 5;
            this.lblm.Text = "m";
            // 
            // lblBrh
            // 
            this.lblBrh.AutoSize = true;
            this.lblBrh.Location = new System.Drawing.Point(3, 63);
            this.lblBrh.Name = "lblBrh";
            this.lblBrh.Size = new System.Drawing.Size(16, 13);
            this.lblBrh.TabIndex = 7;
            this.lblBrh.Text = "---";
            // 
            // lblbremsh
            // 
            this.lblbremsh.AutoSize = true;
            this.lblbremsh.Location = new System.Drawing.Point(40, 63);
            this.lblbremsh.Name = "lblbremsh";
            this.lblbremsh.Size = new System.Drawing.Size(25, 13);
            this.lblbremsh.TabIndex = 6;
            this.lblbremsh.Text = "BrH";
            // 
            // lblMeter
            // 
            this.lblMeter.AutoSize = true;
            this.lblMeter.Location = new System.Drawing.Point(3, 24);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new System.Drawing.Size(16, 13);
            this.lblMeter.TabIndex = 3;
            this.lblMeter.Text = "---";
            // 
            // lblkmh
            // 
            this.lblkmh.AutoSize = true;
            this.lblkmh.Location = new System.Drawing.Point(40, 0);
            this.lblkmh.Name = "lblkmh";
            this.lblkmh.Size = new System.Drawing.Size(32, 13);
            this.lblkmh.TabIndex = 4;
            this.lblkmh.Text = "km/h";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV.Location = new System.Drawing.Point(3, 0);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(31, 24);
            this.lblV.TabIndex = 1;
            this.lblV.Text = "---";
            // 
            // pnlData
            // 
            this.pnlData.AutoSize = true;
            this.pnlData.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlData.ColumnCount = 2;
            this.pnlData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlData.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlData.Controls.Add(this.lblV, 0, 0);
            this.pnlData.Controls.Add(this.lblbarbz, 1, 3);
            this.pnlData.Controls.Add(this.lblkmh, 1, 0);
            this.pnlData.Controls.Add(this.lblBrh, 0, 4);
            this.pnlData.Controls.Add(this.lblMeter, 0, 1);
            this.pnlData.Controls.Add(this.lblHlldruck, 0, 2);
            this.pnlData.Controls.Add(this.lblBzdruck, 0, 3);
            this.pnlData.Controls.Add(this.lblbremsh, 1, 4);
            this.pnlData.Controls.Add(this.lblm, 1, 1);
            this.pnlData.Controls.Add(this.lblbarhll, 1, 2);
            this.pnlData.Location = new System.Drawing.Point(8, 97);
            this.pnlData.Name = "pnlData";
            this.pnlData.RowCount = 5;
            this.pnlData.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlData.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlData.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlData.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlData.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlData.Size = new System.Drawing.Size(80, 76);
            this.pnlData.TabIndex = 16;
            // 
            // CMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1043, 402);
            this.Controls.Add(this.pnlData);
            this.Controls.Add(this.btnNacht);
            this.Controls.Add(this.lblSifa);
            this.Controls.Add(this.btnSettings);
            this.Controls.Add(this.pnlRight);
            this.Controls.Add(this.lblFlag);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "CMainWindow";
            this.Text = "ZusiMeter - v0.3";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CMainWindow_Load);
            this.pnlSettings.ResumeLayout(false);
            this.tabEinstellungen.ResumeLayout(false);
            this.tabAnzeigen.ResumeLayout(false);
            this.grpVisibledata.ResumeLayout(false);
            this.grpVisibledata.PerformLayout();
            this.tabSystem.ResumeLayout(false);
            this.grpVerbindung.ResumeLayout(false);
            this.grpVerbindung.PerformLayout();
            this.pnlDebug.ResumeLayout(false);
            this.grpDebug.ResumeLayout(false);
            this.grpDebug.PerformLayout();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlData.ResumeLayout(false);
            this.pnlData.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblSifa;
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
        private System.Windows.Forms.Timer timerFlag;
        private System.Windows.Forms.Button btnNacht;
        private System.Windows.Forms.Label lblbarhll;
        private System.Windows.Forms.Label lblHlldruck;
        private System.Windows.Forms.Label lblbarbz;
        private System.Windows.Forms.Label lblBzdruck;
        private System.Windows.Forms.GroupBox grpVisibledata;
        private System.Windows.Forms.CheckBox cbBrh;
        private System.Windows.Forms.CheckBox cbDruckbz;
        private System.Windows.Forms.CheckBox cbDruckhll;
        private System.Windows.Forms.CheckBox cbStreckenmeter;
        private System.Windows.Forms.CheckBox cbGeschwindigkeit;
        private System.Windows.Forms.Label lblm;
        private System.Windows.Forms.Label lblBrh;
        private System.Windows.Forms.Label lblbremsh;
        private System.Windows.Forms.Label lblMeter;
        private System.Windows.Forms.Label lblkmh;
        private System.Windows.Forms.Label lblV;
        private System.Windows.Forms.TableLayoutPanel pnlData;
        private System.Windows.Forms.TabControl tabEinstellungen;
        private System.Windows.Forms.TabPage tabAnzeigen;
        private System.Windows.Forms.TabPage tabDarstellung;
        private System.Windows.Forms.TabPage tabSystem;

    }
}

