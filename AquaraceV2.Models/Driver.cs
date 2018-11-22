using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Driver
    {
        public int ID { get; private set; }
        public string Name { get; private set; }
        public decimal Paycheck { get; private set; }
        public Team DriversTeam { get; private set; }

        public Driver(int id, string name, decimal paycheck, Team team)
        {
            ID = id;
            Name = name;
            Paycheck = paycheck;
            DriversTeam = team;
        }

        public override string ToString()
        {
            return Name + ", " + DriversTeam.Name;
        }
    }
}
