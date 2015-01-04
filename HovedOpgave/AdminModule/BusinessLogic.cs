
/**
* Copyright (c) 2013 Lars Skaaning Jensen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Lars Skaaning Jensen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModule.Webservice;
using Crypto;
using System.Net.Mail;
using System.Net;

namespace AdminModule
{
    public class BusinessLogic
    {

        private static BusinessLogic instance;
        private string schoolEmail = "Birkealle@mail.dk";
        private int schoolId = 1;

        private BusinessLogic() { }

        public static BusinessLogic Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new BusinessLogic();
                }
                return instance;
            }

        }


        public string SendEmail(string toUserEmail, string subject, string body)
        {
            string result = "Succes";

            MailMessage msg = new MailMessage();

            msg.From = new MailAddress("");
            msg.To.Add(toUserEmail);
            msg.Subject = "test";
            msg.Body = "Test Content";
            msg.Priority = MailPriority.High;

            SmtpClient client = new SmtpClient();

            client.Credentials = new NetworkCredential("", "", "smtp.gmail.com");
            client.Host = "smtp.gmail.com";
            client.Port = 587;
            client.DeliveryMethod = SmtpDeliveryMethod.Network;
            client.EnableSsl = true;
            client.UseDefaultCredentials = false;

         
            try
            {
                client.Send(msg);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }

            return result;
        }



        public async Task<bool> CreateTeacher(TeacherEx teacher)
        {
            teacher.Lastlogin = DateTime.Now;
            teacher.Password = PasswordHash.CreateHash(teacher.Birthdate); // spørgsmålet er om det hele ikke bare skal være på webservicen?? altså genereing af pass og lastlogin.

            await ServiceProxy.Instance.InsertTeacher(teacher);

            return true;
        }



        public async Task<bool> UpdateTeacher(TeacherEx teacher)
        {
            await ServiceProxy.Instance.InsertTeacher(teacher);

            return true;
        }



        #region ParentMethods


        public async Task<bool> CreateParent(ParentEx parent)
        {

            parent.Lastlogin = DateTime.Now;
            parent.Password = PasswordHash.CreateHash(parent.Birthdate);

            await ServiceProxy.Instance.InsertParent(parent);


            return true;
        }


        public async Task<bool> UpdateParent(ParentEx parent)
        {
            await ServiceProxy.Instance.InsertParent(parent);

            return true;
        }


        #endregion



        #region StudentMethods


        /// <summary>
        /// Creates a student. Optinal to choose enrollment. If you link an enrollment the student will be created out from that enrollment.
        /// </summary>
        public async Task<bool> CreateStudent(string firstname, string lastname, string city, string address,string birthdate, int phonenumber, string email, int fkClassid, EnrollmentEx enrollment =null)
        {

            Student student = new Student();
            student.Firstname = firstname;
            student.Lastname = lastname;
            student.City = city;
            student.Email=email;
            student.Birthdate = birthdate;
            student.Address = address;
            student.Userrole = (int)Enums.Userrole.Student;
            student.Phonenumber = phonenumber;
            student.FkClassid = fkClassid;
            student.Fkschoolid=schoolId;

            student.Lastlogin = DateTime.Now;
            student.Password = PasswordHash.CreateHash(student.Birthdate);


            return await ServiceProxy.Instance.InsertStudent(student,enrollment);
        }


        public async Task<bool> UpdateStudent(Student theStudent)
        {

            return await ServiceProxy.Instance.InsertStudent(theStudent);
        }



        #endregion

        #region Class


        public async Task<bool> CreateClass(ClassEx theClass)
        {


            await ServiceProxy.Instance.InsertClass(theClass);

            //int generatedCount = await ServiceProxy.Instance.GetUserCount(); // begrund hvor vi ikke gør det her..
            // generer id på service 
            // smid id ind i teacher tabellen efterfølgende når der er success. BESKRIV HVORFOR I RAPPORTEN.




            //generer id og username og password inden du opretter. Når du updaterere skal der tjekkes om id allerede findes på objektet.




            return true;
        }



        public async Task<bool> UpdateClass(ClassEx theClass)
        {


            await ServiceProxy.Instance.InsertClass(theClass);

            //int generatedCount = await ServiceProxy.Instance.GetUserCount(); // begrund hvor vi ikke gør det her..
            // generer id på service 
            // smid id ind i teacher tabellen efterfølgende når der er success. BESKRIV HVORFOR I RAPPORTEN.




            //generer id og username og password inden du opretter. Når du updaterere skal der tjekkes om id allerede findes på objektet.




            return true;
        }


        public async Task<bool> DeleteClass(int classId)
        {

            return await ServiceProxy.Instance.DeleteClass(classId);
        }


        #endregion


        public async Task<string> DeleteUserById(int id)
        {




            // hvis det er en parent skal du tjekke om han har oprettet indmeldelser. De skal slettes fra systemet forst.
            // typecast user p[ userrole. n[r det er parent tjekker du khans liste.
            return await ServiceProxy.Instance.DeleteUserById(id);

        }


        public async Task<bool> ResetPasswordForSelectedUser(User selectedUser)
        {
            bool success = false;

            selectedUser.Password = PasswordHash.CreateHash("1234");

            if (selectedUser.Userrole == (int)Enums.Userrole.Parent)
            {
                success = await ServiceProxy.Instance.InsertParent((ParentEx)selectedUser);
            }
            else if (selectedUser.Userrole == (int)Enums.Userrole.Teacher || selectedUser.Userrole == (int)Enums.Userrole.Principal || selectedUser.Userrole == (int)Enums.Userrole.Substitute)
            {
                success = await ServiceProxy.Instance.InsertTeacher((TeacherEx)selectedUser);
            }
            else if (selectedUser.Userrole == (int)Enums.Userrole.Student)
            {
                success = await ServiceProxy.Instance.InsertStudent((Student)selectedUser);
            }


            return success;
        }


        public string GetAssociatedClasses(User user)
        {

            TeacherEx employee = (TeacherEx)user;

            StringBuilder stringBuilder = new StringBuilder();

            if (employee != null)
            {
                if (employee.ClassList.Count == 0)
                {
                    stringBuilder.AppendLine("Denne ansat er ikke tilknyttet nogen klasse.");
                }
                else
                {
                    stringBuilder.AppendLine("De tilknyttede klasser for ansat:" + employee.Firstname + " er:");
                    stringBuilder.AppendLine();
                    foreach (ClassEx classEx in employee.ClassList)
                    {
                        stringBuilder.AppendLine(classEx.Name);
                    }
                }
            }

            return stringBuilder.ToString();
        }


        public string GetAssociatedChildren(ParentEx parent = null, ClassEx classe = null)
        {
            StringBuilder stringBuilder = new StringBuilder();


            if (parent != null)
            {
                if (parent.ChildrenList.Count == 0)
                {
                    stringBuilder.AppendLine("Denne forældre har ingen børn tilknyttet.");
                }
                else
                {
                    stringBuilder.AppendLine("De tilknyttede børn for forældre " + parent.Firstname + " er:");
                    stringBuilder.AppendLine();
                    foreach (Student child in parent.ChildrenList)
                    {
                        stringBuilder.AppendLine(child.Firstname + " " + child.Lastname);
                    }
                }
            }

            else if (classe != null)
            {
                if (classe.StudentsList.Count == 0)
                {
                    stringBuilder.AppendLine("Denne klasse har ingen børn tilknyttet.");
                }
                else
                {
                    stringBuilder.AppendLine("De tilknyttede børn for klasse " + classe.Name + " er:");
                    stringBuilder.AppendLine();
                    foreach (Student child in classe.StudentsList)
                    {
                        stringBuilder.AppendLine(child.Firstname + " " + child.Lastname);
                    }
                }
            }

            return stringBuilder.ToString();
        }
    }
}
