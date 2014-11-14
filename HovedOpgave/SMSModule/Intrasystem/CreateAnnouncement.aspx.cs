using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SMSModule.Intrasystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected async void btnCreate_Click(object sender, EventArgs e)
        {
            bool success = await ObjectHolder.Instance.UcController.CreateAnnouncement(Convert.ToInt32(Session["userid"]), txtHeader.Text, txtMessage.Text, Convert.ToInt32(ddlGroup.SelectedValue), 0);

            if (success == true)
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Meddelelsen er nu oprettet!')</SCRIPT>");
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Meddelelsen kunne desværre ikke oprettes!')</SCRIPT>");
            }
        }
    }
}