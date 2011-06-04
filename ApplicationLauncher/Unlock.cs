#region LICENSE
//ApplicationLauncher: A limited shell-replacement launcher program
//for Windows.

//Copyright 2007, 2008, 2011 Michael Farrell <http://micolous.id.au/>

//This program is free software: you can redistribute it and/or modify
//it under the terms of the GNU General Public License as published by
//the Free Software Foundation, either version 3 of the License, or
//(at your option) any later version.

//This program is distributed in the hope that it will be useful,
//but WITHOUT ANY WARRANTY; without even the implied warranty of
//MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//GNU General Public License for more details.
#endregion

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApplicationLauncher
{
    public partial class Unlock : Form
    {
        private int trem = 30;
        private string pw;
        public Unlock()
        {
            InitializeComponent();
            progressBar1.Value = trem;
            pw = Program.cfg.UnlockPassword;
        }

        private static Random r = new Random();

        private void PasswordInputBox_TextChanged(object sender, EventArgs e)
        {
            trem = (int)((trem * 1.3) + 4);
            if (trem > 30) { trem = 30; }
            progressBar1.Value = trem;

        }

        private void TimerRemaining_Tick(object sender, EventArgs e)
        {
            progressBar1.Value = trem;
            if (trem > 0) {
                trem--;
                // randomise the interval
                TimerRemaining.Interval = r.Next(250, 500);
            } else {
                CloseUp();
            }
        }

        private void CloseUp() {
            this.Close();
        }

        private void CancelUnlockButton_Click(object sender, EventArgs e)
        {
            CloseUp();
        }

        private void Unlock_Load(object sender, EventArgs e)
        {
            Point p = new Point((this.Size.Width / 2) - (panel1.Size.Width / 2), (this.Size.Height / 2) - (panel1.Size.Height / 2));
            panel1.Location = p;
        }

        private void OkButton_Click(object sender, EventArgs e)
        {
            if (PasswordInputBox.Text != pw)
            {
                PasswordInputBox.Text = "";
                trem = 30;
                progressBar1.Value = trem;
            }
            else
            {
                // correct!
                // launch explorer.
                Functions.CrashHandler(LaunchExplorer);
                this.Close();
            }
        }

        private void LaunchExplorer()
        {
            try
            {
                // nt way
                System.Diagnostics.Process.Start(System.Environment.ExpandEnvironmentVariables("%systemroot%\\explorer.exe"));
            }
            catch (Exception)
            {
                // ugly 9x way
                System.Diagnostics.Process.Start("c:\\windows\\explorer.exe");
            }
        }

    }
}