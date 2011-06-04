
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