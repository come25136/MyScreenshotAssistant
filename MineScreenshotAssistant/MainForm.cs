using CoreTweet;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScreenshotAssistant
{
    public partial class MainForm : Form
    {
        // Twitter API 認証情報
        CoreTweet.Tokens tokens = CoreTweet.Tokens.Create(API_Keys.consumerKey, API_Keys.cosumerSecret, Properties.Settings.Default.AccessToken, Properties.Settings.Default.AccessTokenSecret);

        private FileSystemWatcher watcher = null;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Text = Text + Program.version; // バージョン表示

            if (!File.Exists(Properties.Settings.Default.DirectoryList))
            {
                dataSet1.WriteXml(Properties.Settings.Default.DirectoryList);
            }

            dataSet1.ReadXml(Properties.Settings.Default.DirectoryList);

            textbox_twitterid.Text = tokens.Account.VerifyCredentials().ScreenName; // Twitter id 表示

            textBox_DP.Text = Properties.Settings.Default.DirectoryName; // ディレクトリパスの復元
            textBox_twtxt.Text = Properties.Settings.Default.TweetText; // ツイート内容の復元
            textBox_hashtag.Text = Properties.Settings.Default.Hashtag; // ハッシュタグの復元

            Activate(); // アクティブ化
        }

        // ディレクトリ選択
        private void button_path_Click(object sender, EventArgs e)
        {
            new DPS().ShowDialog();

            dataSet1.Clear();

            dataSet1.ReadXml(Properties.Settings.Default.DirectoryList);
        }

        // ディレクトリの監視を開始
        private void button_start_Click(object sender, EventArgs e)
        {
            watcher_start();
        }

        // ディレクトリの監視を止める
        private void button_stop_Click(object sender, EventArgs e)
        {
            watcher_stop();
        }

        // ディレクトリの監視を開始 (メゾット)
        private void watcher_start()
        {
            if (watcher != null)
            {
                Method.message("Info", "Assistantは既にStartしています");
                return;
            }

            try
            {
                if (dataSet1.Tables["DataTable1"].Rows[textBox_DP.FindStringExact(textBox_DP.Text)][1].ToString() == "-1")
                {
                    Method.message("Error", "ディレクトリが記入されていません");
                    return;

                }
            } catch
            {
                Method.message("Error", "設定データが見つかりません");
                return;
            }

            try
            {
                watcher = new FileSystemWatcher();
                watcher.Path = dataSet1.Tables["DataTable1"].Rows[textBox_DP.FindStringExact(textBox_DP.Text)][1].ToString();
                watcher.NotifyFilter =
                    (NotifyFilters.LastAccess
                    | NotifyFilters.LastWrite
                    | NotifyFilters.FileName
                    | NotifyFilters.DirectoryName); ;
                watcher.Filter = "*.png";

                watcher.SynchronizingObject = this;

                watcher.Created += new FileSystemEventHandler(watcher_Changed);

                watcher.EnableRaisingEvents = true;
            } catch (ArgumentException)
            {
                Method.message("Error", "ディレクトリが存在しません");
                watcher = null;
                return;
            }

            Text = "MyScreenshotAssistant - Status start" + Program.version;

            Method.logfile("Info", "Assistant start");

            notifyIcon1.BalloonTipText = "Assistant start";
            notifyIcon1.ShowBalloonTip(2000);
        }

        // ディレクトリの監視を止める (メゾット)
        private void watcher_stop()
        {
            if (watcher == null)
            {
                Method.message("Info", "Assistantは既にStopしています");

                return;
            }

            watcher.EnableRaisingEvents = false;
            watcher.Dispose();
            watcher = null;

            Text = "MyScreenshotAssistant - Status stop" + Program.version;

            Method.logfile("Info", "Assistant stop");

            notifyIcon1.BalloonTipText = "Assistant stop";
            notifyIcon1.ShowBalloonTip(2000);
        }

        //ディレクトリに変化があった時の処理
        private async void watcher_Changed(object source, FileSystemEventArgs e)
        {
            switch (e.ChangeType)
            {
                case WatcherChangeTypes.Created:
                    // ファイルサイズの確認(5MB)
                    if (e.FullPath.Length < 5242880)
                    {
                        if (checkBox1.Checked)
                        {
                            new Tweet().ShowDialog();

                            if (Tweet.cancel_flag)
                            {
                                break;
                            }
                        }

                        try
                        {
                            MediaUploadResult[] result = await Task.WhenAll(tokens.Media.UploadAsync(media: new FileInfo(@e.FullPath)));

                            await tokens.Statuses.UpdateAsync(
                                status: textBox_twtxt.Text.Replace(@"\n", "\n") + " " + textBox_hashtag.Text.Replace(@"\n", "\n") + Tweet.value + " #comeMSA",
                                media_ids: result.Select(x => x.MediaId)
                            );
                            Method.logfile("Info", "Success tweet");
                            Tweet.value = null;
                        }
                        catch (Exception ex)
                        {
                            Method.logfile("Error", ex.Message);

                            notifyIcon1.BalloonTipText = "ツイートに失敗しました";
                            notifyIcon1.ShowBalloonTip(2000);
                        }
                    } else
                    {
                        Method.logfile("Error", "File size over 5MB " + e.FullPath);

                        notifyIcon1.BalloonTipText = "ファイルサイズが5MBを超えています";
                        notifyIcon1.ShowBalloonTip(2000);
                    }
                    break;
            }
        }

        // フォームが閉じられた時
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

        // タスクトレイのアイコンをダブルクリックした時
        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            Show(); // ウィンドウを表示
            Activate(); // アクティブ化
        }

        // 認証情報削除
        private void button_Auth_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.AccessToken = null;
            Properties.Settings.Default.AccessTokenSecret = null;

            Method.message("Info", "認証情報を削除しました\nソフトを再起動してください");

            Method.logfile("Info", "Authentication information Delete");

            exit();
        }

        private void context_exit_Click(object sender, EventArgs e)
        {
            exit();
        }

        // 終了処理
        private void exit()
        {
            Properties.Settings.Default.DirectoryName = textBox_DP.Text;
            Properties.Settings.Default.TweetText = textBox_twtxt.Text;
            Properties.Settings.Default.Hashtag = textBox_hashtag.Text;
            Properties.Settings.Default.Save();

            if (watcher != null)
            {
                Method.logfile("Info", "Assistant stop");
            }

            Application.Exit();
        }

        // ログファイルの表示
        private void log_show_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"MSA.log");
        }
    }
}