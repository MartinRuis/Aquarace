using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AquaraceV2.Logic;

namespace AquaraceV2.Controllers
{
    public class CalendarController : Controller
    {
        // GET: Calendar
        public ActionResult Calendar()
        {
            if (Session["Username"] != null)
            {
                CalendarLogic logic = new CalendarLogic();
                return View(logic.GetRaceCalendar());
            }
            return RedirectToAction("Login", "Player");
            
        }
    }
}