using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DO
{//pr l instant enlevee, a voir si on arrive a le fr marcher
    public static class Static
    {
       public static int LineIdCounter { get; set; } = 0;
       public static int BusOnTripIdCounter { get; set; } = 0;
        public static int LineTripIdCounter { get; set; } = 0;
    }
}

