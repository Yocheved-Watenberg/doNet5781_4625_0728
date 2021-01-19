using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DO;

namespace BL.BO
{
    public static class Static
    {
        //public static int LineIdCounterBO { get; set; } = DAL.DO.Static.LineIdCounter;
        public static int GetLineIdCounterDO()                // function to get the LineIdCounter of the DO(which will be used in the PL)
        {
            return ++DAL.DO.Static.LineIdCounter;
        }

    }
}
