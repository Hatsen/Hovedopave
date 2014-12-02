﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Owin;
using BirkealleWebsite.Models;

namespace BirkealleWebsite.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> GetLoginDetails(string username, string password)
        {
            if (await BusinessLogic.Instance.GetLoginDetails(username, password) == true)
            {
                if (await BusinessLogic.Instance.GetUserDetails(4) == "4")
                {
                    return View("~/Views/Account/Index.cshtml");
                }
                else
                {
                    return Content("Du skal være en forældre før du kan logge ind på systemet.");
                }
            }
            else
            {
                return Content("Brugeren blev ikke fundet. Prøv evt. at genindtaste dit brugernavn og kodeord.");
            }
        }
    }
}