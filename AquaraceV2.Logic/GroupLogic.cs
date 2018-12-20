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

        public void CreateGroup(string groupname, string username, bool isprivated = false)
        {
            if (!String.IsNullOrEmpty(groupname))
            {
                context.Create(groupname, isprivated);
                AddPlayerToGroup(GetGroupId(groupname), username);
            }
        }

        public List<Group> GetAllGroups()
        {
            List<Group> groups = new List<Group>();

            context.GetPublicGroups().ForEach(i => groups.Add(context.GetGroupByID(i)));
            
            return groups;
        }

        public List<int> GetGroupIdsFromPlayer(int player_id)
        {
            return context.GetGroupIdsFromPlayer(player_id);
        }

        public Group GetGroupDetails(int id)
        {
            return context.GetGroupByID(id);
        }

        public int GetGroupId(string groupname)
        {
            GroupContext gc = new GroupContext();
            return gc.GetGroupID(groupname);
        }

        public bool AddPlayerToGroup(int groupid, string username)
        {
            AccountContext accountContext = new AccountContext();
            Player existingPlayer = accountContext.GetPlayerByUsername(username);

            if (existingPlayer != null && !context.IsPlayerInGroup(existingPlayer.ID, groupid))
            {
                context.AddPlayer(groupid, existingPlayer.ID);
                return true;
            }

            return false;
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

        public List<Group> GetPublicGroups()
        {
            GroupContext gc = new GroupContext();
            List<Group> return_values = new List<Group>();
            foreach (int id in gc.GetPublicGroups())
            {
                return_values.Add(gc.GetGroupByID(id));
            }
            return return_values;
        }


        public bool DoesGroupNameExists(string groupName)
        {
            if (context.DoesGroupNameExists(groupName))
            {
                return true;
            }

            return false;
        }
        
    }
}
