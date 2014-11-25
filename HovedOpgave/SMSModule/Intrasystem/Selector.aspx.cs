using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSModule.Webservice;

namespace SMSModule.Intrasystem
{
    public partial class Selector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            List<ClassEx> classList = (List<ClassEx>)Session["classid"];

            html += "<table id=selectorClassTable>";

            if (classList.Count != 0 || classList != null)
            {
                foreach (ClassEx classEx in classList)
                {
                    html += "<tr>";
                    html += "<td class='selectorLinkItem'><a href='Default.aspx?class=" + classEx.Id + "'>" + classEx.Name + "</a></td>";
                    html += "</tr>";
                }
                html += "</table>";
                selectorClassArea.InnerHtml = html;
            }
            else
            {
                Response.Redirect("Default.aspx");
            }
        }
    }
}