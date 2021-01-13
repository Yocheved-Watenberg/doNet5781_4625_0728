using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BL.BO;

//using BO;

namespace BL { 
    //memamech ttes les fctions du ibl
class BLImp : IBL //internal
    {
        IDAL dl = DLFactory.GetDL();

        #region Line
        BO.Line lineDoBoAdapter(DO.Line lineDO)     //
        {
            BO.Line lineBO = new BO.Line();            //bone student de BO
                                                       //DO.LineStation
                                                       //    Person personDO;
                                                       int id = lineDO.Id;
                                                       //try
                                                       //{
                                                       //    personDO = dl.GetPerson(id);
                                                       //}
                                                       //catch (DO.BadPersonIdException ex)
                                                       //{
                                                       //    throw new BO.BadStudentIdException("Student ID is illegal", ex);
                                                       //}

            //BO.Student studentBO = new BO.Student();
            //DO.Person personDO;
            //int id = studentDO.ID;
            lineDO.CopyPropertiesTo(lineBO);   //kah a person chel aDo et donne  le au student du BO
                                               //studentBO.ID = personDO.ID;
                                               //studentBO.BirthDate = personDO.BirthDate;
                                               //studentBO.City = personDO.City;
                                               //studentBO.Name = personDO.Name;
                                               //studentBO.HouseNumber = personDO.HouseNumber;
                                               //studentBO.Street = personDO.Street;
                                               //studentBO.PersonalStatus = (BO.PersonalStatus)(int)personDO.PersonalStatus;

            //kah a STUDENT chel aDo et donne  le au student du BO
            //studentBO.StartYear = studentDO.StartYear;
            //studentBO.Status = (BO.StudentStatus)(int)studentDO.Status;
            //studentBO.Graduation = (BO.StudentGraduate)(int)studentDO.Graduation;
            //studentBO.ListOfCourses = from sic in dl.GetStudentsInCourseList(sic => sic.PersonId == id)
            //                          let course = dl.GetCourse(sic.CourseId)
            //                          select course.CopyToStudentCourse(sic);
            lineBO.ListOfStations /*query on Do.lineStation withlineId=XXX*/  = from allStation in dl.GetAllLineStationBy(l => l.LineId == id)// copie tte la list de courses
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

                  //veut recevoir du dl le student
        
            public BO.Line getLine(int myCode,Station FirstStation,Station LastStation) {   //the first and last station are here to tell us what's the line(because two lines can have the same code)
            DO.Line lineDO;                       
            try
            {
               lineDO = dl.GetLine( l => l.Id == id);          //va au DO et donne moi le student
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
            }
            return studentDoBoAdapter(studentDO);           //si trouve ps va a adapter
        }

        public IEnumerable<BO.Student> GetAllStudents() // mm chose que student ms avc ttes les lists
        {
            //return from item in dl.GetStudentListWithSelectedFields( (stud) => { return GetStudent(stud.ID); } )
            //       let student = item as BO.Student
            //       orderby student.ID
            //       select student;
            return from item in dl.GetAllStudents()
                   select studentDoBoAdapter(item);
        }
        public IEnumerable<BO.Student> GetStudentsBy(Predicate<BO.Student> predicate)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<BO.ListedPerson> GetStudentIDNameList()
        {
            return from item in dl.GetStudentListWithSelectedFields((Func<DO.Student, object>)((stud) =>
            {
                try { Thread.Sleep(1500); } catch (ThreadInterruptedException e) { }
                return new BO.ListedPerson() { ID = stud.ID, Name = dl.GetPerson(stud.ID).Name };
            }))
                   let student = item as BO.ListedPerson
                   //orderby student.ID
                   select student;
        }

        public void UpdateStudentPersonalDetails(BO.Student student)
        {
            //Update DO.Person            
            DO.Person personDO = new DO.Person();
            student.CopyPropertiesTo(personDO);
            try
            {
                dl.UpdatePerson(personDO);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }

            //Update DO.Student            
            DO.Student studentDO = new DO.Student();
            student.CopyPropertiesTo(studentDO);
            try
            {
                dl.UpdateStudent(studentDO);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }

        }

        public void DeleteStudent(int id)// ne ps oublie d effacer la person le student et from all the courses
        {
            try
            {
                dl.DeletePerson(id);
                dl.DeleteStudent(id);
                dl.DeleteStudentFromAllCourses(id);
            }
            catch (DO.BadPersonIdCourseIDException ex)
            {
                throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Person id does not exist or he is not a student", ex);
            }
        }

        #endregion

        #region StudentIn Course
        public void AddStudentInCourse(int perID, int courseID, float grade = 0)
        {
            //try
            //{
            //    dl.AddStudentInCourse(perID, courseID, grade);
            //}
            //catch (DO.BadPersonIdCourseIDException ex)
            //{
            //    throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            //}
        }

        public void UpdateStudentGradeInCourse(int perID, int courseID, float grade)
        {
            //try
            //{
            //    dl.UpdateStudentGradeInCourse(perID, courseID, grade);
            //}
            //catch (DO.BadPersonIdCourseIDException ex)
            //{
            //    throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            //}
        }

        public void DeleteStudentInCourse(int perID, int courseID)
        {
            //try
            //{
            //    dl.DeleteStudentInCourse(perID, courseID);
            //}
            //catch (DO.BadPersonIdCourseIDException ex)
            //{
            //    throw new BO.BadStudentIdCourseIDException("Student ID and Course ID is Not exist", ex);
            //}
        }

        public Line GetLine(int id)
        {
           
            
            
            
            
            
            throw new NotImplementedException();
        }

        public void AddLine(Line line)
        { DO.Line DoLine = new DO.Line();
            line.CopyPropertiesTo(DoLine);
            foreach(LineStation item in line.ListOfLineStations)
            {

            }
            
                if (DataSource.ListLine.FirstOrDefault(l => l.Id == line.Id) != null)
                    throw new DO.BadLineIdException(line.Id, "this line already exists in the list of lines");
                DataSource.ListLine.Add(line.Clone());
            }
            throw new NotImplementedException();
        }

        
        BO.Student studentDoBoAdapter(DO.Student studentDO)
        {
            BO.Student studentBO = new BO.Student();
            DO.Person personDO;
            int id = studentDO.ID;
            try
            {
                personDO = dl.GetPerson(id);
            }
            catch (DO.BadPersonIdException ex)
            {
                throw new BO.BadStudentIdException("Student ID is illegal", ex);
            }
            personDO.CopyPropertiesTo(studentBO);
            //studentBO.ID = personDO.ID;
            //studentBO.BirthDate = personDO.BirthDate;
            //studentBO.City = personDO.City;
            //studentBO.Name = personDO.Name;
            //studentBO.HouseNumber = personDO.HouseNumber;
            //studentBO.Street = personDO.Street;
            //studentBO.PersonalStatus = (BO.PersonalStatus)(int)personDO.PersonalStatus;

            studentDO.CopyPropertiesTo(studentBO);
            //studentBO.StartYear = studentDO.StartYear;
            //studentBO.Status = (BO.StudentStatus)(int)studentDO.Status;
            //studentBO.Graduation = (BO.StudentGraduate)(int)studentDO.Graduation;

            studentBO.ListOfCourses = from sic in dl.GetStudentsInCourseList(sic => sic.PersonId == id)
                                      let course = dl.GetCourse(sic.CourseId)
                                      select course.CopyToStudentCourse(sic);
            //new BO.StudentCourse()
            //{
            //    ID = course.ID,
            //    Number = course.Number,
            //    Name = course.Name,
            //    Year = course.Year,
            //    Semester = (BO.Semester)(int)course.Semester,
            //    Grade = sic.Grade
            //};

            return studentBO;
        }
    public IEnumerable<Line> GetAllLine()
    {
        throw new NotImplementedException();
        }

        public IEnumerable<Line> GetAllLineBy(Predicate<Line> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(Line line)
        {
            throw new NotImplementedException();
        }

        public void UpdateLine(int Id, Action<Line> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteLine(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<LineStation> GetListOfLineStations()
        {
            throw new NotImplementedException();
        }

        public void AddBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public Bus GetBus(int licenseNum)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBus()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Bus> GetAllBusBy(Predicate<Bus> predicate)
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(Bus bus)
        {
            throw new NotImplementedException();
        }

        public void UpdateBus(int licenseNum, Action<Bus> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteBus(int licenseNum)
        {
            throw new NotImplementedException();
        }

        public void AddStation(Station station)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStation()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Station> GetAllStationBy(Predicate<Station> predicate)
        {
            throw new NotImplementedException();
        }

        public Station GetStation(int code)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(Station station)
        {
            throw new NotImplementedException();
        }

        public void UpdateStation(int code, Action<Station> update)
        {
            throw new NotImplementedException();
        }

        public void DeleteStation(int code)
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

