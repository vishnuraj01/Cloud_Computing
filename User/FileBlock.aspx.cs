using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

public partial class User_FileBlock : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    public static string s1, s2, s3,s;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //string dd = Session["encryptstring"].ToString();
            lbl_filename.Text = Session["fname"].ToString();
            lbl_filesize.Text = Session["fsize"].ToString();
            int SecurityOption = Convert.ToInt32(Session["upload_option"].ToString());
            if (SecurityOption == 1)
            {
                s = Session["encryptstring"].ToString();
                txt_block1.Text = s;
            }
            else if (SecurityOption == 2)
            {
                s = Session["RSA"].ToString();
                split();
                txt_block1.Text = s1;
                txt_block2.Text = s2;
                txt_block3.Text = s3;
            }
            else if (SecurityOption == 3)
            {
                s = Session["AES"].ToString();
                txt_block1.Text = s;
                txt_block2.Text = s;
                txt_block3.Text = s;
            }
            
            
        }
    }
    protected void split()
    {
        int l;
        int x = Convert.ToInt32(Session["fsize"]);
        int length = x;
        int div = length / 3;
        s1 = s.Substring(0, div);
        s2 = s.Substring(div,s1.Length);
        l = s1.Length + s2.Length;
        s3 = s.Substring(l,length-l);
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        int SecurityOption = Convert.ToInt32(Session["upload_option"].ToString());
        string FilePath = Server.MapPath("") + "//temporary//" + lbl_filename.Text;
        byte[] FileByte = (byte[])Session["filebt"];
        string Extension = Path.GetExtension(lbl_filename.Text);
        int FSz = Convert.ToInt32(lbl_filesize.Text);
        float FSzinKB = FSz / 1024;
        string FileSize = Convert.ToString(FSzinKB);
        string Date = System.DateTime.Now.ToShortDateString();
        string FileOwner = Session["Uname"].ToString();
        string FileEncrKey = Session["k"].ToString();
        string MetaData = Session["encryptstring"].ToString();
        int Fid = obj.GetId("Fid", "Filearchieve");
        string File_ID = Fid + FileOwner;
        string TagValue = Fid + FSz + Extension;
        if (SecurityOption == 1)
        {
            string INSERT_SQL = "INSERT INTO Filearchieve VALUES(" + Fid + ",'" + lbl_filename.Text + "','" + FilePath + "','" + Extension + "','" + lbl_filesize.Text + "','" + Date + "','" + FileOwner + "','" + FileEncrKey + "','" + MetaData + "',0,0,0," + SecurityOption + ",'" + File_ID + "','" + TagValue + "')";
            obj.PutData(INSERT_SQL);
            string INSERT_TEMP="insert into temporaryfupload values("+Fid+",'"+lbl_filename.Text+"','"+lbl_filesize.Text+"',"+FileEncrKey+")";
          obj.PutData(INSERT_TEMP);
        }
        else if (SecurityOption == 2)
        {
            Cryptography c=new Cryptography ();            
            string PrivateKey = c.Encrypt((String)Session["Kvalue"]);
            SentoMail((String)Session["email"], PrivateKey, lbl_filename.Text);
            string INSERT_SQL = "INSERT INTO Filearchieve VALUES(" + Fid + ",'" + lbl_filename.Text + "','" + FilePath + "','" + Extension + "','" + lbl_filesize.Text + "','" + Date + "','" + FileOwner + "','" + FileEncrKey + "','" + Session["RSA"] + "',0,0,0," + SecurityOption + ",'" + File_ID + "','" + TagValue + "')";
            obj.PutData(INSERT_SQL);
           string INSERT_TEMP = "insert into temporaryfupload values(" + Fid + ",'" + lbl_filename.Text + "','" + lbl_filesize.Text + "'," + FileEncrKey + ")";
           obj.PutData(INSERT_TEMP);
        }
        else if (SecurityOption == 3)
        {
            string INSERT_SQL = "INSERT INTO Filearchieve VALUES(" + Fid + ",'" + lbl_filename.Text + "','" + FilePath + "','" + Extension + "','" + lbl_filesize.Text + "','" + Date + "','" + FileOwner + "','" + FileEncrKey + "','" + Session["AES"] + "',0,0,0," + SecurityOption + ",'" + File_ID + "','" + TagValue + "')";
            obj.PutData(INSERT_SQL);
            string INSERT_TEMP = "insert into temporaryfupload values(" + Fid + ",'" + lbl_filename.Text + "','" + lbl_filesize.Text + "'," + FileEncrKey + ")";
            obj.PutData(INSERT_TEMP);
        }
        
        string SQLID = "SELECT MAX(Fid) FROM Filearchieve";
        int FileID = 0;
        obj.ReadData(SQLID);
        if (obj.dr.Read())
        {
            FileID = Convert.ToInt32(obj.dr.GetValue(0).ToString());
        }
        obj.dr.Close();


        string SysDate = System.DateTime.Now.Year + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Day;
        if (SecurityOption == 1)
        {
            string Cloud_Insert1 = "INSERT INTO FileIndex VALUES(" + FileID + ",1)";
            obj.PutData(Cloud_Insert1);
        }
        else if (SecurityOption == 2)
        {
            string Cloud_Insert1 = "INSERT INTO FileIndex VALUES(" + FileID + ",1)";
            obj.PutData(Cloud_Insert1);
            string Cloud_Insert2 = "INSERT INTO FileIndex VALUES(" + FileID + ",2)";
            obj.PutData(Cloud_Insert2);
            string Cloud_Insert3 = "INSERT INTO FileIndex VALUES(" + FileID + ",3)";
            obj.PutData(Cloud_Insert3);
        }
        else
        {
            string Cloud_Insert1 = "INSERT INTO FileIndex VALUES(" + FileID + ",1)";
            obj.PutData(Cloud_Insert1);
            string Cloud_Insert2 = "INSERT INTO FileIndex VALUES(" + FileID + ",2)";
            obj.PutData(Cloud_Insert2);
            string Cloud_Insert3 = "INSERT INTO FileIndex VALUES(" + FileID + ",3)";
            obj.PutData(Cloud_Insert3);
        }
        txt_block3.Text = MetaData;
        Response.Write(obj.msgbox("File Uploaded Successfully......Plz wait for the Verification"));
        Server.Transfer("UserFiles.aspx");
    }
    protected void SentoMail(string Email, string Key,string FileName)
    {
        string MailId = Email.ToString();
        string mFrom = "cloudstoragewebsite2024@gmail.com";
        string mPwd = "asmrfkfpatusupwj";

        try
        {
            SmtpClient smtp = new SmtpClient("smtp.gmail.com")
            {
                // smtp server address here…
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new System.Net.NetworkCredential(mFrom, mPwd),
                Timeout = 30000,
            };

            MailMessage message = new MailMessage(mFrom, Email.ToString(), "CPDP:File Details", "File name is " + lbl_filename.Text + " and Key for Downloading is " + Key);
            smtp.Send(message);
            Response.Write("<script>alert('MESSAGE SEND TO THE EMAIL')</script>");
        }
        catch (Exception ex)
        {
            // result = "Error sending email.!!!" + ex;
            
            Response.Write("<script>alert('No Internet Connection To send Confirmation Email')</script>");
        }


    }
}