using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Selection
{
    public partial class Grapes : Form
    {
        public SqlConnection conn;
        public DataSet ds;
        public SqlDataAdapter adapt;

        string conString = (@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=E:\FineWines\Selection\Selection\Wines.mdf;Integrated Security=True");

        
        
        public Grapes()
        {
            InitializeComponent();
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            conn = new SqlConnection(conString);
            conn.Open();

            SqlCommand command;
            string sql;

            adapt = new SqlDataAdapter();
            ds = new DataSet();

            sql = "SELECT * FROM GrapesTable";
            command = new SqlCommand(sql, conn);

            adapt.SelectCommand = command;
            adapt.Fill(ds, "GrapesTable");

            dgvGrapes.DataSource = ds;
            dgvGrapes.DataMember = "GrapesTable";

            conn.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Grapes_Load(object sender, EventArgs e)
        {

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
