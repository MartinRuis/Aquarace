using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Player
    {
        public int ID { get; private set; }
        public string Username { get; private set; }

        public Player(int id, string username)
        {
            ID = id;
            Username = username;
        }
    }
}
