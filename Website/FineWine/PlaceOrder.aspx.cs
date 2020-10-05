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
    public partial class PlaceOrder : System.Web.UI.Page
    {

        SqlConnection connect;
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlCommand command;
        DataSet ds;
        SqlDataReader reader;
        Random rand = new Random();

        public void connectDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FineWines.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
        }

        //display all information in tables using sql select statement
        public void displayAll(string tableName)
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM " + tableName;
            command = new SqlCommand(sqlSelect, connect);
            ds = new DataSet();
            adapt.SelectCommand = command;
            adapt.Fill(ds);
            CheckBoxList1.DataSource = ds;
            CheckBoxList1.DataBind();
            connect.Close();
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connectDatabase();
            displayAll("STOCK");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }
    }
}