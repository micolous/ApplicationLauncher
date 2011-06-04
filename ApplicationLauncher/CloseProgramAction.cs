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

enum CloseProgramAction
{
    /// <summary>
    /// Do nothing when closing the program.
    /// </summary>
    Nothing,
    /// <summary>
    /// Logout when closing the program.  This could be cancelled.
    /// </summary>
    Logout,
    /// <summary>
    /// Logout forcibly when closing the program.  This will kill all other processes.
    /// </summary>
    LogoutForce,
    /// <summary>
    /// Reboot when closing the program.
    /// </summary>
    Reboot,
    /// <summary>
    /// Shutdown when closing the program.
    /// </summary>
    Shutdown
}