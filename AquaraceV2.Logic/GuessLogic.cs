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
        public bool Create(Player player, Race race, int group_id, List<Driver> chosen_drivers, int max_placement)
        {
            if (chosen_drivers.Count() > 5)
            {
                return false;
            }
            if (!Check_Team(chosen_drivers))
            {
                return false;
            }
            if (!Check_Wallet(player.Wallet, chosen_drivers))
            {
                return false;
            }
        }

        public bool Check_Existence()
        {

        }

        public bool Check_Wallet(decimal wallet, List<Driver> drivers)
        {
            decimal cost = 0;
            foreach (Driver driver in drivers)
            {
                cost += driver.Paycheck;
            }
            if (cost > wallet)
            {
                return false;
            } else
            {
                return true;
            }
        }

        public bool Check_Team(List<Driver> drivers)
        {
            foreach (Driver driver in drivers)
            {
                foreach (Driver driver2 in drivers)
                {
                    if (driver.ID == driver2.ID)
                    {
                        break;
                    } else
                    {
                        if (driver.DriversTeam.ID == driver2.DriversTeam.ID)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
    }
}
