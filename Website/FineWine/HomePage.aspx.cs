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

        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            Server.Transfer("LogIn.aspx");
        }

        protected void btnSignUp_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegisterBusiness.aspx");
        }
    }
}