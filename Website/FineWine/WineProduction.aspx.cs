using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FineWine
{
    public partial class WineProduction : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!PostBack)
            {
                MultiView1.SetActiveView(Editview);
            }
        }

        protected void btnEditView_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Editview);
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            MultiView1.SetActiveView(Summary);
        }

        protected void gvWineProduction_SelectedIndexChanged(object sender, EventArgs e)
        {


        }

        protected void btnDisplayWineProd_Click(object sender, EventArgs e)
        {

        }
    }
}