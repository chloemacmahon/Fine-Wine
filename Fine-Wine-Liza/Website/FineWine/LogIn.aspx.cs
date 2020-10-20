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
            maintain.connectDatabase();
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
                string sqlRetrieve = "SELECT b.Password, l.Account_Type FROM BUSINESS b, LOGIN l WHERE b.Business_Name LIKE '" + txtBusinessName.Text + 
                                    "' AND b.Business_ID = l.Business_ID AND l.Account_Type = 'B'";

                if (maintain.verifyLogin(sqlRetrieve,txtBusinessPassword.Text))
                {
                    string sqlSelect = "SELECT Business_ID FROM BUSINESS WHERE Business_Name LIKE '" + txtBusinessName.Text + "'";
                    //write user info to a cookie to use later
                    HttpCookie userCookie = new HttpCookie("User Information");
                    userCookie["Account type"] = "B";
                    userCookie["Account name"] = txtBusinessName.Text;
                    userCookie["Account ID"] = maintain.getID(sqlSelect);
                    Response.Cookies.Add(userCookie);
                    Response.Redirect("HomePage.aspx");
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
            try
            {
                //use the following qeury to verify the user details
                string sqlRetrieve = "SELECT a.User_Password, l.Account_Type FROM ADMIN a, LOGIN l WHERE a.User_Name LIKE '" + txtAUserName.Text +
                                    "' AND a.Admin_ID = l.Admin_ID AND l.Account_Type = 'A'";

                if (maintain.verifyLogin(sqlRetrieve, txtAPassword.Text))
                {
                    string sqlSelect = "SELECT Admin_ID FROM ADMIN WHERE User_Name LIKE '" + txtAUserName.Text + "'";
                    //write user info to a cookie to use later
                    HttpCookie userCookie = new HttpCookie("User Information");
                    userCookie["Account type"] = "A";
                    userCookie["Account name"] = txtAUserName.Text;
                    userCookie["Account ID"] = maintain.getID(sqlSelect);
                    Response.Cookies.Add(userCookie);
                    Response.Redirect("HomePage.aspx?view=1");
                }
                else
                {
                    lblError0.Text = "Could not find account or password was incorrect";
                }
            }
            catch
            {
                lblError0.Text = "An error occured";
            }
        }
    }
}