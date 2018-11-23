using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    class GuessedDrivers : Driver
    {
        

        public GuessedDrivers(int id, string name, decimal paycheck, Team team) : base(id, name, paycheck, team)
        {

        }
    }
}
