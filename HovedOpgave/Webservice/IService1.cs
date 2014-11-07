﻿using System;
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
        bool CreateTeacher();

        [OperationContract]
        Teacher GetTeacher();

        [OperationContract]
        List<Teacher> GetTeachers();

        [OperationContract]
        List<Student> GetStudents();

        [OperationContract]
        bool InsertTeacher(Teacher teacher);

        [OperationContract]
        int GetMostRecentUserId();

        [OperationContract]
        string GetUserDetails(int number);

        [OperationContract]
        string CreateAnnouncement(string announcement, int group);
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
