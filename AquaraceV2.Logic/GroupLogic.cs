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

            if (existingPlayer != null && GetAllMembersofGroup(groupid).Any(m => m.Username == username))
            {
                context.AddPlayer(groupid, username);
            } 
        }

        public List<Player> GetAllMembersofGroup(int groupID)
        {
            List<Player> members = new List<Player>();
            Group existingGroup = context.GetGroupByID(groupID);

            if (existingGroup != null)
            {
                foreach (KeyValuePair<int, string> member in context.GetAllMembersOfGroup(groupID))
                {
                    members.Add(new Player(member.Key, member.Value));
                }
            }

            return members;
        }

    }
}
