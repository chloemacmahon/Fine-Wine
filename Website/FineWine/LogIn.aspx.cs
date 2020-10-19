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
    public partial class LogIn : System.Web.UI.Page
    {
        SQLMaintain maintain = new SQLMaintain();

        protected void Page_Load(object sender, EventArgs e)
        {
            //use query to determine which view to show
            var qs = Request.QueryString["view"];
            if (qs != null)
            {
                if (qs == "1")
                {
                    MultiView1.SetActiveView(BusinessView);
                }
                else if(qs == "2")
                {
                     MultiView1.SetActiveView(AdminView);
                }
            }
        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegisterBusiness.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                //use the following qeury to verify the user details
                string sqlCompare = "SELECT * FROM Business b, Login l WHERE b.Business_Name LIKE '" + txtBusinessName.Text + 
                                    "' AND b.Password LIKE '" + txtBusinessPassword.Text + "' AND b.Business_ID = l.Business_ID AND l.Account_Type = 'B'";

                if (maintain.verifyLogin(sqlCompare))
                {
                    //write user info to a cookie to use later
                    HttpCookie userCookie = new HttpCookie("User Information");
                    userCookie["Account type"] = "B";
                    userCookie["Account name"] = txtBusinessName.Text;
                    userCookie["Account ID"] = maintain.getBusinessID(txtBusinessName.Text);
                    Response.Cookies.Add(userCookie); 
                }
                else
                {
                    lblError.Text = "Could not find account or password was incorrect";
                }
            }
            catch
            {
                lblError.Text = "An error occured";
            }
        }

        protected void btnALogIn_Click(object sender, EventArgs e)
        {

        }
    }
}