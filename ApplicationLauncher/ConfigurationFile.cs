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
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Drawing;
using Nini;
using Nini.Ini;

namespace ApplicationLauncher
{
    class ConfigurationFile
    {
        private IniDocument ini;
        private string filename;
        public ConfigurationFile(String filename) : this(new StreamReader(filename)) {
            this.filename = filename;
        }

        public ConfigurationFile(TextReader tr)
        {
            this.ini = new IniDocument(tr, IniFileType.WindowsStyle);
            if (ini.Sections["ApplicationLauncher"].GetValue("ConfigVersion") != "1")
            {
                throw new ConfigurationFileFormatException("ApplicationLauncher.ConfigVersion is not 1");
            }
        }

        /// <summary>
        /// If the configuration loader knows the filename of the configuration,
        /// it will attempt to change the path (if not rooted; ie: relative) so that a
        /// new relative path is given that is shown as if it were relative to the
        /// configuration file.
        /// </summary>
        /// <param name="input">The filename to transform.</param>
        /// <returns>The modified path.</returns>
        public string PathRelativeToConfiguration(string input)
        {
            // select the filename relative to the configuration path
            if (this.filename != null && !Path.IsPathRooted(input))
                input = Path.Combine(Path.GetDirectoryName(this.filename), input);
            return input;
        }

        public Image GetBanner()
        {
            String imgfn = ini.Sections["ApplicationLauncher"].GetValue("BannerImage");
            if (imgfn == null)
            {
                return SystemIcons.Error.ToBitmap();
            }
            else
            {

                return Image.FromFile(PathRelativeToConfiguration(imgfn));
            }
        }

        public Dictionary<String, ApplicationShortcut> GetApplicationList()
        {
            Dictionary<String, ApplicationShortcut> asl = new Dictionary<string, ApplicationShortcut>();

            foreach (DictionaryEntry sect in ini.Sections)
            {
                if (((String)sect.Key).Substring(0, 4).ToLowerInvariant() == "app.")
                {
                    // it's an application link (app.*), add to shortcut list.
                    asl.Add(((String)sect.Key).Substring(4), new ApplicationShortcut((IniSection)(sect.Value)));
                }
            }

            return asl;
        }

        private String GetStringSetting(String key, String def) {
            return GetStringSetting("ApplicationLauncher", key, def);
        }

        private String GetStringSetting(String sect, String key, String def) {
            try {
                if (ini.Sections[sect].Contains(key))
                {
                    return ini.Sections[sect].GetValue(key);
                }
                else
                {
                    return def;
                }
            } 
            catch (Exception)
            { 
                return def;
            }
        }

        private Color GetColourSetting(String key, Color def) {
            return GetColourSetting("ApplicationLauncher", key, def);
        }


        private Color GetColourSetting(String sect, String key, Color def) {
            String c = GetStringSetting(sect, key, "X");
            if (c == "X") {
                return def;
            } else {
                return ColorTranslator.FromHtml(c);
            }
        }

        private bool GetBooleanSetting(String key, bool def) {
            return GetBooleanSetting("ApplicationLauncher", key, def);
        }

        private bool GetBooleanSetting(String sect, String key, bool def) {
            String b = GetStringSetting(sect, key, def.ToString());
            try {
                return Boolean.Parse(b);
            } catch (Exception) {
                return def;
            }
        }

        private int GetIntegerSetting(String key, int def)
        {
            return GetIntegerSetting("ApplicationLauncher", key, def);
        }
        private int GetIntegerSetting(String sect, String key, int def)
        {
            String n = GetStringSetting(sect, key, "x");
            try
            {
                return Int32.Parse(n);
            }
            catch (Exception)
            {
                return def;
            }
        }


        public Color BackgroundColour
        {
            get
            {
                return GetColourSetting("BgColour", SystemColors.Control);
            }
        }

        public Color ForegroundColour
        {
            get
            {
                return GetColourSetting("FgColour", SystemColors.ControlText);
            }
        }

        public Color MenuBackgroundColour
        {
            get
            {
                return GetColourSetting("MenuBgColour", SystemColors.Control);
            }
        }

        public Color MenuForegroundColour
        {
            get
            {
                return GetColourSetting("MenuFgColour", SystemColors.Control);
            }
        }

        public bool DrawBorders
        {
            get
            {
                return GetBooleanSetting("DrawBorders", true);
            }
        }
        public bool DrawBorders2D
        {
            get
            {
                return GetBooleanSetting("DrawBorders2D", true);
            }
        }

        public bool MaximiseWindows
        {
            get { return GetBooleanSetting("MaximiseWindows", true); }
        }

        public string UnlockPassword
        {
            get { return GetStringSetting("UnlockPassword", null); }
        }

        public string ClockFormat
        {
            get { return GetStringSetting("ClockFormat", null); }
        }

        public string ClockFormatTooltip
        {
            get { return GetStringSetting("ClockFormatTooltip", null); }
        }

        public CloseProgramAction CloseProgramAction
        {
            get
            {
                char act = GetStringSetting("ActionOnLogout", "n").ToLowerInvariant()[0];
                switch (act)
                {
                    case 'n':
                        return CloseProgramAction.Nothing;
                    case 'l':
                        return CloseProgramAction.Logout;
                    case 'f':
                        return CloseProgramAction.LogoutForce;
                    case 'r':
                        return CloseProgramAction.Reboot;
                    case 's':
                        return CloseProgramAction.Shutdown;
                    default:
                        return CloseProgramAction.Nothing;
                }
            }
        }

        public bool ForceShutdownIfHung
        {
            get
            {
                return GetBooleanSetting("ForceShutdownIfHung", false);
            }
        }

    }
}
