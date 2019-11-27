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

        private DAL ThisDAL = new DAL();

        protected void Page_Load(object sender, EventArgs e)
        {


            if (Request.Cookies["isLoggedIn"] != null)
            {
                var isLoggedIn = Request.Cookies["isLoggedIn"].Value;
                if (isLoggedIn == "true")
                {
                    Response.Redirect("Default");
                }
            }

        }

        // Login with credentials and redirect on success
        private void LoginWithCredentials(string username, string password)
        {
            // Password in database is SHA256 hashed
            var passHash = Sha256_hash(password);

            if (ThisDAL.CheckUser(username, passHash))
            {
                HttpCookie loginCookie = new HttpCookie("isLoggedIn");
                loginCookie.Value = "true";
                Response.Cookies.Add(loginCookie);
                redirectAfterLogin();
            } else
            {
                LoginMsg.Text = "User not found";
                UsernameInput.Text = "";
                PasswordInput.Text = "";
            }
        }

        private void redirectAfterLogin()
        {
            // Check if user needs to be redirected to previous page
            if (String.IsNullOrEmpty(Request.QueryString["page"]))
            {
                Response.Redirect("Default");
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