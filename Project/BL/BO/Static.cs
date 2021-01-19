using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DO;

namespace BL.BO
{
   public class Static
    {
       // public static int LineIdCounterBO { get; set; } = DAL.DO.Static.LineIdCounter;     
        public static int GetCounterDO()                // function to get the LineIdCounter of the DO(which will be used in the PL)
        {
            DAL.DO.Static.LineIdCounter++;
            return DAL.DO.Static.LineIdCounter;
        }
    }
}
