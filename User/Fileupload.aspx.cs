using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

public partial class User_Fileupload : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    Cryptography cg = new Cryptography();
    public static byte[] File_Byte;
    public static string filebyte, filename, hmencryptedstring, file_name, file_byte, file_ext, file_size, date, file_mdata, hmdencryptedstring;
    public static float fsize;
    protected void Page_Load(object sender, EventArgs e)
    {
        lbl_uid.Text = Session["uname"].ToString();
        if (!IsPostBack)
        {
            Random rnd = new Random();
            Session["key"] = (int)rnd.Next(1, 10);
            string str = "SELECT * FROM KeyGenerate where kid='" + Session["key"].ToString() + "'";
            obj.ReadData(str);
            if (obj.dr.Read())
            {
                Session["k"] = obj.dr.GetValue(1).ToString();
                txt_filekey.Text = obj.dr.GetValue(1).ToString();
                obj.dr.Close();
            }
        }
    }

    protected string HmEncription(byte[] fb, string Key)
    {
        string ecrstr = Source.CryptorEngine.Encrypt(fb, true, Key);
        string hmecrstr = Source.CryptorEngine.homomarphicEncrypt(ecrstr, true, Key);
        Session["hmencryptedstring"] = hmencryptedstring;
        return hmecrstr;
    }
    protected string FN_EncrStr(byte[] fb, string Key)
    {
        string ecrstr = Source.CryptorEngine.Encrypt(fb, true, Key);
        return ecrstr;
    }
    protected void btn_submit_Click(object sender, EventArgs e)
    {

        if (flup_user.HasFile)
        {
            flup_user.SaveAs(Server.MapPath("~/User/files/" + flup_user.FileName));
            byte[] filebt = new byte[flup_user.PostedFile.InputStream.Length];
            flup_user.PostedFile.InputStream.Read(filebt, 0, filebt.Length);
            Session["filebt"] = filebt;
            string fname = flup_user.FileName;
            Session["fname"] = fname;
            string ext = Path.GetExtension(fname);
            string fsize = flup_user.FileContent.Length.ToString();
            Session["fsize"] = fsize;
            string path = Server.MapPath("") + "//temporary//";
            string fkey = txt_filekey.Text;
            Session["FKey"] = fkey;
            flup_user.SaveAs(path + fname);
            Session["ext"] = ext;
            string hmencryptedstring = HmEncription(filebt, txt_filekey.Text);
            Session["encryptstring"] = hmencryptedstring;
            Session["upload_option"] = RadioButtonList1.SelectedValue;
            string AES_Encr = "", RSA = "";
            if (RadioButtonList1.SelectedValue == "2")
            {
                string s = FN_EncrStr(filebt, txt_filekey.Text);
                RSA_Algorithm r = new RSA_Algorithm();
                RSA = r.Encrypt(s, txt_filekey.Text);
                Session["RSA"] = RSA.ToString();
                Session["Kvalue"] = txt_filekey.Text;
            }
            else if (RadioButtonList1.SelectedValue == "3")
            {
                string s = FN_EncrStr(filebt, txt_filekey.Text);
                AES_Encr = AES_Algorithm.AES_Encrypt(s, txt_filekey.Text);
                Session["AES"] = AES_Encr.ToString();
                Session["Kvalue"] = txt_filekey.Text;
            }
            Response.Redirect("~/User/FileBlock.aspx");
        }
        else
        {
            Response.Write(obj.msgbox("Please upload a file"));
        }
    }


    protected void btn_cancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("UserHome.aspx");
    }

    protected void RadioButtonList1_SelectedIndexChanged1(object sender, EventArgs e)
    {
        if (RadioButtonList1.SelectedValue == "1")
        {
            txt_filekey.Text = (String)Session["k"];
        }
        else if (RadioButtonList1.SelectedValue == "2")
        {
            string K = (String)Session["k"];
            txt_filekey.Text = RSA_KeyGeneration.Get64BitKey(K, true);
        }
        else if (RadioButtonList1.SelectedValue == "3")
        {
            string K = (String)Session["k"];
            txt_filekey.Text = AES_KeyGeneration.AES_KeyGenerate(K);
        }
    }
}