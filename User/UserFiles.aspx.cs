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
    public static DataTable dt_temp_user = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt_temp_user.Columns.Clear();
            dt_temp_user.Columns.Add("fid");
            dt_temp_user.Columns.Add("tagvalue");
            dt_temp_user.Columns.Add("fowner");
            dt_temp_user.Columns.Add("fsubject");
            dt_temp_user.Columns.Add("fsizeinkb");
            dt_temp_user.Columns.Add("fdatetime");
            dt_temp_user.Columns.Add("status");
            dt_temp_user.Columns.Add("fsecurity");
            AllFileDetails();
        }
    }

    protected void AllFileDetails()
    {
        dt_temp_user.Rows.Clear();
        string SELECT_SQL = "select Filearchieve.fileid,Filearchieve.tagvalue,UserRegistration.Ownerfname+' '+UserRegistration.Ownerlname as Ownername,Filearchieve.fsubject,Filearchieve.fsizeinkb, " +
                          " Filearchieve.fdatetime,Filearchieve.fverify,Filearchieve.securityOption from " +
                          " UserRegistration,Filearchieve where UserRegistration.uname=Filearchieve.fowner " +
                          " and Filearchieve.fowner='" + (String)Session["uname"] + "'";
        obj.ReadData(SELECT_SQL);
        while (obj.dr.Read())
        {
            DataRow drw = dt_temp_user.NewRow();
            drw[0] = obj.dr.GetValue(0).ToString();
            drw[1] = obj.dr.GetValue(1).ToString();
            drw[2] = obj.dr.GetValue(2).ToString();
            drw[3] = obj.dr.GetValue(3).ToString();
            drw[4] = obj.dr.GetValue(4).ToString();
            drw[5] = obj.dr.GetValue(5).ToString();
            string Status = obj.dr.GetValue(6).ToString();
            if (Status == "0")
            {
                drw[6] = "Not Verified";
            }
            else
            {
                drw[6] = "Verified";
            }
            string FSecurity = obj.dr.GetValue(7).ToString();
            if (FSecurity == "1")
            {
                drw[7] = "Low";
            }
            else if (FSecurity == "2")
            {
                drw[7] = "Medium";
            }
            else if (FSecurity == "3")
            {
                drw[7] = "High";
            }
            dt_temp_user.Rows.Add(drw);
        }
        obj.dr.Close();
        GridView1.DataSource = dt_temp_user;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        AllFileDetails();
    }
}