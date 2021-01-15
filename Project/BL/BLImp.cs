using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BL.BO;
//using BO;

//let student = item as bool.Student
//    orderby student.ID
//    select student;

namespace BL
{
    class BLImp : IBL //internal
    {
        IDAL dl = DLFactory.GetDL();

        public void AddLine(BO.Line line)
        {
            throw new NotImplementedException();
        }

        public void AddStation(BO.Station station)
        {
            throw new NotImplementedException();
        }

        public void AddStationToLine(BO.LineStation lineStation, BO.LineStation previous)

        //veut recevoir du dl le student

        public void AddLine(Line line)
        {
            throw new NotImplementedException();
        }
            DO.Line DoLine = new DO.Line();
            line.CopyPropertiesTo(DoLine);
            DO.LineStation LineStationDO1, LineStationDO2;
            try
            {
                LineStationDO1 = (DO.LineStation)dl.GetLineStation((line.ListOfStations.ToList())[0].LineId, (line.ListOfStations.ToList())[0].StationCode) ;
                LineStationDO2 = (DO.LineStation)dl.GetLineStation((line.ListOfStations.ToList()).Last().LineId, line.ListOfStations.ToList().Last().StationCode);

            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("The code of the station does not exist", ex);
            }
            DoLine.FirstStation = LineStationDO1.StationCode;
            DoLine.LastStation = LineStationDO2.StationCode;
            dl.AddLine(DoLine);

        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }

        public void DeleteStationOfLine(int stationId, int lineId)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.AdjacentStations> GetAllAdjacentStations()
        {
            return from item in dl.GetAllAdjacentStations() 
                   select adjacentStationsDoBoAdapter(item);
        }

        public BL.BO.AdjacentStations adjacentStationsDoBoAdapter(DO.AdjacentStations adjDO)
        {
            BL.BO.AdjacentStations adjBO = new BL.BO.AdjacentStations();
            adjDO.CopyPropertiesTo(adjBO);
            return adjBO;
        }

        public IEnumerable<BO.Line> GetAllLineInStation()
        {
            throw new NotImplementedException();

        }

        public IEnumerable<BO.LineStation> GetAllLineStationsInLine()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetAllLineStationsInLine(Line line)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.Station> GetAllStation()
        {
            throw new NotImplementedException();
        }

        public BO.Line GetLine(int myCode, BO.Station FirstStation, BO.Station LastStation)
        {
            throw new NotImplementedException();
        }

        public BO.Station GetStation(int code)
        {
            DO.Station stationDO;
            try
            {
                stationDO = dl.GetStation(code);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("The code of the station does not exist", ex);
            }
            return StationDoBoAdapter(stationDO);
        }

        public BO.Station StationDoBoAdapter(DO.Station stationDO)
        {
            //BO.Station stationBO = new BO.Station();
            //stationDO.CopyPropertiesTo(stationBO);
            //stationBO.ListOfLine = from allLine in dl.GetAllLineBy(l => l.Code == stationDO.Code)
            //                       let line = dl.GetLine(allLine.Id)
            //                       select line.CopyToLine();                       // a fr
            //return stationBO;
            throw new NotImplementedException();

        }

        public void UpdateStation(BO.Station station)
        {
            throw new NotImplementedException();
        }

        //        #region Line


        public BO.Line LineDoBoAdapter(DO.Line lineDO)     
        {
            BO.Line lineBO = new BO.Line();
            lineDO.CopyPropertiesTo(lineBO);
            lineBO.ListOfStations = from allStation in dl.GetAllLineStationBy(l => l.LineId == lineDO.Id)
                                    let station = dl.GetStation(allStation.LineId)
                                    select station.CopyToLineStation();
            return lineBO;
        }



        //        public BO.Line GetLine(int myCode, Station FirstStation, Station LastStation)
        //        {   //the first and last station are here to tell us what's the line(because two lines can have the same code)
        //            DO.Line lineDO;
        //            try
        //            {
        //                lineDO = (DO.Line)dl.GetAllLineBy(l => l.Code == myCode && (l.FirstStation) == FirstStation.Code && (l.LastStation) == LastStation.Code);
        //            }
        //            catch (DO.BadLineIdException ex)
        //            {
        //                throw new BO.BadLineException("The code of the line does not exist or the stations are not in the line", ex);
        //            }
        //            return LineDoBoAdapter(lineDO);
        //        }


        //        //veut recevoir du dl le student

        //        public void AddLine(Line line/*,Station station1,Station station2*/)
        //        {
        //            DO.Line DoLine = new DO.Line();
        //            line.CopyPropertiesTo(DoLine);
        //            DO.LineStation LineStationDO1, LineStationDO2;
        //            try
        //            {
        //                LineStationDO1 = (DO.Station)dl.GetLineStation((line.ListOfStations.ToList())[0].LineId, (line.ListOfStations.ToList())[0].StationCode) ;
        //                LineStationDO2 = (DO.Station)dl.GetStation(station2.Code);

        //            }
        //            catch (DO.BadStationIdException ex)
        //            {
        //                throw new BO.BadStationException("The code of the station does not exist", ex);
        //            }
        //            DoLine.FirstStation = station1.Code;
        //            DoLine.LastStation = station2.Code;
        //            dl.AddLine(DoLine);



        //        }
        //     //   public void DeleteStudent(int id)// ne ps oublie d effacer la person le student et from all the courses
        //        //{
        //        //    try
        //        //    {
        //        //        dl.DeletePerson(id);
        //        //        dl.DeleteStudent(id);
        //        //        dl.DeleteStudentFromAllCourses(id);
        //        //    }
        //        //    catch (DO.BadPersonIdCourseIDException ex)
        //        //    {
        //        //        throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
        //        //    }
        //        //    catch (DO.BadPersonIdException ex)
        //        //    {
        //        //        throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
        //        //    }
        //        //}
        //        public void DeleteLine(int id)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        public void AddStationToLine(LineStation lineStation, LineStation previous)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        public void DeleteStationOfLine(int stationId, int lineId)
        //        {
        //            throw new NotImplementedException();
        //        }
        public IEnumerable<BO.Line> GetAllLine()
        {
            return from item in dl.GetAllLine()
                   select LineDoBoAdapter(item);
        }
        //        public IEnumerable<LineStation> GetAllLineStationsInLine()
        //        {
        //            throw new NotImplementedException();
        //        }

        //        //public IEnumerable<BO.Line> GetStudentsBy(Predicate<BO.Line> predicate)
        //        //{
        //        //    throw new NotImplementedException();
        //        //}

        //        //public IEnumerable<BO.ListedPerson> GetStudentIDNameList()
        //        //{
        //        //    return from item in dl.GetStudentListWithSelectedFields((Func<DO.Student, object>)((stud) =>
        //        //    {
        //        //        try { Thread.Sleep(1500); } catch (ThreadInterruptedException e) { }
        //        //        return new BO.ListedPerson() { ID = stud.ID, Name = dl.GetPerson(stud.ID).Name };
        //        //    }))
        //        //           let student = item as BO.ListedPerson
        //        //           //orderby student.ID
        //        //           select student;
        //        //}

        //        //public void UpdateStudentPersonalDetails(BO.Student student)
        //        //{
        //        //    //Update DO.Person            
        //        //    DO.Person personDO = new DO.Person();
        //        //    student.CopyPropertiesTo(personDO);
        //        //    try
        //        //    {
        //        //        dl.UpdatePerson(personDO);
        //        //    }
        //        //    catch (DO.BadPersonIdException ex)
        //        //    {
        //        //        throw new BO.BadStudentIdException("Student ID is illegal", ex);
        //        //    }

        //        //    //Update DO.Student            
        //        //    DO.Student studentDO = new DO.Student();
        //        //    student.CopyPropertiesTo(studentDO);
        //        //    try
        //        //    {
        //        //        dl.UpdateStudent(studentDO);
        //        //    }
        //        //    catch (DO.BadPersonIdException ex)
        //        //    {
        //        //        throw new BO.BadStudentIdException("Student ID is illegal", ex);
        //        //    }

        //        //} 
        //        #endregion

        //        #region Stations
        //     
        //        public void AddStation(Station station)   //tres simple creer juste la station, pas bsn de dire les lignes qui pasent par cette station
        //                                                  //pr creer ou leadken les lignes qui passent par cette station jle fais direct par line
        //        {
        //            throw new NotImplementedException();
        //        }
        //        public void DeleteStation(int code)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        public IEnumerable<Station> GetAllStation()
        //        {
        //            return from item in dl.GetAllStation()
        //                   select StationDoBoAdapter(item);
        //        }
        //        public IEnumerable<Line> GetAllLineInStation()
        //        {
        //            throw new NotImplementedException();
        //        }
       
        //        public void UpdateStation(Station station)
        //        {
        //            throw new NotImplementedException();
        //        }
        //        #endregion



        //    }
    }
}

