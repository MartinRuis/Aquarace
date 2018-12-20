﻿using System;
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

        public ActionResult ViewPublicGroups(string message)
        {
            List<Group> PublicGroups;
            PublicGroups = groupLogic.GetPublicGroups();

            if (!String.IsNullOrEmpty(message))
                ViewBag.message = message;

            return View(PublicGroups);
        }

        public ActionResult GroupDetails(int id)
        {
            if (Session["Username"] != null)
            {
                PlayerLogic playerLogic = new PlayerLogic();
                var listUsernames = playerLogic.GetAddPlayerName(id);
                ViewBag.Usernames = listUsernames; 

                return View(groupLogic.GetGroupDetails(id));
            }
            return RedirectToAction("Login", "Player");
        }

        public ActionResult AddPlayerToGroup(int? id, string username)
        {
            bool completed = false;

            if(String.IsNullOrEmpty(username))
            {
                completed = groupLogic.AddPlayerToGroup((int)id, Session["Username"].ToString());
                
            }
            else
            {
                completed = groupLogic.AddPlayerToGroup((int)id, username);
            }

            return completed ? RedirectToAction("GroupDetails", "Group", new{id = id}) : RedirectToAction("ViewPublicGroups", "Group", new{message = "Something went wrong. Please try again later."});
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