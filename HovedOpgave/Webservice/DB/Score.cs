using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Webservice.DB
{
    [DataContract]
    public class Score
    {

        private int id;
        private int userId;
        private int testTime;
        private double result;
        private int testId;
        private string testDate;
        private int schoolId;
        
        [DataMember]
        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        [DataMember]
        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        [DataMember]
        public int TestTime
        {
            get { return testTime; }
            set { testTime = value; }
        }
        [DataMember]
        public double Result
        {
            get { return result; }
            set { result = value; }
        }
        [DataMember]
        public int TestId
        {
            get { return testId; }
            set { testId = value; }
        }
        [DataMember]
        public string TestDate
        {
            get { return testDate; }
            set { testDate = value; }
        }

        [DataMember]
        public int SchoolId
        {
            get { return schoolId; }
            set { schoolId = value; }
        }


    }
}