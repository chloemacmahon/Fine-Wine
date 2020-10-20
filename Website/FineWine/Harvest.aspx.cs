using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace FineWine
{
    public partial class Harvest : System.Web.UI.Page
    {

        SqlConnection connect;
        SqlCommand command;
        SqlDataAdapter adapt;
        DataSet ds;
        SQLMaintain maintain = new SQLMaintain();
        DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
        Random rand = new Random();
        static List<string> harvestInsert = new List<string>();
        static List<string> harvestDelete = new List<string>();
        static List<string> harvestUpdate = new List<string>();

        public void displayRecords()
        {
            int indexInsert = harvestInsert.Count;
            int indexUpdate = harvestUpdate.Count;
            int indexDelete = harvestDelete.Count;
            //display inserted records in summary listbox
            lbHarvests.Items.Add("The following items were inserted into the harvest database:\n");
            lbHarvests.Items.Add("HarvestID\tGrape_ID\tAmount_Planted\tDate_Planted\tEstimated_Harvest\tActual_Harvest");
            lbHarvests.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexInsert; i++)
            {
                lbHarvests.Items.Add(harvestInsert[i]);
            }
            //display updated records in summary listbox
            lbHarvests.Items.Add("\nThe following grape items were updated:\n");
            lbHarvests.Items.Add("HarvestID\tGrape_ID\tAmount_Planted\tDate_Planted\tEstimated_Harvest\tActual_Harvest");
            lbHarvests.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexUpdate; i++)
            {
                lbHarvests.Items.Add(harvestUpdate[i]);
            }
            //display deleted records in summary listbox
            lbHarvests.Items.Add("\nThe following items were removed from the harvest database:\n");
            lbHarvests.Items.Add("HarvestID\tGrape_ID\tAmount_Planted\tDate_Planted\tEstimated_Harvest\tActual_Harvest");
            lbHarvests.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexDelete; i++)
            {
                lbHarvests.Items.Add(harvestDelete[i]);
            }
        }

        //sql query to display grape names in ddlGrape
        public void displayGrapes()
        {
            ddlGrape.Items.Add("");
            connect.Open();
            string sqlSelect = "SELECT Name FROM GRAPE ORDER BY Name ASC";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlGrape.Items.Add(reader.GetValue(0).ToString());
            }
            connect.Close();
        }

        public void display(string sqlSelect)
        {
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(ds);
            gvHarvests.DataSource = ds;
            gvHarvests.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(maintain.connectDatabase());
            displayGrapes();
            MultiView1.SetActiveView(Addview);

        }

        protected void btnAddView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Addview);
        }

        protected void btnDisplayAll_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Review);
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            string sqlSelect = "SELECT * FROM HARVEST";
            display(sqlSelect);
            MultiView1.SetActiveView(Editview);
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //create sql query for update
            string sqlUpdate = "UPDATE HARVEST SET " + ddlField.SelectedValue + " = '" + txtChange.Text + "' WHERE Grape_ID LIKE '" + gvHarvests.SelectedRow.Cells[1].Text + "'";
            string line = gvHarvests.SelectedRow.Cells[1].Text + "\t" + gvHarvests.SelectedRow.Cells[2].Text + "\t" + gvHarvests.SelectedRow.Cells[3].Text + "\t" + gvHarvests.SelectedRow.Cells[4].Text + 
                "\t" + gvHarvests.SelectedRow.Cells[5].Text + "\t" + gvHarvests.SelectedRow.Cells[6].Text;
            harvestUpdate.Add(line);
            maintain.updateData(sqlUpdate);
            txtChange.Text = "";
            ddlField.Text = "";
            //MultiView1.SetActiveView(Review);
        }

        protected void btnAdd0_Click(object sender, EventArgs e)
        {
            //create Harvest ID: first 4 letters of grape name + year + 4 random numbers
            string id = ddlGrape.Text.Substring(0, 4) + date.Year + rand.Next(1000, 9999);
            int estimate = (int)(int.Parse(txtAmountPlanted.Text) * 1.5);
            string sqlSelect = "SELECT Grape_ID FROM GRAPE WHERE Name LIKE '" + ddlGrape.Text + "'";
            string sqlInert = "INSERT INTO HARVEST VALUES('"+ id + "', '" + maintain.getID(sqlSelect) + "', '" + int.Parse(txtAmountPlanted.Text) + "', '" + date.ToShortDateString() + "', " + estimate + "', 0)";
            string line = id + "\t" + maintain.getID(sqlSelect) + "\t" + int.Parse(txtAmountPlanted.Text) + "\t" + date.ToShortDateString() + "\t" + estimate;
            harvestInsert.Add(line);
            maintain.insertData(sqlInert);
            txtAmountPlanted.Text = "";
            ddlGrape.Text = "";
        }

        protected void btnSUmmary1_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Review);
        }

        protected void btnEdit_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Editview);
        }

        protected void btnSummary0_Click(object sender, EventArgs e)
        {
            displayRecords();
            MultiView1.SetActiveView(Review);
        }
    }
}