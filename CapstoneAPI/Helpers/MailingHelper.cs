using SendGrid.Helpers.Mail;
using SendGrid;

namespace CapstoneAPI.Helpers
{
    public static class MailingHelper
    {
        public static async Task SendEmail(string email,string code,string title,string message)
        {
            var apiKey = "";
            var client = new SendGridClient(apiKey);
            var from = new EmailAddress("jassertrainer@gmail.com", "PasswordManagerAPP");
            var subject = title;
            var to = new EmailAddress(email, "Password Manager User");
            var plainTextContent = $"Dear User {message}  Please Use The Following OTP Code {code} It Will be Expired With in 10 minutes";
            //var htmlContent = "<strong>and easy to do anywhere, even with C#</strong>";
            var msg = MailHelper.CreateSingleEmail(from, to, subject, plainTextContent,"");
            var response = await client.SendEmailAsync(msg);
        }
    }
}
