using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InleverOpdracht1
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Request.Cookies["isLoggedIn"] == null)
            {
                FooterLinkLogout.Visible = false;
            }
            else
            {
                FooterLinkLogin.Visible = false;
            }
        }

        protected void FooterLinkLogout_OnClick(object sender, EventArgs e)
        {
            Response.Cookies["isLoggedIn"].Expires = DateTime.Now.AddDays(-1);
            Response.Redirect(Request.RawUrl);
        }

        protected void FooterLinkLogin_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("Login");
        }
    }
}