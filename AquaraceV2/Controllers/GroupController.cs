using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AquaraceV2.Logic;
using AquaraceV2.Models;
using AquaraceV2.ViewModel;

namespace AquaraceV2.Controllers
{
    public class GroupController : Controller
    {
        GroupLogic groupLogic = new GroupLogic();

        public ActionResult AddGroup()
        {
            if (Session["Username"] != null)
            {
                CreateGroupViewModel group = new CreateGroupViewModel();
                return View(group);
            }
            return RedirectToAction("Login", "Player");
        }

        [HttpPost]
        public ActionResult AddGroup(CreateGroupViewModel group)
        {
            groupLogic.CreateGroup(group.Title, (string)Session["UserName"], group.IsPrivate);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult ViewPublicGroups()
        {
            List<Group> PublicGroups;
            PublicGroups = groupLogic.GetPublicGroups();
            return View(PublicGroups);
        }

        public ActionResult GroupDetails(int id)
        {
            if (Session["Username"] != null)
            {
                return View(groupLogic.GetGroupDetails(id));
            }
            return RedirectToAction("Login", "Player");
        }

        public ActionResult AddPlayerToGroup(int groupid, string username)
        {
            bool completed = false;

            if(String.IsNullOrEmpty(username))
            {
                completed = groupLogic.AddPlayerToGroup(groupid, Session["Username"].ToString());
                
            }
            else
            {
                completed = groupLogic.AddPlayerToGroup(groupid, username);
            }

            //TODO          Iets terug sturen.
            return completed ? RedirectToAction("Login", "Player") : RedirectToAction("Login", "Player");
        }

        public ActionResult AddDriverToGroup()
        {
            //int groupid = 0;
            //int playerid = 0;
            //Driver driver = new Driver(0, "", 00, new Team(0, ""));
            
            //groupLogic.AddDriverToGroup(groupid, playerid, driver);

            return null;
        }

        public ActionResult RemovePlayerFromGroup()
        {
            return null;
        }

        public ActionResult RemoveDriverFromGroup()
        {
            return null;
        }

        // GET: Group
        public ActionResult Index()
        {
            return View();
        }
    }
}