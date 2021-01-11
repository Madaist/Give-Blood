using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;

namespace Give_Blood.Services.EmailSender
{
    public interface IEmailSender
    {
        Task SendEmailAsync(string email, string subject, string message);
    }
}
