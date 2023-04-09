using Microsoft.EntityFrameworkCore;
using Model.Dtos;
using Model.EfCode;
using Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Concrete
{
    public class SendEmailService : ISendEmailService
    {
        private EfCoreContext context;

        public SendEmailService(EfCoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<EmailDto> GetAll()
        {
            return context.Emails.Select(e => e.ToDto()).ToList();
        }

        public bool IsLoggedIn()
        {
            return context.Configs.Any(c => c.IsCurrent);
        }

        public async Task SendEmail(EmailDto emailDto)
        {
            await context.Emails.AddAsync(emailDto.ToEmail());

            var currentConfig = await context.Configs.SingleAsync(c => c.IsCurrent);

            var message = new MailMessage(emailDto.From, emailDto.To)
            {
                Subject = emailDto.Subject,
                Body = emailDto.Body,
            };

            using (var smtpClient = new SmtpClient(currentConfig.SmtpServer, currentConfig.SmtpPort))
            {
                smtpClient.Credentials = new NetworkCredential(emailDto.From, currentConfig.Password);
                smtpClient.EnableSsl = true;
                smtpClient.Send(message);
            }

            await context.SaveChangesAsync();
        }
    }
}
