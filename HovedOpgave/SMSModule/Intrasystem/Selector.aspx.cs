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

            if (classList.Count == 0)
            {
                Response.Redirect("Default.aspx");
            }
            else if (classList.Count == 1)
            {
                foreach (ClassEx classEx in classList)
                {
                    Response.Redirect("Default.aspx?class=" + classEx.Id);
                }
            }
            else if (classList.Count != 0 || classList != null)
            {
                foreach (ClassEx classEx in classList)
                {
                    html += "<a class='selectorLinkItem' href='Default.aspx?class=" + classEx.Id + "'>" + classEx.Name + "</a><br />";
                }
                selectorClassArea.InnerHtml = html;
            }
        }

        void lnk_Command(object sender, CommandEventArgs e, int id)
        {
            CreateSession(id);
        }
     
        protected void CreateSession(int classID)
        {

        }
    }
}