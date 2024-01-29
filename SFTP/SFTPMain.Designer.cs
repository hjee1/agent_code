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
            this.btnConnect = new System.Windows.Forms.Button();
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
            this.lblStatus = new System.Windows.Forms.Label();
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
            this.btnDisconnect = new System.Windows.Forms.Button();
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
            this.FilePatternGroupBox = new System.Windows.Forms.GroupBox();
            this.lbUploadOnlyFileExt = new System.Windows.Forms.Label();
            this.txtJSON = new System.Windows.Forms.TextBox();
            this.lbFileUploadTransform = new System.Windows.Forms.Label();
            this.txtCSV = new System.Windows.Forms.TextBox();
            this.txtUploadOnlyFileExt = new System.Windows.Forms.TextBox();
            this.lbJSON = new System.Windows.Forms.Label();
            this.lbCSV = new System.Windows.Forms.Label();
            this.SaveFileTypeCheckBox = new System.Windows.Forms.CheckBox();
            this.lbFileUploadOnly = new System.Windows.Forms.Label();
            this.CtrlModeGroupBox = new System.Windows.Forms.GroupBox();
            this.labelAutoCtrl = new System.Windows.Forms.Label();
            this.labelManualCtrl = new System.Windows.Forms.Label();
            this.btnAutoCtrl = new System.Windows.Forms.Button();
            this.btnManualCtrl = new System.Windows.Forms.Button();
            this.TargetInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.saveTargetInfo = new System.Windows.Forms.CheckBox();
            this.txtTargetTableName = new System.Windows.Forms.TextBox();
            this.txtTargetDatabase = new System.Windows.Forms.TextBox();
            this.txtTargetCatalog = new System.Windows.Forms.TextBox();
            this.txtTargetType = new System.Windows.Forms.TextBox();
            this.lbTargetTableName = new System.Windows.Forms.Label();
            this.lbTargetDatabase = new System.Windows.Forms.Label();
            this.lbTargetCatalog = new System.Windows.Forms.Label();
            this.lbTargetType = new System.Windows.Forms.Label();
            this.AdditionalOptionGroupBox = new System.Windows.Forms.GroupBox();
            this.txtCsvCustomHeader = new System.Windows.Forms.TextBox();
            this.ckbxHeader = new System.Windows.Forms.CheckBox();
            this.txJsonSelectedKey = new System.Windows.Forms.TextBox();
            this.txtCsvDelim = new System.Windows.Forms.TextBox();
            this.lbJsonSelectedKey = new System.Windows.Forms.Label();
            this.lbCsvDelim = new System.Windows.Forms.Label();
            this.lbCsvCustomHeader = new System.Windows.Forms.Label();
            this.SparkConfigGroupBox = new System.Windows.Forms.GroupBox();
            this.btnSparkConfig = new System.Windows.Forms.Button();
            this.toolTip1 = new System.Windows.Forms.ToolTip(this.components);
            this.ObjectStorageGroupBox.SuspendLayout();
            this.LogGroupBox.SuspendLayout();
            this.ScheduleGroupBox.SuspendLayout();
            this.LocalDirGroupBox.SuspendLayout();
            this.TopicServerGroupBox.SuspendLayout();
            this.FilePatternGroupBox.SuspendLayout();
            this.CtrlModeGroupBox.SuspendLayout();
            this.TargetInfoGroupBox.SuspendLayout();
            this.AdditionalOptionGroupBox.SuspendLayout();
            this.SparkConfigGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // ObjectStorageGroupBox
            // 
            this.ObjectStorageGroupBox.Controls.Add(this.txtBucket);
            this.ObjectStorageGroupBox.Controls.Add(this.lbBucket);
            this.ObjectStorageGroupBox.Controls.Add(this.lbRegion);
            this.ObjectStorageGroupBox.Controls.Add(this.txtRegion);
            this.ObjectStorageGroupBox.Controls.Add(this.SaveObjectStorageCheckBox);
            this.ObjectStorageGroupBox.Controls.Add(this.btnConnect);
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
            this.ObjectStorageGroupBox.Size = new System.Drawing.Size(570, 115);
            this.ObjectStorageGroupBox.TabIndex = 0;
            this.ObjectStorageGroupBox.TabStop = false;
            this.ObjectStorageGroupBox.Text = "Object Storage 접속 정보";
            // 
            // txtBucket
            // 
            this.txtBucket.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtBucket.Location = new System.Drawing.Point(63, 50);
            this.txtBucket.Name = "txtBucket";
            this.txtBucket.Size = new System.Drawing.Size(170, 25);
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
            this.lbRegion.Location = new System.Drawing.Point(240, 55);
            this.lbRegion.Name = "lbRegion";
            this.lbRegion.Size = new System.Drawing.Size(50, 17);
            this.lbRegion.TabIndex = 7;
            this.lbRegion.Text = "Region";
            // 
            // txtRegion
            // 
            this.txtRegion.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtRegion.Location = new System.Drawing.Point(290, 50);
            this.txtRegion.Name = "txtRegion";
            this.txtRegion.Size = new System.Drawing.Size(170, 25);
            this.txtRegion.TabIndex = 6;
            // 
            // SaveObjectStorageCheckBox
            // 
            this.SaveObjectStorageCheckBox.AutoSize = true;
            this.SaveObjectStorageCheckBox.Location = new System.Drawing.Point(515, 90);
            this.SaveObjectStorageCheckBox.Name = "SaveObjectStorageCheckBox";
            this.SaveObjectStorageCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveObjectStorageCheckBox.TabIndex = 5;
            this.SaveObjectStorageCheckBox.Text = "저장";
            this.SaveObjectStorageCheckBox.UseVisualStyleBackColor = true;
            this.SaveObjectStorageCheckBox.CheckedChanged += new System.EventHandler(this.SaveLogInCheckBox_CheckedChanged);
            // 
            // btnConnect
            // 
            this.btnConnect.BackColor = System.Drawing.SystemColors.Control;
            this.btnConnect.Location = new System.Drawing.Point(465, 20);
            this.btnConnect.Name = "btnConnect";
            this.btnConnect.Size = new System.Drawing.Size(98, 63);
            this.btnConnect.TabIndex = 4;
            this.btnConnect.Text = "연결";
            this.btnConnect.UseVisualStyleBackColor = false;
            this.btnConnect.Click += new System.EventHandler(this.btnConnect_Click);
            // 
            // txtUser
            // 
            this.txtUser.Location = new System.Drawing.Point(63, 80);
            this.txtUser.Name = "txtUser";
            this.txtUser.Size = new System.Drawing.Size(170, 25);
            this.txtUser.TabIndex = 2;
            this.txtUser.TextChanged += new System.EventHandler(this.txtUser_TextChanged);
            // 
            // txtPort
            // 
            this.txtPort.ForeColor = System.Drawing.SystemColors.MenuText;
            this.txtPort.Location = new System.Drawing.Point(290, 20);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(170, 25);
            this.txtPort.TabIndex = 1;
            this.txtPort.TextChanged += new System.EventHandler(this.txtPort_TextChanged);
            // 
            // txtPassword
            // 
            this.txtPassword.Location = new System.Drawing.Point(290, 80);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.PasswordChar = '*';
            this.txtPassword.Size = new System.Drawing.Size(170, 25);
            this.txtPassword.TabIndex = 3;
            this.txtPassword.TextChanged += new System.EventHandler(this.txtPassword_TextChanged);
            // 
            // txtHost
            // 
            this.txtHost.Location = new System.Drawing.Point(63, 20);
            this.txtHost.Name = "txtHost";
            this.txtHost.Size = new System.Drawing.Size(170, 25);
            this.txtHost.TabIndex = 0;
            this.txtHost.TextChanged += new System.EventHandler(this.txtHost_TextChanged);
            // 
            // lbPort
            // 
            this.lbPort.AutoSize = true;
            this.lbPort.Location = new System.Drawing.Point(240, 25);
            this.lbPort.Name = "lbPort";
            this.lbPort.Size = new System.Drawing.Size(32, 17);
            this.lbPort.TabIndex = 3;
            this.lbPort.Text = "Port";
            // 
            // lbPassword
            // 
            this.lbPassword.AutoSize = true;
            this.lbPassword.Location = new System.Drawing.Point(240, 85);
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
            this.LogSaveCheckBox.Location = new System.Drawing.Point(5, 390);
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
            this.txtLog.Size = new System.Drawing.Size(410, 360);
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
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Location = new System.Drawing.Point(675, 438);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(0, 17);
            this.lblStatus.TabIndex = 19;
            // 
            // lbCurrentTime
            // 
            this.lbCurrentTime.BackColor = System.Drawing.SystemColors.Menu;
            this.lbCurrentTime.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lbCurrentTime.Location = new System.Drawing.Point(772, 607);
            this.lbCurrentTime.Name = "lbCurrentTime";
            this.lbCurrentTime.Size = new System.Drawing.Size(188, 18);
            this.lbCurrentTime.TabIndex = 21;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(715, 550);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(420, 35);
            this.progressBar.TabIndex = 18;
            // 
            // LogGroupBox
            // 
            this.LogGroupBox.Controls.Add(this.textBoxLogPath);
            this.LogGroupBox.Controls.Add(this.labelLogPath);
            this.LogGroupBox.Controls.Add(this.txtLog);
            this.LogGroupBox.Controls.Add(this.LogSaveCheckBox);
            this.LogGroupBox.Location = new System.Drawing.Point(715, 5);
            this.LogGroupBox.Name = "LogGroupBox";
            this.LogGroupBox.Size = new System.Drawing.Size(420, 540);
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
            this.textBoxLogPath.Location = new System.Drawing.Point(5, 440);
            this.textBoxLogPath.Multiline = true;
            this.textBoxLogPath.Name = "textBoxLogPath";
            this.textBoxLogPath.ReadOnly = true;
            this.textBoxLogPath.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxLogPath.Size = new System.Drawing.Size(410, 90);
            this.textBoxLogPath.TabIndex = 39;
            // 
            // labelLogPath
            // 
            this.labelLogPath.AutoSize = true;
            this.labelLogPath.Location = new System.Drawing.Point(5, 415);
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
            this.ScheduleGroupBox.Location = new System.Drawing.Point(180, 585);
            this.ScheduleGroupBox.Name = "ScheduleGroupBox";
            this.ScheduleGroupBox.Size = new System.Drawing.Size(530, 55);
            this.ScheduleGroupBox.TabIndex = 12;
            this.ScheduleGroupBox.TabStop = false;
            this.ScheduleGroupBox.Text = "작업 스케줄러";
            // 
            // labelCountDown
            // 
            this.labelCountDown.AutoSize = true;
            this.labelCountDown.Location = new System.Drawing.Point(298, 25);
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
            this.SaveScheduleCheckBox.Location = new System.Drawing.Point(475, 25);
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
            // btnDisconnect
            // 
            this.btnDisconnect.BackColor = System.Drawing.SystemColors.ControlDark;
            this.btnDisconnect.Location = new System.Drawing.Point(1012, 590);
            this.btnDisconnect.Name = "btnDisconnect";
            this.btnDisconnect.Size = new System.Drawing.Size(125, 50);
            this.btnDisconnect.TabIndex = 13;
            this.btnDisconnect.Text = "강제종료";
            this.btnDisconnect.UseVisualStyleBackColor = false;
            this.btnDisconnect.Click += new System.EventHandler(this.btnDisconnect_Click);
            // 
            // LocalDirGroupBox
            // 
            this.LocalDirGroupBox.Controls.Add(this.btnBrowser);
            this.LocalDirGroupBox.Controls.Add(this.txtBrowser);
            this.LocalDirGroupBox.Controls.Add(this.SaveDirCheckBox);
            this.LocalDirGroupBox.Location = new System.Drawing.Point(5, 205);
            this.LocalDirGroupBox.Name = "LocalDirGroupBox";
            this.LocalDirGroupBox.Size = new System.Drawing.Size(570, 60);
            this.LocalDirGroupBox.TabIndex = 23;
            this.LocalDirGroupBox.TabStop = false;
            this.LocalDirGroupBox.Text = "Local 경로 지정";
            // 
            // btnBrowser
            // 
            this.btnBrowser.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowser.Location = new System.Drawing.Point(465, 25);
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
            this.txtBrowser.Size = new System.Drawing.Size(450, 25);
            this.txtBrowser.TabIndex = 0;
            this.txtBrowser.TextChanged += new System.EventHandler(this.txtBrowser_TextChanged);
            // 
            // SaveDirCheckBox
            // 
            this.SaveDirCheckBox.AutoSize = true;
            this.SaveDirCheckBox.Location = new System.Drawing.Point(515, 25);
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
            this.TopicServerGroupBox.Location = new System.Drawing.Point(5, 120);
            this.TopicServerGroupBox.Name = "TopicServerGroupBox";
            this.TopicServerGroupBox.Size = new System.Drawing.Size(570, 85);
            this.TopicServerGroupBox.TabIndex = 51;
            this.TopicServerGroupBox.TabStop = false;
            this.TopicServerGroupBox.Text = "Topic Server 정보";
            // 
            // txtTopic
            // 
            this.txtTopic.Location = new System.Drawing.Point(130, 50);
            this.txtTopic.Name = "txtTopic";
            this.txtTopic.Size = new System.Drawing.Size(330, 25);
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
            this.SaveTopicServerCheckBox.Location = new System.Drawing.Point(515, 60);
            this.SaveTopicServerCheckBox.Name = "SaveTopicServerCheckBox";
            this.SaveTopicServerCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveTopicServerCheckBox.TabIndex = 53;
            this.SaveTopicServerCheckBox.Text = "저장";
            this.SaveTopicServerCheckBox.UseVisualStyleBackColor = true;
            // 
            // txtTopicServer
            // 
            this.txtTopicServer.Location = new System.Drawing.Point(130, 20);
            this.txtTopicServer.Name = "txtTopicServer";
            this.txtTopicServer.Size = new System.Drawing.Size(330, 25);
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
            // FilePatternGroupBox
            // 
            this.FilePatternGroupBox.Controls.Add(this.lbUploadOnlyFileExt);
            this.FilePatternGroupBox.Controls.Add(this.txtJSON);
            this.FilePatternGroupBox.Controls.Add(this.lbFileUploadTransform);
            this.FilePatternGroupBox.Controls.Add(this.txtCSV);
            this.FilePatternGroupBox.Controls.Add(this.txtUploadOnlyFileExt);
            this.FilePatternGroupBox.Controls.Add(this.lbJSON);
            this.FilePatternGroupBox.Controls.Add(this.lbCSV);
            this.FilePatternGroupBox.Controls.Add(this.SaveFileTypeCheckBox);
            this.FilePatternGroupBox.Controls.Add(this.lbFileUploadOnly);
            this.FilePatternGroupBox.Location = new System.Drawing.Point(5, 265);
            this.FilePatternGroupBox.Name = "FilePatternGroupBox";
            this.FilePatternGroupBox.Size = new System.Drawing.Size(285, 160);
            this.FilePatternGroupBox.TabIndex = 52;
            this.FilePatternGroupBox.TabStop = false;
            this.FilePatternGroupBox.Text = "파일 확장자 지정 (File Extension)";
            // 
            // lbUploadOnlyFileExt
            // 
            this.lbUploadOnlyFileExt.AutoSize = true;
            this.lbUploadOnlyFileExt.Location = new System.Drawing.Point(10, 55);
            this.lbUploadOnlyFileExt.Name = "lbUploadOnlyFileExt";
            this.lbUploadOnlyFileExt.Size = new System.Drawing.Size(34, 17);
            this.lbUploadOnlyFileExt.TabIndex = 47;
            this.lbUploadOnlyFileExt.Text = "파일";
            // 
            // txtJSON
            // 
            this.txtJSON.Location = new System.Drawing.Point(179, 102);
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.Size = new System.Drawing.Size(96, 25);
            this.txtJSON.TabIndex = 46;
            // 
            // lbFileUploadTransform
            // 
            this.lbFileUploadTransform.AutoSize = true;
            this.lbFileUploadTransform.Location = new System.Drawing.Point(10, 84);
            this.lbFileUploadTransform.Name = "lbFileUploadTransform";
            this.lbFileUploadTransform.Size = new System.Drawing.Size(189, 17);
            this.lbFileUploadTransform.TabIndex = 45;
            this.lbFileUploadTransform.Text = "전송 및 변환 대상 파일 확장자";
            // 
            // txtCSV
            // 
            this.txtCSV.Location = new System.Drawing.Point(43, 102);
            this.txtCSV.Name = "txtCSV";
            this.txtCSV.Size = new System.Drawing.Size(96, 25);
            this.txtCSV.TabIndex = 43;
            // 
            // txtUploadOnlyFileExt
            // 
            this.txtUploadOnlyFileExt.Location = new System.Drawing.Point(43, 50);
            this.txtUploadOnlyFileExt.Name = "txtUploadOnlyFileExt";
            this.txtUploadOnlyFileExt.Size = new System.Drawing.Size(232, 25);
            this.txtUploadOnlyFileExt.TabIndex = 10;
            // 
            // lbJSON
            // 
            this.lbJSON.AutoSize = true;
            this.lbJSON.Location = new System.Drawing.Point(139, 107);
            this.lbJSON.Name = "lbJSON";
            this.lbJSON.Size = new System.Drawing.Size(40, 17);
            this.lbJSON.TabIndex = 41;
            this.lbJSON.Text = "JSON";
            // 
            // lbCSV
            // 
            this.lbCSV.AutoSize = true;
            this.lbCSV.Location = new System.Drawing.Point(10, 107);
            this.lbCSV.Name = "lbCSV";
            this.lbCSV.Size = new System.Drawing.Size(31, 17);
            this.lbCSV.TabIndex = 40;
            this.lbCSV.Text = "CSV";
            // 
            // SaveFileTypeCheckBox
            // 
            this.SaveFileTypeCheckBox.AutoSize = true;
            this.SaveFileTypeCheckBox.Location = new System.Drawing.Point(230, 135);
            this.SaveFileTypeCheckBox.Name = "SaveFileTypeCheckBox";
            this.SaveFileTypeCheckBox.Size = new System.Drawing.Size(53, 21);
            this.SaveFileTypeCheckBox.TabIndex = 38;
            this.SaveFileTypeCheckBox.Text = "저장";
            this.SaveFileTypeCheckBox.UseVisualStyleBackColor = true;
            this.SaveFileTypeCheckBox.CheckedChanged += new System.EventHandler(this.SavefileTypeCheckBox_CheckedChanged);
            // 
            // lbFileUploadOnly
            // 
            this.lbFileUploadOnly.AutoSize = true;
            this.lbFileUploadOnly.Location = new System.Drawing.Point(10, 32);
            this.lbFileUploadOnly.Name = "lbFileUploadOnly";
            this.lbFileUploadOnly.Size = new System.Drawing.Size(140, 17);
            this.lbFileUploadOnly.TabIndex = 13;
            this.lbFileUploadOnly.Text = "전송 대상 파일 확장자";
            this.lbFileUploadOnly.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // CtrlModeGroupBox
            // 
            this.CtrlModeGroupBox.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.CtrlModeGroupBox.Controls.Add(this.labelAutoCtrl);
            this.CtrlModeGroupBox.Controls.Add(this.labelManualCtrl);
            this.CtrlModeGroupBox.Controls.Add(this.btnAutoCtrl);
            this.CtrlModeGroupBox.Controls.Add(this.btnManualCtrl);
            this.CtrlModeGroupBox.Font = new System.Drawing.Font("Malgun Gothic", 9.75F);
            this.CtrlModeGroupBox.Location = new System.Drawing.Point(580, 5);
            this.CtrlModeGroupBox.Name = "CtrlModeGroupBox";
            this.CtrlModeGroupBox.Size = new System.Drawing.Size(130, 260);
            this.CtrlModeGroupBox.TabIndex = 16;
            this.CtrlModeGroupBox.TabStop = false;
            this.CtrlModeGroupBox.Text = "모드";
            // 
            // labelAutoCtrl
            // 
            this.labelAutoCtrl.AutoSize = true;
            this.labelAutoCtrl.Location = new System.Drawing.Point(5, 145);
            this.labelAutoCtrl.Name = "labelAutoCtrl";
            this.labelAutoCtrl.Size = new System.Drawing.Size(96, 17);
            this.labelAutoCtrl.TabIndex = 18;
            this.labelAutoCtrl.Text = "자동 실행 모드";
            // 
            // labelManualCtrl
            // 
            this.labelManualCtrl.AutoSize = true;
            this.labelManualCtrl.Location = new System.Drawing.Point(5, 40);
            this.labelManualCtrl.Name = "labelManualCtrl";
            this.labelManualCtrl.Size = new System.Drawing.Size(65, 17);
            this.labelManualCtrl.TabIndex = 17;
            this.labelManualCtrl.Text = "수정 모드";
            // 
            // btnAutoCtrl
            // 
            this.btnAutoCtrl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnAutoCtrl.Location = new System.Drawing.Point(5, 165);
            this.btnAutoCtrl.Name = "btnAutoCtrl";
            this.btnAutoCtrl.Size = new System.Drawing.Size(120, 60);
            this.btnAutoCtrl.TabIndex = 15;
            this.btnAutoCtrl.Text = "자동 실행";
            this.btnAutoCtrl.UseVisualStyleBackColor = false;
            this.btnAutoCtrl.Click += new System.EventHandler(this.btnAutoCtrl_Click);
            // 
            // btnManualCtrl
            // 
            this.btnManualCtrl.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnManualCtrl.Location = new System.Drawing.Point(5, 60);
            this.btnManualCtrl.Name = "btnManualCtrl";
            this.btnManualCtrl.Size = new System.Drawing.Size(120, 60);
            this.btnManualCtrl.TabIndex = 16;
            this.btnManualCtrl.Text = "수정";
            this.btnManualCtrl.UseVisualStyleBackColor = false;
            this.btnManualCtrl.Click += new System.EventHandler(this.btnManualCtrl_Click);
            // 
            // TargetInfoGroupBox
            // 
            this.TargetInfoGroupBox.Controls.Add(this.saveTargetInfo);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetTableName);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetDatabase);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetCatalog);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetType);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetTableName);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetDatabase);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetCatalog);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetType);
            this.TargetInfoGroupBox.Location = new System.Drawing.Point(5, 425);
            this.TargetInfoGroupBox.Name = "TargetInfoGroupBox";
            this.TargetInfoGroupBox.Size = new System.Drawing.Size(285, 160);
            this.TargetInfoGroupBox.TabIndex = 53;
            this.TargetInfoGroupBox.TabStop = false;
            this.TargetInfoGroupBox.Text = "변환 시 Target 정보 (CSV, JSON)";
            // 
            // saveTargetInfo
            // 
            this.saveTargetInfo.AutoSize = true;
            this.saveTargetInfo.Location = new System.Drawing.Point(230, 135);
            this.saveTargetInfo.Name = "saveTargetInfo";
            this.saveTargetInfo.Size = new System.Drawing.Size(53, 21);
            this.saveTargetInfo.TabIndex = 45;
            this.saveTargetInfo.Text = "저장";
            this.saveTargetInfo.UseVisualStyleBackColor = true;
            // 
            // txtTargetTableName
            // 
            this.txtTargetTableName.Location = new System.Drawing.Point(112, 110);
            this.txtTargetTableName.Name = "txtTargetTableName";
            this.txtTargetTableName.Size = new System.Drawing.Size(163, 25);
            this.txtTargetTableName.TabIndex = 48;
            // 
            // txtTargetDatabase
            // 
            this.txtTargetDatabase.Location = new System.Drawing.Point(112, 80);
            this.txtTargetDatabase.Name = "txtTargetDatabase";
            this.txtTargetDatabase.Size = new System.Drawing.Size(163, 25);
            this.txtTargetDatabase.TabIndex = 47;
            // 
            // txtTargetCatalog
            // 
            this.txtTargetCatalog.Location = new System.Drawing.Point(112, 50);
            this.txtTargetCatalog.Name = "txtTargetCatalog";
            this.txtTargetCatalog.Size = new System.Drawing.Size(163, 25);
            this.txtTargetCatalog.TabIndex = 46;
            // 
            // txtTargetType
            // 
            this.txtTargetType.Location = new System.Drawing.Point(112, 20);
            this.txtTargetType.Name = "txtTargetType";
            this.txtTargetType.Size = new System.Drawing.Size(163, 25);
            this.txtTargetType.TabIndex = 45;
            // 
            // lbTargetTableName
            // 
            this.lbTargetTableName.AutoSize = true;
            this.lbTargetTableName.Location = new System.Drawing.Point(10, 115);
            this.lbTargetTableName.Name = "lbTargetTableName";
            this.lbTargetTableName.Size = new System.Drawing.Size(106, 17);
            this.lbTargetTableName.TabIndex = 3;
            this.lbTargetTableName.Text = "Table (CSV only)";
            // 
            // lbTargetDatabase
            // 
            this.lbTargetDatabase.AutoSize = true;
            this.lbTargetDatabase.Location = new System.Drawing.Point(10, 85);
            this.lbTargetDatabase.Name = "lbTargetDatabase";
            this.lbTargetDatabase.Size = new System.Drawing.Size(63, 17);
            this.lbTargetDatabase.TabIndex = 2;
            this.lbTargetDatabase.Text = "Database";
            // 
            // lbTargetCatalog
            // 
            this.lbTargetCatalog.AutoSize = true;
            this.lbTargetCatalog.Location = new System.Drawing.Point(10, 55);
            this.lbTargetCatalog.Name = "lbTargetCatalog";
            this.lbTargetCatalog.Size = new System.Drawing.Size(53, 17);
            this.lbTargetCatalog.TabIndex = 1;
            this.lbTargetCatalog.Text = "Catalog";
            // 
            // lbTargetType
            // 
            this.lbTargetType.AutoSize = true;
            this.lbTargetType.Location = new System.Drawing.Point(10, 25);
            this.lbTargetType.Name = "lbTargetType";
            this.lbTargetType.Size = new System.Drawing.Size(36, 17);
            this.lbTargetType.TabIndex = 0;
            this.lbTargetType.Text = "Type";
            // 
            // AdditionalOptionGroupBox
            // 
            this.AdditionalOptionGroupBox.Controls.Add(this.txtCsvCustomHeader);
            this.AdditionalOptionGroupBox.Controls.Add(this.ckbxHeader);
            this.AdditionalOptionGroupBox.Controls.Add(this.txJsonSelectedKey);
            this.AdditionalOptionGroupBox.Controls.Add(this.txtCsvDelim);
            this.AdditionalOptionGroupBox.Controls.Add(this.lbJsonSelectedKey);
            this.AdditionalOptionGroupBox.Controls.Add(this.lbCsvDelim);
            this.AdditionalOptionGroupBox.Controls.Add(this.lbCsvCustomHeader);
            this.AdditionalOptionGroupBox.Location = new System.Drawing.Point(295, 265);
            this.AdditionalOptionGroupBox.Name = "AdditionalOptionGroupBox";
            this.AdditionalOptionGroupBox.Size = new System.Drawing.Size(415, 320);
            this.AdditionalOptionGroupBox.TabIndex = 54;
            this.AdditionalOptionGroupBox.TabStop = false;
            this.AdditionalOptionGroupBox.Text = "Detail Options";
            // 
            // txtCsvCustomHeader
            // 
            this.txtCsvCustomHeader.AcceptsReturn = true;
            this.txtCsvCustomHeader.AcceptsTab = true;
            this.txtCsvCustomHeader.Location = new System.Drawing.Point(5, 70);
            this.txtCsvCustomHeader.Multiline = true;
            this.txtCsvCustomHeader.Name = "txtCsvCustomHeader";
            this.txtCsvCustomHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCsvCustomHeader.Size = new System.Drawing.Size(390, 215);
            this.txtCsvCustomHeader.TabIndex = 55;
            // 
            // ckbxHeader
            // 
            this.ckbxHeader.AutoSize = true;
            this.ckbxHeader.Location = new System.Drawing.Point(5, 25);
            this.ckbxHeader.Name = "ckbxHeader";
            this.ckbxHeader.Size = new System.Drawing.Size(106, 21);
            this.ckbxHeader.TabIndex = 54;
            this.ckbxHeader.Text = "Header (CSV)";
            this.ckbxHeader.UseVisualStyleBackColor = true;
            // 
            // txJsonSelectedKey
            // 
            this.txJsonSelectedKey.Location = new System.Drawing.Point(145, 290);
            this.txJsonSelectedKey.Name = "txJsonSelectedKey";
            this.txJsonSelectedKey.Size = new System.Drawing.Size(250, 25);
            this.txJsonSelectedKey.TabIndex = 52;
            // 
            // txtCsvDelim
            // 
            this.txtCsvDelim.Location = new System.Drawing.Point(235, 20);
            this.txtCsvDelim.Name = "txtCsvDelim";
            this.txtCsvDelim.Size = new System.Drawing.Size(160, 25);
            this.txtCsvDelim.TabIndex = 51;
            // 
            // lbJsonSelectedKey
            // 
            this.lbJsonSelectedKey.AutoSize = true;
            this.lbJsonSelectedKey.Location = new System.Drawing.Point(5, 295);
            this.lbJsonSelectedKey.Name = "lbJsonSelectedKey";
            this.lbJsonSelectedKey.Size = new System.Drawing.Size(128, 17);
            this.lbJsonSelectedKey.TabIndex = 49;
            this.lbJsonSelectedKey.Text = "Selected Key (JSON)";
            // 
            // lbCsvDelim
            // 
            this.lbCsvDelim.AutoSize = true;
            this.lbCsvDelim.Location = new System.Drawing.Point(135, 25);
            this.lbCsvDelim.Name = "lbCsvDelim";
            this.lbCsvDelim.Size = new System.Drawing.Size(96, 17);
            this.lbCsvDelim.TabIndex = 48;
            this.lbCsvDelim.Text = "Delimiter (CSV)";
            // 
            // lbCsvCustomHeader
            // 
            this.lbCsvCustomHeader.AutoSize = true;
            this.lbCsvCustomHeader.Location = new System.Drawing.Point(5, 50);
            this.lbCsvCustomHeader.Name = "lbCsvCustomHeader";
            this.lbCsvCustomHeader.Size = new System.Drawing.Size(141, 17);
            this.lbCsvCustomHeader.TabIndex = 47;
            this.lbCsvCustomHeader.Text = "CSV Customer Header";
            // 
            // SparkConfigGroupBox
            // 
            this.SparkConfigGroupBox.Controls.Add(this.btnSparkConfig);
            this.SparkConfigGroupBox.Location = new System.Drawing.Point(5, 585);
            this.SparkConfigGroupBox.Name = "SparkConfigGroupBox";
            this.SparkConfigGroupBox.Size = new System.Drawing.Size(170, 55);
            this.SparkConfigGroupBox.TabIndex = 11;
            this.SparkConfigGroupBox.TabStop = false;
            this.SparkConfigGroupBox.Text = "Spark 설정 (CSV/JSON)";
            // 
            // btnSparkConfig
            // 
            this.btnSparkConfig.Location = new System.Drawing.Point(5, 20);
            this.btnSparkConfig.Name = "btnSparkConfig";
            this.btnSparkConfig.Size = new System.Drawing.Size(160, 30);
            this.btnSparkConfig.TabIndex = 0;
            this.btnSparkConfig.Text = "Spark Configs.";
            this.btnSparkConfig.UseVisualStyleBackColor = true;
            this.btnSparkConfig.Click += new System.EventHandler(this.btnSparkConfig_Click);
            // 
            // toolTip1
            // 
            this.toolTip1.Popup += new System.Windows.Forms.PopupEventHandler(this.toolTip1_Popup);
            // 
            // frmSFTPMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.ClientSize = new System.Drawing.Size(1144, 646);
            this.ControlBox = false;
            this.Controls.Add(this.SparkConfigGroupBox);
            this.Controls.Add(this.btnDisconnect);
            this.Controls.Add(this.AdditionalOptionGroupBox);
            this.Controls.Add(this.LocalDirGroupBox);
            this.Controls.Add(this.TargetInfoGroupBox);
            this.Controls.Add(this.FilePatternGroupBox);
            this.Controls.Add(this.CtrlModeGroupBox);
            this.Controls.Add(this.LogGroupBox);
            this.Controls.Add(this.TopicServerGroupBox);
            this.Controls.Add(this.ScheduleGroupBox);
            this.Controls.Add(this.lbCurrentTime);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ObjectStorageGroupBox);
            this.Font = new System.Drawing.Font("Malgun Gothic", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frmSFTPMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NILE Agent";
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
            this.FilePatternGroupBox.ResumeLayout(false);
            this.FilePatternGroupBox.PerformLayout();
            this.CtrlModeGroupBox.ResumeLayout(false);
            this.CtrlModeGroupBox.PerformLayout();
            this.TargetInfoGroupBox.ResumeLayout(false);
            this.TargetInfoGroupBox.PerformLayout();
            this.AdditionalOptionGroupBox.ResumeLayout(false);
            this.AdditionalOptionGroupBox.PerformLayout();
            this.SparkConfigGroupBox.ResumeLayout(false);
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
        private System.Windows.Forms.Button btnConnect;
        private System.Windows.Forms.TextBox txtLog;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private System.Windows.Forms.Label lblStatus;
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
        private System.Windows.Forms.Button btnDisconnect;
        private System.Windows.Forms.GroupBox LocalDirGroupBox;
        private System.Windows.Forms.Button btnBrowser;
        private System.Windows.Forms.TextBox txtBrowser;
        private System.Windows.Forms.CheckBox SaveDirCheckBox;
        private System.Windows.Forms.GroupBox TopicServerGroupBox;
        private System.Windows.Forms.CheckBox SaveTopicServerCheckBox;
        private System.Windows.Forms.TextBox txtTopicServer;
        private System.Windows.Forms.Label lbTopicServer;
        private System.Windows.Forms.GroupBox FilePatternGroupBox;
        private System.Windows.Forms.CheckBox SaveFileTypeCheckBox;
        private System.Windows.Forms.Label lbFileUploadOnly;
        private System.Windows.Forms.GroupBox CtrlModeGroupBox;
        private System.Windows.Forms.Button btnManualCtrl;
        private System.Windows.Forms.Button btnAutoCtrl;
        private System.Windows.Forms.Label labelLogPath;
        private System.Windows.Forms.TextBox textBoxLogPath;
        private System.Windows.Forms.Label lbRegion;
        private System.Windows.Forms.TextBox txtRegion;
        private System.Windows.Forms.TextBox txtBucket;
        private System.Windows.Forms.Label lbBucket;
        private System.Windows.Forms.TextBox txtCSV;
        private System.Windows.Forms.TextBox txtUploadOnlyFileExt;
        private System.Windows.Forms.Label lbJSON;
        private System.Windows.Forms.Label lbCSV;
        private System.Windows.Forms.GroupBox TargetInfoGroupBox;
        private System.Windows.Forms.Label lbTargetType;
        private System.Windows.Forms.Label lbTargetTableName;
        private System.Windows.Forms.Label lbTargetDatabase;
        private System.Windows.Forms.Label lbTargetCatalog;
        private System.Windows.Forms.Label lbTopic;
        private System.Windows.Forms.TextBox txtTopic;
        private System.Windows.Forms.CheckBox saveTargetInfo;
        private System.Windows.Forms.TextBox txtTargetTableName;
        private System.Windows.Forms.TextBox txtTargetDatabase;
        private System.Windows.Forms.TextBox txtTargetCatalog;
        private System.Windows.Forms.TextBox txtTargetType;
        private System.Windows.Forms.GroupBox AdditionalOptionGroupBox;
        private System.Windows.Forms.TextBox txJsonSelectedKey;
        private System.Windows.Forms.TextBox txtCsvDelim;
        private System.Windows.Forms.Label lbJsonSelectedKey;
        private System.Windows.Forms.Label lbCsvDelim;
        private System.Windows.Forms.Label lbCsvCustomHeader;
        private System.Windows.Forms.TextBox txtCsvCustomHeader;
        private System.Windows.Forms.CheckBox ckbxHeader;
        private System.Windows.Forms.Label labelAutoCtrl;
        private System.Windows.Forms.Label labelManualCtrl;
        private System.Windows.Forms.GroupBox SparkConfigGroupBox;
        private System.Windows.Forms.Button btnSparkConfig;
        private System.Windows.Forms.Label lbUploadOnlyFileExt;
        private System.Windows.Forms.TextBox txtJSON;
        private System.Windows.Forms.Label lbFileUploadTransform;
        private System.Windows.Forms.ToolTip toolTip1;
    }
}

