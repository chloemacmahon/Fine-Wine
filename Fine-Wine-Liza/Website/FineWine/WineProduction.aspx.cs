using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;

namespace FineWine
{
    public partial class WineProduction : System.Web.UI.Page
    {

        SQLMaintain maintain = new SQLMaintain();
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        DataSet ds;
        Random rand = new Random();
        static List<string> productionInsert = new List<string>();
        static List<string> productionDelete = new List<string>();
        static List<string> productionUpdate = new List<string>();

        public void displayRecords()
        {
            int indexInsert = productionInsert.Count;
            int indexUpdate = productionUpdate.Count;
            int indexDelete = productionDelete.Count;
            //display inserted records in summary listbox
            lbSummaryWineProduction.Items.Add("The following items were added to the wine production database:\n\n");
            lbSummaryWineProduction.Items.Add("Grape_ID\t\tName\t\tGrape_Type\t\tDescription");
            lbSummaryWineProduction.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexInsert; i++)
            {
                lbSummaryWineProduction.Items.Add(productionInsert[i]);
            }
            //display updated records in summary listbox
            lbSummaryWineProduction.Items.Add("\nThe following grape items were updated:\n\n");
            lbSummaryWineProduction.Items.Add("Grape_ID\t\tName\t\tGrape_Type\t\tDescription");
            lbSummaryWineProduction.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexUpdate; i++)
            {
                lbSummaryWineProduction.Items.Add(productionUpdate[i]);
            }
            //display deleted records in summary listbox
            lbSummaryWineProduction.Items.Add("\nThe following items were removed from the grape database:\n\n");
            lbSummaryWineProduction.Items.Add("Grape_ID\t\tName\t\tGrape_Type\t\tDescription");
            lbSummaryWineProduction.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexDelete; i++)
            {
                lbSummaryWineProduction.Items.Add(productionDelete[i]);
            }
        }

        //sql query to display selected ids in ddlChanges
        public void displaySelect(string sqlSelect)
        {
            ddlChanges.Items.Add("");
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlChanges.Items.Add(reader.GetValue(0).ToString());
            }
            connect.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(maintain.connectDatabase());
            MultiView1.SetActiveView(SelectView);
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Editview);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Summary);
        }

        protected void gvWineProduction_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnDisplayWineProd_Click(object sender, EventArgs e)
        {

        }

        protected void ddlField_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(ddlField.SelectedIndex == 3)
            {
                txtWineProduction.Visible = true;
            }
            else
            {
                ddlChanges.Visible = true;
                string sqlSelect = "";
                if (ddlField.SelectedIndex == 1)
                {
                    sqlSelect = "SELECT Wine_ID FROM WINE ORDER BY Wine_ID ASC";
                }
                else
                {
                    sqlSelect = "SELECT Harvest_ID FROM HARVEST ORDER BY Harvest_ID ASC";
                }
                displaySelect(sqlSelect);
            }
            MultiView1.SetActiveView(Editview);
        }

        protected void btnEdit1_Click(object sender, EventArgs e)
        {
            string changes = "";
            if (txtWineProduction.Visible)
            {
                changes = txtWineProduction.Text;
            }
            else
            {
                changes = ddlChanges.Text;
            }
            string sqlUpdate = "UPDATE WINE_PRODUCTION SET " + ddlField.SelectedValue + " = '" + changes + "' WHERE Wine_ID LIKE '" + gvWineProduction.SelectedRow.Cells[1].Text + "' AND Harvest_ID LIKE '" + gvWineProduction.SelectedRow.Cells[2].Text + "'";
            string line = gvWineProduction.SelectedRow.Cells[1].Text + "\t" + gvWineProduction.SelectedRow.Cells[2].Text + "\t" + gvWineProduction.SelectedRow.Cells[3].Text + "\t" + gvWineProduction.SelectedRow.Cells[4].Text +
                "\t" + gvWineProduction.SelectedRow.Cells[5].Text;
            productionUpdate.Add(line);
            maintain.updateData(sqlUpdate);
            txtWineProduction.Text = "";
            txtWineProduction.Visible = false;
            ddlChanges.Text = "";
            ddlChanges.Visible = false;
            ddlField.Text = "";
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex == 0)
            {
                MultiView1.SetActiveView(AddView);
            }
            else if(RadioButtonList1.SelectedIndex == 1)
            {
                MultiView1.SetActiveView(Editview);
            }
            else
            {
                MultiView1.SetActiveView(Summary);
            }
        }

        protected void btnGoEdit_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Editview);
        }

        protected void btnSummaryGo_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Summary);
        }

        protected void btnHarvest_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(SelectView);
        }
    }
}