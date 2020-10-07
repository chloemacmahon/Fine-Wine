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

            FillGrapeIDs();
            RefreshOverview();
            ResetFields();

        }

        public void FillGrapeIDs()
        {
            cbIDs.Items.Clear();
            string[] IDs = control.getFieldStrings("Grape_ID", "GRAPE");
            foreach (string ID in IDs)
            {
                cbIDs.Items.Add(ID);
            }
            log("Grape ID's refreshed");
        }

        public void RefreshOverview()
        {
            lbGrapes.Items.Clear();
            string[] IDs = control.getFieldStrings("Grape_ID", "GRAPE");
            lbGrapes.Items.Add("ID\t\tName\t\tType\t\tDescription");
            lbGrapes.Items.Add("------------------------------------------------------------");
            foreach (string ID in IDs)
            {
                string record = ID + "\t";

                string grape_name = control.getFieldStringsWhere("Name", "GRAPE", "(Grape_ID='" + ID + "')")[0];
                string grape_type = control.getFieldStringsWhere("Type", "GRAPE", "(Grape_ID='" + ID + "')")[0];
                string grape_description = control.getFieldStringsWhere("Description", "GRAPE", "(Grape_ID='" + ID + "')")[0];

                record += grape_name + "\t\t" + grape_type + "\t\t" + grape_description;
                lbGrapes.Items.Add(record);
            }
        }

        public void SearchOverview(string search)
        {
            lbGrapes.Items.Clear();
            string[] IDs = control.getFieldStringsWhere("Grape_ID", "GRAPE", "(Grape_ID LIKE '%" + search + "%') OR (Name LIKE '%" + search + "%') OR (Type LIKE '%" + search + "%') OR (Description LIKE '%" + search + "%')");

            lbGrapes.Items.Add("Search results for: " + search);
            lbGrapes.Items.Add("------------------------------------------------------------");
            lbGrapes.Items.Add("ID\t\tName\t\tType\t\tDescription");
            lbGrapes.Items.Add("------------------------------------------------------------");
            foreach (string ID in IDs)
            {
                string record = ID + "\t";

                string grape_name = control.getFieldStringsWhere("Name", "GRAPE", "(Grape_ID='" + ID + "')")[0];
                string grape_type = control.getFieldStringsWhere("Type", "GRAPE", "(Grape_ID='" + ID + "')")[0];
                string grape_description = control.getFieldStringsWhere("Description", "GRAPE", "(Grape_ID='" + ID + "')")[0];

                record += grape_name + "\t\t" + grape_type + "\t\t" + grape_description;
                lbGrapes.Items.Add(record);
            }
        }

        private void cbMod_CheckedChanged(object sender, EventArgs e)
        {
            pnlID.Enabled = cbMod.Checked;
            btnUpdate.Enabled = cbMod.Checked;
        }

        private void tabManage_Click(object sender, EventArgs e)
        {

        }

        public void ResetFields()
        {
            cbMod.Checked = false;

            FillGrapeIDs();

            cbIDs.SelectedIndex = -1;
            cbIDs.Text = "";

            txtID.Text = "<GRAPE ID>";
            txtName.Clear();
            txtType.SelectedIndex = -1;
            txtType.Text = "";
            txtDescription.Clear();

            txtLog.Clear();
            log("Grape ID's refreshed");
            log("Fields reset");
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            ResetFields();
        }

        private void btnRefreshInfo_Click(object sender, EventArgs e)
        {

        }

        private void btnRefreshOverview_Click(object sender, EventArgs e)
        {
            RefreshOverview();
        }

        private void btnSearchOverview_Click(object sender, EventArgs e)
        {
            SearchOverview(txtSearch.Text);
        }

        private void btnRefreshIDs_Click(object sender, EventArgs e)
        {
            FillGrapeIDs();
        }

        private void cbIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIDs.SelectedIndex == -1)
            {
                return;
            }
            string id = cbIDs.SelectedItem.ToString();
            txtID.Text = id;
            txtName.Text = control.getFieldStringsWhere("Name", "GRAPE", "(Grape_ID='"+id+"')")[0];
            txtType.Text = control.getFieldStringsWhere("Type", "GRAPE", "(Grape_ID='"+id+"')")[0];
            txtDescription.Text = control.getFieldStringsWhere("Description", "GRAPE", "(Grape_ID='"+id+"')")[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int count = control.getRecordCountWhere("GRAPE", "(Name LIKE '%" + txtName.Text + "%')");
            if (txtName.Text.Length == 0 || txtType.Text.Length == 0 || txtDescription.Text.Length == 0)
            {
                messages.error("Not all field are filled.");
                log("Grape addition cancelled");
                return;
            }
            if (count > 0)
            {
                if (!messages.confirm("There are currently " + count.ToString() + " grapes with a name similar to '" + txtName.Text + "', do you wish to continue?"))
                {
                    log("Grape addition cancelled");
                    return;
                }
            }
            Insert_Add_Delete_Code.AddNewGrape(txtName.Text, txtType.Text, txtDescription.Text, connection_string);
            ResetFields();
            log("Grape addition completed");
        }

        public void log (string s)
        {
            txtLog.Text += "> " + s + "\n";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int count = control.getRecordCountWhere("GRAPE", "(Name LIKE '%" + txtID.Text + "%')");
            if (count == 0)
            {
                messages.error("There is no grape with the ID '"+txtID.Text+"'!");
                log("Update cancelled");
                return;
            }
            if (txtName.Text.Length == 0 || txtType.Text.Length == 0 || txtDescription.Text.Length == 0)
            {
                messages.error("Not all field are filled.");
                log("Update cancelled");
                return;
            }
            if (!messages.confirm("Are you sure you want to update the grape with the ID, '" + txtID.Text + "'?"))
            {
                log("Update cancelled");
                return;
            }
            Insert_Add_Delete_Code.UpdateEntireGrape(txtID.Text, txtName.Text, txtType.Text, txtDescription.Text, connection_string);
            log("Grape has been updated");
        }
    }
}
