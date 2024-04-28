using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class User_Filedata : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    public static DataTable dt_temp = new DataTable();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            dt_temp.Rows.Clear();
            dt_temp.Columns.Clear();
            dt_temp.Columns.Add("fileid");
            dt_temp.Columns.Add("fowner");
            dt_temp.Columns.Add("fname");
            dt_temp.Columns.Add("fext");
            dt_temp.Columns.Add("fsize");
            dt_temp.Columns.Add("fkey");
            dt_temp.Columns.Add("fsecurity");
            dt_temp.Columns.Add("fdate");
            FileDetails();
        }
    }
    protected void FileDetails()
    {
        if ((String)Session["cloud"] == "1")
        {
            obj.StoredProcedureExe_DT("sp_fileverify_low");
            if (obj.dt.Rows.Count > 0)
            {
                for (int i = 0; i < obj.dt.Rows.Count; i++)
                {
                    DataRow drw = dt_temp.NewRow();
                    drw[0] = obj.dt.Rows[i]["fid"].ToString();
                    drw[1] = obj.dt.Rows[i]["fowner"].ToString();
                    drw[2] = obj.dt.Rows[i]["fsubject"].ToString();
                    drw[3] = obj.dt.Rows[i]["fext"].ToString();
                    drw[4] = obj.dt.Rows[i]["fsizeinkb"].ToString();
                    drw[5] = obj.dt.Rows[i]["fencryptkey"].ToString();
                    string S = obj.dt.Rows[i]["securityOption"].ToString();
                    if (S == "1")
                    {
                        drw[6] = "Low";
                    }
                    else if (S == "2")
                    {
                        drw[6] = "Medium";
                    }
                    else if (S == "3")
                    {
                        drw[6] = "High";
                    }
                    drw[7] = obj.dt.Rows[i]["fdatetime"].ToString();
                    dt_temp.Rows.Add(drw);
                }
            }
        }
        obj.cmd_sp.Parameters.AddWithValue("@cloud", (String)Session["cloud"]);
        obj.StoredProcedureExe_DT("sp_fileverify_m_h");
        if (obj.dt.Rows.Count > 0)
        {
            for (int i = 0; i < obj.dt.Rows.Count; i++)
            {
                string S = obj.dt.Rows[i]["securityOption"].ToString();
                if (S != "3")
                {
                    DataRow drw = dt_temp.NewRow();
                    drw[0] = obj.dt.Rows[i]["fid"].ToString();
                    drw[1] = obj.dt.Rows[i]["fowner"].ToString();
                    drw[2] = obj.dt.Rows[i]["fsubject"].ToString();
                    drw[3] = obj.dt.Rows[i]["fext"].ToString();
                    drw[4] = obj.dt.Rows[i]["fsizeinkb"].ToString();
                    drw[5] = obj.dt.Rows[i]["fencryptkey"].ToString();

                    if (S == "1")
                    {
                        drw[6] = "Low";
                    }
                    else if (S == "2")
                    {
                        drw[6] = "Medium";
                    }
                    else if (S == "3")
                    {
                        drw[6] = "High";
                    }
                    drw[7] = obj.dt.Rows[i]["fdatetime"].ToString();
                    dt_temp.Rows.Add(drw);
                }
            }
        }

        obj.ReadData("select * from filearchieve where securityOption=3 and fverify=0 and fid not in (select fid from FVerify_High where tpa=" + (String)Session["cloud"] + ")");
        while (obj.dr.Read())
        {
            DataRow drw = dt_temp.NewRow();
            drw[0] = obj.dr["fid"].ToString();
            drw[1] = obj.dr["fowner"].ToString();
            drw[2] = obj.dr["fsubject"].ToString();
            drw[3] = obj.dr["fext"].ToString();
            drw[4] = obj.dr["fsizeinkb"].ToString();
            drw[5] = obj.dr["fencryptkey"].ToString();
            string S = obj.dr["securityOption"].ToString();
            if (S == "1")
            {
                drw[6] = "Low";
            }
            else if (S == "2")
            {
                drw[6] = "Medium";
            }
            else if (S == "3")
            {
                drw[6] = "High";
            }
            drw[7] = obj.dr["fdatetime"].ToString();
            dt_temp.Rows.Add(drw);
        }

        GridView1.DataSource = dt_temp;
        GridView1.DataBind();   
    }
    
    protected void LinkButton1_Command(object sender, CommandEventArgs e)
    {
        Response.Redirect("Verification.aspx?fid=" + e.CommandArgument.ToString());
    }
    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {




    }
}