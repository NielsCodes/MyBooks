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
    public partial class collection : System.Web.UI.Page
    {

        private DAL _thisDal = new DAL();
        private List<SingleBook> _books = new List<SingleBook>();

        protected void Page_Load(object sender, EventArgs e)
        {

            string searchQuery = Request.QueryString["q"];

            // Get all books if no search query
            // Get filtered result if search query
            if (String.IsNullOrEmpty(searchQuery))
            {
                _books = _thisDal.GetBooks();
            } else
            {
                _books = _thisDal.GetBooks(searchQuery);
                CollectionTitle.Text = "Showing results for '" + searchQuery + "'";
            }

            
            CollectionTable.DataSource = _books;
            CollectionTable.DataBind();
        }

        protected void SeeBookButton_Command(object sender, CommandEventArgs e)
        {

        }
    }
}