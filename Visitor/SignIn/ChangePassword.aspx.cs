using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class ChangePassword : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {
        if (txtCPwd.Text == txtPwd.Text)
        {
            obj.WriteData("update Login set Pwd='" + txtPwd.Text + "' where Uname='" + (String)Session["uname"] + "'");
            Response.Write(obj.msgbox("Password Updated"));
            Server.Transfer("SignIn.aspx");
        }
        else
        {
            Response.Write(obj.msgbox("Password Mismatch"));
        }
    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }
}