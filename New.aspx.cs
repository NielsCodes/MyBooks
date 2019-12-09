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
    public partial class New : System.Web.UI.Page
    {

        private DAL _thisDal = new DAL();
        private List<MetaInfo> _authors = new List<MetaInfo>();
        private List<MetaInfo> _genres = new List<MetaInfo>();
        private List<MetaInfo> _series = new List<MetaInfo>();
        private List<MetaInfo> _languages = new List<MetaInfo>();
        private List<MetaInfo> _publishers = new List<MetaInfo>();
        private List<MetaInfo> _coverTypes = new List<MetaInfo>();

        protected void Page_Load(object sender, EventArgs e)
        {

            // Check if user is logged in
            if (Request.Cookies["isLoggedIn"] == null)
            {
                Response.Redirect("Login?p=new");
            }

            // Get meta data options if first page load
            if (!IsPostBack)
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

                // Bind genre data to dropdown
                BookGenreInput.DataSource = _genres;
                BookGenreInput.DataTextField = "Name";
                BookGenreInput.DataValueField = "Id";
                BookGenreInput.DataBind();

                // Bind series data to dropdown
                BookSeriesInput.DataSource = _series;
                BookSeriesInput.DataTextField = "Name";
                BookSeriesInput.DataValueField = "Id";
                BookSeriesInput.DataBind();

                // Bind language data to dropdown
                BookLanguageInput.DataSource = _languages;
                BookLanguageInput.DataTextField = "Name";
                BookLanguageInput.DataValueField = "Id";
                BookLanguageInput.DataBind();

                // Bind publisher data to dropdown
                BookPublisherInput.DataSource = _publishers;
                BookPublisherInput.DataTextField = "Name";
                BookPublisherInput.DataValueField = "Id";
                BookPublisherInput.DataBind();

                // Bind coverType data to dropdown
                BookCoverTypeInput.DataSource = _coverTypes;
                BookCoverTypeInput.DataTextField = "Name";
                BookCoverTypeInput.DataValueField = "Id";
                BookCoverTypeInput.DataBind();
            }
        }

        protected void SaveBookBtn_Click(object sender, EventArgs e)
        {
            _thisDal.AddBook(
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
    }
}