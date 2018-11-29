using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace AquaraceV2.DAL
{
    public class GuessContext : SqlContext
    {
        public void Create(int race_id, int player_id, int driver_id, int group_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@race_id", race_id));
            parameters.Add(new SqlParameter("@player_id", player_id));
            parameters.Add(new SqlParameter("@driver_id", driver_id));
            parameters.Add(new SqlParameter("@group_id", group_id));

            ExecuteInsertProcedure("create_guess", parameters);
        }

        public void Create_Verstappen_Placement(int race_id, int player_id, int group_id, int placement_guess)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@race_id", race_id));
            parameters.Add(new SqlParameter("@player_id", player_id));
            parameters.Add(new SqlParameter("@group_id", group_id));
            parameters.Add(new SqlParameter("@placement_guess", placement_guess));

            ExecuteInsertProcedure("create_verstappen_placement", parameters);
        }

        public List<int> Check_Guess_Existence(int player_id, int group_id, int race_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@player_id", player_id));
            parameters.Add(new SqlParameter("@group_id", group_id));
            parameters.Add(new SqlParameter("@race_id", race_id));
            string[] x = { "driver_id", };
            List<object> o = ExecuteSelectProcedure("check_guess_existence", parameters, 1, x);
            List<int> returnobject = new List<int>();
            foreach (object ob in o)
            {
                returnobject.Add((int)ob);
            }
            return returnobject;
        }
    }
}
