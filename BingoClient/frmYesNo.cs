using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Linq;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace BingoClient
{
    public partial class frmYesNo : DevExpress.XtraEditors.XtraForm
    {
        public frmYesNo()
        {
            InitializeComponent();
        }

        private void frmYesNo_Load(object sender, EventArgs e)
        {
            DevExpress.LookAndFeel.UserLookAndFeel.Default.Style = DevExpress.LookAndFeel.LookAndFeelStyle.Skin;
            DevExpress.LookAndFeel.UserLookAndFeel.Default.SetSkinStyle("Office 2007 Green");
        }

        private void sbtnOk_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void sbtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}