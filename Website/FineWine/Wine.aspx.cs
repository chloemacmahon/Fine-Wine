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
                arrWineInfo[3] = txtDescrption.Text;
                objMain.insertStock("WINE",arrWineInfo);
            }
            catch
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
    }
}