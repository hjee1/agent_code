using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SFTP
{
    public partial class SparkSettings : Form
    {
        public SparkSettings(string initialAppName, string initialSetMaster, string initialSparkConfigs)
        {
            InitializeComponent();
            // Set initial values to text boxes
            txtAppName.Text = initialAppName;
            txtSetMaster.Text = initialSetMaster;
            textBoxSparkConfigs.Text = initialSparkConfigs;
        }


        private Boolean validateBasicParam(bool promptErr = false)
        {
            bool blResult = true;
            if (txtAppName.Text.Trim().Equals("") || txtSetMaster.Text.Trim().Equals("") || textBoxSparkConfigs.Text.Trim().Equals(""))
            {
                if (promptErr)
                {
                    MessageBox.Show("Please fill all the basic fields.", "NILE Agent Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                blResult = false;
            }
            return blResult;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (validateBasicParam(promptErr: true))
            {
                // Save the settings from text boxes to application settings
                Properties.Settings.Default.APP_NAME = txtAppName.Text.Trim();
                Properties.Settings.Default.SET_MASTER = txtSetMaster.Text.Trim();
                Properties.Settings.Default.SPARK_CONFIGS = textBoxSparkConfigs.Text.Trim();

                // Persist changes
                Properties.Settings.Default.Save();

                // Signal that settings were successfully saved
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

    }
}
