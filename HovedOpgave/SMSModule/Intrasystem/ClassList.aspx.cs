﻿using SMSModule.Webservice;
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
            html += "<th class='classlistitem'>Navn</th>";
            html += "<th class='classlistitem'>Adresse</th>";
            html += "<th class='classlistitem'>By</th>";
            html += "<th class='classlistitem'>Telefonnummer</th>";
            html += "<th class='classlistitem'>E-mail</th>";
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