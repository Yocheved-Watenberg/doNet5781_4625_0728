using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using DLAPI;
using DO;

namespace DL
{
    sealed class DLXML : IDAL    //internal
        {
            #region singelton
            static readonly DLXML instance = new DLXML();
            static DLXML() { }// static ctor to ensure instance init is done just before first usage
            DLXML() { } // default => private
            public static DLXML Instance { get => instance; }// The public Instance prolinety to use
            #endregion

            #region DS XML Files

            string linePath = @"LineXml.xml"; //XElement
            public string stationPath  = @"StationXml.xml"; //XMLSerializer
            string lineStationPath = @"LineStationXml.xml"; //XMLSerializer
            string adjacentStationPath = @"AdjacentsStationXml.xml"; //XMLSerializer
            string lineTripPath= @"LineTripXml.xml"; //XMLSerializer


        #endregion

        #region Line
        public DO.Line GetLine(int code)
            {
                XElement lineRootElem = XMLTools.LoadListFromXMLElement(linePath);

                 Line l= (from line in lineRootElem.Elements()
                            where int.Parse(line.Element("Code").Value) == code
                            select new Line()
                            {
                                Id = Int32.Parse(line.Element("ID").Value),
                                Code = Int32.Parse(line.Element("Code").Value),
                                Area= (DO.Enums.Areas)Enum.Parse(typeof(DO.Enums.Areas), line.Element("Area").Value),
                                FirstStation= Int32.Parse(line.Element("FirstStation").Value),
                                LastStation = Int32.Parse(line.Element("LastStation").Value),
         
                            }
                            ).FirstOrDefault();

                if (l == null)
                    throw new DO.BadLineIdException(code, $"bad line code: {code}");

                return l;
            }
        public IEnumerable<DO.Line> GetAllLines()
        {
            XElement LinesRootElem = XMLTools.LoadListFromXMLElement(linePath);

            return (from l in LinesRootElem.Elements()
                    select new Line()
                    {
                        Id = Int32.Parse(l.Element("ID").Value),
                        Code = Int32.Parse(l.Element("Code").Value),
                        Area = (DO.Enums.Areas)Enum.Parse(typeof(DO.Enums.Areas), l.Element("Area").Value),
                        FirstStation = Int32.Parse(l.Element("FirstStation").Value),
                        LastStation = Int32.Parse(l.Element("LastStation").Value),

                    }
                   );
        }
        public IEnumerable<DO.Line> GetAllLinesBy(Predicate<DO.Line> predicate)
        {
            XElement LinesRootElem = XMLTools.LoadListFromXMLElement(linePath);

            return from l in LinesRootElem.Elements()
                   let l1 = new Line()
                   {
                       Id = Int32.Parse(l.Element("ID").Value),
                       Code = Int32.Parse(l.Element("Code").Value),
                       Area = (DO.Enums.Areas)Enum.Parse(typeof(DO.Enums.Areas), l.Element("Area").Value),
                       FirstStation = Int32.Parse(l.Element("FirstStation").Value),
                       LastStation = Int32.Parse(l.Element("LastStation").Value),
                   }
                   where predicate(l1)
                   select l1;
        }
        public void AddLine(DO.Line Line)
        {
            XElement LinesRootElem = XMLTools.LoadListFromXMLElement(linePath);

            XElement l1 = (from l in LinesRootElem.Elements()
                             where int.Parse(l.Element("Code").Value) == Line.Code
                             select l).FirstOrDefault();

            if (l1 != null)
                throw new DO.BadLineIdException(Line.Code, "Duplicate Line Code");

            XElement LineElem = new XElement("Line", new XElement("Code", Line.Code),
                                new XElement("Id", Line.Id),
                                new XElement("Code", Line.Code),
                                new XElement("Area", Line.Area.ToString()),
                                new XElement("FirstStation", Line.FirstStation),
                                new XElement("LastStation", Line.LastStation));

            LinesRootElem.Add(LineElem);

            XMLTools.SaveListToXMLElement(LinesRootElem, linePath);
        }

        public void DeleteLine(int code)
        {
            XElement LinesRootElem = XMLTools.LoadListFromXMLElement(linePath);

            XElement line = (from l in LinesRootElem.Elements()
                            where int.Parse(l.Element("Code").Value) == code
                            select l).FirstOrDefault();

            if (line != null)
            {
                line.Remove(); //<==>   Remove line from LinesRootElem

                XMLTools.SaveListToXMLElement(LinesRootElem, linePath);
            }
            else
                throw new DO.BadLineIdException(code, $"bad Line code: {code}");
        }

        public void UpdateLine(DO.Line Line)
        {
            XElement LinesRootElem = XMLTools.LoadListFromXMLElement(linePath);

            XElement line = (from p in LinesRootElem.Elements()
                            where int.Parse(p.Element("Code").Value) == Line.Code
                            select p).FirstOrDefault();

            if (line != null)
            {
                line.Element("Id").Value = Line.Id.ToString();
                line.Element("Code").Value = Line.Code.ToString();
                line.Element("Area").Value = Line.Area.ToString();
                line.Element("FirstStation").Value = Line.FirstStation.ToString();
                line.Element("LastStation").Value = Line.LastStation.ToString();
              

                XMLTools.SaveListToXMLElement(LinesRootElem, linePath);
            }
            else
                throw new DO.BadLineIdException(Line.Code, $"bad Line code: {Line.Code}");
        }
    
    #endregion
            #region Station
    public void AddStation(DO.Station station)
    {
        List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

        if (ListStations.FirstOrDefault(s => s.Code == station.Code) != null)
            throw new DO.BadStationIdException(station.Code, "this station already exists in the list of stations or this code has been used for a deleted station");
            ListStations.Add(station);
            XMLTools.SaveListToXMLSerializer(ListStations, stationPath);
    }
    public void DeleteStation(int code)
    {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            DO.Station myStation = ListStations.Find(s => s.Code == code);
        if ((myStation != null) && (myStation.IsDeleted == false))
        {
            // DataSource.ListStation.Remove(myStation);
            myStation.IsDeleted = true;
        }
        else
            throw new DO.BadStationIdException(code, "this station doesn't exist in the list of station");
            XMLTools.SaveListToXMLSerializer(ListStations, stationPath);
        }

    public DO.Station GetStation(int code)
    {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            DO.Station station = ListStations.Find(s => (s.Code == code) && (s.IsDeleted == false));

        if (station != null)
            return station;
        else
            throw new DO.BadStationIdException(code, "this station doesn't exist in the list of station");
    }

    public IEnumerable<DO.Station> GetAllStation()
    {
        List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);

        return from station in ListStations.FindAll(s => s.IsDeleted == false)
               select station;
    }

    public IEnumerable<DO.Station> GetAllStationBy(Predicate<DO.Station> predicate)
    {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            if (predicate != null)
        {
            return from station in ListStations.FindAll(s => s.IsDeleted == false)
                   where predicate(station)
                   select station;
        }
        return GetAllStation();
    }

    public void UpdateStation(DO.Station station)
    {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            DO.Station myStation = ListStations.Find(s => s.Code == station.Code);
        if ((myStation != null) && (myStation.IsDeleted == false))
        {
            ListStations.Remove(myStation);
            ListStations.Add(station);
        }
        else
            throw new DO.BadStationIdException(station.Code, $"bad station code : {station.Code}");
            XMLTools.SaveListToXMLSerializer(ListStations, stationPath);

        }
    public void UpdateStation(int code, Action<DO.Station> update)
    {
            List<Station> ListStations = XMLTools.LoadListFromXMLSerializer<Station>(stationPath);
            var myStation = ListStations .FirstOrDefault(predicate => predicate.Code == code);
        if ((myStation != null) && (myStation.IsDeleted == false))
        {
            update(myStation);
        }
            XMLTools.SaveListToXMLSerializer(ListStations, stationPath);
    }
        #endregion
        #region Bus
        public void AddBus(DO.Bus bus)
        {
            List<Bus> ListStations = XMLTools.LoadListFromXMLSerializer<Bus>(stationPath);
            if (DataSource.ListBus.FirstOrDefault(b => b.LicenseNum == bus.LicenseNum) != null)
                throw new DO.BadBusIdException(bus.LicenseNum, "this bus already exists in the list of bus");
            DataSource.ListBus.Add(bus.Clone());
        }
        public void DeleteBus(int licenseNum)
        {
            DO.Bus myBus = DataSource.ListBus.Find(b => b.LicenseNum == licenseNum);
            if (myBus != null)
            {
                DataSource.ListBus.Remove(myBus);
            }
            else
                throw new DO.BadBusIdException(licenseNum, $"bad person id: {licenseNum}");
        }
        public DO.Bus GetBus(int licenseNum)
        {
            DO.Bus bus = DataSource.ListBus.Find(b => b.LicenseNum == licenseNum);

            if (bus != null)
                return bus.Clone();
            else
                throw new DO.BadBusIdException(licenseNum, $"bad bus license num : {licenseNum}");
        }
        public IEnumerable<DO.Bus> GetAllBus()
        {
            return from bus in DataSource.ListBus
                   select bus.Clone();
        }
        public IEnumerable<DO.Bus> GetAllBusBy(Predicate<DO.Bus> predicate)
        {
            if (predicate != null)
            {
                return from bus in DataSource.ListBus
                       where predicate(bus)
                       select bus.Clone();
            }
            return GetAllBus();
        }
        public void UpdateBus(DO.Bus bus)
        {
            DO.Bus myBus = DataSource.ListBus.Find(b => b.LicenseNum == bus.LicenseNum);
            if (myBus != null)
            {
                DataSource.ListBus.Remove(myBus);
                DataSource.ListBus.Add(bus.Clone());
            }
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus license num: {bus.LicenseNum}");
        }
        public void UpdateBus(int licenseNum, Action<DO.Bus> update)
        {
            var myBus = DataSource.ListBus.FirstOrDefault(predicate => predicate.LicenseNum == licenseNum);
            if (myBus != null)
            {
                update(myBus);
            }
        }
        #endregion
        #region BusOnTrip
        public void AddBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            if (DataSource.ListBusOnTrip.FirstOrDefault(b => b.Id == busOnTrip.Id) != null)
                throw new DO.BadBusOnTripIdException(busOnTrip.Id, "this busOnTrip already exists in the list of busOnTrip");
            DataSource.ListBusOnTrip.Add(busOnTrip.Clone());
        }
        public void DeleteBusOnTrip(int Id)
        {
            DO.BusOnTrip myBusOnTrip = DataSource.ListBusOnTrip.Find(b => b.Id == Id);
            if (myBusOnTrip != null)
            {
                DataSource.ListBusOnTrip.Remove(myBusOnTrip);
            }
            else
                throw new DO.BadBusOnTripIdException(Id, $"bad busOnTrip id: {Id}");
        }
        public IEnumerable<DO.BusOnTrip> GetAllBusOnTrip()
        {
            return from busOnTrip in DataSource.ListBusOnTrip
                   select busOnTrip.Clone();
        }
        public DO.BusOnTrip GetBusOnTrip(int Id)
        {
            DO.BusOnTrip busOnTrip = DataSource.ListBusOnTrip.Find(b => b.Id == Id);

            if (busOnTrip != null)
                return busOnTrip.Clone();
            else
                throw new DO.BadBusOnTripIdException(Id, $"bad busOnTrip id: {Id}");
        }
        public IEnumerable<DO.BusOnTrip> GetAllBusOnTripBy(Predicate<DO.BusOnTrip> predicate)
        {
            if (predicate != null)
            {
                return from busOnTrip in DataSource.ListBusOnTrip
                       where predicate(busOnTrip)
                       select busOnTrip.Clone();
            }
            return GetAllBusOnTrip();
        }
        public void UpdateBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            DO.BusOnTrip myBusOnTrip = DataSource.ListBusOnTrip.Find(b => b.Id == busOnTrip.Id);
            if (myBusOnTrip != null)
            {
                DataSource.ListBusOnTrip.Remove(myBusOnTrip);
                DataSource.ListBusOnTrip.Add(busOnTrip.Clone());
            }
            else
                throw new DO.BadBusOnTripIdException(busOnTrip.Id, $"bad busOnTrip id: {busOnTrip.Id}");
        }
        public void UpdateBusOnTrip(int Id, Action<DO.BusOnTrip> update)
        {
            var myBusOnTrip = DataSource.ListBusOnTrip.FirstOrDefault(predicate => predicate.Id == Id);
            if (myBusOnTrip != null)
            {
                update(myBusOnTrip);
            }
        }
        #endregion
        #region AdjacentStations 
        public void AddAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);
            List<DO.AdjacentStations> myList = ListAdjacentStations.FindAll(s => s.Station1 == adjacentStations.Station1);
            if (myList.FirstOrDefault(adj => adj.Station2 == adjacentStations.Station2) != null)
                throw new DO.BadAdjacentStationsIdException(adjacentStations.Station1, adjacentStations.Station2, "theses adjacent stations already exist in the list of adjacents stations");
           ListAdjacentStations.Add(adjacentStations);
            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationPath);

        }
        public void DeleteAdjacentStations(int station1, int station2)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);
            DO.AdjacentStations adj = ListAdjacentStations.Find(a => (a.Station1 == station1) && (a.Station2 == station2));
            if (adj != null)
            {
               ListAdjacentStations.Remove(adj);
            }
            else
                throw new DO.BadAdjacentStationsIdException(station1, station2, "theses adjacent stations doesn't exist in the list of adjacents stations");
            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationPath);
        }
        public void DeleteAdjacentsStationsFrom(DO.AdjacentStations adj)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);
            ListAdjacentStations.Remove(adj);
            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationPath);
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);

            return from adj in ListAdjacentStations
                   select adj;
        }
        public DO.AdjacentStations GetAdjacentStations(int station1, int station2)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);
             DO.AdjacentStations adj = ListAdjacentStations.Find(a => (a.Station1 == station1) && (a.Station2 == station2));

            if (adj != null)
                return adj;
            else
                throw new DO.BadAdjacentStationsIdException(station1, station2, "theses adjacent stations doesn't exist in the list of adjacents stations");
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);

            if (predicate != null)
            {
                return from adj in ListAdjacentStations
                       where predicate(adj)
                       select adj;
            }
            return GetAllAdjacentStations();
        }
        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);

            DO.AdjacentStations adj =ListAdjacentStations.Find(a => (a.Station1 == adjacentStations.Station1) && (a.Station2 == adjacentStations.Station2));
            if (adj != null)
            {
               ListAdjacentStations.Remove(adj);
                ListAdjacentStations.Add(adjacentStations);
            }
            else
                throw new DO.BadAdjacentStationsIdException(adjacentStations.Station1, adjacentStations.Station2, "these adjacent stations doesn't exist in the list of adjacents stations");
            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationPath);
        }
        public void UpdateAdjacentStations(int Station1, int Station2, Action<DO.AdjacentStations> update)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);
             var adj =ListAdjacentStations.FirstOrDefault(predicate => (predicate.Station1 == Station1) && (predicate.Station2 == Station2));
            if (adj != null)
            {
                update(adj);
            }
            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationPath);
        }
        public void UpdateAdjacentStations(int StationToChange, Action<DO.AdjacentStations> update)
        {
            List<AdjacentStations> ListAdjacentStations = XMLTools.LoadListFromXMLSerializer<AdjacentStations>(adjacentStationPath);
            var adj = ListAdjacentStations.FirstOrDefault(predicate => (predicate.Station1 == StationToChange) || (predicate.Station2 == StationToChange));
            if (adj != null)
            {
                update(adj);
            }
            XMLTools.SaveListToXMLSerializer(ListAdjacentStations, adjacentStationPath);
        }
        #endregion
        #region LineTrip 

        public void AddLineTrip(DO.LineTrip lineTrip)
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            List<DO.LineTrip> myList =ListLineTrip.FindAll(l => l.LineId == lineTrip.LineId);
            if (myList.FirstOrDefault(l => l.StartAt == lineTrip.StartAt) != null)
                throw new DO.BadLineTripIdException(lineTrip.LineId, (int)lineTrip.StartAt.TotalMilliseconds, "this line trip already exists in the list of line trip");
           ListLineTrip.Add(lineTrip);
            XMLTools.SaveListToXMLSerializer(ListLineTrip, lineTripPath);

        }
        public void DeleteLineTrip(int id, TimeSpan startAt)
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            DO.LineTrip myLineTrip = ListLineTrip.Find(l => (l.LineId == id) && (l.StartAt == startAt));
            if (myLineTrip != null)
            {
                ListLineTrip.Remove(myLineTrip);
            }
            else
                throw new DO.BadLineTripIdException(id, (int)startAt.TotalMilliseconds, "this line trip doesn't exists in the list of line trip");
            XMLTools.SaveListToXMLSerializer(ListLineTrip, lineTripPath);

        }

        public IEnumerable<DO.LineTrip> GetAllLineTrip()
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            return from lineTrip in ListLineTrip
                   select lineTrip;
        }

        public DO.LineTrip GetLineTrip(int id, TimeSpan startAt)
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            DO.LineTrip lineTrip = ListLineTrip.Find(l => (l.LineId == id) && (l.StartAt == startAt));

            if (lineTrip != null)
                return lineTrip;
            else
                throw new DO.BadLineTripIdException(id, (int)startAt.TotalMilliseconds, "this line trip doesn't exists in the list of line trip");
        }
        public IEnumerable<DO.LineTrip> GetAllLineTripBy(Predicate<DO.LineTrip> predicate)
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            if (predicate != null)
            {
                return from lineTrip in ListLineTrip
                       where predicate(lineTrip)
                       select lineTrip;
            }
            return GetAllLineTrip();
        }

        public void UpdateLineTrip(DO.LineTrip lineTrip)
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            DO.LineTrip myLineTrip = ListLineTrip.Find(l => (l.LineId == lineTrip.LineId) && (l.StartAt == lineTrip.StartAt));
            if (myLineTrip != null)
            {
                ListLineTrip.Remove(myLineTrip);
               ListLineTrip.Add(lineTrip);
            }
            else
                throw new DO.BadLineTripIdException(lineTrip.LineId, (int)lineTrip.StartAt.TotalMilliseconds, "this line trip doesn't exists in the list of line trip");
            XMLTools.SaveListToXMLSerializer(ListLineTrip, lineTripPath);
        }
        public void UpdateLineTrip(int id, TimeSpan startAt, Action<DO.LineTrip> update)
        {
            List<LineTrip> ListLineTrip = XMLTools.LoadListFromXMLSerializer<LineTrip>(lineTripPath);
            var myLineTrip = ListLineTrip.FirstOrDefault(predicate => (predicate.LineId == id) && (predicate.StartAt == startAt));
            if (myLineTrip != null)
            {
                update(myLineTrip);
            }
            XMLTools.SaveListToXMLSerializer(ListLineTrip, lineTripPath);

        }
        #endregion
        #region Trip 

        public void AddTrip(DO.Trip trip)
        {
            if (DataSource.ListTrip.FirstOrDefault(t => t.Id == trip.Id) != null)
                throw new DO.BadTripIdException(trip.Id, "this trip already exists in the list of trips");
            DataSource.ListTrip.Add(trip.Clone());
        }

        public void DeleteTrip(int id)
        {
            DO.Trip myTrip = DataSource.ListTrip.Find(t => t.Id == id);
            if (myTrip != null)
            {
                DataSource.ListTrip.Remove(myTrip);
            }
            else
                throw new DO.BadTripIdException(id, "this trip doesn't exist in the list of trip");
        }
        public DO.Trip GetTrip(int id)
        {
            DO.Trip trip = DataSource.ListTrip.Find(t => t.Id == id);

            if (trip != null)
                return trip.Clone();
            else
                throw new DO.BadTripIdException(id, "this trip doesn't exist in the list of trip");
        }
        public IEnumerable<DO.Trip> GetAllTrip()
        {
            return from trip in DataSource.ListTrip
                   select trip.Clone();
        }

        public IEnumerable<DO.Trip> GetAllTripBy(Predicate<DO.Trip> predicate)
        {
            if (predicate != null)
            {
                return from trip in DataSource.ListTrip
                       where predicate(trip)
                       select trip.Clone();
            }
            return GetAllTrip();
        }
        public void UpdateTrip(DO.Trip trip)
        {
            DO.Trip myTrip = DataSource.ListTrip.Find(t => t.Id == trip.Id);
            if (myTrip != null)
            {
                DataSource.ListTrip.Remove(myTrip);
                DataSource.ListTrip.Add(trip.Clone());
            }
            else
                throw new DO.BadTripIdException(trip.Id, $"bad trip id: {trip.Id}");
        }

        public void UpdateTrip(int id, Action<DO.Trip> update)
        {
            var myTrip = DataSource.ListTrip.FirstOrDefault(predicate => predicate.Id == id);
            if (myTrip != null)
            {
                update(myTrip);
            }
        }

        #endregion
        #region User

        public void AddUser(DO.User user)
        {
            if (DataSource.ListUser.FirstOrDefault(u => u.UserName == user.UserName) != null)
                throw new DO.BadUserIdException(user.UserName, "this user already exists in the list of user");
            DataSource.ListUser.Add(user.Clone());
        }
        public void DeleteUser(string name)
        {
            DO.User myUser = DataSource.ListUser.Find(u => u.UserName == name);
            if (myUser != null)
            {
                DataSource.ListUser.Remove(myUser);
            }
            else
                throw new DO.BadUserIdException(name, "this user doesn't exist in the list of users");
        }
        public DO.User GetUser(string name)
        {
            DO.User user = DataSource.ListUser.Find(u => u.UserName == name);

            if (user != null)
                return user.Clone();
            else
                throw new DO.BadUserIdException(name, "this user doesn't exist in the list of users");
        }
        public IEnumerable<DO.User> GetAllUser()
        {
            return from user in DataSource.ListUser
                   select user.Clone();
        }
        public IEnumerable<DO.User> GetAllUserBy(Predicate<DO.User> predicate)
        {
            if (predicate != null)
            {
                return from user in DataSource.ListUser
                       where predicate(user)
                       select user.Clone();
            }
            else return GetAllUser();
        }
        public void UpdateUser(DO.User user)
        {
            DO.User myUser = DataSource.ListUser.Find(u => u.UserName == user.UserName);
            if (myUser != null)
            {
                DataSource.ListUser.Remove(myUser);
                DataSource.ListUser.Add(user.Clone());
            }
            else
                throw new DO.BadUserIdException(user.UserName, "this user doesn't exist in the list of users");

        }
        public void UpdateUser(string userName, Action<DO.User> update)
        {
            var myUser = DataSource.ListUser.FirstOrDefault(predicate => predicate.UserName == userName);
            if (myUser != null)
            {
                update(myUser);
            }
        }

        #endregion
    }

}

