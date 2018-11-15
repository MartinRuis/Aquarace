using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Driver
    {
        public int driver_id { get; private set; }
        public string driver_name { get; private set; }
        public decimal paycheck { get; private set; }
        public int team_id { get; private set; }
        public string team_name { get; private set; }

        public Driver(int driver_id, string driver_name, decimal paycheck, int team_id, string team_name)
        {
            this.driver_id = driver_id;
            this.driver_name = driver_name;
            this.paycheck = paycheck;
            this.team_id = team_id;
            this.team_name = team_name;
        }

        public override string ToString()
        {
            return driver_name + ", " + team_name;
        }
    }
}
