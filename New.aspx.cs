using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using InleverOpdracht1.DataAccessLayer;

namespace InleverOpdracht1
{
    public partial class New : System.Web.UI.Page
    {

        private DAL _thisDal = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {
            
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