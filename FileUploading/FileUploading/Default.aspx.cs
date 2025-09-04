using System;
using System.IO;

namespace FileUploading
{
    public partial class _Default : System.Web.UI.Page
    {
        // Runs when the Upload button is clicked
        protected void UploadButton_Click(object sender, EventArgs e)
        {
            // Check if a file is selected
            if (FileUpload1.HasFile)
            {
                try
                {
                    // Get or create upload folder
                    string uploadFolder = Server.MapPath("~/Uploads/");
                    if (!Directory.Exists(uploadFolder)) Directory.CreateDirectory(uploadFolder);

                    // Build full file path and save file
                    string filePath = Path.Combine(uploadFolder, Path.GetFileName(FileUpload1.FileName));
                    FileUpload1.SaveAs(filePath);

                    // Show success message
                    StatusLabel.ForeColor = System.Drawing.Color.Green;
                    StatusLabel.Text = "File uploaded successfully: " + FileUpload1.FileName;
                }
                catch (Exception ex)
                {
                    // Show error message
                    StatusLabel.ForeColor = System.Drawing.Color.Red;
                    StatusLabel.Text = "Error: " + ex.Message;
                }
            }
            else
            {
                // No file chosen
                StatusLabel.ForeColor = System.Drawing.Color.Red;
                StatusLabel.Text = "Please select a file first.";
            }
        }
    }
}
