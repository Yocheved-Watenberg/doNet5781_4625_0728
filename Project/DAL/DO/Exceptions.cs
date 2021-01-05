using System;
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
    public class BadLineIdException : Exception
    {
        public int ID;
        public BadLineIdException(int id) : base() => ID = id;
        public BadLineIdException(int id, string message) :
            base(message) => ID = id;
        public BadLineIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad line id: {ID}";
    }
    public class BadBusOnTripIdException : Exception
    {
        public int ID;
        public BadBusOnTripIdException(int id) : base() => ID = id;
        public BadBusOnTripIdException(int id, string message) :
            base(message) => ID = id;
        public BadBusOnTripIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad BusOnTrip id: {ID}";
    }
    public class BadAdjacentStationsIdException : Exception
    {
        public int station1;
        public int station2;
        public BadAdjacentStationsIdException(int s1, int s2) : base() { station1 = s1; station2 = s2; }
        public BadAdjacentStationsIdException(int s1, int s2, string message) :
            base(message)
        { station1 = s1; station2 = s2; }
        public BadAdjacentStationsIdException(int s1, int s2, string message, Exception innerException) :
            base(message, innerException)
        { station1 = s1; station2 = s2; }

        public override string ToString() => base.ToString() + $", bad adjacent stations id: {station1} and  id: {station2}";
    }
    public class BadLineStationIdException : Exception
    {
        public int lineId;
        public int station;
        public BadLineStationIdException(int l, int s) : base() { lineId = l; station = s; }
        public BadLineStationIdException(int l, int s, string message) : base(message) { lineId = l; station = s; }
        public BadLineStationIdException(int l, int s, string message, Exception innerException) :
            base(message, innerException)
        { lineId = l; station = s; }

        public override string ToString() => base.ToString() + $", bad line stations line id: {lineId} and  station: {station}";
    }
    public class BadLineTripIdException : Exception
    {
        public int lineId;
        public int startAt;
        public BadLineTripIdException(int l, int s) : base() { lineId = l; startAt = s; }
        public BadLineTripIdException(int l, int s, string message) : base(message) { lineId = l; startAt = s; }
        public BadLineTripIdException(int l, int s, string message, Exception innerException) :
            base(message, innerException)
        { lineId = l; startAt = s; }

        public override string ToString() => base.ToString() + $", bad line trip line id: {lineId} and startAt: {startAt}";
    }
    public class BadStationIdException : Exception
    {
        public int code;
        public BadStationIdException(int c) : base() => code = c;
        public BadStationIdException(int c, string message) :
            base(message) => code = c;
        public BadStationIdException(int c, string message, Exception innerException) :
            base(message, innerException) => code = c;

        public override string ToString() => base.ToString() + $", bad station code: {code}";
    }
    public class BadTripIdException : Exception
    {
        public int ID;
        public BadTripIdException(int id) : base() => ID = id;
        public BadTripIdException(int id, string message) :
            base(message) => ID = id;
        public BadTripIdException(int id, string message, Exception innerException) :
            base(message, innerException) => ID = id;

        public override string ToString() => base.ToString() + $", bad trip id: {ID}";
    }
    public class BadUserIdException : Exception
    {
        public string name;
        public BadUserIdException(string n) : base() => name = n;
        public BadUserIdException(string n, string message) :
            base(message) => name = n;
        public BadUserIdException(string n, string message, Exception innerException) :
            base(message, innerException) => name = n;

        public override string ToString() => base.ToString() + $", bad user name: {name}";
    }
}

