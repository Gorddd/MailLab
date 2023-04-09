using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Dtos
{
    public class EmailDto
    {
        public string Subject { get; set; } = null!;
        public string? Body { get; set; }
        public bool IsSent { get; set; }
    }
}
