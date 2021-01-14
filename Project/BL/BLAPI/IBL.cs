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
        //Add bus to the list
        //get all bus in station
        //etc...
        #region Line
        Line GetLine( int myCode, Station FirstStation, Station LastStation);
       void AddLine(Line line);
       IEnumerable<Line> GetAllLine();
       IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate); 
        void UpdateLine(Line line);
        void UpdateLine(int Id, Action<Line> update);
        void DeleteLine(int id);
        IEnumerable<LineStation> GetListOfLineStations();


        #endregion

        #region Station
        void AddStation(Station station);
        IEnumerable<Station> GetAllStation();
        IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate);
        Station GetStation(int code);
        void UpdateStation(Station station);
        void UpdateStation(int code, Action<Station> update);
        void DeleteStation(int code);
        #endregion//IEnumerable<BO.Course> GetAllCourses();

    }
}
