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
        public void Create(Player player)
        {
            string salt = CreateSalt();
            string hashed_password = GenerateHash(player.Password, salt);

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@username", player.UserName));
            parameters.Add(new SqlParameter("@password", hashed_password));
            parameters.Add(new SqlParameter("@is_admin", false));
            parameters.Add(new SqlParameter("@salt", salt));

            ExecuteInsertProcedure("create_account", parameters);
        }

        //TODO
        public Player GetPlayerByUsername(string username)
        {
            return null;
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
