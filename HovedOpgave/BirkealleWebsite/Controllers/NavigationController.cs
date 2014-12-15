using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BirkealleWebsite.WebServiceDeployed;
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