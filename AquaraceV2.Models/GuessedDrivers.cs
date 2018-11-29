using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    class GuessedDrivers : Driver
    {
        public Player Player { get; private set; }

        public GuessedDrivers(string name, decimal paycheck, Team team) : base(id, name, paycheck, team)
        {
            
        }
    }
}
