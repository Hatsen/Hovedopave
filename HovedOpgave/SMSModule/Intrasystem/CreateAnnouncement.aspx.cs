using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SMSModule.Webservice;

namespace SMSModule.Intrasystem
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected async void Page_Load(object sender, EventArgs e)
        {
            List<ClassEx> classList = await ObjectHolder.Instance.UcController.GetClassDetails(Convert.ToInt32(Session["userid"]), Convert.ToInt32(Session["userrole"]));

            foreach (ClassEx classEx in classList)
            {
                ddlClass.Items.Add(new ListItem(classEx.Name, classEx.Id.ToString()));
            }
        }

        protected async void btnCreate_Click(object sender, EventArgs e)
        {
            bool success = await ObjectHolder.Instance.UcController.CreateAnnouncement(Convert.ToInt32(Session["userid"]), txtHeader.Text, txtMessage.Text, Convert.ToInt32(ddlGroup.SelectedValue), Convert.ToInt32(ddlClass.SelectedValue));

            if (success == true)
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Meddelelsen er nu oprettet!')</SCRIPT>");

                txtHeader.Text = "";
                txtMessage.Text = "";
            }
            else
            {
                Response.Write("<SCRIPT LANGUAGE='JavaScript'>alert('Meddelelsen kunne desværre ikke oprettes. Prøv igen.')</SCRIPT>");
            }
        }
    }
}