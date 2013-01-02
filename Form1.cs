using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ZusiMeter
{
    public partial class SettingsForm : Form
    {
        public SettingsForm()
        {
            InitializeComponent();
        }

        private void SettingsForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            //TODO
            
        }

        private void SettingsForm_FormClosing_1(object sender, FormClosingEventArgs e)
        {
            this.Hide();
            //TEST
            //Properties.Settings.Default.Save();
        }

        private void SettingsForm_Load(object sender, EventArgs e)
        {
            
        }
    }
}
