using System;
using System.Collections.Generic;
using System.Linq;
using DLAPI;
using BLAPI;
using System.Threading;
using BL.BO;
using DS;

namespace BL
{
    class BLImp : IBL 
    {
        IDAL dl = DLFactory.GetDL();
        Random rand = new Random(DateTime.Now.Millisecond);
        #region Station
        public void AddStation(BO.Station station)
        { 
            DO.Station myDoStation = new DO.Station();
            station.CopyPropertiesTo(myDoStation);
            try
            {
                dl.AddStation(myDoStation);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station already exist", ex);
            }
        }
        public void DeleteStation(int code)
        {
            try
            {
                IEnumerable<DO.AdjacentStations> adjStationsToDelete = dl.GetAllAdjacentStationsBy(s => s.Station1 == code || s.Station2 == code);    //gets all the AdjacentStations which contains the station with the "code"
                foreach (DO.AdjacentStations item in adjStationsToDelete) 
                    dl.DeleteAdjacentsStationsFrom(item);                                                                                             //deletes each one of the AdjacentStation
                dl.DeleteStation(code);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station does not exist", ex);
            }
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
                throw new BO.BadStationIdException("The code of the station does not exist", ex);
            }
            return StationDoBoAdapter(stationDO);
        }
        public IEnumerable<BO.Station> GetAllStation()
        {
            return from item in dl.GetAllStation()
                   select StationDoBoAdapter(item);
        }
        public IEnumerable<Station> GetStationByArea(BL.BO.Enum.Areas myArea)
        {
            return GetAllStationsInLines(GetAllLineBy(l => (BL.BO.Enum.Areas)l.Area == myArea));
        }
        public IEnumerable<BO.Station> GetAllStationBy(Predicate<BO.Station> predicate)
        {
            if (predicate != null)
            {
                return from station in dl.GetAllStationBy((Predicate<DO.Station>)predicate)
                       select StationDoBoAdapter(station);
            }
            else
            {
                return GetAllStation();
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
                throw new BO.BadStationIdException("This station does not exist", ex);
            }
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
                throw new BO.BadStationIdException("This station doesn't exist", ex);
            }
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
        public Station StationLineStationAdapter(LineStation l)
        {
            return GetStation(l.StationCode);
        }
        #endregion
        #region Line

        public void AddStationToLine(BO.LineStation lineStation, BO.LineStation previous)
        {//can only add a Station which already exists
            try
            {
                dl.GetStation(lineStation.StationCode);
                dl.GetStation(previous.StationCode);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationException("This station doesn't exist", ex);
            }
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStation.CopyPropertiesTo(lineStationDO);
            DO.LineStation lineStationPreviousDO = new DO.LineStation();
            previous.CopyPropertiesTo(lineStationPreviousDO);
            dl.AddLineStationAfter(lineStationDO, lineStationPreviousDO);
            

        }
        public void AddLine(int myCode, BO.Enum.Areas myArea, IEnumerable<BO.LineStation> myListOfStations)
        {
            BO.Line BoLine = new BO.Line();
            BoLine.Id = Static.GetLineIdCounterDO();
            BoLine.Code = myCode;
            BoLine.Area = myArea; 
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
                throw new BO.BadLineIdException("This line already exist", ex);
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
                throw new BO.BadStationIdException("This station does not exist", ex);
            }
        }
        public void AddStationToLine(BO.LineStation lineStation, BO.LineStation previous)
        {//can only add a Station which already exists
            try
            {
                dl.GetStation(lineStation.StationCode);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("This station doesn't exist", ex);
            }
            DO.LineStation lineStationDO = new DO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStation);
            dl.AddLineStation(lineStationDO);
        }
        public void DeleteStationOfLine(int stationCode, int lineCode)
        {
            try
            {
                Line myLine = GetLine(lineCode);
                BO.Enum.Areas myArea = myLine.Area;
                List<LineStation> list = myLine.ListOfStations.ToList();
                list.Remove(GetLineStation(lineCode, stationCode));
                dl.DeleteLineStation(lineCode, stationCode);
                DeleteLine(lineCode);
                AddLine(lineCode, myArea, list); //this function creates also all the adj stations
            }
            catch (DO.BadLineStationIdException ex)
            {
                throw new BO.BadStationIdException("This station does not exist", ex);
            }
        }
        public Line GetLine(int myCode)
        {
            DO.Line lineDO;
            try
            {
                lineDO = dl.GetLine(myCode);
            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineIdException("The code of the line does not exist ", ex);
            }
            return LineDoBoAdapter(lineDO);
        }
        public IEnumerable<Line> GetAllLine()
        {
            return from item in dl.GetAllLine()
                   select LineDoBoAdapter(item);
        }
        public IEnumerable<Line> GetAllLineBy(Predicate<DO.Line> predicate)
        {
            return from item in dl.GetAllLineBy(predicate)
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
                throw new BO.BadLineIdException("This line does not exist", ex);
            }
        }
        public IEnumerable<Station> GetAllStationInLine(Line l) 
        {
            return from item in GetAllLineStationsInLine(l)
                   select StationLineStationAdapter(item);                 
        }
        public IEnumerable<Station> GetAllStationsInLines(IEnumerable<Line> lines) 
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
        public Line LineDoBoAdapter(DO.Line lineDO)
        {
            Line lineBO = new Line();
            lineDO.CopyPropertiesTo(lineBO);
            lineBO.ListOfStations = from allStation in dl.GetAllLineStationBy(ls => ls.LineCode == lineDO.Code)
                                    select LineStationDoBoAdapter(allStation);
            return lineBO;
        }
        #endregion
        #region line station
        public void AddLineStation(int lineCode, int stationCode, int index)
        { 
            DO.LineStation newDOLineStation = new DO.LineStation();
            newDOLineStation.LineCode = lineCode;
            newDOLineStation.StationCode = stationCode;
            newDOLineStation.LineStationIndex = index;
            
            Line line = GetLine(lineCode);
            List<LineStation> list = line.ListOfStations.ToList();
            list.Insert(index, LineStationDoBoAdapter(newDOLineStation));
            DeleteLine(lineCode);
            AddLine(lineCode, line.Area, list);
            newDOLineStation.PrevStation = GetLineStation(lineCode, line.ListOfStations.ToList()[index - 1].StationCode).StationCode;
            newDOLineStation.NextStation = GetLineStation(lineCode, line.ListOfStations.ToList()[index + 1].StationCode).StationCode;
            dl.AddLineStation(newDOLineStation);
        }
        public LineStation GetLineStation(int lineCode, int stationCode)
        {
            LineStation lineStation;
            try
            {
                lineStation = LineStationDoBoAdapter(dl.GetLineStation(lineCode, stationCode));

            }
            catch (DO.BadLineIdException ex)
            {
                throw new BO.BadLineStationIdException("this lineStation doesn't exist", ex);
            }
            return lineStation;
        }
        public BL.BO.LineStation LineStationDoBoAdapter(DO.LineStation lineStationDO)
        {
            BO.LineStation lineStationBO = new BO.LineStation();
            lineStationDO.CopyPropertiesTo(lineStationBO);
            lineStationBO.StationName = dl.GetStation(lineStationDO.StationCode).Name;
            Random random = new Random();
            lineStationBO.DistanceFromLastStation = random.Next(500) + 100;
            lineStationBO.TimeFromLastStation = new TimeSpan(00, random.Next(3), random.Next(60));
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
        public void AddAdjacentStations(AdjacentStations adjacentStations)
        {
            DO.AdjacentStations AdjDo = new DO.AdjacentStations();
            adjacentStations.CopyPropertiesTo(AdjDo);
            try
            {
                dl.AddAdjacentStations(AdjDo);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("Those Adjacents stations already exist", ex);
            }
        }
        public double GetDistanceTo(Station s1, Station s2)          // gives the bird's-eye distance between two stations
        {
            return Math.Sqrt(Math.Pow(s1.Longitude - s2.Longitude, 2) + Math.Pow(s1.Latitude - s2.Latitude, 2));
        }
        #endregion
        #region LineTrip
        public void AddLineTrip(LineTrip lineTrip)
        {
            try
            {
                dl.GetLineTrip(lineTrip.Id,lineTrip.StartAt);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BO.BadLineTripIdException("This line trip doesn't exist", ex);
            }
            DO.LineTrip lineTripDO = new DO.LineTrip();
            lineTripDO.CopyPropertiesTo(lineTrip);
            dl.AddLineTrip(lineTripDO);
        }
        public void DeleteLineTrip(LineTrip lineTrip)
        {
            try
            {
                dl.DeleteLineTrip(lineTrip.Id, lineTrip.StartAt);
                                                                                                                                                                                                                                                                                                            
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BO.BadLineTripIdException("This line trip does not exist", ex);
            }

        }
        public IEnumerable<LineTrip> GetAllLineTrip()
        {
            return from item in dl.GetAllLineTrip()
                   select LineTripDoBoAdapter(item);
        }
        public void UpdateLineTrip(LineTrip lineTrip)
        {
            DO.LineTrip lineTripDO = new DO.LineTrip();
            lineTrip.CopyPropertiesTo(lineTripDO);
            try
            {
                dl.UpdateLineTrip(lineTripDO);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BO.BadLineTripIdException("This line trip doesn't exist", ex);
            }


        }
        public LineTrip GetLineTrip(int id, TimeSpan now)
        {
            DO.LineTrip lineTripDO;
            try
            {
                lineTripDO = dl.GetLineTrip(id,now);
            }
            catch (DO.BadStationIdException ex)
            {
                throw new BO.BadStationIdException("The code of the station does not exist", ex);
            }
            return LineTripDoBoAdapter(lineTripDO);
        }
        public IEnumerable<LineTrip> GetAllLineTripBy(Predicate<LineTrip> predicate)
        {
            if (predicate != null)
            {
                return from lineTrip in dl.GetAllLineTripBy((Predicate<DO.LineTrip>)predicate)
                       select LineTripDoBoAdapter(lineTrip);
            }
            else
            {
                return GetAllLineTrip();
            }
        }
        public BO.LineTrip LineTripDoBoAdapter(DO.LineTrip DoLineTrip)
        {
            BO.LineTrip lineTripBO = new BO.LineTrip();
            DO.Line lineDO;
            int id = DoLineTrip.Id;
            try
            {
                lineDO = dl.GetLine(id);
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BO.BadLineTripIdException("Line Trip ID is illegal", ex);
            }
            lineDO.CopyPropertiesTo(lineTripBO);
            DoLineTrip.CopyPropertiesTo(lineTripBO);
            return lineTripBO;

        }
        #endregion
        #region others
        public IEnumerable<LineTiming> NextBusesInAStation(BL.BO.Station station, TimeSpan hour)
        //this method return ienumerable of line timing of the next buses of all the lines which will go soon though this station 
        {
            try
            {
                List<LineTiming> nextBusesList = new List<LineTiming>();
                foreach (var oneLine in GetAllLineInStation(station))
                {
                    foreach (var item in NextBusesOfOneLineInAStation(oneLine.Code, hour, station.Code))
                        nextBusesList.Add(item);
                }
                return nextBusesList;
            }
            catch (DO.BadLineTripIdException ex)
            {
                throw new BO.BadLineTripIdException("There is any trip during these hours for the requested line", ex);
            }
        }
        public IEnumerable<LineTiming> NextBusesOfOneLineInAStation(int lineCode, TimeSpan hour, int stationKey) 
            //this method return ienumerable of line timing of the next buses OF ONE LINE which will go soon though this station 
        {
            Line line = GetLine(lineCode);
            DO.LineTrip myLineTrip = dl.GetLineTrip(lineCode, hour);
            TimeSpan travelTime = TravelTime(line, stationKey);             //Calcul of TravelTime between first station of line and our station
            List<LineTiming> listTiming = new List<LineTiming>();           //initialize list of all timing for the specified line
            while (myLineTrip.StartAt + travelTime < hour)
                myLineTrip.StartAt += myLineTrip.Frequency;                 //we change the value of the start time because we only want the futur buses 
            for (TimeSpan i = myLineTrip.StartAt; i <= hour; i += myLineTrip.Frequency )
            {
                listTiming.Add(new LineTiming
                {  
                    LineCode = myLineTrip.LineId,
                    LastStation = line.ListOfStations.Last().StationName,
                    TripStart = i,
                    ExpectedTimeTillArrive = i + travelTime,
                }
                ) ;           
            }
            if (stationKey == line.ListOfStations.First().StationCode)        //if station is the first we want to show 5 nexts departures
            {
                for (int j = 0; j < 5; j ++)
                {
                    listTiming.Add(new LineTiming
                    {
                        LineCode = myLineTrip.LineId,
                        LastStation = line.ListOfStations.Last().StationName,
                        TripStart = myLineTrip.StartAt,
                        ExpectedTimeTillArrive = myLineTrip.StartAt
                    });
                    myLineTrip.StartAt += myLineTrip.Frequency;
                }
            }
            return listTiming;
        }
        public TimeSpan TravelTime(Line line, int stationKey)        //Calculate time between first station of line and our station
        {
            int indexOfStation = dl.GetLineStation(line.Code, stationKey).LineStationIndex;

            //we will get in "stations" all the LineStations which are before this LineStation on the line
            IEnumerable<DO.LineStation> stations = (from lineStat in dl.GetAllLineStationBy(l => l.LineCode == line.Code).ToList()
                                                    where lineStat.LineStationIndex <= indexOfStation
                                                    select lineStat).ToList();

            TimeSpan travelDuration = new TimeSpan();
            for (int i = 0; i < stations.Count() - 1; i++)
            {
                //calculates total time from the first station to this station
                travelDuration += dl.GetAdjacentStations(stations.ElementAt(i).StationCode, stations.ElementAt(i + 1).StationCode).Time;
            }
            return travelDuration;
        }
        #endregion
    }
}


