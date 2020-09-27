using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace FineWineUtil
{

    public class sqlControl // management of sql and database strictly
	{

		public SqlConnection connection;
		public SqlDataAdapter adapter;
		public DataSet dataSet;
		public string connectionString = "";
		public bool connected = false;
		public sqlVisual visual;

		public sqlControl()
		{
			connection = new SqlConnection();
			adapter = new SqlDataAdapter();
			dataSet = new DataSet();
			connectionString = "";
			connected = false;
			sqlVisual visual = new sqlVisual(this);
		}

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

	public enum sqlVisualObjects{
		DbGrid,				// used with a datagridview
		ListT,			// used with a listbox (record items are seperated by \t)
		ListC,			// used with a listbox (record items are separated by ,)
		TextT,            // used with a string (record items are separated by \t)
		TextC           // used with a string (record items are separated by ,)
	}

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