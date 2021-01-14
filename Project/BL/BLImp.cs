using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BL.BO;



namespace BL
{
    
    //memamech ttes les fctions du ibl
    class BLImp : IBL //internal
    {
        IDAL dl = DLFactory.GetDL();
        
        #region Line
        public BL.BO.Line LineDoBoAdapter(DO.Line lineDO)     //
        {
            BO.Line lineBO = new BO.Line();            
            int id = lineDO.Id;
            lineDO.CopyPropertiesTo(lineBO);   //copies all the fields from the DO to the Bo

            lineBO.ListOfStations /*query on Do.lineStation withlineId=XXX*/  =
                from allStation in dl.GetAllLineStationBy(l => l.LineId == id)
                let lineStation = dl.GetLineStation(allStation.LineId, allStation.StationCode)             //creates a line station with the line id                                                        
                select lineStation.CopyToLineStation(allStation);
            return lineBO;
        }
        public BO.Line GetLine(int myCode, Station FirstStation, Station LastStation)
        {   //the first and last station are here to tell us what's the line(because two lines can have the same code)
            DO.Line lineDO;
            try
            {
                lineDO = (DO.Line)dl.GetAllLineBy(l => l.Code == myCode && (l.FirstStation) == FirstStation.Code && (l.LastStation) == LastStation.Code);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineException("The code of the line does not exist or the stations are not in the line", ex);
            }
            return LineDoBoAdapter(lineDO);
        }


        //veut recevoir du dl le student

        public void AddLine(Line line)
        {
            DO.Line DoLine = new DO.Line();
            line.CopyPropertiesTo(DoLine);
            //foreach (LineStation item in line.ListOfLineStations)
            //{

            //}

            if (DataSource.ListLine.FirstOrDefault(l => l.Id == line.Id) != null)
                throw new DO.BadLineIdException(line.Id, "this line already exists in the list of lines");
            DataSource.ListLine.Add(line.Clone());

            throw new NotImplementedException();
        }
     //   public void DeleteStudent(int id)// ne ps oublie d effacer la person le student et from all the courses
        //{
        //    try
        //    {
        //        dl.DeletePerson(id);
        //        dl.DeleteStudent(id);
        //        dl.DeleteStudentFromAllCourses(id);
        //    }
        //    catch (DO.BadPersonIdCourseIDException ex)
        //    {
        //        throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
        //    }
        //    catch (DO.BadPersonIdException ex)
        //    {
        //        throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
        //    }
        //}
        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }
        public void AddStationToLine(LineStation lineStation, LineStation previous)
        {
            throw new NotImplementedException();
        }
        public void DeleteStationOfLine(int stationId, int lineId)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<BO.Line> GetAllLine()
        {
            return from item in dl.GetAllLine()
                   select LineDoBoAdapter(item);
        }
        public IEnumerable<LineStation> GetAllLineStationsInLine()
        {
            throw new NotImplementedException();
        }
       
        //public IEnumerable<BO.Line> GetStudentsBy(Predicate<BO.Line> predicate)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<BO.ListedPerson> GetStudentIDNameList()
        //{
        //    return from item in dl.GetStudentListWithSelectedFields((Func<DO.Student, object>)((stud) =>
        //    {
        //        try { Thread.Sleep(1500); } catch (ThreadInterruptedException e) { }
        //        return new BO.ListedPerson() { ID = stud.ID, Name = dl.GetPerson(stud.ID).Name };
        //    }))
        //           let student = item as BO.ListedPerson
        //           //orderby student.ID
        //           select student;
        //}

        //public void UpdateStudentPersonalDetails(BO.Student student)
        //{
        //    //Update DO.Person            
        //    DO.Person personDO = new DO.Person();
        //    student.CopyPropertiesTo(personDO);
        //    try
        //    {
        //        dl.UpdatePerson(personDO);
        //    }
        //    catch (DO.BadPersonIdException ex)
        //    {
        //        throw new BO.BadStudentIdException("Student ID is illegal", ex);
        //    }

        //    //Update DO.Student            
        //    DO.Student studentDO = new DO.Student();
        //    student.CopyPropertiesTo(studentDO);
        //    try
        //    {
        //        dl.UpdateStudent(studentDO);
        //    }
        //    catch (DO.BadPersonIdException ex)
        //    {
        //        throw new BO.BadStudentIdException("Student ID is illegal", ex);
        //    }

        //} 
        #endregion

        #region Stations
        BO.Station StationDoBoAdapter(DO.Station stationDO)     
        {
            BO.Station stationBO = new BO.Station();
            int id = stationDO.Code;
            stationDO.CopyPropertiesTo(stationBO);                          //copies all the fields from the DO to the Bo
            stationBO.ListOfLine /*query on Do.lineStation withlineId=XXX*/  = from allLine in dl.GetAllStationBy(l => l.Id == id)// copie tte la list de courses
                                                                                let station = dl.GetStation(allStation.LineId)
                                                                                select station.CopyToLineStation(allStation);
            //new BO.StudentCourse()
            //{
            //    ID = course.ID,
            //    Number = course.Number,
            //    Name = course.Name,
            //    Year = course.Year,
            //    Semester = (BO.Semester)(int)course.Semester,
            //    Grade = sic.Grade
            //};

            return lineBO;
        }
        public void AddStation(Station station)   //tres simple creer juste la station, pas bsn de dire les lignes qui pasent par cette station
                                                  //pr creer ou leadken les lignes qui passent par cette station jle fais direct par line
        {
            throw new NotImplementedException();
        }
        public void DeleteStation(int code)
        {
            throw new NotImplementedException();
        }
        public IEnumerable<Station> GetAllStation()
        {
            return from item in dl.GetAllStation()
                   select StationDoBoAdapter(item);
        }
        public IEnumerable<Line> GetAllLineInStation()
        {
            throw new NotImplementedException();
        }
        public IEnumerable<AdjacentStations> GetAllAdjacentStations()
        {
            throw new NotImplementedException();
        }
        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }
        #endregion

        #region Course

        //BO.Course courseDoBoAdapter(DO.Course courseDO)
        //{
        //    BO.Course courseBO = new BO.Course();
        //    int id = courseDO.ID;
        //    courseDO.CopyPropertiesTo(courseBO);

        //    courseBO.Lecturers = from lic in dl.GetLecturersInCourseList(lic => lic.CourseId == id)
        //                         let course = dl.GetCourse(lic.CourseId)
        //                         select (BO.CourseLecturer)course.CopyPropertiesToNew(typeof(BO.CourseLecturer));
        //    return courseBO;
        //}
        //public IEnumerable<BO.Course> GetAllCourses()
        //{
        //    return from crsDO in dl.GetAllCourses()
        //           select courseDoBoAdapter(crsDO);
        //}

        #endregion

    }
}

