using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Forms;

using System.Resources;

namespace LocaleManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            //init Resource Bundle before start the MainForm
            InitResourceBundle();
            Application.Run(new MainForm());
        }

        static void InitResourceBundle()
        {
            ResourceBundle resBundle = ResourceBundle.GetInstance();
            resBundle.LocaleRoot = "LocaleManager.locale"; //where my locale files are

            resBundle.AddResourceFile("Forms");
            resBundle.AddResourceFile("Messages");

            string culture = Properties.Settings.Default.LastCulture;
            resBundle.Locale = culture;
            Application.CurrentCulture = new CultureInfo(culture);

        }
    }
}