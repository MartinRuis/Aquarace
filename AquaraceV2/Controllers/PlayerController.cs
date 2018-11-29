﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AquaraceV2.Models;
using AquaraceV2.Logic;

namespace AquaraceV2.Controllers
{
    public class PlayerController : Controller
    {

        //Let user login. returns cookie with userID.
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(Player PlayerModel)
        {
            PlayerLogic playerlogic = new PlayerLogic();

            playerlogic.validatePlayerModel(PlayerModel);
            
            Session["UserName"] = PlayerModel.UserName;
            //id moet ergensanders?
            return RedirectToAction("Index", "Home");
        

            ViewBag.Message = "username/password combination not found!";
            return View();
        }

        public ActionResult CreateAccount()
        {
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(Player PlayerModel, string password)
        {
            PlayerLogic playerlogic = new PlayerLogic();
            //check of username niet al bestaat!
            playerlogic.createAccount(PlayerModel);


            return RedirectToAction("Login", "Player");
        }        
    }
}