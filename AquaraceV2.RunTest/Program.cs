using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.DAL;
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
            //while (true)
            //{
            //    Console.WriteLine("Give command:");
            //    string input = Console.ReadLine();
            //    p.ImplementInput(input);
            //}
            //GroupContext gc = new GroupContext();
            //foreach(int id in gc.GetMemberIDs(1))
            //{
            //    Console.Write(id);
            //    Console.WriteLine(gc.GetMemberName(id));
            //}
            //Console.ReadKey();
            AccountContext ac = new AccountContext();

            //ac.Create("Martin", "1234");
            Console.WriteLine(ac.Check_Login("Martin", "12345").ToString());
            Console.ReadKey();

            
        }

        
    }
}
