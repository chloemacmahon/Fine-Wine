using System;
using System.IO;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FineWineUtil
{

	/*
	
	INSERT ADD DELETE CODE

	I coded this to be called to modify data in the database.

	*/

	public static class Insert_Add_Delete_Code
	{

		/* G R A P E S */

		// coding to add a new grape
		public static void AddNewGrape(string name, string grape_type, string description, string connection)
		{
			string grape_id = "";
			if (name.Length >= 4)
			{
				grape_id = name.Substring(0, 4);
			}
			else
			{
				grape_id = name;
				for (int i = 0; i < (4 - grape_id.Length); i++)
				{
					grape_id += "x";
				}
			}
			grape_id = grape_id.ToLower();
			Random r = new Random();
			grape_id += r.Next(0, 10).ToString();
			grape_id += r.Next(0, 10).ToString();
			grape_id += r.Next(0, 10).ToString();
			grape_id += r.Next(0, 10).ToString();

			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO GRAPE (Grape_ID, Name, Grape_Type, Description) VALUES (@ID, @NAME, @TYPE, @DESC)", c.connection);
				cmd.Parameters.AddWithValue("@ID", grape_id);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.Parameters.AddWithValue("@TYPE", grape_type);
				cmd.Parameters.AddWithValue("@DESC", description);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Grape (" + grape_id + ") successfully added to the DataBase");
		}

		// coding to update a grape entirely
		public static void UpdateEntireGrape(string grape_id, string name, string grape_type, string description, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE GRAPE SET Name=@NAME, Grape_Type=@TYPE, Description=@DESC WHERE (Grape_ID='" + grape_id + "')", c.connection);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.Parameters.AddWithValue("@TYPE", grape_type);
				cmd.Parameters.AddWithValue("@DESC", description);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Grape (" + grape_id + ") successfully updated in the DataBase");
		}

		// coding to update grape name
		public static void UpdateEntireGrape(string grape_id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE GRAPE SET Name=@NAME WHERE (Grape_ID='" + grape_id + "')", c.connection);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Grape (" + grape_id + ") successfully update in the DataBase");
		}

		// coding to update grape type
		public static void UpdateGrapeType(string grape_id, string grape_type, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE GRAPE SET Grape_Type=@TYPE WHERE (Grape_ID='" + grape_id + "')", c.connection);
				cmd.Parameters.AddWithValue("@TYPE", grape_type);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Grape (" + grape_id + ") successfully update in the DataBase");
		}

		// coding to update grape description
		public static void UpdateGrapeDescription(string grape_id, string description, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE GRAPE SET Description=@DESC WHERE (Grape_ID='" + grape_id + "')", c.connection);
				cmd.Parameters.AddWithValue("@DESC", description);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Grape (" + grape_id + ") successfully update in the DataBase");
		}

		// delete grape
		public static void DeleteGrape(string id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM GRAPE WHERE (Grape_ID='" + id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Grape (" + id + ") successfully deleted from the DataBase");
		}


		/* W I N E S */

		// coding to add a new wine
		public static void AddNewWine(string grape_id, string name, string wine_type, string description, string connection)
		{
			string id = "";
			if (name.Length >= 4)
			{
				id = name.Substring(0, 4);
			}
			else
			{
				id = name;
				for (int i = 0; i < (4 - id.Length); i++)
				{
					id += "x";
				}
			}
			id = id.ToLower();
			Random r = new Random();
			id += r.Next(0, 10).ToString();
			id += r.Next(0, 10).ToString();
			id += r.Next(0, 10).ToString();
			id += r.Next(0, 10).ToString();

			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO WINE (Wine_ID, Grape_ID, Name, Wine_Type, Description) VALUES (@ID, @G_ID, @NAME, @TYPE, @DESC)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@G_ID", grape_id);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.Parameters.AddWithValue("@TYPE", wine_type);
				cmd.Parameters.AddWithValue("@DESC", description);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully added to the DataBase");
		}

		// update entire wine
		public static void UpdateEntireWine(string id, string grape_id, string name, string wine_type, string description, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE WINE SET Grape_ID=@G_ID, Name=@NAME, Wine_Type=@TYPE, Description=@DESC WHERE (Wine_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@G_ID", grape_id);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.Parameters.AddWithValue("@TYPE", wine_type);
				cmd.Parameters.AddWithValue("@DESC", description);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully updated in the DataBase");
		}

		// update wine grape id
		public static void UpdateWineGrapeID(string id, string grape_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE WINE SET Grape_ID=@G_ID WHERE (Wine_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@G_ID", grape_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully updated in the DataBase");
		}

		// update wine name
		public static void UpdateWineName(string id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE WINE SET Name=@NAME WHERE (Wine_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully updated in the DataBase");
		}

		// update wine type
		public static void UpdateWineType(string id, string wine_type, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE WINE SET Wine_Type=@TYPE WHERE (Wine_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@TYPE", wine_type);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully updated in the DataBase");
		}

		// update wine description
		public static void UpdateWineDescription(string id, string description, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE WINE SET Description=@DESC WHERE (Wine_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@DESC", description);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully updated in the DataBase");
		}

		// delete wine
		public static void DeleteWine(string id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM WINE WHERE (Wine_ID='" + id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine (" + id + ") successfully deleted from the DataBase");
		}


		/* H A R V E S T */

		// add a new harvest
		public static void AddNewHarvest(string grape_id, int amount_planted, DateTime date_planted, int est_harvest, int act_harvest, string connection)
		{
			string id = "";
			if (grape_id.Length >= 4)
			{
				id = grape_id.Substring(0, 4);
			}
			else
			{
				id = grape_id;
				for (int i = 0; i < (4 - id.Length); i++)
				{
					id += "x";
				}
			}
			id = id.ToLower();
			id += date_planted.Year.ToString() + "_";
			Random r = new Random();
			id += r.Next(0, 10).ToString();
			id += r.Next(0, 10).ToString();
			id += r.Next(0, 10).ToString();

			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO HARVEST VALUES (@ID, @G_ID, @AMT, @DATE, @EST, @ACT)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@G_ID", grape_id);
				cmd.Parameters.AddWithValue("@AMT", amount_planted);
				cmd.Parameters.AddWithValue("@DATE", date_planted.Date.ToString());
				cmd.Parameters.AddWithValue("@EST", est_harvest);
				cmd.Parameters.AddWithValue("@ACT", act_harvest);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully added to the DataBase");
		}

		// update entire harvest
		public static void UpdateEntireHarvest(string id, string grape_id, int amount_planted, DateTime date_planted, int est_harvest, int act_harvest, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE HARVEST SET Grape_ID=@G_ID, Amount_Planted=@AMT, Date_Planted=@DATE, Estimated_Harvest=@EST, Actual_Harvest=@ACT WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@G_ID", grape_id);
				cmd.Parameters.AddWithValue("@AMT", amount_planted);
				cmd.Parameters.AddWithValue("@DATE", date_planted.Date.ToString());
				cmd.Parameters.AddWithValue("@EST", est_harvest);
				cmd.Parameters.AddWithValue("@ACT", act_harvest);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully updated in the DataBase");
		}

		// update harvest grape id
		public static void UpdateHarvestGrapeID(string id, string grape_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE HARVEST SET Grape_ID=@G_ID WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@G_ID", grape_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully updated in the DataBase");
		}

		// update harvest amount planted
		public static void UpdateHarvestAmountPlanted(string id, int amount, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE HARVEST SET Amount_Planted=@VAL WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", amount);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully updated in the DataBase");
		}

		// update harvest date planted
		public static void UpdateHarvestDatePlanted(string id, DateTime date_planted, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE HARVEST SET Date_Planted=@VAL WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", date_planted.Date.ToString());
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully updated in the DataBase");
		}

		// update harvest estimated harvest
		public static void UpdateHarvestEstimatedHarvest(string id, int est, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE HARVEST SET Estimated_Harvest=@VAL WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", est);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully updated in the DataBase");
		}

		// update harvest actual harvest
		public static void UpdateHarvestActualHarvest(string id, int actual_harvest, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE HARVEST SET Actual_Harvest=@VAL WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", actual_harvest);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Havrvest (" + id + ") successfully updated in the DataBase");
		}

		// delete harvest
		public static void DeleteHarvest(string id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM Harvest WHERE (Harvest_ID='" + id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Harvest (" + id + ") successfully deleted from the DataBase");
		}


		/* W I N E   P R O D U C T I O N */

		// add a new wine production
		public static void AddNewWineProduction(string wine_id, string harvest_id, int est_prod, int act_prod, int mat_period, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO WINE_PRODUCTION VALUES (@WINE_ID, @HARVEST_ID, @EST, @ACT, @MAT)", c.connection);
				cmd.Parameters.AddWithValue("@WINE_ID", wine_id);
				cmd.Parameters.AddWithValue("@HARVEST_ID", harvest_id);
				cmd.Parameters.AddWithValue("@EST", est_prod);
				cmd.Parameters.AddWithValue("@ACT", act_prod);
				cmd.Parameters.AddWithValue("@MAT", mat_period);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine Production successfully added to the DataBase");
		}

		// update entire wine production
		public static void UpdateEntireWineProduction(string wine_id, string harvest_id, int est_prod, int act_prod, int mat_period, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE WINE_PRODUCTION SET Wine_ID=@WINE_ID, Harvest_ID=@HARVEST_ID, Estimated_Production=@EST, Actual_Production=@ACT, Maturation_Period=@MAT WHERE (Wine_ID='"+wine_id+"') AND (Harvest_ID='"+harvest_id+"')", c.connection);
				cmd.Parameters.AddWithValue("@WINE_ID", wine_id);
				cmd.Parameters.AddWithValue("@HARVEST_ID", harvest_id);
				cmd.Parameters.AddWithValue("@EST", est_prod);
				cmd.Parameters.AddWithValue("@ACT", act_prod);
				cmd.Parameters.AddWithValue("@MAT", mat_period);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine Production successfully added to the DataBase");
		}

		// delete wine production
		public static void DeleteWineProducion(string wine_id, string harvest_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM WINE_PRODUCTION WHERE (Wine_ID='"+wine_id+"') AND (Harvest_ID='" + harvest_id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Wine production successfully deleted from the DataBase");
		}


		/* S T O C K */

		// add a new stock
		public static void AddNewStock(string wine_id, DateTime year, int stock_on_hand, int sold, double unit_price, double selling_price, string connection)
		{
			string id = "";
			if (wine_id.Length >= 4)
			{
				id = wine_id.Substring(0, 4);
			}
			else
			{
				id = wine_id;
				for (int i = 0; i < (4 - id.Length); i++)
				{
					id += "x";
				}
			}
			id = id.ToLower();
			id += year.Year.ToString();

			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO STOCK VALUES (@ID, @WINE_ID, @YEAR, @STOCK, @SOLD, @UNIT_PRICE, @SELL_PRICE)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@WINE_ID", wine_id);
				cmd.Parameters.AddWithValue("@YEAR", year.Date.ToString());
				cmd.Parameters.AddWithValue("@STOCK", stock_on_hand);
				cmd.Parameters.AddWithValue("@SOLD", sold);
				cmd.Parameters.AddWithValue("@UNIT_PRICE", unit_price);
				cmd.Parameters.AddWithValue("@SELL_PRICE", selling_price);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully added to the DataBase");
		}

		// update entire stock
		public static void UpdateEntireStock(string id, string wine_id, DateTime year, int stock_on_hand, int sold, double unit_price, double selling_price, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Wine_ID=@WINE_ID, Production_Year=@YEAR, Stock_On_Hand=@STOCK, Stock_Sold=@SOLD, Unit_Price=@UNIT_PRICE, Selling_Price=@SELL_PRICE WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@WINE_ID", wine_id);
				cmd.Parameters.AddWithValue("@YEAR", year.Date.ToString());
				cmd.Parameters.AddWithValue("@STOCK", stock_on_hand);
				cmd.Parameters.AddWithValue("@SOLD", sold);
				cmd.Parameters.AddWithValue("@UNIT_PRICE", unit_price);
				cmd.Parameters.AddWithValue("@SELL_PRICE", selling_price);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// update stock wine id
		public static void UpdateStockWineID(string id, string wine_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Wine_ID=@WINE_ID WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@WINE_ID", wine_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// update stock production year
		public static void UpdateStockProductionYear(string id, DateTime year, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Production_Year=@VAL WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", year.Date.ToString());
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// update stock stock on hand
		public static void UpdateStockStockOnHand(string id, int stock_on_hand, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Stock_On_Hand=@VAL WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", stock_on_hand);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// update stock stock sold
		public static void UpdateStockStockSold(string id, int sold, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Stock_Sold=@VAL WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", sold);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// update stock unit price
		public static void UpdateStockUnitPrice(string id, double unit_price, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Unit_Price=@VAL WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", unit_price);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// update stock selling price
		public static void UpdateStockSellingPrice(string id, double selling_price, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE STOCK SET Selling_Price=@VAL WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", selling_price);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully updated in the DataBase");
		}

		// delete stock
		public static void DeleteStock(string id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM STOCK WHERE (Stock_ID='" + id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id + ") successfully deleted from the DataBase");
		}


		/* S U B U R B */

		// add new suburb
		public static void AddNewSuburb(int id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO SUBURB VALUES (@ID, @NAME)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Suburb (" + id.ToString() + ") successfully added to the DataBase");
		}

		// update suburb name
		public static void UpdateSuburbName(int id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE SUBURB SET Name=@NAME WHERE (Suburb_ID='"+id+"')", c.connection);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Suburb (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// delete suburb
		public static void DeleteSuburb(int id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM SUBURB WHERE (Suburb_ID=" + id.ToString() + ")", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Stock (" + id.ToString() + ") successfully deleted from the DataBase");
		}


		/* C I T Y   T O W N */

		// add new city town
		public static void AddNewCityTown(int id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO CITY_TOWN VALUES (@ID, @NAME)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("City Town (" + id.ToString() + ") successfully added to the DataBase");
		}

		// update city town name
		public static void UpdateCityTownName(int id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE CITY_TOWN SET Name=@NAME WHERE (City_Town_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@NAME", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("City Town (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// delete city town
		public static void DeleteCityTown(int id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM CITY_TOWN WHERE (City_Town_ID=" + id.ToString() + ")", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("City Town (" + id.ToString() + ") successfully deleted from the DataBase");
		}


		/* A D D R E S S */

		// add new address
		public static void AddNewAddress(int id, int suburb_id, int city_id, int street_no, string street_name, string zip, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO ADDRESS VALUES (@ID, @SUB_ID, @CITY_ID, @STREET_NO, @STREET_NAME, @ZIP)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@SUB_ID", suburb_id);
				cmd.Parameters.AddWithValue("@CITY_ID", city_id);
				cmd.Parameters.AddWithValue("@STREET_NO", street_no);
				cmd.Parameters.AddWithValue("@STREET_NAME", street_name);
				cmd.Parameters.AddWithValue("@ZIP", zip);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully added to the DataBase");
		}

		// update address suburb id
		public static void UpdateAddressSuburbID(int id, int suburb_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE ADDRESS SET Suburb_ID=@VAL WHERE (Address_ID=" + id.ToString() + ")", c.connection);
				cmd.Parameters.AddWithValue("@VAL", suburb_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// update address city town id
		public static void UpdateAddressCityTownID(int id, int city_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE ADDRESS SET City_Town_ID=@VAL WHERE (Address_ID=" + id.ToString() + ")", c.connection);
				cmd.Parameters.AddWithValue("@VAL", city_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// update address street number
		public static void UpdateAddressStreetNumber(int id, int street_no, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE ADDRESS SET Street_Number=@VAL WHERE (Address_ID=" + id.ToString() + ")", c.connection);
				cmd.Parameters.AddWithValue("@VAL", street_no);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// update address street name
		public static void UpdateAddressStreetName(int id, string street_name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE ADDRESS SET Street_Name=@VAL WHERE (Address_ID=" + id.ToString() + ")", c.connection);
				cmd.Parameters.AddWithValue("@VAL", street_name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// update address zip code
		public static void UpdateAddressZipCode(int id, string zip, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE ADDRESS SET Zip_Code=@VAL WHERE (Address_ID=" + id.ToString() + ")", c.connection);
				cmd.Parameters.AddWithValue("@VAL", zip);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully updated in the DataBase");
		}

		// delete address
		public static void DeleteAddress(int id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM ADDRESS WHERE (Address_ID=" + id.ToString() + ")", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Address (" + id.ToString() + ") successfully deleted from the DataBase");
		}


		/* B U S I N E S S */

		// add new business
		public static void AddNewBusiness(string id, int address_id, string business_name, string password, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO BUSINESS VALUES (@ID, @ADDRESS_ID, @NAME, @PASSWORD)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@ADDRESS_ID", address_id);
				cmd.Parameters.AddWithValue("@NAME", business_name);
				cmd.Parameters.AddWithValue("@PASSWORD", password);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Business (" + id + ") successfully added to the DataBase");
		}

		// update business address id
		public static void UpdateBusinessAddressID(string id, int address_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE BUSINESS SET Address_ID=@VAL WHERE (Business_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Business (" + id + ") successfully updated in the DataBase");
		}

		// update business business name
		public static void UpdateBusinessBusinessName(string id, string name, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE BUSINESS SET Business_Name=@VAL WHERE (Business_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", name);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Business (" + id + ") successfully updated in the DataBase");
		}

		// update business password
		public static void UpdateBusinessPassword(string id, string password, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE BUSINESS SET Password=@VAL WHERE (Business_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", password);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Business (" + id + ") successfully updated in the DataBase");
		}

		// delete business
		public static void DeleteBusiness(string id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM BUSINESS WHERE (Business_ID='" + id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Business (" + id + ") successfully deleted from the DataBase");
		}


		/* S A L E S   O R D E R */

		// add new sales order
		public static void AddNewSalesOrder(string id, string business_id, DateTime sales_date, DateTime sales_time, int qty, double total, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO SALES_ORDER (@ID, @BUSINESS_ID, @SALES_DATE, @SALES_TIME, @QTY, @TOTAL)", c.connection);
				cmd.Parameters.AddWithValue("@ID", id);
				cmd.Parameters.AddWithValue("@BUSINESS_ID", business_id);
				cmd.Parameters.AddWithValue("@SALES_DATE", sales_date.Date.ToString());
				cmd.Parameters.AddWithValue("@SALES_TIME", sales_time.TimeOfDay.ToString());
				cmd.Parameters.AddWithValue("@QTY", qty);
				cmd.Parameters.AddWithValue("@TOTAL", total);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully added to the DataBase");
		}

		// update sales order business id
		public static void UpdateSalesOrderBusinessID(string id, string business_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE SALES_ORDER SET Business_ID=@VAL WHERE (Sales_Order_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", business_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully updated in the DataBase");
		}

		// update sales order sales date
		public static void UpdateSalesOrderSalesDate(string id, DateTime sales_date, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE SALES_ORDER SET Sales_Date=@VAL WHERE (Sales_Order_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", sales_date.Date.ToString());
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully updated in the DataBase");
		}

		// update sales order sales time
		public static void UpdateSalesOrderSalesTime(string id, DateTime sales_time, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE SALES_ORDER SET Sales_Time=@VAL WHERE (Sales_Order_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", sales_time.TimeOfDay.ToString());
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully updated in the DataBase");
		}

		// update sales order quantity bought
		public static void UpdateSalesOrderQuantityBought(string id, int qty, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE SALES_ORDER SET Quantity_Bought=@VAL WHERE (Sales_Order_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", qty);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully updated in the DataBase");
		}

		// update sales order sales total
		public static void UpdateSalesOrderSalesTotal(string id, double total, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("UPDATE SALES_ORDER SET Sales_Total=@VAL WHERE (Sales_Order_ID='" + id + "')", c.connection);
				cmd.Parameters.AddWithValue("@VAL", total);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully updated in the DataBase");
		}

		// delete sales order
		public static void DeleteSalesOrder(string id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM SALES_ORDER WHERE (Sales_Order_ID='" + id + "')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales order (" + id + ") successfully deleted from the DataBase");
		}


		/* S A L E S */

		// add new sales
		public static void AddNewSales(string sales_order_id, string stock_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("INSERT INTO SALES (@SALES_ORDER_ID, @STOCK_ID)", c.connection);
				cmd.Parameters.AddWithValue("@SALES_ORDER_ID", sales_order_id);
				cmd.Parameters.AddWithValue("@STOCK_ID", stock_id);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales successfully added to the DataBase");
		}

		// delete sales
		public static void DeleteSales(string sales_order_id, string stock_id, string connection)
		{
			sqlControl c = new sqlControl();
			c.connectDatabaseStr(connection);

			try
			{
				c.open();
				SqlCommand cmd = new SqlCommand("DELETE FROM SALES WHERE (Sales_Order_ID='" + sales_order_id + "') AND (Stock_ID='"+stock_id+"')", c.connection);
				cmd.ExecuteNonQuery();
				c.close();
			}
			catch (SqlException error)
			{
				messages.errorInternal("SQL Error:\n\n" + error.Message);
				return;
			}

			messages.info("Sales successfully deleted from the DataBase");
		}
	}

	/*
	
	SQL CONTROL

	I coded this class to make working with the database easier and to make
	less code required to do what would normally require more code.

	*/

	public class sqlControl // management of sql and database strictly
	{

		public SqlConnection connection;
		public SqlDataAdapter adapter;
		public DataSet dataSet;
		public string connectionString = "";
		public bool connected = false;
		public sqlVisual visual;

		// initialization of the sql control.
		public sqlControl()
		{
			connection = new SqlConnection();
			adapter = new SqlDataAdapter();
			dataSet = new DataSet();
			connectionString = "";
			connected = false;
			sqlVisual visual = new sqlVisual(this);
		}

		/*
		private string buildConnectionString(string databaseFilename = "database.mdf")
		{
			connectionString = "";
			string path = Application.StartupPath + "\\" + databaseFilename;
			if (!File.Exists(path))
			{
				messages.errorInternal("The database file '" + databaseFilename + "' could not be found.");
			}
			connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + path + ";Integrated Security=True";
            return connectionString;
		}
		*/

		/*
		public void connectDatabase(string databaseFilename = "database.mdf")
		{
			connection = new SqlConnection(buildConnectionString(databaseFilename));
			connected = false;
			try
			{
				connection.Open();
			}
			catch (Exception)
			{
				messages.errorInternal("Unable to connect to the database '" + databaseFilename + "'");
				return;
			}
			connected = true;
			connection.Close();

		}
		*/

		// external method for connecting the database with a pre built connection string.
		public void connectDatabaseStr(string connection_string)
		{
			connection = new SqlConnection(connection_string);
			connected = false;
			try
			{
				connection.Open();
			}
			catch (Exception)
			{
				messages.errorInternal("Unable to connect to the database using connection-string '" + connection_string + "'");
				return;
			}
			connected = true;
			connection.Close();

		}

		public bool containsItem(object item, string field, string table)
        {
            bool b = false;
            foreach (object o in getFieldItems(field, table))
            {
                if (o == item)
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public bool containsString(string item, string field, string table)
        {
            bool b = false;
            foreach (string s in getFieldStrings(field, table))
            {
                if (s.ToLower() == item.ToLower())
                {
                    b = true;
                    break;
                }
            }
            return b;
        }

        public string getFieldString(string field, string table, string where = "")
        {
            string val = "";
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table + (where.Length > 0 ? " WHERE " + where : ""));
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                val = r[field].ToString();
            }
            close();
            return val;
        }

        public int getFieldInt(string field, string table, string where = "")
        {
            int val = 0;
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table + (where.Length > 0 ? " WHERE " + where : ""));
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read())
            {
                val = int.Parse(r[field].ToString());
            }
            close();
            return val;
        }

        public bool compareFieldString (string value, string field, string table, bool caseSensitive = true, string where = "")
        {
            bool b = false;
            if (caseSensitive)
            {
                b = (value == getFieldString(field, table, where));
            }
            else
            {
                b = (value.ToLower() == getFieldString(field, table, where).ToLower());
            }
            return b;
        }

        public void open()
        {
            if (connection.State == ConnectionState.Closed)
            {
                connection.Open();
            }
        }

        public void close()
        {
            if (connection.State == ConnectionState.Open)
            {
                connection.Close();
            }
        }

        public object[] getFieldItems(string field, string table, string where = "")
        {
            List<object> items = new List<object>();
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table + (where.Length > 0 ? " WHERE " + where : ""));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                items.Add(r[field]);
            }
            close();
            return items.ToArray();
        }

        public string[] getFieldStringsWhere(string field, string table, string where = "")
        {
            List<string> items = new List<string>();
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table + (where.Length > 0 ? " WHERE " + where : ""));
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                items.Add(r[field].ToString());
            }
            close();
            return items.ToArray();
        }

        public string[] getFieldStrings(string field, string table)
        {
            List<string> items = new List<string>();
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                items.Add(r[field].ToString());
            }
            close();
            return items.ToArray();
        }

        public int getRecordCount(string table)
        {
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table);
            SqlDataReader r = cmd.ExecuteReader();
            int count = 0;
            while (r.Read())
            {
                count++;
            }
            close();
            return count;
        }

        public int getRecordCountWhere(string table, string where = "")
        {
            open();
            SqlCommand cmd = getSqlCommand("SELECT * FROM " + table + " WHERE " + where);
            SqlDataReader r = cmd.ExecuteReader();
            int count = 0;
            while (r.Read())
            {
                count++;
            }
            close();
            return count;
        }

        public SqlCommand getSqlCommand (string cmd)
        {
            return new SqlCommand(cmd, connection);
        }

        public string buildSelect(string fields, string table)
        {
            return "SELECT " + fields + " FROM " + table;
        }

        public string buildSelectWhere(string fields, string table, string conditions)
        {
            return "SELECT " + fields + " FROM " + table + " WHERE " + conditions;
        }

    }

	/*
	
	SQL VISUAL

	This is to be used along with the SQL CONTROL class in order to easily integrate
	the SQL CONTROL database with the user interface like visual components.

	*/

	public class sqlVisual // management of sql and database visuals
	{

		private sqlControl control;

		public sqlVisual(sqlControl sqlCtrl)
		{
			control = sqlCtrl;
		}

        public void displayGridView(string sql, DataGridView dgv)
        {
            try
            {
                if (control.connected)
                {
                    control.open();
                    control.dataSet = new DataSet();
                    control.adapter = new SqlDataAdapter(sql, control.connection);
                    control.adapter.Fill(control.dataSet, "table_data");
                    dgv.DataSource = control.dataSet;
                    dgv.DataMember = "table_data";
                    control.close();
                }
            }
            catch (SqlException sqlError)
            {
                messages.errorInternal("An SQL Error has occured:\n\n" + sqlError);
            }
        }

    }

	/*
	
	SQL HANDLING

	This class is similar to the handling class except is specifically coded for handling when
	it comes to working with SQL statements and code.

	*/

	public static class sqlHandling
	{

		public static string formatFields(string fields, string table)
		{
			string s = "";
			if (fields.Replace(" ", "") == "*")
			{
				s = "[" + table + "].*";
			}
			else
			{
				fields = fields.Replace(" ", "").Replace(",", ":").Replace(";", ":");
				List<string> l = new List<string>();
				if (fields[0].ToString() == ":")
				{
					fields = fields.Remove(0, 1);
				}
				if (fields[fields.Length - 1].ToString() != ":")
				{
					fields += ":";
				}
				while (fields.Length > 0)
				{
					string field = fields.Substring(0, fields.IndexOf(":"));
					fields = fields.Remove(0, fields.IndexOf(":") + 1);
					l.Add(field);
				}
				foreach (string field in l)
				{
					s += "[" + table + "].[" + field + "],";
				}
				if (s[s.Length - 1].ToString() == ",")
				{
					s = s.Substring(0, s.Length - 1);
				}
			}
			return s;
		}

	}

	/*
	
	SQL VISUAL OBJECTS

	This is a simple enumeration I coded to work with the SQL VISUAL class in order to
	specify types of components used, etc.

	*/

	public enum sqlVisualObjects{
		DbGrid,				// used with a datagridview
		ListT,			// used with a listbox (record items are seperated by \t)
		ListC,			// used with a listbox (record items are separated by ,)
		TextT,            // used with a string (record items are separated by \t)
		TextC           // used with a string (record items are separated by ,)
	}

	/*
	
	MESSAGES

	This is a simple class I coded to save time so that I would not have to use the
	long way of MessageBox.Show(...) when I want to show icons like the info or error icon.

	*/

	public static class messages
	{

		public static void error(string text)
		{
			MessageBox.Show(text, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

		public static void errorInternal(string text)
		{
			MessageBox.Show(text, "Error (Internal)", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}

        public static void warning(string text)
        {
            MessageBox.Show(text, "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        public static void info(string text)
        {
            MessageBox.Show(text, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public static bool confirm(string text)
		{
			return (MessageBox.Show(text, "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes);
		}

	}

	/*
	
	HANDLING

	I coded this class to make string handling less work and to make certain actions easier to do
	without needing to do too much thinking.

	*/

	public static class handling
    {

        public static string symbols = "~`!@#$%^&*()_+-={}[]\\|:;\"'<>?,./ ";
        public static string symbolsText = "~`!@#$%^&*()_+-={}[]\\|:;\"'<>?,./";
        public static string symbolsEmail = "~`!#$%^&*()_+-={}[]\\|:;\"'<>?,/ ";
        public static string letters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ ";
        public static string lettersText = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static string numbers = "1234567890";
        public static string[] months = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };

        public static string path ()
        {
            return Application.StartupPath + "\\";
        }

        public static int yearFromDigits (int digits)
        {
            int baseAmount = 2000;
            if ((DateTime.Now.Year - 2000) < digits)
            {
                baseAmount = 1900;
            }
            return baseAmount + digits;
        }

        public static int indexInStringArray (string[] array, string target)
        {
            int index = -1;
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] == target)
                {
                    index = i;
                    break;
                }
            }
            return index;
        }

        public static string trim (string src, string target)
        {
            string s = src;
            if (target.Length > 0)
            {
                foreach (char c in target.ToCharArray())
                {
                    s = s.Replace(c.ToString(), "");
                }
            }
            return s;
        }

        public static bool checkEmail (string email)
        {
            bool b = false;
            if (email.Length > 0)
            {
                string name = "";
                string domain = "";
                string type = "";
                if (email.Contains ("@"))
                {
                    name = email.Substring(0, email.IndexOf("@"));
                    email = email.Remove(0, name.Length + 1);
                }
                if (email.Contains ("."))
                {
                    domain = email.Substring(0, email.LastIndexOf("."));
                    email = email.Remove(0, domain.Length + 1);
                }
                type = email;
                email = "";

                if (trim(name, symbols).Length > 0 && trim(domain, symbols).Length > 0 && trim(type, symbols).Length > 0)
                {
                    b = true;
                }
            }
            return b;
        }

    }

	/*
	
	IO FILE

	I coded this class to make the use of text files and files in general easier,
	this is for use with things like saving configurations to the local machine as
	well as to save and export reports.

	*/

	public class ioFile
	{

		public string filename = "";

		public ioFile(string ffilename)
		{
			filename = ffilename.Replace ("\\", "/");
		}

		public float filesize()
		{
			FileInfo f = new FileInfo(filename);
			long size = 0;
			if (f.Exists)
			{
				size = f.Length;
			}
			return (float)size;
		}

		public string writedate()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.LastWriteTime.ToLongDateString();
			}
			return s;
		}

		public string writetime()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.LastWriteTime.ToLongTimeString();
			}
			return s;
		}

		public string accessdate()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.LastAccessTime.ToLongDateString();
			}
			return s;
		}

		public string accesstime()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.LastAccessTime.ToLongTimeString();
			}
			return s;
		}

		public string creationdate()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.CreationTime.ToLongDateString();
			}
			return s;
		}

		public string creationtime()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.CreationTime.ToLongTimeString();
			}
			return s;
		}

		public bool isreadonly()
		{
			FileInfo f = new FileInfo(filename);
			bool b = false;
			if (f.Exists)
			{
				b = f.IsReadOnly;
			}
			return b;
		}

		public string fullname()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.FullName;
			}
			return s;
		}

		public string name()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.Name;
			}
			return s;
		}

		public string extension()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.Extension;
			}
			return s;
		}

		public string directory()
		{
			FileInfo f = new FileInfo(filename);
			string s = "";
			if (f.Exists)
			{
				s = f.DirectoryName;
			}
			return s;
		}

		public FileAttributes attributes()
		{
			FileInfo f = new FileInfo(filename);
			FileAttributes a = FileAttributes.Normal;
			if (f.Exists)
			{
				a = f.Attributes;
			}
			return a;
		}

		public void addclassitem(string classname, string key, string value)
		{
			additem(classname + "." + key, value);
		}

		public bool hasclass(string classname)
		{
			bool b = false;
			foreach (string s in loadlines())
			{
				string c = extractkey(s);
				if (c.Contains("."))
				{
					c = c.Substring(0, c.IndexOf("."));
					if (c.ToLower() == classname.ToLower())
					{
						b = true;
						break;
					}
				}
			}
			return b;
		}

		public void removeclass(string classname)
		{
			if (hasclass(classname))
			{
				List<string> ls = new List<string>();
				foreach (string s in loadlines())
				{
					string c = extractkey(s);
					if (c.Contains("."))
					{
						c = c.Substring(0, c.IndexOf("."));
						if (c.ToLower() != classname.ToLower())
						{
							ls.Add(s);
						}
					}
				}
				writelines(ls.ToArray());
			}
		}

		public bool hasitem(string key)
		{
			bool b = false;
			foreach (string s in loadlines())
			{
				if (extractkey(s).ToLower() == key.ToLower())
				{
					b = true;
					break;
				}
			}
			return b;
		}

		public string getitem(string key)
		{
			string item = "";
			foreach (string s in loadlines())
			{
				if (extractkey(s).ToLower() == key.ToLower())
				{
					item = s;
					break;
				}
			}
			return item;
		}

		public void additem(string key, string value)
		{
			appendline(key + "=" + value);
		}

		public void removeitem(string key)
		{
			if (hasitem(key))
			{
				List<string> ls = new List<string>();
				foreach (string s in loadlines())
				{
					if (extractkey(s).ToLower() != key.ToLower())
					{
						ls.Add(s);
					}
				}
				writelines(ls.ToArray());
			}
		}

		public void removeclassitem(string classname, string key)
		{
			if (hasitem(classname + "." + key))
			{
				removeitem(classname + "." + key);
			}
		}

		public void updateitem(string key, string value)
		{
			if (hasitem(key))
			{
				List<string> ls = new List<string>();
				foreach (string s in loadlines())
				{
					if (extractkey(s).ToLower() != key.ToLower())
					{
						ls.Add(s);
					}
					else
					{
						ls.Add(key + "=" + value);
					}
				}
				writelines(ls.ToArray());
			}
		}

		public void updateclassitem(string classname, string key, string value)
		{
			if (hasitem(classname + "." + key))
			{
				List<string> ls = new List<string>();
				foreach (string s in loadlines())
				{
					if (extractkey(s).ToLower() != (classname + "." + key).ToLower())
					{
						ls.Add(s);
					}
					else
					{
						ls.Add(classname + "." + key + "=" + value);
					}
				}
				writelines(ls.ToArray());
			}
		}

		public int getclasscount()
		{
			return getclasses().Length;
		}

		public string[] getclasses()
		{
			string[] lines = loadlines();
			List<string> classes = new List<string>();
			foreach (string line in lines)
			{
				string c = extractkey(line);
				if (c.Contains("."))
				{
					c = c.Substring(0, c.IndexOf(".")).ToLower();
					if (!classes.Contains(c))
					{
						classes.Add(c);
					}
				}
			}
			return classes.ToArray();
		}

		public string getitemvalue(string key)
		{
			string value = "";
			if (hasitem(key))
			{
				string item = getitem(key);
				value = extractvalue(item);
			}
			return value;
		}

		public string getclassitemvalue(string classname, string key)
		{
			string value = "";
			if (hasitem(classname + "." + key))
			{
				string item = getitem(classname + "." + key);
				value = extractvalue(item);
			}
			return value;
		}

		public float getitemvalueasfloat(string key)
		{
			string value = "";
			if (hasitem(key))
			{
				string item = getitem(key);
				value = extractvalue(item);
			}
			float val = 0;
			bool b = float.TryParse(value, out val);
			return val;
		}

		public int getitemvalueasint(string key)
		{
			string value = "";
			if (hasitem(key))
			{
				string item = getitem(key);
				value = extractvalue(item);
			}
			int val = 0;
			bool b = int.TryParse(value, out val);
			return val;
		}

		public float getclassitemvalueasfloat(string classname, string key)
		{
			string value = "";
			if (hasitem(classname + "." + key))
			{
				string item = getitem(classname + "." + key);
				value = extractvalue(item);
			}
			float val = 0;
			bool b = float.TryParse(value, out val);
			return val;
		}

		public int getclassitemvalueasint(string classname, string key)
		{
			string value = "";
			if (hasitem(classname + "." + key))
			{
				string item = getitem(classname + "." + key);
				value = extractvalue(item);
			}
			int val = 0;
			bool b = int.TryParse(value, out val);
			return val;
		}

		public bool getitemvalueasbool(string key)
		{
			string value = "";
			if (hasitem(key))
			{
				string item = getitem(key);
				value = extractvalue(item);
			}
			bool b = false;
			switch (value.ToLower())
			{
				case "true":
					b = true;
					break;
				case "t":
					b = true;
					break;
				case "yes":
					b = true;
					break;
				case "y":
					b = true;
					break;
				case "1":
					b = true;
					break;
				case "+":
					b = true;
					break;
				case "positive":
					b = true;
					break;
				case "p":
					b = true;
					break;
				default:
					b = false;
					break;
			}
			return b;
		}

		public bool getclassitemvalueasbool(string classname, string key)
		{
			string value = "";
			if (hasitem(classname + "." + key))
			{
				string item = getitem(classname + "." + key);
				value = extractvalue(item);
			}
			bool b = false;
			switch (value.ToLower())
			{
				case "true":
					b = true;
					break;
				case "t":
					b = true;
					break;
				case "yes":
					b = true;
					break;
				case "y":
					b = true;
					break;
				case "1":
					b = true;
					break;
				case "+":
					b = true;
					break;
				case "positive":
					b = true;
					break;
				case "p":
					b = true;
					break;
				default:
					b = false;
					break;
			}
			return b;
		}

		public string extractvalue(string item)
		{
			string value = "";
			value = item.Remove(0, item.IndexOf("=") + 1);
			return value;
		}

		public string extractkey(string item)
		{
			string key = "";
			key = item.Substring(0, item.IndexOf("="));
			key = key.Replace(" ", "");
			return key;
		}

		public string loadtext()
		{
			string[] lines = loadlines();
			string s = "";
			int i = 1;
			foreach (string line in lines)
			{
				s += line;
				if (i <= lines.Length)
				{
					s += "\n";
				}
				i++;
			}
			return s;
		}

		public string[] loadlines()
		{
			//return File.ReadAllLines (filename);
			List<string> ls = new List<string>();
			if (exists())
			{
				FileStream fstream = new FileStream(filename, FileMode.Open);
				StreamReader freader = new StreamReader(fstream);
				while (!freader.EndOfStream)
				{
					string sline = freader.ReadLine();
					if (sline.Length != 0)
					{
						if (sline[0].ToString() != "#")
						{
							ls.Add(sline);
						}
					}
				}
				freader.Close();
				fstream.Close();
			}
			return ls.ToArray();
		}

		public void appendlines(string[] flines)
		{
			if (exists())
			{
				FileStream fstream = new FileStream(filename, FileMode.Append);
				StreamWriter fwriter = new StreamWriter(fstream);
				foreach (string s in flines)
				{
					fwriter.WriteLine(s);
				}
				fwriter.Close();
				fstream.Close();
			}
		}

		public void appendline(string fline)
		{
			if (exists())
			{
				FileStream fstream = new FileStream(filename, FileMode.Append);
				StreamWriter fwriter = new StreamWriter(fstream);
				fwriter.WriteLine(fline);
				fwriter.Close();
				fstream.Close();
			}
		}

		public void writelines(string[] flines)
		{
			if (exists())
			{
				string[] slines = loadlines();
				FileStream fstream = new FileStream(filename, FileMode.Create);
				StreamWriter fwriter = new StreamWriter(fstream);
				foreach (string s in flines)
				{
					fwriter.WriteLine(s);
				}
				fwriter.Close();
				fstream.Close();
			}
		}

		public void create()
		{
			if (exists())
			{
				FileStream fstream = new FileStream(filename, FileMode.Create);
				fstream.Close();
			}
			else
			{
				FileStream fstream = new FileStream(filename, FileMode.CreateNew);
				fstream.Close();
			}
		}

		public void delete()
		{
			if (exists())
			{
				FileInfo f = new FileInfo(filename);
				f.Delete();
			}
		}

		public bool exists()
		{
			return File.Exists(filename);
		}

	}

}