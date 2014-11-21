using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }   

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            if (await ObjectHolder.Instance.UcController.GetLoginDetails(txtUsername.Text, txtPassword.Text) == true)
            {
                Session["userid"] = await ObjectHolder.Instance.UcController.GetUserDetails(0);
                Session["firstname"] = await ObjectHolder.Instance.UcController.GetUserDetails(1);
                Session["lastname"] = await ObjectHolder.Instance.UcController.GetUserDetails(2);
                Session["username"] = await ObjectHolder.Instance.UcController.GetUserDetails(3);
                Session["userrole"] = await ObjectHolder.Instance.UcController.GetUserDetails(4);
                Session["classid"] = await ObjectHolder.Instance.UcController.GetClassDetails(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["userrole"]));

                Response.Redirect("Intrasystem/Selector.aspx", false);
            }
            else
            {
                lblError.Text = "En fejl opstod. Prøv at indtaste brugernavnet og kodeordet igen.";
            }
        }
    }
}