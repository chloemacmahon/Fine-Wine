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
        Maintain objMain = new Maintain();
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        DataSet ds;

        //Connect to the database
        public void connectDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FineWines.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connectDatabase();
            MultiView1.SetActiveView(View4);
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {//Add grape to database 
            try
            {
                string[] grapeInfo = new string[3];
                grapeInfo[0] = txtGrapeName.Text;
                grapeInfo[1] = txtType.Text;
                grapeInfo[2] = txtDescrption.Text;
                objMain.insertStock("GRAPE", grapeInfo);
            }
            catch
            {
                lblError.Text = "A error occured please try again later";
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
           
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            if(!(GridViewDelete.SelectedIndex < 0))
            {
                string selectedPrimaryKey = GridViewDelete.Rows[GridViewDelete.SelectedIndex].Cells[0].ToString();
                string[] arrPrimaryKey = new string[2];
                arrPrimaryKey[0] = selectedPrimaryKey;
                try
                {
                    objMain.deleteStock("GRAPE", arrPrimaryKey);
                }
                catch
                {

                }
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
                GridViewUpdate.DataBind();
            }
        }
    }
}