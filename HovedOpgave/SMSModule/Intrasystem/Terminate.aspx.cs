
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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class Terminate : System.Web.UI.Page
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