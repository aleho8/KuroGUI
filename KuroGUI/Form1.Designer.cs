namespace KuroGUI
{
    partial class MainGUI
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
            this.tabControl1 = new MetroFramework.Controls.MetroTabControl();
            this.SettingsPage = new System.Windows.Forms.TabPage();
            this.metroLabel2 = new MetroFramework.Controls.MetroLabel();
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.PresenceBox = new System.Windows.Forms.ListBox();
            this.SetGameButton = new MetroFramework.Controls.MetroButton();
            this.SetGameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.BlackListView = new System.Windows.Forms.ListView();
            this.Guild = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Channel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ChannelID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AdminListView = new System.Windows.Forms.ListView();
            this.tabPage1 = new MetroFramework.Controls.MetroTabPage();
            this.TokenSaveCheck = new MetroFramework.Controls.MetroCheckBox();
            this.FileSendButton = new MetroFramework.Controls.MetroButton();
            this.DisconnectButton = new MetroFramework.Controls.MetroButton();
            this.ConnectButton = new MetroFramework.Controls.MetroButton();
            this.TokenBox = new MetroFramework.Controls.MetroTextBox();
            this.ChatInBox = new MetroFramework.Controls.MetroTextBox();
            this.ChatOutBox = new System.Windows.Forms.RichTextBox();
            this.ChannelListView = new System.Windows.Forms.ListView();
            this.tabControl1.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SettingsPage);
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Location = new System.Drawing.Point(13, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(934, 498);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl1.UseSelectable = true;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.Transparent;
            this.SettingsPage.Controls.Add(this.metroLabel2);
            this.SettingsPage.Controls.Add(this.metroLabel1);
            this.SettingsPage.Controls.Add(this.PresenceBox);
            this.SettingsPage.Controls.Add(this.SetGameButton);
            this.SettingsPage.Controls.Add(this.SetGameTextBox);
            this.SettingsPage.Controls.Add(this.BlackListView);
            this.SettingsPage.Controls.Add(this.AdminListView);
            this.SettingsPage.Location = new System.Drawing.Point(4, 38);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Size = new System.Drawing.Size(926, 456);
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "[SETTINGS]";
            // 
            // metroLabel2
            // 
            this.metroLabel2.AutoSize = true;
            this.metroLabel2.Location = new System.Drawing.Point(6, 177);
            this.metroLabel2.Name = "metroLabel2";
            this.metroLabel2.Size = new System.Drawing.Size(83, 19);
            this.metroLabel2.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel2.TabIndex = 13;
            this.metroLabel2.Text = "Admin Users";
            this.metroLabel2.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(332, 177);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(125, 19);
            this.metroLabel1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel1.TabIndex = 12;
            this.metroLabel1.Text = "Blacklisted Channels";
            this.metroLabel1.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // PresenceBox
            // 
            this.PresenceBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.PresenceBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PresenceBox.ForeColor = System.Drawing.Color.White;
            this.PresenceBox.FormattingEnabled = true;
            this.PresenceBox.ItemHeight = 15;
            this.PresenceBox.Items.AddRange(new object[] {
            "Offline",
            "Online",
            "Idle",
            "AFK",
            "Do not disturb",
            "Invisible"});
            this.PresenceBox.Location = new System.Drawing.Point(6, 16);
            this.PresenceBox.Name = "PresenceBox";
            this.PresenceBox.Size = new System.Drawing.Size(264, 94);
            this.PresenceBox.TabIndex = 11;
            this.PresenceBox.SelectedIndexChanged += new System.EventHandler(this.PresenceBox_SelectedIndexChanged);
            // 
            // SetGameButton
            // 
            this.SetGameButton.Location = new System.Drawing.Point(276, 115);
            this.SetGameButton.Name = "SetGameButton";
            this.SetGameButton.Size = new System.Drawing.Size(82, 23);
            this.SetGameButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SetGameButton.TabIndex = 10;
            this.SetGameButton.Text = "Set Game";
            this.SetGameButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SetGameButton.UseSelectable = true;
            this.SetGameButton.Click += new System.EventHandler(this.SetGameButton_Click);
            // 
            // SetGameTextBox
            // 
            // 
            // 
            // 
            this.SetGameTextBox.CustomButton.Image = null;
            this.SetGameTextBox.CustomButton.Location = new System.Drawing.Point(242, 1);
            this.SetGameTextBox.CustomButton.Name = "";
            this.SetGameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SetGameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SetGameTextBox.CustomButton.TabIndex = 1;
            this.SetGameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SetGameTextBox.CustomButton.UseSelectable = true;
            this.SetGameTextBox.CustomButton.Visible = false;
            this.SetGameTextBox.Lines = new string[0];
            this.SetGameTextBox.Location = new System.Drawing.Point(6, 115);
            this.SetGameTextBox.MaxLength = 32767;
            this.SetGameTextBox.Name = "SetGameTextBox";
            this.SetGameTextBox.PasswordChar = '\0';
            this.SetGameTextBox.PromptText = "Set Presence";
            this.SetGameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SetGameTextBox.SelectedText = "";
            this.SetGameTextBox.SelectionLength = 0;
            this.SetGameTextBox.SelectionStart = 0;
            this.SetGameTextBox.ShortcutsEnabled = true;
            this.SetGameTextBox.Size = new System.Drawing.Size(264, 23);
            this.SetGameTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.SetGameTextBox.TabIndex = 2;
            this.SetGameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SetGameTextBox.UseSelectable = true;
            this.SetGameTextBox.WaterMark = "Set Presence";
            this.SetGameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SetGameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // BlackListView
            // 
            this.BlackListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.BlackListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Guild,
            this.Channel,
            this.ChannelID});
            this.BlackListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BlackListView.ForeColor = System.Drawing.Color.White;
            this.BlackListView.Location = new System.Drawing.Point(331, 205);
            this.BlackListView.Name = "BlackListView";
            this.BlackListView.Size = new System.Drawing.Size(588, 244);
            this.BlackListView.TabIndex = 1;
            this.BlackListView.UseCompatibleStateImageBehavior = false;
            this.BlackListView.View = System.Windows.Forms.View.Details;
            // 
            // Guild
            // 
            this.Guild.Text = "Guild";
            this.Guild.Width = 123;
            // 
            // Channel
            // 
            this.Channel.Text = "Channel";
            this.Channel.Width = 135;
            // 
            // ChannelID
            // 
            this.ChannelID.Text = "ChannelID";
            this.ChannelID.Width = 325;
            // 
            // AdminListView
            // 
            this.AdminListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.AdminListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.AdminListView.ForeColor = System.Drawing.Color.White;
            this.AdminListView.Location = new System.Drawing.Point(6, 205);
            this.AdminListView.Name = "AdminListView";
            this.AdminListView.Size = new System.Drawing.Size(264, 244);
            this.AdminListView.TabIndex = 0;
            this.AdminListView.UseCompatibleStateImageBehavior = false;
            this.AdminListView.View = System.Windows.Forms.View.List;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.TokenSaveCheck);
            this.tabPage1.Controls.Add(this.FileSendButton);
            this.tabPage1.Controls.Add(this.DisconnectButton);
            this.tabPage1.Controls.Add(this.ConnectButton);
            this.tabPage1.Controls.Add(this.TokenBox);
            this.tabPage1.Controls.Add(this.ChatInBox);
            this.tabPage1.Controls.Add(this.ChatOutBox);
            this.tabPage1.Controls.Add(this.ChannelListView);
            this.tabPage1.ForeColor = System.Drawing.Color.White;
            this.tabPage1.HorizontalScrollbarBarColor = true;
            this.tabPage1.HorizontalScrollbarHighlightOnWheel = false;
            this.tabPage1.HorizontalScrollbarSize = 10;
            this.tabPage1.Location = new System.Drawing.Point(4, 38);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(926, 456);
            this.tabPage1.Style = MetroFramework.MetroColorStyle.Blue;
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "[DEFAULT]";
            this.tabPage1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabPage1.UseVisualStyleBackColor = true;
            this.tabPage1.VerticalScrollbarBarColor = true;
            this.tabPage1.VerticalScrollbarHighlightOnWheel = false;
            this.tabPage1.VerticalScrollbarSize = 10;
            // 
            // TokenSaveCheck
            // 
            this.TokenSaveCheck.AutoSize = true;
            this.TokenSaveCheck.Location = new System.Drawing.Point(9, 405);
            this.TokenSaveCheck.Name = "TokenSaveCheck";
            this.TokenSaveCheck.Size = new System.Drawing.Size(116, 15);
            this.TokenSaveCheck.Style = MetroFramework.MetroColorStyle.Blue;
            this.TokenSaveCheck.TabIndex = 12;
            this.TokenSaveCheck.Text = "Remember Token";
            this.TokenSaveCheck.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TokenSaveCheck.UseSelectable = true;
            // 
            // FileSendButton
            // 
            this.FileSendButton.Enabled = false;
            this.FileSendButton.Location = new System.Drawing.Point(7, 431);
            this.FileSendButton.Name = "FileSendButton";
            this.FileSendButton.Size = new System.Drawing.Size(280, 23);
            this.FileSendButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.FileSendButton.TabIndex = 11;
            this.FileSendButton.Text = "Upload Image";
            this.FileSendButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FileSendButton.UseSelectable = true;
            this.FileSendButton.Click += new System.EventHandler(this.FileSendButton_Click);
            // 
            // DisconnectButton
            // 
            this.DisconnectButton.Enabled = false;
            this.DisconnectButton.Location = new System.Drawing.Point(207, 405);
            this.DisconnectButton.Name = "DisconnectButton";
            this.DisconnectButton.Size = new System.Drawing.Size(80, 23);
            this.DisconnectButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.DisconnectButton.TabIndex = 10;
            this.DisconnectButton.Text = "Disconnect";
            this.DisconnectButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DisconnectButton.UseSelectable = true;
            this.DisconnectButton.Click += new System.EventHandler(this.DisconnectButton_Click);
            // 
            // ConnectButton
            // 
            this.ConnectButton.Location = new System.Drawing.Point(207, 376);
            this.ConnectButton.Name = "ConnectButton";
            this.ConnectButton.Size = new System.Drawing.Size(80, 23);
            this.ConnectButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ConnectButton.TabIndex = 9;
            this.ConnectButton.Text = "Connect";
            this.ConnectButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ConnectButton.UseSelectable = true;
            this.ConnectButton.Click += new System.EventHandler(this.ConnectButton_Click);
            // 
            // TokenBox
            // 
            // 
            // 
            // 
            this.TokenBox.CustomButton.Image = null;
            this.TokenBox.CustomButton.Location = new System.Drawing.Point(169, 1);
            this.TokenBox.CustomButton.Name = "";
            this.TokenBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.TokenBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.TokenBox.CustomButton.TabIndex = 1;
            this.TokenBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.TokenBox.CustomButton.UseSelectable = true;
            this.TokenBox.CustomButton.Visible = false;
            this.TokenBox.Lines = new string[0];
            this.TokenBox.Location = new System.Drawing.Point(9, 376);
            this.TokenBox.MaxLength = 32767;
            this.TokenBox.Name = "TokenBox";
            this.TokenBox.PasswordChar = '●';
            this.TokenBox.PromptText = "Token Here";
            this.TokenBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.TokenBox.SelectedText = "";
            this.TokenBox.SelectionLength = 0;
            this.TokenBox.SelectionStart = 0;
            this.TokenBox.ShortcutsEnabled = true;
            this.TokenBox.Size = new System.Drawing.Size(191, 23);
            this.TokenBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.TokenBox.TabIndex = 8;
            this.TokenBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.TokenBox.UseSelectable = true;
            this.TokenBox.UseSystemPasswordChar = true;
            this.TokenBox.WaterMark = "Token Here";
            this.TokenBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.TokenBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // ChatInBox
            // 
            // 
            // 
            // 
            this.ChatInBox.CustomButton.Image = null;
            this.ChatInBox.CustomButton.Location = new System.Drawing.Point(604, 1);
            this.ChatInBox.CustomButton.Name = "";
            this.ChatInBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.ChatInBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ChatInBox.CustomButton.TabIndex = 1;
            this.ChatInBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.ChatInBox.CustomButton.UseSelectable = true;
            this.ChatInBox.CustomButton.Visible = false;
            this.ChatInBox.Lines = new string[0];
            this.ChatInBox.Location = new System.Drawing.Point(297, 431);
            this.ChatInBox.MaxLength = 32767;
            this.ChatInBox.Name = "ChatInBox";
            this.ChatInBox.PasswordChar = '\0';
            this.ChatInBox.PromptText = "Chat Message";
            this.ChatInBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.ChatInBox.SelectedText = "";
            this.ChatInBox.SelectionLength = 0;
            this.ChatInBox.SelectionStart = 0;
            this.ChatInBox.ShortcutsEnabled = true;
            this.ChatInBox.Size = new System.Drawing.Size(626, 23);
            this.ChatInBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.ChatInBox.TabIndex = 7;
            this.ChatInBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ChatInBox.UseSelectable = true;
            this.ChatInBox.WaterMark = "Chat Message";
            this.ChatInBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.ChatInBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            this.ChatInBox.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ChatInBox_KeyUp);
            // 
            // ChatOutBox
            // 
            this.ChatOutBox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ChatOutBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.ChatOutBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.ChatOutBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ChatOutBox.ForeColor = System.Drawing.Color.White;
            this.ChatOutBox.Location = new System.Drawing.Point(297, 6);
            this.ChatOutBox.Name = "ChatOutBox";
            this.ChatOutBox.ReadOnly = true;
            this.ChatOutBox.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
            this.ChatOutBox.Size = new System.Drawing.Size(626, 419);
            this.ChatOutBox.TabIndex = 1;
            this.ChatOutBox.TabStop = false;
            this.ChatOutBox.Text = "";
            this.ChatOutBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.ChatOutBox_LinkClicked);
            this.ChatOutBox.TextChanged += new System.EventHandler(this.richTextBox_TextChanged);
            // 
            // ChannelListView
            // 
            this.ChannelListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.ChannelListView.ForeColor = System.Drawing.Color.White;
            this.ChannelListView.Location = new System.Drawing.Point(7, 6);
            this.ChannelListView.Name = "ChannelListView";
            this.ChannelListView.Size = new System.Drawing.Size(280, 364);
            this.ChannelListView.TabIndex = 0;
            this.ChannelListView.UseCompatibleStateImageBehavior = false;
            this.ChannelListView.View = System.Windows.Forms.View.List;
            this.ChannelListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ChannelSelectionChanged);
            // 
            // MainGUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 562);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.Name = "MainGUI";
            this.Resizable = false;
            this.Text = "KuroUI";
            this.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainGUI_FormClosing);
            this.Load += new System.EventHandler(this.MainGUI_Load);
            this.tabControl1.ResumeLayout(false);
            this.SettingsPage.ResumeLayout(false);
            this.SettingsPage.PerformLayout();
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public MetroFramework.Controls.MetroTabPage tabPage1;
        public System.Windows.Forms.ListView ChannelListView;
        public MetroFramework.Controls.MetroTextBox ChatInBox;
        public MetroFramework.Controls.MetroTextBox TokenBox;
        public MetroFramework.Controls.MetroButton DisconnectButton;
        public MetroFramework.Controls.MetroButton ConnectButton;
        public MetroFramework.Controls.MetroTabControl tabControl1;
        public System.Windows.Forms.RichTextBox ChatOutBox;
        public MetroFramework.Controls.MetroButton FileSendButton;
        private MetroFramework.Controls.MetroCheckBox TokenSaveCheck;
        public System.Windows.Forms.ListBox PresenceBox;
        public MetroFramework.Controls.MetroButton SetGameButton;
        public MetroFramework.Controls.MetroTextBox SetGameTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.ListView AdminListView;
        public System.Windows.Forms.ListView BlackListView;
        private System.Windows.Forms.ColumnHeader Guild;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.ColumnHeader ChannelID;
        public System.Windows.Forms.TabPage SettingsPage;
    }
}

