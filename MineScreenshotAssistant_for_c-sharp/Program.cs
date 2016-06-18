using System;
using System.Windows.Forms;

namespace MyScreenshotAssistant_for_c_sharp
{
    static class Program
    {
        public static string consumerKey = "";
        public static string cosumerSecret = "";

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            if (Properties.Settings.Default.AccessToken == "")
            {
                Application.Run(new LoginForm());
            } else
            {
                Application.Run(new MainForm());
            }
        }
    }
}
