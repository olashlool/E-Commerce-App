using Cosmetic_Store.Models.Interface;
using SendGrid;
using SendGrid.Helpers.Mail;
using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Services
{
    public class EmailServices : IEmail
    {
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
