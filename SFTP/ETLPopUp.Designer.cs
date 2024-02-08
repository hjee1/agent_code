
namespace SFTP
{
    partial class ETLPopUp
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
            this.btnSave = new System.Windows.Forms.Button();
            this.CSVGroupBox = new System.Windows.Forms.GroupBox();
            this.CSVEncodingTypeComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtCSVCustomHeader = new System.Windows.Forms.TextBox();
            this.CSVHeaderCheckBox = new System.Windows.Forms.CheckBox();
            this.txtCSVDelimiter = new System.Windows.Forms.TextBox();
            this.lbCsvDelim = new System.Windows.Forms.Label();
            this.lbCsvCustomHeader = new System.Windows.Forms.Label();
            this.txtJSONSelectedKey = new System.Windows.Forms.TextBox();
            this.lbJsonSelectedKey = new System.Windows.Forms.Label();
            this.TargetInfoGroupBox = new System.Windows.Forms.GroupBox();
            this.txtJSON = new System.Windows.Forms.TextBox();
            this.txtTargetTable = new System.Windows.Forms.TextBox();
            this.txtCSV = new System.Windows.Forms.TextBox();
            this.txtTargetDatabase = new System.Windows.Forms.TextBox();
            this.lbJSON = new System.Windows.Forms.Label();
            this.txtTargetCatalog = new System.Windows.Forms.TextBox();
            this.lbCSV = new System.Windows.Forms.Label();
            this.txtTargetType = new System.Windows.Forms.TextBox();
            this.lbTargetTableName = new System.Windows.Forms.Label();
            this.lbTargetDatabase = new System.Windows.Forms.Label();
            this.lbTargetCatalog = new System.Windows.Forms.Label();
            this.lbTargetType = new System.Windows.Forms.Label();
            this.FilePatternGroupBox = new System.Windows.Forms.GroupBox();
            this.CSVGroupBox.SuspendLayout();
            this.TargetInfoGroupBox.SuspendLayout();
            this.FilePatternGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(494, 231);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(158, 42);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // CSVGroupBox
            // 
            this.CSVGroupBox.Controls.Add(this.CSVEncodingTypeComboBox);
            this.CSVGroupBox.Controls.Add(this.label1);
            this.CSVGroupBox.Controls.Add(this.txtCSVCustomHeader);
            this.CSVGroupBox.Controls.Add(this.CSVHeaderCheckBox);
            this.CSVGroupBox.Controls.Add(this.txtCSVDelimiter);
            this.CSVGroupBox.Controls.Add(this.lbCsvDelim);
            this.CSVGroupBox.Controls.Add(this.lbCsvCustomHeader);
            this.CSVGroupBox.Location = new System.Drawing.Point(5, 80);
            this.CSVGroupBox.Name = "CSVGroupBox";
            this.CSVGroupBox.Size = new System.Drawing.Size(403, 193);
            this.CSVGroupBox.TabIndex = 59;
            this.CSVGroupBox.TabStop = false;
            this.CSVGroupBox.Text = "CSV Detail (상세정보)";
            // 
            // CSVEncodingTypeComboBox
            // 
            this.CSVEncodingTypeComboBox.FormattingEnabled = true;
            this.CSVEncodingTypeComboBox.Items.AddRange(new object[] {
            "EUC-KR",
            "UTF-8"});
            this.CSVEncodingTypeComboBox.Location = new System.Drawing.Point(260, 22);
            this.CSVEncodingTypeComboBox.Name = "CSVEncodingTypeComboBox";
            this.CSVEncodingTypeComboBox.Size = new System.Drawing.Size(106, 21);
            this.CSVEncodingTypeComboBox.TabIndex = 58;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(175, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 56;
            this.label1.Text = "Encoding Type";
            // 
            // txtCSVCustomHeader
            // 
            this.txtCSVCustomHeader.AcceptsReturn = true;
            this.txtCSVCustomHeader.AcceptsTab = true;
            this.txtCSVCustomHeader.Location = new System.Drawing.Point(5, 95);
            this.txtCSVCustomHeader.Multiline = true;
            this.txtCSVCustomHeader.Name = "txtCSVCustomHeader";
            this.txtCSVCustomHeader.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtCSVCustomHeader.Size = new System.Drawing.Size(390, 90);
            this.txtCSVCustomHeader.TabIndex = 55;
            // 
            // CSVHeaderCheckBox
            // 
            this.CSVHeaderCheckBox.AutoSize = true;
            this.CSVHeaderCheckBox.Location = new System.Drawing.Point(10, 50);
            this.CSVHeaderCheckBox.Name = "CSVHeaderCheckBox";
            this.CSVHeaderCheckBox.Size = new System.Drawing.Size(91, 17);
            this.CSVHeaderCheckBox.TabIndex = 54;
            this.CSVHeaderCheckBox.Text = "Header (CSV)";
            this.CSVHeaderCheckBox.UseVisualStyleBackColor = true;
            // 
            // txtCSVDelimiter
            // 
            this.txtCSVDelimiter.Location = new System.Drawing.Point(90, 20);
            this.txtCSVDelimiter.Name = "txtCSVDelimiter";
            this.txtCSVDelimiter.Size = new System.Drawing.Size(68, 20);
            this.txtCSVDelimiter.TabIndex = 51;
            // 
            // lbCsvDelim
            // 
            this.lbCsvDelim.AutoSize = true;
            this.lbCsvDelim.Location = new System.Drawing.Point(10, 25);
            this.lbCsvDelim.Name = "lbCsvDelim";
            this.lbCsvDelim.Size = new System.Drawing.Size(77, 13);
            this.lbCsvDelim.TabIndex = 48;
            this.lbCsvDelim.Text = "Delimiter (CSV)";
            // 
            // lbCsvCustomHeader
            // 
            this.lbCsvCustomHeader.AutoSize = true;
            this.lbCsvCustomHeader.Location = new System.Drawing.Point(5, 75);
            this.lbCsvCustomHeader.Name = "lbCsvCustomHeader";
            this.lbCsvCustomHeader.Size = new System.Drawing.Size(113, 13);
            this.lbCsvCustomHeader.TabIndex = 47;
            this.lbCsvCustomHeader.Text = "CSV Customer Header";
            // 
            // txtJSONSelectedKey
            // 
            this.txtJSONSelectedKey.Location = new System.Drawing.Point(5, 45);
            this.txtJSONSelectedKey.Name = "txtJSONSelectedKey";
            this.txtJSONSelectedKey.Size = new System.Drawing.Size(283, 20);
            this.txtJSONSelectedKey.TabIndex = 52;
            // 
            // lbJsonSelectedKey
            // 
            this.lbJsonSelectedKey.AutoSize = true;
            this.lbJsonSelectedKey.Location = new System.Drawing.Point(5, 25);
            this.lbJsonSelectedKey.Name = "lbJsonSelectedKey";
            this.lbJsonSelectedKey.Size = new System.Drawing.Size(107, 13);
            this.lbJsonSelectedKey.TabIndex = 49;
            this.lbJsonSelectedKey.Text = "Selected Key (JSON)";
            // 
            // TargetInfoGroupBox
            // 
            this.TargetInfoGroupBox.Controls.Add(this.txtJSON);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetTable);
            this.TargetInfoGroupBox.Controls.Add(this.txtCSV);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetDatabase);
            this.TargetInfoGroupBox.Controls.Add(this.lbJSON);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetCatalog);
            this.TargetInfoGroupBox.Controls.Add(this.lbCSV);
            this.TargetInfoGroupBox.Controls.Add(this.txtTargetType);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetTableName);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetDatabase);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetCatalog);
            this.TargetInfoGroupBox.Controls.Add(this.lbTargetType);
            this.TargetInfoGroupBox.Location = new System.Drawing.Point(5, 5);
            this.TargetInfoGroupBox.Name = "TargetInfoGroupBox";
            this.TargetInfoGroupBox.Size = new System.Drawing.Size(710, 75);
            this.TargetInfoGroupBox.TabIndex = 58;
            this.TargetInfoGroupBox.TabStop = false;
            this.TargetInfoGroupBox.Text = "Target 정보";
            // 
            // txtJSON
            // 
            this.txtJSON.Location = new System.Drawing.Point(545, 45);
            this.txtJSON.Name = "txtJSON";
            this.txtJSON.Size = new System.Drawing.Size(148, 20);
            this.txtJSON.TabIndex = 46;
            // 
            // txtTargetTable
            // 
            this.txtTargetTable.Location = new System.Drawing.Point(55, 45);
            this.txtTargetTable.Name = "txtTargetTable";
            this.txtTargetTable.Size = new System.Drawing.Size(163, 20);
            this.txtTargetTable.TabIndex = 48;
            // 
            // txtCSV
            // 
            this.txtCSV.Location = new System.Drawing.Point(305, 45);
            this.txtCSV.Name = "txtCSV";
            this.txtCSV.Size = new System.Drawing.Size(148, 20);
            this.txtCSV.TabIndex = 43;
            // 
            // txtTargetDatabase
            // 
            this.txtTargetDatabase.Location = new System.Drawing.Point(530, 20);
            this.txtTargetDatabase.Name = "txtTargetDatabase";
            this.txtTargetDatabase.Size = new System.Drawing.Size(163, 20);
            this.txtTargetDatabase.TabIndex = 47;
            // 
            // lbJSON
            // 
            this.lbJSON.AutoSize = true;
            this.lbJSON.Location = new System.Drawing.Point(470, 50);
            this.lbJSON.Name = "lbJSON";
            this.lbJSON.Size = new System.Drawing.Size(71, 13);
            this.lbJSON.TabIndex = 41;
            this.lbJSON.Text = "JSON 확장자";
            // 
            // txtTargetCatalog
            // 
            this.txtTargetCatalog.Location = new System.Drawing.Point(290, 20);
            this.txtTargetCatalog.Name = "txtTargetCatalog";
            this.txtTargetCatalog.Size = new System.Drawing.Size(163, 20);
            this.txtTargetCatalog.TabIndex = 46;
            // 
            // lbCSV
            // 
            this.lbCSV.AutoSize = true;
            this.lbCSV.Location = new System.Drawing.Point(235, 50);
            this.lbCSV.Name = "lbCSV";
            this.lbCSV.Size = new System.Drawing.Size(64, 13);
            this.lbCSV.TabIndex = 40;
            this.lbCSV.Text = "CSV 확장자";
            // 
            // txtTargetType
            // 
            this.txtTargetType.Location = new System.Drawing.Point(55, 20);
            this.txtTargetType.Name = "txtTargetType";
            this.txtTargetType.Size = new System.Drawing.Size(163, 20);
            this.txtTargetType.TabIndex = 45;
            // 
            // lbTargetTableName
            // 
            this.lbTargetTableName.AutoSize = true;
            this.lbTargetTableName.Location = new System.Drawing.Point(10, 50);
            this.lbTargetTableName.Name = "lbTargetTableName";
            this.lbTargetTableName.Size = new System.Drawing.Size(34, 13);
            this.lbTargetTableName.TabIndex = 3;
            this.lbTargetTableName.Text = "Table";
            // 
            // lbTargetDatabase
            // 
            this.lbTargetDatabase.AutoSize = true;
            this.lbTargetDatabase.Location = new System.Drawing.Point(470, 25);
            this.lbTargetDatabase.Name = "lbTargetDatabase";
            this.lbTargetDatabase.Size = new System.Drawing.Size(53, 13);
            this.lbTargetDatabase.TabIndex = 2;
            this.lbTargetDatabase.Text = "Database";
            // 
            // lbTargetCatalog
            // 
            this.lbTargetCatalog.AutoSize = true;
            this.lbTargetCatalog.Location = new System.Drawing.Point(235, 25);
            this.lbTargetCatalog.Name = "lbTargetCatalog";
            this.lbTargetCatalog.Size = new System.Drawing.Size(43, 13);
            this.lbTargetCatalog.TabIndex = 1;
            this.lbTargetCatalog.Text = "Catalog";
            // 
            // lbTargetType
            // 
            this.lbTargetType.AutoSize = true;
            this.lbTargetType.Location = new System.Drawing.Point(10, 25);
            this.lbTargetType.Name = "lbTargetType";
            this.lbTargetType.Size = new System.Drawing.Size(31, 13);
            this.lbTargetType.TabIndex = 0;
            this.lbTargetType.Text = "Type";
            // 
            // FilePatternGroupBox
            // 
            this.FilePatternGroupBox.Controls.Add(this.lbJsonSelectedKey);
            this.FilePatternGroupBox.Controls.Add(this.txtJSONSelectedKey);
            this.FilePatternGroupBox.Location = new System.Drawing.Point(410, 80);
            this.FilePatternGroupBox.Name = "FilePatternGroupBox";
            this.FilePatternGroupBox.Size = new System.Drawing.Size(305, 80);
            this.FilePatternGroupBox.TabIndex = 57;
            this.FilePatternGroupBox.TabStop = false;
            this.FilePatternGroupBox.Text = "JSON Detail (상세정보)";
            // 
            // ETLPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 281);
            this.ControlBox = false;
            this.Controls.Add(this.CSVGroupBox);
            this.Controls.Add(this.TargetInfoGroupBox);
            this.Controls.Add(this.FilePatternGroupBox);
            this.Controls.Add(this.btnSave);
            this.Name = "ETLPopUp";
            this.Text = "ETL Configurations";
            this.CSVGroupBox.ResumeLayout(false);
            this.CSVGroupBox.PerformLayout();
            this.TargetInfoGroupBox.ResumeLayout(false);
            this.TargetInfoGroupBox.PerformLayout();
            this.FilePatternGroupBox.ResumeLayout(false);
            this.FilePatternGroupBox.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox CSVGroupBox;
        private System.Windows.Forms.TextBox txtCSVCustomHeader;
        private System.Windows.Forms.CheckBox CSVHeaderCheckBox;
        private System.Windows.Forms.TextBox txtJSONSelectedKey;
        private System.Windows.Forms.TextBox txtCSVDelimiter;
        private System.Windows.Forms.Label lbJsonSelectedKey;
        private System.Windows.Forms.Label lbCsvDelim;
        private System.Windows.Forms.Label lbCsvCustomHeader;
        private System.Windows.Forms.GroupBox TargetInfoGroupBox;
        private System.Windows.Forms.TextBox txtTargetTable;
        private System.Windows.Forms.TextBox txtTargetDatabase;
        private System.Windows.Forms.TextBox txtTargetCatalog;
        private System.Windows.Forms.TextBox txtTargetType;
        private System.Windows.Forms.Label lbTargetTableName;
        private System.Windows.Forms.Label lbTargetDatabase;
        private System.Windows.Forms.Label lbTargetCatalog;
        private System.Windows.Forms.Label lbTargetType;
        private System.Windows.Forms.GroupBox FilePatternGroupBox;
        private System.Windows.Forms.TextBox txtJSON;
        private System.Windows.Forms.TextBox txtCSV;
        private System.Windows.Forms.Label lbJSON;
        private System.Windows.Forms.Label lbCSV;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox CSVEncodingTypeComboBox;
    }
}