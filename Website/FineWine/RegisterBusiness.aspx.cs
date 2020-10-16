using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineWinesWeb;

namespace FineWine
{
    public partial class RegisterBusiness : System.Web.UI.Page
    {
        Maintain objMain = new Maintain();
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<string> cities = objMain.displayCity(); //Loads cities into drop down list
                foreach (string city in cities)
                {
                    ddlCityTown.Items.Add(city);
                }
                if (ddlCityTown.SelectedIndex > -1)
                {
                    string city = ddlCityTown.Items[ddlCityTown.SelectedIndex].Text;
                    List<string> suburbs = objMain.displaySuburb(city.Split(',')[0]); //Loads cities into drop down list
                    foreach (string suburb in suburbs)
                    {
                        ddlCountry.Items.Add(suburb);
                    }
                }
            }
            catch
            {
                lblError.Text = "Problem loading subburbs and cities";
            }
        }

        protected void TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        protected void TextBox7_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                //Creation of info array 
                string[] info = new string[2];
                //Creation of address array
                string[] address = new string[5];
                info[0] = txtBusinessName.Text;
                info[1] = txtPassword.Text;
                List<string> businesses = objMain.displayBusinessInfo(txtBusinessName.Text);
                if (businesses.Count() > 0)
                {
                    lblError.Text = "Business is already registered";
                }
                else
                {
                    //City ID
                    string city = ddlCityTown.Items[ddlCityTown.SelectedIndex].Text;
                    string cityID = city.Split(',')[0];

                    //Suburb ID
                    string suburb = ddlCountry.Items[ddlCountry.SelectedIndex].Text;
                    string suburbID = suburb.Split(',')[0];
                    //Adding address info 
                    address[0] = suburbID;
                    address[1] = cityID;
                    address[2] = txtStreetNumber.Text;
                    address[3] = txtStreetName.Text;
                    address[4] = txtZipCode.Text;
                    List<string> business = objMain.displayBusinessInfo(txtBusinessName.Text);
                    objMain.insertBusiness(info, address); //Adds business into database
                    HttpCookie userCookie = new HttpCookie("User Information");
                    userCookie["Account type"] = "B";
                    userCookie["Account name"] = txtBusinessName.Text;
                    userCookie["Account ID"] = business[0].Split(',')[0];
                    Response.Cookies.Add(userCookie);
                }
                
            }
            catch
            {
                lblError.Text ="There was a problem registering business";
            }
        }
    }
}