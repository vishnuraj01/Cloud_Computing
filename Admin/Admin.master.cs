using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class student_student : System.Web.UI.MasterPage
{
    CloudComputing c = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        Response.Cache.SetNoStore();
        if ((String)Session["Uname"] == "")
        {
            Response.Redirect("~/Visitor/SignIn/SignIn.aspx");
        }
        else
        {
            if (!IsPostBack)
            {
                lblname.Text = (String)Session["Uname"];
            }
        }
    }
}