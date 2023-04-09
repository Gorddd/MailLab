using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface IEmailService
    {
        public IEnumerable<EmailDto> GetAll();
        public Task SendEmail(EmailDto emailDto);
        public bool IsLoggedIn();
    }
}
