using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class GuessedDrivers : Driver
    {
        public Player Player { get; private set; }
        
        public GuessedDrivers(int id, string name, decimal paycheck, Team team, Player player) : base(id, name, paycheck, team)
        {
            Player = player;
        }
    }
}
