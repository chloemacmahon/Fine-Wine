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
        List<string> wineInsert = new List<string>();
        List<string> wineDelete = new List<string>();
        List<string> wineUpdate = new List<string>();
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


        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View4);
            connect = new SqlConnection(maintain.connectDatabase());
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (radlistGrapeOptions.SelectedIndex == 0)
            {
                displayGrapeName();
                MultiView1.SetActiveView(InsertView);
            }
            else if (radlistGrapeOptions.SelectedIndex == 1)
            {
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
            else if (radlistGrapeOptions.SelectedIndex == 2)
            {
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
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            //get selected wineID from gridview
            updateID1 = GridViewUpdate.SelectedRow.Cells[1].Text;
            //get selected grapeID from gridview
            updateID2 = GridViewUpdate.SelectedRow.Cells[2].Text;
            //create sql query statement
            string sqlUpdate = "UPDATE WINE SET Name = '" + txtGrapeName0.Text + "', Wine_Type = '" + txtType0.Text + "', Description = '" + txtDescription0.Text +
                               "' WHERE Wine_ID = '" + updateID1 + "' AND '" + updateID2 + "'";
            //create string to add to update list
            string line = updateID1 + "\t" + updateID2 + "\t" + txtGrapeName0.Text + "\t" + txtType0.Text + "\t" + txtDescription0.Text;
            //execute update sql query
            maintain.updateData(sqlUpdate);
            //add line to update list
            wineUpdate.Add(line);
            //ask user if they want to update another wine file
            Response.Write("<script>alert('The wine was updated.');</script>");
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                //create a sql query statement
                string sqlDelete = "DELETE FROM WINE WHERE Wine_ID LIKE '" + GridViewDelete.SelectedRow.Cells[1].Text + "' AND Grape_ID LIKE '" + GridViewDelete.SelectedRow.Cells[2].Text + "'";
                string line = GridViewDelete.SelectedRow.Cells[1].Text + "\t" + GridViewDelete.SelectedRow.Cells[2].Text + "\t" +
                              GridViewDelete.SelectedRow.Cells[3].Text + "\t" + GridViewDelete.SelectedRow.Cells[4].Text + "\t" + GridViewDelete.SelectedRow.Cells[5].Text;
                wineDelete.Add(line);
                maintain.deleteData(sqlDelete);
                Response.Write("<script>alert('Wine was successfully deleted.');</script>");
                
                /*string[] index = new string[2];
                index[0] = GridViewDelete.Rows[GridViewDelete.SelectedIndex].Cells[0].ToString();
                objMain.deleteStock("WINE", index);  */
            }
            catch
            {

            }
        }

        protected void btnInsert_Click1(object sender, EventArgs e)
        {
           /* try
            {           */
                //create id for wine: first 4 letters of wine name + 4 random letters/numbers
                string id = txtInsertName.Text.Substring(0, 4) + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a');
                //retrieve the grapeID by using the SQLMaintain method
                string grapeID = maintain.getGrapeID(ddlGrapeName.Text);
                //create sql insert query
                string sqlInsert = "INSERT INTO WINE VALUES('" + id + "', '" + grapeID + "', '" + txtInsertName.Text + "', '" + txtInsertType.Text + "', '" + txtInsertDescription.Text + "')";
                //create insert string to add to List
                string line = id + "\t" + grapeID + "\t" + txtInsertName.Text + "\t" + txtInsertType.Text + "\t" + txtInsertDescription.Text;
                wineInsert.Add(line);
                Response.Write("<script>alert('" + line + "');</script>");
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
            MultiView1.SetActiveView(View4);
        }

        protected void btnMainDelete_Click(object sender, EventArgs e)
        {

        }

        protected void btnInsertSummary_Click(object sender, EventArgs e)
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
            RequiredFieldValidator2.Enabled = false;
            RequiredFieldValidator3.Enabled = false;
            RequiredFieldValidator4.Enabled = false;
            MultiView1.SetActiveView(Summary);
        }

        protected void btnMainSummary_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }

        protected void cbSelect_CheckedChanged(object sender, EventArgs e)
        {
            GridViewUpdate.Visible = false;
            lblUpdateName.Visible = true;
            lblUpdateType.Visible = true;
            lblUpdateDescription.Visible = true;
            txtDescription0.Visible = true;
            txtGrapeName0.Visible = true;
            txtType0.Visible = true;
            btnUpdate.Visible = true;
            txtGrapeName0.Text = GridViewUpdate.SelectedRow.Cells[1].Text;
            txtType0.Text = GridViewUpdate.SelectedRow.Cells[2].Text;
            txtDescription0.Text = GridViewUpdate.SelectedRow.Cells[3].Text;
        }
    }            
}