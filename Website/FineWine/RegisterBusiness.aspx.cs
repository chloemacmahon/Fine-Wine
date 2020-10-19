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

        public void getCityTown()
        {
            connect.Open();
            string sqlSelect = "SELECT City_Town_ID FROM City_Town WHERE Name LIKE '" + ddlCityTown.Text + "'";
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
                displayCountry();
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
                getCityTown();
                //Create Address_ID: first 4 letters of street name + street number + 4 random letters/numbers
                string addressId = txtStreetName.Text.Substring(0, 4) + txtStreetNumber.Text + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a');
                string sqlInsertAddress = "INSERT INTO Address VALUES('" + addressId + "', '" + int.Parse(countryID) + "', '" + int.Parse(regionID) + "', '" + 
                                            int.Parse(cityTownID) + "', '" + int.Parse(txtStreetNumber.Text) + "', '" + txtStreetName.Text + "', '" + txtZipCode.Text + "')";
                maintain.insertData(sqlInsertAddress);
                //Create Business_ID: first 4 letters of business name + 4 random letters/numbers
                string businessId = txtBusinessName.Text.Substring(0, 4) + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a') + (char)rand.Next(000, 'a');
                string sqlInsertBusiness =  "INSERT INTO Business VALUES('" + businessId + "', '" + addressId + "', '" + txtBusinessName.Text + "', '" + txtPassword.Text + "')";
                maintain.insertData(sqlInsertBusiness);
                //Insert details into login table
                string sqlInsertLogin =  "INSERT INTO Login(@Business_ID,@Account_Type) VALUES('" + businessId + "', 'B')";
                maintain.insertData(sqlInsertLogin);
            }
            catch
            {
                lblError.Text ="There was a problem registering business";
            }
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