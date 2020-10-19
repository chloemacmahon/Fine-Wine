using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.IO;

namespace FineWine
{
    public partial class Harvest : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

                MultiView1.SetActiveView(Addview);

        }

        protected void btnAddView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Addview);
        }

        protected void btnDisplayAll_Click(object sender, EventArgs e)
        {
            
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Review);
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Editview);

            lbHarvests.Items.Add("");
        }

        protected void btnAdd1_Click(object sender, EventArgs e)
        {

        }
    }
}