using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class GuessedDriver : Driver
    {
        public Player Player { get; private set; }
        
        public GuessedDriver(int id, string name, decimal paycheck, Team team, Player player) : base(id, name, paycheck, team)
        {
            Player = player;
        }
    }
}
