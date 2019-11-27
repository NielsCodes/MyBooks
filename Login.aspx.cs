using InleverOpdracht1.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace InleverOpdracht1
{
    public partial class Login : System.Web.UI.Page
    {

        private DAL _thisDAL = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {

            // Redirect user to homepage if already logged in
            if (Request.Cookies["isLoggedIn"] != null)
            {
                var isLoggedIn = Request.Cookies["isLoggedIn"].Value;
                if (isLoggedIn == "true")
                {
                    Response.Redirect("Default");
                }
            }

            // Check if user needs to be redirected after login
            var page = Request.QueryString["p"];
            if (!String.IsNullOrEmpty(page))
            {
                LoginPreMsg.Text = "You need to log in first. You will be redirected after loging in";
            }

        }

        // Login with credentials and redirect on success
        private void LoginWithCredentials(string username, string password)
        {
            // Password in database is SHA256 hashed
            var passHash = Sha256_hash(password);

            if (_thisDAL.CheckUser(username, passHash))
            {
                HttpCookie loginCookie = new HttpCookie("isLoggedIn")
                {
                    Value = "true"
                };
                Response.Cookies.Add(loginCookie);
                RedirectAfterLogin();
            } else
            {
                LoginMsg.Text = "User not found";
                UsernameInput.Text = "";
                PasswordInput.Text = "";
            }
        }

        private void RedirectAfterLogin()
        {

            var page = Request.QueryString["p"];

            // Check if user needs to be redirected to previous page
            if (String.IsNullOrEmpty(page))
            {
                Response.Redirect("Default");
            } else if(page == "edit")
            {
                // Get book id from URL
                var bookId = Request.QueryString["id"];
                Response.Redirect("Edit?id=" + bookId);
            }
        }

        // Generate SHA256 hash from string
        public static String Sha256_hash(String value)
        {
            using (SHA256 hash = SHA256Managed.Create())
            {
                return String.Concat(hash
                  .ComputeHash(Encoding.UTF8.GetBytes(value))
                  .Select(item => item.ToString("x2")));
            }
        }

        protected void LoginButton_Click(object sender, EventArgs e)
        {
            var usernameInput = UsernameInput.Text;
            var passwordInput = PasswordInput.Text;
            LoginWithCredentials(usernameInput, passwordInput);
        }
    }
}