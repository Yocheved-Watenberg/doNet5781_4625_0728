using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dotNet5781_02_4625_0728
{
    class Program
    {
        static void Main(string[] args)
        {
            BusStation b = new BusStation(66551, 22, 24);
            Console.WriteLine(b.id);
            Console.WriteLine(b);
            Console.ReadLine();
        }
    }
}
