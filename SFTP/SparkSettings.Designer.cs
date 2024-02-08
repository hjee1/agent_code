
namespace SFTP
{
    partial class SparkSettings
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lbAppName = new System.Windows.Forms.Label();
            this.txtAppName = new System.Windows.Forms.TextBox();
            this.textBoxSparkConfigs = new System.Windows.Forms.TextBox();
            this.lbSetMaster = new System.Windows.Forms.Label();
            this.lbSparkConfigs = new System.Windows.Forms.Label();
            this.txtSetMaster = new System.Windows.Forms.TextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lbAppName);
            this.groupBox1.Controls.Add(this.txtAppName);
            this.groupBox1.Controls.Add(this.textBoxSparkConfigs);
            this.groupBox1.Controls.Add(this.lbSetMaster);
            this.groupBox1.Controls.Add(this.lbSparkConfigs);
            this.groupBox1.Controls.Add(this.txtSetMaster);
            this.groupBox1.Location = new System.Drawing.Point(10, 10);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(650, 370);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "기본 입력 정보";
            // 
            // lbAppName
            // 
            this.lbAppName.AutoSize = true;
            this.lbAppName.Location = new System.Drawing.Point(5, 25);
            this.lbAppName.Name = "lbAppName";
            this.lbAppName.Size = new System.Drawing.Size(54, 13);
            this.lbAppName.TabIndex = 57;
            this.lbAppName.Text = "AppName";
            // 
            // txtAppName
            // 
            this.txtAppName.Location = new System.Drawing.Point(65, 22);
            this.txtAppName.Name = "txtAppName";
            this.txtAppName.Size = new System.Drawing.Size(200, 20);
            this.txtAppName.TabIndex = 58;
            // 
            // textBoxSparkConfigs
            // 
            this.textBoxSparkConfigs.AcceptsReturn = true;
            this.textBoxSparkConfigs.AcceptsTab = true;
            this.textBoxSparkConfigs.Location = new System.Drawing.Point(10, 69);
            this.textBoxSparkConfigs.Multiline = true;
            this.textBoxSparkConfigs.Name = "textBoxSparkConfigs";
            this.textBoxSparkConfigs.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.textBoxSparkConfigs.Size = new System.Drawing.Size(629, 299);
            this.textBoxSparkConfigs.TabIndex = 64;
            // 
            // lbSetMaster
            // 
            this.lbSetMaster.AutoSize = true;
            this.lbSetMaster.Location = new System.Drawing.Point(270, 25);
            this.lbSetMaster.Name = "lbSetMaster";
            this.lbSetMaster.Size = new System.Drawing.Size(55, 13);
            this.lbSetMaster.TabIndex = 59;
            this.lbSetMaster.Text = "SetMaster";
            // 
            // lbSparkConfigs
            // 
            this.lbSparkConfigs.AutoSize = true;
            this.lbSparkConfigs.Location = new System.Drawing.Point(5, 50);
            this.lbSparkConfigs.Name = "lbSparkConfigs";
            this.lbSparkConfigs.Size = new System.Drawing.Size(133, 13);
            this.lbSparkConfigs.TabIndex = 63;
            this.lbSparkConfigs.Text = "Spark Parameters (Config.)";
            // 
            // txtSetMaster
            // 
            this.txtSetMaster.Location = new System.Drawing.Point(330, 22);
            this.txtSetMaster.Name = "txtSetMaster";
            this.txtSetMaster.Size = new System.Drawing.Size(120, 20);
            this.txtSetMaster.TabIndex = 60;
            // 
            // btnSave
            // 
            this.btnSave.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.btnSave.Location = new System.Drawing.Point(523, 389);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(136, 48);
            this.btnSave.TabIndex = 67;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // SparkSettings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(671, 443);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "SparkSettings";
            this.Text = "SparkSettings";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lbAppName;
        private System.Windows.Forms.TextBox txtAppName;
        private System.Windows.Forms.TextBox textBoxSparkConfigs;
        private System.Windows.Forms.Label lbSetMaster;
        private System.Windows.Forms.Label lbSparkConfigs;
        private System.Windows.Forms.TextBox txtSetMaster;
        private System.Windows.Forms.Button btnSave;
    }
}