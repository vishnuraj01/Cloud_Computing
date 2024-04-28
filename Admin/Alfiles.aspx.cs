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
            dt_temp.Rows.Clear();
            dt_temp.Columns.Clear();
            dt_temp.Columns.Add("fowner");
            dt_temp.Columns.Add("fsubject");
            dt_temp.Columns.Add("fsizeinkb");
            dt_temp.Columns.Add("fdatetime");
            dt_temp.Columns.Add("status");
            dt_temp.Columns.Add("fsecurity");
            AllFileDetails();
        }
    }

    protected void AllFileDetails()
    {
        dt_temp.Rows.Clear();
        string SELECT_SQL = "select UserRegistration.ownerFName+' '+UserRegistration.ownerLName as Ownername,Filearchieve.fsubject,Filearchieve.fsizeinkb, " +
                            " Filearchieve.fdatetime,Filearchieve.fverify,Filearchieve.securityOption from " +
                            " UserRegistration,Filearchieve where UserRegistration.uname=Filearchieve.fowner";
        obj.ReadData(SELECT_SQL);
        while (obj.dr.Read())
        {
            DataRow drw = dt_temp.NewRow();
            drw[0] = obj.dr.GetValue(0).ToString();//owner
            drw[1] = obj.dr.GetValue(1).ToString();//name
            drw[2] = obj.dr.GetValue(2).ToString();//size
            drw[3] = obj.dr.GetValue(3).ToString();//date
            string Status = obj.dr.GetValue(4).ToString();//fverify=0
            if (Status == "0")
            {
                drw[4] = "Not Verified";
            }
            else
            {
                drw[4] = "Verified";
            }
            string FSecurity = obj.dr.GetValue(5).ToString();//security
            if (FSecurity == "1")
            {
                drw[5] = "Low";
            }
            else if (FSecurity == "2")
            {
                drw[5] = "Medium";
            }
            else if (FSecurity == "3")
            {
                drw[5] = "High";
            }
            dt_temp.Rows.Add(drw);
        }
        obj.dr.Close();
        GridView1.DataSource = dt_temp;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        AllFileDetails();
    }
}