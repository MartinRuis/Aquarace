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

            GroupLogic groupLogic = new GroupLogic();
            groupLogic.CreateGroup(group.Title, group.IsPrivate);
            groupLogic.AddPlayerToGroup(groupLogic.GetGroupId(group.Title), (string)Session["UserName"]);
            return RedirectToAction("Index", "Home");
        }

        public ActionResult GroupDetails()
        {
            if (Session["Username"] != null)
            {
                Group group = new Group("test");
                Player player = new Player();
                player.UserName = "Jeroen de Bakker";
                List<Player> playrList = new List<Player>();
                playrList.Add(player);
                group.AddOneOrMultiplePlayers(playrList);
                return View(group);
            }
            return RedirectToAction("Login", "Player");
        }
        public ActionResult AddPlayerToGroup()
        {
            return null;
        }

        public ActionResult AddDriverToGroup()
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