using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL.BO
{
    [Serializable]
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineIdException)innerException).ID;
        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    [Serializable]
    public class BadLineTripIdException : Exception
    {
        public int ID;
        public BadLineTripIdException(string message, Exception innerException) :
            base(message, innerException) => ID = ((DO.BadLineTripIdException)innerException).lineId;
        public override string ToString() => base.ToString() + $", bad lineTrip id: {ID}";
    }
    [Serializable]
    public class BadStationIdException : Exception
    {
        public int code;
        public BadStationIdException(string message, Exception innerException) :
            base(message, innerException) => code = ((DO.BadStationIdException)innerException).code;
        public override string ToString() => base.ToString() + $", bad station code: {code}";
    }
    [Serializable]
    public class BadLineStationIdException : Exception
    {
        public int id;
        public BadLineStationIdException(string message, Exception innerException) :
                base(message, innerException) => id = ((DO.BadLineTripIdException)innerException).lineId;
        public override string ToString() => base.ToString() + $", bad linestation id : {id}";
    }
    [Serializable]
    public class LessThanTwoStationsException : Exception
    {
        public LessThanTwoStationsException(string message) : base(message) { }
        public override string ToString() => "You must choose at least two stations to create a line";
    }
    [Serializable]
    public class BadCodeException : Exception
    {
        public BadCodeException(string message) : base(message) { }
        public override string ToString() => "Your code's content must be only numbers";
    }
    [Serializable]
    public class NotSelectedAreaException : Exception
    {
        public NotSelectedAreaException(string message) : base(message) { }
        public override string ToString() => "You haven't selected any area for this line";
    }
    [Serializable]
    public class NotSelectedLineException : Exception
    {
        public NotSelectedLineException(string message) : base(message) { }
        public override string ToString() => "You haven't selected any line ";
    }
}
