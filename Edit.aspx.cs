using InleverOpdracht1.DataAccessLayer;
using InleverOpdracht1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Diagnostics;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InleverOpdracht1
{
    public partial class Edit : System.Web.UI.Page
    {

        private SingleBook _book;
        private DAL _thisDal = new DAL();
        private List<MetaInfo> _authors = new List<MetaInfo>();
        private List<MetaInfo> _genres = new List<MetaInfo>();
        private List<MetaInfo> _series = new List<MetaInfo>();
        private List<MetaInfo> _languages = new List<MetaInfo>();
        private List<MetaInfo> _publishers = new List<MetaInfo>();
        private List<MetaInfo> _coverTypes = new List<MetaInfo>();

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

            // Get book info from DB
            _book = _thisDal.GetBook(Int32.Parse(bookId));

            // Only populate fields with database data if page_load is not a postback (a reload of the page on button press)
            if (!IsPostBack)
            {
                PrePopulate();
            }

        }

        protected void SaveBookBtn_Click(object sender, EventArgs e)
        {

            _thisDal.UpdateBook(
                _book.Id,
                BookTitleInput.Text,
                int.Parse(BookAuthorInput.SelectedValue),
                int.Parse(BookGenreInput.SelectedValue),
                int.Parse(BookSeriesInput.SelectedValue),
                int.Parse(BookLanguageInput.SelectedValue),
                BookEditionInput.Text,
                int.Parse(BookPublisherInput.SelectedValue),
                int.Parse(BookPagesInput.Text),
                BookCoverInput.Text,
                int.Parse(BookCoverTypeInput.SelectedValue),
                BookISBNInput.Text,
                BookReleaseDateInput.Text,
                BookPurchaseDateInput.Text,
                int.Parse(BookPriceInput.Text),
                int.Parse(BookPurchasePriceInput.Text)
            );

            Response.Redirect("collection");

        }

        private void PrePopulate()
        {
            // Get dropdown contents from DB
            _authors = _thisDal.GetMeta("Authors");
            _genres = _thisDal.GetMeta("Genres");
            _series = _thisDal.GetMeta("Series");
            _languages = _thisDal.GetMeta("Languages");
            _publishers = _thisDal.GetMeta("Publishers");
            _coverTypes = _thisDal.GetMeta("CoverTypes");

            // Bind author data to dropdown
            BookAuthorInput.DataSource = _authors;
            BookAuthorInput.DataTextField = "Name";
            BookAuthorInput.DataValueField = "Id";
            BookAuthorInput.DataBind();
            BookAuthorInput.Items.FindByValue(_book.Author.Id.ToString());

            // Bind genre data to dropdown
            BookGenreInput.DataSource = _genres;
            BookGenreInput.DataTextField = "Name";
            BookGenreInput.DataValueField = "Id";
            BookGenreInput.DataBind();
            BookGenreInput.Items.FindByValue(_book.Genre.Id.ToString());

            // Bind series data to dropdown
            BookSeriesInput.DataSource = _series;
            BookSeriesInput.DataTextField = "Name";
            BookSeriesInput.DataValueField = "Id";
            BookSeriesInput.DataBind();
            BookSeriesInput.Items.FindByValue(_book.Series.Id.ToString());

            // Bind language data to dropdown
            BookLanguageInput.DataSource = _languages;
            BookLanguageInput.DataTextField = "Name";
            BookLanguageInput.DataValueField = "Id";
            BookLanguageInput.DataBind();
            BookLanguageInput.Items.FindByValue(_book.Language.Id.ToString()).Selected = true;

            // Bind publisher data to dropdown
            BookPublisherInput.DataSource = _publishers;
            BookPublisherInput.DataTextField = "Name";
            BookPublisherInput.DataValueField = "Id";
            BookPublisherInput.DataBind();
            BookPublisherInput.Items.FindByValue(_book.Publisher.Id.ToString());

            // Bind coverType data to dropdown
            BookCoverTypeInput.DataSource = _coverTypes;
            BookCoverTypeInput.DataTextField = "Name";
            BookCoverTypeInput.DataValueField = "Id";
            BookCoverTypeInput.DataBind();
            BookCoverTypeInput.Items.FindByValue(_book.CoverType.Id.ToString());


            // Bind Book data to page elements
            // Required data
            BookCoverInput.Text = _book.Cover;
            BookTitleInput.Text = _book.Title;

            // Optional data - perform check whether value is not null or empty
            BookEditionInput.Text = string.IsNullOrEmpty(_book.Edition) ? "-" : _book.Edition;
            BookPagesInput.Text = _book.Pages == 0 ? "" : _book.Pages.ToString();

            BookISBNInput.Text = string.IsNullOrEmpty(_book.Isbn) ? "" : _book.Isbn;
            BookReleaseDateInput.Text = string.IsNullOrEmpty(_book.ReleaseDate) ? "" : _book.ReleaseDate;
            BookPriceInput.Text = _book.Price == 0 ? "0" : _book.Price.ToString();

            BookPurchaseDateInput.Text = string.IsNullOrEmpty(_book.PurchaseDate) ? "" : _book.PurchaseDate;
            BookPurchasePriceInput.Text = _book.PurchasePrice == 0 ? "0" : _book.PurchasePrice.ToString();
        }

        protected void DeleteBookBtn_Click(object sender, EventArgs e)
        {
            _thisDal.RemoveBook(_book.Id);
            Response.Redirect("collection");
        }
    }
}