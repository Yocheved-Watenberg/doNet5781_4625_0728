﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
        [Serializable]
    public class BadLineException : Exception
    {
            public int ID;
            public BadLineException(string message, Exception innerException) :
                base(message, innerException) => ID = ((DO.BadLineIdException)innerException).ID;
            public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    //a revoir en cas d erreur



    [Serializable]
    public class BadStationException : Exception
    {
        public int code;
        public BadStationException(string message, Exception innerException) :
            base(message, innerException) => code = ((DO.BadStationIdException)innerException).code;
        public override string ToString() => base.ToString() + $", bad station code: {code}";
    }
    [Serializable]
    public class  BadLineTripIdException : Exception
    {
        public int id;
        public BadLineTripIdException(string message, Exception innerException) :
        base(message, innerException) => id = ((DO.BadLineTripIdException)innerException).code;
    public override string ToString() => base.ToString() + $", bad line trip id : {id}";
}
[Serializable]
    public class LessThanTwoStationsException: Exception
    {
        public LessThanTwoStationsException(string message) : base(message){}
        public override string ToString() => "You must choose at least two stations to create a line";
    }
    public class BadCodeException  : Exception
    {
        public BadCodeException(string message) : base(message) { }
    public override string ToString() => "Your code's content must be only numbers";
    }
}
//public class ExistingLineCodeException: Exception
//    {
//    public ExistingLineCodeException(string message) : base(message) { }
//    public override string ToString() => "Your code is already used for another line";
//}

    public class BadFormatException : Exception
    {
        public BadFormatException(string message) : base(message) {}
    }
public class  NotSelectedAreaException: Exception
    {
    public NotSelectedAreaException(string message) : base(message) { }
    public override string ToString() => "You haven't selected any area for this line";
    }


    //a revoir en cas d erreur


    //[Serializable]
    //public class BadLecturerIdException : Exception
    //{
    //    public int ID;
    //    public BadLecturerIdException(string message, Exception innerException) :
    //        base(message, innerException) => ID = ((DO.BadPersonIdException)innerException).ID;
    //    public override string ToString() => base.ToString() + $", bad student id: {ID}";
    //}

    //        [Serializable]
    //        public class BadStudentIdCourseIDException : Exception
    //        {
    //            public int personID;
    //            public int courseID;
    //            public BadStudentIdCourseIDException(string message, Exception innerException) :
    //                base(message, innerException)
    //            {
    //                personID = ((DO.BadPersonIdCourseIDException)innerException).personID;
    //                courseID = ((DO.BadPersonIdCourseIDException)innerException).courseID;
    //            }
    //            public override string ToString() => base.ToString() + $", bad student id: {personID} and course ID: {courseID}";
    //        }

    //    }


