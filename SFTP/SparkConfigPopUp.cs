using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SFTP
{
    public partial class SparkConfigPopUp : Form
    {
        public SparkConfigPopUp()
        {
            InitializeComponent();
        }


        private void btnSave_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
        

        public string AppName
        {
            get { return txtAppName.Text; }
        }
        
        public string SetMaster
        {
            get { return txtSetMaster.Text; }
        }
        
        public string TaskID
        {
            get { return txtTaskID.Text; }
        }

        public string SparkConfigs
        {
            get { return textBoxSparkConfigs.Text; }
        }
        

    }
}
