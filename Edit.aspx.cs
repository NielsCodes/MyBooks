using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InleverOpdracht1
{
    public partial class Edit : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Retrieve book ID from URL parameter.
            // If not present, redirect to home
            string bookId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(bookId))
            {
                Response.Redirect("Default.aspx");
            }

            // Check if user is logged in
        }
    }
}