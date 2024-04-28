using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_TPA : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    protected void Cloud1_Click(object sender, EventArgs e)
    {
        Session["cloud"] = 1;
        Response.Redirect("~/Admin/CreateDeleteTPA1.aspx");
    }
    protected void cloud2_Click(object sender, EventArgs e)
    {
        Session["cloud"] = 2;
        Response.Redirect("~/Admin/CreateDeleteTPA2.aspx");
    }
    protected void cloud3_Click(object sender, EventArgs e)
    {
        Session["cloud"] = 3;
        Response.Redirect("~/Admin/CreateDeleteTPA3.aspx");
    }
}