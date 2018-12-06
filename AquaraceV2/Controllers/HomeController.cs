using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AquaraceV2.Logic;

namespace AquaraceV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            PlayerLogic playerLogic = new PlayerLogic();
            Session["UserID"] = playerLogic.GetUserID((string)Session["UserName"]);
            if (Session["Username"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Player");
        }

        

        public ActionResult About()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Player");
        }

        public ActionResult Contact()
        {
            if (Session["Username"] != null)
            {
                return View();
            }
            return RedirectToAction("Login", "Player");
        }
    }
}