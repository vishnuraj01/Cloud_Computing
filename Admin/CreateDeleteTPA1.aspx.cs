using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Admin_CreateDeleteTPA : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = false;
            Panel2.Visible = false;
        }
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        int cloud = Convert.ToInt32(Session["cloud"].ToString());
        string sql = "SELECT * FROM TpaLogin WHERE name='" + txt_name.Text + "'";
        obj.ReadData(sql);
        if (obj.dr.Read())
        {
            obj.dr.Close();
            
            Response.Write(obj.msgbox("User name already exist"));
        }
        else
        {
            obj.dr.Close();
            string insert_sql = "INSERT INTO TpaLogin VALUES('" + txt_name.Text + "','" + txt_pwd.Text + "'," + cloud + ")";
            string insert_sql1 = "INSERT INTO Login VALUES('" + txt_name.Text + "','" + txt_pwd.Text + "','2')";
            obj.PutData(insert_sql);
            obj.PutData(insert_sql1);
            txt_cpwd.Text = "";
            txt_name.Text = "";
            txt_pwd.Text = "";
            Response.Write(obj.msgbox("Creation Successful"));
        }
    }
    protected void rbtn_create_CheckedChanged(object sender, EventArgs e)
    {
        Panel1.Visible = true;
        Panel2.Visible = false;
    }
    protected void RadioButton2_CheckedChanged(object sender, EventArgs e)
    {
        Panel1.Visible = false;
        Panel2.Visible = true;
        GridBind();
    }
    protected void GridBind()
    {
        string sql = "select * from TpaLogin where cloud=1 ";
        obj.FillGrid(sql, GridView1);
    }
    protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        
        obj.PutData("delete from tpalogin where id=" + GridView1.DataKeys[e.RowIndex].Value);
        Response.Write(obj.msgbox("TPA Deleted Successfully"));
        GridBind();
    }
    protected void dtn_cancel_Click(object sender, EventArgs e)
    {
        txt_name.Text = "";
        txt_pwd.Text = "";
        txt_cpwd.Text = "";
    }
}