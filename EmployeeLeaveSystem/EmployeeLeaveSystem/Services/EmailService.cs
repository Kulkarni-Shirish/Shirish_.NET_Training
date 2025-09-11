using Microsoft.Extensions.Configuration;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;

namespace EmployeeLeaveSystem.Services
{
    // Service for sending emails using SMTP
    public class EmailService
    {
        private readonly IConfiguration _configuration;

        // Inject configuration to read SMTP settings
        public EmailService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // Send an email asynchronously
        public async Task SendEmailAsync(string toEmail, string subject, string body)
        {
            // Read SMTP settings from configuration
            var smtpHost = _configuration["Email:SmtpHost"];
            var smtpPort = int.Parse(_configuration["Email:SmtpPort"] ?? "587");
            var username = _configuration["Email:Username"];
            var password = _configuration["Email:Password"];
            var fromEmail = _configuration["Email:From"] ?? "noreply@example.com";

            // Configure SMTP client
            using var client = new SmtpClient(smtpHost, smtpPort)
            {
                Credentials = new NetworkCredential(username, password),
                EnableSsl = true
            };

            // Prepare email message
            var mailMessage = new MailMessage
            {
                From = new MailAddress(fromEmail),
                Subject = subject,
                Body = body,
                IsBodyHtml = true
            };

            mailMessage.To.Add(toEmail);

            // Send email
            await client.SendMailAsync(mailMessage);
        }
    }
}
