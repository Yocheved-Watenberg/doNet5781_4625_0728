using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace doNet5781_00_4625_0728
{

    partial class Program
    {
        static void Main(string[] args)
        {
            Welcome4625();
            Welcome0728();
            Console.ReadKey();
        }

        static partial void Welcome0728();

        private static void Welcome4625()
        {
            Console.Write("Enter your name: ");
            string userName;
            userName = Console.ReadLine();
            Console.WriteLine("{0}, welcome to my first console application", userName);
        }
    }
}
