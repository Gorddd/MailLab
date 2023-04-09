using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public interface IReceivingEmailService
    {
        public Action<EmailDto> ReceivedEmailAction { get; set; }
        public void StartUpdateReceiving();
    }
}
