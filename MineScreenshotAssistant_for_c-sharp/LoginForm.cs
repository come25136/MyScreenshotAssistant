using System;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace MyScreenshotAssistant_for_c_sharp
{
    public partial class LoginForm : Form
    {
        CoreTweet.OAuth.OAuthSession session = CoreTweet.OAuth.Authorize(Program.consumerKey, Program.cosumerSecret);

        public LoginForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textbox_pin.Text == "")
            {
                MessageBox.Show("PINコードを入力してください",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
            else if (Regex.IsMatch(textbox_pin.Text, "[^0-9]+$"))
            {
                MessageBox.Show("半角数字を入力してください",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            } else {
                try
                {
                    CoreTweet.Tokens tokens = CoreTweet.OAuth.GetTokens(session, textbox_pin.Text);
                    Properties.Settings.Default.AccessToken = tokens.AccessToken;
                    Properties.Settings.Default.AccessTokenSecret = tokens.AccessTokenSecret;

                    Hide();
                    new MainForm().Show();
                }
                catch (CoreTweet.TwitterException)
                {
                    MessageBox.Show("正しいPINコードを入力してください",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
                }
            }
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
            string url = session.AuthorizeUri.ToString();
            textbox_url.Text = url;
            try
            {
                Clipboard.SetText(url);
            }
            catch { }
        }
    }
}
