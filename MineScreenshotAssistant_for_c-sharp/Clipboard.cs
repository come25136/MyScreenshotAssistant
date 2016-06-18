using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace ClipBoard
{
    /// <summary>
    /// クリップボードを監視できるフォーム。
    /// </summary>
    public class ClipboardWatchableForm : Form
    {
        [DllImport("user32.dll")]
        private static extern IntPtr SetClipboardViewer(IntPtr hwnd);
        [DllImport("user32.dll")]
        private static extern int SendMessage(IntPtr hwnd, int wMsg, IntPtr wParam, IntPtr lParam);
        [DllImport("user32.dll")]
        private static extern bool ChangeClipboardChain(IntPtr hwnd, IntPtr hWndNext);

        private const int WM_DRAWCLIPBOARD = 0x0308;
        private const int WM_CHANGECBCHAIN = 0x030D;

        private IntPtr nextHandle;

        /// <summary>
        /// クリップボードに内容に変更があると発生します。
        /// </summary>
        public event EventHandler DrawClipBoard;

        public ClipboardWatchableForm()
        : base()
        {
            FormClosing += ClipboardWatchableForm_FormClosing;
        }

        private void ClipboardWatchableForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            EndWatch();
        }

        /// <summary>
        /// クリップボードの監視を開始します
        /// </summary>
        /// <returns>監視を開始したかどうか。既に監視されている場合、falseを返却します</returns>
        public bool StartWatch()
        {
            if (nextHandle == IntPtr.Zero)
            {
                nextHandle = SetClipboardViewer(this.Handle);
                return true;
            }

            return false;
        }

        /// <summary>
        /// クリップボードの監視を終了します
         /// </summary>
        /// <returns>監視を終了したかどうか。監視されていなかった場合、falseを返します</returns>
        public bool EndWatch()
        {
            return ChangeClipboardChain(this.Handle, nextHandle);
        }

        protected override void WndProc(ref Message m)
        {
            if (m.Msg == WM_DRAWCLIPBOARD)
            {
                SendMessage(nextHandle, m.Msg, m.WParam, m.LParam);
                if (this.DrawClipBoard != null)
                {
                    this.DrawClipBoard(this, EventArgs.Empty);
                }
            }
            else if (m.Msg == WM_CHANGECBCHAIN)
            {
                if (m.WParam == nextHandle)
                {
                    this.nextHandle = m.LParam;
                }
                else
                {
                    SendMessage(nextHandle, m.Msg, m.WParam, m.LParam);
                }
            }

            base.WndProc(ref m);
        }
    }
}