namespace BingoClient
{
    partial class frmYesNo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmYesNo));
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.sbtnOk = new DevExpress.XtraEditors.SimpleButton();
            this.sbtnCancel = new DevExpress.XtraEditors.SimpleButton();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 16F);
            this.labelControl1.Location = new System.Drawing.Point(81, 15);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(393, 25);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Открыть сформировавшийся PDF файл?";
            // 
            // sbtnOk
            // 
            this.sbtnOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.sbtnOk.Image = ((System.Drawing.Image)(resources.GetObject("sbtnOk.Image")));
            this.sbtnOk.Location = new System.Drawing.Point(162, 62);
            this.sbtnOk.Name = "sbtnOk";
            this.sbtnOk.Size = new System.Drawing.Size(101, 40);
            this.sbtnOk.TabIndex = 18;
            this.sbtnOk.Text = "ДА";
            this.sbtnOk.Click += new System.EventHandler(this.sbtnOk_Click);
            // 
            // sbtnCancel
            // 
            this.sbtnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.sbtnCancel.Image = ((System.Drawing.Image)(resources.GetObject("sbtnCancel.Image")));
            this.sbtnCancel.Location = new System.Drawing.Point(280, 62);
            this.sbtnCancel.Name = "sbtnCancel";
            this.sbtnCancel.Size = new System.Drawing.Size(101, 40);
            this.sbtnCancel.TabIndex = 19;
            this.sbtnCancel.Text = "НЕТ";
            this.sbtnCancel.Click += new System.EventHandler(this.sbtnCancel_Click);
            // 
            // frmYesNo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(543, 117);
            this.Controls.Add(this.sbtnCancel);
            this.Controls.Add(this.sbtnOk);
            this.Controls.Add(this.labelControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.LookAndFeel.SkinName = "Office 2007 Green";
            this.MaximizeBox = false;
            this.Name = "frmYesNo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "2pdf Bingo Client";
            this.Load += new System.EventHandler(this.frmYesNo_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.SimpleButton sbtnOk;
        private DevExpress.XtraEditors.SimpleButton sbtnCancel;
    }
}