using MimeKit;
using MimeKit.Text;
using System.Net;
using System.Net.Mail;

namespace BillCollectorApp.Services
{
    public class EmailService
    {
        private readonly string _smtpServer = "smtp.gmail.com";
        private readonly int _smtpPort = 587;
        private readonly string _smtpUser = "mehedihasan93391@gmail.com"; // Your Gmail address
        private readonly string _smtpPass = "obuy uidx vzoz qmmq"; // Your Gmail password or App Password

        public async Task SendPaymentSuccessEmailAsync(string toEmail, string customerName, string bill, string transactionId)
        {
            try
            {
                // Load the HTML template
                string htmlTemplate = System.IO.File.ReadAllText("wwwroot/emailTemplates/paymentsuccessemail.html");

                // Replace placeholders with actual customer data
                string htmlContent = htmlTemplate
                    .Replace("{{CustomerName}}", customerName)
                    .Replace("{{transactionId}}", transactionId)
                    .Replace("{{bill}}", bill);

                var mailMessage = new MailMessage();
                mailMessage.From = new MailAddress(_smtpUser);
                mailMessage.To.Add(toEmail);
                mailMessage.Subject = "Bill Payment Success";
                mailMessage.Body = htmlContent;
                mailMessage.IsBodyHtml = true;  // Set to true to send HTML content

                using (var smtpClient = new SmtpClient(_smtpServer, _smtpPort))
                {
                    smtpClient.Credentials = new NetworkCredential(_smtpUser, _smtpPass);
                    smtpClient.EnableSsl = true;

                    await smtpClient.SendMailAsync(mailMessage);
                }
            }
            catch (Exception ex)
            {

                throw;
            }
        }
    }
}
