using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineWine
{
    public partial class HomePage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            var qs = Request.QueryString["view"];
            if (qs != null)
            {
                if (qs == "1")
                {
                    MultiView1.SetActiveView(AdminHomeView);
                }
                else
                {
                    MultiView1.SetActiveView(View1);
                }
            }
        }
    }
}