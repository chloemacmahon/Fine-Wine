using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

namespace FineWine
{

    public class SQLMaintain
    {
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        SqlDataReader reader;
        

        //Connect to the database  - implement on relevant pageloads
        public string connectDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FineWines.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
            return connectionString;
        }

        //sql query to insert new data into tables  
        public void insertData(string sqlInsert)
        {
            connect.Open();
            command = new SqlCommand(sqlInsert, connect);
            adapt = new SqlDataAdapter();
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
            adapt = new SqlDataAdapter();
            adapt.DeleteCommand = command;
            adapt.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }

        //sql query to edit table data
        public void updateData(string sqlUpdate)
        {
            connect.Open();
            command = new SqlCommand(sqlUpdate, connect);
            adapt = new SqlDataAdapter();
            adapt.UpdateCommand = command;
            adapt.UpdateCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }
        
        //sql query to verify login
        public bool verifyLogin(string sqlCompare)
        {
            //open connection to database and execute sql query
            connect.Open();
            command = new SqlCommand(sqlCompare, connect);
            reader = command.ExecuteReader();
            if(reader != null)
            {
                connect.Close();
                return true;
            }
            else
            {
                connect.Close();
                return false;
            }    
        }

        //get the business id
        public string getBusinessID(string bName)
        {
            string sqlSelect = "SELECT Business_ID FROM BUSINESS WHERE Business_Name LIKE '" + bName + "'";
            string id = "";
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetValue(0).ToString();
            }
            connect.Close();
            return id;
        }

        //get the grape id
        public string getGrapeID(string gName)
        {
            string sqlSelect = "SELECT Grape_ID FROM GRAPE WHERE Name LIKE '" + gName + "'";
            string id = "";
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetValue(0).ToString();
            }
            connect.Close();
            return id;
        }

        //get the wine id
        public string getWineID(string wName)
        {
            string sqlSelect = "SELECT Wine_ID FROM WINE WHERE Name LIKE '" + wName + "'";
            string id = "";
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                id = reader.GetValue(0).ToString();
            }
            connect.Close();
            return id;
        }

        public void wineChart()
        {

        }

    }
}