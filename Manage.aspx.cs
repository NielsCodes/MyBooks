using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InleverOpdracht1
{
    public partial class Manage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (Request.Cookies["isLoggedIn"] == null)
            {
                Response.Redirect("Login?p=manage");
            }
        }

        protected void ManageAuthorsLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ManageType?type=Authors");
        }

        protected void ManageSeriesLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ManageType?type=Series");
        }

        protected void ManageGenresLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ManageType?type=Genres");
        }

        protected void ManageLanguagesLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ManageType?type=Languages");
        }

        protected void ManagePublishersLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ManageType?type=Publishers");
        }

        protected void ManageCoverTypesLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("ManageType?type=CoverType");
        }

        protected void AddBookLink_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("new");
        }
    }
}