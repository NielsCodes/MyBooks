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

        private SingleBook book;

        protected void Page_Load(object sender, EventArgs e)
        {

            // Initialize connection to Data Access Layer
            DAL _thisDAL = new DAL();

            // Retrieve book ID from URL parameter.
            // If not present, redirect to home
            string bookId = Request.QueryString["id"];
            if (string.IsNullOrEmpty(bookId))
            {
                Response.Redirect("Default.aspx");
            }
            
            // Retrieve Book object with ID
            book = _thisDAL.GetBook(Int32.Parse(bookId));

            // Set page title equal to book title
            Page.Title = book.Title;

            // Bind Book data to page elements
            // Required data
            CoverImage.ImageUrl = book.Cover;
            BookTitle.InnerText = book.Title;
            BookAuthor.InnerText = book.Author;

            // Optional data - perform check whether value is not null or empty
            BookGenre.InnerHtml = string.IsNullOrEmpty(book.Genre) ? "-" : book.Genre;
            BookSeries.InnerHtml = string.IsNullOrEmpty(book.Series) ? "-" : book.Series;
            BookLanguage.InnerHtml = string.IsNullOrEmpty(book.Language) ? "-" : book.Language;
            BookEdition.InnerHtml = string.IsNullOrEmpty(book.Edition) ? "-" : book.Edition;
            BookPublisher.InnerHtml = string.IsNullOrEmpty(book.Publisher) ? "-" : book.Publisher;
            BookPages.InnerHtml = book.Pages == 0 ? "-" : book.Pages.ToString();
            BookCoverType.InnerHtml = string.IsNullOrEmpty(book.CoverType) ? "-" : book.CoverType;
            BookISBN.InnerHtml = string.IsNullOrEmpty(book.Isbn) ? "-" : book.Isbn;
            BookReleaseDate.InnerHtml = string.IsNullOrEmpty(book.ReleaseDate) ? "-" : book.ReleaseDate;
            BookPrice.InnerHtml = book.Price == 0 ? "-" : "&euro;" + book.Price.ToString();

            BookPurchaseDate.InnerHtml = string.IsNullOrEmpty(book.PurchaseDate) ? "-" : book.PurchaseDate;
            BookPurchasePrice.InnerHtml = book.PurchasePrice == 0 ? "-" : "&euro;" + book.PurchasePrice;
            var profit = book.Price - book.PurchasePrice;
            BookProfit.InnerHtml = "&euro;" + profit;

        }

        protected void BookEditButton_Click(object sender, EventArgs e)
        {
            var url = "Edit.aspx?id=" + book.Id;
            Response.Redirect(url);
        }
    }
}