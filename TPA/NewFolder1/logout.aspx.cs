using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_logout : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        Session["cloud"] = "";
        Session["c"] = "";
        Response.Redirect("~/Tpa/TPALogin/Login.aspx");
    }
}