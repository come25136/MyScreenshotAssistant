// Copyright 2016 hnx8
// http://d.hatena.ne.jp/hnx8/20160131/1454254349

using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

public class TextBoxEx : TextBox
{
    /// <summary>
    /// テキストが空の場合に表示する文字列を取得・設定します。
    /// </summary>
    [Category("表示")]
    [DefaultValue("")]
    [Description("テキストが空の場合に表示する文字列です。")]
    [RefreshProperties(RefreshProperties.Repaint)]
    public string WatermarkText
    {
        get { return _watermarkText; }
        set
        {
            _watermarkText = value;
            this.Invalidate();
        }
    }
    private string _watermarkText = ""; //ウォーターマーク表示内容text
    ///<summary>
    ///描画拡張（テキスト未設定時、ウォーターマークを描画）
    ///</summary>
    ///<param name="m"></param>
    protected override void WndProc(ref Message m)
    {
        const int WM_PAINT = 0x000F;
        base.WndProc(ref m);
        if (m.Msg == WM_PAINT && string.IsNullOrEmpty(this.Text) && string.IsNullOrEmpty(WatermarkText) == false)
        {
            using (Graphics g = Graphics.FromHwnd(this.Handle))
            {   //テキストボックス内の適切な座標に描画
                Rectangle rect = this.ClientRectangle;
                rect.Offset(1, 1);
                TextRenderer.DrawText(g, WatermarkText, this.Font,
                    rect, SystemColors.ControlDark, TextFormatFlags.Top | TextFormatFlags.Left);
            }
        }
    }
}