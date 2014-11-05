using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

    public partial class Login : System.Web.UI.Page
    {
        

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void btnLogin_Click(object sender, EventArgs e)
        {
            if ()
            {
                Response.Redirect("intra/Default.aspx");
            }
            else
            {
                lblError.Text = "En fejl opstod. Indtast venligst dit brugernavn og kodeord igen.";
            }
        }
    }
