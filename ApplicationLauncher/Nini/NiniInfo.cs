using System;
using System.Collections.Generic;
using System.Text;

namespace Nini
{

    public class NiniInfo
    {
        public static readonly String i1 =
            "ApplicationLauncher contains a 'statically linked' version of Nini.  It only contains the Nini.Ini.*, and Nini.Util " +
            "OrderedList and OrderedListEnumerator classes.";
        public static readonly String i2 =
            "Write support in Nini.Ini.IniDocument has been removed.";
        public static readonly String i3 =
            "This is to reduce code complexity, and space requirements.";
        public static readonly String i4 =
            "This modified version of Nini 1.1.0 is not a public class (ie: you can't link to ApplicationLauncher and use it's " +
            "version of Nini).";
    }
}
