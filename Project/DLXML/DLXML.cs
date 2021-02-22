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
            string tripPath= @"tripPathXml.xml"; //XMLSerializer
            string busPath = @"BusPathXml.xml"; //XMLSerializer
            string busOnTripPath = @"BusOnTripPathXml.xml"; //XMLSerializer
           string userPath = @"UserPathXml.xml"; //XMLSerializer




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
        public IEnumerable<DO.Line> GetAllLine()
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
        public IEnumerable<DO.Line> GetAllLineBy(Predicate<DO.Line> predicate)
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
        public void UpdateLine(int code, Action<DO.Line> update)
        //{   XElement LinesRootElem = XMLTools.LoadListFromXMLElement(linePath);

        //    //XElement l1 = (from l in LinesRootElem.Elements()

        //    //               select predicate => predicate.Code == code).FirstOrDefault();


        //    var myLine = LinesRootElem.FirstOrDefault(predicate => predicate.Code == code);
        //    if ((myLine != null) && (myLine.IsDeleted == false))
        //    {
        //        update(myLine);
        //    }
        {
            throw new NotImplementedException();
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
            //  ListStation.Remove(myStation);
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
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            if ( ListBus.FirstOrDefault(b => b.LicenseNum == bus.LicenseNum) != null)
                throw new DO.BadBusIdException(bus.LicenseNum, "this bus already exists in the list of bus");
             ListBus.Add(bus);
            XMLTools.SaveListToXMLSerializer(ListBus, busPath);
        }
        public void DeleteBus(int licenseNum)
        {
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            DO.Bus myBus =  ListBus.Find(b => b.LicenseNum == licenseNum);
            if (myBus != null)
            {
                 ListBus.Remove(myBus);
            }
            else
                throw new DO.BadBusIdException(licenseNum, $"bad bus id: {licenseNum}");
            XMLTools.SaveListToXMLSerializer(ListBus, busPath);


        }
        public DO.Bus GetBus(int licenseNum)
        {
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            DO.Bus bus =  ListBus.Find(b => b.LicenseNum == licenseNum);

            if (bus != null)
                return bus ;
            else
                throw new DO.BadBusIdException(licenseNum, $"bad bus license num : {licenseNum}");
        }
        public IEnumerable<DO.Bus> GetAllBus()
        {
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            return from bus in  ListBus
                   select bus ;
        }
        public IEnumerable<DO.Bus> GetAllBusBy(Predicate<DO.Bus> predicate)
        {
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            if (predicate != null)
            {
                return from bus in  ListBus
                       where predicate(bus)
                       select bus ;
            }
            return GetAllBus();
        }
        public void UpdateBus(DO.Bus bus)
        {
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            DO.Bus myBus =  ListBus.Find(b => b.LicenseNum == bus.LicenseNum);
            if (myBus != null)
            {
                 ListBus.Remove(myBus);
                 ListBus.Add(bus );
            }
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus license num: {bus.LicenseNum}");
            XMLTools.SaveListToXMLSerializer(ListBus, busPath);
        }
        public void UpdateBus(int licenseNum, Action<DO.Bus> update)
        {
            List<Bus> ListBus = XMLTools.LoadListFromXMLSerializer<Bus>(busPath);
            var myBus =  ListBus.FirstOrDefault(predicate => predicate.LicenseNum == licenseNum);
            if (myBus != null)
            {
                update(myBus);
            }
            XMLTools.SaveListToXMLSerializer(ListBus, busPath);
        }
        #endregion
        #region BusOnTrip
        public void AddBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            if ( ListBusOnTrip.FirstOrDefault(b => b.Id == busOnTrip.Id) != null)
                throw new DO.BadBusOnTripIdException(busOnTrip.Id, "this busOnTrip already exists in the list of busOnTrip");
             ListBusOnTrip.Add(busOnTrip );
            XMLTools.SaveListToXMLSerializer(ListBusOnTrip, busOnTripPath);
        }
        public void DeleteBusOnTrip(int Id)
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            DO.BusOnTrip myBusOnTrip =  ListBusOnTrip.Find(b => b.Id == Id);
            if (myBusOnTrip != null)
            {
                 ListBusOnTrip.Remove(myBusOnTrip);
            }
            else
                throw new DO.BadBusOnTripIdException(Id, $"bad busOnTrip id: {Id}");
            XMLTools.SaveListToXMLSerializer(ListBusOnTrip, busOnTripPath);
        }
        public IEnumerable<DO.BusOnTrip> GetAllBusOnTrip()
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            return from busOnTrip in  ListBusOnTrip
                   select busOnTrip ;
        }
        public DO.BusOnTrip GetBusOnTrip(int Id)
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            DO.BusOnTrip busOnTrip =  ListBusOnTrip.Find(b => b.Id == Id);

            if (busOnTrip != null)
                return busOnTrip ;
            else
                throw new DO.BadBusOnTripIdException(Id, $"bad busOnTrip id: {Id}");
        }
        public IEnumerable<DO.BusOnTrip> GetAllBusOnTripBy(Predicate<DO.BusOnTrip> predicate)
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            if (predicate != null)
            {
                return from busOnTrip in  ListBusOnTrip
                       where predicate(busOnTrip)
                       select busOnTrip ;
            }
            return GetAllBusOnTrip();
        }
        public void UpdateBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            DO.BusOnTrip myBusOnTrip =  ListBusOnTrip.Find(b => b.Id == busOnTrip.Id);
            if (myBusOnTrip != null)
            {
                 ListBusOnTrip.Remove(myBusOnTrip);
                 ListBusOnTrip.Add(busOnTrip );
            }
            else
                throw new DO.BadBusOnTripIdException(busOnTrip.Id, $"bad busOnTrip id: {busOnTrip.Id}");
            XMLTools.SaveListToXMLSerializer(ListBusOnTrip, busOnTripPath);
        }
        public void UpdateBusOnTrip(int Id, Action<DO.BusOnTrip> update)
        {
            List<BusOnTrip> ListBusOnTrip = XMLTools.LoadListFromXMLSerializer<BusOnTrip>(busOnTripPath);
            var myBusOnTrip =  ListBusOnTrip.FirstOrDefault(predicate => predicate.Id == Id);
            if (myBusOnTrip != null)
            {
                update(myBusOnTrip);
            }
            XMLTools.SaveListToXMLSerializer(ListBusOnTrip, busOnTripPath);
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
            List<Trip> ListTrip= XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);

            if (ListTrip.FirstOrDefault(t => t.Id == trip.Id) != null)
                throw new DO.BadTripIdException(trip.Id, "this trip already exists in the list of trips");
            ListTrip.Add(trip);
            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);

        }

        public void DeleteTrip(int id)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            DO.Trip myTrip = ListTrip.Find(t => t.Id == id);
            if (myTrip != null)
            {
                 ListTrip.Remove(myTrip);
            }
            else
                throw new DO.BadTripIdException(id, "this trip doesn't exist in the list of trip");
            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);
        }
        public DO.Trip GetTrip(int id)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            DO.Trip trip =  ListTrip.Find(t => t.Id == id);

            if (trip != null)
                return trip ;
            else
                throw new DO.BadTripIdException(id, "this trip doesn't exist in the list of trip");
        }
        public IEnumerable<DO.Trip> GetAllTrip()
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            return from trip in  ListTrip
                   select trip ;
        }

        public IEnumerable<DO.Trip> GetAllTripBy(Predicate<DO.Trip> predicate)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            if (predicate != null)
            {
                return from trip in  ListTrip
                       where predicate(trip)
                       select trip ;
            }
            return GetAllTrip();
        }
        public void UpdateTrip(DO.Trip trip)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            DO.Trip myTrip =  ListTrip.Find(t => t.Id == trip.Id);
            if (myTrip != null)
            {
                 ListTrip.Remove(myTrip);
                 ListTrip.Add(trip );
            }
            else
                throw new DO.BadTripIdException(trip.Id, $"bad trip id: {trip.Id}");
            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);
        }

        public void UpdateTrip(int id, Action<DO.Trip> update)
        {
            List<Trip> ListTrip = XMLTools.LoadListFromXMLSerializer<Trip>(tripPath);
            var myTrip =  ListTrip.FirstOrDefault(predicate => predicate.Id == id);
            if (myTrip != null)
            {
                update(myTrip);
            }
            XMLTools.SaveListToXMLSerializer(ListTrip, tripPath);
        }

        #endregion
        #region User

        public void AddUser(DO.User user)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            if ( ListUser.FirstOrDefault(u => u.UserName == user.UserName) != null)
                throw new DO.BadUserIdException(user.UserName, "this user already exists in the list of user");
             ListUser.Add(user );
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }
        public void DeleteUser(string name)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            DO.User myUser =  ListUser.Find(u => u.UserName == name);
            if (myUser != null)
            {
                 ListUser.Remove(myUser);
            }
            else
                throw new DO.BadUserIdException(name, "this user doesn't exist in the list of users");
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }
        public DO.User GetUser(string name)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            DO.User user =  ListUser.Find(u => u.UserName == name);

            if (user != null)
                return user ;
            else
                throw new DO.BadUserIdException(name, "this user doesn't exist in the list of users");
        }
        public IEnumerable<DO.User> GetAllUser()
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            return from user in  ListUser
                   select user ;
        }
        public IEnumerable<DO.User> GetAllUserBy(Predicate<DO.User> predicate)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            if (predicate != null)
            {
                return from user in  ListUser
                       where predicate(user)
                       select user ;
            }
            else return GetAllUser();
        }
        public void UpdateUser(DO.User user)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            DO.User myUser =  ListUser.Find(u => u.UserName == user.UserName);
            if (myUser != null)
            {
                 ListUser.Remove(myUser);
                 ListUser.Add(user );
            }
            else
                throw new DO.BadUserIdException(user.UserName, "this user doesn't exist in the list of users");
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);

        }
        public void UpdateUser(string userName, Action<DO.User> update)
        {
            List<User> ListUser = XMLTools.LoadListFromXMLSerializer<User>(userPath);
            var myUser =  ListUser.FirstOrDefault(predicate => predicate.UserName == userName);
            if (myUser != null)
            {
                update(myUser);
            }
            XMLTools.SaveListToXMLSerializer(ListUser, userPath);
        }

        #endregion
        #region LineStation 

        public void AddLineStation(DO.LineStation lineStation)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            List<DO.LineStation> myList =  ListLineStation.FindAll(s => s.LineCode == lineStation.LineCode);
            if (myList.FirstOrDefault(l => l.StationCode == lineStation.StationCode) != null)
                throw new DO.BadLineStationIdException(lineStation.LineCode, lineStation.StationCode, "this line station already exists in the list of line station");
             ListLineStation.Add(lineStation );
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);
        }
        public void DeleteLineStation(int line, int station)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            DO.LineStation myLineStation =  ListLineStation.Find(ls => (ls.LineCode == line) && (ls.StationCode == station));
            if (myLineStation != null)
            {
                 ListLineStation.Remove(myLineStation);
            }
            else
                throw new DO.BadLineStationIdException(line, station, "this line station doesn't exist in the list of line station");
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);
        }
        public IEnumerable<DO.LineStation> GetAllLineStation()
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            return from lineStation in  ListLineStation
                   select lineStation ;
        }
        public DO.LineStation GetLineStation(int id, int station)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            DO.LineStation lineStation =  ListLineStation.Find(l => (l.LineCode == id) && (l.StationCode == station));

            if (lineStation != null)
                return lineStation ;
            else
                throw new DO.BadLineStationIdException(id, station, "this line station doesn't exist in the list of line station");
        }
        public IEnumerable<DO.LineStation> GetAllLineStationBy(Predicate<DO.LineStation> predicate)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            if (predicate != null)
            {
                return from lineStation in  ListLineStation
                       where predicate(lineStation)
                       select lineStation ;
            }
            else return GetAllLineStation();
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            DO.LineStation myLineStation =  ListLineStation.Find(l => (l.LineCode == lineStation.LineCode) && (l.StationCode == lineStation.StationCode));
            if (myLineStation != null)
            {
                 ListLineStation.Remove(myLineStation);
                 ListLineStation.Add(lineStation );
            }
            else
                throw new DO.BadLineStationIdException(lineStation.LineCode, lineStation.StationCode, "this line station doesn't exist in the list of line station");
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);
        }


        public void UpdateLineStation(int LineId, int station, Action<DO.LineStation> update)
        {
            List<LineStation> ListLineStation = XMLTools.LoadListFromXMLSerializer<LineStation>(lineStationPath);
            var myLineStation =  ListLineStation.FirstOrDefault(predicate => (predicate.LineCode == LineId) && (predicate.StationCode == station));
            if (myLineStation != null)
            {
                update(myLineStation);
            }
            XMLTools.SaveListToXMLSerializer(ListLineStation, lineStationPath);
        }

        #endregion
    }

}

