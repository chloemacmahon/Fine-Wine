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
        HttpCookie userCookie;

        protected void Page_Load(object sender, EventArgs e)
        {
           /* userCookie = Request.Cookies["User Information"];
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
                }
                else
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
            }          */
        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("Grapes.aspx?view=1");
        }

        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("Wine.aspx");
        }

        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("Harvest.aspx?view=1");
        }

        protected void LinkButton4_Click(object sender, EventArgs e)
        {
            Response.Redirect("WineProduction.aspx?view=1");
        }

        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("RequestReports.aspx");
        }

        protected void LinkButton6_Click(object sender, EventArgs e)
        {

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
            Response.Cookies.Remove("User Information");
            Response.Redirect("HomePage.aspx?view=2");
        }

        protected void lnkLogIn_Click(object sender, EventArgs e)
        {
            Response.Redirect("javascript:void(0)");
        }
    }
}