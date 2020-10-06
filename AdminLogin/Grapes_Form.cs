using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FineWineUtil;

namespace AdminLogin
{
    public partial class Grapes_Form : Form
    {

        public sqlControl control;
        public string connection_string = "";

        public Grapes_Form()
        {
            InitializeComponent();
        }

        private void Grapes_Form_Load(object sender, EventArgs e)
        {
            control = new sqlControl();
            control.connectDatabaseStr(connection_string);
        }

        private void cbMod_CheckedChanged(object sender, EventArgs e)
        {
            pnlID.Enabled = cbMod.Checked;
        }

        private void tabManage_Click(object sender, EventArgs e)
        {

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            cbMod.Checked = false;

            cbIDs.SelectedIndex = -1;
            cbIDs.Text = "";

            txtID.Text = "<GRAPE ID>";
            txtName.Clear();
            txtType.SelectedIndex = -1;
            txtType.Text = "";
            txtDescription.Clear();

            txtLog.Clear();
        }

        private void btnRefreshInfo_Click(object sender, EventArgs e)
        {

        }
    }
}
