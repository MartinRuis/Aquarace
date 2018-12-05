using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;
using AquaraceV2.Models;

namespace AquaraceV2.DAL
{
    public class AccountContext : SqlContext
    {
        public bool Create(Player player)
        {
            string salt = CreateSalt();
            string hashed_password = GenerateHash(player.Password, salt);
            //help
            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@username", player.UserName));
            parameters.Add(new SqlParameter("@hashed_password", hashed_password));
            parameters.Add(new SqlParameter("@is_admin", false));
            parameters.Add(new SqlParameter("@salt", salt));
            try
            {
                if (DoesPlayerExist(player))
                {
                    return false;
                }
                else
                {
                    ExecuteInsertProcedure("create_account", parameters);
                }
                
                return true;
            }
            catch (Exception e)
            {
                return false;
            }
            
        }

        public bool DoesPlayerExist(Player player)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", player.UserName));
            try
            {
                if ((int)ExecuteSelectProcedure("check_player_existence", parameters, 1, new string[] { "" })[0] >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool CheckLogin(Player player)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@username", player.UserName));
            string salt;
            try
            {
                salt = ExecuteSelectProcedure("get_salt_from_player", parameters, 1, new string[] {"salt"})[0]
                    .ToString();
            }
            catch (Exception e)
            {
                return false;
            }
            parameters = new List<SqlParameter>();
            string hash = GenerateHash(player.Password, salt);
            parameters.Add(new SqlParameter("@username", player.UserName));
            parameters.Add(new SqlParameter("@hashed_password", hash));
            try
            {
                if (ExecuteSelectProcedure("check_login", parameters, 1, new string[] { "" })[0].ToString() == "1")
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                return false;
            }
            return false;
        }


        //TODO
        public Player GetPlayerByUsername(string username)
        {
            List<object> values = ExecuteSelectProcedure("get_player_by_username", new List<SqlParameter> { new SqlParameter("@username", username) }, 1, new string[] { "player_id" });
            return new Player() { ID = (int)values[0], UserName = username };
        }

        public Player GetPlayerByID(int id)
        {
            
            List<object> values = ExecuteSelectProcedure("get_player_by_id", new List<SqlParameter> { new SqlParameter("@player_id", id) }, 1, new string[] { "user_name" });
            return new Player() { ID = id, UserName = values[0].ToString() };
        }

        public List<string> GetAllPlayers()
        {
            //Todo      Ik wil een lijst van alle gebruikers terug krijgen
            return null;
        }

        public string CreateSalt()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] data = new byte[4];

                for (int i = 0; i < 10; i++)
                {
                    rng.GetBytes(data);

                    int value = BitConverter.ToInt32(data, 0);
                    rng.Dispose();
                    return value.ToString();
                }
            }
            return "";
        }

        public string GenerateHash(string password, string salt)
        {
            SHA256 sha256 = SHA256.Create();
            byte[] bytes = Encoding.UTF8.GetBytes(password + salt);
            byte[] hash = sha256.ComputeHash(bytes);
            return Convert.ToBase64String(bytes);
        }
    }
}
