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
using System.Threading;

namespace ApplicationLauncher
{
    internal delegate void CrashHandlableMethod();
    internal class Functions
    {
        internal static void CrashHandler(CrashHandlableMethod method)
        {
#if !DEBUG
            try
            {
#endif
                method();
#if !DEBUG
            }
            catch (ThreadAbortException)
            {
                // pass, die nicely...
            }
            catch (Exception ex)
            {
                Program.error = new ErrorDialogue(ex);
                Program.error.ShowDialog();
            }
#endif
        }
    }
}
