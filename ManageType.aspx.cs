using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InleverOpdracht1.DataAccessLayer;
using InleverOpdracht1.Models;

namespace InleverOpdracht1
{
    public partial class ManageType : System.Web.UI.Page
    {

        private DAL _thisDal = new DAL();


        protected void Page_Load(object sender, EventArgs e)
        {

            // Retrieve meta type from URL parameter.
            // If not present, redirect to management overview
            string metaType = Request.QueryString["type"];
            if (string.IsNullOrEmpty(metaType))
            {
                Response.Redirect("Manage");
            }

            // Check if user is logged in
            if (Request.Cookies["isLoggedIn"] == null)
            {
                Response.Redirect("Login?p=manageType&t=" + metaType);
            }

            ManageTitle.Text = "Manage " + metaType;

            switch (metaType)
            {
                case "Authors":
                    MetaGridView.DataSourceID = "AuthorsDataSource";
                    break;

                case "Series":
                    MetaGridView.DataSourceID = "SeriesDataSource";
                    break;

                case "Languages":
                    MetaGridView.DataSourceID = "LanguagesDataSource";
                    break;

                case "Publishers":
                    MetaGridView.DataSourceID = "PublishersDataSource";
                    break;

                case "Genres":
                    MetaGridView.DataSourceID = "GenresDataSource";
                    break;

                case "CoverType":
                    MetaGridView.DataSourceID = "CoverTypeDataSource";
                    break;

                default:
                    Response.Redirect("Manage");
                    break;
            }




            // TODO: Add switch to catch non-valid URL params



        }

    }
}