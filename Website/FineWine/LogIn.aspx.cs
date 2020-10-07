using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineWinesWeb;

namespace FineWine
{
    public partial class LogIn : System.Web.UI.Page
    {
        Maintain objMain = new Maintain();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            Server.Transfer("RegisterBusiness.aspx");
        }

        protected void btnLogIn_Click(object sender, EventArgs e)
        {
            try
            {
                List<string> businesses = objMain.displayBusinessInfo(txtBusinessName.Text); //Gets businesses in database with information 
                if (businesses.Count() == 1)
                {
                    string password = businesses[0].Split(',')[1];
                    if (password == txtBusinessPassword.Text)
                    {
                        HttpCookie userCookie = new HttpCookie("User Information");
                        userCookie["Account type"] = "B";
                        userCookie["Account name"] = txtBusinessName.Text;
                        userCookie["Account ID"] = businesses[0].Split(',')[0];
                        Response.Cookies.Add(userCookie);
                    }
                    else
                    {
                        lblError.Text = "Incorrect password";
                    }
                }
                else
                {
                    lblError.Text = "Could not find account";
                }
            }
            catch
            {
                lblError.Text = "An error occured";
            }
        }
    }
}