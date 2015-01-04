

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
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected async void btnSubmit_Click(object sender, EventArgs e)
        {
            bool result = await ObjectHolder.Instance.UcController.ChangePassword(Convert.ToInt32(Session["userid"]), txtOldPass.Text, txtNewPass.Text, txtConfirmPass.Text);

            if (result == true)
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Din adgangskode er nu blevet ændret!')</SCRIPT>");

                txtOldPass.Text = "";
                txtNewPass.Text = "";
                txtConfirmPass.Text = "";
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Din adgangskode kunne ikke ændres. Prøv igen.')</SCRIPT>");
            }
        }
    }
}