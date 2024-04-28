using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Admin_AlfilesCloud1 : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    public static DataTable dt_temp = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt_temp.Columns.Clear();
            dt_temp.Columns.Add("fowner");
            dt_temp.Columns.Add("fsubject");
            dt_temp.Columns.Add("fsizeinkb");
            dt_temp.Columns.Add("fdatetime");
            dt_temp.Columns.Add("fid");
            GridBind();
        }
    }
    protected void GridBind()
    {
        dt_temp.Rows.Clear();
        string SELECT_SQL = "select UserRegistration.ownerFName+' '+UserRegistration.ownerLName as Ownername,Filearchieve.fsubject,Filearchieve.fsizeinkb, " +
                        " Filearchieve.fdatetime,Filearchieve.fverify,Filearchieve.securityOption,Filearchieve.fid from " +
                          " UserRegistration,Filearchieve where UserRegistration.OwnerID=Filearchieve.fowner and Filearchieve.fverify=2";
        obj.ReadData(SELECT_SQL);
        while (obj.dr.Read())
        {
            DataRow drw = dt_temp.NewRow();
            drw[0] = obj.dr.GetValue(0).ToString();
            drw[1] = obj.dr.GetValue(1).ToString();
            drw[2] = obj.dr.GetValue(2).ToString();
            drw[3] = obj.dr.GetValue(3).ToString();
            drw[4] = obj.dr.GetValue(4).ToString();
            dt_temp.Rows.Add(drw);
        }
        obj.dr.Close();
        GridView1.DataSource = dt_temp;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        GridBind();
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        //Fid=" + GridView1.DataKeys[e.RowIndex].Value;
        string DeleteSQL = "delete from Filearchieve where fverify=2";
        obj.PutData(DeleteSQL);
        Response.Write(obj.msgbox("File Deleted Successfully"));
        GridBind();
    }
}