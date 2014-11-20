using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class Selector : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string html = "";
            List<int> classList = (List<int>)Session["classid"];

            html += "<table id=selectorClassTable>";

            for (int i = 0; i < classList.Count; i++)
            {
                html += "<tr>";
                html += "<td><a href='Default.aspx?class=" + classList[i].ToString() + "'>" + classList[i].ToString() + "</a></td>";
                html += "</tr>";
            }
            html += "</table>";

            selectorClassArea.InnerHtml = html;
        }
    }
}