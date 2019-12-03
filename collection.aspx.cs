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

        private List<SingleBook> _bookCollection = new List<SingleBook>();
        private DAL _thisDAL = new DAL();

        public List<SingleBook> BookCollection { get => _bookCollection; }

        protected void Page_Load(object sender, EventArgs e)
        {
            _bookCollection = _thisDAL.GetBooks();
        }

        protected void SeeBookButton_Command(object sender, CommandEventArgs e)
        {
            // Cast event originator as Button
            Button btn = (Button)sender;

            var passedId = btn.CommandArgument.ToString();
            Response.Redirect("Book?id=" + passedId);
        }
    }
}