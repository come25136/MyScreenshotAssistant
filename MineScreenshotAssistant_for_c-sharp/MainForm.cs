using CoreTweet;
using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScreenshotAssistant_for_c_sharp
{
    public partial class MainForm : Form
    {
        CoreTweet.Tokens tokens = CoreTweet.Tokens.Create(Program.consumerKey, Program.cosumerSecret, Properties.Settings.Default.AccessToken, Properties.Settings.Default.AccessTokenSecret);

        private System.IO.FileSystemWatcher watcher = null;

        public MainForm()
        {
            InitializeComponent();

            Text = Text + " " + Properties.Settings.Default.version;
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            textbox_twitterid.Text = tokens.Account.VerifyCredentials().ScreenName;

            textBox_DP.Text = Properties.Settings.Default.DirectoryPath;
            textBox_twtxt.Text = Properties.Settings.Default.TweetText;
            textBox_hashtag.Text = Properties.Settings.Default.Hashtag;
        }

        private void button_path_Click(object sender, EventArgs e)
        {
            var Dialog = new CommonOpenFileDialog();
            Dialog.IsFolderPicker = true;
            Dialog.EnsureReadOnly = false;
            Dialog.AllowNonFileSystemItems = false;

            if (Properties.Settings.Default.DirectoryPath != null)
            {
                Dialog.DefaultDirectory = Properties.Settings.Default.DirectoryPath;
            }
            else
            {
                Dialog.DefaultDirectory = Application.StartupPath;
            }

            if (Dialog.ShowDialog() == CommonFileDialogResult.Ok)
            {
                Properties.Settings.Default.DirectoryPath = Dialog.FileName;
                textBox_DP.Text = Dialog.FileName;
            }
        }

        private void button_start_Click(object sender, EventArgs e)
        {
            if (watcher != null)
            {
                Program.message("Info", "Assistantは既にStartしています");
                return;
            };

            if (textBox_DP.Text == "")
            {
                Program.message("Error", "ディレクトリが選択されていません");
                return;

            }

            watcher = new System.IO.FileSystemWatcher();
            watcher.Path = @textBox_DP.Text;
            watcher.NotifyFilter =
                (System.IO.NotifyFilters.LastAccess
                | System.IO.NotifyFilters.LastWrite
                | System.IO.NotifyFilters.FileName
                | System.IO.NotifyFilters.DirectoryName); ;
            watcher.Filter = "*.png";
            watcher.SynchronizingObject = this;
            
            watcher.Created += new System.IO.FileSystemEventHandler(watcher_Changed);

            watcher.EnableRaisingEvents = true;

            Text = "MyScreenshotAssistant - Status start";

            Program.logfile("Info", "Assistant start");

            notifyIcon1.BalloonTipText = "Assistant start";
            notifyIcon1.ShowBalloonTip(2000);
        }

        private void button_stop_Click(object sender, EventArgs e)
        {
            if (watcher == null)
            {
               　Program.message("Info", "Assistantは既にStopしています");

                return;
            }

            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            watcher = null;

            Text = "MyScreenshotAssistant - Status stop";

            Program.logfile("Info", "Assistant stop");

            notifyIcon1.BalloonTipText = "Assistant stop";
            notifyIcon1.ShowBalloonTip(2000);
        }

        private async void watcher_Changed(System.Object source, System.IO.FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case System.IO.WatcherChangeTypes.Created:
                    try
                    {
                        MediaUploadResult[] result = await Task.WhenAll(tokens.Media.UploadAsync(media: new FileInfo(@e.FullPath)));

                        await tokens.Statuses.UpdateAsync(
                            status: textBox_twtxt.Text.Replace(@"\n", "\n") + " " + textBox_hashtag.Text.Replace(@"\n", "\n") + " #comeMSA \n" + e.Name,
                            media_ids: result.Select(x => x.MediaId)
                        );
                        Program.logfile("Info", "Success tweet");
                    } catch(Exception ex) {
                        Program.logfile("Error", ex.Message);

                        notifyIcon1.BalloonTipText = "ツイートに失敗しました";
                        notifyIcon1.ShowBalloonTip(2000);
                    }
                    break;
            }
        }

        private void button_Auth_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AccessToken = null;
            Properties.Settings.Default.AccessTokenSecret = null;
            
            Program.message("Info", "認証情報を削除しました\nソフトを再起動してください");

            Program.logfile("Info", "Authentication information Delete");

            exit();
        }

        private void context_exit_Click(object sender, EventArgs e)
        {
            exit();
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                Hide();

                notifyIcon1.BalloonTipText = "タスクトレイに常駐しています";
                notifyIcon1.ShowBalloonTip(2000);
            }
        }

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show();
        }

        private void exit()
        {
            Properties.Settings.Default.DirectoryPath = textBox_DP.Text;
            Properties.Settings.Default.TweetText = textBox_twtxt.Text;
            Properties.Settings.Default.Hashtag = textBox_hashtag.Text;
            Properties.Settings.Default.Save();

            if (watcher != null)
            {
                Program.logfile("Info", "Assistant stop");
            }

            Application.Exit();
        }
    }
}