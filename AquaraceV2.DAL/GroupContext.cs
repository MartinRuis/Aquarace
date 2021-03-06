﻿using System;
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

        //TODO      Alleen non privated groups 
        public List<Group> GetAllGroups()
        {
            return null;
        }

        //TODO      PAS OP! functie gaat niet werken voordat GetAllMembersOfGroup(int group_id) gefixed is.
        public Group GetGroupByID(int group_id)
        {
            string title = "DefaultTitle";
            bool privacy = false;
            int maxAmountOfPlayers = 5;

            List<SqlParameter> parameters = new List<SqlParameter>();
            List<Player> players = new List<Player>();

            parameters.Add(new SqlParameter("@group_id", group_id));

            List<object> values = ExecuteSelectProcedure("get_group_by_id", parameters, 3, new string[] { "group_name", "is_private", "max_player_amount" });
            try
            {
                Group group = new Group(values[0].ToString(), (bool)values[1], (int)values[2]);
                group.SetGroupID(group_id);
                foreach (Player player in GetAllMembersOfGroup(group_id))
                {
                    players.Add(new Player { ID = player.ID, UserName = player.UserName });
                }
                group.AddOneOrMultiplePlayers(players);

                //TODO      Add GetAllMembersOfGroup()!!!!!~!1!!!
                return group;
            }
            catch (Exception e)
            {
                //todo
                return null;
            }
        }

        public List<int> GetPublicGroups()
        {
            List<int> values = new List<int>();
            try
            {
                foreach (object item in ExecuteSelectProcedure("get_all_public_groups", new List<SqlParameter>(), 1, new string[] { "group_id" }))
                {
                    values.Add((int)item);
                }
                return values;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public List<int> GetGroupIdsFromPlayer(int player_id)
        {
            try
            {
                List<int> group_ids = new List<int>();
                List<object> values = ExecuteSelectProcedure("get_groups_from_player", new List<SqlParameter> { new SqlParameter("@player_id", player_id) }, 1, new string[] { "group_id" });
                if (values != null)
                {
                    foreach (object value in values)
                    {
                        group_ids.Add((int)value);
                    }
                    return group_ids;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public void Delete(int group_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@group_id", group_id));

            ExecuteInsertProcedure("delete_group", parameters);
        }

        public void AddPlayer(int group_id, int user_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@group_id", group_id));
            parameters.Add(new SqlParameter("@player_id", user_id));

            ExecuteInsertProcedure("add_player_to_group", parameters);
        }

        public bool RemovePlayer(int group_id, int user_id)
        {
            if (IsPlayerInGroup(user_id, group_id))
            {
                ExecuteInsertProcedure("remove_player_from_group", new List<SqlParameter> { new SqlParameter("@player_id", user_id), new SqlParameter("@group_id", group_id) });
                return true;
            } else
            {
                return false;
            }
        }

        public bool IsPlayerInGroup(int user_id, int group_id)
        {
            List<object> value = ExecuteSelectProcedure("is_player_in_group", new List<SqlParameter> { new SqlParameter("@user_id", user_id), new SqlParameter("@group_id", group_id) }, 1, new string[] { "" });

            return (int)value[0] == 1 ? true : false;
        }

        public int GetGroupID(string groupname)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@group_name", groupname));
            List<object> values = ExecuteSelectProcedure("get_group_by_name", parameters, 1, new string[] { "group_id" });
            return (int)values[0];
        }

        //TODO
        public List<Player> GetAllMembersOfGroup(int group_id)
        {
            List<Player> players = new List<Player>();
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@group_id", group_id));
            List<object> values = ExecuteSelectProcedure("get_members", parameters, 2, new string[] { "player_id", "username" });

            while (values.Count > 0)
            {
                Player player = new Player();
                player.ID = (int)values[0];
                player.UserName = (string)values[1];
                values.Remove(values[1]);
                values.Remove(values[0]);
                players.Add(player);
            }
            return players;
        }

        //TODO
        private List<GuessedDriver> GetGuessedDrivers(int group_id)
        {
            List<GuessedDriver> drivers = new List<GuessedDriver>();

            return drivers;
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
                    catch (InvalidCastException e)
                    {
                        Console.Write(e.ToString());
                    }
                }
            }
            catch (NullReferenceException e)
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

        //TODO - sql procedures
        public bool DoesGroupNameExists(string groupname)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@group_name", groupname));

            List<object> values = ExecuteSelectProcedure("check_group_existence", parameters, 1, new string[] { "" });
            return (bool)values[0];
        }
    }
}
