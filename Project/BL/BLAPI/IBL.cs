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
       void AddLine(Line line, Station station1, Station station2);                  //allows only after the user entered two stations
       void DeleteLine(int id);
       void AddStationToLine(LineStation lineStation, LineStation previous);
       void DeleteStationOfLine(int stationId, int lineId);
        Line GetLine(int myCode, Station FirstStation, Station LastStation);
        IEnumerable<Line> GetAllLine();
       IEnumerable<LineStation> GetAllLineStationsInLine();


        

        #endregion

        #region Station
       Station StationDoBoAdapter(DO.Station stationDO);
        void AddStation(Station station);       
        void DeleteStation(int code);
        IEnumerable<Station> GetAllStation();
        IEnumerable<BL.BO.Line> GetAllLineInStation();
        IEnumerable<AdjacentStations> GetAllAdjacentStations();
        void UpdateStation(Station station);
        Station GetStation(int code);
       


        #endregion

    }
}
