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
            html += "<tr>";
            html += "<th>Navn</th>";
            html += "<th>Adresse</th>";
            html += "<th>By</th>";
            html += "<th>Telefonnummer</th>";
            html += "<th>E-mail</th>";
            html += "</tr>";

            foreach (ClassEx classEx in classList)
            {
                if (classEx.Id == Convert.ToInt32(Session["selectedclass"]))
                foreach (Student student in classEx.StudentsList)
                {
                    html += "<tr>";
                    html += "<td>" + student.Firstname + " " + student.Lastname + "</td>";
                    html += "<td>" + student.Address + "</td>";
                    html += "<td>" + student.City + "</td>";
                    html += "<td>" + student.Phonenumber + "</td>";
                    html += "<td>" + student.Email + "</td>";
                    html += "</tr>";
                }
            }

            html += "</table>";
            classlistArea.InnerHtml = html;
        }
    }
}