using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using static KarateSchool.Logon;

namespace KarateSchool
{
    public partial class Logon : System.Web.UI.Page
    {
        public static int id = 0;
            //Connect to the database
            DataClasses1DataContext dbcon;
        string conn = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\coleh\\OneDrive\\Desktop\\CSCI 213\\Module 4\\KarateSchool\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
            protected void Page_Load(object sender, EventArgs e)
            {
                //Initialize connection string 
                dbcon = new DataClasses1DataContext(conn);
            }

        protected void Login2_Authenticate(object sender, AuthenticateEventArgs e)
        {
            string nUserName = Login2.UserName;
            string nPassword = Login2.Password;


            HttpContext.Current.Session["nUserName"] = nUserName;
            HttpContext.Current.Session["nPass"] = nPassword;

            dbcon = new DataClasses1DataContext(conn);

            // Search for the current User, validate UserName and Password
            var myUser = (from x in dbcon.NetUsers
                              where x.UserName == HttpContext.Current.Session["nUserName"].ToString() &&
                          x.UserPassword == HttpContext.Current.Session["nPass"].ToString()
                              select x).First();

            id = myUser.UserID;

            if (myUser != null)
            {
                HttpContext.Current.Session["userID"] = myUser.UserID;
                HttpContext.Current.Session["userType"] = myUser.UserType;
            }

            //take user to member page
            if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Member")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Member.aspx");
            }
            //take user to instructor page
            else if (myUser != null && HttpContext.Current.Session["userType"].ToString().Trim() == "Instructor")
            {
                FormsAuthentication.RedirectFromLoginPage(HttpContext.Current.Session["nUserName"].ToString(), true);
                Response.Redirect("~/Instructor.aspx");
            }
            //take user to admin page
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
