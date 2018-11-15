using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.DAL;

namespace AquaraceV2.RunTest
{
    public class Program
    {
        static void Main(string[] args)
        {
            DriverContext dc = new DriverContext();

            Console.WriteLine(dc.GetDriver(5));
        }
    }
}
