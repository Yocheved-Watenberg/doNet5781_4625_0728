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
       BL.BO.Line LineDoBoAdapter(DO.Line lineDO);
        BL.BO.LineStation LineStationDoBoAdapter(DO.LineStation lineDO);
        void AddLine(int myCode, BL.BO.Enum.Areas myArea, IEnumerable<LineStation> myListOfStations);              //allows only after the user entered two stations
       void DeleteLine(int code);
       void AddStationToLine(LineStation lineStation, LineStation previous);
       void DeleteStationOfLine(int stationId, int lineId);
       Line GetLine(int myCode, Station FirstStation, Station LastStation);
        Line GetLine(int myCode);
        IEnumerable<Line> GetAllLine();
       IEnumerable<LineStation> GetAllLineStationsInLine(Line line);
        IEnumerable<Station> GetStationByArea(BL.BO.Enum.Areas myArea);
        IEnumerable<Station> GetAllStationInLine(Line l);

        #endregion

        #region Station
        Station StationDoBoAdapter(DO.Station stationDO);
       void AddStation(Station station);       
       void DeleteStation(int code);
       IEnumerable<Station> GetAllStation();
       IEnumerable<BL.BO.Line> GetAllLineInStation(Station s);
       IEnumerable<AdjacentStations> GetAllAdjacentStations();
        BL.BO.AdjacentStations adjacentStationsDoBoAdapter(DO.AdjacentStations adjDO);
       void UpdateStation(Station station);
       Station GetStation(int code);
        IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate);

        #endregion
        #region LineTrip
        //Station StationDoBoAdapter(DO.Station stationDO); peut etre a fr pr line trip
        void AddLineTrip(LineTrip lineTrip);
        void DeleteLineTrip(int code);
        IEnumerable<LineTrip> GetAllLineTrip();
        void UpdateLineTrip(Station station);
        Station GetLineTrip(int code);
        IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate);

        #endregion

    }
}

