using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class User_UserHome : System.Web.UI.Page
{
    CloudComputing obj = new CloudComputing();
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string SELECT_SQL = "select ownerFName+' '+ownerLName as Ownername,Mobile,Email,Date,Photo,OwnerID from UserRegistration where uname='" + (String)Session["Uname"] + "'";
            obj.ReadData(SELECT_SQL);
            if (obj.dr.Read())
            {
                lbl_name.Text = obj.dr.GetValue(0).ToString();
                lbl_mobile.Text = obj.dr.GetValue(1).ToString();
                lbl_email.Text = obj.dr.GetValue(2).ToString();
                DateTime dt = Convert.ToDateTime(obj.dr.GetValue(3).ToString());

                string datewithMonth = dt.ToString("MMMM dd, yyyy");

                string onlyDate = DateTime.Parse(datewithMonth).ToShortDateString();
                lbl_date.Text = onlyDate.ToString();
                Image1.ImageUrl = "~/Photo/" + obj.dr.GetValue(4).ToString();
                lbl_userid.Text = (String)Session["Uname"];
            }
            obj.dr.Close();
        }
    }
}