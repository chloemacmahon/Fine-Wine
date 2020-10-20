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
        static List<string> sql = new List<string>();
        static List<string> stockid = new List<string>();
        static List<int> units = new List<int>();
        static string name, type, year, sellingPrice, sales_order_id, businessid;
        static int total = 0;
        HttpCookie userCookie;

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
            userCookie = Request.Cookies["User Information"];
            businessid = userCookie["Account ID"];
            sales_order_id = "INV" + rand.Next(10000000, 99999999);
            connect = new SqlConnection(maintain.connectDatabase());
            displayAll("SELECT w.Name, w.Wine_Type, s.Production_Year, s.Stock_ID, s.Stock_On_Hand, s.Selling_Price FROM STOCK s, WINE w WHERE w.Wine_ID = s.Wine_ID");
            MultiView1.SetActiveView(Browse);
        }

        protected void btnAddToCart_Click(object sender, EventArgs e)
        {
            units.Add(int.Parse(txtUnits.Text));
            int unit = int.Parse(txtUnits.Text);
            string SOH = GridView1.SelectedRow.Cells[5].Text;
            if (int.Parse(SOH) < unit)
            {
                Response.Write("<script>alert('Please select less units.  We don't currently have enough stock');</script>");
            }
            else if (unit < 0)
            {
                Response.Write("<script>alert('Invalid number of units selected. Please select a positive number.');</script>");
            }
            else
            {
                int subtotal = (int)decimal.Parse(sellingPrice) * unit;
                total += subtotal;
                sql.Add("INSERT INTO SALES_ORDER VALUES('" + sales_order_id + "', '" + businessid + "', '" + DateTime.Today.ToShortDateString() +
                                    "', '" + DateTime.Now.ToShortTimeString() + "', " + unit + ", '" + subtotal + "')");
                selected.Add(name + "\t\t" + type + "\t\t" + year + "\t\t" + "\t\t" + decimal.Parse(sellingPrice).ToString("c") + "\t\t" + unit + "\t\t" + subtotal.ToString("c"));
                GridView1.Visible = true;
                txtUnits.Visible = false;
                Label1.Visible = false;
                btnAddToCart.Visible = false;
                txtUnits.Text = "0";
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            ListBox2.Items.Add("Thank you for placing your order with us.\n Your order number is "+ sales_order_id + ". We will be in contact with our banking details and delivery confirmation.");
            ListBox2.Items.Add("");
            ListBox2.Items.Add("Your cart contains the following items:");
            ListBox2.Items.Add("");
            for (int i = 0; i < sql.Count; i++)
            {
                maintain.insertData(sql[i]);
               /* string stockSold = "SELECT Stock_Sold FROM STOCK WHERE Stock_ID LIKE '" + stockid[i] + "'";
                string soh = "SELECT Stock_On_Hand FROM STOCK WHERE Stock_ID LIKE '" + stockid[i] + "'";
                string sqlRemoveSOH = "UPDATE STOCK SET Stock_On_Hand = '" + (int.Parse(maintain.getID(soh))-units[i]) + "' AND Stock_Sold = '"+ (int.Parse(maintain.getID(stockSold))+units[i])  +"' WHERE Stock_ID LIKE '" + stockid[i] + "'";
                maintain.updateData(sqlRemoveSOH);     */
                string sqlSales = "INSERT INTO SALES VALUES('" + sales_order_id + "', '" + stockid[i] + "'";
                maintain.insertData(sqlSales);
                ListBox2.Items.Add(selected[i]);
            }
            ListBox2.Items.Add("");
            ListBox2.Items.Add("Your total for today is " + total.ToString("c"));
                
            MultiView1.SetActiveView(ConfirmOrderView);
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            stockid.Add(GridView1.SelectedRow.Cells[4].Text);
            name = GridView1.SelectedRow.Cells[1].Text;
            type = GridView1.SelectedRow.Cells[2].Text;
            year = GridView1.SelectedRow.Cells[3].Text;
            sellingPrice = GridView1.SelectedRow.Cells[6].Text;
            GridView1.Visible = false;
            Label1.Visible = true;
            txtUnits.Visible = true;
            btnAddToCart.Visible = true;
        }

    }
}