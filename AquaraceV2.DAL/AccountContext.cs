using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace AquaraceV2.DAL
{
    public class AccountContext : SqlContext
    {
        public void Create(string username, string password)
        {
            string salt = CreateSalt();
            string hashed_password = GenerateHash(password, salt);

            List<SqlParameter> parameters = new List<SqlParameter>();

            parameters.Add(new SqlParameter("@username", username));
            parameters.Add(new SqlParameter("@password", hashed_password));
            parameters.Add(new SqlParameter("@is_admin", 0));
            parameters.Add(new SqlParameter("@salt", salt));

            ExecuteInsertProcedure("create_account", parameters);
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
