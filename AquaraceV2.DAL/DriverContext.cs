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
            string[] return_columns = { "driver_id", "driver_name", "paycheck", "team_id", "team_name"};
            ArrayList driver_objects = ExecuteSelectProcedure("get_driver", parameters, 5, return_columns);
            //foreach (object ob in driver_objects)
            //{
            //    Console.WriteLine(ob.ToString());

            //}
            //Console.ReadLine();
            int driverid = (int)driver_objects[0];
            string driver_name = driver_objects[1].ToString();
            decimal paycheck = (decimal)driver_objects[2];
            int team_id = (int)driver_objects[3];
            string team_name = driver_objects[4].ToString();

            return new Driver(driverid, driver_name, paycheck, team_id, team_name);
            return null;
        }

    }
}
