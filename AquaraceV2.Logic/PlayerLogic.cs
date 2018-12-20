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

        public int GetUserID(string username)
        {
            AccountContext accountContext = new AccountContext();
            Player p = accountContext.GetPlayerByUsername(username);
            return p.ID;
        }

        /// <summary>
        /// Returns string Array with all the usernames registrated.
        /// If you send an groupid with it you'll get a list of all players except the once that are already in the group.
        /// </summary>
        /// <param name="groupid"></param>
        /// <returns></returns>
        public Array GetAddPlayerName(int? groupid)
        {
            AccountContext accountContext = new AccountContext();
            GroupContext groupContext = new GroupContext();

            if(groupid != null)
            {
                List<string> usernames = new List<string>();

                foreach (string username in accountContext.GetAllPlayers())
                {
                    if (!groupContext.IsPlayerInGroup(accountContext.GetPlayerByUsername(username).ID, (int)groupid))
                        usernames.Add(username);
                }

                return usernames.ToArray<string>();
            }
            else
            {
                return accountContext.GetAllPlayers().ToArray<string>();
            }
        }
    }
}
