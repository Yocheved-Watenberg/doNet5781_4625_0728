using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BL.BO;


namespace BLAPI
{
    public interface IBL
    {
        #region Line
        void AddLine(int myCode, BL.BO.Enum.Areas myArea, IEnumerable<LineStation> myListOfStations);              //allows only after the user entered two stations
        void DeleteLine(int code);
        void AddStationToLine(LineStation lineStation, LineStation previous);
        void DeleteStationOfLine(int stationCode, int lineCode);
        Line GetLine(int myCode);
        IEnumerable<Line> GetAllLine();
        IEnumerable<Line> GetAllLineBy(Predicate<DO.Line> predicate);
        IEnumerable<LineStation> GetAllLineStationsInLine(Line line);
        IEnumerable<Station> GetAllStationInLine(Line l);
        IEnumerable<Station> GetAllStationsInLines(IEnumerable<Line> lines);
        BL.BO.Line LineDoBoAdapter(DO.Line lineDO);
        #endregion
        #region Station
        void AddStation(Station station);
        void DeleteStation(int code);
        Station GetStation(int code);
        IEnumerable<Station> GetAllStation();
        IEnumerable<Station> GetStationByArea(BL.BO.Enum.Areas myArea);
        IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate);
        IEnumerable<BL.BO.Line> GetAllLineInStation(Station s);
        void UpdateStation(Station station);
        Station StationDoBoAdapter(DO.Station stationDO);
        Station StationLineStationAdapter(LineStation l);
        #endregion
        #region Line Station
        void AddLineStation(int lineCode, int stationCode, int index);
        LineStation GetLineStation(int lineCode, int stationCode);
        BL.BO.LineStation LineStationDoBoAdapter(DO.LineStation lineDO);
        #endregion
        #region Adjacent Stations
        void AddAdjacentStations(AdjacentStations adjacentStations);
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        AdjacentStations adjacentStationsDoBoAdapter(DO.AdjacentStations adjDO);
        double GetDistanceTo(Station s1, Station s2);
        #endregion
        #region LineTrip
        void AddLineTrip(LineTrip lineTrip);
        void DeleteLineTrip(LineTrip lineTrip);
        void UpdateLineTrip(LineTrip lineTrip);
        LineTrip GetLineTrip(int id, TimeSpan startAt);
        IEnumerable<LineTrip> GetAllLineTrip();
        IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate);
        LineTrip LineTripDoBoAdapter(DO.LineTrip DoLineTrip);
        #endregion
        #region other functions
        IEnumerable<LineTiming> NextBusesInAStation(BL.BO.Station station, TimeSpan hour);
        IEnumerable<LineTiming> NextBusesOfOneLineInAStation(int lineCode, TimeSpan hour, int stationKey);
        TimeSpan TravelTime(Line line, int stationKey); //Calcul of time between first station of line and our station
        #endregion
    }
}

