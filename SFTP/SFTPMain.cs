using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;
using System.IO;
using System.Timers;
using System.Threading;


namespace SFTP
{

    public partial class frmSFTPMain : Form
    {
        //Connecting to the Object Storage
        /*private int m_iPort = 30100;*/
        private int objectStoragePort = 32728;
        private string topicMessageServer = "172.16.57.26:32272";
        
        
        private readonly string masterPasswd = "hsnc123!";      //App master PW
        public bool auto_ctrl_mode = false;                     //자동 접슥 모드

        /*        public bool sftp_connected = false; // Connetion Status */
        public bool objectStorage_connected = false;
        public bool topicMessage_sent = false;

        public bool sync_processing = false;                    //Sync process on-going 
        public int sec_count = 0;                               //Second counter (0~59) for secTimer
        public readonly char[] delims = { '/', ',', '\'', '\\', ' ' };
        public bool press_autoCtrl = false;

        public string SFTP_LogPath =  @"C:\NILE_Agent_logs\";
        public string SFTP_LogFileName = "AGENT_DATE.log";
        public uint log_line_cnt = 0;
        public uint MAX_LOG_LINES = 100;
        public bool force_exit = false;

        //System.Windows.Forms.Timer autoSyncTimer = new System.Windows.Forms.Timer();//for aurto sync process schedule delay of 1minute (One-shot)




        /*TextBox*/
        private string getText(TextBox txtb )
        {
            return txtb.Text;
        }

        private delegate void SafeCallDelegate_Text(TextBox txt, String strContent);
        public void setText(TextBox txtb, string strContent)
        {
            if (txtLog.InvokeRequired)
            {
                var d = new SafeCallDelegate_Text(setText);
                txtb.Invoke(d, new object[] { txtb, strContent });
            }
            else
            {
                txtb.Text = strContent;
            }
        
        }


        /*Label*/
        private string getText(Label lbl)
        {
            return lbl.Text;
        }

        private delegate void SafeCallDelegate_lblText(Label lbl, String strContent);
        public void setText(Label lbl, string strContent)
        {
            if (txtLog.InvokeRequired)
            {
                var d = new SafeCallDelegate_lblText(setText);
                lbl.Invoke(d, new object[] { lbl, strContent });
            }
            else
            {
                lbl.Text = strContent;
            }

        }


        /*ComboBox*/
        public string getText(ComboBox cb)
        {
            return cb.Text;
        }

        private delegate void SafeCallDelegate_cText(ComboBox cb, String strContent);
        public void setText(ComboBox cb, string strContent)
        {
            if (txtLog.InvokeRequired)
            {
                var d = new SafeCallDelegate_cText(setText);
                cb.Invoke(d, new object[] { cb, strContent });
            }
            else
            {
                cb.Text = strContent;
            }
        }


        /*NumericUpDown*/
        public decimal getValue(NumericUpDown nUD)
        {
            return nUD.Value;
        }

        private delegate void SafeCallDelegate_Value(NumericUpDown nUD, decimal val);
        public void setValue(NumericUpDown nUD, decimal val)
        {
            if (nUD.InvokeRequired)
            {
                var d = new SafeCallDelegate_Value(setValue);
                nUD.Invoke(d, new object[] { nUD, val });
            }
            else
            {
                nUD.Value = val;
            }
        }


        /*CheckBox*/
        public bool getValue(CheckBox ChkBx)
        {
            return ChkBx.Checked;
        }

        private delegate void SafeCallDelegate_cValue(CheckBox ChkBx, Boolean chk);
        public void setValue(CheckBox ChkBx, Boolean chk)
        {
            if (ChkBx.InvokeRequired)
            {
                var d = new SafeCallDelegate_cValue(setValue);
                ChkBx.Invoke(d, new object[] { ChkBx, chk });
            }
            else
            {
                ChkBx.Checked = chk;
            }
        }





        // Main Features

        /*private SftpProtocol m_sftpProtocol = null;*/
        private ObjectStorageProtocol objectStorage_Protocol = null;

        private KafkaProtocol topicMessage_Protocol = null;

        public  void StartSecTimer()
        {
            System.Windows.Forms.Timer secTimer = new System.Windows.Forms.Timer(); //runs every 1s
            secTimer.Tick += new EventHandler(PerSecEvent);
            secTimer.Interval = (int)1000;  //1s
            secTimer.Enabled = true;
            secTimer.Start();
        }


        public void PerSecEvent(Object myObject, EventArgs myEventArgs)
        {

            ((System.Windows.Forms.Timer)myObject).Enabled = false;

            DateTime CurrentTime = DateTime.Now;
            int today = CurrentTime.Day;
            setText(lbCurrentTime, CurrentTime.ToString());


            // Press AutoCtrl after 3 seconds of delay when the Application starts
            if (auto_ctrl_mode == false && press_autoCtrl == true && sec_count == 2)
            {
                press_autoCtrl = false;
                this.btnAutoCtrl.PerformClick();    //Launches the auto button on application start
                sec_count = CurrentTime.Second;
            }


            int curr_secs = sec_count + (60*CurrentTime.Minute) + (60*60* CurrentTime.Hour);    //Current Time in seconds (60*60*24 for a day)
            int sync_intrvl_total_secs = (60*Convert.ToInt32(SyncIntervalMinTextBox.Text)) + (60 * 60 * Convert.ToInt32(SyncIntervalHourTextBox.Text));

            if (auto_ctrl_mode && sync_intrvl_total_secs != 0)
            {
                int rem_secs = sync_intrvl_total_secs - curr_secs % sync_intrvl_total_secs ;
                int rem_mins = rem_secs / 60;
                rem_secs = rem_secs % 60;
                labelCountDown.Text = "Count Down: " + rem_mins.ToString() + "분 " + rem_secs.ToString() + "초";

                //Auto Ctrl 모드에서 현제 시간이 (분 단위로) Sync 설정 시간의 Multiple인 경우 1분 후 Sync 실행
                if (curr_secs % sync_intrvl_total_secs == 0)
                {
                    System.Windows.Forms.Timer tmrOnce = new System.Windows.Forms.Timer();
                    tmrOnce.Tick += new EventHandler(TimerEventAutoSync);
                    tmrOnce.Interval = (int)(100); //0.5 sec after the specified time
                    tmrOnce.Start();
                    rem_secs = 0;
                    rem_mins = 0;
                }
            }

            // Logging
            if ((CurrentTime.AddSeconds(1)).Day != today)
            {
                SFTP_LogFileName = "NILE_Agent_" + CurrentTime.Year.ToString("D4") + "_" + CurrentTime.Month.ToString("D2") + "_" + CurrentTime.Day.ToString("D2") + ".log";

                //log_upload_waiting = true;
            }

            if (++sec_count > 59)
            {
                sec_count = 0;
            }

            ((System.Windows.Forms.Timer)myObject).Enabled = true;
        }

        public static class PromptPW
        {

            public static string ShowPWDialog()
            {
                Form prompt = new Form()
                {
                    Width = 400,
                    Height = 150,
                    FormBorderStyle = FormBorderStyle.FixedDialog,
                    Text = "Password",
                    StartPosition = FormStartPosition.CenterScreen
                };
                Label textLabel = new Label() { Left = 50, Top = 20, Text = "Password" };
                TextBox textBox = new TextBox() { Left = 50, Top = 50, Width = 200, PasswordChar = '*' };
                Button confirmation = new Button() { Text = "적용", Left = 300, Width = 50, Top = 50, DialogResult = DialogResult.OK };
                confirmation.Click += (sender, e) => { prompt.Close(); };
                prompt.Controls.Add(textBox);
                prompt.Controls.Add(confirmation);
                prompt.Controls.Add(textLabel);
                prompt.AcceptButton = confirmation;

                return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
            }
        }


        // TODO 
        private void object_storage_defaults()
        { 

            setText(txtHost, Properties.Settings.Default.OBJECTSTORAGE_HOST);
            setText(txtPort, Properties.Settings.Default.OBJECTSTORAGE_PORT);
            setText(txtBucket, Properties.Settings.Default.BUCKET_NAME);
            setText(txtUser, Properties.Settings.Default.OBJECTSTORAGE_USER);
            setText(txtPassword, Properties.Settings.Default.OBJECTSTORAGE_PW);
        }


        private void load_all_default_params()
        {

            object_storage_defaults();

            setText(txtTopicServer, Properties.Settings.Default.BOOTSTRAP_SERVERS);
            setText(txtTopic, Properties.Settings.Default.TOPIC_NAME);
            setText(txtBrowser, Properties.Settings.Default.SYNC_DIR);
            setText(txtUploadOnlyFileExt, Properties.Settings.Default.UPLOAD_ONLY_EXTENSIONS);
            setText(txtCSV, Properties.Settings.Default.CSV_EXTENSIONS);
            setText(txtJSON, Properties.Settings.Default.JSON_EXTENSIONS);
            setText(txtTargetType, Properties.Settings.Default.TARGET_TYPE);
            setText(txtTargetCatalog, Properties.Settings.Default.TARGET_CATALOG);
            setText(txtTargetDatabase, Properties.Settings.Default.TARGET_DATABASE);
            setText(txtTargetTableName, Properties.Settings.Default.TARGET_TABLE);
            setText(SyncIntervalHourTextBox, Properties.Settings.Default.SYNC_INVL_HR);
            setText(SyncIntervalMinTextBox, Properties.Settings.Default.SYNC_INVL_MIN);
            setText(txtCsvDelim, Properties.Settings.Default.CSV_DELIM);
            setText(txtCsvCustomHeader, Properties.Settings.Default.CSV_CUSTOM_HEADER);
            setText(txJsonSelectedKey, Properties.Settings.Default.JSON_SELECTED_KEY);
            //setValue(LogSaveCheckBox, Properties.Settings.Default.LOG_SAVE);
            //SaveObjectStorageCheckBox.Checked = Properties.Settings.Default.LOG_SAVE;
            //SaveTopicServerCheckBox.Checked = Properties.Settings.Default.LOG_SAVE;
            //saveTargetInfo.Checked = Properties.Settings.Default.LOG_SAVE;


            // TODO : log files should be saved in a new folder created namely logs inside the path set by txtBrowser 
            if (SaveObjectStorageCheckBox.Checked)
            {
                textBoxLogPath.Text =  SFTP_LogPath;
            }
            else
            {
                textBoxLogPath.Text = "";
                textBoxLogPath.Clear();
            }



            if (validateLoginParam(promptErr: true))
                setValue(SaveObjectStorageCheckBox, true);
            else
                setValue(SaveObjectStorageCheckBox, false);

            if (validateDirectory(promptErr: true))
                setValue(SaveDirCheckBox, true);
            else
                setValue(SaveDirCheckBox, false);

            if (validateSyncOptionsParam(promptErr: true))
                setValue(SaveScheduleCheckBox, true);
            else
                setValue(SaveScheduleCheckBox, false);

            if (!string.IsNullOrEmpty(this.txtTopicServer.Text) && this.txtTopicServer.Text.IndexOfAny(Path.GetInvalidFileNameChars()) < 0)
                setValue(SaveTopicServerCheckBox, true);
            else
                setValue(SaveTopicServerCheckBox, false);


        }



        public frmSFTPMain()
        {
            InitializeComponent();
            frmSFTPMain.CheckForIllegalCrossThreadCalls = false;    // To avoid any Exception (We will take care of the errors separately)

        }



        // TODO 
        private void frmAgentMain_Load(object sender, EventArgs e)
        {
            appendLog("System Loading...");
            SFTP_LogPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "NILE_Agent_Logs" + Path.DirectorySeparatorChar;
            SFTP_LogFileName = "NILE_Agent_" + DateTime.Now.Year.ToString("D4") + "_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Day.ToString("D2") + ".log";
            load_all_default_params();
            appendLog("System Loading 완료");

            if (String.IsNullOrEmpty(this.txtRegion.Text))
            {
                this.objectStorage_Protocol = new ObjectStorageProtocol(this.txtUser.Text, this.txtPassword.Text);
            }
            else
            {
                this.objectStorage_Protocol = new ObjectStorageProtocol(this.txtUser.Text, this.txtPassword.Text, this.txtRegion.Text);
            }
                    
            //Create tool-tip text for Controls
            createToolTipText(this.txtHost, "Address");
            createToolTipText(this.txtPort, "Port (0 ~ 65535)");
            createToolTipText(this.txtUser, "ID");
            createToolTipText(this.txtPassword, "PW");

            createToolTipText(this.txtBrowser, "Directory to Syncronize");

            createToolTipText(this.SyncIntervalHourTextBox, "Sync Interval Hour (Local Time)");
            createToolTipText(this.SyncIntervalMinTextBox, "Sync Interval Minutes (Local Time)");


            createToolTipText(this.SaveDirCheckBox, "Save Directory");
            createToolTipText(this.SaveObjectStorageCheckBox, "Save Info");
            createToolTipText(this.SaveScheduleCheckBox, "Save All Options");

            //en_dis_option_selsecions();
            StartSecTimer();

            appendLog("StartSecTimer was successful");


            press_autoCtrl = true;//Press the Auto button few secs after App Start 

            this.btnAutoCtrl.PerformClick();//Press the Auto button on App Start

        }

        private void createToolTipText(Control c, String s)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(c, s);
        }

        private void initManualControl()
        {
            auto_ctrl_mode = false;

            //Initialize Controls
            this.ObjectStorageGroupBox.Enabled = true;
            this.TopicServerGroupBox.Enabled = true;
            this.LocalDirGroupBox.Enabled = true;
            this.FilePatternGroupBox.Enabled = true;
            this.AdditionalOptionGroupBox.Enabled = true;
            this.TargetInfoGroupBox.Enabled = true;
            this.SparkConfigGroupBox.Enabled = true;
            this.ScheduleGroupBox.Enabled = true;
   

        }

        private void storage_connect()
        {
            if (validateLoginParam())
            {

                bool blConnectResult = this.objectStorage_Protocol.ConnectToObjectStorage(this.txtHost.Text, this.objectStoragePort, this.txtUser.Text, this.txtPassword.Text, 120);
                if (!blConnectResult)
                {
                    appendLog("접속 " + this.txtHost.Text + " ERROR");
                    appendLog(this.objectStorage_Protocol.getErrorDes());

                    objectStorage_connected = false;
                }
                else
                {
                    objectStorage_connected = true;
                    appendLog("접속 " + this.txtHost.Text + " 성공");
                }
            }
        }

        private void object_storage_disconnect()
        {
            appendLog("접속 종료 " + this.txtHost.Text + ": Offline \r\n");
            this.objectStorage_Protocol.DisconnectFromObjectStorage();
            objectStorage_connected = false;
        }


        // This is the method to run when the timer is raised
        private void TimerEventAutoSync(Object myObject, EventArgs myEventArgs)
        {
            ((System.Windows.Forms.Timer)myObject).Stop();
            ((System.Windows.Forms.Timer)myObject).Dispose();

            try
            {
                if (!sync_processing)
                {
                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync();
                    }

                }

            }
            catch (Exception exp)
            {
                //Return Error - Notifies the user
                object_storage_disconnect();
                appendLog(this.objectStorage_Protocol.getErrorDes() + " Ex. :" + exp.ToString() + "\r\n");
                initAutoControl();
            }

        }

        // Called when the AutoCtrl button is clicked  - this should include objectStorageProtocol
        private bool initAutoControl(bool promptErr = false)
        {
            Boolean init_sucess = false;
            if (validateLoginParam(promptErr) &&
                validateDirectory(promptErr) &&
                validateSyncOptionsParam(promptErr))
            {
                this.SaveObjectStorageCheckBox.Checked = true;
                this.SaveTopicServerCheckBox.Checked = true;
                this.SaveDirCheckBox.Checked = true;
                this.SaveFileTypeCheckBox.Checked = true;
                this.SaveScheduleCheckBox.Checked = true;

                Properties.Settings.Default.Save();

                auto_ctrl_mode = false;


                appendLog("자동 접속 모드 전환");

                this.ObjectStorageGroupBox.Enabled = false;
                this.TopicServerGroupBox.Enabled = false;
                this.LocalDirGroupBox.Enabled = false;
                this.FilePatternGroupBox.Enabled = false;
                this.ScheduleGroupBox.Enabled = false;
                this.AdditionalOptionGroupBox.Enabled = false;
                this.TargetInfoGroupBox.Enabled = false; 
                this.SparkConfigGroupBox.Enabled = false;
                this.CtrlModeGroupBox.Enabled = true;

                //Firt Run (question: why do we need if statement here?)
                if (true)
                {

                    if (!backgroundWorker.IsBusy)
                    {
                        backgroundWorker.RunWorkerAsync();
                    }
                    sec_count = DateTime.Now.Second;
                    auto_ctrl_mode = true;
                    init_sucess = true;
                }

            }
            return init_sucess;
        }


        private void btnConnect_Click(object sender, EventArgs e)
        {

            //Validate the parameter before connecting to the server
            if (validateLoginParam(promptErr: true))
            {

                if (SaveObjectStorageCheckBox.Checked)
                {

                    Properties.Settings.Default.OBJECTSTORAGE_HOST = this.txtHost.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_PORT = this.txtPort.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_USER = this.txtUser.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_PW = this.txtPassword.Text;
                    Properties.Settings.Default.BUCKET_NAME = this.txtBucket.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_REGION = this.txtRegion.Text;
                    Properties.Settings.Default.Save();
                }

                //Post validate parameter
                appendLog("Object Storage 접속 " + this.txtHost.Text);

                //Connect to the Object Storage
                bool blConnectResult = this.objectStorage_Protocol.ConnectToObjectStorage(this.txtHost.Text, this.objectStoragePort, this.txtUser.Text, this.txtPassword.Text, 120);
                appendLog("why?");
                if (!blConnectResult)
                {
                    MessageBox.Show(this.objectStorage_Protocol.getErrorDes(),
                    "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    appendLog("접속 " + this.txtHost.Text + " ERROR");
                    objectStorage_connected = false;

                }
                else
                {
                    //Connection == True, Initialize
                    this.ObjectStorageGroupBox.Enabled = false;
                    this.btnDisconnect.Enabled = true;
                    objectStorage_connected = true;
                    appendLog("Object Storage Connected successfully");
                }
            }
            else
            {
                MessageBox.Show("필수 정보를 모두 입력해주세요.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private delegate void SafeCallDelegate_appendLog(String strContent, bool newline = true, bool Inc_time = true);


        public void appendLog(String strContent, bool newline = true, bool Inc_time = true) //Thread Safe
        {
            DateTime localDate = DateTime.Now;

            if (true)
            {
                if (txtLog.InvokeRequired)
                {
                    var d = new SafeCallDelegate_appendLog(appendLog);
                    txtLog.Invoke(d, new object[] { strContent, newline, Inc_time });
                }
                else
                {
                    if (newline == true && Inc_time == true)
                        this.txtLog.AppendText("[" + localDate.ToString(System.Globalization.CultureInfo.CurrentCulture) + "] " + strContent + "\r\n");
                    else if (newline == false && Inc_time == true)
                        this.txtLog.AppendText("[" + localDate.ToString(System.Globalization.CultureInfo.CurrentCulture) + "] " + strContent);
                    else if (newline == true && Inc_time == false)
                        this.txtLog.AppendText(strContent + "\r\n");
                    else
                        this.txtLog.AppendText(strContent);

                    if (newline)
                    {
                        string exp_st = null;
                        if (++log_line_cnt > MAX_LOG_LINES)
                        {
                            log_line_cnt = 0;

                            if (this.LogSaveCheckBox.Checked == true)
                            {
                                try
                                {
                                    if (!Directory.Exists(SFTP_LogPath))
                                    {
                                        Directory.CreateDirectory(SFTP_LogPath);
                                    }
                                    File.AppendAllText(SFTP_LogPath + SFTP_LogFileName, txtLog.Text.ToString());
                                }
                                catch (Exception exp)
                                {
                                    exp_st = exp.ToString();
                                }
                            }

                            this.txtLog.Clear();
                            if (exp_st != null)
                            {
                                this.txtLog.AppendText("\r\n" + exp_st + "\r\n");
                                log_line_cnt++;
                            }
                        }
                    }
                }
            }
        }


        private Boolean validateLoginParam(bool promptErr = false)
        {
            bool blResult = true;

            if (this.txtHost.Text.Trim().Equals("")
                || this.txtPort.Text.Trim().Equals("")
                || this.txtBucket.Text.Trim().Equals("")
                || this.txtUser.Text.Trim().Equals("")
                || this.txtPassword.Text.Trim().Equals("")
                || this.txtTopicServer.Text.Trim().Equals("")
                || this.txtTopic.Text.Trim().Equals(""))
            {
                if (promptErr)
                {
                    //Show Warning
                    MessageBox.Show("필수 정보를 모두 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            else
            {
                try
                {
                    //Validate Port
                    this.objectStoragePort = Convert.ToInt32(this.txtPort.Text);
                    if (this.objectStoragePort < 1 && this.objectStoragePort > 65535)
                    {

                        if (promptErr)
                        {
                            //Show Warning
                            MessageBox.Show("0 ~ 65535을 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        blResult = false;
                    }
                }
                catch (Exception exp)
                {
                    blResult = false;
                    if (promptErr)
                    {
                        //Show Warning
                        MessageBox.Show("Integer 값을 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    appendLog("EXCEPTION ERROR: " + this.objectStorage_Protocol.getErrorDes() + " exp :" + exp.ToString(), newline: true);

                }
            }
            return blResult;
        }


        private Boolean validateSyncOptionsParam(bool promptErr = false)
        {
            bool blResult = true;


            if (this.SyncIntervalHourTextBox.Text.Trim().Equals("") || this.SyncIntervalMinTextBox.Text.Trim().Equals(""))
            {
                if (promptErr)
                {
                    //show warning box
                    MessageBox.Show("필수 정보를 모두 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            else
            {
                try
                {
                    int sync_hr = 0;
                    int sync_min = 30;

                    //Validate port
                    sync_hr = Convert.ToInt32(this.SyncIntervalHourTextBox.Text);
                    sync_min = Convert.ToInt32(this.SyncIntervalMinTextBox.Text);

                    if (sync_hr < 0 || sync_hr > 24)
                    {
                        if (promptErr)
                        {
                            MessageBox.Show("0 ~ 24을 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        blResult = false;
                        return blResult;
                    }

                    if (sync_min < 0 || sync_min > 59)
                    {
                        if (promptErr)
                        {
                            MessageBox.Show("0 ~ 59 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        blResult = false;
                        return blResult;

                    }

                    if (sync_hr == 24)
                    {
                        this.SyncIntervalMinTextBox.Text = "0";
                        sync_min = 0;
                    }

                }
                catch (Exception exp)
                {
                    if (promptErr)
                    {
                        MessageBox.Show("Integer 값을 입력해주세요. " + exp.ToString(), "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    blResult = false;
                    return blResult;

                }

            }
            return blResult;
        }

        private Boolean validateDirectory(bool promptErr = false)
        {
            bool blResult = true;

            if (this.txtBrowser.Text.Trim().Equals(""))
            {

                if (promptErr)
                {
                    //show warning box
                    MessageBox.Show("Directory 정보를 선택해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            else
            {
                try
                {
                    //Validate Directory 
                    if (!Directory.Exists(this.txtBrowser.Text))
                    {
                        if (promptErr)
                        {
                            MessageBox.Show("Directory Not Found!", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                        blResult = false;

                    }

                }
                catch (Exception exp)
                {
                    blResult = false;
                    if (promptErr)
                    {
                        MessageBox.Show("Directory Not Found! " + exp.ToString(), "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }

                }
            }
            return blResult;
        }

        private void frmAgentMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            //Save the Log File before exit
            appendLog("App. 강제 종료 !\r\n");

            SFTP_LogFileName = "NILE_Agent_" + DateTime.Now.Year.ToString("D4") + "_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Day.ToString("D2") + ".log";

            try
            {
                if (!Directory.Exists(SFTP_LogPath))
                {
                    Directory.CreateDirectory(SFTP_LogPath);
                }
                File.AppendAllText(SFTP_LogPath + SFTP_LogFileName, txtLog.Text.ToString());
            }
            catch (Exception exp)
            {
                File.AppendAllText("NILE_Agent_ERR.txt", exp.ToString());
            }



            //Before closing you should close the SFTP session to let free of any session running on the SFTP Server
            this.objectStorage_Protocol.DisconnectFromObjectStorage();

            //Release all resources
            this.Dispose(true);

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {

            //This button lets you choose file to upload, or to set Directory

            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();//

            DialogResult result = openFolderDialog.ShowDialog();//
            if (result == DialogResult.OK)
            {
                //this.txtBrowser.Text = 
                setText(this.txtBrowser, openFolderDialog.SelectedPath);
            }
            else
            {
                MessageBox.Show("경로 지정이 필요합니다.",
                    "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }




        private void backgroundWorker_SyncFiles(object sender, DoWorkEventArgs e)
        {

            if ((string)e.Argument != "upload_only")
            {
                //Connect to the SFTP Server
                storage_connect();
            }

            if (objectStorage_connected)
            {
                if (validateDirectory())
                {
                    sync_processing = true;
                    /////////////////////////REOPEN THE FOLLOWING
                    //SyncDirectoryRecurr();

                    string directoryPath = this.txtBrowser.Text;
                    string[] files = Directory.GetFiles(directoryPath);

                    foreach (string file in files)
                    {
                        //bool uploadSuccess = objectStorage_Protocol.UploadFileToObjectStorage(directoryPath, this.txtBucket.Text, file);
                    
                        string fileName = Path.GetFileName(directoryPath); // Extracts the filename from the full path
                        string objectName = fileName; // Or any custom logic to define object name in MinIO
                        bool uploadSuccess = objectStorage_Protocol.UploadFileToObjectStorage(directoryPath, this.txtBucket.Text, objectName);
                        if (uploadSuccess)
                        {
                            appendLog($"Uploaded {fileName}");
                        }
                        else
                        {
                            appendLog($"Failed to upload {fileName}: {objectStorage_Protocol.getErrorDes()}");
                        }

                        if (uploadSuccess)
                        {
                            // Prepare data for Kafka
                            SparkConfigPopUp popUp = new SparkConfigPopUp();

                            var data = new KafkaData
                            {
                                SparkConfigAppName = "FILE_CSV_ETL",
                                SparkConfigSetMaster = "local[*]",
                                objectStoragePath = "s3a://file-lake-consumer",
                                sourceType = "csv",
                                fileName = "1.png",
                                fileExtension = ".png",
                                csvHeader = true,
                                csvCustomHeader = null,
                                csvDelimiter = ",",
                                jsonParseSelectedKey = "",
                                targetType = "iceberg",
                                targetCatalog = "iceberg_catalog",
                                targetDatabase = "file_to_lake",
                                targetTable = "test_ingestion_agent_1",
                                startDateTime = "2023-12-20T15:16:52.804",
                                //SparkConfigAppName = popUp.AppName,
                                //SparkConfigSetMaster = popUp.SetMaster,
                                //objectStoragePath = "s3a://" + this.txtBucket.Text,
                                //sourceType = "",
                                //fileName = "",
                                //fileExtension = "",
                                //csvHeader = "",
                                //csvCustomHeader = "",
                                //csvDelimiter = "",
                                //jsonParseSelectedKey = "",
                                //targetType = "",
                                //targetCatalog = "",
                                //targetDatabase = "",
                                //targetTable = "",
                                //startDateTime = "",
                                SparkConfigs = new List<SparkConfigItem>
                                {
                                    new SparkConfigItem { Key = "spark.sql.extensions", Value = "org.apache.iceberg.spark.extensions.IcebergSparkSessionExtensions" },
                                    new SparkConfigItem { Key = "spark.sql.catalog.spark_catalog", Value = "org.apache.iceberg.spark.SparkSessionCatalog" },
                                    new SparkConfigItem { Key = "spark.sql.catalogImplementation", Value = "hive" },
                                    new SparkConfigItem { Key = "spark.sql.catalog.spark_catalog.type", Value = "hive" },
                                    new SparkConfigItem { Key = "spark.sql.catalog.iceberg_catalog", Value = "org.apache.iceberg.spark.SparkCatalog" },
                                    new SparkConfigItem { Key = "spark.sql.catalog.iceberg_catalog.type", Value = "hive" },
                                    new SparkConfigItem { Key = "spark.sql.catalog.iceberg_catalog.warehouse", Value = "s3a://iceberg/spark/" },
                                    new SparkConfigItem { Key = "spark.sql.catalog.iceberg_catalog.s3.endpoint", Value = "http://172.16.57.21:32728" },
                                    new SparkConfigItem { Key = "spark.sql.catalogImplementation", Value = "in-memory" },
                                    new SparkConfigItem { Key = "spark.executor.heartbeatInterval", Value = "300000" },
                                    new SparkConfigItem { Key = "spark.network.timeout", Value = "400000" },
                                    new SparkConfigItem { Key = "hive.metastore.uris", Value = "thrift://172.16.57.21:31160" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.access.key", Value = "nileadmin" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.secret.key", Value = "nile20211201!" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.impl", Value = "org.apache.hadoop.fs.s3a.S3AFileSystem" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.endpoint", Value = "http://172.16.57.21:32728" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.connection.ssl.enabled", Value = "false" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.path.style.access", Value = "true" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.attempts.maximum", Value = "1" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.connection.establish.timeout", Value = "5000" },
                                    new SparkConfigItem { Key = "spark.hadoop.fs.s3a.connection.timeout", Value = "10000" },
                                    new SparkConfigItem { Key = "spark.sql.iceberg.format-version", Value = "2" }
                                }
                            };

                            var key = "spark_task";

                            // Send message to Kafka
                            topicMessage_Protocol.UploadMessageToKafkaAsync(this.txtTopic.Text, key, data).GetAwaiter().GetResult();
                        }
                    }

                    sync_processing = false;
                }
                else
                {
                    appendLog("Invalid Directory!", newline: true);
                    //  MessageBox.Show("Invalid Directory!!", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                appendLog("Unable to connect . . .  ", newline: true);
            }


            if ((string)e.Argument != "upload_only")
            {
                //Disconnect from the SFTP Server
                object_storage_disconnect();
            }
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            lblStatus.Text = $"진행 중 {e.ProgressPercentage} %";
            progressBar.Value = e.ProgressPercentage;
            progressBar.Update();

        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            lblStatus.Text = $"Upload 완료 {e.Result} %";
            //appendLog(e.Result.ToString(), newline: true);
            //appendLog(e.ToString(), newline: true);
            //appendLog(".. ", newline: true);

            //lblStatus.Text = "Upload 완료";
        }


        private void txtBrowser_TextChanged(object sender, EventArgs e)
        {
            SaveDirCheckBox.Checked = false;
        }

        private void txtHost_TextChanged(object sender, EventArgs e)
        {
            SaveObjectStorageCheckBox.Checked = false;
        }

        private void SyncIntervalMinTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveScheduleCheckBox.Checked = false;
        }

        private void txtPassword_TextChanged(object sender, EventArgs e)
        {
            SaveObjectStorageCheckBox.Checked = false;
        }

        private void btnDisconnect_Click(object sender, EventArgs e)
        {
            //Initialize Controls
            if (objectStorage_connected)
            {
                this.ObjectStorageGroupBox.Enabled = true;
                this.TopicServerGroupBox.Enabled = true;
                this.btnDisconnect.Enabled = false;
                appendLog("접속 종료 " + this.txtHost.Text);
                this.objectStorage_Protocol.DisconnectFromObjectStorage();
                appendLog("연결 끊김 ");
                objectStorage_connected = false;

                //initManualControl();
            }
        }

        public void PrintDirectoryTree(string directory, int lvl, string lvlSeperator = "|-")
        {

            foreach (string f in Directory.GetFiles(directory))
            {
                appendLog(lvlSeperator + Path.GetFileName(f));
            }

            foreach (string d in Directory.GetDirectories(directory))
            {
                appendLog(lvlSeperator + "-" + Path.GetFileName(d));

                if (lvl > 0)
                {
                    PrintDirectoryTree(d, lvl - 1, lvlSeperator + "-");
                }
            }
        }


        private void btnManualCtrl_Click(object sender, EventArgs e)
        {
            if (auto_ctrl_mode)
            {
                string testPW = PromptPW.ShowPWDialog();
                if (testPW != masterPasswd)
                {
                    MessageBox.Show("Password가 일치하지 않습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {

                    btnAutoCtrl.Enabled = true;
                    btnManualCtrl.Enabled = false;
                    //buttonCheckOptions.Enabled = false;

                    initManualControl();
                }
            }
        }

        private void btnAutoCtrl_Click(object sender, EventArgs e)
        {

            if (initAutoControl(promptErr: true))
            {
                btnAutoCtrl.Enabled = false;
                btnManualCtrl.Enabled = true;
                //  buttonCheckOptions.Enabled = true;
            }
        }

        private void SyncIntervalHourTextBox_TextChanged(object sender, EventArgs e)
        {
            SaveScheduleCheckBox.Checked = false;
        }

        private void SaveLogInCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveObjectStorageCheckBox.Checked)
            {
                if (validateLoginParam(promptErr: true))
                {
                    Properties.Settings.Default.OBJECTSTORAGE_HOST = this.txtHost.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_PORT = this.txtPort.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_USER = this.txtUser.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_PW = this.txtPassword.Text;
                    Properties.Settings.Default.BUCKET_NAME = this.txtBucket.Text;
                    Properties.Settings.Default.OBJECTSTORAGE_REGION = this.txtRegion.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    SaveObjectStorageCheckBox.Checked = false;
                }
            }

            if (SaveTopicServerCheckBox.Checked)
            {
                if (validateLoginParam(promptErr: true))
                {
                    Properties.Settings.Default.BOOTSTRAP_SERVERS = this.txtTopicServer.Text;
                    Properties.Settings.Default.TOPIC_NAME = this.txtTopic.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    SaveTopicServerCheckBox.Checked = false;
                }
            }
        }

        private void SaveOptCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveScheduleCheckBox.Checked)
            {
                if (validateSyncOptionsParam(promptErr: true))
                {
                    Properties.Settings.Default.SYNC_INVL_HR = this.SyncIntervalHourTextBox.Text;
                    Properties.Settings.Default.SYNC_INVL_MIN = this.SyncIntervalMinTextBox.Text;
                    // Properties.Settings.Default.FILE_PRE_1 = this.FirstCharTxtBox.Text;
                    //  Properties.Settings.Default.FILE_TYPE = this.FileTypeCombobox.Text;

                    //   Properties.Settings.Default.FILE_PRE_1 = this.FirstCharTxtBox.Text;
                    //   Properties.Settings.Default.FILE_PRE_2 = this.SecondCharTxtBox.Text;
                    //   Properties.Settings.Default.FILE_PRE_3 = this.ThirdCharTxtBox.Text;
                    //   Properties.Settings.Default.FILE_PRE_4 = this.FourthCharTxtBox.Text;

                    Properties.Settings.Default.SYNC_INVL_HR = this.SyncIntervalHourTextBox.Text;
                    Properties.Settings.Default.SYNC_INVL_MIN = this.SyncIntervalMinTextBox.Text;
                    //   Properties.Settings.Default.SYNC_DELAY = (uint)this.SyncDelayUpDown.Value;
                    Properties.Settings.Default.SYNC_DIR = this.txtBrowser.Text;

                    //Properties.Settings.Default.FILE_PRE_NUM = (uint)this.numPrefix.Value;

                    //    Properties.Settings.Default.DATE_TIME_FMT = this.comboBoxFormat.Text;
                    //   Properties.Settings.Default.FILE_TYPE = this.FileTypeCombobox.Text;

                    // Properties.Settings.Default.UTC_TO_LCL = this.UTCtoLocalCheckBox.Checked;
                    // Properties.Settings.Default.ZIP_7Z = this.Zip7CheckBox.Checked;

                    Properties.Settings.Default.LOG_SAVE = this.LogSaveCheckBox.Checked;

                    Properties.Settings.Default.Save();
                }
                else
                {
                    SaveScheduleCheckBox.Checked = false;
                }
            }
        }

        private void SaveDirCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveDirCheckBox.Checked)
            {
                if (validateDirectory(promptErr: true))
                {
                    Properties.Settings.Default.SYNC_DIR = this.txtBrowser.Text;
                    Properties.Settings.Default.Save();
                }
                else
                {
                    SaveDirCheckBox.Checked = false;
                }
            }
        }

        private void txtPort_TextChanged(object sender, EventArgs e)
        {
            SaveObjectStorageCheckBox.Checked = false;
        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {
            SaveObjectStorageCheckBox.Checked = false;
        }


        private void LogSaveCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            this.textBoxLogPath.Text = SFTP_LogPath;
            Properties.Settings.Default.LOG_SAVE = this.LogSaveCheckBox.Checked;
            Properties.Settings.Default.Save();
        }

        void SyncDirectoryResultInterrupt(IAsyncResult result)
        {
            //appendLog(result.AsyncState.ToString());
            // string formatString = (string)result.AsyncState;
            //appendLog("cb: " + formatString);
            if (result.IsCompleted)
            {
                // IEnumerable<System.IO.FileInfo> SyncFileInfo = null;

                // SyncFileInfo = this.m_sftpProtocol.EndSynchronizeDirectory(result);
                // appendLog("Done");
                //  for (int j = 0; j < SyncFileInfo.Count(); j++)
                {
                    //      appendLog(SyncFileInfo.ElementAt(j).ToString());
                }

            }
        }


        /*
        void SyncDirectoryRecurr()
        {
            string ParentDirFullPath = this.txtBrowser.Text;
            string ServerParentFolder = this.txtTopicServer.Text;

            long num_files = 0;
            long num_Directories = 0;
            IEnumerable<System.IO.FileInfo> SyncFileInfo = null;
            List<string> DirListFullPath = null;
            char clientDirectorySeparatorChar = Path.DirectorySeparatorChar;    // windows: \\
            char serverDirectorySeparatorChar = Path.AltDirectorySeparatorChar; // linux: /



            DirListFullPath = Directory.GetDirectories(ParentDirFullPath, "*", SearchOption.AllDirectories).ToList();
            DirListFullPath.Insert(0, Path.GetFullPath(ParentDirFullPath) + Path.DirectorySeparatorChar); //

            for (int i = 0; i < DirListFullPath.Count(); i++)
            {
                num_Directories++;
                string[] fileEntries = Directory.GetFiles(DirListFullPath.ElementAt(i));
                for (int j = 0; j < fileEntries.Count(); j++)
                {
                    num_files++;
                }
            }

            appendLog(num_Directories.ToString() + "  Folder(s) 존재... ");
            appendLog(num_files.ToString() + "  File(s) 존재... ");

            if (objectStorage_connected)
            {
                long currDirNum = 0;
                foreach (string eFullPath in DirListFullPath)
                {
                    IAsyncResult ar = null;
                    AsyncCallback asyncCallback = new AsyncCallback(SyncDirectoryResultInterrupt);
                    string WinClientPath = eFullPath.ToString().Replace(ParentDirFullPath + clientDirectorySeparatorChar, "");
                    string ServerPath = ServerParentFolder + serverDirectorySeparatorChar + WinClientPath.Replace(clientDirectorySeparatorChar, serverDirectorySeparatorChar);
                    // object state = null;
                    //List<string> FileList = Directory.GetFiles(eFullPath, searchPattern).ToList();

                    IEnumerable<Renci.SshNet.Sftp.SftpFile> lsServerDir = this.m_sftpProtocol.listFile(ServerPath);
                    if (lsServerDir == null)
                    {
                        bool tst = this.m_sftpProtocol.creatingDirectory(ServerPath);
                        if (tst == false)
                        {
                            appendLog(this.m_sftpProtocol.getErrorDes());
                        }
                    }

                    //                    ar = this.m_sftpProtocol.BeginSyncDirectory(eFullPath, ServerPath, searchPattern, asyncCallback, null);
                    //                    currDirNum++;
                    //                    double percentage = (double)currDirNum / (double)(DirListFullPath.Count()) * 100;
                    //if (backgroundWorker.IsBusy)
                    //                    {
                    //                        backgroundWorker.ReportProgress((int)percentage);
                    //                    }

                    if (force_exit)
                    {
                        //ar.AsyncWaitHandle.close();
                        force_exit = false;
                        return;
                    }
                    else
                    {
                        ar.AsyncWaitHandle.WaitOne(1000);
                        SyncFileInfo = this.m_sftpProtocol.EndSynchronizeDirectory(ar);
                        ar.AsyncWaitHandle.Close();
                        // SyncFileInfo = this.m_sftpProtocol.SyncDirectory(DirListFullPath.ElementAt(i), ServerPath, "*");

                        if (SyncFileInfo != null)
                        {
                            List<FileInfo> FileList = SyncFileInfo.ToList();
                            foreach (FileInfo finfo in FileList)
                            {
                                appendLog(ServerPath + finfo.ToString());
                            }

                        }
                    }
                }
            }
        }
        */
        



        private void SavefileTypeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(SaveFileTypeCheckBox.Checked)
            {
                Properties.Settings.Default.Save();
            }
        }

        private void FilePatternCombobox_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveFileTypeCheckBox.Checked = false;
        }

        private void comboBoxServerOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTopicServerCheckBox.Checked = false;
        }

        private void txtServerFolder_TextChanged(object sender, EventArgs e)
        {
            SaveTopicServerCheckBox.Checked = false;
        }

        private void buttonForceClose_Click(object sender, EventArgs e)
        {
            if (sync_processing)
            {
                force_exit = true;
                appendLog("작업(파일 업로드 및 토픽 생성) 강제 종료 !!!");
            }
            //Application.Exit();
        }

        private void btnSparkConfig_Click(object sender, EventArgs e)
        {
            SparkConfigPopUp  sparkConfigPopUp= new SparkConfigPopUp();

            DialogResult result = sparkConfigPopUp.ShowDialog();
        }

        private void toolTip1_Popup(object sender, PopupEventArgs e)
        {

        }
    }

}
