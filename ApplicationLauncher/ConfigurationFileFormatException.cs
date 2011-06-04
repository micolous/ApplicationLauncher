using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationLauncher
{
    class ConfigurationFileFormatException : Exception
    {
        public ConfigurationFileFormatException(String Message)
            : base(Message)
        {
        }
    }
}
