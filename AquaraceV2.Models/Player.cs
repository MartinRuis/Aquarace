using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Models
{
    public class Player
    {
        private int iD;
        private string userName;
        private string password;
        private decimal wallet = 0;

        public int ID { get => iD; set => iD = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
        public decimal Wallet { get => wallet; set => wallet = value; }
    }
}
