using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyScreenshotAssistant
{
    public partial class DPS : Form
    {
        public static string DirectoryListFile = "DirectoryList.xml"; 

        public DPS()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            //右クリックのときのみ
            if (e.Button == MouseButtons.Right)
            {
                //コンテキストメニューを表示する
                this.contextMenuStrip1.Show();
                //マウスカーソルの位置を画面座標で取得
                Point p = Control.MousePosition;
                this.contextMenuStrip1.Top = p.Y;
                this.contextMenuStrip1.Left = p.X;
            }
        }

        private void TSMI_Delede_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentCell.RowIndex);
            }
            catch { }
        }

        private void DPS_FormClosed(object sender, FormClosedEventArgs e)
        {
            dataSet1.WriteXml(Properties.Settings.Default.DirectoryList);
        }

        private void DPS_Load(object sender, EventArgs e)
        {
            dataSet1.ReadXml(Properties.Settings.Default.DirectoryList);
        }
    }
}
