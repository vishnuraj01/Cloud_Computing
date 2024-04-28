using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_FileUpdate : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Bind();
        }
    }
    protected void Bind()
    {
        string SQL_SecurityOpt = "select * from Filearchieve where fowner='" + (String)Session["Uname"] + "' and fverify=1 order by Fid desc";
        obj.FillGrid(SQL_SecurityOpt, GridView1);
    }
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        if (e.CommandName == "1")
        {
            obj.PutData("delete from Filearchieve where Fid=" + e.CommandArgument.ToString());
            obj.PutData("delete from FileIndex where Fileid=" + e.CommandArgument.ToString());
            MultiCloud m = new MultiCloud();
            m.PutData_Cloud1("delete from Filearchieve1 where fid=" + e.CommandArgument.ToString());
            m.PutData_Cloud2("delete from Filearchieve2 where fid=" + e.CommandArgument.ToString());
            m.PutData_Cloud3("delete from Filearchieve3 where fid=" + e.CommandArgument.ToString());
            Response.Write(obj.msgbox("File Deleted Successfully"));
            Server.Transfer("VerifiedFileUpdate.aspx");
        }
    }
    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        Bind();
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}