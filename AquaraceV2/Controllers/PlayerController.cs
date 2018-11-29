using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AquaraceV2.Controllers
{
    public class PlayerController : Controller
    {

        //Let user login. returns cookie with userID.
        public ActionResult Login()
        {
            return null;
        }

        // GET: Player
        public ActionResult Index()
        {
            return View();
        }
    }
}