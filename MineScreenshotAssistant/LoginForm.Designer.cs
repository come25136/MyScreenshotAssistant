﻿namespace MyScreenshotAssistant
{
    partial class LoginForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージ リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LoginForm));
            this.Auth_button = new System.Windows.Forms.Button();
            this.textbox_url = new System.Windows.Forms.TextBox();
            this.textbox_pin = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.url_open_button = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Auth_button
            // 
            this.Auth_button.Location = new System.Drawing.Point(14, 64);
            this.Auth_button.Name = "Auth_button";
            this.Auth_button.Size = new System.Drawing.Size(302, 39);
            this.Auth_button.TabIndex = 0;
            this.Auth_button.Text = "認証";
            this.Auth_button.UseVisualStyleBackColor = true;
            this.Auth_button.Click += new System.EventHandler(this.Auth_button_Click);
            // 
            // textbox_url
            // 
            this.textbox_url.BackColor = System.Drawing.SystemColors.Window;
            this.textbox_url.Location = new System.Drawing.Point(46, 10);
            this.textbox_url.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.textbox_url.Name = "textbox_url";
            this.textbox_url.ReadOnly = true;
            this.textbox_url.Size = new System.Drawing.Size(217, 19);
            this.textbox_url.TabIndex = 1;
            // 
            // textbox_pin
            // 
            this.textbox_pin.Location = new System.Drawing.Point(45, 37);
            this.textbox_pin.Margin = new System.Windows.Forms.Padding(3, 3, 3, 5);
            this.textbox_pin.Name = "textbox_pin";
            this.textbox_pin.Size = new System.Drawing.Size(271, 19);
            this.textbox_pin.TabIndex = 2;
            this.textbox_pin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textbox_pin_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Location = new System.Drawing.Point(12, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 12);
            this.label1.TabIndex = 3;
            this.label1.Text = "URL";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.HighlightText;
            this.label2.Location = new System.Drawing.Point(12, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(23, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "PIN";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // url_open_button
            // 
            this.url_open_button.Location = new System.Drawing.Point(269, 10);
            this.url_open_button.Name = "url_open_button";
            this.url_open_button.Size = new System.Drawing.Size(47, 19);
            this.url_open_button.TabIndex = 5;
            this.url_open_button.Text = "開く";
            this.url_open_button.UseVisualStyleBackColor = true;
            this.url_open_button.Click += new System.EventHandler(this.url_open_button_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(328, 115);
            this.Controls.Add(this.url_open_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textbox_pin);
            this.Controls.Add(this.textbox_url);
            this.Controls.Add(this.Auth_button);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "LoginForm";
            this.Text = "MyScreenshotAssistant - Twitter login";
            this.Load += new System.EventHandler(this.LoginForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button Auth_button;
        private System.Windows.Forms.TextBox textbox_url;
        private System.Windows.Forms.TextBox textbox_pin;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button url_open_button;
    }
}

