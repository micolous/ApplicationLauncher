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
