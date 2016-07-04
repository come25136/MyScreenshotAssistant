using System;
using System.Windows.Forms;

namespace MyScreenshotAssistant
{
    public partial class Tweet : Form
    {
        public static string value;
        public static bool cancel_flag;

        public Tweet()
        {
            InitializeComponent();
        }

        private void Tweet_Load(object sender, EventArgs e)
        {
            Activate();
        }

        private void textBox_value_KeyDown(object sender, KeyEventArgs e)
        {
            // ツイート
            if (e.KeyCode == Keys.Enter && e.Control == true)
            {
                cancel_flag = true;

                if (textBox_value.Text != "")
                {
                    value = '\n' + textBox_value.Text + '\n';
                    Close();
                } else
                {
                    value = null;
                    Close();
                }
            }
        }

        private void textBox_value_KeyPress(object sender, KeyPressEventArgs e)
        {
            // キャンセル
            if (e.KeyChar == (char)Keys.Escape)
            {
                cancel_flag = true;
                Close();
            }
        }
    }
}
