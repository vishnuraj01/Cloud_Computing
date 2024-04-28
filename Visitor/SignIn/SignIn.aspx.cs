using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Visitor_SignIn_SignIn : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((String)Session["utype"] == "1")
        {
            Response.Redirect("~/Admin/Home.aspx");
        }
        else if ((String)Session["utype"] == "2")
        {
            Response.Redirect("~/Tpa/TPALogin/Home.aspx");
        }
        else if ((String)Session["utype"] == "3")
        {
            Response.Redirect("~/User/UserHome.aspx");
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        string sql_login = "SELECT * FROM Login WHERE Uname='" + txtUName.Text + "' and Pwd='" + txtPwd.Text + "'";
        obj.ReadData(sql_login);
        if (obj.dr.Read())
        {
            Session["Uname"] = txtUName.Text;
            Session["Utype"] = obj.dr.GetValue(2).ToString();
            int utype = Convert.ToInt32(obj.dr.GetValue(2));
            obj.dr.Close();
            if (utype == 1)
            {
                Response.Redirect("~/Admin/Home.aspx");
            }
            else if (utype == 2)
            {
                Response.Redirect("~/Tpa/TPALogin/Home.aspx");
            }
            else if (utype == 3)
            {
                string sql_owner = "SELECT email FROM UserRegistration WHERE uname='" + txtUName.Text + "'";
                obj.ReadData(sql_owner);
                if (obj.dr.Read())
                {
                    Session["email"] = obj.dr["email"].ToString();
                    obj.dr.Close();
                }
                Response.Redirect("~/User/UserHome.aspx");
            }
        }
        else
        {
            Response.Write(obj.msgbox("invalid user"));
        }
    

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        txtUName.Text = "";
        txtPwd.Text = "";
    }
}