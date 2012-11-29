using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading; //
using System.Diagnostics; // für Stoppuhr
using Zusi_Datenausgabe; //DEBUG: v1.0.0


/* ZusiTCPDemoApp
 * This example shows basic usage of Andreas Karg's Zusi TCP interface for .Net.
 * It is published under the GNU General Public License v3.0. Base your own work on it, play around, do what you want. :-)
 * 
 * 
 * Using the interface requires three steps:
 * - Write one or more handler methods
 * - Create a ZusiTcpConn object, passing basic parameters
 * - Tell your ZusiTcpConn object what measures you want to receive
 * 
 * Everything else is explained below. */

namespace ZusiTCPDemoApp
{
    public partial class CMainWindow : Form
    {
        // We do want to have a ZusiTcpConn object, so here's the declaration
        private ZusiTcpConn MyTCPConnection;

        // Initalize a new stopwatch
        Stopwatch stopwatch = new Stopwatch();

        //TODO: Mit Preferences laden
        //Initialisieren der default-Farben für Tag- und Nachtmodus
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

        //Streckenmeter: Anzeige in Metern oder Kilometern?
        //1000: streckenmeter:1000 = Darstellung in km , 1 = Darstellung in Metern
        int StreckenmeterDarstfaktor = 1000;

           

        public CMainWindow()
        {
            InitializeComponent();          

            

            //System-Tab anzeigen damit ggf. eine Verbindung zum TCP-Server aufgebaut werden kann
            tabEinstellungen.SelectTab("tabSystem");

            //nicht funktionierende Checkboxes deaktivieren
            //TODO

            cbFokuszurueck.Enabled = false;
            
            /* When the application window is created, we create our new connection class as well.
             * ReceiveEvent<T> is a generic delegate type for you to use. See the Object Browser for details. */

            MyTCPConnection = new ZusiTcpConn(
             "ZusiMeter v0.4",                            // The name of this application (Shows up on the server's list)
             // ClientPriority.Low                                 // The priority with which the server should treat you
             ClientPriority.High,                            
             new ReceiveEvent<float>(HandleIncomingData),   // A delegate method for the connection class to call when it receives float data (may be null)
             null,                                          // A delegate method for the connection class to call when it receives string data (may be null)
             null                                           //DEBUG: Using v 1.0.0 of Zusi-Datenausgabe.dll
                                                            // (Using v 1.1.6 of Zusi-Datenausgabe.dll)
            );

            


            MyTCPConnection.RequestData(2654); // "Bremshundertstel"
            MyTCPConnection.RequestData(2562); // "Druck Hauptluftleitung"
            MyTCPConnection.RequestData(2561); // "Geschwindigkeit"
            MyTCPConnection.RequestData(2563); // "Druck Bremszylinder"
            MyTCPConnection.RequestData(2645); // "Strecken-Km in Metern"
            MyTCPConnection.RequestData(2599); // "LM Schleudern"     
            MyTCPConnection.RequestData(2596); // "LM Sifa "
            MyTCPConnection.RequestData(2576); // "Fahrstufe"
            MyTCPConnection.RequestData(2611); // "Schalter Fahrstufen"
            MyTCPConnection.RequestData(2646); // "Türen"
            //TODO MyTCPConnection.RequestData(2656); // "Zugdatei"
            

        }

       

        public void ResetDebugLabels() // Resetting all the labels on the Debug panel to their initial state
        {
            lblDebugBremsen.Text = "(gebremst?)";
            lblDebugScharf.Text = "(scharf?)";
            lblDebugSchleudern.Text = "(geschleudert?)";            
        }

        public void ResetGlobals() // Resetting all global variables
        {

            lblFlag.Visible = false;
            hasMoved = false;
            pnlRight.Visible = true;
            abbruch = false;
            scharf = false;
            vMaxErreicht = false;
            gebremst = false;
 
        }

       
        public void Connect()
        {

            String server = Convert.ToString(tbServer.Text);
            int port = Convert.ToInt16(tbPort.Text);

            {
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
        }

        public bool abbruch;

        double vorgabe, entfernung;
        double streckenmeter = 0;
        bool hasMoved = false;
        double brh;
        double maxVerz = 1; //maximale Verzögerung 
        bool scharf = false; //wurde scharf angehalten?
        bool gebremst = false; // wurde nach dem Beschleunigen gebremst?
        bool verbunden = false;


        //TEST
        double vAlt = 0, vNeu = 0, deltaV; //Zur Messung der Verzögerung
        double vTemp = 0;

        //TODO: TEST: Setting a maximum reached speed vReached
        double vReached = 0;



//###HANDLE INCOMING DATA###//
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
                lblDebugtueren.Text = tuerwert.ToString();

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
                    lblFahrstufe.Text = String.Format("{0}", dataSet.Value);
                else
                    lblFahrstufe.Text = "--";
            }

           

        }
//###HANDLE INCOMING DATA ENDE###//

        public bool vMaxErreicht = false;


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

        private void btnSettings_Click(object sender, EventArgs e)
        {
            /* TODO: Je nachdem ob pnlRight ständig sichtbar sein soll ein- oder ausblenden
            
            if (pnlRight.Visible == false) //DEBUG  && settingsVisible == false)
            {
                // settingsVisible = true; // sorgt für eine ständige Sichtbarkeit
                pnlRight.Visible = true;
                btnSettings.Text = "Einstellungen <<<";
            }
            if (pnlRight.Visible == true) //DEBUG && settingsVisible == true) //ansonsten ein- und ausblenden
            {
                // settingsVisible = false;
                pnlRight.Visible = false;
                btnSettings.Text = "Einstellungen >>>";
            }
             */

            //DEBUG

            pnlRight.Visible = !pnlRight.Visible;
            settingsVisible = true; // ständig sichtbar
                                
        }

        private void btnConnect_Click(object sender, EventArgs e)
        {
            Connect();
        }

       
        private void btnFlag_Click(object sender, EventArgs e)
        {
            //TEST
            lblFlag.Visible = !lblFlag.Visible;
            lblFlag.BackColor = Color.Orange;
            lblFlag.Text = "TEST!";
        }

       
        
        //TEST debugging-modus speichern
        public bool debugging = false;
        // TEST Sichtbarkeit des rechten Panels speichern
        public bool settingsVisible = false;

        private void btnDebugpanel_Click(object sender, EventArgs e)
        {           
            if(debugging == true)
            {
                pnlDebug.Visible = false;
                debugging = false;
            }
            else if (debugging == false)
            {
                pnlDebug.Visible = true;
                debugging = true;
            }
        }

        private void timerFlag_Tick(object sender, EventArgs e)
        {
            lblFlag.Visible = false;
            timerFlag.Stop();
        }

        bool nightmode = false;

        public void setNightmode()
        {

            BackColor = formnightcolor; // Hintergrund der Form
            statusStrip1.BackColor = formnightcolor;

            ///Labels
            foreach (Label label in pnlData1.Controls)
            {
                label.ForeColor = labelnightcolor;
            }
            foreach (Label label in pnlData2.Controls)
            {
                label.ForeColor = labelnightcolor;
            }
            /*foreach (Label label in tabAnzeigen.Controls)
            {
                label.ForeColor = labelnightcolor;
            }
            foreach (Label label in tabDarstellung.Controls)
            {
                label.ForeColor = labelnightcolor;
            }
            foreach (Label label in tabSystem.Controls)
            {
                label.ForeColor = labelnightcolor;
            }*/

            //Textboxes
            /*foreach (TextBox tb in tabSystem.Controls)
            {
                tb.BackColor = textboxnightcolor;
            }
            */
            tbPort.BackColor = textboxnightcolor;
            tbServer.BackColor = textboxnightcolor;
            tbVerz.BackColor = textboxnightcolor;
            

            //Panels
            foreach (TabPage tab in tabEinstellungen.Controls)
            {
                tab.BackColor = panelnightcolor;
            }
            
        }

        public void setDaymode()
        {
            BackColor = formdaycolor; // Hintergrund der Form
            statusStrip1.BackColor = formdaycolor;
            
            
            foreach (Label label in pnlData1.Controls)
            {
                label.ForeColor = labeldaycolor;
            }
            foreach (Label label in pnlData2.Controls)
            {
                label.ForeColor = labeldaycolor;
            }

            tbServer.BackColor = textboxdaycolor;
            tbPort.BackColor = textboxdaycolor;
            tbVerz.BackColor = textboxdaycolor;

            //Panels
            foreach (TabPage tab in tabEinstellungen.Controls)
            {
                tab.BackColor = paneldaycolor;
            }
        }

        private void btnNacht_Click(object sender, EventArgs e)
        {
            if (nightmode == false)
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

        }

        private void CMainWindow_Load(object sender, EventArgs e)
        {

        }

        private void listAnzeige_1_SelectedIndexChanged(object sender, EventArgs e)
        {
           
           
        }

        public void enableLabels(String lblname)
        {
            Object label = lblname.ToString();

            
        }

        private void cbGeschwindigkeit_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGeschwindigkeit.Checked == false)
            {
                pnlData1.Controls.Remove(lblV);
                pnlData1.Controls.Remove(lblkmh);
            }
            else
            {
                pnlData1.Controls.Add(lblV, 0, 0);
                pnlData1.Controls.Add(lblkmh, 1, 0);
            }
        }

        private void cbStreckenmeter_CheckedChanged(object sender, EventArgs e)
        {
            if (cbStreckenmeter.Checked == false)
            {
                pnlData1.Controls.Remove(lblMeter);
                pnlData1.Controls.Remove(lblm);
            }
            else
            {
                pnlData1.Controls.Add(lblMeter, 0, 1);
                pnlData1.Controls.Add(lblm, 1, 1);
            }
        }

        private void cbDruckhll_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDruckhll.Checked == false)
            {
                pnlData2.Controls.Remove(lblHlldruck);
                pnlData2.Controls.Remove(lblbarhll);
            }
            else
            {
                pnlData2.Controls.Add(lblHlldruck, 0, 1);
                pnlData2.Controls.Add(lblbarhll, 1, 1);
            }
        }

        private void cbDruckbz_CheckedChanged(object sender, EventArgs e)
        {
            if (cbDruckbz.Checked == false)
            {
                pnlData2.Controls.Remove(lblBzdruck);
                pnlData2.Controls.Remove(lblbarbz);
            }
            else
            {
                pnlData2.Controls.Add(lblBzdruck, 0, 2);
                pnlData2.Controls.Add(lblbarbz, 1, 2);
            }
        }

        private void cbBrh_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBrh.Checked == false)
            {
                pnlData2.Controls.Remove(lblBrh);
                pnlData2.Controls.Remove(lblbremsh);
            }
            else
            {
                pnlData2.Controls.Add(lblBrh, 0, 0);
                pnlData2.Controls.Add(lblbremsh, 1, 0);
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void pnlData_Paint(object sender, PaintEventArgs e)
        {

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

        public void ShowFlagtest()
        {
            lblFlag.Visible = true;
            lblFlag.Text = "TEST";
            timerFlag.Start(); //Zeigt für eine Sekunde ein Testflag

        }

        private void cbGrunddaten_CheckedChanged(object sender, EventArgs e)
        {
            if (cbGrunddaten.Checked == false)
            {
                pnlLeft.Controls.Remove(pnlData1);

                foreach (CheckBox cbox in pnlGrunddaten.Controls)
                {
                    cbox.Checked = false;
                }

            }
            else
            {
                pnlLeft.Controls.Add(pnlData1);
                foreach (CheckBox cbox in pnlGrunddaten.Controls)
                {
                    cbox.Checked = true;
                }
                //TODO: Wiederherstellen der checkboxes?
            }
        }

        private void cbBremsen_CheckedChanged(object sender, EventArgs e)
        {
            if (cbBremsen.Checked == false)
            {
                pnlLeft.Controls.Remove(pnlData2);                
                foreach (CheckBox cbox in pnlBremsen.Controls)
                {
                    cbox.Checked = false;
                }

            }
            else
            {
                pnlLeft.Controls.Add(pnlData2);
                foreach (CheckBox cbox in pnlBremsen.Controls)
                {
                    cbox.Checked = true;
                }
                //TODO: Wiederherstellen der checkboxes?
            }
        }

        private void cbLmtueren_CheckedChanged(object sender, EventArgs e)
        {
            if (cbLmtueren.Checked == false)
            {
                pnlData1.Controls.Remove(lblTueren);
                pnlData1.Controls.Remove(lbltuer);
            }
            else
            {
                pnlData1.Controls.Add(lblTueren, 0, 3);
                pnlData1.Controls.Add(lbltuer, 1, 3);
                ShowFlagtest();
                lblFlag.Visible = true; 
            }
        }

        private void cbFahrstufe_CheckedChanged(object sender, EventArgs e)
        {
            if (cbFahrstufe.Checked == false)
            {
                pnlData1.Controls.Remove(lblFahrstufe);
                pnlData1.Controls.Remove(lblfahrst);
            }
            else if (cbFahrstufe.Checked)// wenn cbFahrstufe gecheckt
            {
                cbFahrstufenschalter.Checked = false; //TODO: Doppelauswahl sinnvoll von Fahrstufe und -Schalter?

                pnlData1.Controls.Add(lblFahrstufe, 0, 2);
                pnlData1.Controls.Add(lblfahrst, 1, 2);
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
                pnlData1.Controls.Remove(lblFahrstufe);
                pnlData1.Controls.Remove(lblfahrst);
            }
            else if(cbFahrstufenschalter.Checked) // wenn cbFahrstufenschalter gecheckt
            {
                cbFahrstufe.Checked = false; //TODO: Doppelauswahl sinnvoll von Fahrstufe und -Schalter?

                pnlData1.Controls.Add(lblFahrstufe, 0, 2);
                pnlData1.Controls.Add(lblfahrst, 1, 2);
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

          
    }
}
