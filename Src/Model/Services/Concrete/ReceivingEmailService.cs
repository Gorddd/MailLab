using Model.Dtos;
using Model.EfCode;
using Model.Helpers;
using S22.Imap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Concrete
{
    public class ReceivingEmailService : IReceivingEmailService, IDisposable
    {
        private EfCoreContext context;

        private ImapClient client = null!;

        public ReceivingEmailService(EfCoreContext context)
        {
            this.context = context;
        }

        public Action<EmailDto> ReceivedEmailAction { get; set; } = null!;

        public void Dispose()
        {
            if (client != null)
            {
                client.Dispose();
            }
        }

        public void StartUpdateReceiving()
        {
            Dispose();
            var currentConfig = context.Configs.SingleOrDefault(c => c.IsCurrent);
            if (currentConfig == null) 
            {
                return;
            }

            client = new ImapClient(currentConfig.ImapServer, currentConfig.ImapPort, currentConfig.Email, currentConfig.Password, AuthMethod.Login, true);
            if (!client.Supports("IDLE"))
            {
                throw new Exception("Client doesn't support IDLE")!;
            }
            client.NewMessage += async (s, e) =>
            {
                var message = e.Client.GetMessage(e.MessageUID, FetchOptions.Normal);
                var emailDto = new EmailDto
                {
                    From = message.From?.ToString()!,
                    Subject = message.Subject,
                    Body = message.Body,
                };
                await context.Emails.AddAsync(emailDto.ToEmail());
                ReceivedEmailAction?.Invoke(emailDto);
                await context.SaveChangesAsync();
            };
        }
    }
}
