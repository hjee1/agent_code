using System;
using System.Windows.Forms;

namespace SFTP
{
    public partial class ETLPopUp : Form
    {
        public ETLPopUp(string initialTargetType, string initialTargetCatalog, string initialTargetDatabase, string initialTargetTable, 
            bool initialCSVHeader, string initialCSVCustomHeader, string initialCSVDelimiter, string initialCSVEncodingType, 
            string initialJSONParseSelectedKey, string initialCSV, string initialJSON)
        {
            InitializeComponent();

            txtTargetType.Text = initialTargetType;
            txtTargetCatalog.Text = initialTargetCatalog;
            txtTargetDatabase.Text = initialTargetDatabase;
            txtTargetTable.Text = initialTargetTable;
            CSVHeaderCheckBox.Enabled = initialCSVHeader;
            txtCSVCustomHeader.Text = initialCSVCustomHeader;
            txtCSVDelimiter.Text = initialCSVDelimiter;
            CSVEncodingTypeComboBox.Text = initialCSVEncodingType;
            txtJSONSelectedKey.Text = initialJSONParseSelectedKey;
            txtCSV.Text = initialCSV;
            txtJSON.Text = initialJSON;
            
        }

        private void btnSave_Click(object sender, System.EventArgs e)
        {
            
                // Save the settings from text boxes to application settings
                Properties.Settings.Default.TARGET_TYPE = txtTargetType.Text.Trim();
                Properties.Settings.Default.TARGET_CATALOG = txtTargetCatalog.Text.Trim();
                Properties.Settings.Default.TARGET_DATABASE = txtTargetDatabase.Text.Trim();
                Properties.Settings.Default.TARGET_TABLE = txtTargetTable.Text.Trim();
                Properties.Settings.Default.CSV_HEADER = CSVHeaderCheckBox.Enabled;
                Properties.Settings.Default.CSV_CUSTOM_HEADER = txtCSVCustomHeader.Text.Trim();
                Properties.Settings.Default.CSV_DELIMITER = txtCSVDelimiter.Text.Trim();
                Properties.Settings.Default.CSV_ENCODING_TYPE = CSVEncodingTypeComboBox.Text.Trim();
                Properties.Settings.Default.JSON_SELECTED_KEY = txtJSONSelectedKey.Text.Trim();
                Properties.Settings.Default.CSV_EXTENSIONS = txtCSV.Text.Trim();
                Properties.Settings.Default.JSON_EXTENSIONS = txtJSON.Text.Trim();

                // Persist changes
                Properties.Settings.Default.Save();

                // Signal that settings were successfully saved
                this.DialogResult = DialogResult.OK;
                this.Close();
            
        }


    }



}
