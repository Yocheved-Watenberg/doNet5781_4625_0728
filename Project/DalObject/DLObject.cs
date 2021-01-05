using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//chacune des fctions ouvre le kovets, lit qq chose et est mahzir cette chose
//faire attention a s occuper des harigots
using DLAPI;
using DO;
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
            //DO.Person per = DataSource.ListPersons//oleh larechimot.Find(p => p.ID == id)//est mafil la fction find //avour kal evar p si le Id est egal a celui de person(celui qui a ete recu);
            //if (per != null)//
            //    DataSource.ListPerson.Add (per.Clone());//tamid maatikim netounim //copie ds ma list//CLONE=copy ctor
            //else
            //    throw new DO.BadPersonIdException(id, $"bad person id: {id}");//exceptions ds Do

            DO.Bus myBus = DataSource.ListBus.Find(someBus => someBus.LicenseNum == bus.LicenseNum);
            if (myBus != null)
                DataSource.ListBus.Add(myBus.Clone());
            else
                throw new DO.BadBusIdException(bus.LicenseNum, $"bad bus license number: {bus.LicenseNum}");//exceptions ds Do
        }

        public void DeleteBus(int licenseNum)
        {
            throw new NotImplementedException();
        }
        public Bus GetBus(int licenseNum)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Bus> GetAllBus()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(Bus bus)
        {
            throw new NotImplementedException();
        }
        public void UpdateBus(int licenseNum, Action<Bus> update)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region BusOnTrip


        public void AddBusOnTrip(BusOnTrip busOnTrip)
        {
            throw new NotImplementedException();
        }

        public void DeleteBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }

    
        public IEnumerable<BusOnTrip> GetBusOnTrip()
        {
            throw new NotImplementedException();
        }

        public BusOnTrip GetBusOnTrip(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BusOnTrip> GetAllBusOnTripBy(Predicate<BusOnTrip> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusOnTrip(BusOnTrip busOnTrip)
        {
            throw new NotImplementedException();
        }

        public void UpdateBusOnTrip(int Id, Action<BusOnTrip> update)
        {
            throw new NotImplementedException();
        }


        #endregion
        #region AdjacentStations 

        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();

        }
        public void DeleteAdjacentStations(int Station1, int Station2)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<AdjacentStations> GetAdjacentStations()
        {
            throw new NotImplementedException();
        }

        public AdjacentStations GetAdjacentStations(int Station1, int Station2)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdjacentStations(AdjacentStations adjacentStations)
        {
            throw new NotImplementedException();
        }

        public void UpdateAdjacentStations(int Station1, int Station2, Action<AdjacentStations> update)
        {
            throw new NotImplementedException();
        }




        #endregion
        #region Line 
        public void AddLine(Line line)
        {
            DO.Line myLine = DataSource.ListLine.Find(someLine => someLine.Id == line.Id);
            if (myLine != null)
                DataSource.ListLine.Add (myLine.Clone());
            else
                throw new DO.BadLineIdException(line.Id, $"bad line id: {line.Id}");//exceptions ds Do
        }
        public void DeleteLine(int Id)
        {
            throw new NotImplementedException();
        }

        public Line GetLine(int Id)
        {
            throw new NotImplementedException();
        }


        public IEnumerable<Line> GetAllLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }


        public void UpdateLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int Id, Action<Line> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineStation 

        public void AddLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }


        public void DeleteLineStation(int LineId)
        {
            throw new NotImplementedException();
        }



        public IEnumerable<LineStation> GetLineStation()
        {
            throw new NotImplementedException();
        }

        public LineStation GetLineStation(int LineId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<LineStation> GetAllLineStationBy(Predicate<LineStation> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateLineStation(LineStation lineStation)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineStation(int LineId, Action<LineStation> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region LineTrip 

        public void AddLineTrip(LineTrip lineTrip)
        {
            throw new NotImplementedException();
        }
        public void DeleteLineTrip(int Id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineTrip> GetLineTrip()
        {
            throw new NotImplementedException();
        }

        public LineTrip GetLineTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineTrip(LineTrip lineTrip)
        {
            throw new NotImplementedException();
        }

        public void UpdateLineTrip(int Id, Action<LineTrip> update)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region Station

        public void AddStation(Station station)
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }



        public Station GetStation(int code)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }
        #endregion
        #region Trip 

        public void AddTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public void DeleteTrip(int Id)
        {
            throw new NotImplementedException();
        }


        public Trip GetTrip(int Id)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Trip> GetAllTrip()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Trip> GetAllTripBy(Predicate<Trip> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateTrip(Trip trip)
        {
            throw new NotImplementedException();
        }

        public void UpdateTrip(int Id, Action<Trip> update)
        {
            throw new NotImplementedException();
        }

        #endregion
        #region User

        public void AddUser(User user)
        {
            throw new NotImplementedException();
        }
        public void DeleteUser(string userName)
        {
            throw new NotImplementedException();
        }
        public User GetUser(string userName)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAllUser()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<User> GetAllUserBy(Predicate<User> predicate)
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(User user)
        {
            throw new NotImplementedException();
        }
        public void UpdateUser(string userName, Action<User> update)
        {
            throw new NotImplementedException();
        }
        #endregion
    }  
 }

