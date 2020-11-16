using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class MyList : IEnumerable  // IEnumerable<Line> ou  IEnumerable<MyList>
    {
       // MyList<Line>;
    }
   
     
    internal interface IEnumerable
    {
        IEnumerator<MyList> GetEnumerator();
    }
}
