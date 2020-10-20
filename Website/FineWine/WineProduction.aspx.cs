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
        static List<string> productionUpdate = new List<string>();

        public void displayRecords()
        {
            int indexInsert = productionInsert.Count;
            int indexUpdate = productionUpdate.Count;
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
        }

        //sql query to display all wine id's in ddlWines
        public void displayWines()
        {
            ddlWines.Items.Add("");
            connect.Open();
            string sqlSelect = "SELECT Wine_ID FROM WINE ORDER BY Wine_ID ASC";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlWines.Items.Add(reader.GetValue(0).ToString());
            }
            connect.Close();
        }

        //sql query to display all harvest id's in ddlHavest
        public void displayHarvest()
        {
            ddlHarvest.Items.Add("");
            connect.Open();
            string sqlSelect = "SELECT Harvest_ID FROM HARVEST ORDER BY Harvest_ID ASC";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlHarvest.Items.Add(reader.GetValue(0).ToString());
            }
            connect.Close(); ;
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

        public void displayProduction()
        {
            string sqlSelect = "SELECT * FROM WINE_PRODUCTION";
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            adapt = new SqlDataAdapter();
            ds = new DataSet();
            adapt.SelectCommand = command;
            adapt.Fill(ds, "WINE_PRODUCTION");
            gvWineProduction.DataSource = ds;
            gvWineProduction.DataBind();
            connect.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(maintain.connectDatabase());
            MultiView1.SetActiveView(SelectView);
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            lbSummaryWineProduction.Dispose();
            displayProduction();
            MultiView1.SetActiveView(Editview);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            gvWineProduction.Dispose();
            displayRecords();
            MultiView1.SetActiveView(Summary);
        }

        protected void gvWineProduction_SelectedIndexChanged(object sender, EventArgs e)
        {

            MultiView1.SetActiveView(Editview);
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
            ddlChanges.Items.Clear();
            ddlChanges.Visible = false;
            ddlField.Items.Clear();
            gvWineProduction.Dispose();
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex == 0)
            {
                displayHarvest();
                displayWines();
                RadioButtonList1.ClearSelection();
                MultiView1.SetActiveView(AddView);
            }
            else if(RadioButtonList1.SelectedIndex == 1)
            {
                RadioButtonList1.ClearSelection();
                displayProduction();
                MultiView1.SetActiveView(Editview);
            }
            else
            {
                RadioButtonList1.ClearSelection();
                displayRecords();
                MultiView1.SetActiveView(Summary);
            }
        }

        protected void btnGoEdit_Click(object sender, EventArgs e)
        {
            displayProduction();
            MultiView1.SetActiveView(Editview);
        }

        protected void btnSummaryGo_Click(object sender, EventArgs e)
        {
            displayRecords();
            MultiView1.SetActiveView(Summary);
        }

        protected void btnHarvest_Click(object sender, EventArgs e)
        {
            lbSummaryWineProduction.Dispose();
            MultiView1.SetActiveView(SelectView);
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            string sqlHarvest = "SELECT Estimated_Harvest FROM HARVEST WHERE Harvest_ID LIKE '" + ddlHarvest.Text + "'";
            int estimate = maintain.getEstimatedHarvest(sqlHarvest);
            string sqlInsert = "INSERT INTO WINE_PRODUCTION VALUES('" + ddlWines.Text + "', '" + ddlHarvest.Text + "', '" + estimate + "', 0, '" + txtMaturation.Text + "')";
            maintain.insertData(sqlInsert);
            string line = ddlWines.Text + "\t\t" + ddlHarvest.Text + "\t\t" + estimate + "\t\t0\t\t" + txtMaturation.Text;
            productionInsert.Add(line);
            string id = ddlWines.Text.Substring(0, 4) + ddlHarvest.Text.Substring(0, 4) + rand.Next(1000, 9999);
            int price = rand.Next(100, 9999);
            string sqlStock = "INSERT INTO STOCK VALUES('" + id + "', '" + ddlWines.Text + "', '" + DateTime.Today.ToShortDateString() + "', 15, 0, '" + price + "', '" + price*1.4 + "')";
            maintain.insertData(sqlStock);
            ddlHarvest.Items.Clear();
            ddlWines.Items.Clear();
            txtMaturation.Text = "";
            MultiView1.SetActiveView(SelectView);
        }
    }
}