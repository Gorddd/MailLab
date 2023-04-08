using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.Dtos
{
    public class ConfigDto
    {
        public string Email { get; set; } = null!;
        public string SmtpServer { get; set; } = null!;
        public int SmtpPort { get; set; }
        public string ImapServer { get; set; } = null!;
        public int ImapPort { get; set; }
    }
}
