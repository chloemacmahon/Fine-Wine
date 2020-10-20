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
        public bool verifyLogin(string sqlRetrieve, string pass)
        {
            //open connection to database and execute sql query
            connect.Open();
            string dbpass = "";
            command = new SqlCommand(sqlRetrieve, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                dbpass = reader.GetValue(0).ToString();
            }
            connect.Close();
            if (pass == dbpass)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public bool checkForeignKey(string sqlCheck)
        {
            connect.Open();
            command = new SqlCommand(sqlCheck, connect);
            reader = command.ExecuteReader();
            int count = 0;
            while(reader.Read())
            {
                count++;
            }
            connect.Close();
            if (count > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        //get id of different entities
        public string getID(string sqlSelect)
        {
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


        //create list to use to generate reports
        public List<string> wineChart()
        {
            List<string> result = new List<string>();
            string sqlSelect = "SELECT w.Wine_ID, w.Name, wp.Harvest_ID, wp.Estimated_Production, wp.Actual_Production FROM WINE w, WINE_PRODUCTION wp, HARVEST h " +
                                "WHERE w.Wine_ID LIKE wp.Wine_ID AND h.Harvest_ID LIKE wp.Harvest_ID";
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                string line = reader.GetValue(0).ToString() + "," + reader.GetValue(1).ToString() + "," + reader.GetValue(2).ToString() + "," + reader.GetValue(3).ToString() + "," + reader.GetValue(4).ToString();
                result.Add(line);
            }
            connect.Close();
            return result;
        }

        public List<string> salesChart()
        {
            List<string> result = new List<string>();
            string sqlSelect = "SELECT TOP 10(*) FROM STOCK ORDER BY Stock_Sold DESC";
            connect.Open();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string line = reader.GetValue(0).ToString() + "," + reader.GetValue(2).ToString() + "," + reader.GetValue(4).ToString() + "," + reader.GetValue(5).ToString();
                result.Add(line);
            }
            connect.Close();
            return result;
        }

    }
}