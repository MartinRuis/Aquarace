using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AquaraceV2.Logic;
using AquaraceV2.Models;

namespace AquaraceV2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            if (Session["Username"] != null)
            {
                PlayerLogic playerLogic = new PlayerLogic();
                Session["UserID"] = playerLogic.GetUserID((string)Session["UserName"]);

                GroupLogic groupLogic = new GroupLogic();
                List<Group> groups = new List<Group>();

                List<int> GroupsOfUser = groupLogic.GetGroupIdsFromPlayer((int)Session["UserID"]);
                foreach (int i in GroupsOfUser)
                {
                    groups.Add(groupLogic.GetGroupDetails(i));
                }

                ViewBag.groups = groups;
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