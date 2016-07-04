using ClipBoard;
using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyScreenshotAssistant
{
    public partial class LoginForm : ClipboardWatchableForm
    {
        CoreTweet.OAuth.OAuthSession session = CoreTweet.OAuth.Authorize(API_Keys.consumerKey, API_Keys.cosumerSecret);

        string url; // OAuth_url
        bool pin_flag;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = Text + Program.version;
            url = session.AuthorizeUri.ToString();
            textbox_url.Text = url;

            try
            {
                Clipboard.SetText(url);
            }
            catch { }

            DrawClipBoard += new EventHandler(LoginForm_DrawClipBoard);
            StartWatch();
            pin_flag = true;

            Activate();
        }

        // クリップボードに変化がある場合に実行される
        private void LoginForm_DrawClipBoard(object sender, EventArgs e)
        {
            // コピーされた文字列が半角数字のみか調べる
            if (pin_flag == true && Regex.IsMatch(Clipboard.GetText(), "/^[0-9]+$/"))
            {
                textbox_pin.Text = Clipboard.GetText();
                OAuth();
            }
        }

        // 認証用urlを既定のブラウザで開く
        private void url_open_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(url);
        }

        // 認証ボタンがクリックされた時に実行される
        private void Auth_button_Click(object sender, EventArgs e)
        {
            OAuth();
        }

        // PINコード入力欄でEnterキーが押された時に実行される
        private void textbox_pin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OAuth();
            }
        }

        // 認証処理
        private void OAuth()
        {
            if (textbox_pin.Text == "")
            {
                //何も入力されていない場合
                Method.message("Error", "PINコードを入力してください");
            }
            else if (Regex.IsMatch(textbox_pin.Text, "/^[0-9]+$/"))
            {
                // 半角数字以外の文字列が入力されていた場合
                Method.message("Error", "半角数字を入力してください");
            }
            else
            {
                try
                {
                    CoreTweet.Tokens tokens = CoreTweet.OAuth.GetTokens(session, textbox_pin.Text);
                    Properties.Settings.Default.AccessToken = tokens.AccessToken;
                    Properties.Settings.Default.AccessTokenSecret = tokens.AccessTokenSecret;

                    EndWatch();

                    Method.logfile("Info", "Authentication success");

                    Hide();
                    new MainForm().Show();
                }
                catch (CoreTweet.TwitterException)
                {
                    // PINコードが間違っている場合
                    Method.message("Error", "正しいPINコードを入力してください");
                }
            }
        }
    }
}
