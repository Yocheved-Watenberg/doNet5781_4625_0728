﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DO
{
    [Serializable]
    public class BadBusIdException : Exception
    {
        public int ID;
        public BadBusIdException(int id) : base() => ID = id;
        public BadBusIdException(int id, string message) :
            base(message) => ID = id;
        public BadBusIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad bus license number: {ID}";
    }

    //public class BadIdCourseIDException : Exception
    //{
    //    public int personID;
    //    public int courseID;
    //    public BadPersonIdCourseIDException(int perID, int crsID) : base() { personID = perID; courseID = crsID; }
    //    public BadPersonIdCourseIDException(int perID, int crsID, string message) :
    //        base(message)
    //    { personID = perID; courseID = crsID; }
    //    public BadPersonIdCourseIDException(int perID, int crsID, string message, Exception innerException) :
    //        base(message, innerException)
    //    { personID = perID; courseID = crsID; }

    //    public override string ToString() => base.ToString() + $", bad person id: {personID} and course id: {courseID}";
    //}

}