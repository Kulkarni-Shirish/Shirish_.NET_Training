using System;
using System.Web;

namespace FormExperienceApp
{
    public partial class formexp : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                // Store username in a cookie
                HttpCookie userCookie = new HttpCookie("Username");
                userCookie.Value = txtUsername.Text;
                userCookie.Expires = DateTime.Now.AddDays(1); // Cookie valid for 1 day
                Response.Cookies.Add(userCookie);

                // Show confirmation message
                lblMessage.Text = "Form submitted successfully. Username saved in cookies!";
            }
        }
    }
}