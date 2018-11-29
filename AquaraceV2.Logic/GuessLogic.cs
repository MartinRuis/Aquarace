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
            GroupContext grc = new GroupContext();
            decimal total_cost = 0;

            int[] driver_ids = { };
            int i = 0;
            foreach (Driver driver in drivers)
            {
                total_cost += driver.Paycheck;
                driver_ids[i] = driver.ID;
                i++;
            }

            if (total_cost <= wallet)
            {
                if (!check_guessed(grc.GetMemberIDs(group_id), driver_ids, player_id))
                {

                    return;
                }

                foreach (Driver driver in drivers)
                {
                    gc.Create(race_id, player_id, driver.ID, group_id);
                }
            }
        }

        public bool check_guessed(List<int> member_ids, int[] chosen_drivers_ids, int self_id, int race_id, int group_id)
        {
            GuessContext gc = new GuessContext();
            foreach (int id in member_ids)
            {
                if (id != self_id)
                {
                    List<int> other_driver_ids = gc.Check_Guess_Existence(id, race_id, group_id);
                    if (chosen_drivers_ids.Contains(other_driver_ids[0]) && 
                        chosen_drivers_ids.Contains(other_driver_ids[1]) && 
                        chosen_drivers_ids.Contains(other_driver_ids[2]) && 
                        chosen_drivers_ids.Contains(other_driver_ids[3]) && 
                        chosen_drivers_ids.Contains(other_driver_ids[4]))
                    {
                        return false;
                    }
                     
                }
                
            }

            return true;
        }
    }
}
