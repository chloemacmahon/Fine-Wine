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

        HttpCookie userCookie;

        protected void Page_Load(object sender, EventArgs e)
        {
             userCookie = Request.Cookies["User Information"];
             if(userCookie != null)
             {
                 if (userCookie["Account type"] == "A")
                 {
                     lnkGrapes.Visible = true;
                     lnkWines.Visible = true;
                     lnkWineProduction.Visible = true;
                     lnkHarvest.Visible = true;
                     lnkReports.Visible = true;
                     lnkSignOut.Visible = true;
                     lnkLogIn.Visible = false;
                     lnkBusinessLogin.Visible = false;
                     lnkAdminLogin.Visible = false;
                     lnkRegisterBusiness.Visible = false;
                     lnkBrowse.Visible = false;
                     lblWelcome.Visible = true;
                     lblWelcome.Text = "Welcome, " + userCookie["Account name"];
                 }
                 else if (userCookie["Account name"] != "")
                 {
                     lnkGrapes.Visible = false;
                     lnkWines.Visible = false;
                     lnkWineProduction.Visible = false;
                     lnkHarvest.Visible = false;
                     lnkReports.Visible = false;
                     lnkSignOut.Visible = true;
                     lnkLogIn.Visible = false;
                     lnkBusinessLogin.Visible = false;
                     lnkAdminLogin.Visible = false;
                     lnkRegisterBusiness.Visible = false;
                     lnkBrowse.Visible = true;
                     lblWelcome.Visible = true;
                     lblWelcome.Text = "Welcome, " + userCookie["Account name"];
                 }
             }
             else if(userCookie == null)
             {
                 lnkGrapes.Visible = false;
                 lnkWines.Visible = false;
                 lnkWineProduction.Visible = false;
                 lnkHarvest.Visible = false;
                 lnkReports.Visible = false;
                 lnkSignOut.Visible = false;
                 lnkLogIn.Visible = true;
                 lnkBusinessLogin.Visible = true;
                 lnkAdminLogin.Visible = true;
                 lnkBrowse.Visible = false;
                 lnkRegisterBusiness.Visible = true;
                 lblWelcome.Visible = false;
             }          
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
            Response.Redirect("Harvest.aspx");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WineProduction.aspx");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestReports.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            // userCookie = Request.Cookies["User Information"];
            if (userCookie != null && userCookie["Account type"] == "A")
            {
                Response.Redirect("HomePage.aspx?view=1");
            }
            else
            {
                Response.Redirect("HomePage.aspx?view=2");
            }
        }

        protected void LinkButton9_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx?view=1");
        }

        protected void LinkButton10_Click(object sender, EventArgs e)
        {
            Response.Redirect("LogIn.aspx?view=2");
        }

        protected void LinkButton7_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterBusiness.aspx");
        }

        protected void LinkButton8_Click(object sender, EventArgs e)
        {
            Response.Redirect("BrowseStock.aspx");
        }

        protected void LinkButton11_Click(object sender, EventArgs e)
        {
            userCookie["Account type"] = "B";
            userCookie["Account name"] = "";
            userCookie["Account ID"] = "";
            Response.Cookies.Add(userCookie);
             Response.Redirect("HomePage.aspx");
        }

        protected void lnkLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("javascript:void(0)");
        }
    }
}