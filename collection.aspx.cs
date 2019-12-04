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
            _books = _thisDal.GetBooks();
            CollectionTable.DataSource = _books;
            CollectionTable.DataBind();
        }

        protected void SeeBookButton_Command(object sender, CommandEventArgs e)
        {

        }
    }
}