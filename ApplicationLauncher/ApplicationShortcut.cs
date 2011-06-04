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
using System.Text;
using System.Drawing;
using System.IO;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;
using Nini.Ini;

namespace ApplicationLauncher
{
    class ApplicationShortcut
    {
        public String Name;
        public Image Icon;
        public String Exec;
        public Dictionary<String, String> Metadata;
        public String Desc = null;
        public String Opts = "";

        /// <summary>
        /// Create an application shortcut from the ini section provided.
        /// </summary>
        /// <param name="sect">The section to create it from.</param>
        public ApplicationShortcut(IniSection sect)
        {
            Name = sect.GetValue("name");
            if (sect.Contains("icon"))
            {
                String ipath = sect.GetValue("icon");
                try
                {
                    Icon = Image.FromFile(Program.cfg.PathRelativeToConfiguration(ipath));
                }
                catch (Exception)
                {
                    Icon = SystemIcons.Error.ToBitmap();
                }
            }
            else
            {
                Icon = SystemIcons.Application.ToBitmap();
            }

            Exec = sect.GetValue("exec");

            if (sect.Contains("opts"))
            {
                Opts = sect.GetValue("opts");
            }


            Metadata = new Dictionary<string,string>();
            foreach (String k in sect.GetKeys()) {
                if (k[0] == '_')
                {
                    // It's metadata, 'jo.
                    Metadata.Add(k.Substring(1), sect.GetValue(k));
                }
            }

            if (sect.Contains("desc"))
            {
                Desc = sect.GetValue("desc").Replace("|", "\r\n");
            }
        }

        public override String ToString()
        {
            return "[ApplicationShortcut:name=" + this.Name + "]";
        }

        public void Run()
        {
            if (File.Exists(Exec))
            {
                Program.applThread = new Thread(new ThreadStart(RunThread));
                Blackout b = new Blackout();
                b.ShowDialog();
            }
            else
            {
                MessageBox.Show("Sorry, cannot find the target of this shortcut!", "ApplicationLauncher", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void RunThread()
        {
            Functions.CrashHandler(RunThreadCrashHandlerTarget);
        }

        public void RunThreadCrashHandlerTarget()
        {
            ProcessStartInfo p = new ProcessStartInfo(Exec, Opts);
            p.WorkingDirectory = Path.GetDirectoryName(Exec);
            Program.applProcess = Process.Start(p);
            Program.applProcess.WaitForExit();

        }
    }
}
