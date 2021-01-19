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


        #region Station
        public void AddStation(BO.Station station)   //tres simple creer juste la station, pas bsn de dire les lignes qui pasent par cette station
                                                     //pr creer ou leadken les lignes qui passent par cette station jle fais direct par line
        {

            DO.Station DoStation = new DO.Station();
            try
            {
                if ((DO.Station)dl.GetStation(station.Code) == null)                //if it finds a station with this code it sent, that s means that the station already exists
                {
                    station.CopyPropertiesTo(DoStation);

                }
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station already exist", ex);
            }
            dl.AddStation(DoStation);
        }
        public void DeleteStation(int code)
        {

            try
            {
                dl.DeleteStation(code);
                IEnumerable<DO.AdjacentStations> adjStationsToDelete = dl.GetAllAdjacentStationsBy(s => s.Station1 == code || s.Station2 == code);    //gets all the AdjacentStations which contains the station with the "code "
                foreach (DO.AdjacentStations item in adjStationsToDelete) dl.DeleteAdjacentsStationsFrom(item);                                      //deletes each one of the AdjacentStation
                                                                                                                                                     //ENLEVER cette station de la liste des lines                                                                                                                                                                                              
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station does not exist", ex);
            }

        }
        public IEnumerable<BO.Line> GetAllLineInStation(BO.Station s)   //a revoir renvoie t elle vrmnt bo.line, ps plutot do.line
        {
            try
            {
                IEnumerable<Line> lineInStation = from ls in dl.GetAllLineStationBy(ls => ls.StationCode == s.Code)
                                                      //searches all the LineStations which have the same code than the station sent 
                                                  let line = dl.GetLine(ls.LineId)
                                                  //creates a line from the Id of the LineStation
                                                  select LineDoBoAdapter(line);
                return lineInStation;
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station does not exist", ex);
            }

        }
        public IEnumerable<BO.Station> GetAllStation()
        {
            return from item in dl.GetAllStation()
                   select StationDoBoAdapter(item);
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
            BO.Station stationBO = new BO.Station();
            stationDO.CopyPropertiesTo(stationBO);
            //stationBO.ListOfLine = from allLine in dl.GetAllLineStationBy(l => l.StationCode == stationDO.Code)           //searches in all the lineStation which one has the code of the station
            //                       let line = dl.GetLine(allLine.LineId)
            //                       select line.CopyToLine();                                                               // 
            return stationBO;
        }
        public void UpdateStation(BO.Station station)
        {
            DO.Station stationDO = new DO.Station();
            station.CopyPropertiesTo(stationDO);
            try
            {
                dl.UpdateStation(stationDO);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station doesn't exist", ex);
            }


        }
        public IEnumerable<BO.Station> GetAllStationBy(Predicate<BO.Station> predicate)
        {
            if (predicate != null)
            {
                return from station in dl.GetAllStationBy((Predicate<DO.Station>)predicate)
                       select StationDoBoAdapter(station);

                //return from station in dl.GetAllStation()
                //       where predicate(station)
                //       select StationDoBoAdapter(station);
            }
            return GetAllStation();
        }
        #endregion
        #region Line
        public void AddStationToLine(BO.LineStation lineStation, BO.LineStation previous)
        {//can only add a Station which already exists
            try
            {
                dl.GetStation(lineStation.StationCode);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station doesn't exist", ex);
            }
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStation);
            dl.AddLineStation(lineStationDO);
        }
    

        public void AddLine(BO.Line line)
        {
        List<LineStation> listStations = line.ListOfStations.ToList();
        DO.Line DoLine = new DO.Line();
        line.CopyPropertiesTo(DoLine);
        DO.LineStation LineStationDO1, LineStationDO2;
           
            try
            {
                LineStationDO1 = (DO.LineStation) dl.GetLineStation((listStations)[0].LineId, (listStations)[0].StationCode);
                LineStationDO2 = (DO.LineStation) dl.GetLineStation((listStations).Last().LineId, listStations.Last().StationCode);
                for (int i = 0; i < listStations.Count(); i++)
                {
                       DO.AdjacentStations adjStat = dl.GetAdjacentStations(listStations[i].StationCode, listStations[i + 1].StationCode);
                       if(adjStat==null)                                        //meaning there aren't already two Adjacents Stations 
                       {
                        DO.AdjacentStations newAdjStat = new DO.AdjacentStations();
                        newAdjStat.Station1 = listStations[i].StationCode;
                        newAdjStat.Station2 = listStations[i + 1].StationCode;
                        newAdjStat.Time =                   ;
                        newAdjStat.Distance = GetDistanceTo();
                        dl.AddAdjacentStations(newAdjStat);
                       }

                }
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("The code of the station does not exist", ex);
            }

        DoLine.FirstStation = LineStationDO1.StationCode;
        DoLine.LastStation = LineStationDO2.StationCode;
        dl.AddLine(DoLine);
        
        }
        
            




        public void DeleteLine(int id)
        {
            try
            {
                dl.DeleteLine(id);      //first delete the line itself
                IEnumerable<DO.LineStation> lineStation=dl.GetAllLineStationBy(l => l.LineId == id);
                foreach(DO.LineStation item in lineStation) { dl.DeleteLineStation(item.LineId, item.StationCode); }
                                        //but also all the lineStations which are related to this line                                                                                                                                                                                   
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station does not exist", ex);
            }

        }
        public void DeleteStationOfLine(int stationId, int lineId)
        {
            try
            {
                 dl.DeleteLineStation(lineId,stationId);
            }
            catch(DO.BadLineStationIdException ex)
            {
                throw new BO.BadStationException("This station does not exist", ex);
            }

        }
        public IEnumerable<BO.Line> GetAllLine()
        {
            return from item in dl.GetAllLine()
                   select LineDoBoAdapter(item);
        }
        public IEnumerable<LineStation> GetAllLineStationsInLine(Line line)
        {
            try
            {
                IEnumerable<DO.LineStation> lineStationDO = dl.GetAllLineStationBy(l => l.LineId == line.Id);
                return from item in lineStationDO 
                select LineStationDoBoAdapter(item); 
            }
            catch(DO.BadLineIdException ex)
            {
                throw new BO.BadLineException("This line does not exist", ex);
            }
        }
        public BO.Line GetLine(int myCode, BO.Station FirstStation, BO.Station LastStation)
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
        public BO.Line LineDoBoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            lineDO.CopyPropertiesTo(lineBO);
            lineBO.ListOfStations = from allStation in dl.GetAllLineStationBy(l => l.LineId == lineDO.Id)
                                 //   let station = dl.GetStation(allStation.LineId)
                                    select LineStationDoBoAdapter(allStation);
            return lineBO;
        }
       public BL.BO.LineStation LineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new BO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStationBO);
            //il faut rajouter distance et time 
            lineStationBO.StationName = dl.GetStation(lineStationDO.StationCode).Name;
            return lineStationBO;
        }

        #endregion
        #region adjacentStation
        public BL.BO.AdjacentStations adjacentStationsDoBoAdapter(DO.AdjacentStations adjDO)
        {
            BL.BO.AdjacentStations adjBO = new BL.BO.AdjacentStations();
            adjDO.CopyPropertiesTo(adjBO);
            return adjBO;
        }
        public IEnumerable<BO.AdjacentStations> GetAllAdjacentStations()
        {
            return from item in dl.GetAllAdjacentStations()
                   select adjacentStationsDoBoAdapter(item);
        }
        #endregion

        public double GetDistanceTo(this Station s, double longitude, double latitude)
        {
            return Math.Sqrt(Math.Pow(s.Longitude - longitude, 2) + Math.Pow(s.Latitude - latitude, 2));
        }
    }
}

