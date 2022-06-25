using System.Threading.Tasks;

namespace Cosmetic_Store.Models.Interface
{
    public interface IEmail
    {
        public Task SendEmailAsync(string email, string subject, string Message);

    }
}
