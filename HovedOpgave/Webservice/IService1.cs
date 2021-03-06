﻿


/**
* Copyright (c) 2013 Patrick Larsen, Lars Skaaning Jensen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Patrick Larsen, Lars Skaaning Jensen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Webservice.DB;
using Webservice.Extended;

namespace Webservice
{

    [ServiceContract(Name = "IService1", Namespace = "Webservice")]
    public interface IService1
    {
        [OperationContract]
        bool GetLoginDetails(string username, string password);

        [OperationContract]
        string GetUserDetails(int number);

        [OperationContract]
        List<Student> FindParentsChildren(int id);

        [OperationContract]
        List<ClassEx> GetClassDetails(int id, int userrole);

        [OperationContract]
        bool CreateAnnouncement(int creator, string header, string message, int group, int classID);

        [OperationContract]
        List<Announcement> GetAnnouncements(int group, int classID);

        [OperationContract]
        string GetAnnouncementCreator(int id);

        [OperationContract]
        bool ChangePassword(int id, string oldPass, string newPass, string confirmPass);

        #region Teacher


        [OperationContract]
        bool InsertTeacher(TeacherEx teacher);

        /*   [OperationContract]
           Teacher GetTeacher(); // bruges ikke endnu..*/

        [OperationContract]
        List<TeacherEx> GetTeachers();

        [OperationContract]
        string DeleteUser(int id);

        #endregion


        #region Parent

        [OperationContract]
        bool InsertParent(ParentEx parent);

        [OperationContract]
        List<ParentEx> GetParents();

        /*[OperationContract]
        bool DeleteParent(int id);*/


        #endregion

        #region Student
        [OperationContract]
        bool InsertStudent(Student parent, EnrollmentEx enrollment = null);

        [OperationContract]
        List<Student> GetStudents();

        [OperationContract]
        bool DeleteStudent(int id);

        #endregion


        #region Class

        [OperationContract]
        List<ClassEx> GetClasses();


        [OperationContract]
        bool InsertClass(ClassEx theClass);

        [OperationContract]
        bool DeleteClass(int id);

        #endregion



        #region Enrollment

        [OperationContract]
        bool CreateEnrollment(EnrollmentEx entollment, List<ParentEx> parents);


        [OperationContract]
        List<EnrollmentEx> GetEnrollments();



        #endregion


        //[OperationContract]
        //bool UpdateUserDetails(int id, string city, string address, int phone, string email);

        ///* [OperationContract]
        // [WebInvoke(Method = "GET",
        //          RequestFormat = WebMessageFormat.Json,
        //          ResponseFormat = WebMessageFormat.Json,
        //          UriTemplate = "Write")]
        //string Write();
        // */



        [OperationContract]
        bool UpdateUserDetails(int id, string city, string address, int phone, string email);


      /*   [OperationContract]
         [WebInvoke(Method = "GET",
                  RequestFormat = WebMessageFormat.Json,
                  ResponseFormat = WebMessageFormat.Json,
                  UriTemplate = "Write")]
        bool InsertScore(string time);
         */








        /*  [OperationContract]
          int GetMostRecentUserId();*/
    }


    // Use a data contract as illustrated in the sample below to add composite types to service operations.
    /*[DataContract]
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
    }*/
}
