using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class Logout : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Session.Remove("userid");
            Session.Remove("firstname");
            Session.Remove("lastname");
            Session.Remove("userrole");
            Session.Remove("classid");

            Response.Redirect("../Login.aspx");
        }
    }
}