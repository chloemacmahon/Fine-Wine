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

        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(maintain.connectDatabase());
            //use query to determine which view to show
            var qs = Request.QueryString["view"];
            if (qs != null)
            {
                if (qs == "1")
                {
                    MultiView1.SetActiveView(View4);
                }
            }    
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {//Add grape to database 
         // try
         // {
         //create id for grape: first 4 letters of name + random letters/numbers
            string id = txtGrapeName.Text.Substring(0, 4) + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a');
                //create sql query for the insert
                string sqlInsert = "INSERT INTO Grape VALUES('" + id + "', '" + txtGrapeName.Text + "', '" + txtType.Text + "', '" + txtDescrption.Text + "')";
            //execute sql inser query for grapes
            maintain.insertData(sqlInsert);
          /*  }
            catch
            {
                lblError.Text = "A error occured please try again later";
            }  */
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(!(GridViewDelete.SelectedIndex < 0))
            {
               //retrieve primary key               
                string selectedPrimaryKey = GridViewDelete.Rows[GridViewDelete.SelectedIndex].Cells[0].Text.ToString();
                //create sql delete query
                string sqlDelete = "DELETE FROM Grape WHERE Grape_ID = '" + selectedPrimaryKey + "'";
                maintain.deleteData(sqlDelete);
                /*  string[] arrPrimaryKey = new string[2];
                arrPrimaryKey[0] = selectedPrimaryKey;
                try
                {
                    objMain.deleteStock("GRAPE", arrPrimaryKey);
                }
                catch
                {

                } */
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(radlistGrapeOptions.SelectedIndex == 0)
            {
                MultiView1.SetActiveView(View1);
                
            }
            else if (radlistGrapeOptions.SelectedIndex == 1)
            {
                MultiView1.SetActiveView(View2);
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
            else if (radlistGrapeOptions.SelectedIndex == 2)
            {
                MultiView1.SetActiveView(View3);
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
        }
    }
}