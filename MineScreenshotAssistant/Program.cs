using System;
using System.Deployment.Application;
using System.Windows.Forms;

namespace MyScreenshotAssistant
{
    static class Program
    {
        public static string version;

        /// <summary>
        /// アプリケーションのメイン エントリ ポイントです。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            // データの引き継ぎ
            if (Properties.Settings.Default.IsUpgrade == false)
            {
                Properties.Settings.Default.Upgrade();
                Properties.Settings.Default.IsUpgrade = true;
                Properties.Settings.Default.Save();
            }

            // バージョン表記
            if (ApplicationDeployment.IsNetworkDeployed)
            {
                version = " ver:" + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            } else
            {
                version = " debug";
            }

            // ログイン情報があるかどうか
            if (Properties.Settings.Default.AccessToken != "")
            {
                // ログインしている場合
                Application.Run(new MainForm());
            } else
            {
                // ログインしていない場合
                Application.Run(new LoginForm());
            }
        }
    }
}
