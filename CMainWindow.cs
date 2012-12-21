using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection; //for usage of assembly data
using System.Diagnostics; // usage of stopwatch
using Zusi_Datenausgabe; //TODO: v1.0.0
using System.Runtime.InteropServices; //to hand over the focus to Zusi main window
using System.Media; //for sound playback

namespace ZusiMeter
{
    public partial class CMainWindow : Form
    {
        

        // We do want to have a ZusiTcpConn object, so here's the declaration
        private ZusiTcpConn MyTCPConnection;

        // Initalize a new stopwatch
        Stopwatch stopwatch = new Stopwatch();
           
        //Declare external methods
        //for usage of the 'focus back to Zusi' feature
        [DllImport("User32.dll")]
        static extern long SetForegroundWindow(int hwnd);
        
        [DllImport("user32.dll")]
        extern static Boolean SetForegroundWindow(IntPtr Fenster);

        [DllImport("user32.dll", SetLastError = true)]
        static extern IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll")]
        extern static IntPtr SetActiveWindow(IntPtr Fenster);


        public CMainWindow()
        {
            InitializeComponent();

            //we need to define a new connection to the TCP server:
            MyTCPConnection = new ZusiTcpConn(
             "ZusiMeter - v" + Assembly.GetExecutingAssembly().GetName().Version.ToString(), // Name and version, showing up in server's list
             ClientPriority.Low);

            MyTCPConnection.ErrorReceived += TCPConnection_ErrorReceived;
            MyTCPConnection.FloatReceived += TCPConnection_FloatReceived;            
            MyTCPConnection.BoolReceived += TCPConnection_BoolReceived;
            //MyTCPConnection.IntReceived += TCPConnection_IntReceived;
            //MyTCPConnection.StringReceived += TCPConnection_StringReceived;
            MyTCPConnection.DateTimeReceived += TCPConnection_DateTimeReceived;
            //MyTCPConnection.BrakeConfigReceived += TCPConnection_BrakeConfigReceived;
            //MyTCPConnection.DoorsReceived += TCPConnection_DoorsReceived;
            //MyTCPConnection.PZBReceived += TCPConnection_PZBReceived;


            #region RequestData
            MyTCPConnection.RequestData(2561); // "Geschwindigkeit"

            MyTCPConnection.RequestData(2654); // "Bremshundertstel"
            MyTCPConnection.RequestData(2562); // "Druck Hauptluftleitung"
            MyTCPConnection.RequestData(2563); // "Druck Bremszylinder"
            MyTCPConnection.RequestData(2564); // "Druck Hauptluftbehälter"
            MyTCPConnection.RequestData(2579); // "Druck Hilfsluftbehälter"

            MyTCPConnection.RequestData(2645); // "Strecken-Km in Metern"

            MyTCPConnection.RequestData(2611); // "Schalter Fahrstufen"
            MyTCPConnection.RequestData(2576); // "Fahrstufe"
            MyTCPConnection.RequestData(2615); // "Schalter AFB-Geschwindigkeit"
            MyTCPConnection.RequestData(2612); // "Schalter Führerbremsventil"
            
            MyTCPConnection.RequestData(2599); // "LM Schleudern"     
            MyTCPConnection.RequestData(2596); // "LM Sifa"

            MyTCPConnection.RequestData(2616); // "Schalter AFB ein/aus"

            MyTCPConnection.RequestData(2648); // "Reisezug" 
            MyTCPConnection.RequestData(2647); // "Autopilot"

            MyTCPConnection.RequestData(2610); // "LM Uhrzeit (digital)"
            
            
            //MyTCPConnection.RequestData(2646); // "Türen"
            ////TODO MyTCPConnection.RequestData(2656); // "Zugdatei"
           
            //MyTCPConnection.RequestData(2574); // "LZB/AFB Soll-Geschwindigkeit"
           
            //MyTCPConnection.RequestData(2578); // "AFB Soll-Geschwindigkeit"
            //MyTCPConnection.RequestData(2636); // "LZB Soll-Geschwindigkeit"
            //MyTCPConnection.RequestData(2573); // "LZB Ziel-Geschwindigkeit"
            //MyTCPConnection.RequestData(2635); // "LM LZB-Zielweg (ab 0)"   
           
            ////###PZB-90###//
            //MyTCPConnection.RequestData(2583); // "LM PZB Zugart U"
            //MyTCPConnection.RequestData(2584); // "LM PZB Zugart M"
            //MyTCPConnection.RequestData(2585); // "LM PZB Zugart O"
            //MyTCPConnection.RequestData(2580); // "LM PZB 1000Hz"
            //MyTCPConnection.RequestData(2581); // "LM PZB 500Hz"
            //MyTCPConnection.RequestData(2582); // "LM PZB Befehl"
            ////###//
            ////###LZB###//
            //MyTCPConnection.RequestData(2587); // "LM LZB G"
            //MyTCPConnection.RequestData(2590); // "LM LZB Ende"
            //MyTCPConnection.RequestData(2592); // "LM LZB B"
            //MyTCPConnection.RequestData(2593); // "LM LZB S "
            //MyTCPConnection.RequestData(2594); // "LM LZB Ü"
            //MyTCPConnection.RequestData(2595); // "LM LZB Prüfen"
            ////###//
            //MyTCPConnection.RequestData(2615); // "Schalter AFB-Geschwindigkeit"
            ////###Uhrzeit###//
            ////MyTCPConnection.RequestData(2570); // "Uhrzeit Stunde"
            ////MyTCPConnection.RequestData(2571); // "Uhrzeit Minute"
            ////MyTCPConnection.RequestData(2572); // "Uhrzeit Sekunde"
            ////###//
            ////###Schalter Sifa for Railrunner activation###//
            //MyTCPConnection.RequestData(2621); //"Schalter Sifa"
            #endregion 

        }

        public void PlayRRSound()
        {
            try
            {
                SoundPlayer rrSound = new SoundPlayer(@".\resources\rr_meep.wav");
                rrSound.Play();
                //TODO: DEBUG: rrSound needs to be played only ONCE when railrunner i done
                rrSoundplayed = true;
            }
            catch (System.IO.FileNotFoundException)
            {
                MessageBox.Show("Sound kann nicht wiedergegeben werden - Datei nicht gefunden!");
            }
        }

        public void Connect() // here we are going to try connecting to the TCP server
        {
            String server = Convert.ToString(tbServer.Text);
            int port = Convert.ToInt16(tbPort.Text);
            
                // If we're currently disconnected...
                if (MyTCPConnection.ConnectionState == Zusi_Datenausgabe.ConnectionState.Disconnected)
                {
                    // ... try to ... 
                    try
                    {
                        // ... establish a connection using the hostname and port number from the main window.
                        MyTCPConnection.Connect(server, port);
                        setStatus("Warte");
                    }

                    // If something goes wrong...
                    catch (ZusiTcpException ex)
                    {
                        // ... show the user what the connection object has to say.
                        MessageBox.Show(String.Format("Verbindungsfehler: {0}", ex.Message));
                        MyTCPConnection.Disconnnect();
                        setStatus("Getrennt");
                    }
                }

                // If we're currently connected or the connection fell into an error state...
                else
                {
                    // ... reset the connection by explicitly calling Disconnect();
                    MyTCPConnection.Disconnnect();
                    setStatus("Getrennt");
                }            
        }

        #region Setting Of Variables

        //TODO: Load with preferences
        //Here are the default colors for day- and nightmode
        Color labeldaycolor = Color.Black;
        Color paneldaycolor = Color.FromName("Control");
        Color buttondaycolor = Color.FromName("Control");
        Color formdaycolor = Color.FromName("Control");
        Color textboxdaycolor = Color.FromName("Window");

        Color labelnightcolor = Color.WhiteSmoke;
        Color panelnightcolor = Color.FromName("ControlDark");
        Color buttonnightcolor = Color.FromName("ControlDark");
        Color formnightcolor = Color.FromName("ControlDark");
        Color textboxnightcolor = Color.LightGray;      

        //Streckenmeter: User can choose between display in meters or kilometers
        //if factor == 1000 kilometers will be displayed, if factor == 1 meters will be displayed
        int StreckenmeterDarstfaktor = 1000;

        //default values fur user-sizeable form elements
        double labelsifadefaultwidth = 114;
        double labelsifadefaultheight = 51;
        double labelflagdefaultwidth = 114;
        double labelflagdefaultheight = 19;

        //default values for setting a neutral position of Fahr-/Bremsschalter (Kombihebel)
        //TODO: Is there a better solution?
        int fahrschalterneutral = 0;

        //TODO: check for every variable if it's still needed
        double geschwindigkeit;
        public bool abbruch; //TODO: check if still needed
        double vorgabe, entfernung;
        double streckenmeter = 0;
        bool hasMoved = false; //has the train moved?
        double brh;
        double maxVerz = 1; //maximum deceleration
        bool scharf = false; //has the train been stopped sharply?
        bool gebremst = false; //has been braked after acceleration? //TODO: check if still needed
        bool verbunden = false; //connection state of TCP-Server <-> Zusi (when data from Zusi has been received)
        double vAlt = 0, vNeu = 0, deltaV; //determination of acceleration / deceleration
        double vTemp = 0;
        double vReached = 0; //setting a maximum reached speed vReached //TODO: check if still needed
        public bool vMaxErreicht = false; //has a specific speed been reached yet? //TODO: check if still needed
        bool afbistein = false; //reflects the AFB switch status on/off
        public bool debugging = false; //if user has opened the debug panel debugging will be true
        public bool alwaysShowSettings = false; //for determining if the settings panel shall auto hide: has button been clicked?
        bool nightmode = false; //for letting the user choose between two different color sets
        //TODO: maybe it makes sense to determine day- and nightmode automatically when receiving daytime from Zusi
        bool reisezug; //if not true door label will be "Güterzug"
        //DEBUG
        //String zugdateiOld = "";
        //String zugdatei = "";
        //TEST
        bool autopilot = false; //is being checked in intervals to always display label lblFlag "Autopilot ein" when on
        double vmps = 0; // speed in meters per second
        double railrunner = 0; // meters elapsed
        bool rrrunning = false; //is railrunner running?
        //TEST TODO: declare local instead of global
        decimal oldlblsizevaluegrunddaten = 0;
        decimal oldlblsizevaluebremsen = 0;
        decimal oldlblsizevalueafblzb = 0;
        double afbvorwahl = 0.0; // storing value of AFB Schalter * preselected facor / preselected speed
        double afbschalter = 0.0; // storing value of AFB Schalter
        bool rrSoundplayed = false; //has Railrunner sound been played?
        double stunde, minute, sekunde; //TODO: if DLL 1.1.6 is used, this will be obsolete
        double druckhbl, druckhlb;
        double schaltersifa; // if pressed twice RR is activated
        bool settingsAreSeparated = false; // true if settings are shown on a separate form (frmSettings)

        //TODO: TEST: is this the best place?
        SettingsForm frmSettings = new SettingsForm();
        
    

        #endregion

        private void CMainWindow_Load(object sender, EventArgs e) //on loading of the main window...
        {
            if (cbTopmost.Checked == true)
                this.TopMost = true;
            
            //TEST
            //setting form title directly from the assembly information.
            this.Text = this.Text + "v" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
            
            //showing 'System' tab first so that the user is able to establish a connection to the TCP server
            tabEinstellungen.SelectTab("tabSystem");   

            //if a narrow tab page is selected (such as tabSystem)...
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabSystem"])
            {
                tabEinstellungen.Width = 202;
            }

            //adding a global function for all checkboxes, main reason is to determine if user has clicked
            //a checkbox, if so it's being checked if Zusi shall have the window focus back
            //TODO: find a better and more elegant way to detect user interaction with ALL controls on the form

            //pnlBremsen.Controls.Remove(numSizeBremsen);
            foreach (CheckBox c in pnlBremsen.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            //pnlBremsen.Controls.Add(numSizeBremsen);

            //pnlGrunddaten.Controls.Remove(numSizeGrunddaten);
            foreach (CheckBox c in pnlGrunddaten.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            //pnlGrunddaten.Controls.Add(numSizeGrunddaten);

            //TODO: panel object is inside
            //pnlAFBLZB.Controls.Remove(numSizeAFBLZB);
            //foreach (CheckBox c in pnlAFBLZB.Controls)
            //{
            //    c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            //}
            //pnlAFBLZB.Controls.Add(numSizeAFBLZB);

            //DEBUG: remove and add because it's not a checkbox //TODO: find a better way
            pnlSchalterst.Controls.Remove(numFahrschneutral);
            pnlSchalterst.Controls.Remove(lblFahrschneutralbei);
            foreach (CheckBox c in pnlSchalterst.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            pnlSchalterst.Controls.Add(lblFahrschneutralbei);
            pnlSchalterst.Controls.Add(numFahrschneutral);
            
        }

        

        #region HandleIncomingData
        private void TCPConnection_ErrorReceived(object sender, ZusiTcpException ex)
        {
            System.Windows.Forms.MessageBox.Show(String.Format("An error occured when receiving data: {0}", ex.Message));

            MyTCPConnection.Disconnnect();
            btnConnect.Text = "Connect";
        }

        private void  TCPConnection_FloatReceived(object sender, DataSet<float> data) // Handles MyTCPConnection.FloatReceived   
        {
            switch (data.Id)
            {
                #region Geschwindigkeit
                case 2561:
                {
                    geschwindigkeit = data.Value;
                    vmps = geschwindigkeit / 3.6;

                        //TODO: calculate deltaV
                        //vAlt = vNeu;
                        //vNeu = geschwindigkeit;
                        //deltaV = vNeu - vAlt;

                    //displays speed either in kph or in mps
                    if(rbUnitkph.Checked)
                        lblV.Text = String.Format("{0:0.0}", geschwindigkeit); //show current speed in kph
                    else if (rbUnitmps.Checked)
                        lblV.Text = String.Format("{0:0.0}", vmps); //show current speed in mps

                    if (geschwindigkeit > 0.1) 
                        hasMoved = true;
                    
                    if (hasMoved == true && alwaysShowSettings == false && cbHidesettings.Checked && debugging == false) 
                    {
                        if (settingsAreSeparated)
                            frmSettings.Hide();
                        else
                            pnlRight.Visible = false; //auto hide feature: If we start moving, right panel shall be hidden                        
                    }

                    if (hasMoved == true && geschwindigkeit == 0) //if train has stopped
                    {
                        hasMoved = false;
                        alwaysShowSettings = false; //TEST: reset so that settings can autohide again
                    }

                    maxVerz = Convert.ToDouble(tbVerz.Text);
                    //TODO: check sharp braking by by determining deltaV
                    if (deltaV < -maxVerz) //if deceleration was greater than user set value maxVerz
                    {
                        lblFlag.Visible = true;
                        lblFlag.Text = "scharf angehalten";
                        scharf = true;
                        timerFlag.Start(); // TODO: flag shall not hide after x seconds, but only after accelerating again
                    }

                    break;
                }
                #endregion

                #region Bremshundertstel
                case 2654: //Bremshundertstel
                {
                    if (data.Value > 0)  //TODO: do we still need this check?
                    {
                        setStatus("Verbunden");

                        brh = Convert.ToDouble(data.Value); //TODO: do we need to convert here? what if brh were a float?
                        lblBrh.Text = String.Format("{0:0}", brh);
                    }
                    break;
                }
                #endregion

                #region Druck Hll
                case 2562:
                {
                    float hlldruck = data.Value;
                    lblHlldruck.Text = String.Format("{0:0.0}", hlldruck);
                    break;
                }

                #endregion

                #region Druck Bz
                case 2563:
                {
                    float bzdruck = data.Value;
                    lblBzdruck.Text = String.Format("{0:0.0}", bzdruck);
                    break;
                }
                #endregion

                #region Druck HBL
                case 2564:
                    {
                        druckhbl = data.Value;
                        lblHBLwert.Text = String.Format("{0:0.0} bar", druckhbl);
                        break;
                    }
                #endregion

                #region Druck HLB
                case 2579:
                    {
                        druckhlb = data.Value;
                        lblHLBwert.Text = String.Format("{0:0.0} bar", druckhlb);
                        break;
                    }
                #endregion

                #region Streckenkilometer
                case 2645:
                {
                    streckenmeter = Convert.ToDouble(data.Value);
                    lblMeter.Text = String.Format("{0:0.0}", streckenmeter / StreckenmeterDarstfaktor); //see definition of factor
                    break;
                }
                #endregion

                #region Schalter Fahrstufen
                case 2611:
                {
                    double fahrschalter = data.Value - fahrschalterneutral;
                   lblFahrstufenschalter.Text = String.Format("{0:0}", fahrschalter);
                    break;
                }
                #endregion

                #region Schalter Führerbremsventil // NOT YET NEEDED
                case 2612:
                {
                    lblFbventil.Text = data.Value.ToString();
                    break;
                }
                #endregion

                #region Schalter AFB-Geschwindigkeit
                case 2615:
                {
                    afbschalter = data.Value;

                    if (rbAFBvor5.Checked)
                        afbvorwahl = afbschalter * 5;
                    else if (rbAFBvor10.Checked)
                        afbvorwahl = afbschalter * 10;

                    lblAFBvorwahl.Text = afbvorwahl.ToString();
                    break;
                }
                #endregion

                #region Fahrstufe
                case 2576:
                {
                    lblFahrstufe.Text = String.Format("{0:0}", data.Value);
                    break;
                }
                #endregion

                default:
                    break;
            }
        }

        private void TCPConnection_BoolReceived(object sender, DataSet<bool> data) //Handles MyTCPConnection.BoolReceived
        {
            switch (data.Id)
            {
                #region LM Sifa
                case 2596:
                    {
                        if (data.Value) // if true, LM Sifa is on 
                        {
                            lblSifa.Text = "SIFA";
                            lblSifa.BackColor = Color.White;
                        }
                        else
                        {
                            lblSifa.Text = "";
                            lblSifa.BackColor = Color.DarkGray;
                        }
                        break;
                    }
                #endregion

                #region LM Schleudern
                case 2599:
                    {
                        if (data.Value) // if true, LM Schleudern is on
                        {
                            lblFlag.Text = "Schleudern!";
                            lblFlag.Visible = true;
                            //timerFlag.Start(); //TEST: TODO: do we need the timer?
                        }
                        else
                        {
                            lblFlag.Text = "";
                            lblFlag.Visible = false;
                        }
                        break;
                    }
                #endregion

                #region Schalter AFB ein/aus
                case 2616:
                    {
                        if (data.Value) // if true, AFB switch is ON
                        {
                            afbistein = true;
                            lblafbeinaus.Font = new Font(lblafbeinaus.Font, FontStyle.Bold);
                            lblafbeinaus.Text = "AFB ein";
                        }
                        else // else, AFB switch is OFF
                        {
                            afbistein = false;
                            lblafbeinaus.Font = new Font(lblafbeinaus.Font, FontStyle.Regular);
                            lblafbeinaus.Text = "AFB aus";
                        }

                        break;
                    }
                #endregion

                #region Autopilot
                case 2647:
                    {
                        if (data.Value) //if true, autopilot is on...
                        {
                            autopilot = true;
                            timer100.Enabled = true; //makes sure "Autopilot ein" lblFlag is displayed as long as A/P is on
                        }
                        else // if false, autopilot is off
                        {
                            autopilot = false;
                            lblFlag.Visible = false;
                            lblFlag.Text = "";
                            timer100.Enabled = false;
                        }
                        break;
                    }
                #endregion

                #region Reisezug
                case 2648:
                    {
                        //DEBUG:
                        lblDebugreiseztrue.Text = data.Value.ToString();
                        //TODO: check if correct

                        if (data.Value) //if true -> passenger train
                        {
                            reisezug = true;                            
                        }
                        else //if false -> freight train
                        {
                            reisezug = false;
                            lblFlag.Visible = false; //hide if doors were open when a freight train has been selected as new train
                        }

                        break;
                    }
                #endregion

                default:
                    break;
            }
        }

        private void TCPConnection_DateTimeReceived(object sender, DataSet<DateTime> data) // Handles MyTCPConnection.DateTimeReceived 
        {
            switch (data.Id)
            {
                #region LM Uhrzeit (digital)
                case 2610:
                    {
                        lblTime.Text = string.Format("{0}", data.Value.ToLongTimeString());
                        //TODO: add a real-timing functionality that can replace some timers
                        break;
                    }
                #endregion

                default:
                    break;
            }
            

        }

        private void HandleIncomingData(DataSet<float> dataSet)
        {

        
        
        //    else if (dataSet.Id == MyTCPConnection["Türen"])
        //    {

        //        //DEBUG
        //        String reisezugOld = reisezug.ToString();
        //        //lblDebugreisezwert.Text = reisezugOld;

        //        if (reisezug == true)
        //        {
        //            //DEBUG
        //            //MessageBox.Show("DEBUG: Reisezug=TRUE" + "--old:" + reisezugOld + "--:" + reisezug);

        //            double tuerwert = dataSet.Value;

        //            if (tuerwert > 7E-45 && cbTueren.Checked) // closed
        //            {
        //                lblFlag.Visible = false;
        //                lblFlag.Text = "";
        //                lblTueren.Text = "Türen zu";
        //            }
        //            else if (tuerwert < 2E-45 && tuerwert > 0 && cbTueren.Checked) //open
        //            {
        //                lblFlag.Visible = true;
        //                lblFlag.Text = "Türen geöffnet";
        //                lblTueren.Text = "Türen offen";
        //            }
        //            else if (tuerwert > 5E-45 && tuerwert < 7E-45) //closing
        //            {
        //                lblTueren.Text = "Türen schließen";
        //            }
        //            else if (tuerwert > 4E-45 && tuerwert < 5E-45)  //passengers okay
        //            {
        //                lblTueren.Text = "Fahrgäste i.O.";
        //            }
        //            else if (tuerwert == 0)  //doors unblocked
        //            {
        //                lblTueren.Text = "Türen freigegeben";
        //            }
        //        }
        //        else if (reisezug == false)//if reisezug is not true
        //        {
        //            //DEBUG
        //            //MessageBox.Show("DEBUG: Reisezug=FALSE" + "--old:" + reisezugOld + "--:" + reisezug);        
        //            lblTueren.Text = "Güterzug";
        //        }
        //    }
        //    


        //   
        //    else if (dataSet.Id == MyTCPConnection["AFB Soll-Geschwindigkeit"])
        //    //TODO: check if there's a value available that reflects some kind of AFB "preset speed" value
        //    {
        //        double afbvschalter = dataSet.Value;
                
        //        //TODO: check if LZB vSoll is less; if so paint LZB speed value bold instead
        //        lblAFBgeschwindigkeit.Text = String.Format("{0:0} km/h", afbvschalter);
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LZB Soll-Geschwindigkeit"])
        //    {
        //        double lzbsoll = dataSet.Value;
        //        lblLZBsollgeschw.Text = String.Format("{0:0}", lzbsoll);
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LZB Ziel-Geschwindigkeit"])
        //    {
        //        double lzbziel = dataSet.Value;
        //        lblLZBzielgeschw.Text = String.Format("{0:0}", lzbziel);
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM LZB Zielweg (ab 0)"])
        //    {
        //        double lzbweg = dataSet.Value;
        //        lblLZBzielweg.Text = String.Format("{0:0}", lzbweg);
        //    }
        //    //DEBUG TEST
        //    /* else if (dataSet.Id == MyTCPConnection["Zugdatei"])...
        //    {/*zugdateiOld = zugnummer;
        //        zugdatei = dataSet.Value.ToString();
        //        if (zugnummer != zugnummerOld)
        //            MessageBox.Show("DEBUG: Zugdatei has changed"); } */   

        
        //    //###PZB-90###//
        //    else if (dataSet.Id == MyTCPConnection["LM PZB Zugart O"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblPZB_O.BackColor = Color.CornflowerBlue;                      
        //        else
        //            lblPZB_O.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM PZB Zugart M"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblPZB_M.BackColor = Color.CornflowerBlue;
        //        else
        //            lblPZB_M.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM PZB Zugart U"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblPZB_M.BackColor = Color.CornflowerBlue;
        //        else
        //            lblPZB_M.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM PZB 1000Hz"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblPZB_1000.BackColor = Color.Yellow;
        //        else
        //            lblPZB_1000.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM PZB 500Hz"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblPZB_500.BackColor = Color.Red;
        //        else
        //            lblPZB_500.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM PZB Befehl"])
        //    {
        //        if (dataSet.Value > 0)
        //        { lblPZB_Bef.BackColor = Color.Black; lblPZB_Bef.ForeColor = Color.White; }
        //        else
        //        { lblPZB_Bef.BackColor = Color.FromName("Transparent"); lblPZB_Bef.ForeColor = Color.FromName("ControlText"); }
        //    }
        //    //###LZB###//
        //    else if (dataSet.Id == MyTCPConnection["LM LZB G"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblLZB_G.BackColor = Color.Red;
        //        else
        //            lblLZB_G.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM LZB Ende"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblLZB_Ende.BackColor = Color.Yellow;
        //        else
        //            lblLZB_Ende.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM LZB S"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblLZB_S.BackColor = Color.Red;
        //        else
        //            lblLZB_S.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM LZB Prüfen"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblLZB_Pruefstoer.BackColor = Color.White;
        //        else
        //            lblLZB_Pruefstoer.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM LZB Ü"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblLZB_Ue.BackColor = Color.CornflowerBlue;
        //        else
        //            lblLZB_Ue.BackColor = Color.FromName("Transparent");
        //    }
        //    else if (dataSet.Id == MyTCPConnection["LM LZB B"])
        //    {
        //        if (dataSet.Value > 0)
        //            lblLZB_B.BackColor = Color.CornflowerBlue;
        //        else
        //            lblLZB_B.BackColor = Color.FromName("Transparent");
        //    }
        //    //######//
        //    
        //    
        //    else if (dataSet.Id == MyTCPConnection["Schalter Sifa"])
        //    {
        //        //DEBUG
        //        //if (dataSet.Value > 0)
        //        //{
        //        //    schaltersifa++;
        //        //    lblDebugsifaschalter.Text = schaltersifa.ToString();
        //        //}
        //        if (dataSet.Value > 0)
        //        {
        //            schaltersifa++;
        //            lblDebugsifaschalter.Text = schaltersifa.ToString();
        //            if (schaltersifa == 1)
        //            {
        //                timerResetSifaschalter.Start();
        //                lblDebugtimerresetsifa.Text = timerResetSifaschalter.Enabled.ToString();
        //            }
        //            else if (schaltersifa == 2)
        //            {
        //                schaltersifa = 0;
        //                timerResetSifaschalter.Stop();
        //                lblDebugtimerresetsifa.Text = timerResetSifaschalter.Enabled.ToString();
        //                if (cbRailrunner.Checked)  //IMPORTANT - only if cbRailrunner is checked, RR counter will start
        //                    SetRR();
        //            }
        //        }
        //    }
        }
        #endregion

        #region SetStatus
        //here we are setting the program status depending on the connection state 
        public void setStatus(String statusNeu)
        {
            if (statusNeu == "Getrennt")
            {
                btnConnect.Text = "Verbinden";
                lblVerbstatus.Text = "Getrennt";
                verbunden = false;

            }
            else if (statusNeu == "Warte")
            {

                //TODO: set an initial display for all pnlData numbers (like 888.88)
                btnConnect.Text = "Trennen";
                pnlRight.Visible = true;
                tabEinstellungen.SelectTab("tabAnzeigen1");
                lblVerbstatus.Text = "Warte auf Zusi";

            }
            else if (statusNeu == "Verbunden")
            {
                verbunden = true;
                lblVerbstatus.Text = "Verbunden mit Zusi";

                grpDebugoffline.Enabled = false; //DEBUG: disabling control of speed via numUD

            }
        }
        #endregion

        public void DisplayTime()
        {
            //lblUhrzeit.Text = String.Format("{0:0}", stunde) + ":" + String.Format("{0:0}", minute) + ":"
            //    + String.Format("{0:0}", sekunde);

            //label8.Text = stunde.ToString();
            //label9.Text = minute.ToString();
            //label10.Text = sekunde.ToString();
        }

        #region Night- and Daymode

        public void setNightmode()
        {
            this.BackColor = formnightcolor; //the whole main form's background color
            if (settingsAreSeparated) // if there's a separate settings window
                frmSettings.BackColor = formnightcolor;

            statusStrip1.BackColor = formnightcolor; //same for the status strip

            //setting colors for the labels
            foreach (Label label in pnlDataGrunddaten.Controls)
            {
                label.ForeColor = labelnightcolor;
            }
            foreach (Label label in pnlDataBremsen.Controls)
            {
                label.ForeColor = labelnightcolor;
            }
            foreach (Label label in pnlDataAFBLZB.Controls)
            {
                label.ForeColor = labelnightcolor;
            }

            //setting colors for the tab pages
            foreach (TabPage tab in tabEinstellungen.Controls)
            {
                tab.BackColor = panelnightcolor;
            }

            //setting colors for the textboxes
            tbPort.BackColor = textboxnightcolor;
            tbServer.BackColor = textboxnightcolor;
            tbVerz.BackColor = textboxnightcolor;

            //setting colors for PZB90-Panel
            //TEST: darkening background
            //Color c1 = pnlDataPZB90.BackColor;
            //Color c2 = Color.FromArgb(c1.A, (Convert.ToInt32(c1.R*0.8)), (Convert.ToInt32(c1.G*0.8)), (Convert.ToInt32(c1.B*0.8)));
            //pnlDataPZB90.BackColor = c2;
            pnlDataPZB90.BackColor = Color.FromName("ControlDark");
            pnlDataPZB90.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;
            //setting colors for PZB90-Panel
            pnlDataLZB.BackColor = Color.FromName("ControlDark");
            pnlDataLZB.CellBorderStyle = TableLayoutPanelCellBorderStyle.Inset;

            //TEST make btnDebug invisible
            btnDebugpanel.BackColor = formnightcolor;
            btnDebugpanel.ForeColor = formnightcolor;
        }

       
        public void setDaymode()
        {
            BackColor = formdaycolor; //the whole main form's background color
            if (settingsAreSeparated) // if there's a separate settings window
                frmSettings.BackColor = formdaycolor;
            statusStrip1.BackColor = formdaycolor; //same for the status strip           

            //setting colors for the labels
            foreach (Label label in pnlDataGrunddaten.Controls)
            {
                label.ForeColor = labeldaycolor;
            }
            foreach (Label label in pnlDataBremsen.Controls)
            {
                label.ForeColor = labeldaycolor;
            }
            foreach (Label label in pnlDataAFBLZB.Controls)
            {
                label.ForeColor = labeldaycolor;
            }

            //setting colors for the tab pages
            foreach (TabPage tab in tabEinstellungen.Controls)
            {
                tab.BackColor = paneldaycolor;
            }

            //setting colors for the textboxes
            tbServer.BackColor = textboxdaycolor;
            tbPort.BackColor = textboxdaycolor;
            tbVerz.BackColor = textboxdaycolor;

            //setting colors for PZB90-Panel
            //TEST: lightening background
            //Color c1 = pnlDataPZB90.BackColor;
            //Color c2 = Color.FromArgb(c1.A, (Convert.ToInt32(c1.R * 1.2)), (Convert.ToInt32(c1.G * 1.2)), (Convert.ToInt32(c1.B * 1.2)));
            //pnlDataPZB90.BackColor = c2;
            pnlDataPZB90.BackColor = Color.FromName("Control");
            pnlDataPZB90.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            //setting colors for PZB90-Panel
            pnlDataLZB.BackColor = Color.FromName("Control");
            pnlDataLZB.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            //TEST make btnDebug invisible
            btnDebugpanel.BackColor = formdaycolor;
            btnDebugpanel.ForeColor = formdaycolor;
        }

        //if the user clicks the "Nachtmodus / Tagmodus" button
        private void btnNacht_Click(object sender, EventArgs e)
        {
            if (nightmode == false) //if we're not yet in nightmode...
            {
                nightmode = true;
                setNightmode();
                btnNacht.Text = "Tagmodus";
            }
            else
            {
                nightmode = false;
                setDaymode();
                btnNacht.Text = "Nachtmodus";
            }

            FokusAnZusi(); //determine if focus must be handed over to Zusi according to user settings

        }
        #endregion

        #region User Settings Interaction

        //either one or the other checkbox is allowed to be checked, or none
        private void cbFokusImmerzurueck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFokusImmerzurueck.Checked)
                cbFokusFahrtzurueck.Checked = false;
        }
        private void cbFokusFahrtzurueck_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFokusFahrtzurueck.Checked)
                cbFokusImmerzurueck.Checked = false;
        }

        private void cbAFBgeschw_CheckedChanged(object sender, EventArgs e)
        {
                lblafbeinaus.Visible = cbAFBgeschw.Checked;
                lblAFBgeschwindigkeit.Visible = cbAFBgeschw.Checked;
        }
        
        private void cbLZBvsoll_CheckedChanged(object sender, EventArgs e)
        {
            lbllzbvsoll.Visible = cbLZBvsoll.Checked;
            lblLZBsollgeschw.Visible = cbLZBvsoll.Checked;
        }

        private void cbLZBvziel_CheckedChanged(object sender, EventArgs e)
        {
            lbllzbvziel.Visible = cbLZBvziel.Checked;
            lblLZBzielgeschw.Visible = cbLZBvziel.Checked;
        }

        private void cbLZBweg_CheckedChanged(object sender, EventArgs e)
        {
            lbllzbzielw.Visible = cbLZBweg.Checked;
            lblLZBzielweg.Visible = cbLZBweg.Checked;
        }

        private void cbAFBLZB_CheckedChanged(object sender, EventArgs e)
        {
            pnlDataAFBLZB.Visible = cbAFBLZB.Checked;
            pnlAFBLZB.Enabled = cbAFBLZB.Checked;

            pnlDataLZB.Visible = cbLZBlm.Checked && cbAFBLZB.Checked;
        }

        private void cbGeschwindigkeit_CheckedChanged(object sender, EventArgs e)
        {
            lblV.Visible = cbGeschwindigkeit.Checked;
            lblkmh.Visible = cbGeschwindigkeit.Checked;
        }

        private void cbStreckenmeter_CheckedChanged(object sender, EventArgs e)
        {
            lblMeter.Visible = cbStreckenmeter.Checked;
            lblm.Visible = cbStreckenmeter.Checked;
        }

        private void cbDruckhll_CheckedChanged(object sender, EventArgs e)
        {
            lblHlldruck.Visible = cbDruckhll.Checked;
            lblbarhll.Visible = cbDruckhll.Checked;
        }

        private void cbDruckbz_CheckedChanged(object sender, EventArgs e)
        {
            lblBzdruck.Visible = cbDruckbz.Checked;
            lblbarbz.Visible = cbDruckbz.Checked;
        }

        private void cbBrh_CheckedChanged(object sender, EventArgs e)
        {
            lblBrh.Visible = cbBrh.Checked;
            lblbremsh.Visible = cbBrh.Checked;
        }        

        private void cbLmsifa_CheckedChanged(object sender, EventArgs e)
        {
            lblSifa.Visible = cbLmsifa.Checked;
        }

        private void cbLmschleudern_CheckedChanged(object sender, EventArgs e)
        {
            lblFlag.Visible =cbLmschleudern.Checked;
            if(cbLmschleudern.Checked)
                ShowFlagtest();
        }        

        private void cbGrunddaten_CheckedChanged(object sender, EventArgs e)
        {
            pnlDataGrunddaten.Visible = cbGrunddaten.Checked;
            pnlDataPZB90.Visible = cbGrunddaten.Checked && cbPZBLM.Checked; //TODO: watch out if PZB controls visibility can also be controlled by another checkbox
            pnlGrunddaten.Enabled = cbGrunddaten.Checked;
        }

        private void cbBremsen_CheckedChanged(object sender, EventArgs e)
        {
            pnlDataBremsen.Visible = cbBremsen.Checked;
            pnlBremsen.Enabled = cbBremsen.Checked;
        }

        private void cbLmtueren_CheckedChanged(object sender, EventArgs e)
        {
            lblTueren.Visible = cbTueren.Checked;
            if(cbTueren.Checked)
                ShowFlagtest(); //TODO: check if flagtest is only shown when necessary, also: check if lblFlag is really always shown when necessary
        }

        private void cbFahrstufe_CheckedChanged(object sender, EventArgs e)
        {
            lblFahrstufe.Visible = cbFahrstufe.Checked;
            lblfahrst.Visible = cbFahrstufe.Checked;
        }
        private void cbFahrstufenschalter_CheckedChanged(object sender, EventArgs e)
        {
            lblFahrstufenschalter.Visible = cbFahrstufenschalter.Checked;
            lblfahrstschalter.Visible = cbFahrstufenschalter.Checked;
        }

        private void rbDarstKm_CheckedChanged(object sender, EventArgs e)
        {
            StreckenmeterDarstfaktor = 1000;
            lblm.Text = "km";
        }

        private void rbDarstMeter_CheckedChanged(object sender, EventArgs e)
        {
            StreckenmeterDarstfaktor = 1;
            lblm.Text = "m";
        }

        private void cbTopmost_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTopmost.Checked == true)
                this.TopMost = true;
            else
                this.TopMost = false;
        }

        private void numSifagroesse_ValueChanged(object sender, EventArgs e)
        {
            if (numSifagroesse.Value == 3)
            {
                double faktor = 1.2;
                lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
                lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
                lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);
            }
            else if (numSifagroesse.Value == 2)
            {
                double faktor = 1.0;
                lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
                lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
                lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);
            }
            else if (numSifagroesse.Value == 1)
            {
                double faktor = 0.8;
                lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
                lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
                lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);
            }
        }

        private void cbFahrschneutral_ValueChanged(object sender, EventArgs e)
        {
            fahrschalterneutral = Convert.ToInt32(numFahrschneutral.Value);
        }

        private void cbSchalterst_CheckedChanged(object sender, EventArgs e)
        {
            lblfahrstschalter.Visible = cbSchalterst.Checked && cbFahrstufenschalter.Checked; ;
            lblFahrstufenschalter.Visible = cbSchalterst.Checked && cbFahrstufenschalter.Checked;
            pnlSchalterst.Enabled = cbSchalterst.Checked;
        }

        #endregion
        
        #region User Tab Interaction

        private void tabEinstellungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabSystem"])
            {
                tabEinstellungen.Width = 202;
               int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabDarstellung"])
            {
                tabEinstellungen.Width = 202;                
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabAnzeigen1"])
            {
                tabEinstellungen.Width = 420;
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabAnzeigen2"])
            {
                tabEinstellungen.Width = 420;
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            
        }

        #endregion

        #region User Button Interaction

        ////setting user colors for night- and daymode
        //private void btnFarbeNacht_Click(object sender, EventArgs e)
        //{
        //    colorDialog1.ShowDialog();
        //}
        //private void btnFarbeTag_Click(object sender, EventArgs e)
        //{
        //    colorDialog1.ShowDialog();
        //}

        //if the user clicks the "Einstellungen" button...
        private void btnSettings_Click(object sender, EventArgs e)
        {
            if (settingsAreSeparated == false) // if settings are NOT in a separate window
            {
                //TEST
                if (hasMoved)
                {
                    alwaysShowSettings = true; //when we're moving, we do NOT want to autohide at the moment
                    pnlRight.Visible = !pnlRight.Visible;
                }
                else
                {
                    alwaysShowSettings = false;
                    pnlRight.Visible = !pnlRight.Visible;

                }
            }
            else if (settingsAreSeparated == true)
            {
                //TEST
                if (hasMoved)
                {
                    alwaysShowSettings = true; //when we're moving, we do NOT want to autohide at the moment
                    //pnlRight.Visible = !pnlRight.Visible;
                    frmSettings.Visible = !frmSettings.Visible;
                }
                else
                {
                    alwaysShowSettings = false;
                    //pnlRight.Visible = !pnlRight.Visible;
                    frmSettings.Visible = !frmSettings.Visible;
                }
            }

            FokusAnZusi();
        }

        //if the user clicks the "Verbinden / Trennen" button
        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

        //DEBUG: shows the flag below the Sifa label (for testing positioning)
        private void btnFlag_Click(object sender, EventArgs e)
        {
            lblFlag.Visible = !lblFlag.Visible;
            lblFlag.BackColor = Color.Orange;
            lblFlag.Text = "####TEST####";
        }

        //DEBUG: if the debug button has been clicked...
        private void btnDebugpanel_Click(object sender, EventArgs e)
        {
            if (debugging == true)  //if we are yet in debugging mode, turn debugging mode off
            {
                pnlDebug.Visible = false;
                debugging = false;
                btnDebugpanel.BackColor = Color.FromName("Control");
            }
            else if (debugging == false) //else turn debugging mode on
            {
                pnlDebug.Visible = true;
                debugging = true;
                btnDebugpanel.BackColor = Color.Salmon;

                //we want to have the debug panel visible on the right side of our tabbed panel plus 10 pt
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
        }

        //DEBUG: to test focus handling
        private void btnDebugFokusZusi_Click(object sender, EventArgs e)
        {
            String window = "Zusi";
            //SetActiveWindow(FindWindow(null, window));
            //TODO: check if SetActiveWindow makes a difference
            SetForegroundWindow(FindWindow(null, window));

        }

        #endregion


        //adding a global function for all checkboxes, main reason is to determine if user has clicked
        //a checkbox, if so it's being checked if Zusi shall have the window focus back
        //TODO: find a better and more elegant way to detect user interaction with ALL controls on the form
        private void Control_CheckedChanged(object sender, EventArgs e)
        {
            FokusAnZusi();
        }

        public void ResetDebugLabels() //resetting all the labels on the Debug panel to their initial state
        {
            //         
        }

        public void ResetGlobals() //resetting some variables
        {
            lblFlag.Visible = false;
            hasMoved = false;
            pnlRight.Visible = true;
            abbruch = false;
            scharf = false;
            vMaxErreicht = false;
            gebremst = false;
        }

        //TEST: global function, TODO: find a better way
       

        //if called (lblFlag is showing), after x seconds turn off the flag and stop the timer
        private void timerFlag_Tick(object sender, EventArgs e)
        {
            lblFlag.Visible = false;
            timerFlag.Stop();
        }

        public void ShowFlagtest()
        {
            lblFlag.Visible = true;
            lblFlag.Text = "TEST";
            timerFlag.Start(); //Zeigt für eine Sekunde ein Testflag

        }
        
        public void FokusAnZusi()
        {
            if (hasMoved == true && cbFokusFahrtzurueck.Checked) //give focus back to Zusi when already moving
            {
                String window = "Zusi";
                //SetActiveWindow(FindWindow(null, window));
                SetForegroundWindow(FindWindow(null, window));
            }
            else if (cbFokusImmerzurueck.Checked)
            {                
                String window = "Zusi";
                //SetActiveWindow(FindWindow(null, window));
                SetForegroundWindow(FindWindow(null, window));
            }
        }

        //TEST
        private void timer100_Tick(object sender, EventArgs e)
        {
            if (autopilot == true)
            {
                lblFlag.Visible = true;
                lblFlag.Text = "Autopilot ein";
            }

        }

        

        private void cbPZBLM_CheckedChanged(object sender, EventArgs e)
        {
            pnlDataPZB90.Visible = cbPZBLM.Checked;
        }

        private void numFahrschneutral_ValueChanged(object sender, EventArgs e)
        {
            fahrschalterneutral = Convert.ToInt32(numFahrschneutral.Value);
        }

        //TODO: rename method
        //DEBUG
        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            if (verbunden == false)
            {
                geschwindigkeit = Convert.ToDouble(numDebugsetspeed.Value);
                vmps = geschwindigkeit / 3.6;
                //vAlt = vNeu;
                //vNeu = geschwindigkeit;
                //deltaV = vNeu - vAlt;
                if (rbUnitkph.Checked)
                    lblV.Text = String.Format("{0:0.0}", geschwindigkeit); //show current speed in kph
                else if (rbUnitmps.Checked)
                    lblV.Text = String.Format("{0:0.0}", vmps); //show current speed in mps
            }
        }

        //TEST
        private void timerRailrunner_Tick(object sender, EventArgs e)
        {
            double intrvl = Convert.ToDouble(timerRailrunner.Interval);
            railrunner = railrunner + (vmps * (intrvl / 1000.0));

            if (cbRRcountdown.Checked && rbRRfest.Checked)
            {
                btnRailrunner.Text = String.Format("noch {0:0} m", Convert.ToDouble(numRRfest.Value) - railrunner);

                if (railrunner >= Convert.ToDouble(numRRfest.Value))
                {
                    if (vAlt == 0.0 | geschwindigkeit < vAlt)
                        vAlt = geschwindigkeit;

                    btnRailrunner.Text = "Strecke abgefahren";
                    btnRailrunner.BackColor = Color.LightGreen;
                    if (cbRRSound.Checked && rrSoundplayed == false)
                       PlayRRSound();

                    //for determining if train has been accelerated by more than x kph                                  
                    if (geschwindigkeit > vAlt + 5 && cbRRautoreset.Checked)
                    {
                        SetRR(); //will reset RR if rrrunning is still true
                        vAlt = 0.0;
                    }                
                }
            }
            else if (cbRRcountup.Checked && rbRRfest.Checked)
            {
                btnRailrunner.Text = String.Format("{0:0} m", railrunner);

                if (railrunner >= Convert.ToDouble(numRRfest.Value))
                {
                    if (vAlt == 0.0 | geschwindigkeit < vAlt)
                        vAlt = geschwindigkeit;

                    btnRailrunner.Text = numRRfest.Value.ToString() + " m OK";
                    btnRailrunner.BackColor = Color.LightGreen;
                    if (cbRRSound.Checked && rrSoundplayed == false)
                        PlayRRSound();
  
                    //for determining if train has been accelerated by more than x kph                                  
                    if (geschwindigkeit > vAlt + 5 && cbRRautoreset.Checked)
                    {
                        SetRR(); //will reset RR if rrrunning is still true
                        vAlt = 0.0;
                    }
                }
            }
            else if (rbRRfrei.Checked)
                btnRailrunner.Text = String.Format("{0:0} m", railrunner);    
        }

        private void btnDebugRailrunner_Click(object sender, EventArgs e)
        {
            timerRailrunner.Start();
        }

        private void cbRailrunner_CheckedChanged(object sender, EventArgs e)
        {
            btnRailrunner.Visible = cbRailrunner.Checked;
            pnlRailrunner.Enabled = cbRailrunner.Checked;
        }

        public void SetRR()
        {
            if (rrrunning)
            {
                timerRailrunner.Stop();
                btnRailrunner.BackColor = Color.FromName("Control");
                btnRailrunner.Text = "Wegmessung";
                railrunner = 0;
                rrrunning = false;
                rrSoundplayed = false; //TODO
            }
            else if (rrrunning == false)
            {
                timerRailrunner.Start();
                btnRailrunner.BackColor = Color.LightSkyBlue;
                rrrunning = true;
            }
        }

        private void btnRailrunner_Click(object sender, EventArgs e)
        {
            SetRR();
            FokusAnZusi();
        }

       

        private void numSizeGrunddaten_ValueChanged(object sender, EventArgs e)
        {
            if (numSizeGrunddaten.Value > oldlblsizevaluegrunddaten) // we want to upscale the font of each label
            {

                foreach (Label lbl in pnlDataGrunddaten.Controls)
                {
                    float newsize = lbl.Font.Size + 1;

                    lbl.Font = new Font(lbl.Font.Name, newsize);
                }

                oldlblsizevaluegrunddaten = numSizeGrunddaten.Value;
            }
            else if (numSizeGrunddaten.Value < oldlblsizevaluegrunddaten) // we want to downscale the font of each label
            {

                foreach (Label lbl in pnlDataGrunddaten.Controls)
                {
                    float newsize = lbl.Font.Size - 1;

                    lbl.Font = new Font(lbl.Font.Name, newsize);
                }

                oldlblsizevaluegrunddaten = numSizeGrunddaten.Value;
            }
        }

        private void numSizeBremsen_ValueChanged(object sender, EventArgs e)
        {
            if (numSizeBremsen.Value > oldlblsizevaluebremsen) // we want to upscale the font of each label
            {

                foreach (Label lbl in pnlDataBremsen.Controls)
                {
                    float newsize = lbl.Font.Size + 1;

                    lbl.Font = new Font(lbl.Font.Name, newsize);
                }

                oldlblsizevaluebremsen = numSizeBremsen.Value;
            }
            else if (numSizeBremsen.Value < oldlblsizevaluebremsen) // we want to downscale the font of each label
            {

                foreach (Label lbl in pnlDataBremsen.Controls)
                {
                    float newsize = lbl.Font.Size - 1;

                    lbl.Font = new Font(lbl.Font.Name, newsize);
                }

                oldlblsizevaluebremsen = numSizeBremsen.Value;
            }

        }

        private void numSizeRailrunner_ValueChanged(object sender, EventArgs e)
        {
            //if (numSizeRailrunner.Value > oldlblsizevalue) // we want to upscale the font of each label
            //{


            //    double newheight = btnRailrunner.Height * 1.1;
            //    double newwidth = btnRailrunner.Width * 1.1;                

            //    oldlblsizevalue = numSizeRailrunner.Value;
            //}
            //else if (numSizeGrunddaten.Value < oldlblsizevalue) // we want to downscale the font of each label
            //{

            //    double newheight = btnRailrunner.Height * 0.9;
            //    double newwidth = btnRailrunner.Width * 0.9;
                
            //    oldlblsizevalue = numSizeRailrunner.Value;
            //}
        }

        private void numSizeAFBLZB_ValueChanged(object sender, EventArgs e)
        {
            if (numSizeAFBLZB.Value > oldlblsizevalueafblzb) // we want to upscale the font of each label
            {

                foreach (Label lbl in pnlDataAFBLZB.Controls)
                {
                    float newsize = lbl.Font.Size + 1;

                    lbl.Font = new Font(lbl.Font.Name, newsize);
                }

                oldlblsizevalueafblzb = numSizeAFBLZB.Value;
            }
            else if (numSizeAFBLZB.Value < oldlblsizevalueafblzb) // we want to downscale the font of each label
            {

                foreach (Label lbl in pnlDataAFBLZB.Controls)
                {
                    float newsize = lbl.Font.Size - 1;

                    lbl.Font = new Font(lbl.Font.Name, newsize);
                }

                oldlblsizevalueafblzb = numSizeAFBLZB.Value;
            }
        }

        private void numRRfest_ValueChanged(object sender, EventArgs e)
        {
            if (rrrunning && railrunner <= Convert.ToDouble(numRRfest.Value)) //if value has increased, change color back to blue
            {
                btnRailrunner.BackColor = Color.LightSkyBlue;
                rrSoundplayed = false; // so that the sound is played when the new value has been reached
            }
        }

        private void rbRRfrei_CheckedChanged(object sender, EventArgs e)
        {
            if(rrrunning)
                btnRailrunner.BackColor = Color.LightSkyBlue;

            //TODO: integrate these controls into a panel?
            cbRRSound.Enabled = !rbRRfrei.Checked; //if rbRRfrei is checked, cbRRSound will be disabled ...
            numRRfest.Enabled = !rbRRfrei.Checked;
            cbRRcountup.Enabled = !rbRRfrei.Checked;
            cbRRcountdown.Enabled = !rbRRfrei.Checked;
            cbRRautoreset.Enabled = !rbRRfrei.Checked;

        }

        private void cbAFBVorwahl_CheckedChanged(object sender, EventArgs e)
        {
            lblAFBvorwahl.Visible = cbAFBVorwahl.Checked;
            lblafbvorw.Visible = cbAFBVorwahl.Checked;
            rbAFBvor5.Enabled = cbAFBVorwahl.Checked;
            rbAFBvor10.Enabled = cbAFBVorwahl.Checked;
        }

        //TODO: more elegant soution appreciated
        private void rbAFBvor5_CheckedChanged(object sender, EventArgs e)
        {
            rbAFBvor10.Checked = !rbAFBvor5.Checked;

            if(rbAFBvor5.Checked)
                afbvorwahl = afbschalter * 5;
            else if (rbAFBvor10.Checked)
                afbvorwahl = afbschalter * 10;
            lblAFBvorwahl.Text = afbvorwahl.ToString(); //update display of preselected speed
        }

        //TODO: more elegant soution appreciated
        private void rbAFBvor10_CheckedChanged(object sender, EventArgs e)
        {
            rbAFBvor5.Checked = !rbAFBvor10.Checked;

            if (rbAFBvor5.Checked)
                afbvorwahl = afbschalter * 5;
            else if (rbAFBvor10.Checked)
                afbvorwahl = afbschalter * 10;
            lblAFBvorwahl.Text = afbvorwahl.ToString(); //update display of preselected speed
        }

        private void cbRRcountdown_CheckedChanged(object sender, EventArgs e)
        {
            cbRRcountup.Checked = !cbRRcountdown.Checked;
        }

        private void cbRRcountup_CheckedChanged(object sender, EventArgs e)
        {
            cbRRcountdown.Checked = !cbRRcountup.Checked;
        }

        private void btnDebugPlaysound_Click(object sender, EventArgs e)
        {
            PlayRRSound();
        }

        private void rbRRfest_CheckedChanged(object sender, EventArgs e)
        {
            //TODO: integrate these controls into a panel...
            cbRRSound.Enabled = rbRRfest.Checked; //if rbRRfrei is checked, cbRRSound will be disabled ...
            numRRfest.Enabled = rbRRfest.Checked;
            cbRRcountup.Enabled = rbRRfest.Checked;
            cbRRcountdown.Enabled = rbRRfest.Checked;
            cbRRautoreset.Enabled = rbRRfest.Checked;
        }

        private void cbDruckhbl_CheckedChanged(object sender, EventArgs e)
        {
            lblhbl.Visible = cbDruckhbl.Checked;
            lblHBLwert.Visible = cbDruckhbl.Checked;
        }

        private void cbDruckhlb_CheckedChanged(object sender, EventArgs e)
        {
            lblhlb.Visible = cbDruckhlb.Checked;
            lblHLBwert.Visible = cbDruckhlb.Checked;
        }

        private void cbLZBlm_CheckedChanged(object sender, EventArgs e)
        {
            pnlDataLZB.Visible = cbLZBlm.Checked;
        }

        private void CMainWindow_Click(object sender, EventArgs e)
        {
            FokusAnZusi();
        }

        private void tabAnzeigen1_Click(object sender, EventArgs e)
        {
            FokusAnZusi();
        }

        private void tabDarstellung_Click(object sender, EventArgs e)
        {
            FokusAnZusi();
        }

        private void tabSystem_Click(object sender, EventArgs e)
        {
            FokusAnZusi();
        }

        private void btnAbout_Click(object sender, EventArgs e)
        {
            AboutBox aBox = new AboutBox();
            //temporarily disable topMost so that the about box will be on top
            this.TopMost = false;
            frmSettings.TopMost = false;

            aBox.ShowDialog();

            this.TopMost = cbTopmost.Checked;
            frmSettings.TopMost = cbTopmost.Checked;
        }

        private void numDebugsetspeed_KeyUp(object sender, KeyEventArgs e)
        {
            if (verbunden == false)
            {
                geschwindigkeit = Convert.ToDouble(numDebugsetspeed.Value);
                vmps = geschwindigkeit / 3.6;
                //vAlt = vNeu;
                //vNeu = geschwindigkeit;
                //deltaV = vNeu - vAlt;
                lblV.Text = String.Format("{0:0.0}", geschwindigkeit); //show current speed
            }
        }

        int clicks = 0;
        private void lblSifa_Click(object sender, EventArgs e)
        {
            //TODO
            //if (clicks > 2)
            //    clicks = 0;

            //if (clicks == 0)
            //{
            //    double faktor = 0.6;
            //    lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
            //    lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
            //    lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);

            //    clicks++;
            //}
            //else if (clicks == 1)
            //{
            //    double faktor = 0.8;
            //    lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
            //    lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
            //    lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);

            //    clicks++;
            //}
            //else if (clicks == 2)
            //{
            //    double faktor = 1.3;
            //    lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
            //    lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
            //    lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);

            //    clicks++;
            //}
            //else if (clicks == 3)
            //{
            //    double faktor = 1;
            //    lblSifa.Width = Convert.ToInt32(labelsifadefaultwidth * faktor);
            //    lblSifa.Height = Convert.ToInt32(labelsifadefaultheight * faktor);
            //    lblFlag.Width = Convert.ToInt32(labelflagdefaultwidth * faktor);

            //    clicks++;
            //}

        }

        private void timerResetSifaschalter_Tick(object sender, EventArgs e)
        {
            schaltersifa = 0;
            lblDebugsifaschalter.Text = schaltersifa.ToString();
            timerResetSifaschalter.Enabled = false;
            lblDebugtimerresetsifa.Text = timerResetSifaschalter.Enabled.ToString();
        }

        private void timerCheckSifaschalter_Tick(object sender, EventArgs e)
        {
            //if (schaltersifa == 2)
            //{
            //    SetRR();
            //    schaltersifa = 0; //TODO: check if this is the right place
            //}            
        }

        private void cbHidesettings_CheckedChanged(object sender, EventArgs e)
        {
            //TEST
            if (hasMoved && cbHidesettings.Checked)
                pnlRight.Visible = false;
        }

        public void createSettingsForm()
        {
            
        }
       
        

        private void cbSettingsSeparate_CheckedChanged(object sender, EventArgs e)
        {
            //bool hideSettingsCheckedOLD = cbHidesettings.Checked; //stores the user checked box value, -- "!" because value has already changed!
            cbHidesettings.Checked = !cbSettingsSeparate.Checked; //settings shall not be autohidden if on a separate form

            //TEST
            Point pnlRightOldPosition = new Point(pnlRight.Location.X, pnlRight.Location.Y);
            

            if (cbSettingsSeparate.Checked)
            {
                //TODO: does not yet work, why? Location is determined correctly
                frmSettings.StartPosition = FormStartPosition.Manual;
                frmSettings.Location = new Point(this.Location.X + 200, this.Location.Y);

                this.Controls.Remove(pnlRight); // removing settings panel from main form
                frmSettings.Controls.Add(pnlRight); //adding settings panel to settings form

                //TEST
                pnlRight.Location = new Point(0, 0);

                settingsAreSeparated = true;
                //TEST
                //this.pnlRight.Visible = false;

                frmSettings.Show();
                
            }
            else //if user does not want separated settings 
            {
                
                this.pnlRight.Location = new Point(pnlLeft.Location.X + pnlLeft.Width + 10, pnlLeft.Location.Y);
                this.Controls.Add(pnlRight);
                //cbHidesettings.Checked = hideSettingsCheckedOLD; // restore value from before settings were separated                
                this.pnlRight.Visible = true;
                
                settingsAreSeparated = false;

                frmSettings.Hide();
            }
        }

        private void cbTime_CheckedChanged(object sender, EventArgs e)
        {
            lblTime.Visible = cbTime.Checked;
        }

        private void rbUnitmps_CheckedChanged(object sender, EventArgs e)
        {
            lblkmh.Text = "m/s";
        }

        private void rbUnitkph_CheckedChanged(object sender, EventArgs e)
        {
            lblkmh.Text = "km/h";
        }

        private void grpManageSettings_Enter(object sender, EventArgs e)
        {

        }

        
          
    }
}
