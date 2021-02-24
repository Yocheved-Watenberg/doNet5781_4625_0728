using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DLAPI;
using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDAL    
    {
        #region singelton
        static readonly DLObject instance = new DLObject();
        static DLObject() { }// static ctor to ensure instance init is done just before first usage
        DLObject() { } // default => private
        public static DLObject Instance { get => instance; }// The public Instance property to use
        #endregion
        #region Bus
        public void AddBus(DO.Bus bus)
        {
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
            List<DO.AdjacentStations> myList = DataSource.ListAdjacentStations.FindAll(s => s.Station1 == adjacentStations.Station1);
            if (myList.FirstOrDefault(adj => adj.Station2 == adjacentStations.Station2) != null)
                throw new DO.BadAdjacentStationsIdException(adjacentStations.Station1, adjacentStations.Station2, "theses adjacent stations already exist in the list of adjacents stations");
            DataSource.ListAdjacentStations.Add(adjacentStations.Clone());
        }
        public void DeleteAdjacentStations(int station1, int station2)
        {
            DO.AdjacentStations adj = DataSource.ListAdjacentStations.Find(a => (a.Station1 == station1)&&(a.Station2 == station2));
            if (adj != null)
            {
                DataSource.ListAdjacentStations.Remove(adj);
            }
            else
            throw new DO.BadAdjacentStationsIdException(station1, station2, "theses adjacent stations doesn't exist in the list of adjacents stations");
        }
        public void DeleteAdjacentsStationsFrom(DO.AdjacentStations adj) 
        {
            DataSource.ListAdjacentStations.Remove(adj);
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStations()
        {
            return from adj in DataSource.ListAdjacentStations
                   select adj.Clone();
        }
        public DO.AdjacentStations GetAdjacentStations(int station1, int station2)
        {
            DO.AdjacentStations adj = DataSource.ListAdjacentStations.Find(a => (a.Station1 == station1) && (a.Station2 == station2));

            if (adj != null)
                return adj.Clone();
            else
                 throw new DO.BadAdjacentStationsIdException(station1, station2, "theses adjacent stations doesn't exist in the list of adjacents stations");
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate)
        {
            if (predicate != null)
            {
                return from adj in DataSource.ListAdjacentStations
                       where predicate(adj)
                       select adj.Clone();
            }
            return GetAllAdjacentStations();
        }
        public void UpdateAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            DO.AdjacentStations adj = DataSource.ListAdjacentStations.Find(a => (a.Station1 == adjacentStations.Station1)&&(a.Station2 == adjacentStations.Station2));
            if (adj != null)
            {
                DataSource.ListAdjacentStations.Remove(adj);
                DataSource.ListAdjacentStations.Add(adjacentStations.Clone());
            }
            else
                throw new DO.BadAdjacentStationsIdException(adjacentStations.Station1, adjacentStations.Station2, "these adjacent stations doesn't exist in the list of adjacents stations");
        }
        public void UpdateAdjacentStations(int Station1, int Station2, Action<DO.AdjacentStations> update)
        {
            var adj = DataSource.ListAdjacentStations.FirstOrDefault(predicate => (predicate.Station1 == Station1) && (predicate.Station2 == Station2));
            if (adj != null)
            {
                update(adj);
            }
        }
        public void UpdateAdjacentStations(int StationToChange, Action<DO.AdjacentStations> update)
        {
            var adj = DataSource.ListAdjacentStations.FirstOrDefault(predicate => (predicate.Station1 == StationToChange) || (predicate.Station2 == StationToChange));
            if (adj != null)
            {
                update(adj);
            }
        }
        #endregion
        #region Line 
        public void AddLine(DO.Line line)
        {
            if (DataSource.ListLine.Exists(l =>(l.Code == line.Code) && (l.IsDeleted==false)))
                    throw new DO.BadLineIdException(line.Code, "this line already exists in the list of lines or this code has been used for a deleted line");
            DataSource.ListLine.Add(line.Clone());
        }
        public void DeleteLine(int code)
        {
            DO.Line myLine = DataSource.ListLine.Find(l => l.Code == code);
            if (myLine != null)
            {
                myLine.IsDeleted = true; 
              //  DataSource.ListLine.Remove(myLine);
            }
            else
                throw new DO.BadLineIdException(code, $"bad line code: {code}");
        }
        public DO.Line GetLine(int code)
        {
            DO.Line line = DataSource.ListLine.Find(l => (l.Code == code) && (l.IsDeleted == false));
            if (line != null)
                return line.Clone();
            else
                throw new DO.BadLineIdException(code, $"bad line code: {code}");   
        }

        public IEnumerable<DO.Line> GetAllLine()
        {
            return from line in DataSource.ListLine.FindAll(l => l.IsDeleted == false)
                   select line.Clone();
        }

        public IEnumerable<DO.Line> GetAllLineBy(Predicate<DO.Line> predicate)
        {
            if (predicate != null)
            {
                return from line in DataSource.ListLine.FindAll(l => l.IsDeleted == false)
                       where predicate(line)
                       select line.Clone();
            }
            return GetAllLine();
        }

        public void UpdateLine(DO.Line line)
        {
            DO.Line myLine = DataSource.ListLine.Find(l => l.Code == line.Code);
            if ((myLine != null) && (myLine.IsDeleted == false))
            {
                DataSource.ListLine.Remove(myLine);
                DataSource.ListLine.Add(line.Clone());
            }
            else
                throw new DO.BadLineIdException(line.Code, $"bad line code : {line.Code}");
        }

        public void UpdateLine(int code, Action<DO.Line> update)
        {
            var myLine = DataSource.ListLine.FirstOrDefault(predicate => predicate.Code == code);
            if ((myLine != null) && (myLine.IsDeleted == false))
            {
                update(myLine);
            }
        }
     
        #endregion
        #region LineStation 

        public void AddLineStation(DO.LineStation lineStation)
        {
            List<DO.LineStation> myList = DataSource.ListLineStation.FindAll(s => s.LineCode == lineStation.LineCode);
            if (myList.FirstOrDefault(l => l.StationCode == lineStation.StationCode) != null)
                throw new DO.BadLineStationIdException(lineStation.LineCode, lineStation.StationCode, "this line station already exists in the list of line station");
            DataSource.ListLineStation.Add(lineStation.Clone());
        }
        public void AddLineStationWithFields(int lineCode, int stationCode, int index)
        {
            LineStation myLineStation = new LineStation();
            myLineStation.LineCode = lineCode;
            myLineStation.StationCode = stationCode; 
            myLineStation.LineStationIndex = index;
            AddLineStation(myLineStation);
        }
        public void DeleteLineStation(int line, int station)
        {
            DO.LineStation myLineStation = DataSource.ListLineStation.Find(ls => (ls.LineCode == line)&&(ls.StationCode==station));
            if (myLineStation != null)
            {
                DataSource.ListLineStation.Remove(myLineStation);
            }
            else
                throw new DO.BadLineStationIdException(line, station, "this line station doesn't exist in the list of line station");
        }
        public IEnumerable<DO.LineStation> GetAllLineStation()
        {
            return from lineStation in DataSource.ListLineStation
                   select lineStation.Clone();
        }
        public DO.LineStation GetLineStation(int id, int station)
        {
            DO.LineStation lineStation = DataSource.ListLineStation.Find(l => (l.LineCode == id) && (l.StationCode == station));

            if (lineStation != null)
                return lineStation.Clone();
            else
                throw new DO.BadLineStationIdException(id, station, "this line station doesn't exist in the list of line station");
        }
        public IEnumerable<DO.LineStation> GetAllLineStationBy(Predicate<DO.LineStation> predicate)
        {
            if (predicate != null)
            {
                return from lineStation in DataSource.ListLineStation
                       where predicate(lineStation)
                       select lineStation.Clone();
            }
           else return GetAllLineStation();
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            DO.LineStation myLineStation = DataSource.ListLineStation.Find(l => (l.LineCode == lineStation.LineCode) && (l.StationCode==lineStation.StationCode));
            if (myLineStation != null)
            {
                DataSource.ListLineStation.Remove(myLineStation);
                DataSource.ListLineStation.Add(lineStation.Clone());
            }
            else
                throw new DO.BadLineStationIdException(lineStation.LineCode, lineStation.StationCode, "this line station doesn't exist in the list of line station");
        }
    

    public void UpdateLineStation(int LineId, int station, Action<DO.LineStation> update)
    {
        var myLineStation = DataSource.ListLineStation.FirstOrDefault(predicate => (predicate.LineCode == LineId) && (predicate.StationCode == station));
        if (myLineStation != null)
        {
            update(myLineStation);
        }
    }

        #endregion
        #region LineTrip 

        public void AddLineTrip(DO.LineTrip lineTrip)
        {
            List<DO.LineTrip> myList = DataSource.ListLineTrip.FindAll(l => l.LineId == lineTrip.LineId);
            if (myList.FirstOrDefault(l => l.StartAt == lineTrip.StartAt) != null)
                throw new DO.BadLineTripIdException(lineTrip.LineId, (int)lineTrip.StartAt.TotalMilliseconds, "this line trip already exists in the list of line trip");
            DataSource.ListLineTrip.Add(lineTrip.Clone());
        }
        public void DeleteLineTrip(int id, TimeSpan startAt)
        {
            DO.LineTrip myLineTrip = DataSource.ListLineTrip.Find(l => (l.LineId == id)&&(l.StartAt==startAt));
            if (myLineTrip != null)
            {
                DataSource.ListLineTrip.Remove(myLineTrip);
            }
            else
                throw new DO.BadLineTripIdException(id, (int)startAt.TotalMilliseconds, "this line trip doesn't exists in the list of line trip");
        }

        public IEnumerable<DO.LineTrip> GetAllLineTrip()
        {
            return from lineTrip in DataSource.ListLineTrip
                   select lineTrip.Clone();
        }

        public DO.LineTrip GetLineTrip(int id, TimeSpan now)
        {
             DO.LineTrip trip = DataSource.ListLineTrip.Find(s => (s.LineId == id));

                if (trip != null  && trip.StartAt <= now && trip.FinishedAt >= now)
                {
                    return trip.Clone();
                }
                else
                {
                throw new DO.BadLineTripIdException(id, (int)now.TotalMilliseconds, "this line trip doesn't exists in the list of line trip");
                }
        }
        public IEnumerable<DO.LineTrip> GetAllLineTripBy(Predicate<DO.LineTrip> predicate)
        {
            if (predicate != null)
            {
                return from lineTrip in DataSource.ListLineTrip
                       where predicate(lineTrip)
                       select lineTrip.Clone();
            }
            return GetAllLineTrip();
        }

        public void UpdateLineTrip(DO.LineTrip lineTrip)
        {
            DO.LineTrip myLineTrip = DataSource.ListLineTrip.Find(l => (l.LineId == lineTrip.LineId)&&(l.StartAt==lineTrip.StartAt));
            if (myLineTrip != null)
            {
                DataSource.ListLineTrip.Remove(myLineTrip);
                DataSource.ListLineTrip.Add(lineTrip.Clone());
            }
            else
                throw new DO.BadLineTripIdException(lineTrip.LineId, (int)lineTrip.StartAt.TotalMilliseconds, "this line trip doesn't exists in the list of line trip");
        }
        public void UpdateLineTrip(int id, TimeSpan startAt, Action<DO.LineTrip> update)
        {
            var myLineTrip = DataSource.ListLineTrip.FirstOrDefault(predicate => (predicate.LineId == id)&&(predicate.StartAt==startAt));
            if (myLineTrip != null)
            {
                update(myLineTrip);
            }
        }
        #endregion
        #region Station

        public void AddStation(DO.Station station)
        {
            if (DataSource.ListStation.FirstOrDefault(s => s.Code == station.Code) != null)
                throw new DO.BadStationIdException(station.Code, "this station already exists in the list of stations or this code has been used for a deleted station");
            DataSource.ListStation.Add(station.Clone());
        }
        public void DeleteStation(int code)
        {
            DO.Station myStation = DataSource.ListStation.Find(s => s.Code == code);
            if ((myStation != null)&&(myStation.IsDeleted==false))
            {
                // DataSource.ListStation.Remove(myStation);
                myStation.IsDeleted = true;
            }
            else
                throw new DO.BadStationIdException(code, "this station doesn't exist in the list of station");
        }

        public DO.Station GetStation(int code)
        {
            DO.Station station = DataSource.ListStation.Find(s => (s.Code == code)&&(s.IsDeleted==false));

            if (station != null)
                return station.Clone();
            else
                throw new DO.BadStationIdException(code, "this station doesn't exist in the list of station");
        }

        public IEnumerable<DO.Station> GetAllStation()
        {
            return from station in DataSource.ListStation.FindAll(s=>s.IsDeleted==false)
                   select station.Clone();
        }

        public IEnumerable<DO.Station> GetAllStationBy(Predicate<DO.Station> predicate)
        {
            if (predicate != null)
            {
                return from station in DataSource.ListStation.FindAll(s => s.IsDeleted == false)
                       where predicate(station)
                       select station.Clone();
            }
            return GetAllStation();
        }

        public void UpdateStation(DO.Station station)
        {
            DO.Station myStation = DataSource.ListStation.Find(s => s.Code == station.Code);
            if ((myStation != null)&&(myStation.IsDeleted==false))
            {
                DataSource.ListStation.Remove(myStation);
                DataSource.ListStation.Add(station.Clone());
            }
            else
                throw new DO.BadStationIdException(station.Code, $"bad station code : {station.Code}");
        }
        public void UpdateStation(int code, Action<DO.Station> update)
        {
            var myStation = DataSource.ListStation.FirstOrDefault(predicate => predicate.Code == code);
            if ((myStation != null) && (myStation.IsDeleted == false))
            {
                update(myStation);
            }
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
            DO.Trip myTrip = DataSource.ListTrip.Find(t => t.Id==id);
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
            DO.Trip myTrip = DataSource.ListTrip.Find(t => t.Id== trip.Id);
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


