namespace BingoClient
{
    partial class frmMain
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

        #region Windows Form Designer GenerateАd code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.sbtnRun = new DevExpress.XtraEditors.SimpleButton();
            this.bwCommon = new System.ComponentModel.BackgroundWorker();
            this.labelControl6 = new DevExpress.XtraEditors.LabelControl();
            this.meLog = new DevExpress.XtraEditors.MemoEdit();
            this.sbtnClose = new DevExpress.XtraEditors.SimpleButton();
            this.labelControl10 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl11 = new DevExpress.XtraEditors.LabelControl();
            this.teUserDirectory = new DevExpress.XtraEditors.TextEdit();
            this.teShareDirectory = new DevExpress.XtraEditors.TextEdit();
            this.sbtnSelectShareDirectory = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnSelectUserDirectory = new DevExpress.XtraEditors.SimpleButton();
            this.fbdCommon = new System.Windows.Forms.FolderBrowserDialog();
            this.teUrl = new DevExpress.XtraEditors.TextEdit();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            ((System.ComponentModel.ISupportInitialize)(this.meLog.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserDirectory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teShareDirectory.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUrl.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // sbtnRun
            // 
            this.sbtnRun.Image = ((System.Drawing.Image)(resources.GetObject("sbtnRun.Image")));
            this.sbtnRun.Location = new System.Drawing.Point(525, 372);
            this.sbtnRun.Name = "sbtnRun";
            this.sbtnRun.Size = new System.Drawing.Size(151, 41);
            this.sbtnRun.TabIndex = 17;
            this.sbtnRun.Text = "СТАРТ";
            this.sbtnRun.Click += new System.EventHandler(this.sbtnRun_Click);
            // 
            // bwCommon
            // 
            this.bwCommon.WorkerReportsProgress = true;
            this.bwCommon.WorkerSupportsCancellation = true;
            this.bwCommon.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bwCommon_DoWork);
            this.bwCommon.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.bwCommon_ProgressChanged);
            this.bwCommon.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.bwCommon_RunWorkerCompleted);
            // 
            // labelControl6
            // 
            this.labelControl6.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl6.Location = new System.Drawing.Point(20, 132);
            this.labelControl6.Name = "labelControl6";
            this.labelControl6.Size = new System.Drawing.Size(155, 16);
            this.labelControl6.TabIndex = 23;
            this.labelControl6.Text = "Ход выполнения задания:";
            // 
            // meLog
            // 
            this.meLog.Location = new System.Drawing.Point(20, 154);
            this.meLog.Name = "meLog";
            this.meLog.Size = new System.Drawing.Size(813, 207);
            this.meLog.TabIndex = 16;
            this.meLog.EditValueChanged += new System.EventHandler(this.meLog_EditValueChanged);
            // 
            // sbtnClose
            // 
            this.sbtnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnClose.Image = ((System.Drawing.Image)(resources.GetObject("sbtnClose.Image")));
            this.sbtnClose.Location = new System.Drawing.Point(682, 372);
            this.sbtnClose.Name = "sbtnClose";
            this.sbtnClose.Size = new System.Drawing.Size(151, 41);
            this.sbtnClose.TabIndex = 19;
            this.sbtnClose.Text = "ЗАКРЫТЬ";
            this.sbtnClose.Click += new System.EventHandler(this.sbtnClose_Click);
            // 
            // labelControl10
            // 
            this.labelControl10.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl10.Location = new System.Drawing.Point(24, 26);
            this.labelControl10.Name = "labelControl10";
            this.labelControl10.Size = new System.Drawing.Size(260, 16);
            this.labelControl10.TabIndex = 51;
            this.labelControl10.Text = "Глобальная общая директория на сервере:";
            // 
            // labelControl11
            // 
            this.labelControl11.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl11.Location = new System.Drawing.Point(149, 59);
            this.labelControl11.Name = "labelControl11";
            this.labelControl11.Size = new System.Drawing.Size(135, 16);
            this.labelControl11.TabIndex = 53;
            this.labelControl11.Text = "Файлы для обработки:";
            // 
            // teUserDirectory
            // 
            this.teUserDirectory.Location = new System.Drawing.Point(286, 56);
            this.teUserDirectory.Name = "teUserDirectory";
            this.teUserDirectory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teUserDirectory.Properties.Appearance.Options.UseFont = true;
            this.teUserDirectory.Size = new System.Drawing.Size(521, 22);
            this.teUserDirectory.TabIndex = 7;
            // 
            // teShareDirectory
            // 
            this.teShareDirectory.Location = new System.Drawing.Point(286, 23);
            this.teShareDirectory.Name = "teShareDirectory";
            this.teShareDirectory.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teShareDirectory.Properties.Appearance.Options.UseFont = true;
            this.teShareDirectory.Size = new System.Drawing.Size(521, 22);
            this.teShareDirectory.TabIndex = 5;
            // 
            // sbtnSelectShareDirectory
            // 
            this.sbtnSelectShareDirectory.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbtnSelectShareDirectory.Appearance.Options.UseFont = true;
            this.sbtnSelectShareDirectory.Location = new System.Drawing.Point(810, 22);
            this.sbtnSelectShareDirectory.Name = "sbtnSelectShareDirectory";
            this.sbtnSelectShareDirectory.Size = new System.Drawing.Size(23, 23);
            this.sbtnSelectShareDirectory.TabIndex = 6;
            this.sbtnSelectShareDirectory.Text = "...";
            this.sbtnSelectShareDirectory.Click += new System.EventHandler(this.sbtnSelectTemplateCallbackFile_Click);
            // 
            // sbtnSelectUserDirectory
            // 
            this.sbtnSelectUserDirectory.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.sbtnSelectUserDirectory.Appearance.Options.UseFont = true;
            this.sbtnSelectUserDirectory.Location = new System.Drawing.Point(810, 55);
            this.sbtnSelectUserDirectory.Name = "sbtnSelectUserDirectory";
            this.sbtnSelectUserDirectory.Size = new System.Drawing.Size(23, 23);
            this.sbtnSelectUserDirectory.TabIndex = 8;
            this.sbtnSelectUserDirectory.Text = "...";
            this.sbtnSelectUserDirectory.Click += new System.EventHandler(this.sbtnSelectTemplateOrderFile_Click);
            // 
            // teUrl
            // 
            this.teUrl.Location = new System.Drawing.Point(286, 89);
            this.teUrl.Name = "teUrl";
            this.teUrl.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.teUrl.Properties.Appearance.Options.UseFont = true;
            this.teUrl.Size = new System.Drawing.Size(521, 22);
            this.teUrl.TabIndex = 54;
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 10F);
            this.labelControl1.Location = new System.Drawing.Point(196, 92);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(88, 16);
            this.labelControl1.TabIndex = 55;
            this.labelControl1.Text = "URL адрес API:";
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.sbtnClose;
            this.ClientSize = new System.Drawing.Size(853, 434);
            this.Controls.Add(this.teUrl);
            this.Controls.Add(this.labelControl1);
            this.Controls.Add(this.sbtnSelectUserDirectory);
            this.Controls.Add(this.sbtnSelectShareDirectory);
            this.Controls.Add(this.teUserDirectory);
            this.Controls.Add(this.teShareDirectory);
            this.Controls.Add(this.labelControl11);
            this.Controls.Add(this.labelControl10);
            this.Controls.Add(this.sbtnClose);
            this.Controls.Add(this.labelControl6);
            this.Controls.Add(this.meLog);
            this.Controls.Add(this.sbtnRun);
            this.Cursor = System.Windows.Forms.Cursors.Default;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2pdf Bingo Client";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.meLog.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUserDirectory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teShareDirectory.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.teUrl.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton sbtnRun;
        private System.ComponentModel.BackgroundWorker bwCommon;
        private DevExpress.XtraEditors.LabelControl labelControl6;
        private DevExpress.XtraEditors.MemoEdit meLog;
        private DevExpress.XtraEditors.SimpleButton sbtnClose;
        private DevExpress.XtraEditors.LabelControl labelControl10;
        private DevExpress.XtraEditors.LabelControl labelControl11;
        private DevExpress.XtraEditors.TextEdit teUserDirectory;
        private DevExpress.XtraEditors.TextEdit teShareDirectory;
        private DevExpress.XtraEditors.SimpleButton sbtnSelectShareDirectory;
        private DevExpress.XtraEditors.SimpleButton sbtnSelectUserDirectory;
        private System.Windows.Forms.FolderBrowserDialog fbdCommon;
        private DevExpress.XtraEditors.TextEdit teUrl;
        private DevExpress.XtraEditors.LabelControl labelControl1;
    }
}

