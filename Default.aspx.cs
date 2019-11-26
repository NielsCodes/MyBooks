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
            DAL thisDal = new DAL();
            thisDal.GetBooks();
            List<SingleBook> books = thisDal.Books;
            this.GridView2.DataSource = books;
            this.GridView2.DataBind();
            Console.WriteLine(books);
        }
    }
}