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
    public partial class BrowseStock : System.Web.UI.Page
    {

        SqlConnection connect;
        SqlDataAdapter adapt = new SqlDataAdapter();
        SqlCommand command;
        DataSet ds;
        SqlDataReader reader;
        Random rand = new Random();
        public List<string> selected = new List<string>();

        public void connectDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FineWines.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
        }

        //display all information in tables using sql select statement
        public void displayAll(string sqlSelect)
        {
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            ds = new DataSet();
            adapt = new SqlDataAdapter();
            adapt.SelectCommand = command;
            adapt.Fill(ds);
            GridView1.DataSource = ds;
            GridView1.DataBind();

        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connectDatabase();
            displayAll("SELECT w.Name, w.Wine_Type, s.Production_Year, s.Stock_On_Hand, s.Selling_Price FROM STOCK s, WINE w WHERE w.Wine_ID = s.Wine_ID");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
           /* foreach (GridViewRow row in GridView1.Rows)
            {
                 if(Convert.ToBoolean(cbSelect.Checked))
                 {
                     string name = GridView1.SelectedRow.Cells[1].Text;
                     string type = GridView1.SelectedRow.Cells[2].Text;
                     string year = GridView1.SelectedRow.Cells[3].Text;
                     string soh = GridView1.SelectedRow.Cells[4].Text;
                     string sellingPrice = GridView1.SelectedRow.Cells[5].Text;
                     selected.Add(name + "\t" + type + "\t" + year + "\t" + soh + "\t" + sellingPrice);
                 }  
                Response.Write("<script>alert('" + row.Cells[1].Text + "');</script>");
            }     */
            if (selected.Count == 0)
            {
                Response.Write("<script>alert('No items were selected.');</script>");
            }
            else
            {
                Response.Redirect("PlaceOrder.aspx");
            } 
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridView1.SelectedRow.Cells[1].Text;
            string type = GridView1.SelectedRow.Cells[2].Text;
            string year = GridView1.SelectedRow.Cells[3].Text;
            string soh = GridView1.SelectedRow.Cells[4].Text;
            string sellingPrice = GridView1.SelectedRow.Cells[5].Text;
            selected.Add(name + "\t" + type + "\t" + year + "\t" + soh + "\t" + sellingPrice);
            Response.Write("<script>alert('" + selected.Count + "');</script>");      
        }
    }
}