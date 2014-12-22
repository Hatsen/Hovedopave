using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        protected void Page_Init(object sender, EventArgs e)
        {
            txtCity.Text = Session["city"].ToString();
            txtAddress.Text = Session["address"].ToString();
            txtPhone.Text = Session["phone"].ToString();

            if (Session["email"] == null)
            {
                Session["email"] = "email@email.dk";
            }

            txtEmail.Text = Session["email"].ToString();
        }

        //protected async void btnSubmit_Click(object sender, EventArgs e)
        //{
            
        //}

        protected async void btnSubmit_Click1(object sender, EventArgs e)
        {
            bool success = await ObjectHolder.Instance.UcController.UpdateUserDetails(Convert.ToInt32(Session["userid"]), txtCity.Text, txtAddress.Text, Convert.ToInt32(txtPhone.Text), txtEmail.Text);

            if (success == true)
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Dine brugeroplysninger er nu opdateret!')</SCRIPT>");

                Session["city"] = txtCity.Text;
                Session["address"] = txtAddress.Text;
                Session["phone"] = txtPhone.Text;
                Session["email"] = txtEmail.Text;
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Dine brugeroplysninger kunne ikke opdateres. Prøv igen.')</SCRIPT>");
            }
        }
    }
}