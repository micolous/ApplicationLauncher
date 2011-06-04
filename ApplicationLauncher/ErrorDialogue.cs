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
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ApplicationLauncher
{
    public partial class ErrorDialogue : Form
    {
        public ErrorDialogue(Exception ex)
        {
            InitializeComponent();
            ErrorText.Text =
                "Exception of type " + ex.GetType().ToString() + " was thrown.  The message was:\r\n" +
                "   " + ex.Message + "\r\n\r\n" +
                "Stack Trace:\r\n" +
                ex.StackTrace;
            ErrorText.Select(0, 0);

        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            Program.Kill();
        }

        private void FlashingBorderTimer_Tick(object sender, EventArgs e)
        {
            if (this.BackColor == Color.Red)
            {
                this.BackColor = Color.Yellow;
            }
            else
            {
                this.BackColor = Color.Red;
            }
        }

    }
}