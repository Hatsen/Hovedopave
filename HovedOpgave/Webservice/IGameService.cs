
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
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using Webservice.DB;
using Webservice.Extended;

namespace Webservice
{
    [ServiceContract(Name = "IGameService", Namespace = "Webservice")]
    public interface IGameService
    {

        [OperationContract]
        [WebGet(ResponseFormat = WebMessageFormat.Json,
            UriTemplate = "/Welcome")]
        List<TeacherEx> get_devices2();



        [OperationContract]
        [WebInvoke(Method = "POST",UriTemplate = "lars", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)]
        string get_devices3();



        [OperationContract]
        [WebInvoke(Method = "GET", UriTemplate = "InsertEn")]
        void InsertEnrollment();



        [OperationContract]
        [WebInvoke(Method = "POST", UriTemplate = "InsertScore/{testScore}", BodyStyle = WebMessageBodyStyle.Bare, ResponseFormat = WebMessageFormat.Json)] // {testScore}
        bool InsertScore(string testScore);//int testId, string startDate, string testTime, int testUser, double testResult
        


    }
}