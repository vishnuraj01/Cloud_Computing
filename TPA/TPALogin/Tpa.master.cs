using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;

public partial class Visitor : System.Web.UI.MasterPage
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if ((String)Session["Uname"] == "")
        {
            Session.Abandon();
            Response.Redirect("~/Visitor/SignIn/SignIn.aspx");
        }
    }
    protected void Button5_Click(object sender, EventArgs e)
    {
        FormsAuthentication.SignOut();
        Session.Abandon();
        Response.Redirect("~/Visitor/SignIn/SignIn.aspx");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Session["c"] = "1";
        Response.Redirect("~/Tpa/TPALogin/Login.aspx");
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        Session["c"] = "2";
        Response.Redirect("~/Tpa/TPALogin/Login.aspx");
    }
    protected void Button4_Click(object sender, EventArgs e)
    {
        Session["c"] = "3";
        Response.Redirect("~/Tpa/TPALogin/Login.aspx");
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/Tpa/TPALogin/Home.aspx");
    }
}
