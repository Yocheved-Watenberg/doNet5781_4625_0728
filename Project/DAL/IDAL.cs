﻿using DO;
using System;
using System.Collections.Generic;



namespace DLAPI
   
{
    public interface IDAL // eze peoulot aleha lessapek li (on s en fout cmt tu fais) pr que BL marche
    {
        //For each class, the interface allows the functions below:
        // Create - add new instance
        // Request - ask for an instance or for a collection(or all the list or all the instance which are under a condition)
        // Update - update properties of an instance
        // Delete - delete an instance
        #region Bus
        void AddBus(Bus bus);
        IEnumerable <Bus> GetAllBus();
        IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate);
        Bus GetBus(int licenseNum);
        void UpdateBus(Bus bus);
        void UpdateBus(int licenseNum, Action <Bus> update);
        void DeleteBus(int licenseNum);
        #endregion
        #region Station
        void AddStation(Station station);
        IEnumerable<Station> GetAllStation();
        IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate);
        Station GetStation(int code);
        void UpdateStation(Station station);
        void UpdateStation(int code, Action<Station> update);
        void DeleteStation(int code);
        #endregion
        #region Line
        void AddLine(Line line);
        IEnumerable<Line> GetAllLine();
        IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate);
        Line GetLine(int Id);
        void UpdateLine(Line line);
        void UpdateLine(int Id, Action<Line> update);
        void DeleteLine(int Id);
        #endregion
        #region Trip
        void AddTrip(Trip trip);
        IEnumerable<Trip> GetAllTrip();
        IEnumerable<Trip> GetAllTripBy(Predicate<Trip> predicate);
        Trip GetTrip(int Id);
        void UpdateTrip(Trip trip);
        void UpdateTrip(int Id, Action<Trip> update);
        void DeleteTrip(int Id);
        #endregion
        #region User
        void AddUser(User user);
        IEnumerable<User> GetAllUser();
        IEnumerable<User> GetAllUserBy(Predicate<User> predicate);
        User GetUser(string userName);
        void UpdateUser(User user);
        void UpdateUser(string userName, Action<User> update);
        void DeleteUser(string userName);
        #endregion
        #region BusOnTrip
        void AddBusOnTrip(BusOnTrip busOnTrip);
        IEnumerable<BusOnTrip> GetBusOnTrip();
        IEnumerable<BusOnTrip> GetAllBusOnTripBy(Predicate<BusOnTrip> predicate);
        BusOnTrip GetBusOnTrip(int Id);
        void UpdateBusOnTrip(BusOnTrip busOnTrip);
        void UpdateBusOnTrip(int Id, Action<BusOnTrip> update);
        void DeleteBusOnTrip(int Id);
        #endregion
        #region LineTrip
        void AddLineTrip(LineTrip lineTrip);
        IEnumerable<LineTrip> GetLineTrip();
        IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate);
        LineTrip GetLineTrip(int Id);
        void UpdateLineTrip(LineTrip lineTrip);
        void UpdateLineTrip(int Id, Action<LineTrip> update);
        void DeleteLineTrip(int Id);
        #endregion
        #region LineStation
        void AddLineStation(LineStation lineStation);
        IEnumerable<LineStation> GetLineStation();
        IEnumerable<LineStation> GetAllLineStationBy(Predicate<LineStation> predicate);
        LineStation GetLineStation(int LineId);
        void UpdateLineStation(LineStation lineStation);
        void UpdateLineStation(int LineId, Action<LineStation> update);
        void DeleteLineStation(int LineId);
        #endregion
        //pas sure, est ce quon doit fr une liste de adjacents stations?
        #region AdjacentStations
        void AddAdjacentStations(AdjacentStations adjacentStations);
        IEnumerable<AdjacentStations> GetAdjacentStations();
        IEnumerable<AdjacentStations> GetAllAdjacentStationsBy(Predicate<AdjacentStations> predicate);
        AdjacentStations GetAdjacentStations(int Station1,int Station2);
        void UpdateAdjacentStations(AdjacentStations adjacentStations);
        void UpdateAdjacentStations(int Station1, int Station2, Action<AdjacentStations> update);
        void DeleteAdjacentStations(int Station1, int Station2);
        #endregion

        
    }
}
