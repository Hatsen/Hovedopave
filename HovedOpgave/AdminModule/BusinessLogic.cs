using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdminModule.Webservice;

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

            int generatedCount = await ServiceProxy.Instance.GetUserCount();

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
