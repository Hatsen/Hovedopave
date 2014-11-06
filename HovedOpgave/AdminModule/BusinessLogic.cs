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



        public async Task<bool> CreateTeacher(Teacher teacher)
        {
            //der mangler at blive genereteret id, username og password

            string username = "";

            //int generatedCount = await ServiceProxy.Instance.GetUserCount();

            teacher.Firstname = "Patrick";
            teacher.Lastname = "Larsen";
            teacher.City = "Kolding";
            teacher.Address = "Hagevej 22";
            teacher.Birthdate = "1991:14:06";
            teacher.Id = 100;
            teacher.Fkuserid = 100;
            teacher.Username = "test";
            teacher.Userrole = 1;
            teacher.Lastlogin = DateTime.Now;
            teacher.Password = PasswordHash.CreateHash("test");
            

            await ServiceProxy.Instance.InsertTeacher(teacher);


            //generer id og username og password inden du opretter. Når du updaterere skal der tjekkes om id allerede findes på objektet.




            return true;
        }




        public bool UpdateTeacher(Teacher teacher)
        {
            //der mangler at blive genereteret id, username og password

            //generer id og username og password inden du opretter. Når du updaterere skal der tjekkes om id allerede findes på objektet.

            // finder ud af fra id hvilken user der er tale om.


            return true;
        }



    }
}
