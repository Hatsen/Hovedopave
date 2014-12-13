using BirkealleWebsite.Models;
using BirkealleWebsite.WebServiceDeployed;
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