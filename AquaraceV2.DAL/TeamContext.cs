using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using AquaraceV2.Models;

namespace AquaraceV2.DAL
{
    public class TeamContext : SqlContext
    {
        public Team GetTeam(int driver_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@driver_id", driver_id));

            string[] return_columns = { "team_id", "team_name" };

            List<object> team_objects = ExecuteSelectProcedure("get_team", parameters, 2, return_columns);

            return new Team((int)team_objects[0], team_objects[1].ToString());
        }
    }
}
