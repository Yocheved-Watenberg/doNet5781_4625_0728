﻿using BL.BO;
using BLAPI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PL

//jme suis trompee c line timing
//entierement copier coller de tirtsa 
{
    class LineTiming
    {
        public int LineId { get; set; }
        public int LineNumber { get; set; }
        public string LastStation { get; set; }
        public TimeSpan TripStart { get; set; }
        public TimeSpan Timing { get; set; }
    }

    public class PL
    {
        static IBL bl = BLFactory.GetBL("1");

        internal IEnumerable<IGrouping<TimeSpan, LineTiming>> BoPoLineTimingAdapter
            (IEnumerable<IGrouping<TimeSpan, LineTiming>> listTiming, TimeSpan hour)
        {
            List<LineTiming> timing = new List<LineTiming>();
            foreach (var element in listTiming)
            {
                //foreach (var item in element)
                //{
                //    Line line = bl.GetLine(item.LineId);
                //    timing.Add(new LineTiming
                //    {
                //        LineId = item.LineId,
                //        LineNumber = line.Code,
                //        LastStation = bl.GetStation(line.LastStation).StationName,
                //        TripStart = item.TripStart,
                //        Timing = item.ExpectedTimeTillArrive - hour
                //    });
               // }
            }

            return from item in timing
                   group item by item.Timing;
        }
    }
}
