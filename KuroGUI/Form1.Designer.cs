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
            this.SettingsPage = new MetroFramework.Controls.MetroTabPage();
            this.OwnerButton = new MetroFramework.Controls.MetroButton();
            this.OwnerIDBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel3 = new MetroFramework.Controls.MetroLabel();
            this.MessagesListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.metroButton1 = new MetroFramework.Controls.MetroButton();
            this.ConnectedMessageAddButton = new MetroFramework.Controls.MetroButton();
            this.UserJoinMessageBox = new MetroFramework.Controls.MetroTextBox();
            this.UserJoinChannelsComboBox = new MetroFramework.Controls.MetroComboBox();
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
            this.PicturesPage = new MetroFramework.Controls.MetroTabPage();
            this.NSFWRemoveButton = new MetroFramework.Controls.MetroButton();
            this.NSFWAddButton = new MetroFramework.Controls.MetroButton();
            this.NSFWPicsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.RemoveSFWButton = new MetroFramework.Controls.MetroButton();
            this.SFWAddFolder = new MetroFramework.Controls.MetroButton();
            this.SFWPicsTextBox = new MetroFramework.Controls.MetroTextBox();
            this.NSFWPicsListView = new System.Windows.Forms.ListView();
            this.SFWPicsListView = new System.Windows.Forms.ListView();
            this.DefaultPage = new MetroFramework.Controls.MetroTabPage();
            this.TokenSaveCheck = new MetroFramework.Controls.MetroCheckBox();
            this.FileSendButton = new MetroFramework.Controls.MetroButton();
            this.DisconnectButton = new MetroFramework.Controls.MetroButton();
            this.ConnectButton = new MetroFramework.Controls.MetroButton();
            this.TokenBox = new MetroFramework.Controls.MetroTextBox();
            this.ChatInBox = new MetroFramework.Controls.MetroTextBox();
            this.ChatOutBox = new System.Windows.Forms.RichTextBox();
            this.ChannelListView = new System.Windows.Forms.ListView();
            this.GuildChannels = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SFWFolders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.NSFWFolders = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SankakuUserNameTextBox = new MetroFramework.Controls.MetroTextBox();
            this.SankakuPasswordTextBox = new MetroFramework.Controls.MetroTextBox();
            this.metroLabel4 = new MetroFramework.Controls.MetroLabel();
            this.SankakuLoginButton = new MetroFramework.Controls.MetroButton();
            this.tabControl1.SuspendLayout();
            this.SettingsPage.SuspendLayout();
            this.PicturesPage.SuspendLayout();
            this.DefaultPage.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.SettingsPage);
            this.tabControl1.Controls.Add(this.PicturesPage);
            this.tabControl1.Controls.Add(this.DefaultPage);
            this.tabControl1.Location = new System.Drawing.Point(13, 52);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 2;
            this.tabControl1.Size = new System.Drawing.Size(934, 498);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.tabControl1.UseSelectable = true;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // SettingsPage
            // 
            this.SettingsPage.BackColor = System.Drawing.Color.Transparent;
            this.SettingsPage.Controls.Add(this.OwnerButton);
            this.SettingsPage.Controls.Add(this.OwnerIDBox);
            this.SettingsPage.Controls.Add(this.metroLabel3);
            this.SettingsPage.Controls.Add(this.MessagesListView);
            this.SettingsPage.Controls.Add(this.metroButton1);
            this.SettingsPage.Controls.Add(this.ConnectedMessageAddButton);
            this.SettingsPage.Controls.Add(this.UserJoinMessageBox);
            this.SettingsPage.Controls.Add(this.UserJoinChannelsComboBox);
            this.SettingsPage.Controls.Add(this.metroLabel2);
            this.SettingsPage.Controls.Add(this.metroLabel1);
            this.SettingsPage.Controls.Add(this.PresenceBox);
            this.SettingsPage.Controls.Add(this.SetGameButton);
            this.SettingsPage.Controls.Add(this.SetGameTextBox);
            this.SettingsPage.Controls.Add(this.BlackListView);
            this.SettingsPage.Controls.Add(this.AdminListView);
            this.SettingsPage.ForeColor = System.Drawing.Color.White;
            this.SettingsPage.HorizontalScrollbarBarColor = true;
            this.SettingsPage.HorizontalScrollbarHighlightOnWheel = false;
            this.SettingsPage.HorizontalScrollbarSize = 10;
            this.SettingsPage.Location = new System.Drawing.Point(4, 38);
            this.SettingsPage.Name = "SettingsPage";
            this.SettingsPage.Size = new System.Drawing.Size(926, 456);
            this.SettingsPage.Style = MetroFramework.MetroColorStyle.Blue;
            this.SettingsPage.TabIndex = 1;
            this.SettingsPage.Text = "[SETTINGS]";
            this.SettingsPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SettingsPage.VerticalScrollbarBarColor = true;
            this.SettingsPage.VerticalScrollbarHighlightOnWheel = false;
            this.SettingsPage.VerticalScrollbarSize = 10;
            // 
            // OwnerButton
            // 
            this.OwnerButton.Location = new System.Drawing.Point(192, 422);
            this.OwnerButton.Name = "OwnerButton";
            this.OwnerButton.Size = new System.Drawing.Size(82, 23);
            this.OwnerButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.OwnerButton.TabIndex = 21;
            this.OwnerButton.Text = "Set Owner";
            this.OwnerButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OwnerButton.UseSelectable = true;
            this.OwnerButton.Click += new System.EventHandler(this.OwnerButton_Click);
            // 
            // OwnerIDBox
            // 
            // 
            // 
            // 
            this.OwnerIDBox.CustomButton.Image = null;
            this.OwnerIDBox.CustomButton.Location = new System.Drawing.Point(160, 1);
            this.OwnerIDBox.CustomButton.Name = "";
            this.OwnerIDBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.OwnerIDBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.OwnerIDBox.CustomButton.TabIndex = 1;
            this.OwnerIDBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.OwnerIDBox.CustomButton.UseSelectable = true;
            this.OwnerIDBox.CustomButton.Visible = false;
            this.OwnerIDBox.Lines = new string[0];
            this.OwnerIDBox.Location = new System.Drawing.Point(6, 422);
            this.OwnerIDBox.MaxLength = 32767;
            this.OwnerIDBox.Name = "OwnerIDBox";
            this.OwnerIDBox.PasswordChar = '\0';
            this.OwnerIDBox.PromptText = "Owner ID Here";
            this.OwnerIDBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.OwnerIDBox.SelectedText = "";
            this.OwnerIDBox.SelectionLength = 0;
            this.OwnerIDBox.SelectionStart = 0;
            this.OwnerIDBox.ShortcutsEnabled = true;
            this.OwnerIDBox.Size = new System.Drawing.Size(182, 23);
            this.OwnerIDBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.OwnerIDBox.TabIndex = 20;
            this.OwnerIDBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.OwnerIDBox.UseSelectable = true;
            this.OwnerIDBox.WaterMark = "Owner ID Here";
            this.OwnerIDBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.OwnerIDBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel3
            // 
            this.metroLabel3.AutoSize = true;
            this.metroLabel3.Location = new System.Drawing.Point(308, 48);
            this.metroLabel3.Name = "metroLabel3";
            this.metroLabel3.Size = new System.Drawing.Size(119, 19);
            this.metroLabel3.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel3.TabIndex = 19;
            this.metroLabel3.Text = "Greeting Messages";
            this.metroLabel3.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // MessagesListView
            // 
            this.MessagesListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.MessagesListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.MessagesListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.MessagesListView.ForeColor = System.Drawing.Color.White;
            this.MessagesListView.FullRowSelect = true;
            this.MessagesListView.Location = new System.Drawing.Point(308, 75);
            this.MessagesListView.Name = "MessagesListView";
            this.MessagesListView.Size = new System.Drawing.Size(613, 141);
            this.MessagesListView.TabIndex = 18;
            this.MessagesListView.UseCompatibleStateImageBehavior = false;
            this.MessagesListView.View = System.Windows.Forms.View.Details;
            this.MessagesListView.SelectedIndexChanged += new System.EventHandler(this.MessagesListView_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Guild";
            this.columnHeader1.Width = 85;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Channel";
            this.columnHeader2.Width = 94;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Message";
            this.columnHeader3.Width = 430;
            // 
            // metroButton1
            // 
            this.metroButton1.Location = new System.Drawing.Point(700, 48);
            this.metroButton1.Name = "metroButton1";
            this.metroButton1.Size = new System.Drawing.Size(107, 23);
            this.metroButton1.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroButton1.TabIndex = 17;
            this.metroButton1.Text = "Remove Message";
            this.metroButton1.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.metroButton1.UseSelectable = true;
            this.metroButton1.Click += new System.EventHandler(this.metroButton1_Click);
            // 
            // ConnectedMessageAddButton
            // 
            this.ConnectedMessageAddButton.Enabled = false;
            this.ConnectedMessageAddButton.Location = new System.Drawing.Point(812, 48);
            this.ConnectedMessageAddButton.Name = "ConnectedMessageAddButton";
            this.ConnectedMessageAddButton.Size = new System.Drawing.Size(107, 23);
            this.ConnectedMessageAddButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.ConnectedMessageAddButton.TabIndex = 16;
            this.ConnectedMessageAddButton.Text = "Add Message";
            this.ConnectedMessageAddButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.ConnectedMessageAddButton.UseSelectable = true;
            this.ConnectedMessageAddButton.Click += new System.EventHandler(this.ConnectedMessageAddButton_Click);
            // 
            // UserJoinMessageBox
            // 
            // 
            // 
            // 
            this.UserJoinMessageBox.CustomButton.Image = null;
            this.UserJoinMessageBox.CustomButton.Location = new System.Drawing.Point(362, 1);
            this.UserJoinMessageBox.CustomButton.Name = "";
            this.UserJoinMessageBox.CustomButton.Size = new System.Drawing.Size(27, 27);
            this.UserJoinMessageBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserJoinMessageBox.CustomButton.TabIndex = 1;
            this.UserJoinMessageBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.UserJoinMessageBox.CustomButton.UseSelectable = true;
            this.UserJoinMessageBox.CustomButton.Visible = false;
            this.UserJoinMessageBox.Lines = new string[0];
            this.UserJoinMessageBox.Location = new System.Drawing.Point(308, 16);
            this.UserJoinMessageBox.MaxLength = 32767;
            this.UserJoinMessageBox.Name = "UserJoinMessageBox";
            this.UserJoinMessageBox.PasswordChar = '\0';
            this.UserJoinMessageBox.PromptText = "Set NewUser Greeting";
            this.UserJoinMessageBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.UserJoinMessageBox.SelectedText = "";
            this.UserJoinMessageBox.SelectionLength = 0;
            this.UserJoinMessageBox.SelectionStart = 0;
            this.UserJoinMessageBox.ShortcutsEnabled = true;
            this.UserJoinMessageBox.Size = new System.Drawing.Size(390, 29);
            this.UserJoinMessageBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserJoinMessageBox.TabIndex = 15;
            this.UserJoinMessageBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UserJoinMessageBox.UseSelectable = true;
            this.UserJoinMessageBox.WaterMark = "Set NewUser Greeting";
            this.UserJoinMessageBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.UserJoinMessageBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // UserJoinChannelsComboBox
            // 
            this.UserJoinChannelsComboBox.FormattingEnabled = true;
            this.UserJoinChannelsComboBox.ItemHeight = 23;
            this.UserJoinChannelsComboBox.Location = new System.Drawing.Point(700, 16);
            this.UserJoinChannelsComboBox.Name = "UserJoinChannelsComboBox";
            this.UserJoinChannelsComboBox.Size = new System.Drawing.Size(219, 29);
            this.UserJoinChannelsComboBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.UserJoinChannelsComboBox.TabIndex = 14;
            this.UserJoinChannelsComboBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.UserJoinChannelsComboBox.UseSelectable = true;
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
            this.metroLabel1.Location = new System.Drawing.Point(308, 219);
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
            this.PresenceBox.Size = new System.Drawing.Size(268, 94);
            this.PresenceBox.TabIndex = 11;
            this.PresenceBox.SelectedIndexChanged += new System.EventHandler(this.PresenceBox_SelectedIndexChanged);
            // 
            // SetGameButton
            // 
            this.SetGameButton.Location = new System.Drawing.Point(6, 142);
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
            this.SetGameTextBox.CustomButton.Location = new System.Drawing.Point(246, 1);
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
            this.SetGameTextBox.Size = new System.Drawing.Size(268, 23);
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
            this.BlackListView.Location = new System.Drawing.Point(308, 243);
            this.BlackListView.Name = "BlackListView";
            this.BlackListView.Size = new System.Drawing.Size(611, 206);
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
            this.AdminListView.Size = new System.Drawing.Size(268, 212);
            this.AdminListView.TabIndex = 0;
            this.AdminListView.UseCompatibleStateImageBehavior = false;
            this.AdminListView.View = System.Windows.Forms.View.List;
            // 
            // PicturesPage
            // 
            this.PicturesPage.BackColor = System.Drawing.Color.Transparent;
            this.PicturesPage.Controls.Add(this.SankakuLoginButton);
            this.PicturesPage.Controls.Add(this.metroLabel4);
            this.PicturesPage.Controls.Add(this.SankakuPasswordTextBox);
            this.PicturesPage.Controls.Add(this.SankakuUserNameTextBox);
            this.PicturesPage.Controls.Add(this.NSFWRemoveButton);
            this.PicturesPage.Controls.Add(this.NSFWAddButton);
            this.PicturesPage.Controls.Add(this.NSFWPicsTextBox);
            this.PicturesPage.Controls.Add(this.RemoveSFWButton);
            this.PicturesPage.Controls.Add(this.SFWAddFolder);
            this.PicturesPage.Controls.Add(this.SFWPicsTextBox);
            this.PicturesPage.Controls.Add(this.NSFWPicsListView);
            this.PicturesPage.Controls.Add(this.SFWPicsListView);
            this.PicturesPage.ForeColor = System.Drawing.Color.White;
            this.PicturesPage.HorizontalScrollbarBarColor = true;
            this.PicturesPage.HorizontalScrollbarHighlightOnWheel = false;
            this.PicturesPage.HorizontalScrollbarSize = 10;
            this.PicturesPage.Location = new System.Drawing.Point(4, 38);
            this.PicturesPage.Name = "PicturesPage";
            this.PicturesPage.Size = new System.Drawing.Size(926, 456);
            this.PicturesPage.Style = MetroFramework.MetroColorStyle.Blue;
            this.PicturesPage.TabIndex = 2;
            this.PicturesPage.Text = "[PICTURES]";
            this.PicturesPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.PicturesPage.VerticalScrollbarBarColor = true;
            this.PicturesPage.VerticalScrollbarHighlightOnWheel = false;
            this.PicturesPage.VerticalScrollbarSize = 10;
            // 
            // NSFWRemoveButton
            // 
            this.NSFWRemoveButton.Location = new System.Drawing.Point(826, 262);
            this.NSFWRemoveButton.Name = "NSFWRemoveButton";
            this.NSFWRemoveButton.Size = new System.Drawing.Size(93, 23);
            this.NSFWRemoveButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NSFWRemoveButton.TabIndex = 14;
            this.NSFWRemoveButton.Text = "Remove NSFW";
            this.NSFWRemoveButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.NSFWRemoveButton.UseSelectable = true;
            this.NSFWRemoveButton.Click += new System.EventHandler(this.NSFWRemoveButton_Click);
            // 
            // NSFWAddButton
            // 
            this.NSFWAddButton.Location = new System.Drawing.Point(731, 262);
            this.NSFWAddButton.Name = "NSFWAddButton";
            this.NSFWAddButton.Size = new System.Drawing.Size(89, 23);
            this.NSFWAddButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NSFWAddButton.TabIndex = 13;
            this.NSFWAddButton.Text = "Add NSFW";
            this.NSFWAddButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.NSFWAddButton.UseSelectable = true;
            this.NSFWAddButton.Click += new System.EventHandler(this.NSFWAddButton_Click);
            // 
            // NSFWPicsTextBox
            // 
            // 
            // 
            // 
            this.NSFWPicsTextBox.CustomButton.Image = null;
            this.NSFWPicsTextBox.CustomButton.Location = new System.Drawing.Point(226, 1);
            this.NSFWPicsTextBox.CustomButton.Name = "";
            this.NSFWPicsTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.NSFWPicsTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.NSFWPicsTextBox.CustomButton.TabIndex = 1;
            this.NSFWPicsTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.NSFWPicsTextBox.CustomButton.UseSelectable = true;
            this.NSFWPicsTextBox.CustomButton.Visible = false;
            this.NSFWPicsTextBox.Lines = new string[0];
            this.NSFWPicsTextBox.Location = new System.Drawing.Point(477, 262);
            this.NSFWPicsTextBox.MaxLength = 32767;
            this.NSFWPicsTextBox.Name = "NSFWPicsTextBox";
            this.NSFWPicsTextBox.PasswordChar = '\0';
            this.NSFWPicsTextBox.PromptText = "NSFW Picture Folder";
            this.NSFWPicsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.NSFWPicsTextBox.SelectedText = "";
            this.NSFWPicsTextBox.SelectionLength = 0;
            this.NSFWPicsTextBox.SelectionStart = 0;
            this.NSFWPicsTextBox.ShortcutsEnabled = true;
            this.NSFWPicsTextBox.Size = new System.Drawing.Size(248, 23);
            this.NSFWPicsTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.NSFWPicsTextBox.TabIndex = 12;
            this.NSFWPicsTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.NSFWPicsTextBox.UseSelectable = true;
            this.NSFWPicsTextBox.WaterMark = "NSFW Picture Folder";
            this.NSFWPicsTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.NSFWPicsTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // RemoveSFWButton
            // 
            this.RemoveSFWButton.Location = new System.Drawing.Point(352, 262);
            this.RemoveSFWButton.Name = "RemoveSFWButton";
            this.RemoveSFWButton.Size = new System.Drawing.Size(93, 23);
            this.RemoveSFWButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.RemoveSFWButton.TabIndex = 11;
            this.RemoveSFWButton.Text = "Remove SFW";
            this.RemoveSFWButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.RemoveSFWButton.UseSelectable = true;
            this.RemoveSFWButton.Click += new System.EventHandler(this.RemoveSFWButton_Click);
            // 
            // SFWAddFolder
            // 
            this.SFWAddFolder.Location = new System.Drawing.Point(257, 262);
            this.SFWAddFolder.Name = "SFWAddFolder";
            this.SFWAddFolder.Size = new System.Drawing.Size(89, 23);
            this.SFWAddFolder.Style = MetroFramework.MetroColorStyle.Blue;
            this.SFWAddFolder.TabIndex = 10;
            this.SFWAddFolder.Text = "Add SFW";
            this.SFWAddFolder.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SFWAddFolder.UseSelectable = true;
            this.SFWAddFolder.Click += new System.EventHandler(this.SFWAddFolder_Click);
            // 
            // SFWPicsTextBox
            // 
            // 
            // 
            // 
            this.SFWPicsTextBox.CustomButton.Image = null;
            this.SFWPicsTextBox.CustomButton.Location = new System.Drawing.Point(226, 1);
            this.SFWPicsTextBox.CustomButton.Name = "";
            this.SFWPicsTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SFWPicsTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SFWPicsTextBox.CustomButton.TabIndex = 1;
            this.SFWPicsTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SFWPicsTextBox.CustomButton.UseSelectable = true;
            this.SFWPicsTextBox.CustomButton.Visible = false;
            this.SFWPicsTextBox.Lines = new string[0];
            this.SFWPicsTextBox.Location = new System.Drawing.Point(3, 262);
            this.SFWPicsTextBox.MaxLength = 32767;
            this.SFWPicsTextBox.Name = "SFWPicsTextBox";
            this.SFWPicsTextBox.PasswordChar = '\0';
            this.SFWPicsTextBox.PromptText = "SFW Picture Folder";
            this.SFWPicsTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SFWPicsTextBox.SelectedText = "";
            this.SFWPicsTextBox.SelectionLength = 0;
            this.SFWPicsTextBox.SelectionStart = 0;
            this.SFWPicsTextBox.ShortcutsEnabled = true;
            this.SFWPicsTextBox.Size = new System.Drawing.Size(248, 23);
            this.SFWPicsTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.SFWPicsTextBox.TabIndex = 9;
            this.SFWPicsTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SFWPicsTextBox.UseSelectable = true;
            this.SFWPicsTextBox.WaterMark = "SFW Picture Folder";
            this.SFWPicsTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SFWPicsTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // NSFWPicsListView
            // 
            this.NSFWPicsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.NSFWPicsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.NSFWFolders});
            this.NSFWPicsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.NSFWPicsListView.ForeColor = System.Drawing.Color.White;
            this.NSFWPicsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.NSFWPicsListView.Location = new System.Drawing.Point(477, 40);
            this.NSFWPicsListView.MultiSelect = false;
            this.NSFWPicsListView.Name = "NSFWPicsListView";
            this.NSFWPicsListView.Size = new System.Drawing.Size(442, 216);
            this.NSFWPicsListView.TabIndex = 3;
            this.NSFWPicsListView.UseCompatibleStateImageBehavior = false;
            this.NSFWPicsListView.View = System.Windows.Forms.View.Details;
            this.NSFWPicsListView.SelectedIndexChanged += new System.EventHandler(this.NSFWPicsListView_SelectedIndexChanged);
            // 
            // SFWPicsListView
            // 
            this.SFWPicsListView.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(22)))), ((int)(((byte)(22)))), ((int)(((byte)(22)))));
            this.SFWPicsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.SFWFolders});
            this.SFWPicsListView.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.SFWPicsListView.ForeColor = System.Drawing.Color.White;
            this.SFWPicsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.SFWPicsListView.Location = new System.Drawing.Point(3, 40);
            this.SFWPicsListView.MultiSelect = false;
            this.SFWPicsListView.Name = "SFWPicsListView";
            this.SFWPicsListView.Size = new System.Drawing.Size(442, 216);
            this.SFWPicsListView.TabIndex = 2;
            this.SFWPicsListView.UseCompatibleStateImageBehavior = false;
            this.SFWPicsListView.View = System.Windows.Forms.View.Details;
            this.SFWPicsListView.SelectedIndexChanged += new System.EventHandler(this.SFWPicsListView_SelectedIndexChanged);
            // 
            // DefaultPage
            // 
            this.DefaultPage.BackColor = System.Drawing.Color.Transparent;
            this.DefaultPage.Controls.Add(this.TokenSaveCheck);
            this.DefaultPage.Controls.Add(this.FileSendButton);
            this.DefaultPage.Controls.Add(this.DisconnectButton);
            this.DefaultPage.Controls.Add(this.ConnectButton);
            this.DefaultPage.Controls.Add(this.TokenBox);
            this.DefaultPage.Controls.Add(this.ChatInBox);
            this.DefaultPage.Controls.Add(this.ChatOutBox);
            this.DefaultPage.Controls.Add(this.ChannelListView);
            this.DefaultPage.ForeColor = System.Drawing.Color.White;
            this.DefaultPage.HorizontalScrollbarBarColor = true;
            this.DefaultPage.HorizontalScrollbarHighlightOnWheel = false;
            this.DefaultPage.HorizontalScrollbarSize = 10;
            this.DefaultPage.Location = new System.Drawing.Point(4, 38);
            this.DefaultPage.Name = "DefaultPage";
            this.DefaultPage.Padding = new System.Windows.Forms.Padding(3);
            this.DefaultPage.Size = new System.Drawing.Size(926, 456);
            this.DefaultPage.Style = MetroFramework.MetroColorStyle.Blue;
            this.DefaultPage.TabIndex = 0;
            this.DefaultPage.Text = "[DEFAULT]";
            this.DefaultPage.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.DefaultPage.VerticalScrollbarBarColor = true;
            this.DefaultPage.VerticalScrollbarHighlightOnWheel = false;
            this.DefaultPage.VerticalScrollbarSize = 10;
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
            this.ChannelListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.GuildChannels});
            this.ChannelListView.ForeColor = System.Drawing.Color.White;
            this.ChannelListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.ChannelListView.Location = new System.Drawing.Point(7, 6);
            this.ChannelListView.MultiSelect = false;
            this.ChannelListView.Name = "ChannelListView";
            this.ChannelListView.Size = new System.Drawing.Size(280, 364);
            this.ChannelListView.TabIndex = 0;
            this.ChannelListView.UseCompatibleStateImageBehavior = false;
            this.ChannelListView.View = System.Windows.Forms.View.Details;
            this.ChannelListView.ItemSelectionChanged += new System.Windows.Forms.ListViewItemSelectionChangedEventHandler(this.ChannelSelectionChanged);
            // 
            // GuildChannels
            // 
            this.GuildChannels.Width = 276;
            // 
            // SFWFolders
            // 
            this.SFWFolders.Text = "SFWFolders";
            this.SFWFolders.Width = 438;
            // 
            // NSFWFolders
            // 
            this.NSFWFolders.Text = "NSFWFolders";
            this.NSFWFolders.Width = 438;
            // 
            // SankakuUserNameTextBox
            // 
            // 
            // 
            // 
            this.SankakuUserNameTextBox.CustomButton.Image = null;
            this.SankakuUserNameTextBox.CustomButton.Location = new System.Drawing.Point(226, 1);
            this.SankakuUserNameTextBox.CustomButton.Name = "";
            this.SankakuUserNameTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SankakuUserNameTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SankakuUserNameTextBox.CustomButton.TabIndex = 1;
            this.SankakuUserNameTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SankakuUserNameTextBox.CustomButton.UseSelectable = true;
            this.SankakuUserNameTextBox.CustomButton.Visible = false;
            this.SankakuUserNameTextBox.Lines = new string[0];
            this.SankakuUserNameTextBox.Location = new System.Drawing.Point(3, 362);
            this.SankakuUserNameTextBox.MaxLength = 32767;
            this.SankakuUserNameTextBox.Name = "SankakuUserNameTextBox";
            this.SankakuUserNameTextBox.PasswordChar = '\0';
            this.SankakuUserNameTextBox.PromptText = "Username";
            this.SankakuUserNameTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SankakuUserNameTextBox.SelectedText = "";
            this.SankakuUserNameTextBox.SelectionLength = 0;
            this.SankakuUserNameTextBox.SelectionStart = 0;
            this.SankakuUserNameTextBox.ShortcutsEnabled = true;
            this.SankakuUserNameTextBox.Size = new System.Drawing.Size(248, 23);
            this.SankakuUserNameTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.SankakuUserNameTextBox.TabIndex = 15;
            this.SankakuUserNameTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SankakuUserNameTextBox.UseSelectable = true;
            this.SankakuUserNameTextBox.WaterMark = "Username";
            this.SankakuUserNameTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SankakuUserNameTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // SankakuPasswordTextBox
            // 
            // 
            // 
            // 
            this.SankakuPasswordTextBox.CustomButton.Image = null;
            this.SankakuPasswordTextBox.CustomButton.Location = new System.Drawing.Point(226, 1);
            this.SankakuPasswordTextBox.CustomButton.Name = "";
            this.SankakuPasswordTextBox.CustomButton.Size = new System.Drawing.Size(21, 21);
            this.SankakuPasswordTextBox.CustomButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SankakuPasswordTextBox.CustomButton.TabIndex = 1;
            this.SankakuPasswordTextBox.CustomButton.Theme = MetroFramework.MetroThemeStyle.Light;
            this.SankakuPasswordTextBox.CustomButton.UseSelectable = true;
            this.SankakuPasswordTextBox.CustomButton.Visible = false;
            this.SankakuPasswordTextBox.Lines = new string[0];
            this.SankakuPasswordTextBox.Location = new System.Drawing.Point(3, 391);
            this.SankakuPasswordTextBox.MaxLength = 32767;
            this.SankakuPasswordTextBox.Name = "SankakuPasswordTextBox";
            this.SankakuPasswordTextBox.PasswordChar = '●';
            this.SankakuPasswordTextBox.PromptText = "Password";
            this.SankakuPasswordTextBox.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.SankakuPasswordTextBox.SelectedText = "";
            this.SankakuPasswordTextBox.SelectionLength = 0;
            this.SankakuPasswordTextBox.SelectionStart = 0;
            this.SankakuPasswordTextBox.ShortcutsEnabled = true;
            this.SankakuPasswordTextBox.Size = new System.Drawing.Size(248, 23);
            this.SankakuPasswordTextBox.Style = MetroFramework.MetroColorStyle.Blue;
            this.SankakuPasswordTextBox.TabIndex = 16;
            this.SankakuPasswordTextBox.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SankakuPasswordTextBox.UseSelectable = true;
            this.SankakuPasswordTextBox.UseSystemPasswordChar = true;
            this.SankakuPasswordTextBox.WaterMark = "Password";
            this.SankakuPasswordTextBox.WaterMarkColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.SankakuPasswordTextBox.WaterMarkFont = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Pixel);
            // 
            // metroLabel4
            // 
            this.metroLabel4.AutoSize = true;
            this.metroLabel4.Location = new System.Drawing.Point(0, 340);
            this.metroLabel4.Name = "metroLabel4";
            this.metroLabel4.Size = new System.Drawing.Size(92, 19);
            this.metroLabel4.Style = MetroFramework.MetroColorStyle.Blue;
            this.metroLabel4.TabIndex = 17;
            this.metroLabel4.Text = "Sankaku Login";
            this.metroLabel4.Theme = MetroFramework.MetroThemeStyle.Dark;
            // 
            // SankakuLoginButton
            // 
            this.SankakuLoginButton.Location = new System.Drawing.Point(3, 421);
            this.SankakuLoginButton.Name = "SankakuLoginButton";
            this.SankakuLoginButton.Size = new System.Drawing.Size(248, 23);
            this.SankakuLoginButton.Style = MetroFramework.MetroColorStyle.Blue;
            this.SankakuLoginButton.TabIndex = 18;
            this.SankakuLoginButton.Text = "Login";
            this.SankakuLoginButton.Theme = MetroFramework.MetroThemeStyle.Dark;
            this.SankakuLoginButton.UseSelectable = true;
            this.SankakuLoginButton.Click += new System.EventHandler(this.SankakuLoginButton_Click);
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
            this.PicturesPage.ResumeLayout(false);
            this.PicturesPage.PerformLayout();
            this.DefaultPage.ResumeLayout(false);
            this.DefaultPage.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        public MetroFramework.Controls.MetroTabPage DefaultPage;
        public System.Windows.Forms.ListView ChannelListView;
        public MetroFramework.Controls.MetroTextBox ChatInBox;
        public MetroFramework.Controls.MetroTextBox TokenBox;
        public MetroFramework.Controls.MetroButton DisconnectButton;
        public MetroFramework.Controls.MetroButton ConnectButton;
        public MetroFramework.Controls.MetroTabControl tabControl1;
        public System.Windows.Forms.RichTextBox ChatOutBox;
        public MetroFramework.Controls.MetroButton FileSendButton;
        public System.Windows.Forms.ListBox PresenceBox;
        public MetroFramework.Controls.MetroButton SetGameButton;
        public MetroFramework.Controls.MetroTextBox SetGameTextBox;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        public MetroFramework.Controls.MetroTabPage SettingsPage;
        private MetroFramework.Controls.MetroLabel metroLabel2;
        public System.Windows.Forms.ListView BlackListView;
        private System.Windows.Forms.ColumnHeader Guild;
        private System.Windows.Forms.ColumnHeader Channel;
        private System.Windows.Forms.ColumnHeader ChannelID;
        public System.Windows.Forms.ListView AdminListView;
        public MetroFramework.Controls.MetroTextBox UserJoinMessageBox;
        public MetroFramework.Controls.MetroComboBox UserJoinChannelsComboBox;
        public System.Windows.Forms.ListView MessagesListView;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        public MetroFramework.Controls.MetroButton metroButton1;
        public MetroFramework.Controls.MetroButton ConnectedMessageAddButton;
        private MetroFramework.Controls.MetroLabel metroLabel3;
        public MetroFramework.Controls.MetroButton OwnerButton;
        public MetroFramework.Controls.MetroTextBox OwnerIDBox;
        private System.Windows.Forms.ColumnHeader GuildChannels;
        public MetroFramework.Controls.MetroTabPage PicturesPage;
        public MetroFramework.Controls.MetroTextBox SFWPicsTextBox;
        public MetroFramework.Controls.MetroButton SFWAddFolder;
        public MetroFramework.Controls.MetroButton RemoveSFWButton;
        public MetroFramework.Controls.MetroButton NSFWRemoveButton;
        public MetroFramework.Controls.MetroButton NSFWAddButton;
        public MetroFramework.Controls.MetroTextBox NSFWPicsTextBox;
        public System.Windows.Forms.ListView NSFWPicsListView;
        public System.Windows.Forms.ListView SFWPicsListView;
        private System.Windows.Forms.ColumnHeader SFWFolders;
        private System.Windows.Forms.ColumnHeader NSFWFolders;
        private MetroFramework.Controls.MetroLabel metroLabel4;
        public MetroFramework.Controls.MetroTextBox SankakuPasswordTextBox;
        public MetroFramework.Controls.MetroTextBox SankakuUserNameTextBox;
        public MetroFramework.Controls.MetroButton SankakuLoginButton;
        public MetroFramework.Controls.MetroCheckBox TokenSaveCheck;
    }
}

