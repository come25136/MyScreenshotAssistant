using ClipBoard;
using System;
using System.Deployment.Application;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyScreenshotAssistant_for_c_sharp
{
    public partial class LoginForm : ClipboardWatchableForm
    {
        CoreTweet.OAuth.OAuthSession session = CoreTweet.OAuth.Authorize(Program.consumerKey, Program.cosumerSecret);
        bool pin_flag;

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            Text = Text + " ver:" + ApplicationDeployment.CurrentDeployment.CurrentVersion.ToString();
            string url = session.AuthorizeUri.ToString();
            textbox_url.Text = url;

            try
            {
                Clipboard.SetText(url);
            }
            catch { }

            DrawClipBoard += new EventHandler(LoginForm_DrawClipBoard);
            StartWatch();
            pin_flag = true;
        }

        private void LoginForm_DrawClipBoard(object sender, EventArgs e)
        {
            if (pin_flag == true)
            {
                textbox_pin.Text = Clipboard.GetText();
                OAuth();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OAuth();
        }

        private void textbox_pin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                OAuth();
            }
        }

        private void OAuth()
        {
            if (textbox_pin.Text == "")
            {
                Program.message("Error", "PINコードを入力してください");
            }
            else if (Regex.IsMatch(textbox_pin.Text, "[^0-9]+$"))
            {
                Program.message("Error", "半角数字を入力してください");
            }
            else
            {
                try
                {
                    CoreTweet.Tokens tokens = CoreTweet.OAuth.GetTokens(session, textbox_pin.Text);
                    Properties.Settings.Default.AccessToken = tokens.AccessToken;
                    Properties.Settings.Default.AccessTokenSecret = tokens.AccessTokenSecret;

                    Program.logfile("Info", "Authentication success");

                    Hide();
                    new MainForm().Show();
                    Console.WriteLine("a");
                }
                catch (CoreTweet.TwitterException)
                {
                    Program.message("Error", "正しいPINコードを入力してください");
                }
            }

        }
    }
}
