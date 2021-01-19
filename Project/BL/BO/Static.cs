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
        public static int LineIdCounterBO { get; set; } = DAL.DO.Static.LineIdCounter;
        
    }
}
