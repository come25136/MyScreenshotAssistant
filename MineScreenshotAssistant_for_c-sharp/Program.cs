using System;
using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
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

        /// <summary>
        /// MessageBox
        /// </summary>
        public static void message(string title, string value)
        {
            MessageBox.Show(value,
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            return;
        }

        /// <summary>
        /// logファイルの作成
        /// </summary>
        public static void logfile(string level, string value)
        {
            System.IO.File.AppendAllText("MSA.log", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + level + ": " + value + '\n' + '\r');
            return;
        }
    }
}
