using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if(Session["logged_in"] == null || (bool)Session["logged_in"] == false)
        {            
            TreeView1.Visible = false;
        }
        else
        {
            Label1.Text = "<a href=Logout.aspx > Logout</a>";
            TreeView1.Visible = true;
        }
    }
}
