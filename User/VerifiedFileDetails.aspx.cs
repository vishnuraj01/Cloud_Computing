using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_VerifiedFileDetails : System.Web.UI.Page
{
    MultiCloud mobj = new MultiCloud();
    CloudComputing obj = new CloudComputing();
    public static int Cloud;
    public static string SecurityOpt, Fid, MetaData1, MetaData2, MetaData2_1, MetaData2_2, MetaData2_3, MetaData3, Key;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Fid = Request.QueryString["Fid"].ToString();
            FileDetails();
        }
    }
    protected void FileDetails()
    {
        string SQL_SecurityOpt = "select securityOption from Filearchieve where Fid=" + Fid;
        obj.ReadData(SQL_SecurityOpt);
        if (obj.dr.Read())
        {
            SecurityOpt = obj.dr.GetValue(0).ToString();
        }
        obj.dr.Close();
        if (SecurityOpt != "")
        {
            if (SecurityOpt == "1")
            {
                string SQL_Temp = "select * from Filearchieve where Fid=" + Fid;
                obj.ReadData(SQL_Temp);
                if (obj.dr.Read())
                {
                    lbl_Fname.Text = obj.dr.GetValue(1).ToString();
                    lbl_Fext.Text = obj.dr.GetValue(3).ToString();
                    lbl_Fsize.Text = obj.dr.GetValue(4).ToString() + " KB";
                    lbl_Fdate.Text = obj.dr.GetValue(5).ToString();
                    lbl_Fowner.Text = obj.dr.GetValue(6).ToString();
                    Key = obj.dr.GetValue(7).ToString();
                    lbl_Fsecurityopt.Text = "Minimum";
                }
                obj.dr.Close();

                string SQL_Mdata = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                mobj.ReadData_Cloud1(SQL_Mdata);
                if (mobj.dr1.Read())
                {
                    MetaData1 = mobj.dr1.GetValue(0).ToString();
                }
                mobj.dr1.Close();
                txtkey.Text = Key.ToString();
            }
            else if (SecurityOpt == "2")
            {
                string SQL_Temp = "select * from Filearchieve where Fid=" + Fid;
                obj.ReadData(SQL_Temp);
                if (obj.dr.Read())
                {
                    lbl_Fname.Text = obj.dr.GetValue(1).ToString();
                    lbl_Fext.Text = obj.dr.GetValue(3).ToString();
                    lbl_Fsize.Text = obj.dr.GetValue(4).ToString() + " KB";
                    lbl_Fdate.Text = obj.dr.GetValue(5).ToString();
                    lbl_Fowner.Text = obj.dr.GetValue(6).ToString();
                    Key = obj.dr.GetValue(7).ToString();
                    lbl_Fsecurityopt.Text = "Medium";
                }
                obj.dr.Close();

                string SQL_Mdata1 = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                mobj.ReadData_Cloud1(SQL_Mdata1);
                if (mobj.dr1.Read())
                {
                    MetaData2_1 = mobj.dr1.GetValue(0).ToString();
                }
                mobj.dr1.Close();

                string SQL_Mdata2 = "select fmetadata from Filearchieve2 where Fid=" + Fid;
                mobj.ReadData_Cloud2(SQL_Mdata2);
                if (mobj.dr2.Read())
                {
                    MetaData2_2 = mobj.dr2.GetValue(0).ToString();
                }
                mobj.dr2.Close();

                string SQL_Mdata3 = "select fmetadata from Filearchieve3 where Fid=" + Fid;
                mobj.ReadData_Cloud3(SQL_Mdata3);
                if (mobj.dr3.Read())
                {
                    MetaData2_3 = mobj.dr3.GetValue(0).ToString();
                }
                mobj.dr3.Close();

                MetaData2 = MetaData2_1 + MetaData2_2 + MetaData2_3;
            }
            else if (SecurityOpt == "3")
            {
                string SQL_Temp = "select * from Filearchieve where Fid=" + Fid;
                obj.ReadData(SQL_Temp);
                if (obj.dr.Read())
                {
                    lbl_Fname.Text = obj.dr.GetValue(1).ToString();
                    lbl_Fext.Text = obj.dr.GetValue(3).ToString();
                    lbl_Fsize.Text = obj.dr.GetValue(4).ToString() + " KB";
                    lbl_Fdate.Text = obj.dr.GetValue(5).ToString();
                    lbl_Fowner.Text = obj.dr.GetValue(6).ToString();
                    Key = obj.dr.GetValue(7).ToString();
                    lbl_Fsecurityopt.Text = "High";
                }
                obj.dr.Close();

                txtkey.Text = AES_KeyGeneration.AES_KeyGenerate(Key.ToString());
                Random rnd = new Random();
                Cloud = (int)rnd.Next(1, 3);
                if (Cloud == 1)
                {
                    string SQL_Mdata = "select fmetadata from Filearchieve1 where Fid=" + Fid;
                    mobj.ReadData_Cloud1(SQL_Mdata);
                    if (mobj.dr1.Read())
                    {
                        MetaData1 = mobj.dr1.GetValue(0).ToString();
                    }
                    mobj.dr1.Close();
                }
                else if (Cloud == 2)
                {
                    string SQL_Mdata = "select fmetadata from Filearchieve2 where Fid=" + Fid;
                    mobj.ReadData_Cloud2(SQL_Mdata);
                    if (mobj.dr2.Read())
                    {
                        MetaData2 = mobj.dr2.GetValue(0).ToString();
                    }
                    mobj.dr2.Close();
                }
                else if (Cloud == 3)
                {
                    string SQL_Mdata = "select fmetadata from Filearchieve3 where Fid=" + Fid;
                    mobj.ReadData_Cloud3(SQL_Mdata);
                    if (mobj.dr3.Read())
                    {
                        MetaData3 = mobj.dr3.GetValue(0).ToString();
                    }
                    mobj.dr3.Close();
                }
            }
        }
    }

    protected void Download(string MDATA)
    {
        string FDownload = "";
        string SQL_FDwnld = "select ISNULL(max(fdownload)+1,1) from Filearchieve where Fid=" + Fid;
        obj.ReadData(SQL_FDwnld);
        if (obj.dr.Read())
        {
            FDownload = obj.dr.GetValue(0).ToString();
        }
        obj.ReadData("select securityOption from Filearchieve where Fid=" + Fid);
        if (obj.dr.Read())
        {
            SecurityOpt = obj.dr.GetValue(0).ToString();
        }
        obj.dr.Close();
        string SQL_Update = "update Filearchieve set fdownload=" + FDownload + " where Fid=" + Fid;
        obj.PutData(SQL_Update);

        string ext = lbl_Fext.Text;
        if (ext == ".txt")
        {
            string EncryptedString = MDATA;
            string CryptoGraphicKey = Key.ToString();
            if (SecurityOpt == "1")
            {
                string Datatext_Pre = Source.CryptorEngine.homomarphicDecrypt(EncryptedString, true, CryptoGraphicKey);
                string Datatext = Source.CryptorEngine.Decrypt(Datatext_Pre, true, CryptoGraphicKey);
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = lbl_Fext.Text;
                Response.AddHeader("content-disposition", "attachment;filename=" + lbl_Fname.Text);
                Response.Write(Datatext);
                Response.End();  
            }
            else if (SecurityOpt == "2")
            {                
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = lbl_Fext.Text;
                Response.AddHeader("content-disposition", "attachment;filename=" + lbl_Fname.Text);
                Response.Write(MDATA);
                Response.End();  
            }
            else if (SecurityOpt == "3")
            {               
               
                Response.Buffer = true;
                Response.Charset = "";
                Response.Cache.SetCacheability(HttpCacheability.NoCache);
                Response.ContentType = lbl_Fext.Text;
                Response.AddHeader("content-disposition", "attachment;filename=" + lbl_Fname.Text);
                Response.Write(MDATA);
                Response.End();  
            }            
        }
        //else if (ext == ".doc" || ext == "docx" || ext == ".xml" || ext == ".pdf")
        //{
        //    string filepath=
        //}
        else
        {
            string ImgPath = "~/user/files/" + lbl_Fname.Text;
            Response.Clear();
            Response.ContentType = "";
            Response.AddHeader("content-disposition", "attachment;filename=" + ImgPath);
            Response.WriteFile(ImgPath);
            Response.End();
        }        
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        if (SecurityOpt != "")
        {
            if (SecurityOpt == "1")
            {
                Download(MetaData1);
            }
            else if (SecurityOpt == "2")
            {
                Cryptography c = new Cryptography();
                string K = c.Decrypt(txtkey.Text);
                string RSA_Key = RSA_KeyGeneration.ReturnKey(K, true);
                if (int.Parse(RSA_Key) == int.Parse(Key))
                {
                    RSA_Algorithm r = new RSA_Algorithm();
                    string RSA = r.Decrypt(MetaData2, Key);
                    string s = "FL"; //Source.CryptorEngine.Decrypt(RSA, true, Key);
                    Download(s);
                }
                else
                {
                    Response.Write(obj.msgbox("Invalid Private Key...!!! File cannot be Downloaded"));
                }
            }
            else if (SecurityOpt == "3")
            {
                if (Cloud == 1)
                {
                    string s = "FL";
                    Download(s);
                }
                else if (Cloud == 2)
                {
                    string s = "FL";
                    Download(s);
                }
                else if (Cloud == 3)
                {
                    string s = "FL";
                    Download(s);
                }
            }           
        }
    }
}