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

        BrowseStock browse = new BrowseStock();
        DateTime date = new DateTime(DateTime.Today.Year, DateTime.Today.Month, DateTime.Today.Day);


        protected void Page_Load(object sender, EventArgs e)
        {
            string name = "";
            ListBox1.Items.Add("");
            MultiView1.SetActiveView(ConfirmOrderView);
        }

        protected void Button1_Click(object sender, EventArgs e)
        {

        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

        }
    }
}