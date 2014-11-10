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
                Response.Redirect("Intrasystem/Default.aspx");
            }
            else
            {
                lblError.Text = "En fejl opstod. Prøv at indtaste brugernavnet og kodeordet igen.";
            }
        }
    }
}