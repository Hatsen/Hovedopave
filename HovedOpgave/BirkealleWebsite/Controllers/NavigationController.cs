



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
using System.Web;
using System.Web.Mvc;
using BirkealleWebsite.Webservice;
using BirkealleWebsite.Models;

namespace BirkealleWebsite.Controllers
{
    public class NavigationController : Controller
    {
        // GET: Navigation
        public ActionResult Index()
        {
            return View("~/Views/Navigation/IndexView.cshtml");
        }

        public ActionResult GotoEnrollment()
        {

            return View("~/Views/Navigation/EnrollmentView.cshtml");
        }

        public ActionResult GotoAboutSchool()
        {
            return View("~/Views/Navigation/AboutSchoolView.cshtml");
        }

        public ActionResult GotoLogin()
        {
            return View("~/Views/Navigation/LoginView.cshtml");
        }

        public ActionResult GotoContact()
        {
            return View("~/Views/Navigation/ContactView.cshtml");
        }

        public ActionResult GotoGallery()
        {
            return View("~/Views/Navigation/GalleryView.cshtml");
        }

        public ActionResult Information()
        {
            return View("~/Views/Navigation/GalleryView.cshtml");
        }

    }
}