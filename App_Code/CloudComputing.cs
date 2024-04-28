using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Web.UI.WebControls;

/// <summary>
/// Summary description for CloudComputing
/// </summary>
public class CloudComputing
{
    public SqlConnection con = new SqlConnection();
    public SqlCommand cmd;
    public SqlCommand cmd_sp = new SqlCommand();
    public SqlDataReader dr;
    public SqlDataAdapter ada = new SqlDataAdapter();
    public SqlDataAdapter ad = new SqlDataAdapter();
    public DataTable dt = new DataTable();
    public void DBConnection()
    {
        if (con.State == ConnectionState.Open)
        {
            con.Close();
        }
        con.ConnectionString = ConfigurationManager.AppSettings["CloudComputingConStr"];
        con.Open();
    }
    public void ReadData(string sql)
    { 
        DBConnection();
        cmd = new SqlCommand(sql, con);
        dr = cmd.ExecuteReader();
    }
    public void PutData(string sql)
    {
        DBConnection();
        cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
    }
    public void WriteData(string sql)
    {
        DBConnection();
        cmd = new SqlCommand(sql, con);
        cmd.ExecuteNonQuery();
    }
    public void StoredProcedureExe_DT(string spname)
    {
        try
        {
            dt.Rows.Clear();
            DBConnection();
            cmd_sp.Connection = con;
            cmd_sp.CommandType = CommandType.StoredProcedure;
            cmd_sp.CommandText = spname;
            ad.SelectCommand = cmd_sp;
            ad.Fill(dt);
        }
        catch (Exception ex)
        {

        }
        finally
        {
            cmd_sp.Parameters.Clear();
        }
    }
    public int GetId(string pk, string table)
    {
        DBConnection();
        string sql = "SELECT ISNULL(MAX(" + pk + ")+1,1000) FROM " + table;
        cmd = new SqlCommand(sql, con);
        int id = Convert.ToInt32(cmd.ExecuteScalar());
        return id;

    }
    public string msgbox(string msg)
    {
        string message = "<script language='javascript'>alert('" + msg + "')</script>";
        return message;
    }
    public void FillDropDownList(string text, string value, string table, string condition, DropDownList ddlldt)
    {
        if (condition == "")
        {
            string sql = "select " + text + "," + value + " from " + table;
            Adapter(sql);
            if (dt.Rows.Count > 0)
            {
                ddlldt.DataSource = dt;
                ddlldt.DataTextField = text;
                ddlldt.DataValueField = value;
                ddlldt.DataBind();
            }
            ddlldt.Items.Insert(0, "--select--");
        }
        else
        {
            string sql = "select " + text + "," + value + " from " + table + " where " + condition;
            Adapter(sql);
            if (dt.Rows.Count > 0)
            {
                ddlldt.DataSource = dt;
                ddlldt.DataTextField = text;
                ddlldt.DataValueField = value;
                ddlldt.DataBind();
            }
            ddlldt.Items.Insert(0, "--select--");
        }
    }
    public void FillGrid(string sql, GridView grd)
    {
        DataAdapter(sql);
        if (dt.Rows.Count > 0)
        {
            grd.DataSource = dt;
            grd.DataBind();
        }
    }
    public void FillDetailsView(string sql, DetailsView dw)
    {
        DataAdapter(sql);
        if (dt.Rows.Count > 0)
        {
            dw.DataSource = dt;
            dw.DataBind();
        }
    }
    public void FillDataList(string sql, DataList dtlst)
    {
        DataAdapter(sql);
        if (dt.Rows.Count > 0)
        {
            dtlst.DataSource = dt;
            dtlst.DataBind();
        }
    }
    public string MessageBox(string msg)
    {
        string Message = "<script>alert('" + msg + "')</script>";
        return Message;
    }
    public void Adapter(string sql)
    {
        dt.Rows.Clear();
        DBConnection();
        cmd = new SqlCommand(sql, con);
        ada.SelectCommand = cmd;
        ada.Fill(dt);
    }
    public void DataAdapter(string sql)
    {
        dt.Rows.Clear();
        DBConnection();
        cmd = new SqlCommand(sql, con);
        ada.SelectCommand = cmd;
        ada.Fill(dt);
    }
    public int serverid(string sql)
    {
        DBConnection();
        int sid;
        cmd = new SqlCommand(sql, con);
        sid = Convert.ToInt32(cmd.ExecuteScalar());
        return sid;
    }
}