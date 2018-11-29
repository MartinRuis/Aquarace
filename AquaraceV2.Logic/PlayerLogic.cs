using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.DAL;
using AquaraceV2.Models;

namespace AquaraceV2.Logic
{
    public class PlayerLogic
    {
        public bool validatePlayerModel(Player playerModel)
        {
            AccountContext accountContext = new AccountContext();
            if (accountContext.CheckLogin(playerModel))
            {
                return true;
            }
            
            return false;
        }

        public bool createAccount(Player playerModel)
        {
            AccountContext accountContext = new AccountContext();

            if (accountContext.Create(playerModel))
            {
                return true;
            }

            return false;
        }
    }
}
