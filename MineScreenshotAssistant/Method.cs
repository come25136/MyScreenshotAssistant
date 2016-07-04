using System;
using System.Windows.Forms;

namespace MyScreenshotAssistant
{
    class Method
    {
        /// <summary>
        /// MessageBox
        /// </summary>

        // MessageBoxのコード省略化
        public static void message(string title, string value)
        {
            MessageBox.Show(value,
                    title,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);

            return;
        }

        /// <summary>
        /// Make log file
        /// </summary>

        // ログファイルへ記入
        public static void logfile(string level, string value)
        {
            System.IO.File.AppendAllText("MSA.log", DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss") + " " + level + ": " + value + '\r' + '\n');
            return;
        }
    }
}
