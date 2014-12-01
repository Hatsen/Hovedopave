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

namespace Webservice
{
    public class Service1 : IService1
    {
        #region AnnouncementMethods
        public bool CreateAnnouncement(int creator, string header, string message, int groupID, int classID)
        {
            if (DatabaseHandler.Instance.CreateAnnouncement(creator, header, message, groupID, classID) == true)
            {
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

        /*    public Teacher GetTeacher()
        {
            Teacher t = new Teacher();
            t.Id = 1; t.Firstname = "Hr Jensen";

            return t;
        }*/
        public List<TeacherEx> GetTeachers()
        {
            List<TeacherEx> listOfTeacherExs = DatabaseHandler.Instance.GetTeachers();
            List<ClassEx> listOfClasses = DatabaseHandler.Instance.GetClasses();
            //listOfTeacherExs = DatabaseHandler.Instance.GetTeachers();

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

        public bool CreateParent(ParentEx parent)
        {

            return true;
        }


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
            // søg efter children i studentparent table
            //ParentEx.Children = FindParentsChildren();
            List<ParentEx> parentExlist = new List<ParentEx>();
            parentExlist = DatabaseHandler.Instance.GetParents();

            foreach (ParentEx parent in parentExlist)
            {
                List<Student> children = new List<Student>();
                children = DatabaseHandler.Instance.FindParentsChildrenTEST(parent.Id);

                //  children = DatabaseHandler.Instance.FindParentsChildren(parent.Id);

                //children = DatabaseHandler.Instance.FindParentsChildren(parent.Id);


                if (children.Count != 0)
                {
                    parent.ChildrenList = children;


                }


            }
            return parentExlist;
        }


        /* public bool DeleteParent(int id)
         {

             return DatabaseHandler.Instance.DeleteParent(id);
         }*/

        #endregion

        #region StudentMethods


        public bool InsertStudent(Student student)
        {

            bool success = false;

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
                success = DatabaseHandler.Instance.InsertStudent(student); // will insert into User and Teacher.
                //  }
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
            HttpContext context = HttpContext.Current;
            bool loggedIn = false;

            DatabaseHandler.Instance.GetLoginDetails(username);
            if (Holder.Instance.LoginDetails != null && PasswordHash.ValidatePassword(password, Holder.Instance.LoginDetails.Password) == true)
            {
                loggedIn = true;
                DatabaseHandler.Instance.UpdateLastLogin(username, DateTime.Now);
            }
            else
            {
                loggedIn = false;
            }
            return loggedIn;
        }

        public string GetUserDetails(int number)
        {
            string[] userDetails = new string[5];

            userDetails[0] = Convert.ToString(Holder.Instance.LoginDetails.Id);
            userDetails[1] = Holder.Instance.LoginDetails.Firstname;
            userDetails[2] = Holder.Instance.LoginDetails.Lastname;
            userDetails[3] = Holder.Instance.LoginDetails.Username;
            userDetails[4] = Convert.ToString(Holder.Instance.LoginDetails.Userrole);

            return userDetails[number];
        }

        public string DeleteUser(int id)
        {
            string returnMessage = "";
            int userrole = DatabaseHandler.Instance.GetTheUserrole(id);
            string tableName = "";
            // delete user. Du har user tabel og evt. teacher, student eller parent.

            if (userrole == (int)EnumsWeb.Userrole.Teacher)
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

        #endregion
    }
}
