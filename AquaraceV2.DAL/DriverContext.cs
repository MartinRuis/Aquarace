using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.Models;
using System.Data.SqlClient;
using System.Collections;

namespace AquaraceV2.DAL
{
    public class DriverContext : SqlContext
    {
        public Driver GetDriver(int driver_id)
        {
            List<SqlParameter> parameters = new List<SqlParameter>();
            parameters.Add(new SqlParameter("@driver_id", driver_id));

            //TODO      team_id and team_name needs to be removed from the SP.
            string[] return_columns = { "driver_id", "driver_name", "paycheck", "team_id", "team_name"};

            List<object> driver_objects = ExecuteSelectProcedure("get_driver", parameters, 5, return_columns);

            return new Driver((int)driver_objects[0], driver_objects[1].ToString(), decimal.Parse(driver_objects[2].ToString()), getTeam((int)driver_objects[0]));
        }

        private Team getTeam(int driverID)
        {
            return null;
        }

    }
}
