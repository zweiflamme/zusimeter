using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics; // usage of stopwatch
using Zusi_Datenausgabe; //TODO: v1.0.0
using System.Runtime.InteropServices; //to hand over the focus to Zusi main window

namespace Zielbremsen
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
             "ZusiMeter v0.4",                            // The name of this application (Shows up on the server's list)
             ClientPriority.High,                            
             new ReceiveEvent<float>(HandleIncomingData),   // A delegate method for the connection class to call when it receives float data (may be null)
             null,                                          // A delegate method for the connection class to call when it receives string data (may be null)
             null                                           //TODO: need to make use of the new DLL v1.1.6                                                            
            );

            #region RequestData //MUST STAY IN CMainWindow()!
            MyTCPConnection.RequestData(2654); // "Bremshundertstel"
            MyTCPConnection.RequestData(2562); // "Druck Hauptluftleitung"
            MyTCPConnection.RequestData(2561); // "Geschwindigkeit"
            MyTCPConnection.RequestData(2563); // "Druck Bremszylinder"
            MyTCPConnection.RequestData(2612); // "Schalter Führerbremsventil"
            MyTCPConnection.RequestData(2645); // "Strecken-Km in Metern"
            MyTCPConnection.RequestData(2599); // "LM Schleudern"     
            MyTCPConnection.RequestData(2596); // "LM Sifa "
            MyTCPConnection.RequestData(2576); // "Fahrstufe"
            MyTCPConnection.RequestData(2611); // "Schalter Fahrstufen"
            MyTCPConnection.RequestData(2646); // "Türen"
            //TODO MyTCPConnection.RequestData(2656); // "Zugdatei"
            //TODO MyTCPConnection.RequestData(2615); // "Schalter AFB-Geschwindigkeit"
            MyTCPConnection.RequestData(2574); // "LZB/AFB Soll-Geschwindigkeit"
            MyTCPConnection.RequestData(2616); // "Schalter AFB ein/aus"
            MyTCPConnection.RequestData(2578); // "AFB Soll-Geschwindigkeit"
            MyTCPConnection.RequestData(2636); // "LZB Soll-Geschwindigkeit"
            MyTCPConnection.RequestData(2573); // "LZB Ziel-Geschwindigkeit"
            MyTCPConnection.RequestData(2635); // "LM LZB-Zielweg (ab 0)"   
            #endregion 

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
        public bool settingsVisible = false; //for determining if the settings panel shall auto hide
        bool nightmode = false; //for letting the user choose between two different color sets
        //TODO: maybe it makes sense to determine day- and nightmode automatically when receiving daytime from Zusi

        #endregion

        private void CMainWindow_Load(object sender, EventArgs e) //on loading of the main window...
        {
            //showing 'System' tab first so that the user is able to establish a connection to the TCP server
            tabEinstellungen.SelectTab("tabSystem");   

            //if a narrow tab page is selected (such as tabSystem)...
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabSystem"])
            {
                tabEinstellungen.Width = 202;
            }
            //TEST removing unwanted controls that should not be showing when first showing the form
            //TODO: is there a better way? later on this will be controlled by user prefs            
            pnlDataAFBLZB.Controls.Remove(lbllzbvsoll);
            pnlDataAFBLZB.Controls.Remove(lblLZBsollgeschw);
            pnlDataAFBLZB.Controls.Remove(lbllzbvziel);
            pnlDataAFBLZB.Controls.Remove(lblLZBzielgeschw);
            pnlDataAFBLZB.Controls.Remove(lbllzbzielw);
            pnlDataAFBLZB.Controls.Remove(lblLZBzielweg);

            pnlDataBremsen.Controls.Remove(lblfbv);
            pnlDataBremsen.Controls.Remove(lblFbventil);
            pnlDataBremsen.Controls.Remove(lbldynbrem);
            pnlDataBremsen.Controls.Remove(lblDynbremse);
            pnlDataBremsen.Controls.Remove(lblzusbr);
            pnlDataBremsen.Controls.Remove(lblZusbremse);

            //adding a global function for all checkboxes, main reason is to determine if user has clicked
            //a checkbox, if so it's being checked if Zusi shall have the window focus back
            //TODO: find a better and more elegant way to detect user interaction with ALL controls on the form
            foreach (CheckBox c in pnlBremsen.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            foreach (CheckBox c in pnlGrunddaten.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            foreach (CheckBox c in pnlAFBLZB.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            foreach (CheckBox c in pnlSchalterst.Controls)
            {
                c.CheckedChanged += new System.EventHandler(this.Control_CheckedChanged);
            }
            
        }

        #region HandleIncomingData
        private void HandleIncomingData(DataSet<float> dataSet)
        {
            if (dataSet.Id == MyTCPConnection["Bremshundertstel"]) // 2654
            {
                if (dataSet.Value > 0)
                {
                    setStatus("Verbunden");

                    brh = Convert.ToDouble(dataSet.Value);
                    lblBrh.Text = String.Format("{0}", brh);
                }

            }
            else if (dataSet.Id == MyTCPConnection["Geschwindigkeit"]) // 2561
            {
                if (verbunden)
                {
                    double geschwindigkeit = dataSet.Value;

                    if (geschwindigkeit > 0.1) hasMoved = true;

                    if (hasMoved == true && settingsVisible == false && debugging == false)
                    {
                        pnlRight.Visible = false;
                        //TODO: In eigener Methode unterbringen
                    }

                    if (hasMoved == true && geschwindigkeit == 0) //Lok ist zum Stillstand gekommen
                    {
                        hasMoved = false;

                        maxVerz = Convert.ToDouble(tbVerz.Text);
                        //TODO: Scharfes Anhalten wieder überprüfen
                        if (deltaV < -maxVerz) //wenn scharf angehalten wurde
                        {
                            lblFlag.Visible = true;
                            lblFlag.Text = "scharf angehalten";
                            scharf = true;
                            timerFlag.Start(); // TODO: Bis zum Beschleunigen oder nach x Sekunden verschwinden lassen
                        }
                    }

                    lblV.Text = String.Format("{0:0.0}", dataSet.Value); //Geschwindigkeit anzeigen

                }
            }
            else if (dataSet.Id == MyTCPConnection["Druck Bremszylinder"]) // 2563
            {

                if (verbunden)
                {
                    float bzdruck = dataSet.Value; //TODO: Was kann man damit noch anstellen?                
                    lblBzdruck.Text = String.Format("{0:0.0}", bzdruck);
                }

            }
            else if (dataSet.Id == MyTCPConnection["Druck Hauptluftleitung"]) // 2562
            {
                float hlldruck = dataSet.Value; //TODO: Was kann man damit noch anstellen?                
                lblHlldruck.Text = String.Format("{0:0.0}", hlldruck);
            }

            else if (dataSet.Id == MyTCPConnection["LM Schleudern"]) // 2599
            {
                if (verbunden)
                {
                    if (dataSet.Value > 0)
                    {
                        lblFlag.Text = "Schleudern!";
                        lblFlag.Visible = true;
                        timerFlag.Start(); //Nach x Sekunden verschwindet das Label, TODO: Sekunden als Parameter übergeben
                    }
                }
            }
            else if (dataSet.Id == MyTCPConnection["Schalter Führerbremsventil"])
            {
                lblFbventil.Text = dataSet.Value.ToString();
            }
            else if (dataSet.Id == MyTCPConnection["Strecken-Km"]) // 2645
            {
                if (verbunden && dataSet.Value > 0)
                {
                    streckenmeter = Convert.ToDouble(dataSet.Value);
                    lblMeter.Text = String.Format("{0:0.0}", streckenmeter / StreckenmeterDarstfaktor); //Streckenmeter-Darstellungsfaktor
                }
                else lblMeter.Text = "---";
            }
            else if (dataSet.Id == MyTCPConnection["LM Sifa"]) // 2596
            {
                if (dataSet.Value > 0)
                {
                    lblSifa.Text = "SIFA";
                    lblSifa.BackColor = Color.White;
                }
                else
                {
                    lblSifa.Text = "";
                    lblSifa.BackColor = Color.DarkGray;
                }
            }
            else if (dataSet.Id == MyTCPConnection["Fahrstufe"] && cbFahrstufe.Checked == true) // 2576 ) //ENTWEDER SCHALTER ODER FAHRSTUFE
            {
                if (dataSet.Value > -50 | dataSet.Value < 50) //TODO: ist das sinnvoll? wieviele Fahrstufen gibt es maximal?
                    lblFahrstufe.Text = String.Format("{0}", dataSet.Value);
                else
                    lblFahrstufe.Text = "--";
            }
            else if (dataSet.Id == MyTCPConnection["Türen"])
            {

                //TODO

                //INFO:
                //Türstatus
                //größer als 9: geschlossen
                //größer als 7: schließen
                //größer als 5: schließen(?)
                //größer als 4: Fahrgäste i.O.
                //größer als 1, kleiner als 5: TODO

                //DEBUG
                double tuerwert = dataSet.Value;


                //TEST
                //if (tuerwert > 9E-45) lblDebugtuerbool.Text = "größer 9E-45";
                //else if (tuerwert < 9E-45) lblDebugtuerbool.Text = "kleiner 9E-45";
                //else lblDebugtuerbool.Text = "anderer Wert";


                if (tuerwert > 7E-45 && cbLmtueren.Checked) // geschlossen
                {
                    lblFlag.Visible = false;
                    lblFlag.Text = "";
                    lblTueren.Text = "zu";
                }
                else if (tuerwert < 2E-45 && tuerwert > 0 && cbLmtueren.Checked) //geöffnet
                {
                    lblFlag.Visible = true;
                    lblFlag.Text = "Türen geöffnet";
                    lblTueren.Text = "offen";
                }
                else if (tuerwert > 5E-45 && tuerwert < 7E-45) //Schließvorgang
                {
                    lblTueren.Text = "schließen";
                }
                else if (tuerwert > 4E-45 && tuerwert < 5E-45)  //Fahrgäste i.O.
                {
                    lblTueren.Text = "Fahrgäste i.O.";
                }
                else if (tuerwert == 0)  //Türfreigabe erfolgt
                {
                    lblTueren.Text = "freigegeben";
                }

            }
            else if (dataSet.Id == MyTCPConnection["Schalter Fahrstufen"] && cbFahrstufenschalter.Checked == true) //ENTWEDER SCHALTER ODER FAHRSTUFE
            {
                if (dataSet.Value > -50 | dataSet.Value < 50) //TODO: ist das sinnvoll? wieviele Fahrstufen gibt es maximal?
                {
                    double fahrschalter = dataSet.Value - fahrschalterneutral;
                    lblFahrstufe.Text = String.Format("{0}", fahrschalter);
                }
                else
                    lblFahrstufe.Text = "--";
            }


            else if (dataSet.Id == MyTCPConnection["Schalter AFB ein/aus"])
            {
                if (dataSet.Value > 0)
                    afbistein = true;
                else
                    afbistein = false;

                if (afbistein)
                {
                    lblafbeinaus.Font = new Font(lblafbeinaus.Font, FontStyle.Bold);
                    lblafbeinaus.Text = "AFB ein";
                }
                else
                {
                    lblafbeinaus.Font = new Font(lblafbeinaus.Font, FontStyle.Regular);
                    lblafbeinaus.Text = "AFB aus";
                }

            }
            else if (dataSet.Id == MyTCPConnection["AFB Soll-Geschwindigkeit"])
            //TEST else if(dataSet.Id == MyTCPConnection["LZB/AFB Soll-Geschwindigkeit"])
            {
                double afbvschalter = dataSet.Value;


                //TODO: Schauen ob LZB-vSoll höher ist!
                lblAFBgeschwindigkeit.Text = String.Format("{0} km/h", afbvschalter);
            }
            else if (dataSet.Id == MyTCPConnection["LZB Soll-Geschwindigkeit"])
            {
                double lzbsoll = dataSet.Value;
                lblLZBsollgeschw.Text = String.Format("{0}", lzbsoll);
            }
            else if (dataSet.Id == MyTCPConnection["LZB Ziel-Geschwindigkeit"])
            {
                double lzbziel = dataSet.Value;
                lblLZBzielgeschw.Text = String.Format("{0}", lzbziel);
            }
            else if (dataSet.Id == MyTCPConnection["LM LZB Zielweg (ab 0)"])
            {
                double lzbweg = dataSet.Value;
                lblLZBzielweg.Text = String.Format("{0}", lzbweg);
            }

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

            }
            else if (statusNeu == "Warte")
            {

                //TODO: Anzeigedaten anzeigen
                btnConnect.Text = "Trennen";
                pnlRight.Visible = true;
                tabEinstellungen.SelectTab("tabAnzeigen");
                lblVerbstatus.Text = "Warte auf Zusi";

            }
            else if (statusNeu == "Verbunden")
            {
                verbunden = true;
                lblVerbstatus.Text = "Verbunden mit Zusi";
            }
        }
        #endregion

        #region Night- and Daymode

        public void setNightmode()
        {
            BackColor = formnightcolor; //the whole form's background color
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
        }

        public void setDaymode()
        {
            BackColor = formdaycolor; //the whole form's background color
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
            if (cbAFBgeschw.Checked == false)
            {
                pnlDataAFBLZB.Controls.Remove(lblafbeinaus);
                pnlDataAFBLZB.Controls.Remove(lblAFBgeschwindigkeit);
            }
            else
            {
                pnlDataAFBLZB.Controls.Add(lblafbeinaus, 0, 0);
                pnlDataAFBLZB.Controls.Add(lblAFBgeschwindigkeit, 1, 0);
            }
        }

        private void cbLZBvsoll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLZBvsoll.Checked == false)
            {
                pnlDataAFBLZB.Controls.Remove(lbllzbvsoll);
                pnlDataAFBLZB.Controls.Remove(lblLZBsollgeschw);
            }
            else
            {
                pnlDataAFBLZB.Controls.Add(lbllzbvsoll, 0, 1);
                pnlDataAFBLZB.Controls.Add(lblLZBsollgeschw, 1, 1);
            }
        }

        private void cbLZBvziel_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLZBvziel.Checked == false)
            {
                pnlDataAFBLZB.Controls.Remove(lbllzbvziel);
                pnlDataAFBLZB.Controls.Remove(lblLZBzielgeschw);
            }
            else
            {
                pnlDataAFBLZB.Controls.Add(lbllzbvziel, 0, 2);
                pnlDataAFBLZB.Controls.Add(lblLZBzielgeschw, 1, 2);
            }
        }

        private void cbLZBweg_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLZBweg.Checked == false)
            {
                pnlDataAFBLZB.Controls.Remove(lbllzbzielw);
                pnlDataAFBLZB.Controls.Remove(lblLZBzielweg);
            }
            else
            {
                pnlDataAFBLZB.Controls.Add(lbllzbzielw, 0, 3);
                pnlDataAFBLZB.Controls.Add(lblLZBzielweg, 1, 3);
            }
        }

        private void cbAFBLZB_CheckedChanged(object sender, EventArgs e)
        {
            if (cbAFBLZB.Checked == false)
            {
                pnlLeft.Controls.Remove(pnlDataAFBLZB);

                foreach (CheckBox cbox in pnlAFBLZB.Controls)
                {
                    cbox.Enabled = false;
                }

                cbAFBLZB.Enabled = true; //Als Ausnahme von foreach :) TODO: geht das eleganter?

            }
            else
            {
                pnlLeft.Controls.Add(pnlDataAFBLZB);

                foreach (CheckBox cbox in pnlAFBLZB.Controls)
                {
                    cbox.Enabled = true;
                }

            }
        }

        private void cbGeschwindigkeit_CheckedChanged(object sender, EventArgs e)
        {

            if (cbGeschwindigkeit.Checked == false)
            {
                pnlDataGrunddaten.Controls.Remove(lblV);
                pnlDataGrunddaten.Controls.Remove(lblkmh);
            }
            else
            {
                pnlDataGrunddaten.Controls.Add(lblV, 0, 0);
                pnlDataGrunddaten.Controls.Add(lblkmh, 1, 0);
            }
        }

        private void cbStreckenmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStreckenmeter.Checked == false)
            {
                pnlDataGrunddaten.Controls.Remove(lblMeter);
                pnlDataGrunddaten.Controls.Remove(lblm);
            }
            else
            {
                pnlDataGrunddaten.Controls.Add(lblMeter, 0, 1);
                pnlDataGrunddaten.Controls.Add(lblm, 1, 1);
            }
        }

        private void cbDruckhll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDruckhll.Checked == false)
            {
                pnlDataBremsen.Controls.Remove(lblHlldruck);
                pnlDataBremsen.Controls.Remove(lblbarhll);
            }
            else
            {
                pnlDataBremsen.Controls.Add(lblHlldruck, 0, 1);
                pnlDataBremsen.Controls.Add(lblbarhll, 1, 1);
            }
        }

        private void cbDruckbz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDruckbz.Checked == false)
            {
                pnlDataBremsen.Controls.Remove(lblBzdruck);
                pnlDataBremsen.Controls.Remove(lblbarbz);
            }
            else
            {
                pnlDataBremsen.Controls.Add(lblBzdruck, 0, 2);
                pnlDataBremsen.Controls.Add(lblbarbz, 1, 2);
            }
        }

        private void cbBrh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBrh.Checked == false)
            {
                pnlDataBremsen.Controls.Remove(lblBrh);
                pnlDataBremsen.Controls.Remove(lblbremsh);
            }
            else
            {
                pnlDataBremsen.Controls.Add(lblBrh, 0, 0);
                pnlDataBremsen.Controls.Add(lblbremsh, 1, 0);
            }
        }        

        private void cbLmsifa_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLmsifa.Checked == false)
            {
                pnlLeft.Controls.Remove(lblSifa);                
            }
            else
            {
                pnlLeft.Controls.Add(lblSifa);           
            }
        }

        private void cbLmschleudern_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLmschleudern.Checked == false)
            {
                pnlLeft.Controls.Remove(lblFlag);
               
            }
            else
            {
                pnlLeft.Controls.Add(lblFlag);
                ShowFlagtest();
                lblFlag.Visible = true;                
            }
        }        

        private void cbGrunddaten_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGrunddaten.Checked == false)
            {
                pnlLeft.Controls.Remove(pnlDataGrunddaten);                

                foreach (CheckBox cbox in pnlGrunddaten.Controls)
                {
                    cbox.Enabled = false;                    
                }

                cbGrunddaten.Enabled = true; //Als Ausnahme von foreach :) TODO: geht das eleganter?

            }
            else
            {
                pnlLeft.Controls.Add(pnlDataGrunddaten);
                
                foreach (CheckBox cbox in pnlGrunddaten.Controls)
                {
                    cbox.Enabled = true;                   
                }           

            }
        }

        private void cbBremsen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBremsen.Checked == false)
            {
                pnlLeft.Controls.Remove(pnlDataBremsen);                
                foreach (CheckBox cbox in pnlBremsen.Controls)
                {
                    cbox.Enabled = false;                    
                }

                cbBremsen.Enabled = true; //Als Ausnahme von foreach :) TODO: geht das eleganter?
            }
            else
            {
                pnlLeft.Controls.Add(pnlDataBremsen);
                foreach (CheckBox cbox in pnlBremsen.Controls)
                {
                    cbox.Enabled = true;
                }                
            }
        }

        private void cbLmtueren_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLmtueren.Checked == false)
            {
                pnlDataGrunddaten.Controls.Remove(lblTueren);
                pnlDataGrunddaten.Controls.Remove(lbltuer);
            }
            else
            {
                pnlDataGrunddaten.Controls.Add(lblTueren, 0, 3);
                pnlDataGrunddaten.Controls.Add(lbltuer, 1, 3);
                ShowFlagtest();
                lblFlag.Visible = true; 
            }
        }

        private void cbFahrstufe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFahrstufe.Checked == false)
            {
                pnlDataGrunddaten.Controls.Remove(lblFahrstufe);
                pnlDataGrunddaten.Controls.Remove(lblfahrst);
            }
            else if (cbFahrstufe.Checked)// wenn cbFahrstufe gecheckt
            {
                cbFahrstufenschalter.Checked = false; //TODO: Doppelauswahl sinnvoll von Fahrstufe und -Schalter?

                pnlDataGrunddaten.Controls.Add(lblFahrstufe, 1, 2);
                pnlDataGrunddaten.Controls.Add(lblfahrst, 0, 2);
                lblfahrst.Text = "Fahrstufe";
            }
        }

        private void pnlRight_Paint(object sender, PaintEventArgs e)
        {

        }

        private void cbFahrstufenschalter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFahrstufenschalter.Checked == false && cbFahrstufe.Checked == false)
            {
                pnlDataGrunddaten.Controls.Remove(lblFahrstufe);
                pnlDataGrunddaten.Controls.Remove(lblfahrst);
            }
            else if(cbFahrstufenschalter.Checked) // wenn cbFahrstufenschalter gecheckt
            {
                cbFahrstufe.Checked = false; //TODO: Doppelauswahl sinnvoll von Fahrstufe und -Schalter?

                pnlDataGrunddaten.Controls.Add(lblFahrstufe, 1, 2);
                pnlDataGrunddaten.Controls.Add(lblfahrst, 0, 2);
                lblfahrst.Text = "Fahrschalter";
            }
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
            if (cbSchalterst.Checked == false)
            {
                cbSchalterst.Enabled = true;
            }
            else
            {
                pnlSchalterst.Controls.Add(label5);
                pnlSchalterst.Controls.Add(numFahrschneutral);
                cbFahrstufenschalter.Enabled = true;
            }

        }

        #endregion
        
        #region User Tab Interaction

        private void tabEinstellungen_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if(tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabSystem"])
            {
                tabEinstellungen.Width = 202;
                //TODO einen Weg finden damit auch bei breitem tabEinstellungen das Debug Panel angezeigt wird
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabDarstellung"])
            {
                tabEinstellungen.Width = 202;
                //TODO einen Weg finden damit auch bei breitem tabEinstellungen das Debug Panel angezeigt wird
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            if (tabEinstellungen.SelectedTab == tabEinstellungen.TabPages["tabAnzeigen"])
            {
                tabEinstellungen.Width = 420;
                //TODO einen Weg finden damit auch bei breitem tabEinstellungen das Debug Panel angezeigt wird
                int offsetX = pnlSettings.Location.X + pnlSettings.Width + 10;
                pnlDebug.Location = new Point(offsetX, pnlDebug.Location.Y);
            }
            
        }

        #endregion

        #region User Button Interaction

        //setting user colors for night- and daymode
        private void btnFarbeNacht_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }
        private void btnFarbeTag_Click(object sender, EventArgs e)
        {
            colorDialog1.ShowDialog();
        }

        //if the user clicks the "Einstellungen" button...
        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlRight.Visible = !pnlRight.Visible; //if visible make invisible and vice versa
            settingsVisible = true; //once btnSettings has been clicked, the settings panel shall not auto hide                                
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
            }
            else if (debugging == false) //else turn debugging mode on
            {
                pnlDebug.Visible = true;
                debugging = true;

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
          
    }
}
