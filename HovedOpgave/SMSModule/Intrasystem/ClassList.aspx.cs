

/**
* Copyright (c) 2013 Patrick Larsen
*
* The terms of use for this and related files can be read in
* the fictional LICENSE file, which do not exist!
*/
/**
* Author: Patrick Larsen
* Location: Erhvervsakademiet Lillebælt, DAT12A
*/

using SMSModule.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class WebForm5 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<ClassEx> classList = await ObjectHolder.Instance.UcController.GetClasses();
            string html = "";

            html += "<br />";
            html += "<table id='classlist' align='center'>";
            html += "<tr class='classlistitem'>";
            html += "<th class='classlistheaderitem'>Navn</th>";
            html += "<th class='classlistheaderitem'>Adresse</th>";
            html += "<th class='classlistheaderitem'>By</th>";
            html += "<th class='classlistheaderitem'>Telefonnummer</th>";
            html += "<th class='classlistheaderitem'>E-mail</th>";
            html += "</tr>";

            foreach (ClassEx classEx in classList)
            {
                if (classEx.Id == Convert.ToInt32(Session["selectedclass"]))
                foreach (Student student in classEx.StudentsList)
                {
                    html += "<tr class='classlistitem'>";
                    html += "<td class='classlistitem'>" + student.Firstname + " " + student.Lastname + "</td>";
                    html += "<td class='classlistitem'>" + student.Address + "</td>";
                    html += "<td class='classlistitem'>" + student.City + "</td>";
                    html += "<td class='classlistitem'>" + student.Phonenumber + "</td>";
                    html += "<td class='classlistitem'>" + student.Email + "</td>";
                    html += "</tr>";
                }
            }

            html += "</table>";
            classlistArea.InnerHtml = html;
        }
    }
}