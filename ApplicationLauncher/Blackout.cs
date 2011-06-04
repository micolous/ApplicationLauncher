using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Threading;

namespace ApplicationLauncher
{
    public partial class Blackout : Form
    {
        public Blackout()
        {
            InitializeComponent();
            if (!Program.cfg.MaximiseWindows)
            {
                WindowState = FormWindowState.Normal;
            }
        }

        private void BlackoutTicker_Tick(object sender, EventArgs e)
        {
            if (Program.applThread.Join(100))
            {
                Program.mf.Select();
                this.Close();
            }
        }

        private void Blackout_Load(object sender, EventArgs e)
        {
            //this.Enabled = false;
            Program.applThread.Start();
        }

        private void ForceQuitButton_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to force quit the application?", "Application Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                try
                {
                    Program.applProcess.Kill();
                }
                catch (InvalidOperationException)
                {
                    // pass, program already exited.
                }
                Program.applThread.Abort();
            }
        }
    }
}