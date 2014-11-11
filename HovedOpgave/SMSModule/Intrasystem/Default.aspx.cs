using SMSModule.Webservice;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            string html = "";

            List<Announcement> announcementList = await ObjectHolder.Instance.UcController.GetAnnouncements(Convert.ToInt32(Session["userrole"]), 0);

            html += "<table id='announcementTable'>";
            foreach(Announcement anc in announcementList)
            {
                html += "<tr>";
                html += "<td>Skrevet af: <b>" + anc.Header + "</b></td>";
                html += "<td>" + anc.Message + "</td>";
                html += "</tr>";
            }
            html += "</table>";
            announcements.InnerHtml = html;
        }
    }
}