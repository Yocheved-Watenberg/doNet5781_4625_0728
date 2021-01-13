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
       Line GetLine(int id);
       void AddLine(Line line);
       IEnumerable<Line> GetAllLine();
       IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate); 
        void UpdateLine(Line line);
        void UpdateLine(int Id, Action<Line> update);
        void DeleteLine(int id);
        IEnumerable<LineStation> GetListOfLineStations();


        #endregion



        #region Bus
        void AddBus(Bus bus);
        Bus GetBus(int licenseNum);
        IEnumerable<Bus> GetAllBus();
        IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate);
        void UpdateBus(Bus bus);
        void UpdateBus(int licenseNum, Action<Bus> update);
        void DeleteBus(int licenseNum);
        

        #endregion

        #region Course
        //IEnumerable<BO.Course> GetAllCourses();
        #endregion
    }
}
