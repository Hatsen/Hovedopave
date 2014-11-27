using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModule.Webservice;
using Crypto;

namespace AdminModule
{
    public class BusinessLogic
    {

        private static BusinessLogic instance;

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


        public async Task<bool> CreateStudent(Student student)
        {

            student.Lastlogin = DateTime.Now;
            student.Password = PasswordHash.CreateHash(student.Birthdate);


            await ServiceProxy.Instance.InsertStudent(student);



            return true;
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
            else if (selectedUser.Userrole == (int)Enums.Userrole.Teacher)
            {
                success = await ServiceProxy.Instance.InsertTeacher((TeacherEx)selectedUser);
            }
            else if (selectedUser.Userrole == (int)Enums.Userrole.Student)
            {
                success = await ServiceProxy.Instance.InsertStudent((Student)selectedUser);
            }


            return success;
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

            else if (classe!=null)
            {
                if (classe.StudentsList.Count == 0)
                {
                    stringBuilder.AppendLine("Denne klasse har ingen børn tilknyttet.");
                }
                else
                {
                    stringBuilder.AppendLine("De tilknyttede børn for klasse " + classe.Name+ " er:");
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
