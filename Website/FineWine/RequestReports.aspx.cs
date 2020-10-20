using System;
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
        SQLMaintain objMain = new SQLMaintain();
        SqlConnection connect;
        SqlDataAdapter adapt;
        DataSet ds;
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

        struct sales
        {
            public string salesOrderID;
            public DateTime orderDate;
            public int quantity;
            public double total;
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
        
        public void displayTop10()
        {
            List<string> elements = objMain.salesChart();
            List<sales> sold = new List<sales>();
            for (int i = 0; i < elements.Count(); i++)
            {
                string[] items = elements.ElementAt(i).Split(',');
                sales newElement = new sales();
                newElement.salesOrderID = items[0];
                newElement.orderDate = Convert.ToDateTime(items[1]);
                newElement.quantity = Convert.ToInt32(items[2]);
                newElement.total = Convert.ToDouble(items[3]);
                sold.Add(newElement);
            }

            string[] lines = sortSales(sold);
            for (int i = 0; i < 11; i++)
            {
                ListBox2.Items.Add(lines[i]);
            }

            if (writeReport(lines.ToList(), "Top10.txt"))
                ListBox2.Items.Add("Succesfully written to file");
            else
                ListBox2.Items.Add("Error writing to file");
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
                return true;
            }
            catch
            {
                return false;
            }
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(View1);
            connect = new SqlConnection(objMain.connectDatabase());
        }
        
        protected void Button1_Click(object sender, EventArgs e)
        {
            List<string> stock = objMain.wineChart();
            List<wineProduction> production = new List<wineProduction>();
            //Adds wineProduction elements into production list
            for(int i = 0; i < stock.Count(); i++)
            {
                string[] arrItems = stock.ElementAt(i).Split(','); //Splits string into seperate elements 
                wineProduction newItem = new wineProduction();
                newItem.wineID = arrItems[0];
                newItem.wineName = arrItems[1];
                newItem.harvestID = arrItems[2];
                newItem.estimatedProduction = Convert.ToInt32(arrItems[3]);
                newItem.actualProduction = Convert.ToInt32(arrItems[4]);
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
            {
                ListBox1.Items.Add(lines.ElementAt(i));
            }
            writeReport(lines, "ProductionReport.txt");
            radSortBy.ClearSelection();
            MultiView1.SetActiveView(View2);
            
        } 

        private List<string> sortProduction(List<wineProduction> productions)
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

        }
             
        protected void btnGenerateHarvestReports_Click(object sender, EventArgs e)
        {

        }

        protected void MultiView1_ActiveViewChanged(object sender, EventArgs e)
        {



        }

        protected void Button1_Click1(object sender, EventArgs e)
        {
            List<string> elements = objMain.salesChart();
            List<sales> sold = new List<sales>();
            for (int i = 0; i < elements.Count(); i++)
            {
                string[] items = elements.ElementAt(i).Split(',');
                sales newElement = new sales();
                newElement.salesOrderID = items[0];
                newElement.orderDate = Convert.ToDateTime(items[1]);
                newElement.quantity = Convert.ToInt32(items[2]);
                newElement.total = Convert.ToDouble(items[3]);
                sold.Add(newElement);
            }

            string[] lines = sortSales(sold);
            for (int i = 0; i < 11; i++)
            {
                ListBox2.Items.Add(lines[i]);
            }

            if (writeReport(lines.ToList(), "Top10.txt"))
                ListBox2.Items.Add("Succesfully written to file");
            else
                ListBox2.Items.Add("Error writing to file");         
        }

        private string[] sortSales(List<sales> sold)
        {
            for (int i = 0; i < sold.Count(); i++)
            {
                for (int j = 0; j < sold.Count(); j++)
                {
                    if (sold[i].quantity.CompareTo(sold[j].quantity) < 0)
                    {
                        sales temp = sold[i];
                        sold[i] = sold[j];
                        sold[j] = temp;
                    }
                }
            }
            string[] lines = new string[sold.Count() + 1];
            lines[0] = "Sales Order ID \t Order date \t Order quantity \t Total \t";
            for (int i = 0; i < sold.Count(); i++)
            {
                lines[i + 1] = sold.ElementAt(i).salesOrderID + "\t " + sold.ElementAt(i).orderDate.ToString() + "\t " + sold.ElementAt(i).quantity.ToString() + "\t " + sold.ElementAt(i).total.ToString();
            }
            return lines;
        }

        protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
        {
            if(RadioButtonList1.SelectedIndex == 0)
            {
                RadioButtonList1.ClearSelection();
                MultiView1.SetActiveView(View2);
            }
            else
            {
                RadioButtonList1.ClearSelection();
                displayTop10();
                MultiView1.SetActiveView(View3);
            }
        }

        protected void ListBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void Button2_Click(object sender, EventArgs e)
        {
            ListBox1.Items.Clear();
            displayTop10();
            MultiView1.SetActiveView(View3);
        }
    }
}