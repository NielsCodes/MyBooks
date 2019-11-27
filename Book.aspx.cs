using InleverOpdracht1.DataAccessLayer;
using InleverOpdracht1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InleverOpdracht1
{
    public partial class Book : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            // Initialize connection to Data Access Layer
            DAL thisDAL = new DAL();

            // Retrieve book ID from URL parameter.
            // If not present, redirect to home
            string bookId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(bookId))
            {
                Response.Redirect("Default.aspx");
            }
            
            // Retrieve Book object with ID
            SingleBook book = thisDAL.GetBook(Int32.Parse(bookId));

            // Bind Book data to page elements
            CoverImage.ImageUrl = book.Cover;
            BookTitle.InnerText = book.Title;
            BookAuthor.InnerText = book.Author;

            BookGenre.InnerHtml = string.IsNullOrEmpty(book.Genre) ? "-" : book.Genre;
            BookSeries.InnerHtml = string.IsNullOrEmpty(book.Series) ? "-" : book.Series;
            BookPublisher.InnerHtml = string.IsNullOrEmpty(book.Publisher) ? "-" : book.Publisher;

        }
    }
}