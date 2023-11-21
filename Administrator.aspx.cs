using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace KarateSchool
{
    public partial class Administrator : System.Web.UI.Page
    {
        private string conString = "Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\DL\\Carter\\Assignment4Retry2\\App_Data\\KarateSchool(1).mdf;Integrated Security=True;Connect Timeout=30";
        private DataClasses1DataContext dbcon;

        protected void Page_Load(object sender, EventArgs e)
        {
            //adding data to the members grid view
            dbcon = new DataClasses1DataContext(conString); 
            var memberInfo = from member in dbcon.Members
                             select new { member.MemberFirstName, member.MemberLastName, 
                                         member.MemberPhoneNumber, member.MemberDateJoined };
            
            memberGridView.DataSource = memberInfo;
            memberGridView.DataBind();

            //adding data to the instructor grid view
            var instructorInfo = from instructor in dbcon.Instructors
                                 select new { instructor.InstructorFirstName, instructor.InstructorLastName };

            instructorGridView.DataSource = instructorInfo;
            instructorGridView.DataBind();

            //adding data to the sections gridview
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
            /*Mapping data entered in the textboxes to use for adding a member to the 
             member table*/

            //int userID = int.Parse(memberIdTextBox.Text);
            string userName = memUserNameTextBox.Text;
            string userPass = memPassTextBox.Text;
            string userType = "Member";
            string firstName = memberFirstNameTextBox.Text;
            string lastName = memberLastNameTextBox.Text;
            DateTime joinDate = DateTime.Today;
            string phoneNumber = memberPhoneNumberTextBox.Text;
            string email = memberEmailTextBox.Text;
            //var check = from x in dbcon.NetUsers where x.UserID == userID select x;
            NetUser newUser = new NetUser
            {
                UserName = userName,
                UserPassword = userPass,
                UserType = userType
            };

            //submitting the changes to the database, need to make a NetUser before a member
            dbcon.NetUsers.InsertOnSubmit(newUser);
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            //pulling an ID from the NetUsers table for the memberID inheritance
            var getID = (from x in dbcon.NetUsers where x.UserName == userName select x.UserID).First();
        
            //Member object can now be created after the NetUser was added
            Member newMember = new Member
            {
                Member_UserID = getID,
                MemberFirstName = firstName,
                MemberLastName = lastName,
                MemberDateJoined = joinDate,
                MemberPhoneNumber = phoneNumber,
                MemberEmail = email
            };

            //submitting the member to the member table
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
            //user enters an Id to delete
            int id = int.Parse(memberIdTextBox.Text);

            //Finding the entered Id in the member table
            dbcon = new DataClasses1DataContext(conString);
            var recordToRemoveFromMemberTable = from member in dbcon.Members
                                 where member.Member_UserID == id
                                 select member;

            //Deleting the specified user in the member table with the matching Id
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

            //Finding the entered Id in the netusers table
            var recordToRemoveFromNetUserTable = from netUser in dbcon.NetUsers
                                                   where netUser.UserID == id
                                                   select netUser;

            //deleting the specified record from the netUsers table
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
            //storing the value of the Id the user wants deleted
            int id = int.Parse(instUserID.Text);

            //finding the matching Id to be deleted from the instructor table
            dbcon = new DataClasses1DataContext(conString);
            var recordToRemoveFromMemberTable = from instructor in dbcon.Instructors
                                                where instructor.InstructorID == id
                                                select instructor;

            //deleting the record from the instructor table
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

            //finding the matching Id in the net user table
            var recordToRemoveFromNetUserTable = from netUser in dbcon.NetUsers
                                                 where netUser.UserID == id
                                                 select netUser;

            //deleting the record from the netuser table
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
            /*Mapping all of the data from the text boxes into variables so we can 
             create objects to be added to the instructor table*/

            //int userID = int.Parse(instUserID.Text);
            string userName = instUserName.Text;
            string userPass = instPass.Text;
            string userType = "Instructor";
            string firstName = instructorFirstNameTextBox.Text;
            string lastName = instructorLastNameTextBox.Text;
            string phoneNumber = instructorPhoneNumberTextBox.Text;

            //creating the NetUser object first 
            NetUser newUser = new NetUser
            {
                UserName = userName,
                UserPassword = userPass,
                UserType = userType
            };

            //adding the netUser object to the database
            dbcon.NetUsers.InsertOnSubmit(newUser);
            try
            {
                dbcon.SubmitChanges();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

            //retrieving the ID from the NetUser table for inheritance into the instructor table
            var getID = (from x in dbcon.NetUsers where x.UserName == userName select x.UserID).First();

            //creating the instructor object to be inserted
            Instructor newInstructor = new Instructor 
            {
                InstructorID = getID,
                InstructorFirstName = firstName,
                InstructorLastName = lastName,
                InstructorPhoneNumber = phoneNumber
            };

            //inserting the instructor object into the database
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
            /*Mapping all of the data entered into the textboxes into variables to create
             a section object to be added to the database*/

            int sectionID = int.Parse(sectionIdTextBox.Text);
            string sectionName = sectionNameTextBox.Text;
            DateTime sectionSD = DateTime.Parse(sectionStartDateTextBox.Text);
            int memberID = int.Parse(memberInSectionTextBox.Text);
            int instID = int.Parse(instructorInSectionTextBox.Text);
            decimal sectionFee = decimal.Parse(sectionFeeTextBox.Text);
            //grabbing the user Id and Instructor Id that was entered in the textbox
            var memIdCheck = from x in dbcon.NetUsers where x.UserID == memberID select x;
            var instIdCheck = from x in dbcon.NetUsers where x.UserID == instID select x;
            //If both of the Id's exist in the database, then we can move forward with creating the object
            if (memIdCheck.Count() >= 1 &&  instIdCheck.Count() >= 1)
            {
                //creating the section object ot add to the Database
                Section newSection = new Section
                {
                    SectionID = sectionID,
                    SectionName = sectionName,
                    SectionStartDate = sectionSD,
                    Member_ID = memberID,
                    Instructor_ID = instID,
                    SectionFee = sectionFee
                };

                //adding the section object to the database
                dbcon.Sections.InsertOnSubmit(newSection);
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

        protected void deleteSectionButton_Click(object sender, EventArgs e)
        {
            //grabbing the entered id 
            int id = int.Parse(sectionIdTextBox.Text);

            
            dbcon = new DataClasses1DataContext(conString);

            //searching for the entered id
            var recordToRemoveFromMemberTable = from section in dbcon.Sections
                                                where section.SectionID == id
                                                select section;
            //deleting the record with the specified id from the section table
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