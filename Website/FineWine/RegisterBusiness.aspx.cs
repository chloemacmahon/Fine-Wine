using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineWinesWeb;
using System.Data;
using System.Data.SqlClient;

namespace FineWine
{
    public partial class RegisterBusiness : System.Web.UI.Page
    {

        SqlConnection connect;
        SqlCommand command;
        SQLMaintain maintain = new SQLMaintain();
        string countryID, regionID, cityTownID;
        Random rand = new Random();


        //sql query to display countries in ddlCountry on RegisterBusiness form
        public void displayCountry()
        {
            ddlCountry.Items.Add("");
            connect.Open();
            string sqlSelect = "SELECT Name FROM COUNTRY ORDER BY Name ASC";
            command = new SqlCommand(sqlSelect,connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlCountry.Items.Add(reader.GetValue(0).ToString());
            }
            connect.Close();
        }

        public void displayRegions()
        {
            connect.Open();
            ddlRegion.Items.Add("");
            string sqlSelect = "SELECT r.Name, c.Country_ID FROM REGION r, COUNTRY c WHERE c.Name LIKE '" + ddlCountry.Text + "' AND c.Country_ID = r.Country_ID ORDER BY r.Name ASC";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlRegion.Items.Add(reader.GetValue(0).ToString());
                countryID = reader.GetValue(1).ToString();
            }
            connect.Close();
        }

        public void displayCityTown()
        {
            connect.Open();
            
            ddlCityTown.Items.Add("");
            string sqlSelect = "SELECT ct.Name, r.Region_ID FROM CITY_TOWN ct, REGION r WHERE r.Name LIKE '" + ddlRegion.Text + "' AND r.Region_ID = ct.Region_ID ORDER BY ct.Name ASC";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                ddlCityTown.Items.Add(reader.GetValue(0).ToString());
                regionID = reader.GetValue(1).ToString();
            }
            connect.Close();
        }

        public void getCountryID()
        {
            connect.Open();
            string sqlSelect = "SELECT Country_ID FROM COUNTRY WHERE Name LIKE '" + ddlCountry.Text + "'";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                countryID = reader.GetValue(0).ToString();
            }
            connect.Close();
        }

        public void getRegionID()
        {
            connect.Open();
            string sqlSelect = "SELECT Region_ID FROM REGION WHERE Name LIKE '" + ddlRegion.Text + "'";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                regionID = reader.GetValue(0).ToString();
            }
            connect.Close();
        }

        public void getCityTownID()
        {
            connect.Open();
            string sqlSelect = "SELECT City_Town_ID FROM CITY_TOWN WHERE Name LIKE '" + ddlCityTown.Text + "'";
            command = new SqlCommand(sqlSelect, connect);
            SqlDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                cityTownID = reader.GetValue(0).ToString();
            }
            connect.Close();
        }


        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                connect = new SqlConnection(maintain.connectDatabase());
                
                var qs = Request.QueryString["view"];
                if (qs != null && qs == "1")
                {
                        MultiView1.SetActiveView(AdminView);
                }
                else
                {
                    MultiView1.SetActiveView(BusinessView);
                    displayCountry();
                }
            }
            catch
            {
                Response.Write("<script>alert('Unsuccessful');<script>");
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
            getCountryID();
            getRegionID();
                getCityTownID();
                string sqlId = "";
                string addressId = "";
                string businessId = "";
                do
                {
                    //Create Address_ID: first 4 letters of street name + street number + 4 random numbers
                    addressId = txtStreetName.Text.Substring(0, 4) + txtStreetNumber.Text + rand.Next(1000, 9999);
                    sqlId = "SELECT Address_ID FROM ADDRESS WHERE Address_ID LIKE '" + addressId + "'";
                } while (maintain.isUsed(sqlId,addressId));
                
                string sqlInsertAddress = "INSERT INTO Address VALUES('" + addressId + "', '" + int.Parse(countryID) + "', '" + int.Parse(regionID) + "', '" + 
                                            int.Parse(cityTownID) + "', '" + int.Parse(txtStreetNumber.Text) + "', '" + txtStreetName.Text + "', '" + txtZipCode.Text + "')";
                maintain.insertData(sqlInsertAddress);
                do
                {
                    //Create Business_ID: first 4 letters of business name + 4 random numbers
                    businessId = txtBusinessName.Text.Substring(0, 4) + rand.Next(1000, 9999);
                    sqlId = "SELECT Business_ID FROM BUSINESS WHERE Business_ID LIKE '" + businessId + "'";
                } while (maintain.isUsed(sqlId,businessId));
                
                string sqlInsertBusiness =  "INSERT INTO Business VALUES('" + businessId + "', '" + addressId + "', '" + txtBusinessName.Text + "', '" + txtPassword.Text + "')";
                maintain.insertData(sqlInsertBusiness);
                //Insert details into login table
                string sqlInsertLogin =  "INSERT INTO Login VALUES(null, '" + businessId + "', 'B')";
                maintain.insertData(sqlInsertLogin);
                HttpCookie userCookie = new HttpCookie("User Information");
                userCookie["Account type"] = "B";
                userCookie["Account name"] = txtBusinessName.Text;
                userCookie["Account ID"] = businessId;
                Response.Cookies.Add(userCookie);
            Response.Redirect("HomePage.aspx");
            }
            catch
            {
                lblError.Text ="There was a problem registering business";
            }     
        }

        protected void txtPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void txtRepeatPassword_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnARegister_Click(object sender, EventArgs e)
        {
            try
            {
                string adminId = "";
                do
                {
                    //Create Admin_ID: first 4 letters of user name + 4 random numbers
                    adminId = txtAUserName.Text.Substring(0, 4) + txtStreetNumber.Text + rand.Next(1000, 9999);
                } while (maintain.isUsed("SELELECT Admin_ID FROM ADMIN WHERE Admin_ID LIKE '" + adminId + "'",adminId));
                
                string sqlInsert = "INSERT INTO ADMIN VALUES('" + adminId + "', '" + txtAUserName.Text + "', '" + txtAConfirm.Text + "')";
                maintain.insertData(sqlInsert);
                string sqlLogin = "INSERT INTO LOGIN VALUES('" + adminId + "', null, 'A')";
                maintain.insertData(sqlLogin);
                Response.Redirect("HomePage.aspx?view=1");
            }
            catch
            {

            }
        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {

        }

        protected void ddlCountry_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayRegions();
        }

        protected void ddlRegion_SelectedIndexChanged(object sender, EventArgs e)
        {
            displayCityTown();
        }
    }
}