﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Collections;

public partial class Admin_AlfilesCloud1 : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    MultiCloud mobj = new MultiCloud();
    public static DataTable dt_temp = new DataTable();
    public static string Fid_C3;
    public static ArrayList ArrLst_C3 = new ArrayList();
    public static ArrayList ArrLst_CPDP = new ArrayList();
    public static int CountC3, CountCPDP, C3;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt_temp.Columns.Clear();
            dt_temp.Columns.Add("fowner");
            dt_temp.Columns.Add("fsubject");
            dt_temp.Columns.Add("fsizeinkb");
            dt_temp.Columns.Add("fdatetime");
            dt_temp.Columns.Add("fsecurity");
            AllFileDetails();
        }
    }

    protected void AllFileDetails()
    {
        CountC3 = 0;
        CountCPDP = 0;
        C3 = 0;
        dt_temp.Rows.Clear();
        ArrLst_C3.Clear();
        ArrLst_CPDP.Clear();
        string SQL_FidC3 = "select fid from Filearchieve3";
        mobj.ReadData_Cloud3(SQL_FidC3);
        while (mobj.dr3.Read())
        {
            ArrLst_C3.Add(mobj.dr3.GetValue(0).ToString());
            CountC3++;
        }
        mobj.dr3.Close();

        string SQL_FidCPDP = "select fid from Filearchieve where fverify=1";
        obj.ReadData(SQL_FidCPDP);
        while (obj.dr.Read())
        {
            ArrLst_CPDP.Add(obj.dr.GetValue(0).ToString());
            CountCPDP++;
        }
        obj.dr.Close();


        for (int j = 0; j < CountC3; j++)
        {
            string SELECT_SQL = "select UserRegistration.ownerFName+' '+UserRegistration.ownerLName as Ownername,Filearchieve.fsubject,Filearchieve.fsizeinkb, " +
                         " Filearchieve.fdatetime,Filearchieve.fverify,Filearchieve.securityOption from " +
                         " UserRegistration,Filearchieve where UserRegistration.uname=Filearchieve.fowner and Filearchieve.Fid=" + ArrLst_C3[j].ToString();
            obj.ReadData(SELECT_SQL);
            while (obj.dr.Read())
            {
                DataRow drw = dt_temp.NewRow();
                drw[0] = obj.dr.GetValue(0).ToString();
                drw[1] = obj.dr.GetValue(1).ToString();
                drw[2] = obj.dr.GetValue(2).ToString();
                drw[3] = obj.dr.GetValue(3).ToString();
                string FSecurity = obj.dr.GetValue(5).ToString();
                if (FSecurity == "1")
                {
                    drw[4] = "Low";
                }
                else if (FSecurity == "2")
                {
                    drw[4] = "Medium";
                }
                else if (FSecurity == "3")
                {
                    drw[4] = "High";
                }
                dt_temp.Rows.Add(drw);
            }
            obj.dr.Close();
        }
        GridView1.DataSource = dt_temp;
        GridView1.DataBind();
    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        AllFileDetails();
    }
}