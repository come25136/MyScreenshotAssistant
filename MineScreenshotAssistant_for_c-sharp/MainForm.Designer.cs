﻿namespace MyScreenshotAssistant_for_c_sharp
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.label1 = new System.Windows.Forms.Label();
            this.textbox_twitterid = new System.Windows.Forms.TextBox();
            this.textBox_DP = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button_start = new System.Windows.Forms.Button();
            this.button_stop = new System.Windows.Forms.Button();
            this.button_Auth = new System.Windows.Forms.Button();
            this.button_path = new System.Windows.Forms.Button();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.context_exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label3 = new System.Windows.Forms.Label();
            this.textBox_twtxt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox_hashtag = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(18, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Twitter id:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textbox_twitterid
            // 
            this.textbox_twitterid.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_twitterid.Location = new System.Drawing.Point(91, 10);
            this.textbox_twitterid.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.textbox_twitterid.Name = "textbox_twitterid";
            this.textbox_twitterid.ReadOnly = true;
            this.textbox_twitterid.Size = new System.Drawing.Size(153, 19);
            this.textbox_twitterid.TabIndex = 1;
            // 
            // textBox_DP
            // 
            this.textBox_DP.Location = new System.Drawing.Point(91, 37);
            this.textBox_DP.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.textBox_DP.Name = "textBox_DP";
            this.textBox_DP.Size = new System.Drawing.Size(153, 19);
            this.textBox_DP.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(75, 12);
            this.label2.TabIndex = 3;
            this.label2.Text = "ディレクトリパス:";
            // 
            // button_start
            // 
            this.button_start.Location = new System.Drawing.Point(12, 121);
            this.button_start.Name = "button_start";
            this.button_start.Size = new System.Drawing.Size(150, 39);
            this.button_start.TabIndex = 4;
            this.button_start.Text = "Start";
            this.button_start.UseVisualStyleBackColor = true;
            this.button_start.Click += new System.EventHandler(this.button_start_Click);
            // 
            // button_stop
            // 
            this.button_stop.Location = new System.Drawing.Point(168, 121);
            this.button_stop.Name = "button_stop";
            this.button_stop.Size = new System.Drawing.Size(148, 39);
            this.button_stop.TabIndex = 5;
            this.button_stop.Text = "Stop";
            this.button_stop.UseVisualStyleBackColor = true;
            this.button_stop.Click += new System.EventHandler(this.button_stop_Click);
            // 
            // button_Auth
            // 
            this.button_Auth.Font = new System.Drawing.Font("MS UI Gothic", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(128)));
            this.button_Auth.Location = new System.Drawing.Point(250, 10);
            this.button_Auth.Name = "button_Auth";
            this.button_Auth.Size = new System.Drawing.Size(66, 19);
            this.button_Auth.TabIndex = 6;
            this.button_Auth.Text = "再認証";
            this.button_Auth.UseVisualStyleBackColor = true;
            this.button_Auth.Click += new System.EventHandler(this.button_Auth_Click);
            // 
            // button_path
            // 
            this.button_path.Location = new System.Drawing.Point(250, 37);
            this.button_path.Name = "button_path";
            this.button_path.Size = new System.Drawing.Size(66, 19);
            this.button_path.TabIndex = 7;
            this.button_path.Text = "参照";
            this.button_path.UseVisualStyleBackColor = true;
            this.button_path.Click += new System.EventHandler(this.button_path_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.BalloonTipTitle = "MyScreenshotAssistant";
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "MyScreenshotAssistant";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.DoubleClick += new System.EventHandler(this.notifyIcon1_DoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.context_exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(99, 26);
            // 
            // context_exit
            // 
            this.context_exit.Name = "context_exit";
            this.context_exit.Size = new System.Drawing.Size(98, 22);
            this.context_exit.Text = "終了";
            this.context_exit.Click += new System.EventHandler(this.context_exit_Click);
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(14, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(67, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "ツイート内容:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_twtxt
            // 
            this.textBox_twtxt.Location = new System.Drawing.Point(91, 65);
            this.textBox_twtxt.Name = "textBox_twtxt";
            this.textBox_twtxt.Size = new System.Drawing.Size(225, 19);
            this.textBox_twtxt.TabIndex = 9;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(18, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "ハッシュタグ:";
            // 
            // textBox_hashtag
            // 
            this.textBox_hashtag.Location = new System.Drawing.Point(91, 94);
            this.textBox_hashtag.Name = "textBox_hashtag";
            this.textBox_hashtag.Size = new System.Drawing.Size(224, 19);
            this.textBox_hashtag.TabIndex = 11;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(328, 172);
            this.Controls.Add(this.textBox_hashtag);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBox_twtxt);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button_path);
            this.Controls.Add(this.button_Auth);
            this.Controls.Add(this.button_stop);
            this.Controls.Add(this.button_start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox_DP);
            this.Controls.Add(this.textbox_twitterid);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.Text = "MyScreenshotAssistant";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textbox_twitterid;
        private System.Windows.Forms.TextBox textBox_DP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_start;
        private System.Windows.Forms.Button button_stop;
        private System.Windows.Forms.Button button_Auth;
        private System.Windows.Forms.Button button_path;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBox_twtxt;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBox_hashtag;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem context_exit;
        public System.Windows.Forms.NotifyIcon notifyIcon1;
    }
}