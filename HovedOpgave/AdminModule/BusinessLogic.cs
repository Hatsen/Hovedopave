﻿using System;
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
            // Husk at id og username skal genereres på servicesiden. (tynd klient)
            // det behøver ikke forholde sig sådan med password. Den har sammen med de andre attributter
            // ikke noget med tallet fra Id at gøre.

          
            //teacher.Firstname = "Lars";
            //teacher.Lastname = "Larsen";
            //teacher.City = "Kolding";
          //  teacher.Address = "Hagevej 22";
         //   teacher.Birthdate = "06/12-1992";
           // teacher.Userrole = 1; // skoleleder, vikar, underviser

/*            List<int> listen = new List<int>(); listen.Add(1); listen.Add(2); 

            for (int i = 0; i < 3; i++)
            {
                listen.RemoveAt(i);
            }
            */


            teacher.Lastlogin = DateTime.Now;
            teacher.Password = PasswordHash.CreateHash(teacher.Birthdate);


            await ServiceProxy.Instance.InsertTeacher(teacher);

            //int generatedCount = await ServiceProxy.Instance.GetUserCount(); // begrund hvor vi ikke gør det her..
            // generer id på service 
            // smid id ind i teacher tabellen efterfølgende når der er success. BESKRIV HVORFOR I RAPPORTEN.




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
