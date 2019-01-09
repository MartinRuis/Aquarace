using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AquaraceV2.DAL;

namespace AquaraceV2.Logic
{
    public class CalendarLogic
    {
        public List<Models.Calendar> GetRaceCalendar()
        {
            CalendarContext context = new CalendarContext();
            return context.GetAllRaces();
        }
    }
}
