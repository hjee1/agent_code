
namespace SFTP
{
    partial class SparkConfigPopUp
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
            this.lbAppName = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.txtSetMaster = new System.Windows.Forms.TextBox();
            this.lbSetMaster = new System.Windows.Forms.Label();
            this.txtTaskID = new System.Windows.Forms.TextBox();
            this.lbTaskID = new System.Windows.Forms.Label();
            this.lbSparkConfigs = new System.Windows.Forms.Label();
            this.textBoxSparkConfigs = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(213, 226);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // lbAppName
            // 
            this.lbAppName.AutoSize = true;
            this.lbAppName.Location = new System.Drawing.Point(5, 9);
            this.lbAppName.Name = "lbAppName";
            this.lbAppName.Size = new System.Drawing.Size(57, 13);
            this.lbAppName.TabIndex = 1;
            this.lbAppName.Text = "App Name";
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(79, 5);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(160, 20);
            this.txtAppName.TabIndex = 2;
            // 
            // txtSetMaster
            // 
            this.txtSetMaster.Location = new System.Drawing.Point(313, 5);
            this.txtSetMaster.Name = "txtSetMaster";
            this.txtSetMaster.Size = new System.Drawing.Size(160, 20);
            this.txtSetMaster.TabIndex = 4;
            // 
            // lbSetMaster
            // 
            this.lbSetMaster.AutoSize = true;
            this.lbSetMaster.Location = new System.Drawing.Point(253, 9);
            this.lbSetMaster.Name = "lbSetMaster";
            this.lbSetMaster.Size = new System.Drawing.Size(58, 13);
            this.lbSetMaster.TabIndex = 3;
            this.lbSetMaster.Text = "Set Master";
            // 
            // txtTaskID
            // 
            this.txtTaskID.Location = new System.Drawing.Point(79, 30);
            this.txtTaskID.Name = "txtTaskID";
            this.txtTaskID.Size = new System.Drawing.Size(160, 20);
            this.txtTaskID.TabIndex = 6;
            // 
            // lbTaskID
            // 
            this.lbTaskID.AutoSize = true;
            this.lbTaskID.Location = new System.Drawing.Point(5, 34);
            this.lbTaskID.Name = "lbTaskID";
            this.lbTaskID.Size = new System.Drawing.Size(74, 13);
            this.lbTaskID.TabIndex = 5;
            this.lbTaskID.Text = "Task ID Prefix";
            // 
            // lbSparkConfigs
            // 
            this.lbSparkConfigs.AutoSize = true;
            this.lbSparkConfigs.Location = new System.Drawing.Point(5, 60);
            this.lbSparkConfigs.Name = "lbSparkConfigs";
            this.lbSparkConfigs.Size = new System.Drawing.Size(133, 13);
            this.lbSparkConfigs.TabIndex = 7;
            this.lbSparkConfigs.Text = "Spark Parameters (Config.)";
            // 
            // textBoxSparkConfigs
            // 
            this.textBoxSparkConfigs.AcceptsReturn = true;
            this.textBoxSparkConfigs.AcceptsTab = true;
            this.textBoxSparkConfigs.Location = new System.Drawing.Point(5, 80);
            this.textBoxSparkConfigs.Multiline = true;
            this.textBoxSparkConfigs.Name = "textBoxSparkConfigs";
            this.textBoxSparkConfigs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSparkConfigs.Size = new System.Drawing.Size(470, 140);
            this.textBoxSparkConfigs.TabIndex = 56;
            // 
            // SparkConfigPopUp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(484, 261);
            this.ControlBox = false;
            this.Controls.Add(this.textBoxSparkConfigs);
            this.Controls.Add(this.lbSparkConfigs);
            this.Controls.Add(this.txtTaskID);
            this.Controls.Add(this.lbTaskID);
            this.Controls.Add(this.txtSetMaster);
            this.Controls.Add(this.lbSetMaster);
            this.Controls.Add(this.txtAppName);
            this.Controls.Add(this.lbAppName);
            this.Controls.Add(this.btnSave);
            this.Name = "SparkConfigPopUp";
            this.Text = "Spark Configs (only for CSV & JSON)";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Label lbAppName;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.TextBox txtSetMaster;
        private System.Windows.Forms.Label lbSetMaster;
        private System.Windows.Forms.TextBox txtTaskID;
        private System.Windows.Forms.Label lbTaskID;
        private System.Windows.Forms.Label lbSparkConfigs;
        private System.Windows.Forms.TextBox textBoxSparkConfigs;
    }
}