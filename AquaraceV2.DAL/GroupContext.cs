using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using AquaraceV2.Models;

namespace AquaraceV2.DAL
{
    public class GroupContext : SqlContext
    {
        public void Create(string group_name, bool is_private)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@group_name", group_name));
            parameters.Add(new SqlParameter("@is_private", is_private));

            ExecuteInsertProcedure("create_group", parameters);
        }

        //TODO
        public Group GetGroupByID(int group_id)
        {
            return null;
        }

        public void Delete(int group_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@group_id", group_id));

            ExecuteInsertProcedure("delete_group", parameters);
        }

        //TODO
        public void AddPlayer(int group_id, string user_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@group_id", group_id));
            parameters.Add(new SqlParameter("@user_id", user_id));

            ExecuteInsertProcedure("add_player_to_group", parameters);
        }

        //TODO
        public Dictionary<int, string> GetAllMembersOfGroup(int group_id)
        {
            Dictionary<int, string> players = new Dictionary<int, string>();

            players.Add(1, "Max Verstappen");
            players.Add(3, "Racer #1245");
            players.Add(7, "Test2");

            return players;
        }

        //TODO REMOVE?!
        public List<int> GetMemberIDs(int group_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@group_id", group_id));

            string[] return_columns = { "player_id" };

            List<int> return_objects = new List<int>();
            try
            {
                foreach (object member_id in ExecuteSelectProcedure("get_members", parameters, 1, return_columns))
                    {
                        try
                        {
                            return_objects.Add((int)member_id);
                        }
                        catch(InvalidCastException e)
                        {
                            Console.Write(e.ToString());
                        }
                    }
            }
            catch(NullReferenceException e)
            {
                Console.Write(e.ToString());
            }


            return return_objects;
        }

        //TODO REMOVE?!
        public string GetMemberName(int player_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@player_id", player_id));
            string[] return_columns = { "username" };
            string return_object = "";
            try
            {
                foreach (object member_name in ExecuteSelectProcedure("get_player_name", parameters, 1, return_columns))
                {
                    try
                    {
                        return_object = member_name.ToString();
                    }
                    catch (InvalidCastException e)
                    {
                        Console.Write(e.ToString());
                    }
                    catch (ArgumentOutOfRangeException e)
                    {
                        Console.Write(e.ToString());
                    }
                }
            }
            catch (NullReferenceException e)
            {
                Console.Write(e.ToString());
            }
            return return_object;
        }
    }
}
