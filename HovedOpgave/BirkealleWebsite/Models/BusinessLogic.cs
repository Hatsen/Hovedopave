using BirkealleWebsite.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using BirkealleWebsite.WebService;

namespace BirkealleWebsite.Models
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

<<<<<<< HEAD

        public async Task<bool> CreateEnrollment(Repository repository)
        {

            try
            {


                Student s = new Student();
                List<ParentEx> parents = new List<ParentEx>();

                Enrollment enrollment = new Enrollment();
                enrollment.ChildFirstname = repository.ChildFirstname;
                enrollment.ChildLastname = repository.ChildLastname;
                enrollment.ChildCity = repository.ChildCity;
                enrollment.ChildAddress = repository.ChildAddress;
                enrollment.ChildPhonenumber = repository.ChildPhonenumber;
                enrollment.ChildBirthdate = repository.ChildBirthdate;
                enrollment.Notes = repository.Notes;
                enrollment.Fkschoolid = 1; // id 1 er for birkealle.




                if (string.IsNullOrEmpty(repository.FatherUsername) || string.IsNullOrEmpty(repository.MotherUsername)) // the mother and father is not a couple.
                {

                    if (string.IsNullOrEmpty(repository.MotherUsername))
                    {
                        parents.Add(new ParentEx { Id = Convert.ToInt32(repository.FatherUsername.Substring(3, repository.FatherUsername.Length - 3)) });
                    }
                    else if (string.IsNullOrEmpty(repository.FatherUsername))
                    {
                        parents.Add(new ParentEx { Id = Convert.ToInt32(repository.MotherUsername.Substring(3, repository.MotherUsername.Length - 3)) });
                    }

                }

                else // the mother and father is a coulpe
                {


                    parents.Add(new ParentEx { Username = repository.MotherUsername, Id = Convert.ToInt32(repository.MotherUsername.Substring(3, repository.MotherUsername.Length - 3)) });
                    parents.Add(new ParentEx { Username = repository.FatherUsername, Id = Convert.ToInt32(repository.FatherUsername.Substring(3, repository.MotherUsername.Length - 3)) });


                }


                return await ServiceProxy.Instance.CreateEnrollment(enrollment, parents);

            }

            catch (Exception ex)
            {
                return false;

            }





        }



=======
        public async Task<bool> GetLoginDetails(string username, string password)
        {
            if (await ServiceProxy.Instance.GetLoginDetails(username, password) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<string> GetUserDetails(int number)
        {
            string result = await ServiceProxy.Instance.GetUserDetails(number);
            return result;
        }

        public async Task<List<ClassEx>> GetClasses()
        {
            List<ClassEx> result = await ServiceProxy.Instance.GetClasses();
            return result;
        }

        public async Task<List<ClassEx>> GetClassDetails(int id, int groupID)
        {
            List<ClassEx> result = await ServiceProxy.Instance.GetClassDetails(id, groupID);
            return result;
        }
>>>>>>> origin/master
    }
}