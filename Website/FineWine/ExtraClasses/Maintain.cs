using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace FineWinesWeb
{
    public class Maintain
    {
        SqlConnection connect;
        SqlDataAdapter adapt;
        SqlCommand command;
        DataSet ds;
        SqlDataReader reader;
        Random rand = new Random();

        //Connect to the database
        public void connectDatabase()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\FineWines.mdf;Integrated Security=True;Connect Timeout=30";
            connect = new SqlConnection(connectionString);
        }

        //insert data into different stock tables using table name and array with the necessary stock information
        public void insertStock(string tableName, string[] info)
        {
            connect.Open();
            string primary = "";
            string sqlInsert = "";

            //determine table
            if (tableName == "GRAPE")
            {
                primary = info[0].Substring(0, 4) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
                sqlInsert = @"INSERT INTO " + tableName + "(Grape_ID, Name, Grape_Type, Description) VALUES('" + primary + "', '" + info[0] + "', '" + info[1] + "', '" + info[2] + "')";
            }
            else if (tableName == "WINE")
            {
                primary = info[0].Substring(0, 4) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
                sqlInsert = @"INSERT INTO " + tableName + "(Wine_ID, Grape_ID, Name, Wine_Type, Description) VALUES('" + primary + "', '" + info[0] + "', '" + info[1] + "', '" + info[2] + "', '" + info[3] + "', '" + info[4] + "')";
            }
            else if (tableName == "HARVEST")
            {
                primary = info[0].Substring(0, 4) + info[2] + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
                sqlInsert = @"INSERT INTO " + tableName + "(Harvest_ID, Grape_ID, Amount_Planted, Date_Planted, Estimated_Harvest, Actual_Harvest) " +
                            "VALUES('" + primary + "', " + info[0] + "', " + int.Parse(info[1]) + ", " + int.Parse(info[2]) + ", " + int.Parse(info[3]) + ", " + int.Parse(info[4]) + ")";
            }
            else if (tableName == "WINE_PRODUCTION")
            {
                sqlInsert = @"INSERT INTO " + tableName + "(Wine_ID, Harvest_ID, Estimated_Production, Actual_Production, Maturartion_Period) " +
                            "VALUES('" + info[0] + "', '" + info[1] + "', " + int.Parse(info[2]) + ", " + int.Parse(info[3]) + ", " + int.Parse(info[4]) + ")";
            }
            else if (tableName == "STOCK")
            {
                primary = info[0].Substring(0, 4) + info[1] + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
                sqlInsert = @"INSERT INTO " + tableName + "(Stock_ID, Wine_ID, Production_Year, Stock_On_Hand, Stock_Sold, Unit_Price, Selling_Price) " +
                            "VALUES('" + primary + "', '" + info[0] + "', " + int.Parse(info[1]) + ", " + int.Parse(info[2]) + ", " + int.Parse(info[3]) + ", " + int.Parse(info[4]) + ", " + int.Parse(info[5]) + ")";
            }
            else if (tableName == "SALES_ORDER")
            {
                primary = info[0].Substring(0, 4) + info[1] + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
                sqlInsert = @"INSERT INTO " + tableName + "(Sales_Order_ID, Business_ID, Sales_Date, Sales_Time, Quantity_Bought, Sales_Total) " +
                            "VALUES('" + primary + "', '" + info[0] + "', " + int.Parse(info[1]) + "," + int.Parse(info[2]) + ", " + int.Parse(info[3]) + ", " + int.Parse(info[4]) + ")";
            }
            command = new SqlCommand(sqlInsert, connect);
            adapt.InsertCommand = command;
            adapt.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }

        //add business to the database using arrays to store business information and address information
        public void insertBusiness(string[] info, string[] address)
        {
            connect.Open();
            //add address to database
            string primaryA = info[0].Substring(0, 4) + address[3].Substring(0,4) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
            string sqlInsertAddress = @"INSERT INTO ADDRESS(Address_ID, Suburb_ID, City_Town_ID, Street_Number, Street_Name, Zip_Code) " +
                                      "VALUES('" + primaryA +"', " + int.Parse(address[0]) + ", " + int.Parse(address[1]) + ", " + int.Parse(address[2]) + ", '" + address[3] + "', '" + address[4] + "')";
            command = new SqlCommand(sqlInsertAddress, connect);
            adapt.InsertCommand = command;
            adapt.InsertCommand.ExecuteNonQuery();
            command.Dispose();

            string primaryB = info[0].Substring(0, 4) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9) + rand.Next('Z', 9);
            string sqlInsertBusiness = @"INSERT INTO BUSINESS(Business_ID, Address_ID, Business_Name, Password) " +
                        "VALUES('" + primaryB + "', '" + primaryA +"', " + info[0] + "', '" + info[1] + "')";
            command = new SqlCommand(sqlInsertBusiness, connect);
            adapt.InsertCommand = command;
            adapt.InsertCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }

        //delete stock from database with paramaters table name and an array id
        public void deleteStock(string tableName, string[] id)
        {
            connect.Open();
            string sqlDelete = "DELETE FROM " + tableName + " WHERE ";
            if(tableName == "GRAPE")
            {
                sqlDelete += "Grape_ID LIKE '" + id[0] + "'";
            }
            else if(tableName == "WINE")
            {
                sqlDelete += "Wine_ID LIKE '" + id[0] + "'";
            }
            else if(tableName == "HARVEST")
            {
                sqlDelete += "Harvest_ID LIKE '" + id[0] + "'";
            }
            else if (tableName == "WINE_PRODUCTION")
            {
                sqlDelete += "Wine_ID LIKE '" + id[0] + "' AND WHERE Harvest_ID LIKE '" + id[1] + "'";
            }
            else if(tableName == "STOCK")
            {
                sqlDelete += "Stock_ID LIKE '" + id[0] + "' AND WHERE Wine_ID LIKE '" + id[1] + "'";
            }
            else if(tableName == "BUSINESS")
            {
                sqlDelete += "Business_ID LIKE '" + id[0] + "' AND WHERE Address_ID LIKE '" + id[1] + "'";
            }
            command = new SqlCommand(sqlDelete, connect);
            adapt.DeleteCommand = command;
            adapt.DeleteCommand.ExecuteNonQuery();
            command.Dispose();
            connect.Close();
        }

        //display all information in tables using sql select statement
        public List<string> displayAll(string tableName)
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM " + tableName;
            List<string> result = new List<string>();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            if(tableName == "GRAPE" )
            {
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3);
                    result.Add(output);
                }
            }
            else if(tableName == "WINE")
            {
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4);
                    result.Add(output);
                }
            }
            else if(tableName == "HARVEST")
            {
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4) + "," + reader.GetValue(5);
                    result.Add(output);
                }
            }
            else if(tableName == "WINE_PRODUCTION")
            {
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4);
                    result.Add(output);
                }
            }
            else if(tableName == "STOCK")
            {
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4) + "," + reader.GetValue(5) + "," + reader.GetValue(6);
                    result.Add(output);
                }
            }
            connect.Close();
            return result;
        }

        //display all cities in database divided by ,
        public List<string> displayCity()
        {
            connect.Open();
            List<string> city = new List<string>();
            string sqlCity = "SELECT * FROM CITY_TOWN";
            command = new SqlCommand(sqlCity, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                string output = reader.GetValue(0) + "," + reader.GetValue(1);
                city.Add(output);
            }
            connect.Close();
            return city;
        }

        public List<string> displaySuburb(string cityID)
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM SUBURB WHERE City_Town_ID = '" + cityID + "'";
            List<string> suburb = new List<string>();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                string output = reader.GetValue(0) + "," + reader.GetValue(2);
                suburb.Add(output);
            }
            connect.Close();
            return suburb;
        }
        //Displays business information based on business name
        public List<string> displayBusinessInfo(string businessName)
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM Business WHERE Business_Name = '" + businessName + "'";
            List<string> business = new List<string>();
            command = new SqlCommand(sqlSelect, connect);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                string output = reader.GetValue(0) + "," + reader.GetValue(2);
                business.Add(output);
            }
            connect.Close();
            return business;
        }

        //display all records of selected table with condition
        public List<string> displaySelect(string tablename, List<string> id)
        {
            connect.Open();
            string sqlSelect = "SELECT * FROM " + tablename + " WHERE ";
            List<string> result = new List<string>();
            if(tablename == "GRAPE")
            {
                sqlSelect += "Grpae_ID LIKE '" + id[0] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3);
                    result.Add(output);
                }
            }
            else if(tablename == "WINE")
            {
                sqlSelect += "Wine_ID LIKE '" + id[0] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4);
                    result.Add(output);
                }
            }
            else if(tablename == "HARVEST")
            {
                sqlSelect += "Harvest_ID LIKE '" + id[0] + "' AND WHERE Grape_ID LIKE '" + id[1] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4) + "," + reader.GetValue(5);
                    result.Add(output);
                }
            }
            else if(tablename == "STOCK")
            {
                sqlSelect += "Stock_ID LIKE '" + id[0] + "' AND WHERE Wine_ID LIKE '" + id[1] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4) + "," + reader.GetValue(5) + "," + reader.GetValue(6);
                    result.Add(output);
                }
            }
            else if(tablename == "WINE_PRODUCTION")
            {
                sqlSelect += "Wine_ID LIKE '" + id[0] + "' AND WHERE Harvest_ID LIKE '" + id[1] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4);
                    result.Add(output);
                }
            }
            else if(tablename == "SALES_ORDER")
            {
                sqlSelect += "Sales_Order_ID LIKE '" + id[0] + "' AND Busines_ID LIKE '" + id[1] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) + "," + reader.GetValue(4) + "," + reader.GetValue(5);
                    result.Add(output);
                }
            }
            else if(tablename == "BUSINESS")
            {
                sqlSelect += "Business_ID LIKE '" + id[0] + "' AND Address_ID LIKE '" + id[1] + "'";
                command = new SqlCommand(sqlSelect, connect);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    string output = reader.GetValue(0) + "," + reader.GetValue(1) + "," + reader.GetValue(2) + "," + reader.GetValue(3) ;
                    result.Add(output);
                }
            }
            
            connect.Close();
            return result;
        }


        //edit the information of a certain stock item or business information
       /* public void editGrapes(string tableName, List<string> info, string paramater)
        {
            connect.Open();
            
            connect.Close();
        }*/
    }
}