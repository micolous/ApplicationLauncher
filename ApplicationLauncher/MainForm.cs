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
using System.IO;

namespace ApplicationLauncher
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            // work around bug in form designer
            this.splitContainer1.Panel2MinSize = 150;

            // theming
            BannerPictureBox.Image = Program.cfg.GetBanner();

            BackColor = Program.cfg.BackgroundColour;
            ProgramDescriptionRTB.BackColor = BackColor;
            ShortcutsListView.BackColor = BackColor;

            ForeColor = Program.cfg.ForegroundColour;
            ProgramDescriptionRTB.ForeColor = ForeColor;
            ShortcutsListView.ForeColor = ForeColor;

            menuStrip1.BackColor = Program.cfg.MenuBackgroundColour;
            menuStrip1.ForeColor = Program.cfg.MenuForegroundColour;

            

            
            if (!Program.cfg.DrawBorders)
            {
                ShortcutsListView.BorderStyle = BorderStyle.None;
                ProgramDescriptionRTB.BorderStyle = BorderStyle.None;
            }
            else if (Program.cfg.DrawBorders2D)
            {
                ShortcutsListView.BorderStyle = BorderStyle.FixedSingle;
                ProgramDescriptionRTB.BorderStyle = BorderStyle.FixedSingle;
            }

            switch (Program.cpa)
            {
                case CloseProgramAction.Logout:
                case CloseProgramAction.LogoutForce:
                    closeToolStripMenuItem.ToolTipText = "Closes the application launcher, and logs you out of Windows.";
                    break;
                case CloseProgramAction.Nothing:
                    closeToolStripMenuItem.ToolTipText = "Closes the application launcher.";
                    break;
                case CloseProgramAction.Reboot:
                    closeToolStripMenuItem.ToolTipText = "Closes the application launcher, and reboots the computer.";
                    break;
                case CloseProgramAction.Shutdown:
                    closeToolStripMenuItem.ToolTipText = "Closes the application launcher, and shuts down the computer.";
                    break;
            
            }

            if (!Program.cfg.MaximiseWindows)
            {
                WindowState = FormWindowState.Normal;
            }

            // create appl list.
            CreateApplicationList();

            TimeTimer_Tick(null, null);
        }

        private void CreateApplicationList()
        {
            foreach (KeyValuePair<String, ApplicationShortcut> a in Program.apps)
            {
                ShortcutsListView.Items.Add(new ListViewItem(a.Value.Name, a.Key));
                IconList.Images.Add(a.Key, a.Value.Icon);
            }
            ShortcutsListView.Sort();
        }

        private void closeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to quit the application launcher?", "Application Launcher", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
            {
                Program.Kill();
            }
        }

        private void ShortcutsListView_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (e.IsSelected)
            {
                ApplicationShortcut a = Program.apps[((ListView)sender).SelectedItems[0].ImageKey];
                ProgramDescriptionRTB.Clear();
                AddBoldFormattedText(ProgramDescriptionRTB, a.Name + "\r\n\r\n");
                foreach (KeyValuePair<String, String> m in a.Metadata) {
                    AddBoldFormattedText(ProgramDescriptionRTB, m.Key + ": ");
                    ProgramDescriptionRTB.AppendText(m.Value+"\r\n");
                }
                if (a.Desc != null)
                {
                    AddBoldFormattedText(ProgramDescriptionRTB, "Description:\r\n");
                    ProgramDescriptionRTB.AppendText(a.Desc);
                }
                ProgramDescriptionRTB.AppendText("\r\n\r\nPress ");
                AddItalicFormattedText(ProgramDescriptionRTB, "ENTER");
                ProgramDescriptionRTB.AppendText(" to start this application.");
                ProgramDescriptionRTB.Select(0, 0);
            }
            else
            {
                ProgramDescriptionRTB.Clear();
            }
        }

        private void AddBoldFormattedText(RichTextBox rtb, String txt)
        {
            int spos = rtb.TextLength;
            rtb.AppendText(txt);
            rtb.Select(spos, txt.Length);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Bold);
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Regular);
        }

        private void AddItalicFormattedText(RichTextBox rtb, String txt)
        {
            int spos = rtb.TextLength;
            rtb.AppendText(txt);
            rtb.Select(spos, txt.Length);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Italic);
            rtb.Select(rtb.TextLength, 0);
            rtb.SelectionFont = new Font(rtb.SelectionFont, FontStyle.Regular);
        }


        private void ShortcutContextMenu_Opening(object sender, CancelEventArgs e)
        {
            if (ShortcutsListView.SelectedItems.Count != 1)
            {
                e.Cancel = true;
            }
        }

        private void RunSelectedProgram()
        {
            if (ShortcutsListView.SelectedItems.Count == 1)
            {
                MessageToolStrip.Text = "Running " + Program.apps[ShortcutsListView.SelectedItems[0].ImageKey].Name + "...";
                Refresh();
                Program.apps[ShortcutsListView.SelectedItems[0].ImageKey].Run();
                MessageToolStrip.Text = "";
                Refresh();
            }
        }

        private void openApplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunSelectedProgram();
        }

        private void ShortcutsListView_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            RunSelectedProgram();
        }

        private void ShortcutsListView_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == '\r') // enter
                RunSelectedProgram();
        }

        private void ProgramDescriptionRTB_Enter(object sender, EventArgs e)
        {
            ShortcutsListView.Select();
        }

        private void appToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            ShortcutsListView.Select();
        }

        private void MessageToolStrip_DropDownOpening(object sender, EventArgs e)
        {
            ShortcutsListView.Select();
        }

        private void appToolStripMenuItem_MouseEnter(object sender, EventArgs e)
        {
            MessageToolStrip.Text = "Copyright 2007, 2008, 2011 Michael Farrell";
        }

        private void appToolStripMenuItem_MouseLeave(object sender, EventArgs e)
        {
            MessageToolStrip.Text = "";
        }

        public void TimeTimer_Tick(object sender, EventArgs e)
        {
            DateTime n = DateTime.Now;
            if (Program.cfg.ClockFormat == null)
            {
                TimeToolStripItem.Text = n.ToShortTimeString();
            }
            else
            {
                TimeToolStripItem.Text = n.ToString(Program.cfg.ClockFormat);
            }

            if (Program.cfg.ClockFormatTooltip == null)
            {
                TimeToolStripItem.ToolTipText = n.ToLongDateString();
            }
            else
            {
                TimeToolStripItem.ToolTipText = n.ToString(Program.cfg.ClockFormatTooltip);
            }
        }

        private void TimeToolStripItem_DropDownOpening(object sender, EventArgs e)
        {
            //ShortcutsListView.Select(); 
            // secret mode! :P
            if (Program.cfg.UnlockPassword != null)
            {
                Functions.CrashHandler(ShowUnlockDialogue);
            }
            else
            {
                ShortcutsListView.Select();
            }
        }

        private void ShowUnlockDialogue()
        {
            Unlock u = new Unlock();
            u.ShowDialog(this);

        }
        private void MessageToolStrip_TextChanged(object sender, EventArgs e)
        {
            MessageToolStrip.Visible = MessageToolStrip.Text != "";
        }

    }
}