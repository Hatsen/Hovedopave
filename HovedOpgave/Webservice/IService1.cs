using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Webservice.DB;

namespace Webservice
{
    [ServiceContract]
    public interface IService1
    {
        [OperationContract]
        bool GetLoginDetails(string username, string password);

        [OperationContract]
        string GetUserDetails(int number);

        [OperationContract]
        bool CreateAnnouncement(int creator, string header, string message, int group, int classID);

        [OperationContract]
        List<Announcement> GetAnnouncements(int group, int classID);

        [OperationContract]
        bool ChangePassword(int id, string oldPass, string newPass, string confirmPass);

        #region Teacher
    

        [OperationContract]
        bool InsertTeacher(Teacher teacher);

     /*   [OperationContract]
        Teacher GetTeacher(); // bruges ikke endnu..*/

        [OperationContract]
        List<Teacher> GetTeachers();

        #endregion


        #region Parent

        [OperationContract]
        bool InsertParent(Parent parent);

        [OperationContract]
        List<Parent> GetParents();


        #endregion

        #region Student
        [OperationContract]
        bool InsertStudent(Student parent);

        [OperationContract]
        List<Student> GetStudents();

        #endregion


        #region Class

        [OperationContract]
        List<Class> GetClasses();


        [OperationContract]
        bool InsertClass(Class theClass);


        #endregion


      /*  [OperationContract]
        int GetMostRecentUserId();*/



    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
