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
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;
using System.Runtime.InteropServices;


namespace ApplicationLauncher
{
    static class Program
    {
#if !DEBUG
        internal static ErrorDialogue error;
#endif
        internal static String[] args;
        internal static ConfigurationFile cfg;
        internal static Dictionary<String,ApplicationShortcut> apps;
        internal static MainForm mf;

        internal static Thread applThread;
        internal static Process applProcess;
        internal static CloseProgramAction cpa;
        internal static bool forceShutdownIfHung;
        

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(String[] args)
        {
            Program.args = args;
            Functions.CrashHandler(new CrashHandlableMethod(Startup));
        }

        internal static void Startup() {
            cfg = new ConfigurationFile(args[0]);
            apps = cfg.GetApplicationList();
            cpa = cfg.CloseProgramAction;
            forceShutdownIfHung = cfg.ForceShutdownIfHung;

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            mf = new MainForm();
            Application.Run(mf);
        }

        internal static void Kill()
        {
            int f = 0;
            if (forceShutdownIfHung)
            {
                // This makes it so no waiting is done at all if a program is non-responsive.
                f |= 0x10;
            }
            switch (cpa)
            {
                case CloseProgramAction.Logout:
                    ExitWindowsEx(f, 0);
                    break;
                case CloseProgramAction.LogoutForce:
                    ExitWindowsEx(f | 0x04, 0);
                    break;
                case CloseProgramAction.Reboot:
                    ExitWindowsEx(f | 0x02, 0);
                    break;
                case CloseProgramAction.Shutdown:
                    ExitWindowsEx(f | 0x01, 0);
                    break;
            }
            Application.Exit();
        }

        /// <summary>
        /// ExitWindowsEx shuts down Windows.
        /// </summary>
        /// <param name="uFlags">The type of shutdown to perform.</param>
        /// <param name="dwReason">The reason code for the shutdown. (NT)</param>
        /// <returns></returns>
        [DllImport("user32.dll")]
        static extern int ExitWindowsEx(int uFlags, int dwReason);
    }
}