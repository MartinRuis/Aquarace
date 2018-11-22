using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class User
    {
        public int player_id { get; private set; }
        public string username { get; private set; }
        public bool is_admin { get; private set; }

        public User(int player_id, string username, bool is_admin)
        {
            this.player_id = player_id;
            this.username = username;
            this.is_admin = is_admin;
        }

        public User(int player_id)
        {
            this.player_id = player_id;
        }
    }
}
