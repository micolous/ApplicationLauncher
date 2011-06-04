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