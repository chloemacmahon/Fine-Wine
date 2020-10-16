using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineWinesWeb
{
    public partial class FineWines : System.Web.UI.MasterPage
    {

        HttpCookie viewCookie = new HttpCookie("viewInfo");

        protected void Page_Load(object sender, EventArgs e)
        {
                
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grapes.aspx");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wine.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {

        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {

        }
    }
}