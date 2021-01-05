using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//chacune des fctions ouvre le kovets, lit qq chose et est mahzir cette chose
//faire attention a s occuper des harigots
using DLAPI;
//using DO;
using DS;

namespace DL
{
    sealed class DLObject : IDAL    //internal //af ehad yahol larechet
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
            throw new NotImplementedException();
        }
        public IEnumerable<DO.Bus> GetAllBus()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.Bus> GetAllBusBy(Predicate<DO.Bus> predicate)
        {
            throw new NotImplementedException();
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
    public IEnumerable<DO.BusOnTrip> GetBusOnTrip()
        {
            throw new NotImplementedException();
        }
        public DO.BusOnTrip GetBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.BusOnTrip> GetAllBusOnTripBy(Predicate<DO.BusOnTrip> predicate)
        {
            throw new NotImplementedException();
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
        public IEnumerable<DO.AdjacentStations> GetAdjacentStations()
        {
            throw new NotImplementedException();
        }
        public DO.AdjacentStations GetAdjacentStations(int Station1, int Station2)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.AdjacentStations> GetAllAdjacentStationsBy(Predicate<DO.AdjacentStations> predicate)
        {
            throw new NotImplementedException();
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
                throw new DO.BadAdjacentStationsIdException(adjacentStations.Station1, adjacentStations.Station2, "theses adjacent stations doesn't exist in the list of adjacents stations");
        }
        public void UpdateAdjacentStations(int Station1, int Station2, Action<DO.AdjacentStations> update)
        {
            var adj = DataSource.ListAdjacentStations.FirstOrDefault(predicate => (predicate.Station1 == Station1) && (predicate.Station2 == Station2));
            if (adj != null)
            {
                update(adj);
            }
        }
        #endregion
        #region Line 
        public void AddLine(DO.Line line)
        {
            if (DataSource.ListLine.FirstOrDefault(l => l.Id == line.Id) != null)
                throw new DO.BadLineIdException(line.Id, "this line already exists in the list of lines");
            DataSource.ListLine.Add(line.Clone());
        }
        public void DeleteLine(int id)
        {
            DO.Line myLine = DataSource.ListLine.Find(l => l.Id == id);
            if (myLine != null)
            {
                DataSource.ListLine.Remove(myLine);
            }
            else
                throw new DO.BadLineIdException(id, $"bad line id: {id}");
        }
        public DO.Line GetLine(int Id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<DO.Line> GetAllLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Line> GetAllLineBy(Predicate<DO.Line> predicate)
        {
            throw new NotImplementedException();
        }


        public void UpdateLine(DO.Line line)
        {
            DO.Line myLine = DataSource.ListLine.Find(l => l.Id == line.Id);
            if (myLine != null)
            {
                DataSource.ListLine.Remove(myLine);
                DataSource.ListLine.Add(line.Clone());
            }
            else
                throw new DO.BadLineIdException(line.Id, $"bad line id : {line.Id}");
        }

        public void UpdateLine(int id, Action<DO.Line> update)
        {
            var myLine = DataSource.ListLine.FirstOrDefault(predicate => predicate.Id == id);
            if (myLine != null)
            {
                update(myLine);
            }
        }
        #endregion
        #region LineStation 

        public void AddLineStation(DO.LineStation lineStation)
        {
            List<DO.LineStation> myList = DataSource.ListLineStation.FindAll(s => s.LineId == lineStation.LineId);
            if (myList.FirstOrDefault(l => l.Station == lineStation.Station) != null)
                throw new DO.BadLineStationIdException(lineStation.LineId, lineStation.Station, "this line station already exists in the list of line station");
            DataSource.ListLineStation.Add(lineStation.Clone());
        }
        public void DeleteLineStation(int id, int station)
        {
            DO.LineStation myLineStation = DataSource.ListLineStation.Find(l => (l.LineId == id)&&(l.Station==station));
            if (myLineStation != null)
            {
                DataSource.ListLineStation.Remove(myLineStation);
            }
            else
                throw new DO.BadLineStationIdException(id, station, "this line station doesn't exist in the list of line station");
        }
        public IEnumerable<DO.LineStation> GetLineStation()
        {
            throw new NotImplementedException();
        }
        public DO.LineStation GetLineStation(int LineId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.LineStation> GetAllLineStationBy(Predicate<DO.LineStation> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateLineStation(DO.LineStation lineStation)
        {
            DO.LineStation myLineStation = DataSource.ListLineStation.Find(l => (l.LineId == lineStation.LineId) && (l.Station==lineStation.Station));
            if (myLineStation != null)
            {
                DataSource.ListLineStation.Remove(myLineStation);
                DataSource.ListLineStation.Add(lineStation.Clone());
            }
            else
                throw new DO.BadLineStationIdException(lineStation.LineId, lineStation.Station, "this line station doesn't exist in the list of line station");
        }
    

    public void UpdateLineStation(int LineId, int station, Action<DO.LineStation> update)
    {
        var myLineStation = DataSource.ListLineStation.FirstOrDefault(predicate => (predicate.LineId == LineId) && (predicate.Station == station));
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

        public IEnumerable<DO.LineTrip> GetLineTrip()
        {
            throw new NotImplementedException();
        }

        public DO.LineTrip GetLineTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.LineTrip> GetAllLineTripBy(Predicate<DO.LineTrip> predicate)
        {
            throw new NotImplementedException();
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
                throw new DO.BadStationIdException(station.Code, "this station already exists in the list of stations");
            DataSource.ListStation.Add(station.Clone());
        }
        public void DeleteStation(int code)
        {
            DO.Station myStation = DataSource.ListStation.Find(s => s.Code == code);
            if (myStation != null)
            {
                DataSource.ListStation.Remove(myStation);
            }
            else
                throw new DO.BadStationIdException(code, "this station doesn't exist in the list of station");
        }

        public DO.Station GetStation(int code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Station> GetAllStation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Station> GetAllStationBy(Predicate<DO.Station> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(DO.Station station)
        {
            DO.Station myStation = DataSource.ListStation.Find(s => s.Code == station.Code);
            if (myStation != null)
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
            if (myStation != null)
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
        public DO.Trip GetTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.Trip> GetAllTrip()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<DO.Trip> GetAllTripBy(Predicate<DO.Trip> predicate)
        {
            throw new NotImplementedException();
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
        public void DeleteUser(string user)
        {
            DO.User myUser = DataSource.ListUser.Find(u => u.UserName == user);
            if (myUser != null)
            {
                DataSource.ListUser.Remove(myUser);
            }
            else
                throw new DO.BadUserIdException(user, "this user doesn't exist in the list of users");
        }
        public DO.User GetUser(string userName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.User> GetAllUser()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<DO.User> GetAllUserBy(Predicate<DO.User> predicate)
        {
            throw new NotImplementedException();
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
