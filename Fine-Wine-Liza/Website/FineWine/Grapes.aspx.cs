using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineWinesWeb;
using System.Data.SqlClient;
using System.Data;

namespace FineWine
{
    public partial class Grapes : System.Web.UI.Page
    {
        SQLMaintain maintain = new SQLMaintain();
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        DataSet ds;
        Random rand = new Random();
        static List<string> grapeInsert = new List<string>();
        static List<string> grapeDelete = new List<string>();
        static List<string> grapeUpdate = new List<string>();

        public void displayRecords()
        {
            int indexInsert = grapeInsert.Count;
            int indexUpdate = grapeUpdate.Count;
            int indexDelete = grapeDelete.Count;
            //display inserted records in summary listbox
            lbxGrapeSummary.Items.Add("The following items were inserted into the grape database:\n\n");
            lbxGrapeSummary.Items.Add("Grape_ID\t\tName\t\tGrape_Type\t\tDescription");
            lbxGrapeSummary.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexInsert; i++)
            {
                lbxGrapeSummary.Items.Add(grapeInsert[i]);
            }
            //display updated records in summary listbox
            lbxGrapeSummary.Items.Add("\nThe following grape items were updated:\n\n");
            lbxGrapeSummary.Items.Add("Grape_ID\t\tName\t\tGrape_Type\t\tDescription");
            lbxGrapeSummary.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexUpdate; i++)
            {
                lbxGrapeSummary.Items.Add(grapeUpdate[i]);
            }
            //display deleted records in summary listbox
            lbxGrapeSummary.Items.Add("\nThe following items were removed from the grape database:\n\n");
            lbxGrapeSummary.Items.Add("Grape_ID\t\tName\t\tGrape_Type\t\tDescription");
            lbxGrapeSummary.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexDelete; i++)
            {
                lbxGrapeSummary.Items.Add(grapeDelete[i]);
            }
        }

        public void displayUpdate()
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM GRAPE";
            command = new SqlCommand(sqlSelect, connect);
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(ds, "GRAPE");
            GridViewUpdate.DataSource = ds;
            GridViewUpdate.DataMember = "GRAPE";
            GridViewUpdate.DataBind();
            command.Dispose();
            connect.Close();
        }

        public void displayDelete()
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM GRAPE";
            command = new SqlCommand(sqlSelect, connect);
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(ds, "GRAPE");
            GridViewDelete.DataSource = ds;
            GridViewDelete.DataMember = "GRAPE";
            GridViewDelete.DataBind();
            command.Dispose();
            connect.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(maintain.connectDatabase());
            MultiView1.SetActiveView(View4);
  
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {//Add grape to database 
          try
          {
                //create id for grape: first 4 letters of name + random numbers
                string id = txtGrapeName.Text.Substring(0, 4) + rand.Next(1000, 9999);
                //create sql query for the insert
                string sqlInsert = "INSERT INTO Grape VALUES('" + id + "', '" + txtGrapeName.Text + "', '" + txtType.Text + "', '" + txtDescription.Text + "')";
                //create input for summary
                string line = id + "\t" + txtGrapeName.Text + "\t" + txtType.Text + "\t" + txtDescription.Text;
                //clear objects
                grapeInsert.Add(line);
                txtDescription.Text = "";
                txtGrapeName.Text = "";
                txtType.Text = "";
                //execute sql inser query for grapes
                maintain.insertData(sqlInsert);
                MultiView1.SetActiveView(View1);
            }
            catch
            {
                //lblError.Text = "A error occured please try again later";
            }  
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //create sql query for update
            string sqlUpdate = "UPDATE GRAPE SET " + ddlField.SelectedValue + " = '" + txtChange.Text + "' WHERE Grape_ID LIKE '" + GridViewUpdate.SelectedRow.Cells[1].Text + "'";
            string line = GridViewUpdate.SelectedRow.Cells[1].Text + "\t" + GridViewUpdate.SelectedRow.Cells[2].Text + "\t" + GridViewUpdate.SelectedRow.Cells[3].Text + "\t" + GridViewUpdate.SelectedRow.Cells[4].Text;
            grapeUpdate.Add(line); 
            maintain.updateData(sqlUpdate);
            ddlField.Text = "";
            txtChange.Text = "";
            MultiView1.SetActiveView(View4);
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(!(GridViewDelete.SelectedIndex < 0))
            {
                //retrieve primary key               
                string selectedPrimaryKey = GridViewDelete.SelectedRow.Cells[1].Text;
                string sqlCheck = "SELECT * FROM HARVEST WHERE Grape_ID = '" + selectedPrimaryKey + "'";
                string sqlCheck2 = "SELECT * FROM WINE WHERE Grape_ID = '" + selectedPrimaryKey + "'";
                if (maintain.checkForeignKey(sqlCheck) || maintain.checkForeignKey(sqlCheck2))
                {
                    Response.Write("<script>alert('Grape cannot be deleted because it is being used.');</script>");
                }
                else
                {
                    //create sql delete query
                    string sqlDelete = "DELETE FROM Grape WHERE Grape_ID = '" + selectedPrimaryKey + "'";
                    string line = selectedPrimaryKey + "\t" + GridViewDelete.SelectedRow.Cells[2].Text +
                        "\t" + GridViewDelete.SelectedRow.Cells[3].Text + "\t" + GridViewDelete.SelectedRow.Cells[4].Text;
                    grapeDelete.Add(line);
                    maintain.deleteData(sqlDelete);
                }
            }
            else
            {
                Response.Write("<script>alert('No record was chosen.');</script>");
                MultiView1.SetActiveView(View3);
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(radlistGrapeOptions.SelectedIndex == 0)
            {
                radlistGrapeOptions.ClearSelection();
                MultiView1.SetActiveView(View1);
            }
            else if (radlistGrapeOptions.SelectedIndex == 1)
            {
                displayUpdate();
                radlistGrapeOptions.ClearSelection();
                MultiView1.SetActiveView(View2); 
            }
            else if (radlistGrapeOptions.SelectedIndex == 2)
            {
                displayDelete();
                radlistGrapeOptions.ClearSelection();
                MultiView1.SetActiveView(View3);
            }
            else if(radlistGrapeOptions.SelectedIndex == 3)
            {
                radlistGrapeOptions.ClearSelection();
                displayRecords();
                MultiView1.SetActiveView(Summary);
            }
        }

        protected void btnMainSummary0_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }

        protected void GridViewUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View2);
        }

        protected void GridViewDelete_SelectedIndexChanged(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View3);
        }

        protected void btnMainSummary_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }
    }
}