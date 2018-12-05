using AquaraceV2.DAL;
using AquaraceV2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquaraceV2.Logic
{
    public class GroupLogic
    {
        GroupContext context = new GroupContext();

        public void CreateGroup(string groupname, bool isprivated = false)
        {
            if (!String.IsNullOrEmpty(groupname))
            {
                context.Create(groupname, isprivated);
            }
        }

        public void AddPlayerToGroup(int groupid, string username)
        {
            AccountContext accountContext = new AccountContext();
            Player existingPlayer = accountContext.GetPlayerByUsername(username);

            if (existingPlayer != null && GetAllMembersofGroup(groupid).Any(m => m.UserName == username))
            {
                context.AddPlayer(groupid, username);
            } 
        }

        public void AddDriverToGroup(int groupid, int playerid, Driver driver)
        {
            DriverContext driverContext = new DriverContext();
            AccountContext accountContext = new AccountContext();
            Group existingGroup = context.GetGroupByID(groupid);

            Driver existingDriver = driverContext.GetDriver(driver.ID);
            Player existingPlayer = accountContext.GetPlayerByID(playerid);

            //Bestaat de group, driver en player
            if (existingGroup != null && existingDriver !=  null && existingPlayer != null)
            {
                //Bestaat de opgegeven driver niet al bestaat in de group
                //Heeft de player niet al een driver van het zelfde team in de groep staan
            }
        }

        public List<Player> GetAllMembersofGroup(int groupid)
        {
            List<Player> members = new List<Player>();
            Group existingGroup = context.GetGroupByID(groupid);

            if (existingGroup != null)
            {
                foreach (KeyValuePair<int, string> member in context.GetAllMembersOfGroup(groupid))
                {
                    members.Add(new Player(){ID = member.Key, UserName = member.Value});
                }
            }

            return members;
        }

        public bool DoesGroupNameExists(string groupName)
        {
            if (context.DoesGroupTitleExists(groupName))
            {
                return true;
            }

            return false;
        }
        

    }
}
