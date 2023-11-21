using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.Web.WebSockets;

namespace KarateSchool
{
    public partial class Instructor1 : System.Web.UI.Page
    {
        DataClasses1DataContext dbcon;
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\coleh\\OneDrive\\Desktop\\CSCI 213\\Module 4\\KarateSchool\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";

        private void gridLoad()
        {
            //make a connection to the database
            dbcon = new DataClasses1DataContext(connString);
            SqlConnection conn = new SqlConnection(connString);

            //query string
            string sqlstring = "select Section.SectionName, Member.MemberFirstName, Member.MemberLastName " +
                "from Section inner join Member on Section.Member_ID = Member.Member_UserID where Section.Instructor_ID = " +
                Logon.id;

            SqlCommand cmd = new SqlCommand(sqlstring, conn);
            conn.Open();
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adp.Fill(dt);
            GridView1.DataSource = dt;
            GridView1.DataBind();
            conn.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            gridLoad();
        }
    }
}