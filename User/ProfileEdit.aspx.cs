using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class Reristration : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    public static string Oid;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            OwnerDetails();
        }
    }

    protected void OwnerDetails()
    {
        string SELECT_SQL = "select * from UserRegistration where uname='" + (String)Session["Uname"] + "'";
        obj.ReadData(SELECT_SQL);
        if (obj.dr.Read())
        {
            txt_id.Text = (String)Session["Uname"];
            Oid = obj.dr.GetValue(0).ToString();
            txt_userid.Text = obj.dr["Ownerid"].ToString();
            txt_fname.Text = obj.dr["Ownerfname"].ToString();
            txt_lname.Text = obj.dr["Ownerlname"].ToString();
            txt_age.Text = obj.dr["age"].ToString();
            txt_mobile.Text = obj.dr["mobile"].ToString();
            txt_email.Text = obj.dr["email"].ToString();
            string gender = obj.dr["email"].ToString();
            if (gender == "Male")
            {
                rbl_gender.SelectedIndex = 0;
            }
            else
            {
                rbl_gender.SelectedIndex = 1;
            }
        }
        obj.dr.Close();
    }

    protected void btn_submit_Click(object sender, EventArgs e)
    {
        if (FileUpload1.HasFile)
        {
            string Fname = "", Ext = "";
            Fname = FileUpload1.FileName;
            Ext = Path.GetExtension(Fname);
            if (Ext == ".jpeg" || Ext == ".jpg" || Ext == ".gif" || Ext == ".png" || Ext == ".bmp" || Ext == ".tiff")
            {

                FileUpload1.SaveAs(Server.MapPath("~/Photo/" + Fname));
                string date = System.DateTime.Now.Year + "-" + System.DateTime.Now.Month + "-" + System.DateTime.Now.Day;
                //int oid = obj.GetId("Oid", "UserRegistration");
                string update_sql = "update UserRegistration set Ownerfname='" + txt_fname.Text + "',Ownerlname='" + txt_lname.Text + "', " +
                                    " Gender='" + rbl_gender.SelectedItem.Text + "',Age=" + txt_age.Text + ",Mobile='" + txt_mobile.Text + "',Email='" + txt_email.Text + "',Photo='" + Fname + "' where Ownerid='" + (String)Session["Uname"] + "'";
                obj.PutData(update_sql);
                
                Response.Write(obj.msgbox("Updated Successfully"));
                Server.Transfer("Userhome.aspx");
            }
            else
            {
                Response.Write(obj.msgbox("Invalid Image...!"));
            }
        }
        else
        {
            Response.Write(obj.msgbox("Pleasse Upload Your Photo...!"));
        }
    }
    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Server.Transfer("Userhome.aspx");
    }
    protected void txt_name_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btn_submit0_Click(object sender, EventArgs e)
    {
        System.Collections.ArrayList arrlst = new System.Collections.ArrayList();
        arrlst.Clear();
        obj.PutData("delete from Login where uname='" + (String)Session["Uname"] + "'");
        obj.PutData("delete from UserRegistration where Ownerid='" + (String)Session["Uname"] + "'");
        obj.ReadData("select Fid from Filearchieve where fowner='" + (String)Session["Uname"] + "'");
        while (obj.dr.Read())
        {
            arrlst.Add(obj.dr.GetValue(0).ToString());
        }
        for (int i = 0; i < arrlst.Count; i++)
        {
            obj.PutData("delete from Filearchieve where Fid=" + arrlst[i].ToString());
            obj.PutData("delete from FileIndex where Fileid=" + arrlst[i].ToString());
            MultiCloud m = new MultiCloud();
            m.PutData_Cloud1("delete from Filearchieve1 where fid=" + arrlst[i].ToString());
            m.PutData_Cloud2("delete from Filearchieve2 where fid=" + arrlst[i].ToString());
            m.PutData_Cloud3("delete from Filearchieve3 where fid=" + arrlst[i].ToString());
        }
        Session.Abandon();
        Response.Redirect("~/Visitor/home/home.aspx");
    }
}