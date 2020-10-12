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
    public partial class Wines_Form : Form
    {
        public sqlControl control;
        public string connection_string = "";

        public Wines_Form()
        {
            InitializeComponent();
        }

        private void Wines_Form_Load(object sender, EventArgs e)
        {

            control = new sqlControl();
            control.connectDatabaseStr(connection_string);

            FillWineIDs();
            RefreshOverview();
            ResetFields();

        }

        public void FillWineIDs()
        {
            cbIDs.Items.Clear();
            string[] IDs = control.getFieldStrings("Wine_ID", "WINE");
            foreach (string ID in IDs)
            {
                cbIDs.Items.Add(ID);
            }
            txtGrapeID.Items.Clear();
            IDs = control.getFieldStrings("Wine_ID", "WINE");
            foreach (string ID in IDs)
            {
                txtGrapeID.Items.Add(ID);
            }
            log("Wine ID's refreshed");
        }

        public void RefreshOverview()
        {
            lbWines.Items.Clear();
            string[] IDs = control.getFieldStrings("Wine_ID", "WINE");
            lbWines.Items.Add("ID\t\tGrape ID\t\tName\t\tType\t\tDescription");
            lbWines.Items.Add("------------------------------------------------------------");
            foreach (string ID in IDs)
            {
                string record = ID + "\t";

                string grape_id = control.getFieldStringsWhere("Grape_ID", "WINE", "(Wine_ID='" + ID + "')")[0];
                string grape_name = control.getFieldStringsWhere("Name", "WINE", "(Wine_ID='" + ID + "')")[0];
                string grape_type = control.getFieldStringsWhere("Type", "WINE", "(Wine_ID='" + ID + "')")[0];
                string grape_description = control.getFieldStringsWhere("Description", "WINE", "(Wine_ID='" + ID + "')")[0];

                record += grape_id + "\t\t" + grape_name + "\t\t" + grape_type + "\t\t" + grape_description;
                lbWines.Items.Add(record);
            }
        }

        public void SearchOverview(string search)
        {
            lbWines.Items.Clear();
            string[] IDs = control.getFieldStringsWhere("Wine_ID", "WINE", "(Wine_ID LIKE '%" + search + "%') OR (Grape_ID LIKE '%" + search + "%') OR (Name LIKE '%" + search + "%') OR (Type LIKE '%" + search + "%') OR (Description LIKE '%" + search + "%')");

            lbWines.Items.Add("Search results for: " + search);
            lbWines.Items.Add("------------------------------------------------------------");
            lbWines.Items.Add("ID\t\tGrape ID\t\tName\t\tType\t\tDescription");
            lbWines.Items.Add("------------------------------------------------------------");
            foreach (string ID in IDs)
            {
                string record = ID + "\t";

                string grape_id = control.getFieldStringsWhere("Grape_ID", "WINE", "(Wine_ID='" + ID + "')")[0];
                string wine_name = control.getFieldStringsWhere("Name", "WINE", "(Wine_ID='" + ID + "')")[0];
                string wine__type = control.getFieldStringsWhere("Type", "WINE", "(Wine_ID='" + ID + "')")[0];
                string wine_description = control.getFieldStringsWhere("Description", "WINE", "(Wine_ID='" + ID + "')")[0];

                record += grape_id + "\t\t" + wine_name + "\t\t" + wine__type + "\t\t" + wine_description;
                lbWines.Items.Add(record);
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

            FillWineIDs();

            cbIDs.SelectedIndex = -1;
            cbIDs.Text = "";

            txtID.Text = "<WINE ID>";
            txtGrapeID.SelectedIndex = -1;
            txtGrapeID.Text = "";
            txtName.Clear();
            txtType.SelectedIndex = -1;
            txtType.Text = "";
            txtDescription.Clear();

            txtLog.Clear();
            log("Wine ID's refreshed");
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
            FillWineIDs();
        }

        private void cbIDs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbIDs.SelectedIndex == -1)
            {
                return;
            }
            string id = cbIDs.SelectedItem.ToString();
            txtID.Text = id;
            txtName.Text = control.getFieldStringsWhere("Name", "WINE", "(Wine_ID='" + id + "')")[0];
            txtType.Text = control.getFieldStringsWhere("Type", "WINE", "(Wine_ID='" + id + "')")[0];
            txtDescription.Text = control.getFieldStringsWhere("Description", "WINE", "(Wine_ID='" + id + "')")[0];
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int count = control.getRecordCountWhere("WINE", "(Name LIKE '%" + txtName.Text + "%')");
            if (txtName.Text.Length == 0 || txtType.Text.Length == 0 || txtDescription.Text.Length == 0)
            {
                messages.error("Not all fields are filled.");
                log("Wine addition cancelled");
                return;
            }
            if (count > 0)
            {
                if (!messages.confirm("There are currently " + count.ToString() + " wines with a name similar to '" + txtName.Text + "', do you wish to continue?"))
                {
                    log("Wine addition cancelled");
                    return;
                }
            }
            count = control.getRecordCountWhere("GRAPE", "(Grape_ID='" + txtGrapeID.Text + "')");
            if (count == 0)
            {
                messages.error("There is no grape with the ID, '"+txtGrapeID.Text+"'!");
                log("Wine addition cancelled");
                return;
            }
            Insert_Add_Delete_Code.AddNewWine(txtGrapeID.Text, txtName.Text, txtType.Text, txtDescription.Text, connection_string);
            ResetFields();
            log("Wine addition completed");
        }

        public void log(string s)
        {
            txtLog.Text += "> " + s + "\n";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            int count = control.getRecordCountWhere("WINE", "(Name LIKE '%" + txtID.Text + "%')");
            if (count == 0)
            {
                messages.error("There is no wine with the ID '" + txtID.Text + "'!");
                log("Update cancelled");
                return;
            }
            count = control.getRecordCountWhere("GRAPE", "(Grape_ID='" + txtGrapeID.Text + "')");
            if (count == 0)
            {
                messages.error("There is no grape with the ID, '" + txtGrapeID.Text + "'!");
                log("Update cancelled");
                return;
            }
            if (txtGrapeID.Text.Length == 0 || txtName.Text.Length == 0 || txtType.Text.Length == 0 || txtDescription.Text.Length == 0)
            {
                messages.error("Not all fields are filled.");
                log("Update cancelled");
                return;
            }
            if (!messages.confirm("Are you sure you want to update the wine with the ID, '" + txtID.Text + "'?"))
            {
                log("Update cancelled");
                return;
            }
            Insert_Add_Delete_Code.UpdateEntireWine(txtID.Text, txtGrapeID.Text, txtName.Text, txtType.Text, txtDescription.Text, connection_string);
            log("Wine has been updated");
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            int count = control.getRecordCountWhere("WINE", "(Name LIKE '%" + cbIDs.Text + "%')");
            if (count == 0)
            {
                messages.error("There is no wine with the ID '" + cbIDs.Text + "'!");
                log("Deletion cancelled");
                return;
            }
            Insert_Add_Delete_Code.DeleteWine(cbIDs.Text, connection_string);
            log("Wine has been deleted");
        }
    }
}
