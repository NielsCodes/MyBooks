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
    public partial class Edit : System.Web.UI.Page
    {

        private SingleBook book;
        private DAL _thisDal = new DAL(); 

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
            if (Request.Cookies["isLoggedIn"] == null)
            {
                Response.Redirect("Login?p=edit&id=" + bookId);
            }

            book = _thisDal.GetBook(Int32.Parse(bookId));

            // Bind Book data to page elements
            // Required data
            BookCoverInput.Text = book.Cover;
            BookTitleInput.Text = book.Title;
            BookAuthorInput.Text = book.Author;

            // Optional data - perform check whether value is not null or empty
            BookGenreInput.Text = string.IsNullOrEmpty(book.Genre) ? "" : book.Genre;
            BookSeriesInput.Text = string.IsNullOrEmpty(book.Series) ? "" : book.Series;
            BookLanguageInput.Text = string.IsNullOrEmpty(book.Language) ? "" : book.Language;
            BookEditionInput.Text = string.IsNullOrEmpty(book.Edition) ? "-" : book.Edition;
            BookPublisherInput.Text = string.IsNullOrEmpty(book.Publisher) ? "" : book.Publisher;
            BookPagesInput.Text = book.Pages == 0 ? "" : book.Pages.ToString();
            BookCoverTypeInput.Text = string.IsNullOrEmpty(book.CoverType) ? "" : book.CoverType;
            BookISBNInput.Text = string.IsNullOrEmpty(book.Isbn) ? "" : book.Isbn;
            BookReleaseDateInput.Text = string.IsNullOrEmpty(book.ReleaseDate) ? "" : book.ReleaseDate;
            BookPriceInput.Text = book.Price == 0 ? "0" : book.Price.ToString();

            BookPurchaseDateInput.Text = string.IsNullOrEmpty(book.PurchaseDate) ? "" : book.PurchaseDate;
            BookPurchasePriceInput.Text = book.PurchasePrice == 0 ? "0" : book.PurchasePrice.ToString();

        }

        protected void SaveBookBtn_Click(object sender, EventArgs e)
        {

        }
    }
}