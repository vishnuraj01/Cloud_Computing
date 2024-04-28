using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text.RegularExpressions;

public partial class Visitors_Home : System.Web.UI.Page
{
    CloudComputing c1 = new CloudComputing();
    public static string ID;
    public static int flag_mobile, flag_email, flag_age;
    protected void Page_Load(object sender, EventArgs e)
    {
        if ((String)Session["utype"] == "3")
        {
            Response.Redirect("~/User/UserHome.aspx");
        }
        if (!IsPostBack)
        {
            flag_mobile = 0;
            flag_email = 0;
            flag_age = 0;
            c1.ReadData("select isnull(MAX(oid)+1,7575) from UserRegistration");
            if (c1.dr.Read())
            {
                ID = c1.dr.GetValue(0).ToString();
            }
        }
    }
    protected void txtPass_TextChanged(object sender, EventArgs e)
    {

    }
    protected void btnReg_Click(object sender, EventArgs e)
    {
        c1.ReadData("select * from login where Uname='" + txtUName.Text + "'");
        if (c1.dr.Read())
        {
            Response.Write(c1.MessageBox("Username already Exists!!!"));
        }
        else
        {
            Session["Uname"] = txtUName.Text;
            Session["email"] = txtEmail.Text;
            Session["utype"] = "3";
            Response.Write(c1.MessageBox("User Registered Successfully!!"));
            PhotoUpload.SaveAs(Server.MapPath("~/Photo/" + PhotoUpload.FileName));
            c1.WriteData("insert into UserRegistration values(" + ID + ",'" + txtOwnerId.Text + "','" + txtFName.Text + "','" + txtLName.Text + "','" + RadioButtonList1.SelectedItem.Text + "','" + System.DateTime.Now.Date.ToShortDateString() + "','" + txtDOB.Text + "'," + txtAge.Text + "," + txtMobNo.Text + ",'" + txtEmail.Text + "','" + PhotoUpload.FileName + "','" + txtUName.Text + "')");
            c1.WriteData("insert into Login values('" + txtUName.Text + "','" + txtPass.Text + "','3')");
            Server.Transfer("SignIn/SignIn.aspx");
        }
    }
    protected void txtLName_TextChanged(object sender, EventArgs e)
    {
        txtOwnerId.Text = "CL-ID/" + txtFName.Text.Substring(0, 1) + "/" + ID + "/" + txtLName.Text.Substring(0, 1);
    }
    protected void btnClr_Click(object sender, EventArgs e)
    {
        txtFName.Text = "";
        txtLName.Text = "";
        txtDOB.Text = "";
        txtEmail.Text = "";
        txtAge.Text = "";
        txtConfPass.Text = "";
        txtUName.Text = "";
        txtPass.Text = "";
        txtMobNo.Text = "";
        txtOwnerId.Text = "";

    }

    protected void txtDOB_TextChanged(object sender, EventArgs e)
    {
        int age = CalculateAge(Convert.ToDateTime(txtDOB.Text));
        if (age < 18)
        {
            flag_age = 1;
            lblmsg.Text = "Age must be greater than 18";
        }
        else
        {
            txtAge.Text = Convert.ToString(CalculateAge(Convert.ToDateTime(txtDOB.Text)));
            lblmsg.Text = "";
            flag_age = 0;
        }
    }
    private static int CalculateAge(DateTime dateOfBirth)
    {
        int age = 0;
        age = DateTime.Now.Year - dateOfBirth.Year;
        if (DateTime.Now.DayOfYear < dateOfBirth.DayOfYear)
            age = age - 1;

        return age;
    }

    protected void txtEmail_TextChanged(object sender, EventArgs e)
    {
        c1.ReadData("select * from UserRegistration where email='" + txtEmail.Text + "'");
        if (c1.dr.Read())
        {
            lblmsg.Text = "Email ID Already Exists";
            flag_email = 1;
        }
        else
        {
            flag_email = 0;
        }
    }

    protected void txtMobNo_TextChanged(object sender, EventArgs e)
    {
        c1.ReadData("select * from UserRegistration where mobile=" + txtMobNo.Text);
        if (c1.dr.Read())
        {
            lblmsg.Text = "Mobile No. Already Exists";
            flag_mobile = 1;
        }
        else
        {
            string enteredWord = txtMobNo.Text.Substring(0, 4);
            string mob = "";

            string m = enteredWord.Substring(0, 1);
            if (m == "9" || m == "8" || m == "7" || m == "6")
            {
                HashSet<char> letters = new HashSet<char>();
                foreach (char c in enteredWord)
                {
                    if (letters.Contains(c))
                    {
                        lblmsg.Text += c.ToString();
                        mob += c.ToString();
                    }
                    else
                        letters.Add(c);
                }
                if (mob.Length >= 2)
                {
                    flag_mobile = 1;
                    lblmsg.Text = "Invalid Mobile Number";
                }
                else
                {
                    flag_mobile = 0;
                    lblmsg.Text = "";
                }
            }
            else
            {
                lblmsg.Text = "Invalid Mobile Number";
            }
        }
    }
}