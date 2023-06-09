﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Entities
{
    public class Email
    {
        public int Id { get; set; }
        public string Subject { get; set; } = null!;
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Body { get; set; }
        public bool IsSent { get; set; }
    }
}
