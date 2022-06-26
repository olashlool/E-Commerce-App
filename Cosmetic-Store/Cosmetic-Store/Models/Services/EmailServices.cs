using Cosmetic_Store.Models.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Services
{
    public class EmailServices : IEmail
    {
        /* 1. Brings in string type of email, subject, and message contents
           2. Brings in the sender from configuration and create a new SendGridMessage
           3. Set the message properties to have a sender, an email subject, and email contents */

        public async Task SendEmailAsync(string email, string subject, string message)
        {
            SendGridClient client = new SendGridClient("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");
            SendGridMessage msg = new SendGridMessage();
            msg.SetFrom("22029620@student.ltuc.com", "Manager");
            msg.AddTo(email);
            msg.SetSubject(subject);
            msg.AddContent(MimeType.Html, message);
            await client.SendEmailAsync(msg);

        }
    }
}
