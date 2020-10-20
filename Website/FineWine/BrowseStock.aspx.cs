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
        Random rand = new Random();
        SQLMaintain maintain = new SQLMaintain();
        static List<string> selected = new List<string>();

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
            connect = new SqlConnection(maintain.connectDatabase());
            displayAll("SELECT w.Name, w.Wine_Type, s.Production_Year, s.Stock_On_Hand, s.Selling_Price FROM STOCK s, WINE w WHERE w.Wine_ID = s.Wine_ID");
            MultiView1.SetActiveView(Browse);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
         
    
            if (selected.Count == 0)
            {
                Response.Write("<script>alert('No items were selected.');</script>");
            }
            else
            {
                Table1.Caption.Insert(0, "Units");

                foreach (string line in selected)
                {
                    ListBox1.Items.Add(line);
                }
                MultiView1.SetActiveView(ConfirmOrderView);
            } 
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string name = GridView1.SelectedRow.Cells[1].Text;
            string type = GridView1.SelectedRow.Cells[2].Text;
            string year = GridView1.SelectedRow.Cells[3].Text;
            string sellingPrice = GridView1.SelectedRow.Cells[5].Text;
            selected.Add(name + "\t" + type + "\t" + year + "\t" + "\t" + sellingPrice);     
        }
     

        /* protected void cbSelect_CheckedChanged(object sender, EventArgs e)
         {
             string name = GridView1.SelectedRow.Cells[1].Text;
             string type = GridView1.SelectedRow.Cells[2].Text;
             string year = GridView1.SelectedRow.Cells[3].Text;
             string soh = GridView1.SelectedRow.Cells[4].Text;
             string sellingPrice = GridView1.SelectedRow.Cells[5].Text;
             selected.Add(name + "\t" + type + "\t" + year + "\t" + soh + "\t" + sellingPrice);
             Response.Write("<script>alert('" + selected.Count + "');</script>");
         }             */
    }
}