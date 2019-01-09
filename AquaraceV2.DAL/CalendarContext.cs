using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using  AquaraceV2.Models;

namespace AquaraceV2.DAL
{
    public class CalendarContext : SqlContext
    {
        public List<Models.Calendar> GetAllRaces()
        {
            try
            {
                List<Models.Calendar> results = new List<Models.Calendar>();
                List<object> values = ExecuteSelectProcedure("get_race_calendar", new List<SqlParameter>(), 4, new string[] { "race_id", "race_location", "fastest_round_driver_id", "date_of_race" });
                if (values != null)
                {
                    while(values.Count != 0)
                    {
                        Models.Calendar nc = new Models.Calendar();
                        nc.RaceID = (int)values[0];
                        nc.RaceLocation = (string)values[1];
                        nc.FastestRoundDriverId = (int)values[2];
                        nc.DateOfRace = (DateTime)values[3];


                        values.RemoveAt(0);

                        values.RemoveAt(0);

                        values.RemoveAt(0);

                        values.RemoveAt(0);


                        results.Add(nc);
                        
                    }
                    return results;
                }
                return null;
            }
            catch (Exception e)
            {
                return null;
            }
        }
    }
}
