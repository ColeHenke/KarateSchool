using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Administrator : System.Web.UI.Page
    {
        private string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=\"C:\\Users\\coleh\\OneDrive\\Desktop\\CSCI 213\\Module 4\\KarateSchool\\App_Data\\KarateSchool(1).mdf\";Integrated Security=True;Connect Timeout=30";
        private DataClasses1DataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            dbcon = new DataClasses1DataContext(conString); 
            var memberInfo = from member in dbcon.Members
                             select new { member.MemberFirstName, member.MemberLastName, 
                                         member.MemberPhoneNumber, member.MemberDateJoined };
            
            memberGridView.DataSource = memberInfo;
            memberGridView.DataBind();

            var instructorInfo = from instructor in dbcon.Instructors
                                 select new { instructor.InstructorFirstName, instructor.InstructorLastName };

            instructorGridView.DataSource = instructorInfo;
            instructorGridView.DataBind();

            var sectionInfo = from section in dbcon.Sections
                              from member in dbcon.Members
                              from instructor in dbcon.Instructors
                              where member.Member_UserID == section.Member_ID &&
                                    instructor.InstructorID == section.Instructor_ID
                              select new
                              {
                                  member.MemberFirstName,
                                  member.MemberLastName,
                                  instructor.InstructorFirstName,
                                  instructor.InstructorLastName,
                                  section.SectionName,
                                  section.SectionStartDate,
                                  section.SectionFee
                              };
            sectionGridView.DataSource = sectionInfo;
            sectionGridView.DataBind();
        }

        protected void memberGridView_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void addMemberButton_Click(object sender, EventArgs e)
        {
            string firstName = memberFirstNameTextBox.Text;
            string lastName = memberLastNameTextBox.Text;
            DateTime joinDate = DateTime.Today;
            string phoneNumber = memberPhoneNumberTextBox.Text;
            string email = memberEmailTextBox.Text;


            Member newMember = new Member 
            { 
                MemberFirstName = firstName, 
                MemberLastName = lastName, 
                MemberDateJoined = joinDate, 
                MemberPhoneNumber = phoneNumber,
                MemberEmail = email 
            };

            dbcon.Members.InsertOnSubmit(newMember);
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void deleteMemberButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(memberIdTextBox.Text);

            dbcon = new DataClasses1DataContext(conString);
            var recordToRemoveFromMemberTable = from member in dbcon.Members
                                 where member.Member_UserID == id
                                 select member;

            foreach(var member in recordToRemoveFromMemberTable)
            {
                dbcon.Members.DeleteOnSubmit(member);
            }
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);
            }

            var recordToRemoveFromNetUserTable = from netUser in dbcon.NetUsers
                                                   where netUser.UserID == id
                                                   select netUser;

            foreach (var netUser in recordToRemoveFromNetUserTable)
            {
                dbcon.NetUsers.DeleteOnSubmit(netUser);
            }
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void deleteInstructorButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(instructorIdTextBox.Text);

            dbcon = new DataClasses1DataContext(conString);
            var recordToRemoveFromMemberTable = from instructor in dbcon.Instructors
                                                where instructor.InstructorID == id
                                                select instructor;

            foreach (var instructor in recordToRemoveFromMemberTable)
            {
                dbcon.Instructors.DeleteOnSubmit(instructor);
            }
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            var recordToRemoveFromNetUserTable = from netUser in dbcon.NetUsers
                                                 where netUser.UserID == id
                                                 select netUser;

            foreach (var netUser in recordToRemoveFromNetUserTable)
            {
                dbcon.NetUsers.DeleteOnSubmit(netUser);
            }
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void addInstructorButton_Click(object sender, EventArgs e)
        {
            string fisrtName = instructorFirstNameTextBox.Text;
            string lastName = instructorLastNameTextBox.Text;
            string phoneNumber = instructorPhoneNumberTextBox.Text;

            Instructor newInstructor = new Instructor 
            {
                InstructorFirstName = fisrtName,
                InstructorLastName = lastName,
                InstructorPhoneNumber = phoneNumber
            };

            dbcon.Instructors.InsertOnSubmit(newInstructor);
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        protected void addSectionButton_Click(object sender, EventArgs e)
        {
            string
        }

        protected void deleteSectionButton_Click(object sender, EventArgs e)
        {
            int id = int.Parse(sectionIdTextBox.Text);

            dbcon = new DataClasses1DataContext(conString);
            var recordToRemoveFromMemberTable = from section in dbcon.Sections
                                                where section.SectionID == id
                                                select section;

            foreach (var section in recordToRemoveFromMemberTable)
            {
                dbcon.Sections.DeleteOnSubmit(section);
            }
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}