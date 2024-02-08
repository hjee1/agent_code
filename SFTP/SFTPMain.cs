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
using Newtonsoft.Json;
using Amazon.S3;
using System.Threading.Tasks;

namespace SFTP
{

    public partial class frmSFTPMain : Form
    {
        private int objectStoragePort = 32728;
        private readonly string masterPasswd = "hsnc123!";
        public bool auto_ctrl_mode = false;
        public bool objectStorage_connected = false;

        public bool sync_processing = false;
        public int sec_count = 0;
        public bool press_autoCtrl = false;
        public string SFTP_LogPath =  @"C:\NILE_Agent_logs\";
        public string SFTP_LogFileName = "AGENT_DATE.log";
        public uint log_line_cnt = 0;
        public uint MAX_LOG_LINES = 100;

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
        private ObjectStorageProtocol objectStorage_Protocol = null;

        private KafkaProtocol topicMessage_Protocol = null;

        private void InitializeKafkaProtocol()
        {
            topicMessage_Protocol = new KafkaProtocol(this.txtTopicServer.Text);
        }

        public  void StartSecTimer()
        {
            this.textBoxLogPath.Text = SFTP_LogPath;
            System.Windows.Forms.Timer secTimer = new System.Windows.Forms.Timer();
            secTimer.Tick += new EventHandler(PerSecEvent);
            secTimer.Interval = (int)1000;
            secTimer.Enabled = true;
            secTimer.Start();
        }

        public void PerSecEvent(Object myObject, EventArgs myEventArgs)
        {

            ((System.Windows.Forms.Timer)myObject).Enabled = false;

            DateTime CurrentTime = DateTime.Now;
            int today = CurrentTime.Day;
            setText(lbCurrentTime, CurrentTime.ToString());

            if (auto_ctrl_mode == false && press_autoCtrl == true && sec_count == 2)
            {
                press_autoCtrl = false;
                this.btnAutoCtrl.PerformClick();
                sec_count = CurrentTime.Second;
            }

            int curr_secs = sec_count + (60*CurrentTime.Minute) + (60*60* CurrentTime.Hour);
            int sync_intrvl_total_secs = (60*Convert.ToInt32(SyncIntervalMinTextBox.Text)) + (60 * 60 * Convert.ToInt32(SyncIntervalHourTextBox.Text));

            if (auto_ctrl_mode && sync_intrvl_total_secs != 0)
            {
                int rem_secs = sync_intrvl_total_secs - curr_secs % sync_intrvl_total_secs ;
                int rem_mins = rem_secs / 60;
                rem_secs = rem_secs % 60;
                labelCountDown.Text = "Count Down: " + rem_mins.ToString() + "분 " + rem_secs.ToString() + "초";

                if (curr_secs % sync_intrvl_total_secs == 0)
                {
                    System.Windows.Forms.Timer tmrOnce = new System.Windows.Forms.Timer();
                    tmrOnce.Tick += new EventHandler(TimerEventAutoSync);
                    tmrOnce.Interval = (int)(100);
                    tmrOnce.Start();
                    rem_secs = 0;
                    rem_mins = 0;
                }
            }

            if ((CurrentTime.AddSeconds(1)).Day != today)
            {
                SFTP_LogFileName = "NILE_Agent_" + CurrentTime.Year.ToString("D4") + "_" + CurrentTime.Month.ToString("D2") + "_" + CurrentTime.Day.ToString("D2") + ".log";
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
            
            setText(SyncIntervalHourTextBox, Properties.Settings.Default.SYNC_INVL_HR);
            setText(SyncIntervalMinTextBox, Properties.Settings.Default.SYNC_INVL_MIN);

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
            frmSFTPMain.CheckForIllegalCrossThreadCalls = false;
            topicMessage_Protocol = new KafkaProtocol(this.txtTopicServer.Text);
        }

        private void frmAgentMain_Load(object sender, EventArgs e)
        {
            appendLog("System Loading...");
            SFTP_LogPath = Directory.GetCurrentDirectory() + Path.DirectorySeparatorChar + "NILE_Agent_Logs" + Path.DirectorySeparatorChar;
            SFTP_LogPath = @"C:\NILE_Agent_logs\";
            SFTP_LogFileName = "NILE_Agent_" + DateTime.Now.Year.ToString("D4") + "_" + DateTime.Now.Month.ToString("D2") + "_" + DateTime.Now.Day.ToString("D2") + ".log";
            this.textBoxLogPath.Text = SFTP_LogPath + SFTP_LogFileName;

            load_all_default_params();
            InitializeKafkaProtocol();
            appendLog("System Loading 완료");

            if (String.IsNullOrEmpty(this.txtRegion.Text))
            {
                this.objectStorage_Protocol = new ObjectStorageProtocol(this.txtUser.Text, this.txtPassword.Text);
            }
            else
            {
                this.objectStorage_Protocol = new ObjectStorageProtocol(this.txtUser.Text, this.txtPassword.Text, this.txtRegion.Text);
            }
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

            StartSecTimer();

            appendLog("StartSecTimer was successful");


            if (AreSparkSettingsValid())
            {
                press_autoCtrl = true;
                btnAutoCtrl.PerformClick();
            }
            else
            {
                appendLog("Spark settings are incomplete. Auto control is disabled.");
            }

        }

        private bool AreSparkSettingsValid()
        {
            string appName = Properties.Settings.Default.APP_NAME;
            string setMaster = Properties.Settings.Default.SET_MASTER;
            string sparkConfigs = Properties.Settings.Default.SPARK_CONFIGS;

            return !string.IsNullOrEmpty(appName) &&
                   !string.IsNullOrEmpty(setMaster) &&
                   !string.IsNullOrEmpty(sparkConfigs);
        }

        private void createToolTipText(Control c, String s)
        {
            ToolTip toolTip = new ToolTip();

            toolTip.SetToolTip(c, s);
        }

        private void initDisconnectControl()
        {
            auto_ctrl_mode = false;
            this.ObjectStorageGroupBox.Enabled = true;
            this.TopicServerGroupBox.Enabled = true;
            this.LocalDirGroupBox.Enabled = true;
            this.ETLGroupBox.Enabled = true;
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
                object_storage_disconnect();
                appendLog(this.objectStorage_Protocol.getErrorDes() + " Ex. :" + exp.ToString() + "\r\n");
                initAutoControl();
            }

        }

        private bool initAutoControl(bool promptErr = false)
        {
            Boolean init_sucess = false;
            if (validateLoginParam(promptErr) &&
                validateDirectory(promptErr) &&
                validateSyncOptionsParam(promptErr) &&
                AreSparkSettingsValid())
            {
                this.SaveObjectStorageCheckBox.Checked = true;
                this.SaveTopicServerCheckBox.Checked = true;
                this.SaveDirCheckBox.Checked = true;
                this.SaveScheduleCheckBox.Checked = true;
                Properties.Settings.Default.Save();

                auto_ctrl_mode = false;


                appendLog("자동 접속 모드 전환");

                this.ObjectStorageGroupBox.Enabled = false;
                this.TopicServerGroupBox.Enabled = false;
                this.LocalDirGroupBox.Enabled = false;
                this.ScheduleGroupBox.Enabled = false;
                this.ETLGroupBox.Enabled = false;
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

                appendLog("Object Storage 접속 " + this.txtHost.Text);
                bool blConnectResult = this.objectStorage_Protocol.ConnectToObjectStorage(this.txtHost.Text, this.objectStoragePort, this.txtUser.Text, this.txtPassword.Text, 120);

                if (!blConnectResult)
                {
                    MessageBox.Show(this.objectStorage_Protocol.getErrorDes(),
                    "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    appendLog("접속 " + this.txtHost.Text + " ERROR");
                    objectStorage_connected = false;

                }
                else
                {
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
                    MessageBox.Show("필수 정보를 모두 입력해주세요.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            else
            {
                try
                {
                    this.objectStoragePort = Convert.ToInt32(this.txtPort.Text);
                    if (this.objectStoragePort < 1 && this.objectStoragePort > 65535)
                    {

                        if (promptErr)
                        {
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

            if (string.IsNullOrWhiteSpace(this.txtBrowser.Text))
            {
                if (promptErr)
                {
                    MessageBox.Show("Please select a directory.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            else
            {
                try
                {
                    var normalizedPath = Path.GetFullPath(new Uri(this.txtBrowser.Text).LocalPath);
                    normalizedPath = normalizedPath.TrimEnd(Path.DirectorySeparatorChar, Path.AltDirectorySeparatorChar);

                    if (!Directory.Exists(normalizedPath))
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
                        MessageBox.Show("Error accessing directory: " + exp.Message, "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            return blResult;
        }


        private void frmAgentMain_FormClosing(object sender, FormClosingEventArgs e)
        {
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
            this.objectStorage_Protocol.DisconnectFromObjectStorage();
            this.Dispose(true);

        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog openFolderDialog = new FolderBrowserDialog();
            DialogResult result = openFolderDialog.ShowDialog();
            if (result == DialogResult.OK)
            {
                setText(this.txtBrowser, openFolderDialog.SelectedPath);
            }
            else
            {
                MessageBox.Show("경로 지정이 필요합니다.",
                    "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        public class KafkaData
        {
            public string sparkConfigAppName { get; set; }
            public string sparkConfigSetMaster { get; set; }
            public string objectStoragePath { get; set; }
            public string sourceType { get; set; }
            public string fileName { get; set; }
            public string fileExtension { get; set; }
            public bool processETL { get; set; }
            //csv
            public bool csvHeader { get; set; }
            public string csvCustomHeader { get; set; }
            public string csvDelimiter { get; set; }
            public string csvEncodingType { get; set; }
            //json
            public string jsonParseSelectedKey { get; set; }
            //target table
            public string targetType { get; set; }
            public string targetCatalog { get; set; }
            public string targetDatabase { get; set; }
            public string targetTable { get; set; }
            //others
            public string startDateTime { get; set; }
            public List<SparkConfigItem> sparkConfigs { get; set; }

        }

        private string GetRelativePath(string basePath, string targetPath)
        {
            if (!basePath.EndsWith(Path.DirectorySeparatorChar.ToString(), StringComparison.Ordinal))
                basePath += Path.DirectorySeparatorChar;
            Uri baseUri = new Uri(basePath);
            Uri targetUri = new Uri(targetPath);

            if (baseUri.IsBaseOf(targetUri))
            {
                Uri relativeUri = baseUri.MakeRelativeUri(targetUri);
                string relativePath = Uri.UnescapeDataString(relativeUri.ToString()).Replace('/', Path.DirectorySeparatorChar);
                return relativePath;
            }
            return targetPath;
        }


        private void backgroundWorker_SyncFiles(object sender, DoWorkEventArgs e)
        {
            if (!objectStorage_Protocol.ConnectToObjectStorage(this.txtHost.Text, this.objectStoragePort, this.txtUser.Text, this.txtPassword.Text, 120))
            {
                storage_connect();
            }

            if ((string)e.Argument != "upload_only")
            {
                storage_connect();
            }

            topicMessage_Protocol = new KafkaProtocol(this.txtTopicServer.Text);

            if (objectStorage_connected)
            {
                if (validateDirectory())
                {
                    sync_processing = true;

                    string baseDirectoryPath = this.txtBrowser.Text;
                    string[] files = Directory.GetFiles(baseDirectoryPath, "*", SearchOption.AllDirectories);
                    string csvExtensions = Properties.Settings.Default.CSV_EXTENSIONS ?? "";
                    string jsonExtensions = Properties.Settings.Default.JSON_EXTENSIONS ?? "";
                    var csvExtension = csvExtensions.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(ext => ext.Trim()).ToList();
                    var jsonExtension = jsonExtensions.Split(new[] { ';' }, StringSplitOptions.RemoveEmptyEntries).Select(ext => ext.Trim()).ToList();
                    
                    int totalFiles = files.Length;
                    for (int i = 0; i < totalFiles; i++)
                    {
                        string filePath = files[i];
                        string relativePath = GetRelativePath(baseDirectoryPath, filePath);
                        string objectKey = relativePath.Replace("\\", "/");
                        string fileExtensionLower = Path.GetExtension(filePath).ToLower();

                        if (!(fileExtensionLower.Equals(".csv") || fileExtensionLower.Equals(".json") || fileExtensionLower.Equals(".txt")))
                        {
                            bool fileExists = objectStorage_Protocol.CheckIfFileExists(this.txtBucket.Text, objectKey);
                            if (fileExists)
                            {
                                appendLog($"File {objectKey},{fileExtensionLower} already exists in object storage. Skipping upload.");
                            }
                        }
                        else
                        {
                            bool uploadSuccess = objectStorage_Protocol.UploadFileToObjectStorage(filePath, this.txtBucket.Text, objectKey);

                            string appName = Properties.Settings.Default.APP_NAME;
                            string setMaster = Properties.Settings.Default.SET_MASTER;
                            string sparkConfigsJson = Properties.Settings.Default.SPARK_CONFIGS;
                            bool csvHeader = Properties.Settings.Default.CSV_HEADER;
                            string csvCustomHeader = Properties.Settings.Default.CSV_CUSTOM_HEADER;
                            string csvDelimiter = Properties.Settings.Default.CSV_DELIMITER;
                            string csvEncodingType = Properties.Settings.Default.CSV_ENCODING_TYPE;
                            string targetType = Properties.Settings.Default.TARGET_TYPE;
                            string targetCatalog = Properties.Settings.Default.TARGET_CATALOG;
                            string targetDatabase = Properties.Settings.Default.TARGET_DATABASE;
                            string targetTable = Properties.Settings.Default.TARGET_TABLE;
                            string jsonParseSelectedKey = Properties.Settings.Default.JSON_SELECTED_KEY;

                            List<SparkConfigItem> sparkConfigs = null;
                            try
                            {
                                sparkConfigs = JsonConvert.DeserializeObject<List<SparkConfigItem>>(sparkConfigsJson);
                            }
                            catch (JsonException ex)
                            {
                                appendLog($"Failed to deserialize SPARK_CONFIGS: {ex.Message}");
                            }

                            if (uploadSuccess)
                            {
                                appendLog($"Uploaded {objectKey} to bucket {this.txtBucket.Text}");

                                string fileExtension = Path.GetExtension(filePath).TrimStart('.');
                                string fileName = Path.GetFileName(filePath);

                                if (topicMessage_Protocol != null)
                                {
                                    KafkaData data = new KafkaData { };

                                    data.sparkConfigAppName = appName;
                                    data.sparkConfigSetMaster = setMaster;
                                    data.objectStoragePath = "s3a://" + this.txtTopic.Text;
                                    data.sourceType = fileExtension;
                                    data.fileName = objectKey;
                                    data.fileExtension = "." + fileExtension;
                                    data.sparkConfigs = sparkConfigs;

                                    if (csvExtension.Contains(fileExtension))
                                    {
                                        data = csvProcess(data, csvHeader, csvCustomHeader, csvDelimiter, csvEncodingType,
                                            targetType, targetCatalog, targetDatabase, targetTable);
                                    }
                                    else if (jsonExtension.Contains(fileExtension))
                                    {
                                        data = jsonProcess(data, jsonParseSelectedKey,
                                            targetType, targetCatalog, targetDatabase, targetTable);
                                    }
                                    else
                                    {
                                        data = defaultProcess(data);
                                    }

                                    try
                                    {
                                        string jsonData = JsonConvert.SerializeObject(data);
                                        var key = "spark_task";
                                        topicMessage_Protocol.UploadMessageToKafka(this.txtTopic.Text, key, jsonData, this.txtTopicServer.Text);

                                        appendLog($"Kafka message sent for {objectKey}");
                                    }
                                    catch (Exception kafkaExp)
                                    {
                                        appendLog($"Failed to send Kafka message for {objectKey}: {kafkaExp.Message}");
                                    }

                                }
                                else
                                {
                                    appendLog("Kafka protocol is not initialized.");
                                }

                            }
                            else
                            {
                                appendLog($"Failed to upload {objectKey}: {objectStorage_Protocol.getErrorDes()}");
                            }
                        }

                        int progressPercentage = (int)((i + 1) / (double)totalFiles * 100);
                        backgroundWorker.ReportProgress(progressPercentage);
                    }

                    sync_processing = false;
                }
                else
                {
                    appendLog("Invalid Directory!", newline: true);
                }
            }
            else
            {
                appendLog("Unable to connect . . .  ", newline: true);
            }

            if ((string)e.Argument != "upload_only")
            {
                object_storage_disconnect();
            }
        }

        private KafkaData csvProcess(KafkaData data, bool csvHeader, string csvCustomHeader, string csvDelimiter, string csvEncodingType,
                                        string targetType, string targetCatalog, string targetDatabase, string targetTable)
        {
            data.processETL = this.btnETL.Enabled;
            data.csvHeader = csvHeader;
            data.csvCustomHeader = csvCustomHeader;
            data.csvDelimiter = csvDelimiter;
            data.csvEncodingType = csvEncodingType;
            data.targetType = targetType;
            data.targetCatalog = targetCatalog;
            data.targetDatabase = targetDatabase;
            data.targetTable = targetTable;
            data.jsonParseSelectedKey = null;
            data.startDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff");
            return data;
        }

        private KafkaData jsonProcess(KafkaData data, string jsonParseSelectedKey,
                                        string targetType, string targetCatalog, string targetDatabase, string targetTable)
        {
            data.processETL = this.btnETL.Enabled;
            data.csvHeader = false;
            data.csvCustomHeader = null;
            data.csvDelimiter = null;
            data.csvEncodingType = null;
            data.targetType = targetType;
            data.targetCatalog = targetCatalog;
            data.targetDatabase = targetDatabase;
            data.targetTable = targetTable;
            data.jsonParseSelectedKey = jsonParseSelectedKey;
            data.startDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff");
            return data;
        }

        private KafkaData defaultProcess(KafkaData data)
        {
            data.processETL = this.btnETL.Enabled;
            data.csvHeader = false;
            data.csvCustomHeader = null;
            data.csvDelimiter = null;
            data.csvEncodingType = null;
            data.targetType = null;
            data.targetCatalog = null;
            data.targetDatabase = null;
            data.targetTable = null;
            data.jsonParseSelectedKey = null;
            data.startDateTime = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss:fff");
            return data;
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
            if (auto_ctrl_mode)
            {
                string testPW = PromptPW.ShowPWDialog();
                if (testPW != masterPasswd)
                {
                    MessageBox.Show("Password가 일치하지 않습니다.", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                {
                    press_autoCtrl = false;
                    btnAutoCtrl.Enabled = true;
                    btnDisconnect.Enabled = false;
                    btnSpark.Enabled = true;
                    initDisconnectControl();
                }
            }
        }

        private void btnAutoCtrl_Click(object sender, EventArgs e)
        {

            if (initAutoControl(promptErr: true))
            {
                btnAutoCtrl.Enabled = false;
                btnDisconnect.Enabled = true;
                btnSpark.Enabled = false;
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
                    Properties.Settings.Default.SYNC_DIR = this.txtBrowser.Text;
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


        private void comboBoxServerOS_SelectedIndexChanged(object sender, EventArgs e)
        {
            SaveTopicServerCheckBox.Checked = false;
        }

        private void txtServerFolder_TextChanged(object sender, EventArgs e)
        {
            SaveTopicServerCheckBox.Checked = false;
        }

        private void btnETL_Click(object sender, EventArgs e)
        {
            string targetType = Properties.Settings.Default.TARGET_TYPE;
            string targetCatalog = Properties.Settings.Default.TARGET_CATALOG;
            string targetDatabase = Properties.Settings.Default.TARGET_DATABASE;
            string targetTable = Properties.Settings.Default.TARGET_TABLE;
            bool csvHeader = Properties.Settings.Default.CSV_HEADER;
            string csvCustomHeader = Properties.Settings.Default.CSV_CUSTOM_HEADER;
            string csvDelimiter = Properties.Settings.Default.CSV_DELIMITER;
            string csvEncodingType = Properties.Settings.Default.CSV_ENCODING_TYPE;
            string jsonParseSelectedKey = Properties.Settings.Default.JSON_SELECTED_KEY;
            string csv = Properties.Settings.Default.CSV_EXTENSIONS;
            string json = Properties.Settings.Default.JSON_EXTENSIONS;

            ETLPopUp etlPopUp = new ETLPopUp(targetType, targetCatalog, targetDatabase, targetTable,
            csvHeader, csvCustomHeader, csvDelimiter, csvEncodingType,
            jsonParseSelectedKey, csv, json);

            if (etlPopUp.ShowDialog() == DialogResult.OK)
            {
                // Settings are saved within SparkSettings form, no need to save here again
                // Any post-save actions can be handled here if necessary
            }
        }

        private void checkBoxETL_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxETL.Checked)
            {
                btnETL.Enabled = true;
            }
            else
            {
                btnETL.Enabled = false;
            }
            
        }

        private void SaveTopicServerCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (SaveTopicServerCheckBox.Checked)
            {
                if (validateTopicServerParam(promptErr: true))
                {
                    Properties.Settings.Default.BOOTSTRAP_SERVERS = txtTopicServer.Text.Trim();
                    Properties.Settings.Default.TOPIC_NAME = txtTopic.Text.Trim();
                    Properties.Settings.Default.Save();
                }
                else
                {
                    SaveTopicServerCheckBox.Checked = false;
                }
            }
        }

        private Boolean validateTopicServerParam(bool promptErr = false)
        {
            bool blResult = true;
            if (txtTopicServer.Text.Trim().Equals("") || txtTopic.Text.Trim().Equals(""))
            {
                if (promptErr)
                {
                    MessageBox.Show("Please enter both Topic Server and Topic Name.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            return blResult;
        }

        private void btnSpark_Click(object sender, EventArgs e)
        {
            string currentAppName = Properties.Settings.Default.APP_NAME;
            string currentSetMaster = Properties.Settings.Default.SET_MASTER;
            string currentSparkConfigs = Properties.Settings.Default.SPARK_CONFIGS;

            SparkSettings sparkPopUp = new SparkSettings(currentAppName, currentSetMaster, currentSparkConfigs);

            if (sparkPopUp.ShowDialog() == DialogResult.OK)
            {
                // Settings are saved within SparkSettings form, no need to save here again
                // Any post-save actions can be handled here if necessary
            }
        }

    }

}
