using Model.Dtos;
using Model.EfCode;
using Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services.Concrete
{
    public class EmailService : IEmailService
    {
        private EfCoreContext context;

        public EmailService(EfCoreContext context)
        {
            this.context = context;
        }

        public IEnumerable<EmailDto> GetAll()
        {
            return context.Emails.Select(e => e.ToDto()).ToList();
        }

        public Task SendEmail()
        {
            
        }
    }
}
