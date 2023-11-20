﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Collections.Specialized.BitVector32;

namespace KarateSchool
{
    public partial class Member1 : System.Web.UI.Page
    {
        string connString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DL\\Carter\\Assignment4Retry\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";

        //TODO - replace with 
        private int id = 1; //placeholder id

        private DataClasses1DataContext dbcon;
        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(connString);

            var totalLifetimePayment = (from section in dbcon.Sections
                                       where section.Member_ID == id 
                                       select Convert.ToInt32(section.SectionFee)).Sum();

            var memberSectionInfo = from section in dbcon.Sections
                                    from instructor in dbcon.Instructors
                                    where section.Member_ID == id && section.Instructor_ID == instructor.InstructorID
                                    select new 
                                    { section.SectionName, 
                                        instructor.InstructorFirstName, 
                                        instructor.InstructorLastName,
                                        section.SectionStartDate,
                                        section.SectionFee};

            /*var memberInfo = from member in dbcon.Members
                             where member.Member_UserID == id
                             select member;*/
            memberGridView.DataSource = memberSectionInfo;
            memberGridView.DataBind();
        }
    }
}