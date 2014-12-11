using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSModule.Webservice;

namespace SMSModule.Intrasystem
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            string html = "";

            int selectedClass = Convert.ToInt32(Request.QueryString["class"]);
            List<ClassEx> classList = (await ObjectHolder.Instance.UcController.GetClassDetails(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["userrole"])));

            foreach (ClassEx classEx in classList)
            {
                if (Convert.ToInt32(Session["userrole"]) == 1)
                {
                    Session["selectedclass"] = 0;
                }
                if (classEx == null)
                {
                    Session["selectedclass"] = 0;
                }
                else if (classEx.Id == Convert.ToInt32(Request.QueryString["class"]))
                {
                    Session["selectedclass"] = classEx.Id;
                    helloMessageArea.InnerHtml = "<h2> Hej " + Session["firstname"].ToString() + " " + Session["lastname"].ToString() + " - " + classEx.Name + "</h2>";
                }
            }

            List<Announcement> announcementList = await ObjectHolder.Instance.UcController.GetAnnouncements(Convert.ToInt32(Session["userrole"]), Convert.ToInt32(Session["selectedclass"]));

            html += "<table id='announcementTable'>";
            foreach(Announcement anc in announcementList)
            {
                html += "<tr>";
                html += "<td class='ancHeaderItem'><b>" + anc.Header + "</b></td>";
                html += "</tr>";
                html += "<tr>";
                html += "<td class='ancMessageItem'>" + anc.Message + "</td>";
                html += "</tr>";
                html += "<td class='ancCreatorItem'><b>Skrevet af: " + await ObjectHolder.Instance.UcController.GetAnnouncementCreator(anc.Creator) + " </b></td>";
                html += "</tr>";
                html += "<td></td>";
                html += "</tr>";
            }
            html += "</table>";
            announcements.InnerHtml = html;
        }
    }
}