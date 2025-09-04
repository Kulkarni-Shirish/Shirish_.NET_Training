using System;

namespace FlowerSelector
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void btnShowSelection_Click(object sender, EventArgs e)
        {
            // Ensure a choice was made
            if (!string.IsNullOrEmpty(rblFlower.SelectedValue))
            {
                // Show the selected flower
                lblResult.Text = "You selected: " + rblFlower.SelectedValue;
            }
            else
            {
                // Prompt the user if nothing chosen
                lblResult.Text = "Please select a flower first.";
            }
        }
    }
}
