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

        public CMainWindow()
        {
            InitializeComponent();

            /* When the application window is created, we create our new connection class as well.
             * ReceiveEvent<T> is a generic delegate type for you to use. See the Object Browser for details. */

            MyTCPConnection = new ZusiTcpConn(
             "ZusiMeter v0.1",                            // The name of this application (Shows up on the server's list)
             // ClientPriority.Low                                 // The priority with which the server should treat you
             ClientPriority.High,                            
             new ReceiveEvent<float>(HandleIncomingData),   // A delegate method for the connection class to call when it receives float data (may be null)
             null,                                          // A delegate method for the connection class to call when it receives string data (may be null)
             null                                           //DEBUG: Using v 1.0.0 of Zusi-Datenausgabe.dll
                                                            // (Using v 1.1.6 of Zusi-Datenausgabe.dll)
            );



            MyTCPConnection.RequestData(2654); // "Bremshundertstel"
            MyTCPConnection.RequestData(2561); // "Geschwindigkeit"
            MyTCPConnection.RequestData(2563); // "Druck Bremszylinder"
            MyTCPConnection.RequestData(2645); // "Strecken-Km in Metern"
            MyTCPConnection.RequestData(2599); // "LM Schleudern"     
            MyTCPConnection.RequestData(2596); // "LM Sifa "
        }

       

        public void ResetDebugLabels() // Resetting all the labels on the Debug panel to their initial state
        {
            lblDebugBremsen.Text = "(gebremst?)";
            lblDebugScharf.Text = "(scharf?)";
            lblDebugSchleudern.Text = "(geschleudert?)";
            lblDebugVreached.Text = "(vReached)";
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

        

        //TODO: Uhrzeit verwenden
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

                    if (hasMoved == true && geschwindigkeit == 0) //Lok ist zum Stillstand gekommen
                    {                        
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

                    lblV.Text = String.Format("{0:f}", dataSet.Value); //Geschwindigkeit anzeigen

                }
            }
            else if (dataSet.Id == MyTCPConnection["Druck Bremszylinder"]) // 2563
            {

                if (verbunden)
                {
                    //TODO: Druck Bremszylinder anzeigen
                }

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
                    else
                    {
                        //TEST: ist überflüssig?
                        //lblFlag.Text = "";
                        //lblFlag.Visible = false;
                    }
                }

            }
            else if (dataSet.Id == MyTCPConnection["Strecken-Km"]) // 2645
            {
                if (verbunden && dataSet.Value > 0)
                {
                        streckenmeter = Convert.ToDouble(dataSet.Value);
                        lblMeter.Text = String.Format("{0:f}", streckenmeter);
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
        }

        public bool vMaxErreicht = false;


        public void setStatus(String statusNeu)
        {
            if (statusNeu == "Getrennt")
            {
                btnConnect.Text = "Verbinden";               
             
            }
            else if (statusNeu == "Warte")
            {
                btnConnect.Text = "Trennen";
                pnlRight.Visible = true;
                
            }
            else if (statusNeu == "Verbunden")
            {          
                verbunden = true;
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            pnlRight.Visible = !pnlRight.Visible;
                        
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
            lblFlag.Text = "TEST";
        }

       
        
        //TEST debugging-modus speichern
        public bool debugging = false;

        private void btnDebugpanel_Click(object sender, EventArgs e)
        {
            if (debugging == true)
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

            BackColor = Color.DarkGray; // Hintergrund der Form
            lblV.ForeColor = Color.WhiteSmoke;
            lblMeter.ForeColor = Color.WhiteSmoke;
            lblBrh.ForeColor = Color.WhiteSmoke;

            tbServer.BackColor = Color.LightGray;
            tbPort.BackColor = Color.LightGray;
        }

        public void setDaymode()
        {
            BackColor = CMainWindow.DefaultBackColor; // Hintergrund der Form
            lblV.ForeColor = Color.Black;
            lblMeter.ForeColor = Color.Black;
            lblBrh.ForeColor = Color.Black;

            tbServer.BackColor = Color.White;
            tbPort.BackColor = Color.White;
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
    }
}
