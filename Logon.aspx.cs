using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Logon : System.Web.UI.Page
    {
        DataClasses1DataContext dbcon;
        private string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DL\\Carter\\Assignment4Retry2\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);
        }
        protected void Login1_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login1.UserName;
            string nPassword = Login1.Password;

            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["nPass"] = nPassword;

            NetUser myUser = (from x in dbcon.NetUsers where x.UserName == HttpContext.Current.Session["nUserName"].ToString() &&
                              x.UserPassword == HttpContext.Current.Session["nPass"].ToString() select x).First();

            if (myUser != null)
            {
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;
            }

            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Member.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Instructor.aspx");
            }
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Administrator")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Administrator.aspx");
            }
            else
            {
                Response.Redirect("Logon.aspx");
            }
        }
    }
}