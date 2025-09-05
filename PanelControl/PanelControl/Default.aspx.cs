using System;

namespace YourProjectNamespace
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadNotifications();
            }
        }

        private void LoadNotifications()
        {
            NotificationList.Items.Clear();
            //Items
            NotificationList.Items.Add(" New feature released in your dashboard!");
            NotificationList.Items.Add(" Your profile was updated successfully.");
            NotificationList.Items.Add(" Password will expire in 5 days.");
            NotificationList.Items.Add(" You have 3 new messages.");
            NotificationList.Items.Add(" Congratulations! You won a gift voucher.");
        }

        protected void btnLoad_Click(object sender, EventArgs e)
        {
            // Add a new notification dynamically
            NotificationList.Items.Add(" New alert received at " + DateTime.Now.ToString("hh:mm:ss tt"));
        }
    }
}
