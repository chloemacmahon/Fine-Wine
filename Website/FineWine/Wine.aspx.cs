using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using FineWinesWeb;

namespace FineWine
{
    public partial class Wine : System.Web.UI.Page
    {
        SQLMaintain maintain = new SQLMaintain();
        Random rand = new Random();
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        DataSet ds;
        static List<string> wineInsert = new List<string>();
        static List<string> wineDelete = new List<string>();
        static List<string> wineUpdate = new List<string>();
        string updateID1, updateID2;

        //sql query to display grapeIDs in ddlGrapeName
        public void displayGrapeName()
        {
            ddlGrapeName.Items.Add("");
            connect.Open();
            string sqlSelect = "SELECT Name FROM GRAPE ORDER BY Name ASC";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlGrapeName.Items.Add(reader.GetValue(0).ToString());
            }
            connect.Close();
        }

        public void displayRecords()
        {
            int indexInsert = wineInsert.Count;
            int indexUpdate = wineUpdate.Count;
            int indexDelete = wineDelete.Count;
            //display inserted records in summary listbox
            lbxWineSummary.Items.Add("The following items were inserted into the wine database:\n");
            lbxWineSummary.Items.Add("Wine_ID\tGrape_ID\tName\tWine_Type\tDescription");
            lbxWineSummary.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexInsert; i++)
            {
                lbxWineSummary.Items.Add(wineInsert[i]);
            }
            //display updated records in summary listbox
            lbxWineSummary.Items.Add("The following items were updated:\n");
            lbxWineSummary.Items.Add("Wine_ID\tGrape_ID\tName\tWine_Type\tDescription");
            lbxWineSummary.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexUpdate; i++)
            {
                lbxWineSummary.Items.Add(wineUpdate[i]);
            }
            //display deleted records in summary listbox
            lbxWineSummary.Items.Add("The following items were removed from the wine database:\n");
            lbxWineSummary.Items.Add("Wine_ID\tGrape_ID\tName\tWine_Type\tDescription");
            lbxWineSummary.Items.Add("-----------------------------------------------------------------------------------------------------------------------------------------------------------");
            for (int i = 0; i < indexDelete; i++)
            {
                lbxWineSummary.Items.Add(wineDelete[i]);
            }
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View4);
            connect = new SqlConnection(maintain.connectDatabase());
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (radlistWineOptions.SelectedIndex == 0)
            {
                displayGrapeName();
                radlistWineOptions.ClearSelection();
                MultiView1.SetActiveView(InsertView);
            }
            else if (radlistWineOptions.SelectedIndex == 1)
            {
                radlistWineOptions.ClearSelection();
                MultiView1.SetActiveView(View2);
                connect.Open();
                string sqlSelect = "SELECT * FROM WINE";
                command = new SqlCommand(sqlSelect, connect);
                ds = new DataSet();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = command;
                adapt.Fill(ds, "WINE");

                GridViewUpdate.DataSource = ds;
                GridViewUpdate.DataMember = "WINE";
                GridViewUpdate.DataBind();
            }
            else if (radlistWineOptions.SelectedIndex == 2)
            {
                radlistWineOptions.ClearSelection();
                MultiView1.SetActiveView(View3);
                connect.Open();
                string sqlSelect = "SELECT * FROM WINE";
                command = new SqlCommand(sqlSelect, connect);
                ds = new DataSet();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = command;
                adapt.Fill(ds, "WINE");
                GridViewDelete.DataSource = ds;
                GridViewDelete.DataMember = "WINE";
                GridViewDelete.DataBind();
            }
            else if(radlistWineOptions.SelectedIndex == 3)
            {
                radlistWineOptions.ClearSelection();
                displayRecords();
                MultiView1.SetActiveView(Summary);
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //get selected wineID from gridview
            updateID1 = GridViewUpdate.SelectedRow.Cells[1].Text;
            //get selected grapeID from gridview
            updateID2 = GridViewUpdate.SelectedRow.Cells[2].Text;
            //create sql query statement
            string sqlUpdate = "UPDATE WINE SET " + ddlField.SelectedValue + " = '" + txtChange.Text + "' WHERE Wine_ID LIKE '" + updateID1 + "' AND Grape_ID LIKE '" + updateID2 + "'";
            //create string to add to update list
            string line = updateID1 + "\t" + updateID2 + "\t" + GridViewUpdate.SelectedRow.Cells[3].Text + "\t" + GridViewUpdate.SelectedRow.Cells[4].Text + "\t" + GridViewUpdate.SelectedRow.Cells[5].Text;
            //execute update sql query
            maintain.updateData(sqlUpdate);
            //add line to update list
            wineUpdate.Add(line);
            GridViewUpdate.Dispose();
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            /*try
            {       */
            if (!(GridViewDelete.SelectedIndex < 0))
            {
                //retrieve primary key               
                string selectedPrimaryKey = GridViewDelete.SelectedRow.Cells[1].Text;
                string sqlCheck = "SELECT * FROM WINE_PRODUCTION WHERE Wine_ID = '" + selectedPrimaryKey + "'";
                string sqlCheck2 = "SELECT * FROM STOCK WHERE Wine_ID = '" + selectedPrimaryKey + "'";
                if (maintain.checkForeignKey(sqlCheck) || maintain.checkForeignKey(sqlCheck2))
                {
                    Response.Write("<script>alert('Wine cannot be deleted because it is being used.');</script>");
                }
                else
                {
                    //create sql delete query
                    string sqlDelete = "DELETE FROM WINE WHERE Wine_ID = '" + selectedPrimaryKey + "'";
                    string line = selectedPrimaryKey + "\t" + GridViewDelete.SelectedRow.Cells[2].Text + "\t" + GridViewDelete.SelectedRow.Cells[3].Text + 
                                "\t" + GridViewDelete.SelectedRow.Cells[4].Text + "\t" + GridViewDelete.SelectedRow.Cells[5].Text;
                    wineDelete.Add(line);
                    maintain.deleteData(sqlDelete);
                }
                GridViewDelete.Dispose();
            }
            else
            {
                Response.Write("<script>alert('No record was chosen.');</script>");
                MultiView1.SetActiveView(View3);
            }
            /*  }
              catch
              {

              }     */
        }

        protected void btnInsert_Click1(object sender, EventArgs e)
        {
           /* try
            {           */
                //create id for wine: first 4 letters of wine name + 4 random numbers
                string id = txtInsertName.Text.Substring(0, 4) + rand.Next(1000, 9999);
            //retrieve the grapeID by using the SQLMaintain method
            string sqlSelect = "SELECT Grape_ID FROM GRAPE WHERE Name LIKE '" + ddlGrapeName.Text + "'";
            string grapeID = maintain.getID(sqlSelect);
                //create sql insert query
                string sqlInsert = "INSERT INTO WINE VALUES('" + id + "', '" + grapeID + "', '" + txtInsertName.Text + "', '" + txtInsertType.Text + "', '" + txtInsertDescription.Text + "')";
                //create insert string to add to List
                string line = id + "\t" + grapeID + "\t" + txtInsertName.Text + "\t" + txtInsertType.Text + "\t" + txtInsertDescription.Text;
                wineInsert.Add(line);
                //use insert method to add wine to database
                maintain.insertData(sqlInsert);
            txtInsertDescription.Text = "";
            txtInsertName.Text = "";
            txtInsertType.Text = "";
            MultiView1.SetActiveView(InsertView);
          /*  }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.ToString() + "');</script>");
            }       */
        }

        protected void btnMainUpdate_Click(object sender, EventArgs e)
        {
            GridViewUpdate.Dispose();
            GridViewDelete.Dispose();
            MultiView1.SetActiveView(View4);
        }

        protected void btnMainDelete_Click(object sender, EventArgs e)
        {
            displayRecords();
            MultiView1.SetActiveView(Summary);
        }

        protected void btnInsertSummary_Click(object sender, EventArgs e)
        {
            displayRecords(); 
            MultiView1.SetActiveView(Summary);
        }

        protected void btnMainSummary_Click(object sender, EventArgs e)
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

        protected void btnUpdateSummary_Click(object sender, EventArgs e)
        {
            displayRecords();
            MultiView1.SetActiveView(Summary);
        }
    }            
}