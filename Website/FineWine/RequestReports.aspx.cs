<<<<<<< HEAD
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineWinesWeb;
using System.IO;

namespace FineWine
{
    public partial class RequestReports : System.Web.UI.Page
    {
        Maintain objMain = new Maintain();
        //Struct for wine production
        struct wineProduction
        {
            public string wineID;
            public string harvestID;
            public string wineName;
            public int estimatedProduction;
            public int actualProduction;
            public double percentageProduced;
            public int differenceBetween;
        }
        
        public bool writeReport(List<string> toWrite, string fileName)//Filename Harvest.txt
        {
            try
            {
                string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(filepath, fileName)))
                {
                    foreach(string line in toWrite)
                    {
                        outputFile.WriteLine(line);
                    }
                }

                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool productionChartsSave()
        {
            try
            {
                System.IO.MemoryStream chartActual_Estimated = new System.IO.MemoryStream();
                string chartPath = Server.MapPath("/Estimated_Actual_Production_Chart.png");
                Chart1.SaveImage(chartPath, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
                System.IO.MemoryStream chartActual_Estimated_1 = new System.IO.MemoryStream();
                string chartPath1 = Server.MapPath("/Net_Production_Chart.png");
                Chart1.SaveImage(chartPath1, System.Web.UI.DataVisualization.Charting.ChartImageFormat.Png);
=======
﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FineWinesWeb;
using System.IO;
using System.Data;
using System.Data.SqlClient;

namespace FineWine
{
    public partial class RequestReports : System.Web.UI.Page
    {
        SQLMaintain maintain = new SQLMaintain();
        SqlConnection connect;
        SqlDataAdapter adapt;
        DataSet ds;

        public void displayWine()
        {
            
        }

        //Struct for wine production
        struct wineProduction
        {
            public string wineID;
            public string wineName;
            public int estimatedProduction;
            public int actualProduction;
            public double percentageProduced;
        }

        public bool writeReport(List<string> toWrite, string fileName)//Filename Harvest.txt
        {
            try
            {
                string filepath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
                using (StreamWriter outputFile = new StreamWriter(Path.Combine(filepath, fileName)))
                {
                    foreach(string line in toWrite)
                    {
                        outputFile.WriteLine(line);
                    }
                }

>>>>>>> Liza
                return true;
            }
            catch
            {
                return false;
            }
<<<<<<< HEAD
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> stock = objMain.displayAll("WINE_PRODUCTION");
            List<wineProduction> production = new List<wineProduction>();
            //Adds wineProduction elements into production list
            for(int i = 0; i < stock.Count(); i++)
            {
                string[] arrItems = stock.ElementAt(i).Split(','); //Splits string into seperate elements 
                wineProduction newItem = new wineProduction();
                newItem.wineID = arrItems[0];
                List<string> elements = objMain.displaySelect("WINE", arrItems.ToList());
                newItem.wineName = elements.ElementAt(0).Split(',')[2];
                newItem.harvestID = arrItems[1];
                newItem.estimatedProduction = Convert.ToInt32(arrItems[2]);
                newItem.actualProduction = Convert.ToInt32(arrItems[3]);
                newItem.percentageProduced = newItem.actualProduction / newItem.estimatedProduction * 100;
                newItem.differenceBetween = newItem.actualProduction - newItem.estimatedProduction;
                production.Add(newItem);
            }
            Chart1.Series.Add("Wine 1");
            Chart1.Series[0].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            Chart1.Series.Add("Wine 2");
            Chart1.Series[1].ChartType = System.Web.UI.DataVisualization.Charting.SeriesChartType.StackedColumn100;
            for (int i = 0; i < production.Count(); i++)
            {
                Chart1.Series[0].Points.AddY(production[i].actualProduction);
                Chart1.Series[0].Points[i].AxisLabel = production[i].wineName + "Actual ";
                Chart1.Series[1].Points.AddY(production[i].estimatedProduction);
                Chart1.Series[1].Points[i].AxisLabel = production[i].wineName + "Estimated";
            }


            Chart2.Series.Add("Net Production");
            for (int i = 0; i < production.Count(); i++)
            {
                Chart2.Series[0].Points.AddY(production[i].differenceBetween);
                Chart2.Series[0].Points[i].AxisLabel = production[i].wineName;
            }


            List<string> lines = sortProduction(production);
            for (int  i = 0;  i < lines.Count();  i++)
=======
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            connect = new SqlConnection(maintain.connectDatabase());
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> stock = maintain.wineChart();
            List<wineProduction> production = new List<wineProduction>();
            //Adds wineProduction elements into production list
            for(int i = 0; i < stock.Count(); i++)
>>>>>>> Liza
            {
                string[] arrItems = stock.ElementAt(i).Split(','); //Splits string into seperate elements 
                wineProduction newItem = new wineProduction();
                newItem.wineID = arrItems[0];
                List<string> elements = objMain.displaySelect("WINE", arrItems.ToList());
                newItem.wineName = elements.ElementAt(0).Split(',')[2];
                newItem.estimatedProduction = Convert.ToInt32(arrItems[2]);
                newItem.actualProduction = Convert.ToInt32(arrItems[3]);
                newItem.percentageProduced = newItem.actualProduction / newItem.estimatedProduction * 100;
                production.Add(newItem);
            }
            Chart1.Series.Add("Wine 1");
            Chart1.Series.Add("Wine 2");
            for (int i = 0; i < production.Count(); i++)
            {
                Chart1.Series[0].Points.AddY(production[i].actualProduction);
                Chart1.Series[0].Points[i].AxisLabel = production[i].wineName + "Actual ";
                Chart1.Series[1].Points.AddY(production[i].estimatedProduction);
                Chart1.Series[1].Points[i].AxisLabel = production[i].wineName + "Estimated";
            }
            
        } 

        private List<wineProduction> sortProduction(List<wineProduction> productions)
        {
            for (int i = 0; i < productions.Count(); i++)
            {
                  for (int j = 0; j < productions.Count(); j++)
                  {
                        switch (radSortBy.SelectedIndex)
                        {
                            case 0:
                            {
                                if (productions[i].wineName.CompareTo(productions[j].wineName) < 0)
                                {
                                    wineProduction temp = productions[i];
                                    productions[i] = productions[j];
                                    productions[j] = temp;
                                }
                                break;
                            }
                            case 1:
                            {
                                if (productions[i].actualProduction.CompareTo(productions[j].actualProduction) < 0)
                                {
                                    wineProduction temp = productions[i];
                                    productions[i] = productions[j];
                                    productions[j] = temp;
                                }
                                break;
                            }
                            case 2:
                            {
                                if (productions[i].estimatedProduction.CompareTo(productions[j].estimatedProduction) < 0)
                                {
                                    wineProduction temp = productions[i];
                                    productions[i] = productions[j];
                                    productions[j] = temp;
                                }
                                break;
                            }
                            case 3:
                            {
                                if (productions[i].percentageProduced.CompareTo(productions[j].percentageProduced) < 0)
                                {
                                    wineProduction temp = productions[i];
                                    productions[i] = productions[j];
                                    productions[j] = temp;
                                }
                                break;
                            }
                        }
                        
                  }
            }
<<<<<<< HEAD
            List<string> lines = new List<string>();
            lines.Add("Code \t Wine Name \t Actual Production \t Estimated Production \t Percentage produced \t Net production");
            for (int i = 0; i < productions.Count(); i++)
            {
                lines.Add(productions[i].wineID + "\t" + productions[i].harvestID +"\t" + productions[i].wineName + "\t" + productions[i].actualProduction + "\t" + productions[i].estimatedProduction + "\t" + productions[i].percentageProduced + "%\t" + productions[i].differenceBetween);
            }
            return lines;
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

=======
                     
            
            return productions;
>>>>>>> Liza
        }

        protected void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Chart1_Load(object sender, EventArgs e)
        {

        }
<<<<<<< HEAD

        protected void btnGenerateHarvestReports_Click(object sender, EventArgs e)
        {

        }
    }
=======
    }
>>>>>>> Liza
}