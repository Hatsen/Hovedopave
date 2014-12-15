using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;
using System.Web.Services;
//using System.Services;
using System.ServiceModel.Web;
using System.Text;
using Crypto;
using Webservice.DB;
using Webservice.Extended;
using System.Data.SqlClient;
using System.Runtime.Serialization.Json;
using System.IO;

namespace Webservice
{
    public class Service1 : IService1, IGameService
    {
        #region AnnouncementMethods
        public bool CreateAnnouncement(int creator, string header, string message, int groupID, int classID)
        {
            if (DatabaseHandler.Instance.CreateAnnouncement(creator, header, message, groupID, classID) == true)
            {
                Announcement anc = new Announcement();

                anc.Creator = creator;
                anc.Header = header;
                anc.Message = message;
                anc.GroupID = groupID;
                anc.ClassID = classID;
                Holder.Instance.Announcements.Add(anc);

                return true;
            }
            else
            {
                return false;
            }
        }

        public List<Announcement> GetAnnouncements(int groupID, int classID)
        {
            DatabaseHandler.Instance.GetAnnouncements(groupID);
            List<Announcement> announcements = new List<Announcement>();

            foreach (Announcement anc in Holder.Instance.Announcements)
            {
                if (groupID == 1 || groupID == anc.GroupID || classID == anc.ClassID || groupID == 0)
                {
                    if ((groupID == anc.GroupID) && (classID == anc.ClassID) || groupID == anc.GroupID && classID == 0)
                    {
                        if (!announcements.Any(i => i.ID == anc.ID))
                        {
                            announcements.Add(anc);
                        }
                    }
                }
            }

            return announcements;
        }

        public string GetAnnouncementCreator(int id)
        {
            return DatabaseHandler.Instance.GetAnnouncementCreator(id);
        }

        #endregion

        #region TeacherMethods

       
        public List<TeacherEx> GetTeachers()
        {
            List<TeacherEx> listOfTeacherExs = DatabaseHandler.Instance.GetTeachers();
            List<ClassEx> listOfClasses = DatabaseHandler.Instance.GetClasses();
            listOfTeacherExs = DatabaseHandler.Instance.GetTeachers();

            foreach (TeacherEx teacherEx in listOfTeacherExs)
            {
                foreach (ClassEx classEx in listOfClasses)
                {
                    if (classEx.Fkteacherid == teacherEx.Id)
                    {
                        teacherEx.ClassList.Add(classEx);
                    }
                }
            }
            return listOfTeacherExs;
        }


        /*    public int GetMostRecentUserId()
            {
                return DatabaseHandler.Instance.GetMostRecentUserId();
            }*/


        public bool InsertTeacher(TeacherEx teacher)
        {
            bool success = false;

            if (teacher.Id != 0) // update
            {
                success = DatabaseHandler.Instance.UpdateTeacher(teacher);
            }

            else
            {
                success = DatabaseHandler.Instance.InsertTeacher(teacher); // will insert into User and Teacher.
            }
            return success;
        }



        #endregion

        #region ParentMethods


        private bool InsertTheParrentsChildren(List<Student> childList, int parentId)
        {
            bool success = true;
            try
            {
                foreach (Student child in childList)
                {
                    StudentParent studentParent = new StudentParent();
                    studentParent.Fkparentid = parentId;
                    studentParent.Fkstudentid = child.Id;
                    DatabaseHandler.Instance.InsertIntoStudentParent(studentParent);
                }
            }
            catch (Exception)
            {
                success = false;
            }

            return success;

        }


        public bool InsertParent(ParentEx parent)
        {
            int generatedId = 0;
            bool success = false;

            if (parent.Id != 0) // update
            {
                success = DatabaseHandler.Instance.UpdateParent(parent);

                if (parent.ChildrenList.Count != 0 && success)
                {
                    foreach (Student child in parent.ChildrenList)
                    {
                        DatabaseHandler.Instance.DeleteConnectionBetweenParentAndChild(parent.Id, child.Id);
                    }

                    success = InsertTheParrentsChildren(parent.ChildrenList, parent.Id);
                }
            }

            else // create
            {
                generatedId = DatabaseHandler.Instance.InsertParent(parent);

                if (generatedId == 0)
                    success = false;
                else
                    success = true;
                if (parent.ChildrenList.Count != 0 && success)
                {
                    success = InsertTheParrentsChildren(parent.ChildrenList, generatedId);
                }
            }


            return success;
        }

        public List<Student> FindParentsChildren(int id)
        {
            return DatabaseHandler.Instance.FindParentsChildren(id);
        }

        public List<ParentEx> GetParents()
        {

            List<ParentEx> parentExlist = new List<ParentEx>();
            parentExlist = DatabaseHandler.Instance.GetParents();

            foreach (ParentEx parent in parentExlist)
            {
                List<Student> children = new List<Student>();
                children = DatabaseHandler.Instance.FindParentsChildrenTEST(parent.Id);

                parent.EnrollmentsCount = DatabaseHandler.Instance.FindTheEnrollmentsAssociateforTheParent(parent.Id); // finds the number for how many enrollments the parent has created.

                if (children.Count != 0)
                {
                    parent.ChildrenList = children;
                }

            }
            return parentExlist;
        }

        #endregion

        #region StudentMethods


        public bool InsertStudent(Student student, Enrollment enrollment = null)
        {

            bool success = false;
            string sqlStatement = "";

            if (enrollment != null)
            {
                List<ParentEnrollment> parentenrollmentlist = DatabaseHandler.Instance.GetParentEnrollment(enrollment.Id);

                // student.Id = DatabaseHandler.Instance.InsertStudent(student); // hvorfor ikke bare returner string tilbage og så have en commit metode på databasehandler
                // så kan du sende den samlet sql statement ned til databasen. (Dette behøves ikke når der skal læses/read da den ikke kan ødelægge noget.) transaction

                sqlStatement += DatabaseHandler.Instance.InsertStudent2(student);


                foreach (ParentEnrollment parentenrollment in parentenrollmentlist)
                {
                    StudentParent association = new StudentParent();
                    association.Fkparentid = parentenrollment.Fkparentid;
                    association.Fkstudentid = student.Id;

                    sqlStatement += DatabaseHandler.Instance.InsertIntoStudentParent2(association); // abner og lukker connection flere gange....
                }


                foreach (ParentEnrollment parentenrollment in parentenrollmentlist)
                {
                    sqlStatement += DatabaseHandler.Instance.DeleteConnectionBetweenParentAndEnrollment2(parentenrollment.Fkparentid, enrollment.Id); // abner og lukker connection flere gange....
                }
                sqlStatement += DatabaseHandler.Instance.DeleteEnrollment2(enrollment.Id);


                success = DatabaseHandler.Instance.Commit(sqlStatement);




            }

            else if (enrollment == null)
            {

                if (student.Id != 0)
                {
                    success = DatabaseHandler.Instance.UpdateStudent(student);
                }
                else
                {
                    //int recentId = DatabaseHandler.Instance.GetMostRecentUserId();

                    // if (recentId != -1)
                    //{
                    /*  student.Id = recentId;
                      student.Fkuserid = recentId;
                      student.Username = "St_" + recentId;*/
                    int generatedId = DatabaseHandler.Instance.InsertStudent(student); // will insert into User and Student.
                    //  }
                }

            }

            return success;

        }


        public List<Student> GetStudents()
        {


            return DatabaseHandler.Instance.GetStudents();

        }

        public bool DeleteStudent(int id)
        {

            return DatabaseHandler.Instance.DeleteStudent(id);
        }

        #endregion

        #region ClassMethods

        public List<ClassEx> GetClasses()
        {
            List<ClassEx> listOfClassExs = new List<ClassEx>();
            List<Student> listOfStudents = DatabaseHandler.Instance.GetStudents();
            // her bliver studerende sat ind i listen:
            listOfClassExs = DatabaseHandler.Instance.GetClasses();

            foreach (ClassEx classEx in listOfClassExs)
            {
                foreach (Student student in listOfStudents)
                {
                    if (student.FkClassid == classEx.Id)
                    {
                        classEx.StudentsList.Add(student);
                    }
                }
            }

            return listOfClassExs;
        }

        public List<ClassEx> GetClassDetails(int id, int userrole)
        {
            List<ClassEx> classList = GetClasses();
            List<ClassEx> userList = new List<ClassEx>(); //De klasser brugeren er en del af.

            switch (userrole) //Her skal vi finde ud af hvilken klasse personen tilhører.
            {
                case 1: //Skoleleder
                    userList = classList;
                    break;

                case 2: //Teacher
                    foreach (ClassEx classEx in classList)
                    {
                        if (classEx.Fkteacherid == id)
                        {
                            userList.Add(classEx);
                        }
                    }
                    break;

                case 3: //Vikar
                    break;

                case 4: //Parent
                    List<Student> children = DatabaseHandler.Instance.FindParentsChildrenTEST(id);

                    foreach (Student st in children)
                    {
                        foreach (ClassEx classEx in classList)
                        {
                            if (st.FkClassid == classEx.Id)
                            {
                                if (!userList.Contains(classEx))
                                {
                                    userList.Add(classEx);
                                }
                            }
                        }
                    }

                    break;

                case 5: //Student
                    foreach (ClassEx classEx in classList)
                    {
                        foreach (Student student in classEx.StudentsList)
                        {
                            if (student.Id == id)
                            {
                                userList.Add(classEx);
                            }
                        }
                    }
                    break;
            }
            return userList;
        }

        public bool InsertClass(ClassEx theClass)
        {
            bool success;

            if (theClass.Id != 0) // update
            {
                success = DatabaseHandler.Instance.UpdateClass(theClass);
            }

            else
            {
                success = DatabaseHandler.Instance.InsertClass(theClass);
            }

            return success;
        }

        public bool DeleteClass(int classId)
        {
            return DatabaseHandler.Instance.DeleteClass(classId);
        }

        #endregion

        #region UserMethods

        public bool GetLoginDetails(string username, string password)
        {
            bool loggedIn = false;
            string cleanUsername = username.Replace("'", "");

            DatabaseHandler.Instance.GetLoginDetails(cleanUsername);
            if (Holder.Instance.LoginDetails != null && PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails.Password) == true)
            {
                loggedIn = true;
                DatabaseHandler.Instance.UpdateLastLogin(cleanUsername, DateTime.Now);
            }
            else
            {
                loggedIn = false;
            }
            return loggedIn;
        }

        public string GetUserDetails(int number)
        {
            string[] userDetails = new string[9];

            userDetails[0] = Convert.ToString(Holder.Instance.LoginDetails.Id);
            userDetails[1] = Holder.Instance.LoginDetails.Firstname;
            userDetails[2] = Holder.Instance.LoginDetails.Lastname;
            userDetails[3] = Holder.Instance.LoginDetails.Username;
            userDetails[4] = Convert.ToString(Holder.Instance.LoginDetails.Userrole);
            userDetails[5] = Holder.Instance.LoginDetails.City;
            userDetails[6] = Holder.Instance.LoginDetails.Address;
            userDetails[7] = Convert.ToString(Holder.Instance.LoginDetails.Phonenumber);
            userDetails[8] = Holder.Instance.LoginDetails.Email;

            return userDetails[number];
        }

        public string DeleteUser(int id)
        {
            string returnMessage = "";
            int userrole = DatabaseHandler.Instance.GetTheUserrole(id);
            string tableName = "";
            // delete user. Du har user tabel og evt. teacher, student eller parent.

            if (userrole == (int)EnumsWeb.Userrole.Teacher || userrole == (int)EnumsWeb.Userrole.Principal || userrole == (int)EnumsWeb.Userrole.Substitute)
            {
                tableName = "Teacher";
                bool result = DatabaseHandler.Instance.DeleteUser(id, tableName);

                if (!result && tableName == "Teacher")
                {
                    returnMessage =
                        "Underviseren blev ikke blevet slettet. Noget gik galt." +
                        "Du bedes kontakte support.";
                }
            }

            if (userrole == (int)EnumsWeb.Userrole.Parent)
            {

                tableName = "Parent";

                List<ParentEnrollment> parentEnrollments = DatabaseHandler.Instance.GetTheAssociatedEnrollmentsForTheParent(id);
                if (parentEnrollments.Count != 0)
                {
                    foreach (ParentEnrollment studentParent in parentEnrollments)
                    {
                        DatabaseHandler.Instance.DeleteConnectionBetweenParentAndEnrollment(studentParent.Fkparentid, studentParent.FkEnrollmentid);
                    }
                }

                List<StudentParent> children = DatabaseHandler.Instance.GetStudentParent(id);
                if (children.Count != 0)
                {
                    foreach (StudentParent studentParent in children)
                    {
                        DatabaseHandler.Instance.DeleteConnectionBetweenParentAndChild(studentParent.Fkparentid, studentParent.Fkstudentid);
                    }
                }
                bool result = DatabaseHandler.Instance.DeleteUser(id, tableName);

                if (!result && tableName == "Parent")
                {
                    returnMessage =
                        "Noget gik galt under sletningen af forældre. Forældren er ikke blevet slettet." +
                        "Du bedes kontakte support.";
                }

            }

            if (userrole == (int)EnumsWeb.Userrole.Student)
            {
                tableName = "Student";
                List<StudentParent> children = DatabaseHandler.Instance.GetStudentParent(id);
                if (children.Count != 0)
                {
                    foreach (StudentParent studentParent in children)
                    {
                        DatabaseHandler.Instance.DeleteConnectionBetweenParentAndChild(studentParent.Fkparentid, studentParent.Fkstudentid);
                    }
                }
                bool result = DatabaseHandler.Instance.DeleteUser(id, tableName);

                if (!result && tableName == "Student")
                {
                    returnMessage =
                        "Noget gik galt under sletningen af eleven. Eleven er ikke blevet slettet." +
                        "Du bedes kontakte support.";
                }
            }

            return returnMessage;
        }

        public bool ChangePassword(int id, string oldPass, string newPass, string confirmPass)
        {
            bool success = false;

            if (Holder.Instance.LoginDetails.Id == id)
            {
                if (newPass.Equals(confirmPass) && PasswordHash.ValidatePassword(oldPass, Holder.Instance.LoginDetails.Password) == true)
                {
                    DatabaseHandler.Instance.ChangePassword(id, PasswordHash.CreateHash(confirmPass));
                    success = true;
                }
            }
            return success;
        }

        public bool UpdateUserDetails(int id, string city, string address, int phone, string email)
        {
            return DatabaseHandler.Instance.UpdateUserDetails(id, city, address, phone, email);
        }

        #endregion

        #region Enrollments

        public bool CreateEnrollment(EnrollmentEx enrollment, List<ParentEx> parents)
        {

            enrollment.DateCreated = DateTime.Now.ToString(); // for at faa servertiden. mest korrekt.



            return DatabaseHandler.Instance.InsertEnrollment(enrollment, parents);

        }


        public List<EnrollmentEx> GetEnrollments()
        {



            return DatabaseHandler.Instance.GetEnrollments();
        }


        #endregion


        public List<TeacherEx> get_devices2()
        {
            List<TeacherEx> list = new List<TeacherEx>();

            //  for (int i = 0; i < 10; i++)
            list = DatabaseHandler.Instance.GetTeachers();
            // list.Add(i.ToString());


            return list;

        }


        public string get_devices3()
        {
            List<string> list = new List<string>();

            for (int i = 0; i < 10; i++)
                list.Add(i.ToString());

            // Serialize the results as JSON
            DataContractJsonSerializer serializer = new DataContractJsonSerializer(list.GetType());
            MemoryStream memoryStream = new MemoryStream();
            serializer.WriteObject(memoryStream, list);

            // Return the results serialized as JSON
            string json = Encoding.Default.GetString(memoryStream.ToArray());


            return json;

        }

        public void InsertEnrollment()
        {

            List<ParentEx> parents = new List<ParentEx>();

            EnrollmentEx en = new EnrollmentEx();

            en.ChildAddress = "Hejsmukke";
            en.ChildBirthdate = "android";
            en.ChildCity = "android";
            en.ChildFirstname = "android";
            en.ChildLastname = "android";
            en.ChildPhonenumber = 232;
            en.DateCreated = DateTime.Now.ToString();
            en.Fkschoolid = 1;
            en.Notes = "notetet";

            DatabaseHandler.Instance.InsertEnrollment(en, parents);
        }



    }
}
