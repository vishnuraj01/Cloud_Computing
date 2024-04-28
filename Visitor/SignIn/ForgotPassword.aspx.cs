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
using System.Windows.Forms;

public partial class ForgotPassword : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Panel1.Visible = true;
            Panel2.Visible = false;
        }
    }
    protected void btnLogin_Click(object sender, EventArgs e)
    {            

    }
    protected void btnClear_Click(object sender, EventArgs e)
    {
        
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        obj.ReadData("SELECT * FROM UserRegistration WHERE email='" + txtemail.Text + "'");
        if (obj.dr.Read())
        {
            Panel2.Visible = true;
            Panel1.Visible = false;
            Session["uname"] = obj.dr["ownerid"].ToString();
            Session["otp"] = System.DateTime.Now.Second.ToString() + System.DateTime.Now.Millisecond.ToString();
            SentoMail();
        }
        else
        {
            Response.Write(obj.msgbox("Not a registered Email ID"));
        }
    }

    public static bool CheckForInternetConnection()
    {
        try
        {
            using (var client = new WebClient())
            {
                using (var stream = client.OpenRead("http://www.google.com"))
                {
                    return true;
                }
            }
        }
        catch
        {
            return false;
        }
    }

 

    protected void SentoMail()
    {
        bool VAL = CheckForInternetConnection();
        if (VAL == true)
        {
            
            string MailId = txtemail.Text;
            try
            {
                MailMessage mail = new MailMessage();
                mail.To.Add(MailId.ToString());

                mail.From = new MailAddress("cloudstoragewebsite2024@gmail.com");
                mail.Subject = "MULTI CLOUD STORAGE";
                string Body = "OTP IS " + Session["otp"];
                mail.Body = Body;
                SmtpClient smtp = new SmtpClient("smtp.gmail.com")
                {
                    // smtp server address here…
                    Port = 587,
                    EnableSsl = true,
                    DeliveryMethod = SmtpDeliveryMethod.Network,
                    Credentials = new System.Net.NetworkCredential("cloudstoragewebsite2024@gmail.com", "asmrfkfpatusupwj"),
                    Timeout = 30000,

                };
                //Or your Smtp Email ID and Password
                smtp.EnableSsl = true;
                smtp.Send(mail);


                Response.Write("<script>alert('MESSAGE SEND TO THE EMAIL')</script>");
            }
            catch (Exception ex)
            {
                // result = "Error sending email.!!!" + ex;
                Response.Write("<script>alert('No Internet Connection To send Confirmation Email')</script>");
            }
        }
        else
        {
            Response.Write("<script>alert('No Internet Connection')</script>");
        }
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        if ((String)Session["otp"] == txtotp.Text)
        {
            Response.Redirect("ChangePassword.aspx");
        }
        else
        {
            Response.Write(obj.MessageBox("Invalid OTP"));
        }
    }
}