﻿using BirkealleWebsite.Models;
using BirkealleWebsite.WebService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace BirkealleWebsite.Controllers
{
    public class ClassController : Controller
    {
        // GET: Class
        public async Task<ActionResult> DisplayClassList()
        {
            List<ClassEx> classList = await BusinessLogic.Instance.GetClassDetails(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["userrole"]));
            return View(classList);
        }

        public async Task<ActionResult> DisplaySpecifiedClass(int id)
        {
            List<ClassEx> selectedList = new List<ClassEx>();
            List<ClassEx> classList = await BusinessLogic.Instance.GetClasses();

            foreach (ClassEx classEx in classList)
            {
                if (classEx.Id == id)
                {
                    selectedList.Add(classEx);
                }
            }

            ViewData["title"] = id;
            return View(selectedList);
        }
    }
}