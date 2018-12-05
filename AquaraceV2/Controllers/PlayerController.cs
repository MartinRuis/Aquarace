using System;
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
            Session["UserName"] = null;
            return View();

        }
        [HttpPost]
        public ActionResult Login(Player PlayerModel)
        {
            PlayerLogic playerlogic = new PlayerLogic();

            if (playerlogic.validatePlayerModel(PlayerModel))
            {
                Session["UserName"] = PlayerModel.UserName;
                //id moet ergensanders?
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "error!";
            return View(PlayerModel);
        }
            
           
            
        

        public ActionResult CreateAccount()
        {
            Session["UserName"] = null;
            return View();
        }
        [HttpPost]
        public ActionResult CreateAccount(Player PlayerModel)
        {
            PlayerLogic playerlogic = new PlayerLogic();
            //check of username niet al bestaat!
            if (playerlogic.createAccount(PlayerModel))
            {
                return RedirectToAction("Login", "Player");
            }

            ViewBag.Message = "Error";
            return View();


        }        
    }
}