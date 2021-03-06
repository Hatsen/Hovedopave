﻿

/**
* Copyright (c) 2013 Lars Skaaning Jensen, Patrick Larsen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Lars Skaaning Jensen, Patrick Larsen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/



using System;
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
                if (await BusinessLogic.Instance.GetUserDetails(4) == "4") // userrole for parent
                {
                    this.Session["userid"] = await BusinessLogic.Instance.GetUserDetails(0);
                    this.Session["firstname"] = await BusinessLogic.Instance.GetUserDetails(1);
                    this.Session["lastname"] = await BusinessLogic.Instance.GetUserDetails(2);
                    this.Session["username"] = await BusinessLogic.Instance.GetUserDetails(3);
                    this.Session["userrole"] = await BusinessLogic.Instance.GetUserDetails(4);
                    this.Session["classid"] = await BusinessLogic.Instance.GetClassDetails(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["userrole"]));

                    return View("~/Views/Account/Index.cshtml");
                }
                else
                {

                    return View("~/Views/Shared/NotParent.cshtml"); //Hvis brugeren ikke er forælder.

                }
            }
            else
            {

             

                return View("~/Views/Shared/LoginFail.cshtml"); //Hvis brugeroplysningerne var forkerte.

            }
        }
    }
}