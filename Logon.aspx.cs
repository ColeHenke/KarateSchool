using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        DataClasses1DataContext dbcon;
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DL\\Carter\\Assignment4Retry\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;
            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["nPassword"] = nPassword;

            NetUser myUser = (from x in dbcon.NetUsers where x.UserName == HttpContext.Current.Session["nUserName"].ToString()
                              && x.UserPassword == HttpContext.Current.Session["nPassword"].ToString() select x).First();

            if (myUser != null ) 
            {
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;
            }

            if(myUser != null && HttpContext.Current.Session["UserType"].ToString().Trim() == "Member") 
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Member.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["UserType"].ToString().Trim() == "Instructor")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Instructor.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["UserType"].ToString().Trim() == "Administrator")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Administrator.aspx");
            }
            else
            {
                Response.Redirect("Logon.aspx", true);
            }
        }
    }
}