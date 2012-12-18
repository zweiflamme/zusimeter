namespace Zielbremsen
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMainWindow));
            this.lblSifa = new System.Windows.Forms.Label();
            this.lblbarbz = new System.Windows.Forms.Label();
            this.lblBzdruck = new System.Windows.Forms.Label();
            this.lblbarhll = new System.Windows.Forms.Label();
            this.lblHlldruck = new System.Windows.Forms.Label();
            this.btnSettings = new System.Windows.Forms.Button();
            this.pnlSettings = new System.Windows.Forms.Panel();
            this.tabEinstellungen = new System.Windows.Forms.TabControl();
            this.tabAnzeigen1 = new System.Windows.Forms.TabPage();
            this.numSizeAFBLZB = new System.Windows.Forms.NumericUpDown();
            this.numSizeBremsen = new System.Windows.Forms.NumericUpDown();
            this.cbRailrunner = new System.Windows.Forms.CheckBox();
            this.cbSchalterst = new System.Windows.Forms.CheckBox();
            this.numSizeGrunddaten = new System.Windows.Forms.NumericUpDown();
            this.pnlRailrunner = new System.Windows.Forms.Panel();
            this.label7 = new System.Windows.Forms.Label();
            this.rbRRfest = new System.Windows.Forms.RadioButton();
            this.numRRfest = new System.Windows.Forms.NumericUpDown();
            this.rbRRfrei = new System.Windows.Forms.RadioButton();
            this.cbAFBLZB = new System.Windows.Forms.CheckBox();
            this.cbGrunddaten = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.pnlAFBLZB = new System.Windows.Forms.Panel();
            this.cbAFBvor5 = new System.Windows.Forms.CheckBox();
            this.cbAFBVorwahl = new System.Windows.Forms.CheckBox();
            this.cbAFBvor10 = new System.Windows.Forms.CheckBox();
            this.cbLZBvziel = new System.Windows.Forms.CheckBox();
            this.cbLZBweg = new System.Windows.Forms.CheckBox();
            this.cbLZBvsoll = new System.Windows.Forms.CheckBox();
            this.cbAFBgeschw = new System.Windows.Forms.CheckBox();
            this.pnlGrunddaten = new System.Windows.Forms.Panel();
            this.cbPZBLM = new System.Windows.Forms.CheckBox();
            this.cbStreckenmeter = new System.Windows.Forms.CheckBox();
            this.cbGeschwindigkeit = new System.Windows.Forms.CheckBox();
            this.cbFahrstufe = new System.Windows.Forms.CheckBox();
            this.cbLmsifa = new System.Windows.Forms.CheckBox();
            this.cbTueren = new System.Windows.Forms.CheckBox();
            this.cbUhrzeit = new System.Windows.Forms.CheckBox();
            this.cbLmschleudern = new System.Windows.Forms.CheckBox();
            this.pnlBremsen = new System.Windows.Forms.Panel();
            this.cbZusbremse = new System.Windows.Forms.CheckBox();
            this.cbDruckhbl = new System.Windows.Forms.CheckBox();
            this.cbDynbremse = new System.Windows.Forms.CheckBox();
            this.cbDruckhlb = new System.Windows.Forms.CheckBox();
            this.cbFbv = new System.Windows.Forms.CheckBox();
            this.cbDruckhll = new System.Windows.Forms.CheckBox();
            this.cbBrh = new System.Windows.Forms.CheckBox();
            this.cbDruckbz = new System.Windows.Forms.CheckBox();
            this.cbBremsen = new System.Windows.Forms.CheckBox();
            this.pnlSchalterst = new System.Windows.Forms.Panel();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.cbMotorsch = new System.Windows.Forms.CheckBox();
            this.cbFahrtrichtg = new System.Windows.Forms.CheckBox();
            this.cbSchleuderschutz = new System.Windows.Forms.CheckBox();
            this.cbHauptsch = new System.Windows.Forms.CheckBox();
            this.numFahrschneutral = new System.Windows.Forms.NumericUpDown();
            this.lblFahrschneutralbei = new System.Windows.Forms.Label();
            this.cbFahrstufenschalter = new System.Windows.Forms.CheckBox();
            this.tabDarstellung = new System.Windows.Forms.TabPage();
            this.label1 = new System.Windows.Forms.Label();
            this.cbFokusFahrtzurueck = new System.Windows.Forms.CheckBox();
            this.btnFarbeTag = new System.Windows.Forms.Button();
            this.btnFarbeNacht = new System.Windows.Forms.Button();
            this.cbTopmost = new System.Windows.Forms.CheckBox();
            this.cbFokusImmerzurueck = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.numSifagroesse = new System.Windows.Forms.NumericUpDown();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rbDarstMeter = new System.Windows.Forms.RadioButton();
            this.rbDarstKm = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.tabSystem = new System.Windows.Forms.TabPage();
            this.grpVerbindung = new System.Windows.Forms.GroupBox();
            this.tbServer = new System.Windows.Forms.TextBox();
            this.tbPort = new System.Windows.Forms.TextBox();
            this.btnConnect = new System.Windows.Forms.Button();
            this.btnDebugpanel = new System.Windows.Forms.Button();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.lblVerbstatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblFlag = new System.Windows.Forms.Label();
            this.pnlDebug = new System.Windows.Forms.Panel();
            this.grpDebug = new System.Windows.Forms.GroupBox();
            this.lblDebugafbschalter = new System.Windows.Forms.Label();
            this.grpDebugoffline = new System.Windows.Forms.GroupBox();
            this.numDebugsetspeed = new System.Windows.Forms.NumericUpDown();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lblDebugreiseztrue = new System.Windows.Forms.Label();
            this.lblDebugreisezwert = new System.Windows.Forms.Label();
            this.lblDebugreisezug = new System.Windows.Forms.Label();
            this.btnDebugFokusZusi = new System.Windows.Forms.Button();
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
            this.pnlDataGrunddaten = new System.Windows.Forms.TableLayoutPanel();
            this.lblFahrstufenschalter = new System.Windows.Forms.Label();
            this.lblfahrstschalter = new System.Windows.Forms.Label();
            this.lblfahrst = new System.Windows.Forms.Label();
            this.lblFahrstufe = new System.Windows.Forms.Label();
            this.lblTueren = new System.Windows.Forms.Label();
            this.pnlDataBremsen = new System.Windows.Forms.TableLayoutPanel();
            this.lblfbv = new System.Windows.Forms.Label();
            this.lbldynbrem = new System.Windows.Forms.Label();
            this.lblzusbr = new System.Windows.Forms.Label();
            this.lblFbventil = new System.Windows.Forms.Label();
            this.lblDynbremse = new System.Windows.Forms.Label();
            this.lblZusbremse = new System.Windows.Forms.Label();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pnlDataAFBLZB = new System.Windows.Forms.TableLayoutPanel();
            this.lblAFBvorwahl = new System.Windows.Forms.Label();
            this.lblafbvorw = new System.Windows.Forms.Label();
            this.lblafbeinaus = new System.Windows.Forms.Label();
            this.lbllzbvsoll = new System.Windows.Forms.Label();
            this.lbllzbvziel = new System.Windows.Forms.Label();
            this.lbllzbzielw = new System.Windows.Forms.Label();
            this.lblAFBgeschwindigkeit = new System.Windows.Forms.Label();
            this.lblLZBsollgeschw = new System.Windows.Forms.Label();
            this.lblLZBzielgeschw = new System.Windows.Forms.Label();
            this.lblLZBzielweg = new System.Windows.Forms.Label();
            this.pnlLeft = new System.Windows.Forms.TableLayoutPanel();
            this.btnRailrunner = new System.Windows.Forms.Button();
            this.pnlDataPZB90 = new System.Windows.Forms.TableLayoutPanel();
            this.lblPZB_1000 = new System.Windows.Forms.Label();
            this.lblPZB_500 = new System.Windows.Forms.Label();
            this.lblPZB_Bef = new System.Windows.Forms.Label();
            this.lblPZB_U = new System.Windows.Forms.Label();
            this.lblPZB_M = new System.Windows.Forms.Label();
            this.lblPZB_O = new System.Windows.Forms.Label();
            this.timer100 = new System.Windows.Forms.Timer(this.components);
            this.timerRailrunner = new System.Windows.Forms.Timer(this.components);
            this.cbRRcountup = new System.Windows.Forms.CheckBox();
            this.cbRRcountdown = new System.Windows.Forms.CheckBox();
            this.cbRRSound = new System.Windows.Forms.CheckBox();
            this.btnDebugPlaysound = new System.Windows.Forms.Button();
            this.cbRRautoreset = new System.Windows.Forms.CheckBox();
            this.pnlSettings.SuspendLayout();
            this.tabEinstellungen.SuspendLayout();
            this.tabAnzeigen1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeAFBLZB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeBremsen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeGrunddaten)).BeginInit();
            this.pnlRailrunner.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRRfest)).BeginInit();
            this.pnlAFBLZB.SuspendLayout();
            this.pnlGrunddaten.SuspendLayout();
            this.pnlBremsen.SuspendLayout();
            this.pnlSchalterst.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFahrschneutral)).BeginInit();
            this.tabDarstellung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSifagroesse)).BeginInit();
            this.panel1.SuspendLayout();
            this.tabSystem.SuspendLayout();
            this.grpVerbindung.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.pnlDebug.SuspendLayout();
            this.grpDebug.SuspendLayout();
            this.grpDebugoffline.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDebugsetspeed)).BeginInit();
            this.pnlRight.SuspendLayout();
            this.pnlDataGrunddaten.SuspendLayout();
            this.pnlDataBremsen.SuspendLayout();
            this.pnlDataAFBLZB.SuspendLayout();
            this.pnlLeft.SuspendLayout();
            this.pnlDataPZB90.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblSifa
            // 
            this.lblSifa.BackColor = System.Drawing.Color.DarkGray;
            this.lblSifa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblSifa.Location = new System.Drawing.Point(3, 0);
            this.lblSifa.Name = "lblSifa";
            this.lblSifa.Size = new System.Drawing.Size(114, 51);
            this.lblSifa.TabIndex = 0;
            this.lblSifa.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblbarbz
            // 
            this.lblbarbz.AutoSize = true;
            this.lblbarbz.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblbarbz.Location = new System.Drawing.Point(54, 26);
            this.lblbarbz.Name = "lblbarbz";
            this.lblbarbz.Size = new System.Drawing.Size(37, 13);
            this.lblbarbz.TabIndex = 11;
            this.lblbarbz.Text = "bar Bz";
            // 
            // lblBzdruck
            // 
            this.lblBzdruck.AutoSize = true;
            this.lblBzdruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBzdruck.Location = new System.Drawing.Point(3, 26);
            this.lblBzdruck.Name = "lblBzdruck";
            this.lblBzdruck.Size = new System.Drawing.Size(45, 13);
            this.lblBzdruck.TabIndex = 10;
            this.lblBzdruck.Text = "8,8";
            // 
            // lblbarhll
            // 
            this.lblbarhll.AutoSize = true;
            this.lblbarhll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblbarhll.Location = new System.Drawing.Point(54, 13);
            this.lblbarhll.Name = "lblbarhll";
            this.lblbarhll.Size = new System.Drawing.Size(37, 13);
            this.lblbarhll.TabIndex = 9;
            this.lblbarhll.Text = "bar Hll";
            // 
            // lblHlldruck
            // 
            this.lblHlldruck.AutoSize = true;
            this.lblHlldruck.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblHlldruck.Location = new System.Drawing.Point(3, 13);
            this.lblHlldruck.Name = "lblHlldruck";
            this.lblHlldruck.Size = new System.Drawing.Size(45, 13);
            this.lblHlldruck.TabIndex = 8;
            this.lblHlldruck.Text = "8,8";
            // 
            // btnSettings
            // 
            this.btnSettings.AutoSize = true;
            this.btnSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnSettings.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSettings.Location = new System.Drawing.Point(3, 442);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(118, 25);
            this.btnSettings.TabIndex = 6;
            this.btnSettings.Text = "Einstellungen";
            this.btnSettings.UseVisualStyleBackColor = true;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // pnlSettings
            // 
            this.pnlSettings.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlSettings.Controls.Add(this.tabEinstellungen);
            this.pnlSettings.Controls.Add(this.statusStrip1);
            this.pnlSettings.Location = new System.Drawing.Point(3, 1);
            this.pnlSettings.Name = "pnlSettings";
            this.pnlSettings.Size = new System.Drawing.Size(421, 454);
            this.pnlSettings.TabIndex = 10;
            // 
            // tabEinstellungen
            // 
            this.tabEinstellungen.Controls.Add(this.tabAnzeigen1);
            this.tabEinstellungen.Controls.Add(this.tabDarstellung);
            this.tabEinstellungen.Controls.Add(this.tabSystem);
            this.tabEinstellungen.Location = new System.Drawing.Point(3, 2);
            this.tabEinstellungen.Name = "tabEinstellungen";
            this.tabEinstellungen.SelectedIndex = 0;
            this.tabEinstellungen.Size = new System.Drawing.Size(415, 402);
            this.tabEinstellungen.SizeMode = System.Windows.Forms.TabSizeMode.FillToRight;
            this.tabEinstellungen.TabIndex = 0;
            this.tabEinstellungen.SelectedIndexChanged += new System.EventHandler(this.tabEinstellungen_SelectedIndexChanged);
            // 
            // tabAnzeigen1
            // 
            this.tabAnzeigen1.BackColor = System.Drawing.SystemColors.Control;
            this.tabAnzeigen1.Controls.Add(this.numSizeAFBLZB);
            this.tabAnzeigen1.Controls.Add(this.numSizeBremsen);
            this.tabAnzeigen1.Controls.Add(this.cbRailrunner);
            this.tabAnzeigen1.Controls.Add(this.cbSchalterst);
            this.tabAnzeigen1.Controls.Add(this.numSizeGrunddaten);
            this.tabAnzeigen1.Controls.Add(this.pnlRailrunner);
            this.tabAnzeigen1.Controls.Add(this.cbAFBLZB);
            this.tabAnzeigen1.Controls.Add(this.cbGrunddaten);
            this.tabAnzeigen1.Controls.Add(this.label6);
            this.tabAnzeigen1.Controls.Add(this.pnlAFBLZB);
            this.tabAnzeigen1.Controls.Add(this.pnlGrunddaten);
            this.tabAnzeigen1.Controls.Add(this.pnlBremsen);
            this.tabAnzeigen1.Controls.Add(this.cbBremsen);
            this.tabAnzeigen1.Controls.Add(this.pnlSchalterst);
            this.tabAnzeigen1.Location = new System.Drawing.Point(4, 22);
            this.tabAnzeigen1.Name = "tabAnzeigen1";
            this.tabAnzeigen1.Padding = new System.Windows.Forms.Padding(3);
            this.tabAnzeigen1.Size = new System.Drawing.Size(407, 376);
            this.tabAnzeigen1.TabIndex = 0;
            this.tabAnzeigen1.Text = "Anzeigen";
            // 
            // numSizeAFBLZB
            // 
            this.numSizeAFBLZB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSizeAFBLZB.Location = new System.Drawing.Point(286, 169);
            this.numSizeAFBLZB.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSizeAFBLZB.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numSizeAFBLZB.Name = "numSizeAFBLZB";
            this.numSizeAFBLZB.Size = new System.Drawing.Size(16, 20);
            this.numSizeAFBLZB.TabIndex = 38;
            this.numSizeAFBLZB.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numSizeAFBLZB.ValueChanged += new System.EventHandler(this.numSizeAFBLZB_ValueChanged);
            // 
            // numSizeBremsen
            // 
            this.numSizeBremsen.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSizeBremsen.Location = new System.Drawing.Point(65, 146);
            this.numSizeBremsen.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSizeBremsen.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numSizeBremsen.Name = "numSizeBremsen";
            this.numSizeBremsen.Size = new System.Drawing.Size(16, 20);
            this.numSizeBremsen.TabIndex = 39;
            this.numSizeBremsen.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numSizeBremsen.ValueChanged += new System.EventHandler(this.numSizeBremsen_ValueChanged);
            // 
            // cbRailrunner
            // 
            this.cbRailrunner.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRailrunner.AutoSize = true;
            this.cbRailrunner.Checked = true;
            this.cbRailrunner.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRailrunner.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.cbRailrunner.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cbRailrunner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRailrunner.Location = new System.Drawing.Point(6, 280);
            this.cbRailrunner.Name = "cbRailrunner";
            this.cbRailrunner.Size = new System.Drawing.Size(65, 23);
            this.cbRailrunner.TabIndex = 31;
            this.cbRailrunner.Text = "Railrunner";
            this.cbRailrunner.UseVisualStyleBackColor = true;
            this.cbRailrunner.CheckedChanged += new System.EventHandler(this.cbRailrunner_CheckedChanged);
            // 
            // cbSchalterst
            // 
            this.cbSchalterst.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbSchalterst.AutoSize = true;
            this.cbSchalterst.Checked = true;
            this.cbSchalterst.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbSchalterst.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.cbSchalterst.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cbSchalterst.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSchalterst.Location = new System.Drawing.Point(217, 9);
            this.cbSchalterst.Name = "cbSchalterst";
            this.cbSchalterst.Size = new System.Drawing.Size(104, 23);
            this.cbSchalterst.TabIndex = 8;
            this.cbSchalterst.Text = "Schalterstellungen";
            this.cbSchalterst.UseVisualStyleBackColor = true;
            this.cbSchalterst.CheckedChanged += new System.EventHandler(this.cbSchalterst_CheckedChanged);
            // 
            // numSizeGrunddaten
            // 
            this.numSizeGrunddaten.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numSizeGrunddaten.Location = new System.Drawing.Point(80, 12);
            this.numSizeGrunddaten.Maximum = new decimal(new int[] {
            4,
            0,
            0,
            0});
            this.numSizeGrunddaten.Minimum = new decimal(new int[] {
            2,
            0,
            0,
            -2147483648});
            this.numSizeGrunddaten.Name = "numSizeGrunddaten";
            this.numSizeGrunddaten.Size = new System.Drawing.Size(16, 20);
            this.numSizeGrunddaten.TabIndex = 40;
            this.numSizeGrunddaten.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numSizeGrunddaten.ValueChanged += new System.EventHandler(this.numSizeGrunddaten_ValueChanged);
            // 
            // pnlRailrunner
            // 
            this.pnlRailrunner.Controls.Add(this.cbRRautoreset);
            this.pnlRailrunner.Controls.Add(this.cbRRSound);
            this.pnlRailrunner.Controls.Add(this.cbRRcountdown);
            this.pnlRailrunner.Controls.Add(this.label7);
            this.pnlRailrunner.Controls.Add(this.cbRRcountup);
            this.pnlRailrunner.Controls.Add(this.rbRRfest);
            this.pnlRailrunner.Controls.Add(this.numRRfest);
            this.pnlRailrunner.Controls.Add(this.rbRRfrei);
            this.pnlRailrunner.Location = new System.Drawing.Point(6, 305);
            this.pnlRailrunner.Name = "pnlRailrunner";
            this.pnlRailrunner.Size = new System.Drawing.Size(171, 68);
            this.pnlRailrunner.TabIndex = 25;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Enabled = false;
            this.label7.Location = new System.Drawing.Point(144, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(15, 13);
            this.label7.TabIndex = 36;
            this.label7.Text = "m";
            // 
            // rbRRfest
            // 
            this.rbRRfest.AutoSize = true;
            this.rbRRfest.Location = new System.Drawing.Point(48, 4);
            this.rbRRfest.Name = "rbRRfest";
            this.rbRRfest.Size = new System.Drawing.Size(45, 17);
            this.rbRRfest.TabIndex = 34;
            this.rbRRfest.TabStop = true;
            this.rbRRfest.Text = "fest:";
            this.rbRRfest.UseVisualStyleBackColor = true;
            this.rbRRfest.CheckedChanged += new System.EventHandler(this.rbRRfest_CheckedChanged);
            // 
            // numRRfest
            // 
            this.numRRfest.Enabled = false;
            this.numRRfest.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRRfest.Location = new System.Drawing.Point(93, 1);
            this.numRRfest.Maximum = new decimal(new int[] {
            9999,
            0,
            0,
            0});
            this.numRRfest.Name = "numRRfest";
            this.numRRfest.ReadOnly = true;
            this.numRRfest.Size = new System.Drawing.Size(45, 20);
            this.numRRfest.TabIndex = 35;
            this.numRRfest.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.numRRfest.ValueChanged += new System.EventHandler(this.numRRfest_ValueChanged);
            // 
            // rbRRfrei
            // 
            this.rbRRfrei.AutoSize = true;
            this.rbRRfrei.Checked = true;
            this.rbRRfrei.Location = new System.Drawing.Point(3, 4);
            this.rbRRfrei.Name = "rbRRfrei";
            this.rbRRfrei.Size = new System.Drawing.Size(39, 17);
            this.rbRRfrei.TabIndex = 33;
            this.rbRRfrei.TabStop = true;
            this.rbRRfrei.Text = "frei";
            this.rbRRfrei.UseVisualStyleBackColor = true;
            this.rbRRfrei.CheckedChanged += new System.EventHandler(this.rbRRfrei_CheckedChanged);
            // 
            // cbAFBLZB
            // 
            this.cbAFBLZB.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbAFBLZB.AutoSize = true;
            this.cbAFBLZB.Checked = true;
            this.cbAFBLZB.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAFBLZB.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.cbAFBLZB.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cbAFBLZB.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAFBLZB.Location = new System.Drawing.Point(217, 165);
            this.cbAFBLZB.Name = "cbAFBLZB";
            this.cbAFBLZB.Size = new System.Drawing.Size(68, 23);
            this.cbAFBLZB.TabIndex = 26;
            this.cbAFBLZB.Text = "AFB / LZB";
            this.cbAFBLZB.UseVisualStyleBackColor = true;
            this.cbAFBLZB.CheckedChanged += new System.EventHandler(this.cbAFBLZB_CheckedChanged);
            // 
            // cbGrunddaten
            // 
            this.cbGrunddaten.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbGrunddaten.AutoSize = true;
            this.cbGrunddaten.Checked = true;
            this.cbGrunddaten.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbGrunddaten.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.cbGrunddaten.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cbGrunddaten.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbGrunddaten.Location = new System.Drawing.Point(6, 9);
            this.cbGrunddaten.Name = "cbGrunddaten";
            this.cbGrunddaten.Size = new System.Drawing.Size(73, 23);
            this.cbGrunddaten.TabIndex = 8;
            this.cbGrunddaten.Text = "Grunddaten";
            this.cbGrunddaten.UseVisualStyleBackColor = true;
            this.cbGrunddaten.CheckedChanged += new System.EventHandler(this.cbGrunddaten_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(76, 285);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 32;
            this.label6.Text = "Wegmessung";
            // 
            // pnlAFBLZB
            // 
            this.pnlAFBLZB.Controls.Add(this.cbAFBvor5);
            this.pnlAFBLZB.Controls.Add(this.cbAFBVorwahl);
            this.pnlAFBLZB.Controls.Add(this.cbAFBvor10);
            this.pnlAFBLZB.Controls.Add(this.cbLZBvziel);
            this.pnlAFBLZB.Controls.Add(this.cbLZBweg);
            this.pnlAFBLZB.Controls.Add(this.cbLZBvsoll);
            this.pnlAFBLZB.Controls.Add(this.cbAFBgeschw);
            this.pnlAFBLZB.Location = new System.Drawing.Point(217, 190);
            this.pnlAFBLZB.Name = "pnlAFBLZB";
            this.pnlAFBLZB.Size = new System.Drawing.Size(182, 90);
            this.pnlAFBLZB.TabIndex = 24;
            // 
            // cbAFBvor5
            // 
            this.cbAFBvor5.AutoSize = true;
            this.cbAFBvor5.Checked = true;
            this.cbAFBvor5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAFBvor5.Location = new System.Drawing.Point(21, 55);
            this.cbAFBvor5.Name = "cbAFBvor5";
            this.cbAFBvor5.Size = new System.Drawing.Size(60, 17);
            this.cbAFBvor5.TabIndex = 32;
            this.cbAFBvor5.Text = "5 km/h";
            this.cbAFBvor5.UseVisualStyleBackColor = true;
            this.cbAFBvor5.CheckedChanged += new System.EventHandler(this.cbAFBvor5_CheckedChanged);
            // 
            // cbAFBVorwahl
            // 
            this.cbAFBVorwahl.AutoSize = true;
            this.cbAFBVorwahl.Location = new System.Drawing.Point(3, 39);
            this.cbAFBVorwahl.Name = "cbAFBVorwahl";
            this.cbAFBVorwahl.Size = new System.Drawing.Size(101, 17);
            this.cbAFBVorwahl.TabIndex = 31;
            this.cbAFBVorwahl.Text = "AFB vorgewählt";
            this.cbAFBVorwahl.UseVisualStyleBackColor = true;
            this.cbAFBVorwahl.CheckedChanged += new System.EventHandler(this.cbAFBVorwahl_CheckedChanged);
            // 
            // cbAFBvor10
            // 
            this.cbAFBvor10.AutoSize = true;
            this.cbAFBvor10.Location = new System.Drawing.Point(21, 71);
            this.cbAFBvor10.Name = "cbAFBvor10";
            this.cbAFBvor10.Size = new System.Drawing.Size(66, 17);
            this.cbAFBvor10.TabIndex = 33;
            this.cbAFBvor10.Text = "10 km/h";
            this.cbAFBvor10.UseVisualStyleBackColor = true;
            this.cbAFBvor10.CheckedChanged += new System.EventHandler(this.cbAFBvor10_CheckedChanged);
            // 
            // cbLZBvziel
            // 
            this.cbLZBvziel.AutoSize = true;
            this.cbLZBvziel.Location = new System.Drawing.Point(86, 4);
            this.cbLZBvziel.Name = "cbLZBvziel";
            this.cbLZBvziel.Size = new System.Drawing.Size(78, 17);
            this.cbLZBvziel.TabIndex = 30;
            this.cbLZBvziel.Text = "LZB - vZiel";
            this.cbLZBvziel.UseVisualStyleBackColor = true;
            this.cbLZBvziel.CheckedChanged += new System.EventHandler(this.cbLZBvziel_CheckedChanged);
            // 
            // cbLZBweg
            // 
            this.cbLZBweg.AutoSize = true;
            this.cbLZBweg.Location = new System.Drawing.Point(86, 20);
            this.cbLZBweg.Name = "cbLZBweg";
            this.cbLZBweg.Size = new System.Drawing.Size(89, 17);
            this.cbLZBweg.TabIndex = 29;
            this.cbLZBweg.Text = "LZB - Ziel (m)";
            this.cbLZBweg.UseVisualStyleBackColor = true;
            this.cbLZBweg.CheckedChanged += new System.EventHandler(this.cbLZBweg_CheckedChanged);
            // 
            // cbLZBvsoll
            // 
            this.cbLZBvsoll.AutoSize = true;
            this.cbLZBvsoll.Location = new System.Drawing.Point(3, 20);
            this.cbLZBvsoll.Name = "cbLZBvsoll";
            this.cbLZBvsoll.Size = new System.Drawing.Size(78, 17);
            this.cbLZBvsoll.TabIndex = 28;
            this.cbLZBvsoll.Text = "LZB - vSoll";
            this.cbLZBvsoll.UseVisualStyleBackColor = true;
            this.cbLZBvsoll.CheckedChanged += new System.EventHandler(this.cbLZBvsoll_CheckedChanged);
            // 
            // cbAFBgeschw
            // 
            this.cbAFBgeschw.AutoSize = true;
            this.cbAFBgeschw.Checked = true;
            this.cbAFBgeschw.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbAFBgeschw.Location = new System.Drawing.Point(3, 3);
            this.cbAFBgeschw.Name = "cbAFBgeschw";
            this.cbAFBgeschw.Size = new System.Drawing.Size(78, 17);
            this.cbAFBgeschw.TabIndex = 27;
            this.cbAFBgeschw.Text = "AFB - vSoll";
            this.cbAFBgeschw.UseVisualStyleBackColor = true;
            this.cbAFBgeschw.CheckedChanged += new System.EventHandler(this.cbAFBgeschw_CheckedChanged);
            // 
            // pnlGrunddaten
            // 
            this.pnlGrunddaten.Controls.Add(this.cbPZBLM);
            this.pnlGrunddaten.Controls.Add(this.cbStreckenmeter);
            this.pnlGrunddaten.Controls.Add(this.cbGeschwindigkeit);
            this.pnlGrunddaten.Controls.Add(this.cbFahrstufe);
            this.pnlGrunddaten.Controls.Add(this.cbLmsifa);
            this.pnlGrunddaten.Controls.Add(this.cbTueren);
            this.pnlGrunddaten.Controls.Add(this.cbUhrzeit);
            this.pnlGrunddaten.Controls.Add(this.cbLmschleudern);
            this.pnlGrunddaten.Location = new System.Drawing.Point(6, 35);
            this.pnlGrunddaten.Name = "pnlGrunddaten";
            this.pnlGrunddaten.Size = new System.Drawing.Size(205, 95);
            this.pnlGrunddaten.TabIndex = 19;
            // 
            // cbPZBLM
            // 
            this.cbPZBLM.AutoSize = true;
            this.cbPZBLM.Checked = true;
            this.cbPZBLM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbPZBLM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPZBLM.Location = new System.Drawing.Point(3, 71);
            this.cbPZBLM.Name = "cbPZBLM";
            this.cbPZBLM.Size = new System.Drawing.Size(114, 17);
            this.cbPZBLM.TabIndex = 9;
            this.cbPZBLM.Text = "PZB-Leuchtmelder";
            this.cbPZBLM.UseVisualStyleBackColor = true;
            this.cbPZBLM.CheckedChanged += new System.EventHandler(this.cbPZBLM_CheckedChanged);
            // 
            // cbStreckenmeter
            // 
            this.cbStreckenmeter.AutoSize = true;
            this.cbStreckenmeter.Checked = true;
            this.cbStreckenmeter.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbStreckenmeter.Location = new System.Drawing.Point(3, 20);
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
            this.cbGeschwindigkeit.Location = new System.Drawing.Point(3, 3);
            this.cbGeschwindigkeit.Name = "cbGeschwindigkeit";
            this.cbGeschwindigkeit.Size = new System.Drawing.Size(104, 17);
            this.cbGeschwindigkeit.TabIndex = 0;
            this.cbGeschwindigkeit.Text = "Geschwindigkeit";
            this.cbGeschwindigkeit.UseVisualStyleBackColor = true;
            this.cbGeschwindigkeit.CheckedChanged += new System.EventHandler(this.cbGeschwindigkeit_CheckedChanged);
            // 
            // cbFahrstufe
            // 
            this.cbFahrstufe.AutoSize = true;
            this.cbFahrstufe.Checked = true;
            this.cbFahrstufe.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFahrstufe.Location = new System.Drawing.Point(3, 36);
            this.cbFahrstufe.Name = "cbFahrstufe";
            this.cbFahrstufe.Size = new System.Drawing.Size(70, 17);
            this.cbFahrstufe.TabIndex = 7;
            this.cbFahrstufe.Text = "Fahrstufe";
            this.cbFahrstufe.UseVisualStyleBackColor = true;
            this.cbFahrstufe.CheckedChanged += new System.EventHandler(this.cbFahrstufe_CheckedChanged);
            // 
            // cbLmsifa
            // 
            this.cbLmsifa.AutoSize = true;
            this.cbLmsifa.Checked = true;
            this.cbLmsifa.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLmsifa.Location = new System.Drawing.Point(113, 3);
            this.cbLmsifa.Name = "cbLmsifa";
            this.cbLmsifa.Size = new System.Drawing.Size(44, 17);
            this.cbLmsifa.TabIndex = 2;
            this.cbLmsifa.Text = "Sifa";
            this.cbLmsifa.UseVisualStyleBackColor = true;
            this.cbLmsifa.CheckedChanged += new System.EventHandler(this.cbLmsifa_CheckedChanged);
            // 
            // cbTueren
            // 
            this.cbTueren.AutoSize = true;
            this.cbTueren.Checked = true;
            this.cbTueren.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTueren.Location = new System.Drawing.Point(113, 20);
            this.cbTueren.Name = "cbTueren";
            this.cbTueren.Size = new System.Drawing.Size(54, 17);
            this.cbTueren.TabIndex = 3;
            this.cbTueren.Text = "Türen";
            this.cbTueren.UseVisualStyleBackColor = true;
            this.cbTueren.CheckedChanged += new System.EventHandler(this.cbLmtueren_CheckedChanged);
            // 
            // cbUhrzeit
            // 
            this.cbUhrzeit.AutoSize = true;
            this.cbUhrzeit.Enabled = false;
            this.cbUhrzeit.Location = new System.Drawing.Point(113, 36);
            this.cbUhrzeit.Name = "cbUhrzeit";
            this.cbUhrzeit.Size = new System.Drawing.Size(59, 17);
            this.cbUhrzeit.TabIndex = 6;
            this.cbUhrzeit.Text = "Uhrzeit";
            this.cbUhrzeit.UseVisualStyleBackColor = true;
            // 
            // cbLmschleudern
            // 
            this.cbLmschleudern.AutoSize = true;
            this.cbLmschleudern.Checked = true;
            this.cbLmschleudern.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbLmschleudern.Location = new System.Drawing.Point(3, 54);
            this.cbLmschleudern.Name = "cbLmschleudern";
            this.cbLmschleudern.Size = new System.Drawing.Size(142, 17);
            this.cbLmschleudern.TabIndex = 4;
            this.cbLmschleudern.Text = "LM Schleudern / Gleiten";
            this.cbLmschleudern.UseVisualStyleBackColor = true;
            this.cbLmschleudern.CheckedChanged += new System.EventHandler(this.cbLmschleudern_CheckedChanged);
            // 
            // pnlBremsen
            // 
            this.pnlBremsen.Controls.Add(this.cbZusbremse);
            this.pnlBremsen.Controls.Add(this.cbDruckhbl);
            this.pnlBremsen.Controls.Add(this.cbDynbremse);
            this.pnlBremsen.Controls.Add(this.cbDruckhlb);
            this.pnlBremsen.Controls.Add(this.cbFbv);
            this.pnlBremsen.Controls.Add(this.cbDruckhll);
            this.pnlBremsen.Controls.Add(this.cbBrh);
            this.pnlBremsen.Controls.Add(this.cbDruckbz);
            this.pnlBremsen.Location = new System.Drawing.Point(6, 167);
            this.pnlBremsen.Name = "pnlBremsen";
            this.pnlBremsen.Size = new System.Drawing.Size(205, 107);
            this.pnlBremsen.TabIndex = 19;
            // 
            // cbZusbremse
            // 
            this.cbZusbremse.AutoSize = true;
            this.cbZusbremse.Enabled = false;
            this.cbZusbremse.Location = new System.Drawing.Point(3, 83);
            this.cbZusbremse.Name = "cbZusbremse";
            this.cbZusbremse.Size = new System.Drawing.Size(92, 17);
            this.cbZusbremse.TabIndex = 25;
            this.cbZusbremse.Text = "Zusatzbremse";
            this.cbZusbremse.UseVisualStyleBackColor = true;
            // 
            // cbDruckhbl
            // 
            this.cbDruckhbl.AutoSize = true;
            this.cbDruckhbl.Enabled = false;
            this.cbDruckhbl.Location = new System.Drawing.Point(106, 5);
            this.cbDruckhbl.Name = "cbDruckhbl";
            this.cbDruckhbl.Size = new System.Drawing.Size(79, 17);
            this.cbDruckhbl.TabIndex = 11;
            this.cbDruckhbl.Text = "Druck HBL";
            this.cbDruckhbl.UseVisualStyleBackColor = true;
            // 
            // cbDynbremse
            // 
            this.cbDynbremse.AutoSize = true;
            this.cbDynbremse.Enabled = false;
            this.cbDynbremse.Location = new System.Drawing.Point(113, 62);
            this.cbDynbremse.Name = "cbDynbremse";
            this.cbDynbremse.Size = new System.Drawing.Size(86, 17);
            this.cbDynbremse.TabIndex = 24;
            this.cbDynbremse.Text = "Dyn. Bremse";
            this.cbDynbremse.UseVisualStyleBackColor = true;
            // 
            // cbDruckhlb
            // 
            this.cbDruckhlb.AutoSize = true;
            this.cbDruckhlb.Enabled = false;
            this.cbDruckhlb.Location = new System.Drawing.Point(106, 23);
            this.cbDruckhlb.Name = "cbDruckhlb";
            this.cbDruckhlb.Size = new System.Drawing.Size(79, 17);
            this.cbDruckhlb.TabIndex = 10;
            this.cbDruckhlb.Text = "Druck HLB";
            this.cbDruckhlb.UseVisualStyleBackColor = true;
            // 
            // cbFbv
            // 
            this.cbFbv.AutoSize = true;
            this.cbFbv.Enabled = false;
            this.cbFbv.Location = new System.Drawing.Point(3, 62);
            this.cbFbv.Name = "cbFbv";
            this.cbFbv.Size = new System.Drawing.Size(109, 17);
            this.cbFbv.TabIndex = 23;
            this.cbFbv.Text = "Führerbremsventil";
            this.cbFbv.UseVisualStyleBackColor = true;
            // 
            // cbDruckhll
            // 
            this.cbDruckhll.AutoSize = true;
            this.cbDruckhll.Checked = true;
            this.cbDruckhll.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbDruckhll.Location = new System.Drawing.Point(3, 23);
            this.cbDruckhll.Name = "cbDruckhll";
            this.cbDruckhll.Size = new System.Drawing.Size(70, 17);
            this.cbDruckhll.TabIndex = 2;
            this.cbDruckhll.Text = "Druck Hll";
            this.cbDruckhll.UseVisualStyleBackColor = true;
            this.cbDruckhll.CheckedChanged += new System.EventHandler(this.cbDruckhll_CheckedChanged);
            // 
            // cbBrh
            // 
            this.cbBrh.AutoSize = true;
            this.cbBrh.Checked = true;
            this.cbBrh.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBrh.Location = new System.Drawing.Point(3, 5);
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
            this.cbDruckbz.Location = new System.Drawing.Point(3, 43);
            this.cbDruckbz.Name = "cbDruckbz";
            this.cbDruckbz.Size = new System.Drawing.Size(122, 17);
            this.cbDruckbz.TabIndex = 3;
            this.cbDruckbz.Text = "Druck Bremszylinder";
            this.cbDruckbz.UseVisualStyleBackColor = true;
            this.cbDruckbz.CheckedChanged += new System.EventHandler(this.cbDruckbz_CheckedChanged);
            // 
            // cbBremsen
            // 
            this.cbBremsen.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbBremsen.AutoSize = true;
            this.cbBremsen.Checked = true;
            this.cbBremsen.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbBremsen.FlatAppearance.CheckedBackColor = System.Drawing.Color.DarkSeaGreen;
            this.cbBremsen.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.Control;
            this.cbBremsen.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbBremsen.Location = new System.Drawing.Point(6, 143);
            this.cbBremsen.Name = "cbBremsen";
            this.cbBremsen.Size = new System.Drawing.Size(58, 23);
            this.cbBremsen.TabIndex = 9;
            this.cbBremsen.Text = "Bremsen";
            this.cbBremsen.UseVisualStyleBackColor = true;
            this.cbBremsen.CheckedChanged += new System.EventHandler(this.cbBremsen_CheckedChanged);
            // 
            // pnlSchalterst
            // 
            this.pnlSchalterst.Controls.Add(this.checkBox2);
            this.pnlSchalterst.Controls.Add(this.checkBox1);
            this.pnlSchalterst.Controls.Add(this.cbMotorsch);
            this.pnlSchalterst.Controls.Add(this.cbFahrtrichtg);
            this.pnlSchalterst.Controls.Add(this.cbSchleuderschutz);
            this.pnlSchalterst.Controls.Add(this.cbHauptsch);
            this.pnlSchalterst.Controls.Add(this.numFahrschneutral);
            this.pnlSchalterst.Controls.Add(this.lblFahrschneutralbei);
            this.pnlSchalterst.Controls.Add(this.cbFahrstufenschalter);
            this.pnlSchalterst.Location = new System.Drawing.Point(217, 35);
            this.pnlSchalterst.Name = "pnlSchalterst";
            this.pnlSchalterst.Size = new System.Drawing.Size(183, 117);
            this.pnlSchalterst.TabIndex = 23;
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Enabled = false;
            this.checkBox2.Location = new System.Drawing.Point(72, 94);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(53, 17);
            this.checkBox2.TabIndex = 27;
            this.checkBox2.Text = "Lüfter";
            this.checkBox2.UseVisualStyleBackColor = true;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Enabled = false;
            this.checkBox1.Location = new System.Drawing.Point(3, 94);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(63, 17);
            this.checkBox1.TabIndex = 26;
            this.checkBox1.Text = "Sanden";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // cbMotorsch
            // 
            this.cbMotorsch.AutoSize = true;
            this.cbMotorsch.Enabled = false;
            this.cbMotorsch.Location = new System.Drawing.Point(101, 29);
            this.cbMotorsch.Name = "cbMotorsch";
            this.cbMotorsch.Size = new System.Drawing.Size(53, 17);
            this.cbMotorsch.TabIndex = 25;
            this.cbMotorsch.Text = "Motor";
            this.cbMotorsch.UseVisualStyleBackColor = true;
            // 
            // cbFahrtrichtg
            // 
            this.cbFahrtrichtg.AutoSize = true;
            this.cbFahrtrichtg.Enabled = false;
            this.cbFahrtrichtg.Location = new System.Drawing.Point(3, 49);
            this.cbFahrtrichtg.Name = "cbFahrtrichtg";
            this.cbFahrtrichtg.Size = new System.Drawing.Size(124, 17);
            this.cbFahrtrichtg.TabIndex = 24;
            this.cbFahrtrichtg.Text = "Fahrtrichtungs-Hebel";
            this.cbFahrtrichtg.UseVisualStyleBackColor = true;
            // 
            // cbSchleuderschutz
            // 
            this.cbSchleuderschutz.AutoSize = true;
            this.cbSchleuderschutz.Enabled = false;
            this.cbSchleuderschutz.Location = new System.Drawing.Point(3, 72);
            this.cbSchleuderschutz.Name = "cbSchleuderschutz";
            this.cbSchleuderschutz.Size = new System.Drawing.Size(105, 17);
            this.cbSchleuderschutz.TabIndex = 23;
            this.cbSchleuderschutz.Text = "Schleuderschutz";
            this.cbSchleuderschutz.UseVisualStyleBackColor = true;
            // 
            // cbHauptsch
            // 
            this.cbHauptsch.AutoSize = true;
            this.cbHauptsch.Enabled = false;
            this.cbHauptsch.Location = new System.Drawing.Point(3, 29);
            this.cbHauptsch.Name = "cbHauptsch";
            this.cbHauptsch.Size = new System.Drawing.Size(92, 17);
            this.cbHauptsch.TabIndex = 22;
            this.cbHauptsch.Text = "Hauptschalter";
            this.cbHauptsch.UseVisualStyleBackColor = true;
            // 
            // numFahrschneutral
            // 
            this.numFahrschneutral.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numFahrschneutral.Location = new System.Drawing.Point(142, 0);
            this.numFahrschneutral.Maximum = new decimal(new int[] {
            15,
            0,
            0,
            0});
            this.numFahrschneutral.Name = "numFahrschneutral";
            this.numFahrschneutral.ReadOnly = true;
            this.numFahrschneutral.Size = new System.Drawing.Size(33, 20);
            this.numFahrschneutral.TabIndex = 20;
            this.numFahrschneutral.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numFahrschneutral.ValueChanged += new System.EventHandler(this.numFahrschneutral_ValueChanged);
            // 
            // lblFahrschneutralbei
            // 
            this.lblFahrschneutralbei.AutoSize = true;
            this.lblFahrschneutralbei.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblFahrschneutralbei.Location = new System.Drawing.Point(83, 5);
            this.lblFahrschneutralbei.Name = "lblFahrschneutralbei";
            this.lblFahrschneutralbei.Size = new System.Drawing.Size(56, 13);
            this.lblFahrschneutralbei.TabIndex = 21;
            this.lblFahrschneutralbei.Text = "neutral bei";
            // 
            // cbFahrstufenschalter
            // 
            this.cbFahrstufenschalter.AutoSize = true;
            this.cbFahrstufenschalter.Location = new System.Drawing.Point(3, 5);
            this.cbFahrstufenschalter.Name = "cbFahrstufenschalter";
            this.cbFahrstufenschalter.Size = new System.Drawing.Size(84, 17);
            this.cbFahrstufenschalter.TabIndex = 9;
            this.cbFahrstufenschalter.Text = "Fahrschalter";
            this.cbFahrstufenschalter.UseVisualStyleBackColor = true;
            this.cbFahrstufenschalter.CheckedChanged += new System.EventHandler(this.cbFahrstufenschalter_CheckedChanged);
            // 
            // tabDarstellung
            // 
            this.tabDarstellung.BackColor = System.Drawing.SystemColors.Control;
            this.tabDarstellung.Controls.Add(this.label1);
            this.tabDarstellung.Controls.Add(this.cbFokusFahrtzurueck);
            this.tabDarstellung.Controls.Add(this.btnFarbeTag);
            this.tabDarstellung.Controls.Add(this.btnFarbeNacht);
            this.tabDarstellung.Controls.Add(this.cbTopmost);
            this.tabDarstellung.Controls.Add(this.cbFokusImmerzurueck);
            this.tabDarstellung.Controls.Add(this.label3);
            this.tabDarstellung.Controls.Add(this.numSifagroesse);
            this.tabDarstellung.Controls.Add(this.panel1);
            this.tabDarstellung.Controls.Add(this.label2);
            this.tabDarstellung.Location = new System.Drawing.Point(4, 22);
            this.tabDarstellung.Name = "tabDarstellung";
            this.tabDarstellung.Padding = new System.Windows.Forms.Padding(3);
            this.tabDarstellung.Size = new System.Drawing.Size(407, 350);
            this.tabDarstellung.TabIndex = 1;
            this.tabDarstellung.Text = "Darstellung";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 246);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(162, 13);
            this.label1.TabIndex = 21;
            this.label1.Text = "Fokus nach Klick zurück an Zusi";
            // 
            // cbFokusFahrtzurueck
            // 
            this.cbFokusFahrtzurueck.AutoSize = true;
            this.cbFokusFahrtzurueck.Checked = true;
            this.cbFokusFahrtzurueck.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbFokusFahrtzurueck.Location = new System.Drawing.Point(66, 264);
            this.cbFokusFahrtzurueck.Name = "cbFokusFahrtzurueck";
            this.cbFokusFahrtzurueck.Size = new System.Drawing.Size(115, 17);
            this.cbFokusFahrtzurueck.TabIndex = 20;
            this.cbFokusFahrtzurueck.Text = "Während der Fahrt";
            this.cbFokusFahrtzurueck.UseVisualStyleBackColor = true;
            this.cbFokusFahrtzurueck.CheckedChanged += new System.EventHandler(this.cbFokusFahrtzurueck_CheckedChanged);
            // 
            // btnFarbeTag
            // 
            this.btnFarbeTag.Enabled = false;
            this.btnFarbeTag.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFarbeTag.Location = new System.Drawing.Point(9, 167);
            this.btnFarbeTag.Name = "btnFarbeTag";
            this.btnFarbeTag.Size = new System.Drawing.Size(121, 23);
            this.btnFarbeTag.TabIndex = 19;
            this.btnFarbeTag.Text = "Farbe Tagmodus";
            this.btnFarbeTag.UseVisualStyleBackColor = true;
            this.btnFarbeTag.Click += new System.EventHandler(this.btnFarbeTag_Click);
            // 
            // btnFarbeNacht
            // 
            this.btnFarbeNacht.Enabled = false;
            this.btnFarbeNacht.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFarbeNacht.Location = new System.Drawing.Point(9, 138);
            this.btnFarbeNacht.Name = "btnFarbeNacht";
            this.btnFarbeNacht.Size = new System.Drawing.Size(121, 23);
            this.btnFarbeNacht.TabIndex = 18;
            this.btnFarbeNacht.Text = "Farbe Nachtmodus";
            this.btnFarbeNacht.UseVisualStyleBackColor = true;
            this.btnFarbeNacht.Click += new System.EventHandler(this.btnFarbeNacht_Click);
            // 
            // cbTopmost
            // 
            this.cbTopmost.AutoSize = true;
            this.cbTopmost.Checked = true;
            this.cbTopmost.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbTopmost.Location = new System.Drawing.Point(6, 213);
            this.cbTopmost.Name = "cbTopmost";
            this.cbTopmost.Size = new System.Drawing.Size(128, 17);
            this.cbTopmost.TabIndex = 17;
            this.cbTopmost.Text = "Immer im Vordergrund";
            this.cbTopmost.UseVisualStyleBackColor = true;
            this.cbTopmost.CheckedChanged += new System.EventHandler(this.cbTopmost_CheckedChanged);
            // 
            // cbFokusImmerzurueck
            // 
            this.cbFokusImmerzurueck.AutoSize = true;
            this.cbFokusImmerzurueck.Location = new System.Drawing.Point(6, 264);
            this.cbFokusImmerzurueck.Name = "cbFokusImmerzurueck";
            this.cbFokusImmerzurueck.Size = new System.Drawing.Size(54, 17);
            this.cbFokusImmerzurueck.TabIndex = 16;
            this.cbFokusImmerzurueck.Text = "Immer";
            this.cbFokusImmerzurueck.UseVisualStyleBackColor = true;
            this.cbFokusImmerzurueck.CheckedChanged += new System.EventHandler(this.cbFokusImmerzurueck_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 60);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(57, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Größe Sifa";
            // 
            // numSifagroesse
            // 
            this.numSifagroesse.Location = new System.Drawing.Point(68, 53);
            this.numSifagroesse.Maximum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numSifagroesse.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSifagroesse.Name = "numSifagroesse";
            this.numSifagroesse.ReadOnly = true;
            this.numSifagroesse.Size = new System.Drawing.Size(29, 20);
            this.numSifagroesse.TabIndex = 4;
            this.numSifagroesse.UpDownAlign = System.Windows.Forms.LeftRightAlignment.Left;
            this.numSifagroesse.Value = new decimal(new int[] {
            2,
            0,
            0,
            0});
            this.numSifagroesse.ValueChanged += new System.EventHandler(this.numSifagroesse_ValueChanged);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.rbDarstMeter);
            this.panel1.Controls.Add(this.rbDarstKm);
            this.panel1.Location = new System.Drawing.Point(7, 22);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(131, 23);
            this.panel1.TabIndex = 3;
            // 
            // rbDarstMeter
            // 
            this.rbDarstMeter.AutoSize = true;
            this.rbDarstMeter.Location = new System.Drawing.Point(3, 0);
            this.rbDarstMeter.Name = "rbDarstMeter";
            this.rbDarstMeter.Size = new System.Drawing.Size(52, 17);
            this.rbDarstMeter.TabIndex = 1;
            this.rbDarstMeter.Text = "Meter";
            this.rbDarstMeter.UseVisualStyleBackColor = true;
            this.rbDarstMeter.CheckedChanged += new System.EventHandler(this.rbDarstMeter_CheckedChanged);
            // 
            // rbDarstKm
            // 
            this.rbDarstKm.AutoSize = true;
            this.rbDarstKm.Checked = true;
            this.rbDarstKm.Location = new System.Drawing.Point(61, 0);
            this.rbDarstKm.Name = "rbDarstKm";
            this.rbDarstKm.Size = new System.Drawing.Size(68, 17);
            this.rbDarstKm.TabIndex = 2;
            this.rbDarstKm.TabStop = true;
            this.rbDarstKm.Text = "Kilometer";
            this.rbDarstKm.UseVisualStyleBackColor = true;
            this.rbDarstKm.CheckedChanged += new System.EventHandler(this.rbDarstKm_CheckedChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 6);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Streckenmeter";
            // 
            // tabSystem
            // 
            this.tabSystem.BackColor = System.Drawing.SystemColors.Control;
            this.tabSystem.Controls.Add(this.grpVerbindung);
            this.tabSystem.Controls.Add(this.btnDebugpanel);
            this.tabSystem.Location = new System.Drawing.Point(4, 22);
            this.tabSystem.Name = "tabSystem";
            this.tabSystem.Size = new System.Drawing.Size(407, 350);
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
            this.btnDebugpanel.Location = new System.Drawing.Point(3, 121);
            this.btnDebugpanel.Name = "btnDebugpanel";
            this.btnDebugpanel.Size = new System.Drawing.Size(121, 22);
            this.btnDebugpanel.TabIndex = 13;
            this.btnDebugpanel.Text = "DEBUG";
            this.btnDebugpanel.UseVisualStyleBackColor = true;
            this.btnDebugpanel.Click += new System.EventHandler(this.btnDebugpanel_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.AutoSize = false;
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblVerbstatus});
            this.statusStrip1.Location = new System.Drawing.Point(3, 415);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(129, 23);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.Stretch = false;
            this.statusStrip1.TabIndex = 18;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // lblVerbstatus
            // 
            this.lblVerbstatus.Name = "lblVerbstatus";
            this.lblVerbstatus.Size = new System.Drawing.Size(52, 18);
            this.lblVerbstatus.Text = "getrennt";
            // 
            // lblFlag
            // 
            this.lblFlag.BackColor = System.Drawing.Color.Orange;
            this.lblFlag.Location = new System.Drawing.Point(3, 51);
            this.lblFlag.Name = "lblFlag";
            this.lblFlag.Size = new System.Drawing.Size(114, 19);
            this.lblFlag.TabIndex = 11;
            this.lblFlag.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblFlag.Visible = false;
            // 
            // pnlDebug
            // 
            this.pnlDebug.AutoSize = true;
            this.pnlDebug.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDebug.Controls.Add(this.grpDebug);
            this.pnlDebug.Location = new System.Drawing.Point(430, 7);
            this.pnlDebug.Name = "pnlDebug";
            this.pnlDebug.Size = new System.Drawing.Size(138, 420);
            this.pnlDebug.TabIndex = 12;
            this.pnlDebug.Visible = false;
            // 
            // grpDebug
            // 
            this.grpDebug.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.grpDebug.Controls.Add(this.btnDebugPlaysound);
            this.grpDebug.Controls.Add(this.lblDebugafbschalter);
            this.grpDebug.Controls.Add(this.grpDebugoffline);
            this.grpDebug.Controls.Add(this.lblDebugreiseztrue);
            this.grpDebug.Controls.Add(this.lblDebugreisezwert);
            this.grpDebug.Controls.Add(this.lblDebugreisezug);
            this.grpDebug.Controls.Add(this.btnDebugFokusZusi);
            this.grpDebug.Controls.Add(this.label13);
            this.grpDebug.Controls.Add(this.label12);
            this.grpDebug.Controls.Add(this.tbVerz);
            this.grpDebug.Controls.Add(this.btnFlag);
            this.grpDebug.Location = new System.Drawing.Point(3, 4);
            this.grpDebug.Name = "grpDebug";
            this.grpDebug.Size = new System.Drawing.Size(132, 413);
            this.grpDebug.TabIndex = 12;
            this.grpDebug.TabStop = false;
            this.grpDebug.Text = "Debug";
            // 
            // lblDebugafbschalter
            // 
            this.lblDebugafbschalter.AutoSize = true;
            this.lblDebugafbschalter.Location = new System.Drawing.Point(9, 175);
            this.lblDebugafbschalter.Name = "lblDebugafbschalter";
            this.lblDebugafbschalter.Size = new System.Drawing.Size(102, 13);
            this.lblDebugafbschalter.TabIndex = 25;
            this.lblDebugafbschalter.Text = "AFBSchalterstellung";
            // 
            // grpDebugoffline
            // 
            this.grpDebugoffline.Controls.Add(this.numDebugsetspeed);
            this.grpDebugoffline.Controls.Add(this.label4);
            this.grpDebugoffline.Controls.Add(this.label5);
            this.grpDebugoffline.Location = new System.Drawing.Point(6, 100);
            this.grpDebugoffline.Name = "grpDebugoffline";
            this.grpDebugoffline.Size = new System.Drawing.Size(107, 68);
            this.grpDebugoffline.TabIndex = 20;
            this.grpDebugoffline.TabStop = false;
            this.grpDebugoffline.Text = "Offline";
            // 
            // numDebugsetspeed
            // 
            this.numDebugsetspeed.Location = new System.Drawing.Point(6, 37);
            this.numDebugsetspeed.Name = "numDebugsetspeed";
            this.numDebugsetspeed.Size = new System.Drawing.Size(49, 20);
            this.numDebugsetspeed.TabIndex = 25;
            this.numDebugsetspeed.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(3, 17);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 13);
            this.label4.TabIndex = 26;
            this.label4.Text = "Geschwindigkeit";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(62, 43);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 27;
            this.label5.Text = "km/h";
            // 
            // lblDebugreiseztrue
            // 
            this.lblDebugreiseztrue.AutoSize = true;
            this.lblDebugreiseztrue.Location = new System.Drawing.Point(3, 222);
            this.lblDebugreiseztrue.Name = "lblDebugreiseztrue";
            this.lblDebugreiseztrue.Size = new System.Drawing.Size(79, 13);
            this.lblDebugreiseztrue.TabIndex = 24;
            this.lblDebugreiseztrue.Text = "(reisezug true?)";
            // 
            // lblDebugreisezwert
            // 
            this.lblDebugreisezwert.AutoSize = true;
            this.lblDebugreisezwert.Location = new System.Drawing.Point(3, 238);
            this.lblDebugreisezwert.Name = "lblDebugreisezwert";
            this.lblDebugreisezwert.Size = new System.Drawing.Size(52, 13);
            this.lblDebugreisezwert.TabIndex = 23;
            this.lblDebugreisezwert.Text = "(reisezug)";
            // 
            // lblDebugreisezug
            // 
            this.lblDebugreisezug.AutoSize = true;
            this.lblDebugreisezug.Location = new System.Drawing.Point(3, 208);
            this.lblDebugreisezug.Name = "lblDebugreisezug";
            this.lblDebugreisezug.Size = new System.Drawing.Size(52, 13);
            this.lblDebugreisezug.TabIndex = 22;
            this.lblDebugreisezug.Text = "(reisezug)";
            // 
            // btnDebugFokusZusi
            // 
            this.btnDebugFokusZusi.Location = new System.Drawing.Point(6, 52);
            this.btnDebugFokusZusi.Name = "btnDebugFokusZusi";
            this.btnDebugFokusZusi.Size = new System.Drawing.Size(75, 23);
            this.btnDebugFokusZusi.TabIndex = 21;
            this.btnDebugFokusZusi.Text = "Zusi-Fokus";
            this.btnDebugFokusZusi.UseVisualStyleBackColor = true;
            this.btnDebugFokusZusi.Click += new System.EventHandler(this.btnDebugFokusZusi_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 266);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(92, 13);
            this.label13.TabIndex = 20;
            this.label13.Text = "max. Verzögerung";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(48, 289);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 13);
            this.label12.TabIndex = 19;
            this.label12.Text = "m/s²";
            // 
            // tbVerz
            // 
            this.tbVerz.Location = new System.Drawing.Point(6, 282);
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
            this.btnFlag.Text = "lblFlag";
            this.btnFlag.UseVisualStyleBackColor = true;
            this.btnFlag.Click += new System.EventHandler(this.btnFlag_Click);
            // 
            // pnlRight
            // 
            this.pnlRight.AutoSize = true;
            this.pnlRight.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlRight.Controls.Add(this.pnlSettings);
            this.pnlRight.Controls.Add(this.pnlDebug);
            this.pnlRight.Location = new System.Drawing.Point(149, 13);
            this.pnlRight.Name = "pnlRight";
            this.pnlRight.Size = new System.Drawing.Size(571, 458);
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
            this.btnNacht.AutoSize = true;
            this.btnNacht.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnNacht.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnNacht.Location = new System.Drawing.Point(3, 382);
            this.btnNacht.Name = "btnNacht";
            this.btnNacht.Size = new System.Drawing.Size(118, 23);
            this.btnNacht.TabIndex = 15;
            this.btnNacht.Text = "Nachtmodus";
            this.btnNacht.UseVisualStyleBackColor = true;
            this.btnNacht.Click += new System.EventHandler(this.btnNacht_Click);
            // 
            // lblm
            // 
            this.lblm.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblm.AutoSize = true;
            this.lblm.Location = new System.Drawing.Point(74, 24);
            this.lblm.Name = "lblm";
            this.lblm.Size = new System.Drawing.Size(21, 13);
            this.lblm.TabIndex = 5;
            this.lblm.Text = "km";
            // 
            // lblBrh
            // 
            this.lblBrh.AutoSize = true;
            this.lblBrh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblBrh.Location = new System.Drawing.Point(3, 0);
            this.lblBrh.Name = "lblBrh";
            this.lblBrh.Size = new System.Drawing.Size(45, 13);
            this.lblBrh.TabIndex = 7;
            this.lblBrh.Text = "888";
            // 
            // lblbremsh
            // 
            this.lblbremsh.AutoSize = true;
            this.lblbremsh.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblbremsh.Location = new System.Drawing.Point(54, 0);
            this.lblbremsh.Name = "lblbremsh";
            this.lblbremsh.Size = new System.Drawing.Size(37, 13);
            this.lblbremsh.TabIndex = 6;
            this.lblbremsh.Text = "BrH";
            // 
            // lblMeter
            // 
            this.lblMeter.AutoSize = true;
            this.lblMeter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblMeter.Location = new System.Drawing.Point(3, 24);
            this.lblMeter.Name = "lblMeter";
            this.lblMeter.Size = new System.Drawing.Size(65, 13);
            this.lblMeter.TabIndex = 3;
            this.lblMeter.Text = "888888,88";
            // 
            // lblkmh
            // 
            this.lblkmh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblkmh.AutoSize = true;
            this.lblkmh.Location = new System.Drawing.Point(74, 11);
            this.lblkmh.Name = "lblkmh";
            this.lblkmh.Size = new System.Drawing.Size(32, 13);
            this.lblkmh.TabIndex = 4;
            this.lblkmh.Text = "km/h";
            // 
            // lblV
            // 
            this.lblV.AutoSize = true;
            this.lblV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblV.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblV.Location = new System.Drawing.Point(3, 0);
            this.lblV.Name = "lblV";
            this.lblV.Size = new System.Drawing.Size(65, 24);
            this.lblV.TabIndex = 1;
            this.lblV.Text = "888,8";
            // 
            // pnlDataGrunddaten
            // 
            this.pnlDataGrunddaten.AutoSize = true;
            this.pnlDataGrunddaten.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDataGrunddaten.ColumnCount = 2;
            this.pnlDataGrunddaten.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlDataGrunddaten.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlDataGrunddaten.Controls.Add(this.lblFahrstufenschalter, 1, 3);
            this.pnlDataGrunddaten.Controls.Add(this.lblfahrstschalter, 0, 3);
            this.pnlDataGrunddaten.Controls.Add(this.lblfahrst, 0, 2);
            this.pnlDataGrunddaten.Controls.Add(this.lblFahrstufe, 1, 2);
            this.pnlDataGrunddaten.Controls.Add(this.lblV, 0, 0);
            this.pnlDataGrunddaten.Controls.Add(this.lblkmh, 1, 0);
            this.pnlDataGrunddaten.Controls.Add(this.lblMeter, 0, 1);
            this.pnlDataGrunddaten.Controls.Add(this.lblm, 1, 1);
            this.pnlDataGrunddaten.Controls.Add(this.lblTueren, 0, 4);
            this.pnlDataGrunddaten.Location = new System.Drawing.Point(3, 74);
            this.pnlDataGrunddaten.Name = "pnlDataGrunddaten";
            this.pnlDataGrunddaten.RowCount = 5;
            this.pnlDataGrunddaten.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataGrunddaten.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataGrunddaten.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataGrunddaten.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataGrunddaten.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataGrunddaten.Size = new System.Drawing.Size(109, 76);
            this.pnlDataGrunddaten.TabIndex = 16;
            // 
            // lblFahrstufenschalter
            // 
            this.lblFahrstufenschalter.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFahrstufenschalter.AutoSize = true;
            this.lblFahrstufenschalter.Location = new System.Drawing.Point(74, 50);
            this.lblFahrstufenschalter.Name = "lblFahrstufenschalter";
            this.lblFahrstufenschalter.Size = new System.Drawing.Size(19, 13);
            this.lblFahrstufenschalter.TabIndex = 10;
            this.lblFahrstufenschalter.Text = "88";
            this.lblFahrstufenschalter.Visible = false;
            // 
            // lblfahrstschalter
            // 
            this.lblfahrstschalter.AutoSize = true;
            this.lblfahrstschalter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblfahrstschalter.Location = new System.Drawing.Point(3, 50);
            this.lblfahrstschalter.Name = "lblfahrstschalter";
            this.lblfahrstschalter.Size = new System.Drawing.Size(65, 13);
            this.lblfahrstschalter.TabIndex = 9;
            this.lblfahrstschalter.Text = "Fahrschalter";
            this.lblfahrstschalter.Visible = false;
            // 
            // lblfahrst
            // 
            this.lblfahrst.AutoSize = true;
            this.lblfahrst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblfahrst.Location = new System.Drawing.Point(3, 37);
            this.lblfahrst.Name = "lblfahrst";
            this.lblfahrst.Size = new System.Drawing.Size(65, 13);
            this.lblfahrst.TabIndex = 7;
            this.lblfahrst.Text = "Fahrstufe";
            // 
            // lblFahrstufe
            // 
            this.lblFahrstufe.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.lblFahrstufe.AutoSize = true;
            this.lblFahrstufe.Location = new System.Drawing.Point(74, 37);
            this.lblFahrstufe.Name = "lblFahrstufe";
            this.lblFahrstufe.Size = new System.Drawing.Size(19, 13);
            this.lblFahrstufe.TabIndex = 6;
            this.lblFahrstufe.Text = "88";
            // 
            // lblTueren
            // 
            this.lblTueren.AutoSize = true;
            this.pnlDataGrunddaten.SetColumnSpan(this.lblTueren, 2);
            this.lblTueren.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblTueren.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTueren.Location = new System.Drawing.Point(3, 63);
            this.lblTueren.Name = "lblTueren";
            this.lblTueren.Size = new System.Drawing.Size(103, 13);
            this.lblTueren.TabIndex = 8;
            this.lblTueren.Text = "########";
            // 
            // pnlDataBremsen
            // 
            this.pnlDataBremsen.AutoSize = true;
            this.pnlDataBremsen.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDataBremsen.ColumnCount = 2;
            this.pnlDataBremsen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlDataBremsen.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlDataBremsen.Controls.Add(this.lblBrh, 0, 0);
            this.pnlDataBremsen.Controls.Add(this.lblbarbz, 1, 2);
            this.pnlDataBremsen.Controls.Add(this.lblbremsh, 1, 0);
            this.pnlDataBremsen.Controls.Add(this.lblHlldruck, 0, 1);
            this.pnlDataBremsen.Controls.Add(this.lblbarhll, 1, 1);
            this.pnlDataBremsen.Controls.Add(this.lblBzdruck, 0, 2);
            this.pnlDataBremsen.Controls.Add(this.lblfbv, 0, 3);
            this.pnlDataBremsen.Controls.Add(this.lbldynbrem, 0, 4);
            this.pnlDataBremsen.Controls.Add(this.lblzusbr, 0, 5);
            this.pnlDataBremsen.Controls.Add(this.lblFbventil, 1, 3);
            this.pnlDataBremsen.Controls.Add(this.lblDynbremse, 1, 4);
            this.pnlDataBremsen.Controls.Add(this.lblZusbremse, 1, 5);
            this.pnlDataBremsen.Location = new System.Drawing.Point(3, 227);
            this.pnlDataBremsen.Name = "pnlDataBremsen";
            this.pnlDataBremsen.RowCount = 6;
            this.pnlDataBremsen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataBremsen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataBremsen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataBremsen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataBremsen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataBremsen.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataBremsen.Size = new System.Drawing.Size(94, 78);
            this.pnlDataBremsen.TabIndex = 17;
            // 
            // lblfbv
            // 
            this.lblfbv.AutoSize = true;
            this.lblfbv.Location = new System.Drawing.Point(3, 39);
            this.lblfbv.Name = "lblfbv";
            this.lblfbv.Size = new System.Drawing.Size(26, 13);
            this.lblfbv.TabIndex = 12;
            this.lblfbv.Text = "FbV";
            this.lblfbv.Visible = false;
            // 
            // lbldynbrem
            // 
            this.lbldynbrem.AutoSize = true;
            this.lbldynbrem.Location = new System.Drawing.Point(3, 52);
            this.lbldynbrem.Name = "lbldynbrem";
            this.lbldynbrem.Size = new System.Drawing.Size(45, 13);
            this.lbldynbrem.TabIndex = 13;
            this.lbldynbrem.Text = "Dyn. Br.";
            this.lbldynbrem.Visible = false;
            // 
            // lblzusbr
            // 
            this.lblzusbr.AutoSize = true;
            this.lblzusbr.Location = new System.Drawing.Point(3, 65);
            this.lblzusbr.Name = "lblzusbr";
            this.lblzusbr.Size = new System.Drawing.Size(43, 13);
            this.lblzusbr.TabIndex = 14;
            this.lblzusbr.Text = "Zus. br.";
            this.lblzusbr.Visible = false;
            // 
            // lblFbventil
            // 
            this.lblFbventil.AutoSize = true;
            this.lblFbventil.Location = new System.Drawing.Point(54, 39);
            this.lblFbventil.Name = "lblFbventil";
            this.lblFbventil.Size = new System.Drawing.Size(13, 13);
            this.lblFbventil.TabIndex = 15;
            this.lblFbventil.Text = "0";
            this.lblFbventil.Visible = false;
            // 
            // lblDynbremse
            // 
            this.lblDynbremse.AutoSize = true;
            this.lblDynbremse.Location = new System.Drawing.Point(54, 52);
            this.lblDynbremse.Name = "lblDynbremse";
            this.lblDynbremse.Size = new System.Drawing.Size(13, 13);
            this.lblDynbremse.TabIndex = 16;
            this.lblDynbremse.Text = "0";
            this.lblDynbremse.Visible = false;
            // 
            // lblZusbremse
            // 
            this.lblZusbremse.AutoSize = true;
            this.lblZusbremse.Location = new System.Drawing.Point(54, 65);
            this.lblZusbremse.Name = "lblZusbremse";
            this.lblZusbremse.Size = new System.Drawing.Size(13, 13);
            this.lblZusbremse.TabIndex = 17;
            this.lblZusbremse.Text = "0";
            this.lblZusbremse.Visible = false;
            // 
            // pnlDataAFBLZB
            // 
            this.pnlDataAFBLZB.AutoSize = true;
            this.pnlDataAFBLZB.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlDataAFBLZB.ColumnCount = 2;
            this.pnlDataAFBLZB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlDataAFBLZB.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlDataAFBLZB.Controls.Add(this.lblAFBvorwahl, 1, 0);
            this.pnlDataAFBLZB.Controls.Add(this.lblafbvorw, 0, 0);
            this.pnlDataAFBLZB.Controls.Add(this.lblafbeinaus, 0, 1);
            this.pnlDataAFBLZB.Controls.Add(this.lbllzbvsoll, 0, 2);
            this.pnlDataAFBLZB.Controls.Add(this.lbllzbvziel, 0, 3);
            this.pnlDataAFBLZB.Controls.Add(this.lbllzbzielw, 0, 4);
            this.pnlDataAFBLZB.Controls.Add(this.lblAFBgeschwindigkeit, 1, 1);
            this.pnlDataAFBLZB.Controls.Add(this.lblLZBsollgeschw, 1, 2);
            this.pnlDataAFBLZB.Controls.Add(this.lblLZBzielgeschw, 1, 3);
            this.pnlDataAFBLZB.Controls.Add(this.lblLZBzielweg, 1, 4);
            this.pnlDataAFBLZB.Location = new System.Drawing.Point(3, 311);
            this.pnlDataAFBLZB.Name = "pnlDataAFBLZB";
            this.pnlDataAFBLZB.RowCount = 5;
            this.pnlDataAFBLZB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataAFBLZB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataAFBLZB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataAFBLZB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataAFBLZB.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlDataAFBLZB.Size = new System.Drawing.Size(114, 65);
            this.pnlDataAFBLZB.TabIndex = 18;
            // 
            // lblAFBvorwahl
            // 
            this.lblAFBvorwahl.AutoSize = true;
            this.lblAFBvorwahl.Location = new System.Drawing.Point(80, 0);
            this.lblAFBvorwahl.Name = "lblAFBvorwahl";
            this.lblAFBvorwahl.Size = new System.Drawing.Size(25, 13);
            this.lblAFBvorwahl.TabIndex = 9;
            this.lblAFBvorwahl.Text = "888";
            this.lblAFBvorwahl.Visible = false;
            // 
            // lblafbvorw
            // 
            this.lblafbvorw.AutoSize = true;
            this.lblafbvorw.Location = new System.Drawing.Point(3, 0);
            this.lblafbvorw.Name = "lblafbvorw";
            this.lblafbvorw.Size = new System.Drawing.Size(71, 13);
            this.lblafbvorw.TabIndex = 8;
            this.lblafbvorw.Text = "AFB Vorwahl:";
            this.lblafbvorw.Visible = false;
            // 
            // lblafbeinaus
            // 
            this.lblafbeinaus.AutoSize = true;
            this.lblafbeinaus.Location = new System.Drawing.Point(3, 13);
            this.lblafbeinaus.Name = "lblafbeinaus";
            this.lblafbeinaus.Size = new System.Drawing.Size(47, 13);
            this.lblafbeinaus.TabIndex = 0;
            this.lblafbeinaus.Text = "AFB aus";
            // 
            // lbllzbvsoll
            // 
            this.lbllzbvsoll.AutoSize = true;
            this.lbllzbvsoll.Location = new System.Drawing.Point(3, 26);
            this.lbllzbvsoll.Name = "lbllzbvsoll";
            this.lbllzbvsoll.Size = new System.Drawing.Size(53, 13);
            this.lbllzbvsoll.TabIndex = 1;
            this.lbllzbvsoll.Text = "LZB vSoll";
            this.lbllzbvsoll.Visible = false;
            // 
            // lbllzbvziel
            // 
            this.lbllzbvziel.AutoSize = true;
            this.lbllzbvziel.Location = new System.Drawing.Point(3, 39);
            this.lbllzbvziel.Name = "lbllzbvziel";
            this.lbllzbvziel.Size = new System.Drawing.Size(53, 13);
            this.lbllzbvziel.TabIndex = 2;
            this.lbllzbvziel.Text = "LZB vZiel";
            this.lbllzbvziel.Visible = false;
            // 
            // lbllzbzielw
            // 
            this.lbllzbzielw.AutoSize = true;
            this.lbllzbzielw.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbllzbzielw.Location = new System.Drawing.Point(3, 52);
            this.lbllzbzielw.Name = "lbllzbzielw";
            this.lbllzbzielw.Size = new System.Drawing.Size(44, 13);
            this.lbllzbzielw.TabIndex = 3;
            this.lbllzbzielw.Text = "Zielweg";
            this.lbllzbzielw.Visible = false;
            // 
            // lblAFBgeschwindigkeit
            // 
            this.lblAFBgeschwindigkeit.AutoSize = true;
            this.lblAFBgeschwindigkeit.Location = new System.Drawing.Point(80, 13);
            this.lblAFBgeschwindigkeit.Name = "lblAFBgeschwindigkeit";
            this.lblAFBgeschwindigkeit.Size = new System.Drawing.Size(25, 13);
            this.lblAFBgeschwindigkeit.TabIndex = 4;
            this.lblAFBgeschwindigkeit.Text = "888";
            // 
            // lblLZBsollgeschw
            // 
            this.lblLZBsollgeschw.AutoSize = true;
            this.lblLZBsollgeschw.Location = new System.Drawing.Point(80, 26);
            this.lblLZBsollgeschw.Name = "lblLZBsollgeschw";
            this.lblLZBsollgeschw.Size = new System.Drawing.Size(25, 13);
            this.lblLZBsollgeschw.TabIndex = 5;
            this.lblLZBsollgeschw.Text = "888";
            this.lblLZBsollgeschw.Visible = false;
            // 
            // lblLZBzielgeschw
            // 
            this.lblLZBzielgeschw.AutoSize = true;
            this.lblLZBzielgeschw.Location = new System.Drawing.Point(80, 39);
            this.lblLZBzielgeschw.Name = "lblLZBzielgeschw";
            this.lblLZBzielgeschw.Size = new System.Drawing.Size(25, 13);
            this.lblLZBzielgeschw.TabIndex = 6;
            this.lblLZBzielgeschw.Text = "888";
            this.lblLZBzielgeschw.Visible = false;
            // 
            // lblLZBzielweg
            // 
            this.lblLZBzielweg.AutoSize = true;
            this.lblLZBzielweg.Location = new System.Drawing.Point(80, 52);
            this.lblLZBzielweg.Name = "lblLZBzielweg";
            this.lblLZBzielweg.Size = new System.Drawing.Size(31, 13);
            this.lblLZBzielweg.TabIndex = 7;
            this.lblLZBzielweg.Text = "8888";
            this.lblLZBzielweg.Visible = false;
            // 
            // pnlLeft
            // 
            this.pnlLeft.AutoSize = true;
            this.pnlLeft.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.pnlLeft.ColumnCount = 1;
            this.pnlLeft.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.pnlLeft.Controls.Add(this.btnRailrunner, 0, 7);
            this.pnlLeft.Controls.Add(this.pnlDataPZB90, 0, 3);
            this.pnlLeft.Controls.Add(this.lblSifa, 0, 0);
            this.pnlLeft.Controls.Add(this.pnlDataBremsen, 0, 4);
            this.pnlLeft.Controls.Add(this.pnlDataAFBLZB, 0, 5);
            this.pnlLeft.Controls.Add(this.lblFlag, 0, 1);
            this.pnlLeft.Controls.Add(this.pnlDataGrunddaten, 0, 2);
            this.pnlLeft.Controls.Add(this.btnSettings, 0, 8);
            this.pnlLeft.Controls.Add(this.btnNacht, 0, 6);
            this.pnlLeft.Location = new System.Drawing.Point(2, 13);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.RowCount = 9;
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.pnlLeft.Size = new System.Drawing.Size(124, 470);
            this.pnlLeft.TabIndex = 19;
            // 
            // btnRailrunner
            // 
            this.btnRailrunner.AutoSize = true;
            this.btnRailrunner.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.btnRailrunner.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnRailrunner.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRailrunner.Location = new System.Drawing.Point(3, 411);
            this.btnRailrunner.Name = "btnRailrunner";
            this.btnRailrunner.Size = new System.Drawing.Size(118, 25);
            this.btnRailrunner.TabIndex = 21;
            this.btnRailrunner.Text = "Wegmessung";
            this.btnRailrunner.UseVisualStyleBackColor = true;
            this.btnRailrunner.Click += new System.EventHandler(this.btnRailrunner_Click);
            // 
            // pnlDataPZB90
            // 
            this.pnlDataPZB90.BackColor = System.Drawing.SystemColors.Control;
            this.pnlDataPZB90.CellBorderStyle = System.Windows.Forms.TableLayoutPanelCellBorderStyle.Single;
            this.pnlDataPZB90.ColumnCount = 3;
            this.pnlDataPZB90.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlDataPZB90.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlDataPZB90.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.pnlDataPZB90.Controls.Add(this.lblPZB_1000, 2, 1);
            this.pnlDataPZB90.Controls.Add(this.lblPZB_500, 1, 1);
            this.pnlDataPZB90.Controls.Add(this.lblPZB_Bef, 0, 1);
            this.pnlDataPZB90.Controls.Add(this.lblPZB_U, 0, 0);
            this.pnlDataPZB90.Controls.Add(this.lblPZB_M, 1, 0);
            this.pnlDataPZB90.Controls.Add(this.lblPZB_O, 2, 0);
            this.pnlDataPZB90.Location = new System.Drawing.Point(3, 156);
            this.pnlDataPZB90.Name = "pnlDataPZB90";
            this.pnlDataPZB90.RowCount = 2;
            this.pnlDataPZB90.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlDataPZB90.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.pnlDataPZB90.Size = new System.Drawing.Size(118, 65);
            this.pnlDataPZB90.TabIndex = 20;
            // 
            // lblPZB_1000
            // 
            this.lblPZB_1000.BackColor = System.Drawing.Color.Transparent;
            this.lblPZB_1000.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPZB_1000.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPZB_1000.Location = new System.Drawing.Point(79, 33);
            this.lblPZB_1000.Margin = new System.Windows.Forms.Padding(0);
            this.lblPZB_1000.Name = "lblPZB_1000";
            this.lblPZB_1000.Size = new System.Drawing.Size(38, 31);
            this.lblPZB_1000.TabIndex = 28;
            this.lblPZB_1000.Text = "1000";
            this.lblPZB_1000.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPZB_500
            // 
            this.lblPZB_500.BackColor = System.Drawing.Color.Transparent;
            this.lblPZB_500.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPZB_500.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPZB_500.Location = new System.Drawing.Point(40, 33);
            this.lblPZB_500.Margin = new System.Windows.Forms.Padding(0);
            this.lblPZB_500.Name = "lblPZB_500";
            this.lblPZB_500.Size = new System.Drawing.Size(38, 31);
            this.lblPZB_500.TabIndex = 29;
            this.lblPZB_500.Text = "500";
            this.lblPZB_500.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPZB_Bef
            // 
            this.lblPZB_Bef.BackColor = System.Drawing.Color.Transparent;
            this.lblPZB_Bef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPZB_Bef.Font = new System.Drawing.Font("Microsoft Sans Serif", 5F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPZB_Bef.Location = new System.Drawing.Point(1, 33);
            this.lblPZB_Bef.Margin = new System.Windows.Forms.Padding(0);
            this.lblPZB_Bef.Name = "lblPZB_Bef";
            this.lblPZB_Bef.Size = new System.Drawing.Size(38, 31);
            this.lblPZB_Bef.TabIndex = 30;
            this.lblPZB_Bef.Text = "Befehl";
            this.lblPZB_Bef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPZB_U
            // 
            this.lblPZB_U.BackColor = System.Drawing.Color.Transparent;
            this.lblPZB_U.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPZB_U.Location = new System.Drawing.Point(1, 1);
            this.lblPZB_U.Margin = new System.Windows.Forms.Padding(0);
            this.lblPZB_U.Name = "lblPZB_U";
            this.lblPZB_U.Size = new System.Drawing.Size(38, 31);
            this.lblPZB_U.TabIndex = 25;
            this.lblPZB_U.Text = "U";
            this.lblPZB_U.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPZB_M
            // 
            this.lblPZB_M.BackColor = System.Drawing.Color.Transparent;
            this.lblPZB_M.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPZB_M.Location = new System.Drawing.Point(40, 1);
            this.lblPZB_M.Margin = new System.Windows.Forms.Padding(0);
            this.lblPZB_M.Name = "lblPZB_M";
            this.lblPZB_M.Size = new System.Drawing.Size(38, 31);
            this.lblPZB_M.TabIndex = 27;
            this.lblPZB_M.Text = "M";
            this.lblPZB_M.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblPZB_O
            // 
            this.lblPZB_O.BackColor = System.Drawing.Color.Transparent;
            this.lblPZB_O.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lblPZB_O.Location = new System.Drawing.Point(79, 1);
            this.lblPZB_O.Margin = new System.Windows.Forms.Padding(0);
            this.lblPZB_O.Name = "lblPZB_O";
            this.lblPZB_O.Size = new System.Drawing.Size(38, 31);
            this.lblPZB_O.TabIndex = 26;
            this.lblPZB_O.Text = "O";
            this.lblPZB_O.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer100
            // 
            this.timer100.Tick += new System.EventHandler(this.timer100_Tick);
            // 
            // timerRailrunner
            // 
            this.timerRailrunner.Tick += new System.EventHandler(this.timerRailrunner_Tick);
            // 
            // cbRRcountup
            // 
            this.cbRRcountup.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRRcountup.AutoSize = true;
            this.cbRRcountup.BackColor = System.Drawing.Color.Transparent;
            this.cbRRcountup.Enabled = false;
            this.cbRRcountup.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.cbRRcountup.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRRcountup.Location = new System.Drawing.Point(114, 23);
            this.cbRRcountup.Name = "cbRRcountup";
            this.cbRRcountup.Size = new System.Drawing.Size(23, 23);
            this.cbRRcountup.TabIndex = 20;
            this.cbRRcountup.Text = "˄";
            this.cbRRcountup.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRRcountup.UseVisualStyleBackColor = false;
            this.cbRRcountup.CheckedChanged += new System.EventHandler(this.cbRRcountup_CheckedChanged);
            // 
            // cbRRcountdown
            // 
            this.cbRRcountdown.Appearance = System.Windows.Forms.Appearance.Button;
            this.cbRRcountdown.AutoSize = true;
            this.cbRRcountdown.BackColor = System.Drawing.Color.Transparent;
            this.cbRRcountdown.Checked = true;
            this.cbRRcountdown.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRRcountdown.Enabled = false;
            this.cbRRcountdown.FlatAppearance.CheckedBackColor = System.Drawing.Color.LightSlateGray;
            this.cbRRcountdown.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbRRcountdown.Location = new System.Drawing.Point(93, 23);
            this.cbRRcountdown.Name = "cbRRcountdown";
            this.cbRRcountdown.Size = new System.Drawing.Size(23, 23);
            this.cbRRcountdown.TabIndex = 21;
            this.cbRRcountdown.Text = "˅";
            this.cbRRcountdown.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.cbRRcountdown.UseVisualStyleBackColor = false;
            this.cbRRcountdown.CheckedChanged += new System.EventHandler(this.cbRRcountdown_CheckedChanged);
            // 
            // cbRRSound
            // 
            this.cbRRSound.AutoSize = true;
            this.cbRRSound.Checked = true;
            this.cbRRSound.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRRSound.Enabled = false;
            this.cbRRSound.Location = new System.Drawing.Point(4, 23);
            this.cbRRSound.Name = "cbRRSound";
            this.cbRRSound.Size = new System.Drawing.Size(62, 17);
            this.cbRRSound.TabIndex = 37;
            this.cbRRSound.Text = "Ton ein";
            this.cbRRSound.UseVisualStyleBackColor = true;
            // 
            // btnDebugPlaysound
            // 
            this.btnDebugPlaysound.Location = new System.Drawing.Point(9, 315);
            this.btnDebugPlaysound.Name = "btnDebugPlaysound";
            this.btnDebugPlaysound.Size = new System.Drawing.Size(75, 23);
            this.btnDebugPlaysound.TabIndex = 26;
            this.btnDebugPlaysound.Text = "Sound";
            this.btnDebugPlaysound.UseVisualStyleBackColor = true;
            this.btnDebugPlaysound.Click += new System.EventHandler(this.btnDebugPlaysound_Click);
            // 
            // cbRRautoreset
            // 
            this.cbRRautoreset.AutoSize = true;
            this.cbRRautoreset.Checked = true;
            this.cbRRautoreset.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbRRautoreset.Enabled = false;
            this.cbRRautoreset.Location = new System.Drawing.Point(3, 46);
            this.cbRRautoreset.Name = "cbRRautoreset";
            this.cbRRautoreset.Size = new System.Drawing.Size(139, 17);
            this.cbRRautoreset.TabIndex = 38;
            this.cbRRautoreset.Text = "Automatisch rücksetzen";
            this.cbRRautoreset.UseVisualStyleBackColor = true;
            // 
            // CMainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1003, 480);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.pnlRight);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "CMainWindow";
            this.Text = "ZusiMeter - v0.4";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.CMainWindow_Load);
            this.pnlSettings.ResumeLayout(false);
            this.tabEinstellungen.ResumeLayout(false);
            this.tabAnzeigen1.ResumeLayout(false);
            this.tabAnzeigen1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeAFBLZB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeBremsen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSizeGrunddaten)).EndInit();
            this.pnlRailrunner.ResumeLayout(false);
            this.pnlRailrunner.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numRRfest)).EndInit();
            this.pnlAFBLZB.ResumeLayout(false);
            this.pnlAFBLZB.PerformLayout();
            this.pnlGrunddaten.ResumeLayout(false);
            this.pnlGrunddaten.PerformLayout();
            this.pnlBremsen.ResumeLayout(false);
            this.pnlBremsen.PerformLayout();
            this.pnlSchalterst.ResumeLayout(false);
            this.pnlSchalterst.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numFahrschneutral)).EndInit();
            this.tabDarstellung.ResumeLayout(false);
            this.tabDarstellung.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSifagroesse)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tabSystem.ResumeLayout(false);
            this.grpVerbindung.ResumeLayout(false);
            this.grpVerbindung.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.pnlDebug.ResumeLayout(false);
            this.grpDebug.ResumeLayout(false);
            this.grpDebug.PerformLayout();
            this.grpDebugoffline.ResumeLayout(false);
            this.grpDebugoffline.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numDebugsetspeed)).EndInit();
            this.pnlRight.ResumeLayout(false);
            this.pnlRight.PerformLayout();
            this.pnlDataGrunddaten.ResumeLayout(false);
            this.pnlDataGrunddaten.PerformLayout();
            this.pnlDataBremsen.ResumeLayout(false);
            this.pnlDataBremsen.PerformLayout();
            this.pnlDataAFBLZB.ResumeLayout(false);
            this.pnlDataAFBLZB.PerformLayout();
            this.pnlLeft.ResumeLayout(false);
            this.pnlLeft.PerformLayout();
            this.pnlDataPZB90.ResumeLayout(false);
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
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox tbVerz;
        private System.Windows.Forms.Button btnFlag;
        private System.Windows.Forms.Button btnDebugpanel;
        private System.Windows.Forms.Panel pnlRight;
        private System.Windows.Forms.Timer timerFlag;
        private System.Windows.Forms.Button btnNacht;
        private System.Windows.Forms.Label lblbarhll;
        private System.Windows.Forms.Label lblHlldruck;
        private System.Windows.Forms.Label lblbarbz;
        private System.Windows.Forms.Label lblBzdruck;
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
        private System.Windows.Forms.TableLayoutPanel pnlDataGrunddaten;
        private System.Windows.Forms.TabControl tabEinstellungen;
        private System.Windows.Forms.TabPage tabAnzeigen1;
        private System.Windows.Forms.TabPage tabDarstellung;
        private System.Windows.Forms.TabPage tabSystem;
        private System.Windows.Forms.CheckBox cbLmsifa;
        private System.Windows.Forms.CheckBox cbLmschleudern;
        private System.Windows.Forms.CheckBox cbTueren;
        private System.Windows.Forms.CheckBox cbFahrstufe;
        private System.Windows.Forms.CheckBox cbUhrzeit;
        private System.Windows.Forms.TableLayoutPanel pnlDataBremsen;
        private System.Windows.Forms.Label lblFahrstufe;
        private System.Windows.Forms.CheckBox cbGrunddaten;
        private System.Windows.Forms.CheckBox cbBremsen;
        private System.Windows.Forms.Label lblTueren;
        private System.Windows.Forms.Panel pnlBremsen;
        private System.Windows.Forms.Panel pnlGrunddaten;
        private System.Windows.Forms.CheckBox cbFahrstufenschalter;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel lblVerbstatus;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rbDarstMeter;
        private System.Windows.Forms.RadioButton rbDarstKm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.NumericUpDown numSifagroesse;
        private System.Windows.Forms.CheckBox cbTopmost;
        private System.Windows.Forms.CheckBox cbFokusImmerzurueck;
        private System.Windows.Forms.NumericUpDown numFahrschneutral;
        private System.Windows.Forms.Label lblFahrschneutralbei;
        private System.Windows.Forms.Panel pnlSchalterst;
        private System.Windows.Forms.CheckBox cbZusbremse;
        private System.Windows.Forms.CheckBox cbDynbremse;
        private System.Windows.Forms.CheckBox cbFbv;
        private System.Windows.Forms.CheckBox cbSchalterst;
        private System.Windows.Forms.CheckBox cbDruckhbl;
        private System.Windows.Forms.CheckBox cbDruckhlb;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox cbMotorsch;
        private System.Windows.Forms.CheckBox cbFahrtrichtg;
        private System.Windows.Forms.CheckBox cbSchleuderschutz;
        private System.Windows.Forms.CheckBox cbHauptsch;
        private System.Windows.Forms.Label lblfahrst;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Button btnFarbeTag;
        private System.Windows.Forms.Button btnFarbeNacht;
        private System.Windows.Forms.Panel pnlAFBLZB;
        private System.Windows.Forms.CheckBox cbAFBLZB;
        private System.Windows.Forms.TableLayoutPanel pnlDataAFBLZB;
        private System.Windows.Forms.Label lblafbeinaus;
        private System.Windows.Forms.Label lbllzbvsoll;
        private System.Windows.Forms.Label lbllzbvziel;
        private System.Windows.Forms.Label lbllzbzielw;
        private System.Windows.Forms.Label lblAFBgeschwindigkeit;
        private System.Windows.Forms.Label lblLZBsollgeschw;
        private System.Windows.Forms.Label lblLZBzielgeschw;
        private System.Windows.Forms.Label lblLZBzielweg;
        private System.Windows.Forms.TableLayoutPanel pnlLeft;
        private System.Windows.Forms.CheckBox cbLZBvziel;
        private System.Windows.Forms.CheckBox cbLZBweg;
        private System.Windows.Forms.CheckBox cbLZBvsoll;
        private System.Windows.Forms.CheckBox cbAFBgeschw;
        private System.Windows.Forms.Label lblfbv;
        private System.Windows.Forms.Label lbldynbrem;
        private System.Windows.Forms.Label lblzusbr;
        private System.Windows.Forms.Label lblFbventil;
        private System.Windows.Forms.Label lblDynbremse;
        private System.Windows.Forms.Label lblZusbremse;
        private System.Windows.Forms.Button btnDebugFokusZusi;
        private System.Windows.Forms.CheckBox cbFokusFahrtzurueck;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label lblDebugreisezug;
        private System.Windows.Forms.Label lblDebugreisezwert;
        private System.Windows.Forms.Label lblDebugreiseztrue;
        private System.Windows.Forms.Timer timer100;
        private System.Windows.Forms.Label lblPZB_Bef;
        private System.Windows.Forms.Label lblPZB_500;
        private System.Windows.Forms.Label lblPZB_1000;
        private System.Windows.Forms.Label lblPZB_M;
        private System.Windows.Forms.Label lblPZB_O;
        private System.Windows.Forms.Label lblPZB_U;
        private System.Windows.Forms.TableLayoutPanel pnlDataPZB90;
        private System.Windows.Forms.CheckBox cbPZBLM;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.NumericUpDown numDebugsetspeed;
        private System.Windows.Forms.Timer timerRailrunner;
        private System.Windows.Forms.GroupBox grpDebugoffline;
        private System.Windows.Forms.Button btnRailrunner;
        private System.Windows.Forms.Panel pnlRailrunner;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.CheckBox cbRailrunner;
        private System.Windows.Forms.RadioButton rbRRfest;
        private System.Windows.Forms.NumericUpDown numRRfest;
        private System.Windows.Forms.RadioButton rbRRfrei;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.NumericUpDown numSizeAFBLZB;
        private System.Windows.Forms.Label lblFahrstufenschalter;
        private System.Windows.Forms.Label lblfahrstschalter;
        private System.Windows.Forms.NumericUpDown numSizeBremsen;
        private System.Windows.Forms.NumericUpDown numSizeGrunddaten;
        private System.Windows.Forms.Label lblDebugafbschalter;
        private System.Windows.Forms.CheckBox cbAFBvor5;
        private System.Windows.Forms.CheckBox cbAFBVorwahl;
        private System.Windows.Forms.CheckBox cbAFBvor10;
        private System.Windows.Forms.Label lblAFBvorwahl;
        private System.Windows.Forms.Label lblafbvorw;
        private System.Windows.Forms.CheckBox cbRRcountup;
        private System.Windows.Forms.CheckBox cbRRcountdown;
        private System.Windows.Forms.CheckBox cbRRSound;
        private System.Windows.Forms.Button btnDebugPlaysound;
        private System.Windows.Forms.CheckBox cbRRautoreset;

    }


}

