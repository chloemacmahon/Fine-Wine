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
            MultiView1.SetActiveView(View4);
            connectDatabase();
        }

        protected void btnInsert_Click(object sender, EventArgs e)
        {
            try
            {
                string[] arrWineInfo = new string[4];
                arrWineInfo[0] = txtGrapeName.Text;
                arrWineInfo[1] = GridViewInsert.Rows[GridViewInsert.SelectedIndex].Cells[0].ToString();
                arrWineInfo[2] = txtType.Text;
               // arrWineInfo[3] = txtDescrption.Text;
                objMain.insertStock("WINE",arrWineInfo);
            }
            catch(Exception ex)
            {
                
            }
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if (radlistGrapeOptions.SelectedIndex == 0)
            {
                MultiView1.SetActiveView(View1);
                connect.Open();
                string sqlSelect = "SELECT * FROM GRAPE";
                command = new SqlCommand(sqlSelect, connect);
                ds = new DataSet();
                adapt = new SqlDataAdapter();
                adapt.SelectCommand = command;
                adapt.Fill(ds, "GRAPE");
                GridViewInsert.DataSource = ds;
                GridViewInsert.DataMember = "GRAPE";
                GridViewInsert.DataBind();

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
                GridViewUpdate.DataBind();
            }
        }

        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            /* Kan jy my ook dalk asb help met die update funksie?
             * Ek weet nie presies hoe hierdie kode moet lyk nie. 
             */
        }

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                string[] index = new string[2];
                index[0] = GridViewDelete.Rows[GridViewDelete.SelectedIndex].Cells[0].ToString();
                objMain.deleteStock("WINE", index);
            }
            catch
            {

            }
        }
         /*
        protected System.Void btnInsert_Click(System.Object sender, System.EventArgs e)
        {

        }

        protected System.Void btnMainInsert_Click(System.Object sender, System.EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }

        protected System.Void btnMainUpdate_Click(System.Object sender, System.EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }

        protected System.Void btnMainDelete_Click(System.Object sender, System.EventArgs e)
        {
            MultiView1.SetActiveView(Summary);

            lblGrapeNameInsert.Text = txtGrapeName.Text;
            lblTypeInsert.Text = txtType.Text;
            lblDescriptionInsert.Text = txtDescription.Text;

            lblGrapeNameUpdate.Text = txtGrapeName0.Text;
            lblTypeUpdate.Text = txtType0.Text;
            lblDescriptionUpdate.Text = txtDescription0.Text;

            /* delete het nie textbox'e om van te delete nie, so ek hak nou bietjie vas, 
                    weet jy dalk hoe ek nou verder gaan om die delet funksie in die summary ook te sit?

            lblGrapeNameDelete.Text = txtGrapeName.Text;
            lblTypeInsert.Delete = txtType.Text;
            lblDescriptionDelete.Text = txtDescription.Text;
            */
        //}   
         /*
        protected System.Void btnMainSummary_Click(System.Object sender, System.EventArgs e)
        {
            MultiView1.SetActiveView(View4);
        }      */
    }            
}