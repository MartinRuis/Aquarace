using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.DAL;
using AquaraceV2.Models;

namespace AquaraceV2.Logic
{
    public class GuessLogic
    {
        public List<Driver> AvailableDrivers()
        {
            throw new NotImplementedException();
        }
        //NOT FINISHED
        public void Create(List<Driver> drivers, int race_id, decimal wallet, int group_id, int player_id)
        {
            GuessContext gc = new GuessContext();
            decimal total_cost = 0;

            foreach (Driver driver in drivers)
            {
                total_cost += driver.paycheck;
            }

            if (total_cost <= wallet)
            {
                check_guessed(group_id);

                foreach (Driver driver in drivers)
                {
                    gc.Create(race_id, player_id, driver.driver_id, group_id);
                }
            }
        }

        public bool check_guessed(int group_id)
        {
            throw new NotImplementedException();
        }
    }
}
