



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


using BirkealleWebsite.Models;
using BirkealleWebsite.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BirkealleWebsite.Controllers
{
    public class EnrollmentController : Controller
    {
        //
        // GET: /Repository/
        public ActionResult Index()
        {
            return View();
        }



        [HttpPost]
        public async Task<ActionResult> PostEnrollment(Repository obj)
        {

            if (ModelState.IsValid)
            {

                bool success = await BusinessLogic.Instance.CreateEnrollment(obj);

                if (success)
                    return View("~/Views/Repository/EnrollmentConfirmed.cshtml"); // her skal den retuerner et view der siger tak :)
                else
                {
                    ModelState.AddModelError("Error", "Kunne ikke gennemføre indmeldelse!!");
                    return View("~/Views/Navigation/EnrollmentView.cshtml");
                }
            }
            else
            {
                return View("~/Views/Navigation/EnrollmentView.cshtml");
            }

        }





    }
}