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
            update();

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

        static void update()
        {
            string web256 = null;

            WebClient wc = new WebClient();
            wc.Encoding = Encoding.UTF8;
            try
            {
                web256 = wc.DownloadString(new Uri("https://raw.githubusercontent.com/come25136/MyScreenshotAssistant/master/SHA-256"));
            }
            catch (WebException e)
            {
                message("MyScreenshotAssistant  " + Properties.Settings.Default.version, "アップデートの確認に失敗しました" + '\n' + e);
            }

            //SHA1ハッシュ値を計算するファイル
            string fileName = Assembly.GetExecutingAssembly().Location;
            //ファイルを開く
            System.IO.FileStream fs = new System.IO.FileStream(
                fileName, System.IO.FileMode.Open, System.IO.FileAccess.Read);

            var sha256 = System.Security.Cryptography.SHA256.Create();

            //ハッシュ値を計算する
            byte[] bs = sha256.ComputeHash(fs);

            //リソースを解放する
            sha256.Clear();
            //ファイルを閉じる
            fs.Close();


            string result = BitConverter.ToString(bs).ToLower().Replace("-", "");

            if (web256 != result)
            {
                message("MyScreenshotAssistant  " + Properties.Settings.Default.version, "新しいバージョンが公開されています" + '\n' + "GitHubからダウンロードしてください");
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
            System.IO.File.AppendAllText("MSA.log", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + level + ": " + value + '\n');
            return;
        }
    }
}
