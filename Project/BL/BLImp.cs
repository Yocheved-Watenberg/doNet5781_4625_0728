using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BL.BO;
using DS;

//let student = item as bool.Student
//    orderby student.ID
//    select student;

namespace BL
{
    class BLImp : IBL //internal
    {
        IDAL dl = DLFactory.GetDL();
        Random rand = new Random(DateTime.Now.Millisecond);
        #region Station
        public void AddStation(BO.Station station)   //tres simple creer juste la station, pas bsn de dire les lignes qui pasent par cette station
                                                     //pr creer ou leadken les lignes qui passent par cette station jle fais direct par line
        {
            //    if (DataSource.ListStation.Exists(s => s.Code == station.Code))
            //        throw new BO.BadStationException("This station already exist", ex);
            //}
            DO.Station myDoStation = new DO.Station();
            station.CopyPropertiesTo(myDoStation);
            try
            {
                dl.AddStation(myDoStation);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station already exist", ex);
            }
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
        public IEnumerable<BO.Line> GetAllLineInStation(BO.Station s)   
        {
            try
            {
                return from ls in dl.GetAllLineStationBy(ls => ls.StationCode == s.Code)  //searches all the LineStations which have the same code than the station sent 
                       let line = dl.GetLine(ls.LineCode)                                 //creates a line from the Id of the LineStation
                       select LineDoBoAdapter(line);
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
         else
            {
                return GetAllStation();
            }
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
        public void AddLine(int myCode, BO.Enum.Areas myArea, IEnumerable<BO.LineStation> myListOfStations)
        {
            BO.Line BoLine = new BO.Line();
            BoLine.Id = Static.GetLineIdCounterDO();
            BoLine.Code = myCode;
            BoLine.Area = myArea; //(DO.Enums.Areas)myArea; 
            BoLine.ListOfStations = myListOfStations;



            DO.Line DoLine = new DO.Line();
            BoLine.CopyPropertiesTo(DoLine);
            DoLine.FirstStation = myListOfStations.First().StationCode;
            DoLine.LastStation = myListOfStations.Last().StationCode;


            //create the adjacents stations
            List<LineStation> listStations = myListOfStations.ToList(); 
            for (int i = 0; i < listStations.Count() - 1; i++)
            {
                if (!(DataSource.ListAdjacentStations.Exists(adj=> (adj.Station1== listStations[i].StationCode) && (adj.Station2 == listStations[i + 1].StationCode))))                                        //meaning there aren't already two Adjacents Stations 
                {
                    DO.AdjacentStations newAdjStat = new DO.AdjacentStations();
                    newAdjStat.Station1 = listStations[i].StationCode;
                    newAdjStat.Station2 = listStations[i + 1].StationCode;
                    newAdjStat.Distance = GetDistanceTo(StationLineStationAdapter(listStations[i]), StationLineStationAdapter(listStations[i + 1])) * 1.5;
                    int timeSec = (int)newAdjStat.Distance * (rand.Next()+1 % 5) / (rand.Next()+1 % 5);
                    newAdjStat.Time = new TimeSpan(00, 00, timeSec);
                    dl.AddAdjacentStations(newAdjStat);
                }
            }
       
            try
            {
                dl.AddLine(DoLine);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineException("This line already exist", ex);
            }
        }

        public void DeleteLine(int code)
        {
            try
            {
                dl.DeleteLine(code);     //delete the line itself
                //IEnumerable<DO.LineStation> lineStation = dl.GetAllLineStationBy(ls => ls.LineCode == code);  //on na pas le droit de creer un inumerable, mettre une liste a la place 
                //foreach (var item in lineStation) { dl.DeleteLineStation(item.LineCode, item.StationCode); }
                // but also all the lineStations which are related to this line
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
                return from item in dl.GetAllLineStationBy(l => l.LineCode == line.Code)
                       select LineStationDoBoAdapter(item);
            }
            catch(DO.BadLineIdException ex)
            {
                throw new BO.BadLineException("This line does not exist", ex);
            }
        }

        public IEnumerable<Station> GetAllStationInLine(Line l) 
        {
            return from item in GetAllLineStationsInLine(l)
                   select StationLineStationAdapter(item);                 
        }

        public IEnumerable<Station> GetAllStationsInLines(IEnumerable<Line> lines)//a metttre ds le ibl 
        {
            List<Station> newList = new List<Station>(); 
            foreach (Line line in lines)
            {
                foreach (Station station in GetAllStationInLine(line))
                {
                    newList.Add(station);
                }
            }
           return newList.Distinct(); 
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

        public Line GetLine(int myCode)
        {
            DO.Line lineDO;
            try
            {
                lineDO = (DO.Line)dl.GetLine(myCode);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineException("The code of the line does not exist ", ex);
            }
            return LineDoBoAdapter(lineDO);
        }
    
    public BO.Line LineDoBoAdapter(DO.Line lineDO)
        {
            BO.Line lineBO = new BO.Line();
            lineDO.CopyPropertiesTo(lineBO);
            lineBO.ListOfStations = from allStation in dl.GetAllLineStationBy(ls => ls.LineCode == lineDO.Code)
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

        public IEnumerable<BO.Line> GetAllLineBy(Predicate<DO.Line> predicate)
        {
            return from item in dl.GetAllLineBy(predicate)
                   select LineDoBoAdapter(item);
        }

        public IEnumerable<Station> GetStationByArea(BL.BO.Enum.Areas myArea)
        {
           return GetAllStationsInLines(GetAllLineBy(l => (BL.BO.Enum.Areas)l.Area == myArea));
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
        #region global functions

        private double GetDistanceTo(Station s1, Station s2)           //donne la distance a vol doiseau entre deux stations
        {
            return Math.Sqrt(Math.Pow(s1.Longitude - s2.Longitude, 2) + Math.Pow(s1.Latitude - s2.Latitude, 2));
        }
        private Station StationLineStationAdapter(LineStation l)
        {
            return GetStation(l.StationCode);
        }

        private Line LineStationLineAdapter (LineStation l)
        {
            return LineDoBoAdapter(dl.GetLine(l.LineCode));
        }
        #endregion
        //Afr??
        //#region LineTrip
        //public void AddLineTrip(LineTrip lineTrip)
        //{

        //}
        //public void DeleteLineTrip(int code);
        //public IEnumerable<LineTrip> GetAllLineTrip();
        //public void UpdateLineTrip(Station station);
        //public Station GetLineTrip(int code);
        //public IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate);


        //copié coller entierement de tirtsa 
        public IEnumerable<IGrouping<TimeSpan, LineTiming>> StationTiming(BL.BO.Station station, TimeSpan hour)
        {
            //if (station.LinesThatPass == null)
          //  throw new BO.BadLineTripException("There is any trip during these hours for the requested line", ex);
            try
            {
                List<LineTiming> timing = new List<LineTiming>();
                foreach (var lineId in GetAllLineInStation(station))
                {
                    foreach (var item in ListArrivalOfLine(lineId.Code, hour, station.Code))
                        timing.Add(item);
                }

                return from item in timing
                       group item by item.ExpectedTimeTillArrive;
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BO.BadLineTripException("There is any trip during these hours for the requested line", ex);
            }

        }

        //copier coller entierement de tirtsa

        public IEnumerable<LineTiming> ListArrivalOfLine(int lineId, TimeSpan hour, int stationKey)
        {
            //Calcul of TravelTime between first station of line and our station
            Line line = GetLine(lineId);
            TimeSpan durationOfTravel = DurationOfTravel(line, stationKey);

            DO.LineTrip myLineTrip = dl.GetLineTrip(lineId, hour);


            List<LineTiming> listTiming = new List<LineTiming>(); //initialize list of all timing for the specified line
            while (myLineTrip.StartAt + durationOfTravel < hour)
                myLineTrip.StartAt += myLineTrip.Frequency; //we can change value of StartTimeRange thanks to Clone() 
            for (TimeSpan i = myLineTrip.StartAt; i <= hour;)
            {
                listTiming.Add(new LineTiming
                {
                    TripStart = i,
                    LineId = myLineTrip.LineId,
                    ExpectedTimeTillArrive = i + durationOfTravel
                });
                i += myLineTrip.Frequency;
            }
            //if station is the first we want to show 2 nexts departures
            if (stationKey == line.ListOfStations.First().StationCode)
            {
                listTiming.Add(new LineTiming
                {
                    TripStart = myLineTrip.StartAt,
                    LineId = myLineTrip.LineId,
                    ExpectedTimeTillArrive = myLineTrip.StartAt
                });
                myLineTrip.StartAt += myLineTrip.Frequency;
                listTiming.Add(new LineTiming
                {
                    TripStart = myLineTrip.StartAt,
                    LineId = myLineTrip.LineId,
                    ExpectedTimeTillArrive = myLineTrip.StartAt
                });
            }
            return listTiming;

        }

        //copié coller entierement de tirtsa
        internal TimeSpan DurationOfTravel(Line line, int stationKey)
        {
            int indexOfStation = dl.GetLineStation(line.Id, stationKey).LineStationIndex;
            IEnumerable<DO.LineStation> stations = (from lineStat in dl.GetAllLineStationBy(l => l.LineCode == line.Code).ToList()
                                                    where lineStat.LineStationIndex <= indexOfStation
                                                    select lineStat).ToList();

            TimeSpan travelDuration = new TimeSpan();
            for (int i = 0; i < stations.Count() - 1; i++)
            {
                travelDuration += dl.GetAdjacentStations(stations.ElementAt(i).StationCode, stations.ElementAt(i + 1).StationCode).Time;
            }
            return travelDuration;
        }


    }


}


