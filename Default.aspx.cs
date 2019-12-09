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
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ExecuteSearchButton_Click(object sender, EventArgs e)
        {
            // Get content of input
            string searchInput = SearchQueryInput.Text;

            // Show full collection if no search is submitted
            if (String.IsNullOrEmpty(searchInput))
            {
                Response.Redirect("/collection");
            } else
            {
                Response.Redirect("/collection?q=" + searchInput);
            }
        }
    }
}