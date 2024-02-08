namespace SFTP
{
    partial class frmSFTPMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmSFTPMain));
            this.ObjectStorageGroupBox = new System.Windows.Forms.GroupBox();
            this.txtBucket = new System.Windows.Forms.TextBox();
            this.lbBucket = new System.Windows.Forms.Label();
            this.lbRegion = new System.Windows.Forms.Label();
            this.txtRegion = new System.Windows.Forms.TextBox();
            this.SaveObjectStorageCheckBox = new System.Windows.Forms.CheckBox();
            this.txtUser = new System.Windows.Forms.TextBox();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtHost = new System.Windows.Forms.TextBox();
            this.lbPort = new System.Windows.Forms.Label();
            this.lbPassword = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbHost = new System.Windows.Forms.Label();
            this.LogSaveCheckBox = new System.Windows.Forms.CheckBox();
            this.txtLog = new System.Windows.Forms.TextBox();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.lbCurrentTime = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.LogGroupBox = new System.Windows.Forms.GroupBox();
            this.textBoxLogPath = new System.Windows.Forms.TextBox();
            this.labelLogPath = new System.Windows.Forms.Label();
            this.ScheduleGroupBox = new System.Windows.Forms.GroupBox();
            this.labelCountDown = new System.Windows.Forms.Label();
            this.labelTimeZone = new System.Windows.Forms.Label();
            this.SaveScheduleCheckBox = new System.Windows.Forms.CheckBox();
            this.labelMin = new System.Windows.Forms.Label();
            this.SyncIntervalMinTextBox = new System.Windows.Forms.TextBox();
            this.labelInterval = new System.Windows.Forms.Label();
            this.labelHr = new System.Windows.Forms.Label();
            this.SyncIntervalHourTextBox = new System.Windows.Forms.TextBox();
            this.LocalDirGroupBox = new System.Windows.Forms.GroupBox();
            this.btnBrowser = new System.Windows.Forms.Button();
            this.txtBrowser = new System.Windows.Forms.TextBox();
            this.SaveDirCheckBox = new System.Windows.Forms.CheckBox();
            this.TopicServerGroupBox = new System.Windows.Forms.GroupBox();
            this.txtTopic = new System.Windows.Forms.TextBox();
            this.lbTopic = new System.Windows.Forms.Label();
            this.SaveTopicServerCheckBox = new System.Windows.Forms.CheckBox();
            this.txtTopicServer = new System.Windows.Forms.TextBox();
            this.lbTopicServer = new System.Windows.Forms.Label();
            this.btnAutoCtrl = new System.Windows.Forms.Button();
            this.btnDisconnect = new System.Windows.Forms.Button();
            this.ETLGroupBox = new System.Windows.Forms.GroupBox();
            this.checkBoxETL = new System.Windows.Forms.CheckBox();
            this.btnETL = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.lblStatus = new System.Windows.Forms.Label();
            this.SparkSettingGroupBox = new System.Windows.Forms.GroupBox();
            this.btnSpark = new System.Windows.Forms.Button();
            this.ObjectStorageGroupBox.SuspendLayout();
            this.LogGroupBox.SuspendLayout();
            this.ScheduleGroupBox.SuspendLayout();
            this.LocalDirGroupBox.SuspendLayout();
            this.TopicServerGroupBox.SuspendLayout();
            this.ETLGroupBox.SuspendLayout();
            this.SparkSettingGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectStorageGroupBox
            // 
            this.ObjectStorageGroupBox.Controls.Add(this.txtBucket);
            this.ObjectStorageGroupBox.Controls.Add(this.lbBucket);
            this.ObjectStorageGroupBox.Controls.Add(this.lbRegion);
            this.ObjectStorageGroupBox.Controls.Add(this.txtRegion);
            this.ObjectStorageGroupBox.Controls.Add(this.SaveObjectStorageCheckBox);
            this.ObjectStorageGroupBox.Controls.Add(this.txtUser);
            this.ObjectStorageGroupBox.Controls.Add(this.txtPort);
            this.ObjectStorageGroupBox.Controls.Add(this.txtPassword);
            this.ObjectStorageGroupBox.Controls.Add(this.txtHost);
            this.ObjectStorageGroupBox.Controls.Add(this.lbPort);
            this.ObjectStorageGroupBox.Controls.Add(this.lbPassword);
            this.ObjectStorageGroupBox.Controls.Add(this.lbUser);
            this.ObjectStorageGroupBox.Controls.Add(this.lbHost);
            this.ObjectStorageGroupBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ObjectStorageGroupBox.Location = new System.Drawing.Point(5, 5);
            this.ObjectStorageGroupBox.Name = "ObjectStorageGroupBox";
            this.ObjectStorageGroupBox.Size = new System.Drawing.Size(420, 110);
            this.ObjectStorageGroupBox.TabIndex = 0;
            this.ObjectStorageGroupBox.TabStop = false;
            this.ObjectStorageGroupBox.Text = "Object Storage 접속 정보";
            // 
            // txtBucket
            // 
            this.txtBucket.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtBucket.Location = new System.Drawing.Point(60, 50);
            this.txtBucket.Name = "txtBucket";
            this.txtBucket.Size = new System.Drawing.Size(120, 25);
            this.txtBucket.TabIndex = 9;
            // 
            // lbBucket
            // 
            this.lbBucket.AutoSize = true;
            this.lbBucket.Location = new System.Drawing.Point(10, 55);
            this.lbBucket.Name = "lbBucket";
            this.lbBucket.Size = new System.Drawing.Size(48, 17);
            this.lbBucket.TabIndex = 8;
            this.lbBucket.Text = "Bucket";
            // 
            // lbRegion
            // 
            this.lbRegion.AutoSize = true;
            this.lbRegion.Location = new System.Drawing.Point(190, 55);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(50, 17);
            this.lbRegion.TabIndex = 7;
            this.lbRegion.Text = "Region";
            // 
            // txtRegion
            // 
            this.txtRegion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtRegion.Location = new System.Drawing.Point(240, 50);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(120, 25);
            this.txtRegion.TabIndex = 6;
            // 
            // SaveObjectStorageCheckBox
            // 
            this.SaveObjectStorageCheckBox.AutoSize = true;
            this.SaveObjectStorageCheckBox.Location = new System.Drawing.Point(365, 80);
            this.SaveObjectStorageCheckBox.Name = "SaveObjectStorageCheckBox";
            this.SaveObjectStorageCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveObjectStorageCheckBox.TabIndex = 5;
            this.SaveObjectStorageCheckBox.Text = "저장";
            this.SaveObjectStorageCheckBox.UseVisualStyleBackColor = true;
            this.SaveObjectStorageCheckBox.CheckedChanged += new System.EventHandler(this.SaveLogInCheckBox_CheckedChanged);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(60, 80);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(120, 25);
            this.txtUser.TabIndex = 2;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtPort.Location = new System.Drawing.Point(240, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(120, 25);
            this.txtPort.TabIndex = 1;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(240, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(120, 25);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(60, 20);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(120, 25);
            this.txtHost.TabIndex = 0;
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(190, 25);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(32, 17);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "Port";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(190, 85);
            this.lbPassword.Name = "lbPassword";
            this.lbPassword.Size = new System.Drawing.Size(27, 17);
            this.lbPassword.TabIndex = 2;
            this.lbPassword.Text = "PW";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Location = new System.Drawing.Point(10, 85);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(35, 17);
            this.lbUser.TabIndex = 0;
            this.lbUser.Text = "User";
            // 
            // lbHost
            // 
            this.lbHost.AutoSize = true;
            this.lbHost.Location = new System.Drawing.Point(10, 25);
            this.lbHost.Name = "lbHost";
            this.lbHost.Size = new System.Drawing.Size(35, 17);
            this.lbHost.TabIndex = 1;
            this.lbHost.Text = "Host";
            // 
            // LogSaveCheckBox
            // 
            this.LogSaveCheckBox.AutoSize = true;
            this.LogSaveCheckBox.Checked = true;
            this.LogSaveCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.LogSaveCheckBox.Location = new System.Drawing.Point(5, 190);
            this.LogSaveCheckBox.Name = "LogSaveCheckBox";
            this.LogSaveCheckBox.Size = new System.Drawing.Size(84, 21);
            this.LogSaveCheckBox.TabIndex = 20;
            this.LogSaveCheckBox.Text = "로그 저장";
            this.LogSaveCheckBox.UseVisualStyleBackColor = true;
            this.LogSaveCheckBox.CheckedChanged += new System.EventHandler(this.LogSaveCheckBox_CheckedChanged);
            // 
            // txtLog
            // 
            this.txtLog.AcceptsReturn = true;
            this.txtLog.AcceptsTab = true;
            this.txtLog.AccessibleName = "";
            this.txtLog.Location = new System.Drawing.Point(5, 25);
            this.txtLog.Multiline = true;
            this.txtLog.Name = "txtLog";
            this.txtLog.ReadOnly = true;
            this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtLog.Size = new System.Drawing.Size(490, 160);
            this.txtLog.TabIndex = 4;
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_SyncFiles);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.BackColor = System.Drawing.SystemColors.Menu;
            this.lbCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCurrentTime.Location = new System.Drawing.Point(560, 320);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(188, 18);
            this.lbCurrentTime.TabIndex = 21;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(555, 295);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(500, 20);
            this.progressBar.TabIndex = 18;
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Controls.Add(this.textBoxLogPath);
            this.LogGroupBox.Controls.Add(this.labelLogPath);
            this.LogGroupBox.Controls.Add(this.txtLog);
            this.LogGroupBox.Controls.Add(this.LogSaveCheckBox);
            this.LogGroupBox.Location = new System.Drawing.Point(555, 5);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(500, 285);
            this.LogGroupBox.TabIndex = 22;
            this.LogGroupBox.TabStop = false;
            this.LogGroupBox.Text = "Logs";
            // 
            // textBoxLogPath
            // 
            this.textBoxLogPath.AcceptsReturn = true;
            this.textBoxLogPath.AcceptsTab = true;
            this.textBoxLogPath.AccessibleName = "";
            this.textBoxLogPath.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.textBoxLogPath.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBoxLogPath.Location = new System.Drawing.Point(5, 230);
            this.textBoxLogPath.Multiline = true;
            this.textBoxLogPath.Name = "textBoxLogPath";
            this.textBoxLogPath.ReadOnly = true;
            this.textBoxLogPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogPath.Size = new System.Drawing.Size(490, 45);
            this.textBoxLogPath.TabIndex = 39;
            // 
            // labelLogPath
            // 
            this.labelLogPath.AutoSize = true;
            this.labelLogPath.Location = new System.Drawing.Point(5, 210);
            this.labelLogPath.Name = "labelLogPath";
            this.labelLogPath.Size = new System.Drawing.Size(107, 22);
            this.labelLogPath.TabIndex = 38;
            this.labelLogPath.Text = "로그 저장 경로:  ";
            this.labelLogPath.UseCompatibleTextRendering = true;
            // 
            // ScheduleGroupBox
            // 
            this.ScheduleGroupBox.Controls.Add(this.labelCountDown);
            this.ScheduleGroupBox.Controls.Add(this.labelTimeZone);
            this.ScheduleGroupBox.Controls.Add(this.SaveScheduleCheckBox);
            this.ScheduleGroupBox.Controls.Add(this.labelMin);
            this.ScheduleGroupBox.Controls.Add(this.SyncIntervalMinTextBox);
            this.ScheduleGroupBox.Controls.Add(this.labelInterval);
            this.ScheduleGroupBox.Controls.Add(this.labelHr);
            this.ScheduleGroupBox.Controls.Add(this.SyncIntervalHourTextBox);
            this.ScheduleGroupBox.Location = new System.Drawing.Point(5, 260);
            this.ScheduleGroupBox.Name = "ScheduleGroupBox";
            this.ScheduleGroupBox.Size = new System.Drawing.Size(420, 55);
            this.ScheduleGroupBox.TabIndex = 12;
            this.ScheduleGroupBox.TabStop = false;
            this.ScheduleGroupBox.Text = "작업 스케줄러";
            // 
            // labelCountDown
            // 
            this.labelCountDown.AutoSize = true;
            this.labelCountDown.Location = new System.Drawing.Point(200, 25);
            this.labelCountDown.Name = "labelCountDown";
            this.labelCountDown.Size = new System.Drawing.Size(153, 17);
            this.labelCountDown.TabIndex = 37;
            this.labelCountDown.Text = "Count down: 0 분 00 초";
            // 
            // labelTimeZone
            // 
            this.labelTimeZone.AutoSize = true;
            this.labelTimeZone.Location = new System.Drawing.Point(161, 214);
            this.labelTimeZone.Name = "labelTimeZone";
            this.labelTimeZone.Size = new System.Drawing.Size(0, 17);
            this.labelTimeZone.TabIndex = 36;
            // 
            // SaveScheduleCheckBox
            // 
            this.SaveScheduleCheckBox.AutoSize = true;
            this.SaveScheduleCheckBox.Location = new System.Drawing.Point(365, 25);
            this.SaveScheduleCheckBox.Name = "SaveScheduleCheckBox";
            this.SaveScheduleCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveScheduleCheckBox.TabIndex = 14;
            this.SaveScheduleCheckBox.Text = "저장";
            this.SaveScheduleCheckBox.UseVisualStyleBackColor = true;
            this.SaveScheduleCheckBox.CheckedChanged += new System.EventHandler(this.SaveOptCheckBox_CheckedChanged);
            // 
            // labelMin
            // 
            this.labelMin.AutoSize = true;
            this.labelMin.Location = new System.Drawing.Point(170, 25);
            this.labelMin.Name = "labelMin";
            this.labelMin.Size = new System.Drawing.Size(21, 17);
            this.labelMin.TabIndex = 11;
            this.labelMin.Text = "분";
            // 
            // SyncIntervalMinTextBox
            // 
            this.SyncIntervalMinTextBox.Location = new System.Drawing.Point(130, 20);
            this.SyncIntervalMinTextBox.Name = "SyncIntervalMinTextBox";
            this.SyncIntervalMinTextBox.Size = new System.Drawing.Size(38, 25);
            this.SyncIntervalMinTextBox.TabIndex = 10;
            this.SyncIntervalMinTextBox.TextChanged += new System.EventHandler(this.SyncIntervalMinTextBox_TextChanged);
            // 
            // labelInterval
            // 
            this.labelInterval.AutoSize = true;
            this.labelInterval.Location = new System.Drawing.Point(10, 25);
            this.labelInterval.Name = "labelInterval";
            this.labelInterval.Size = new System.Drawing.Size(52, 17);
            this.labelInterval.TabIndex = 8;
            this.labelInterval.Text = "Interval";
            // 
            // labelHr
            // 
            this.labelHr.AutoSize = true;
            this.labelHr.Location = new System.Drawing.Point(110, 25);
            this.labelHr.Name = "labelHr";
            this.labelHr.Size = new System.Drawing.Size(21, 17);
            this.labelHr.TabIndex = 9;
            this.labelHr.Text = "시";
            // 
            // SyncIntervalHourTextBox
            // 
            this.SyncIntervalHourTextBox.Location = new System.Drawing.Point(70, 20);
            this.SyncIntervalHourTextBox.Name = "SyncIntervalHourTextBox";
            this.SyncIntervalHourTextBox.Size = new System.Drawing.Size(38, 25);
            this.SyncIntervalHourTextBox.TabIndex = 7;
            this.SyncIntervalHourTextBox.TextChanged += new System.EventHandler(this.SyncIntervalHourTextBox_TextChanged);
            // 
            // LocalDirGroupBox
            // 
            this.LocalDirGroupBox.Controls.Add(this.btnBrowser);
            this.LocalDirGroupBox.Controls.Add(this.txtBrowser);
            this.LocalDirGroupBox.Controls.Add(this.SaveDirCheckBox);
            this.LocalDirGroupBox.Location = new System.Drawing.Point(5, 200);
            this.LocalDirGroupBox.Name = "LocalDirGroupBox";
            this.LocalDirGroupBox.Size = new System.Drawing.Size(420, 60);
            this.LocalDirGroupBox.TabIndex = 23;
            this.LocalDirGroupBox.TabStop = false;
            this.LocalDirGroupBox.Text = "Local 경로 지정";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowser.Location = new System.Drawing.Point(315, 25);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(45, 25);
            this.btnBrowser.TabIndex = 1;
            this.btnBrowser.Text = ". . .";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // txtBrowser
            // 
            this.txtBrowser.Location = new System.Drawing.Point(10, 25);
            this.txtBrowser.Name = "txtBrowser";
            this.txtBrowser.Size = new System.Drawing.Size(300, 25);
            this.txtBrowser.TabIndex = 0;
            this.txtBrowser.TextChanged += new System.EventHandler(this.txtBrowser_TextChanged);
            // 
            // SaveDirCheckBox
            // 
            this.SaveDirCheckBox.AutoSize = true;
            this.SaveDirCheckBox.Location = new System.Drawing.Point(365, 30);
            this.SaveDirCheckBox.Name = "SaveDirCheckBox";
            this.SaveDirCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveDirCheckBox.TabIndex = 14;
            this.SaveDirCheckBox.Text = "저장";
            this.SaveDirCheckBox.UseVisualStyleBackColor = true;
            this.SaveDirCheckBox.CheckedChanged += new System.EventHandler(this.SaveDirCheckBox_CheckedChanged);
            // 
            // TopicServerGroupBox
            // 
            this.TopicServerGroupBox.Controls.Add(this.txtTopic);
            this.TopicServerGroupBox.Controls.Add(this.lbTopic);
            this.TopicServerGroupBox.Controls.Add(this.SaveTopicServerCheckBox);
            this.TopicServerGroupBox.Controls.Add(this.txtTopicServer);
            this.TopicServerGroupBox.Controls.Add(this.lbTopicServer);
            this.TopicServerGroupBox.Location = new System.Drawing.Point(5, 115);
            this.TopicServerGroupBox.Name = "TopicServerGroupBox";
            this.TopicServerGroupBox.Size = new System.Drawing.Size(420, 85);
            this.TopicServerGroupBox.TabIndex = 51;
            this.TopicServerGroupBox.TabStop = false;
            this.TopicServerGroupBox.Text = "Topic Server 정보";
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(130, 50);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(230, 25);
            this.txtTopic.TabIndex = 54;
            // 
            // lbTopic
            // 
            this.lbTopic.AutoSize = true;
            this.lbTopic.Location = new System.Drawing.Point(10, 55);
            this.lbTopic.Name = "lbTopic";
            this.lbTopic.Size = new System.Drawing.Size(109, 17);
            this.lbTopic.TabIndex = 4;
            this.lbTopic.Text = "Topic Title Name";
            // 
            // SaveTopicServerCheckBox
            // 
            this.SaveTopicServerCheckBox.AutoSize = true;
            this.SaveTopicServerCheckBox.Location = new System.Drawing.Point(365, 60);
            this.SaveTopicServerCheckBox.Name = "SaveTopicServerCheckBox";
            this.SaveTopicServerCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveTopicServerCheckBox.TabIndex = 53;
            this.SaveTopicServerCheckBox.Text = "저장";
            this.SaveTopicServerCheckBox.UseVisualStyleBackColor = true;
            this.SaveTopicServerCheckBox.CheckedChanged += new System.EventHandler(this.SaveTopicServerCheckBox_CheckedChanged);
            // 
            // txtTopicServer
            // 
            this.txtTopicServer.Location = new System.Drawing.Point(130, 20);
            this.txtTopicServer.Name = "txtTopicServer";
            this.txtTopicServer.Size = new System.Drawing.Size(230, 25);
            this.txtTopicServer.TabIndex = 50;
            this.txtTopicServer.TextChanged += new System.EventHandler(this.txtServerFolder_TextChanged);
            // 
            // lbTopicServer
            // 
            this.lbTopicServer.AutoSize = true;
            this.lbTopicServer.Location = new System.Drawing.Point(10, 25);
            this.lbTopicServer.Name = "lbTopicServer";
            this.lbTopicServer.Size = new System.Drawing.Size(108, 17);
            this.lbTopicServer.TabIndex = 39;
            this.lbTopicServer.Text = "Bootstrap-Server";
            // 
            // btnAutoCtrl
            // 
            this.btnAutoCtrl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAutoCtrl.Location = new System.Drawing.Point(431, 12);
            this.btnAutoCtrl.Name = "btnAutoCtrl";
            this.btnAutoCtrl.Size = new System.Drawing.Size(120, 60);
            this.btnAutoCtrl.TabIndex = 15;
            this.btnAutoCtrl.Text = "자동 실행";
            this.btnAutoCtrl.UseVisualStyleBackColor = false;
            this.btnAutoCtrl.Click += new System.EventHandler(this.btnAutoCtrl_Click);
            // 
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnDisconnect.Location = new System.Drawing.Point(429, 269);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(122, 46);
            this.btnDisconnect.TabIndex = 16;
            this.btnDisconnect.Text = "강제 종료";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // ETLGroupBox
            // 
            this.ETLGroupBox.Controls.Add(this.checkBoxETL);
            this.ETLGroupBox.Controls.Add(this.btnETL);
            this.ETLGroupBox.Location = new System.Drawing.Point(431, 148);
            this.ETLGroupBox.Name = "ETLGroupBox";
            this.ETLGroupBox.Size = new System.Drawing.Size(120, 112);
            this.ETLGroupBox.TabIndex = 11;
            this.ETLGroupBox.TabStop = false;
            this.ETLGroupBox.Text = "ETL 관련 설정";
            // 
            // checkBoxETL
            // 
            this.checkBoxETL.AutoSize = true;
            this.checkBoxETL.Location = new System.Drawing.Point(10, 35);
            this.checkBoxETL.Name = "checkBoxETL";
            this.checkBoxETL.Size = new System.Drawing.Size(78, 21);
            this.checkBoxETL.TabIndex = 1;
            this.checkBoxETL.Text = "ETL 사용";
            this.checkBoxETL.UseVisualStyleBackColor = true;
            this.checkBoxETL.CheckedChanged += new System.EventHandler(this.checkBoxETL_CheckedChanged);
            // 
            // btnETL
            // 
            this.btnETL.Enabled = false;
            this.btnETL.Location = new System.Drawing.Point(10, 65);
            this.btnETL.Name = "btnETL";
            this.btnETL.Size = new System.Drawing.Size(100, 40);
            this.btnETL.TabIndex = 0;
            this.btnETL.Text = "ETL 설정";
            this.btnETL.UseVisualStyleBackColor = true;
            this.btnETL.Click += new System.EventHandler(this.btnETL_Click);
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(768, 321);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 19;
            // 
            // SparkSettingGroupBox
            // 
            this.SparkSettingGroupBox.Controls.Add(this.btnSpark);
            this.SparkSettingGroupBox.Location = new System.Drawing.Point(430, 80);
            this.SparkSettingGroupBox.Name = "SparkSettingGroupBox";
            this.SparkSettingGroupBox.Size = new System.Drawing.Size(120, 62);
            this.SparkSettingGroupBox.TabIndex = 12;
            this.SparkSettingGroupBox.TabStop = false;
            this.SparkSettingGroupBox.Text = "*Spark 설정";
            // 
            // btnSpark
            // 
            this.btnSpark.Location = new System.Drawing.Point(10, 25);
            this.btnSpark.Name = "btnSpark";
            this.btnSpark.Size = new System.Drawing.Size(100, 30);
            this.btnSpark.TabIndex = 0;
            this.btnSpark.Text = "Spark 설정";
            this.btnSpark.UseVisualStyleBackColor = true;
            this.btnSpark.Click += new System.EventHandler(this.btnSpark_Click);
            // 
            // frmSFTPMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1067, 360);
            this.ControlBox = false;
            this.Controls.Add(this.SparkSettingGroupBox);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.ETLGroupBox);
            this.Controls.Add(this.LocalDirGroupBox);
            this.Controls.Add(this.btnAutoCtrl);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.LogGroupBox);
            this.Controls.Add(this.TopicServerGroupBox);
            this.Controls.Add(this.ScheduleGroupBox);
            this.Controls.Add(this.lbCurrentTime);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ObjectStorageGroupBox);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSFTPMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NILE Agent Object Transfer";
            this.TransparencyKey = System.Drawing.Color.WhiteSmoke;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmAgentMain_FormClosing);
            this.Load += new System.EventHandler(this.frmAgentMain_Load);
            this.ObjectStorageGroupBox.ResumeLayout(false);
            this.ObjectStorageGroupBox.PerformLayout();
            this.LogGroupBox.ResumeLayout(false);
            this.LogGroupBox.PerformLayout();
            this.ScheduleGroupBox.ResumeLayout(false);
            this.ScheduleGroupBox.PerformLayout();
            this.LocalDirGroupBox.ResumeLayout(false);
            this.LocalDirGroupBox.PerformLayout();
            this.TopicServerGroupBox.ResumeLayout(false);
            this.TopicServerGroupBox.PerformLayout();
            this.ETLGroupBox.ResumeLayout(false);
            this.ETLGroupBox.PerformLayout();
            this.SparkSettingGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox ObjectStorageGroupBox;
        private System.Windows.Forms.Label lbPort;
        private System.Windows.Forms.Label lbPassword;
        private System.Windows.Forms.Label lbHost;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.TextBox txtUser;
        private System.Windows.Forms.TextBox txtPort;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.TextBox txtHost;
        private System.Windows.Forms.TextBox txtLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.CheckBox SaveObjectStorageCheckBox;
        private System.Windows.Forms.CheckBox LogSaveCheckBox;
        private System.Windows.Forms.TextBox lbCurrentTime;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.GroupBox LogGroupBox;
        private System.Windows.Forms.GroupBox ScheduleGroupBox;
        private System.Windows.Forms.Label labelCountDown;
        private System.Windows.Forms.Label labelTimeZone;
        private System.Windows.Forms.CheckBox SaveScheduleCheckBox;
        private System.Windows.Forms.Label labelMin;
        private System.Windows.Forms.TextBox SyncIntervalMinTextBox;
        private System.Windows.Forms.Label labelInterval;
        private System.Windows.Forms.Label labelHr;
        private System.Windows.Forms.TextBox SyncIntervalHourTextBox;
        private System.Windows.Forms.GroupBox LocalDirGroupBox;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtBrowser;
        private System.Windows.Forms.CheckBox SaveDirCheckBox;
        private System.Windows.Forms.GroupBox TopicServerGroupBox;
        private System.Windows.Forms.CheckBox SaveTopicServerCheckBox;
        private System.Windows.Forms.TextBox txtTopicServer;
        private System.Windows.Forms.Label lbTopicServer;
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.Button btnAutoCtrl;
        private System.Windows.Forms.Label labelLogPath;
        private System.Windows.Forms.TextBox textBoxLogPath;
        private System.Windows.Forms.Label lbRegion;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtBucket;
        private System.Windows.Forms.Label lbBucket;
        private System.Windows.Forms.Label lbTopic;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.GroupBox ETLGroupBox;
        private System.Windows.Forms.Button btnETL;
        private System.Windows.Forms.ToolTip toolTip1;
        private System.Windows.Forms.CheckBox checkBoxETL;
        private System.Windows.Forms.Label lblStatus;
        private System.Windows.Forms.GroupBox SparkSettingGroupBox;
        private System.Windows.Forms.Button btnSpark;
    }
}

