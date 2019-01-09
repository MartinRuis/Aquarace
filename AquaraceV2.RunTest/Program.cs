using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.DAL;
using AquaraceV2.Logic;
using AquaraceV2.Models;

namespace AquaraceV2.RunTest
{
    public class Program
    {

        public void ImplementInput(string input)
        {
            DriverContext dc = new DriverContext();
            switch (input)
            {
                case ">GetDriver":
                    Console.WriteLine("Give driver id:");
                    int nr = 0;
                    ConsoleKeyInfo key = Console.ReadKey();
                    Console.WriteLine();
                    if (char.IsDigit(key.KeyChar))
                    {
                        nr = int.Parse(key.KeyChar.ToString()); // use Parse if it's a Digit
                    }
                    Console.WriteLine(dc.GetDriver(nr));
                    break;

            }
        }

        static void Main(string[] args)
        {
            Program p = new Program();
            GuessLogic gl = new GuessLogic();
            Race race = new Race() { Drivers{ new Driver()} };
            
            gl.Create()
            Console.WriteLine(gc.GetGroupId("Test"));
            Console.ReadKey();
        }

        
    }
}
