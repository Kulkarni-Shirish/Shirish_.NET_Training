using System;

namespace AjaxDemo
{
    // This page shows how to use AJAX to update only part of a web page.
    public partial class AjaxTimeDemo : System.Web.UI.Page
    {
        // Runs when the "Update Time" button is clicked inside the UpdatePanel.
        protected void btnUpdate_Click(object sender, EventArgs e)
        {
            // Update the label with the current server time.
            lblMessage.Text = "Current Server Time: " + DateTime.Now.ToString("hh:mm:ss tt");
        }
    }
}
