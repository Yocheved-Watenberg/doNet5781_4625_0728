using DO;
using System;
using System.Collections.Generic;

namespace DLAPI
   
{
    public interface IDAL
    {
        //For each class, the interface allows the functions below:
        // Create - add new instance
        // Request - ask for an instance or for a collection(or all the list or all the instance which are under a condition)
        // Update - update properties of an instance
        // Delete - delete an instance
        #region Bus
        void AddBus(Bus bus);
        Bus GetBus(int licenseNum);
        IEnumerable <Bus> GetAllBus();
        IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate);
        void UpdateBus(Bus bus);
        void UpdateBus(int licenseNum, Action <Bus> update);
        void DeleteBus(int licenseNum);
        #endregion
        #region BusOnTrip
        void AddBusOnTrip(BusOnTrip busOnTrip);
        BusOnTrip GetBusOnTrip(int Id);
        IEnumerable<BusOnTrip> GetAllBusOnTrip();
        IEnumerable<BusOnTrip> GetAllBusOnTripBy(Predicate<BusOnTrip> predicate);
        void UpdateBusOnTrip(BusOnTrip busOnTrip);
        void UpdateBusOnTrip(int Id, Action<BusOnTrip> update);
        void DeleteBusOnTrip(int Id);
        #endregion
        #region Station
        void AddStation(Station station);
        Station GetStation(int code);
        IEnumerable<Station> GetAllStation();
        IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate);
        void UpdateStation(Station station);
        void UpdateStation(int code, Action<Station> update);
        void DeleteStation(int code);
        #endregion
        #region Line
        void AddLine(Line line);
        Line GetLine(int code);
        IEnumerable<Line> GetAllLine();
        IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate);
        void UpdateLine(Line line);
        void UpdateLine(int Id, Action<Line> update);
        void DeleteLine(int code);
        #endregion
        #region LineTrip
        void AddLineTrip(LineTrip lineTrip);
        LineTrip GetLineTrip(int id, TimeSpan startAt);
        IEnumerable<LineTrip> GetAllLineTrip();
        IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate);
        void UpdateLineTrip(LineTrip lineTrip);
        void UpdateLineTrip(int id, TimeSpan startAt, Action<LineTrip> update);
        void DeleteLineTrip(int id, TimeSpan startAt);

        #endregion
        #region LineStation
        void AddLineStation(LineStation lineStation);
        void AddLineStationWithFields(int lineCode, int stationCode, int index);
        LineStation GetLineStation(int line, int station);
        IEnumerable<LineStation> GetAllLineStation();
        IEnumerable<LineStation> GetAllLineStationBy(Predicate<LineStation> predicate);
        void UpdateLineStation(LineStation lineStation);
        void UpdateLineStation(int LineId, int station, Action<DO.LineStation> update);
        void DeleteLineStation(int id, int station);
        #endregion
        #region Trip
        void AddTrip(Trip trip);
        Trip GetTrip(int id);
        IEnumerable<Trip> GetAllTrip();
        IEnumerable<Trip> GetAllTripBy(Predicate<Trip> predicate);
        void UpdateTrip(Trip trip);
        void UpdateTrip(int id, Action<Trip> update);
        void DeleteTrip(int id);
        #endregion
        #region User
        void AddUser(User user);
        User GetUser(string userName);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllUserBy(Predicate<User> predicate);
        void UpdateUser(User user);
        void UpdateUser(string userName, Action<User> update);
        void DeleteUser(string userName);
        #endregion
        #region AdjacentStations
        void AddAdjacentStations(AdjacentStations adjacentStations);
        AdjacentStations GetAdjacentStations(int Station1, int Station2);
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        void UpdateAdjacentStations(AdjacentStations adjacentStations);
        void UpdateAdjacentStations(int Station1, int Station2, Action<AdjacentStations> update);
        void UpdateAdjacentStations(int StationToChange, Action<AdjacentStations> update);
        void DeleteAdjacentStations(int Station1, int Station2);
        void DeleteAdjacentsStationsFrom(DO.AdjacentStations adj);
        #endregion
    }
}
