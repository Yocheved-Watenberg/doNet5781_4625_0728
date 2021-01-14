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
       void AddLine(Line line);                  //allow only after the user entered two stations
       void DeleteLine(int id);
       void AddStationToLine(LineStation lineStation, LineStation previous);
       void DeleteStationOfLine(int stationId, int lineId);
       Line GetLine(int myCode, Station FirstStation, Station LastStation);
       IEnumerable<Line> GetAllLine();
       IEnumerable<LineStation> GetAllLineStationsInLine();


        // avi pourquoi ta mis toutes ces fonctions ?? 
        //IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate); 
        //void UpdateLine(Line line);
        //void UpdateLine(int Id, Action<Line> update);

        #endregion
       #region Station
        BL.BO.Station StationDoBoAdapter(DO.Station stationDO);
        void AddStation(Station station);       
        void DeleteStation(int code);
        IEnumerable<Station> GetAllStation();
        IEnumerable<BL.BO.Line> GetAllLineInStation();
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        void UpdateStation(Station station);


        // avi pourquoi ta mis toutes ces fonctions ?? 
        //IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate);
        //Station GetStation(int code);
        //void UpdateStation(int code, Action<Station> update);

        #endregion
    }
}
