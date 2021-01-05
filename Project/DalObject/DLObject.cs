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
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public void UpdateBus(int licenseNum, Action<DO.Bus> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region BusOnTrip
        public void AddBusOnTrip(DO.BusOnTrip busOnTrip)
        {
            if (DataSource.ListBusOnTrip.FirstOrDefault(b => b.LicenseNum == busOnTrip.LicenseNum) != null)
                throw new DO.BadBusOnTripIdException(busOnTrip.LicenseNum, "this busOnTrip already exists in the list of busOnTrip");
            DataSource.ListBusOnTrip.Add(busOnTrip.Clone());
        }
        public void DeleteBusOnTrip(int Id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public void UpdateBusOnTrip(int Id, Action<DO.BusOnTrip> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region AdjacentStations 
        public void AddAdjacentStations(DO.AdjacentStations adjacentStations)
        {
            if ((DataSource.ListAdjacentStations.FirstOrDefault(s => s.Station1 == adjacentStations.Station1) != null)&&(DataSource.ListAdjacentStations.FirstOrDefault(s => s.Station2 == adjacentStations.Station2) != null))
                throw new DO.BadAdjacentStationsIdException(adjacentStations.Station1, adjacentStations.Station2, "theses adjacent stations already exists in the list of adjacents stations");
            DataSource.ListAdjacentStations.Add(adjacentStations.Clone());
        }
        public void DeleteAdjacentStations(int Station1, int Station2)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public void UpdateAdjacentStations(int Station1, int Station2, Action<DO.AdjacentStations> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Line 
        public void AddLine(DO.Line line)
        {
            if (DataSource.ListLine.FirstOrDefault(l => l.Id == line.Id) != null)
                throw new DO.BadLineIdException(line.Id, "this line already exists in the list of lines");
            DataSource.ListLine.Add(line.Clone());
        }
        public void DeleteLine(int Id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateLine(int Id, Action<DO.Line> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineStation 

        public void AddLineStation(DO.LineStation lineStation)
        {
            if ((DataSource.ListLineStation.FirstOrDefault(l => l.LineId == lineStation.LineId) != null)&&(DataSource.ListLineStation.FirstOrDefault(l => l.Station == lineStation.Station) != null))
                throw new DO.BadLineStationIdException(lineStation.LineId, lineStation.Station, "this line station already exists in the list of line station");
            DataSource.ListLineStation.Add(lineStation.Clone());
        }


        public void DeleteLineStation(int LineId)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int LineId, Action<DO.LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineTrip 

        public void AddLineTrip(DO.LineTrip lineTrip)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineTrip(int Id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateLineTrip(int Id, Action<DO.LineTrip> update)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Station

        public void AddStation(DO.Station station)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateStation(int code, Action<DO.Station> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Trip 

        public void AddTrip(DO.Trip trip)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrip(int Id)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void UpdateTrip(int Id, Action<DO.Trip> update)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region User

        public void AddUser(DO.User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }
        public void UpdateUser(string userName, Action<DO.User> update)
        {
            throw new NotImplementedException();
        }
        #endregion
    }  
 }

