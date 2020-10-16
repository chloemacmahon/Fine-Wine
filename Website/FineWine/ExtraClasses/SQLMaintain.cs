using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace FineWine
{

    public class SQLMaintain
    {
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        RegisterBusiness register = new RegisterBusiness();

        //Connect to the database  - implement on relevant pageloads
        public void connectDatabase()
        {
            //string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\App_Data\FineWines.mdf;Integrated Security=True;Connect Timeout=30";
            //use relative connectionString that is defined in web.config
            string connectionString = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
            connect = new SqlConnection(connectionString);
        }

        //sql query to insert new data into tables  
        public void insertData(string sqlInsert)
        {
            connect.Open();
            command = new SqlCommand(sqlInsert, connect);
            adapt.InsertCommand = command;
            adapt.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }

        //sql query to delete data from tables
        public void deleteData(string sqlDelete)
        {
            connect.Open();
            command = new SqlCommand(sqlDelete, connect);
            adapt.DeleteCommand = command;
            adapt.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }

        //sql query to display country
        public void displayCountry()
        {
            connect.Open();
            string sqlSelect = "SELECT Name FROM COUNTRY ORDER BY ASC";
            connect.Close();
        }
    }
}