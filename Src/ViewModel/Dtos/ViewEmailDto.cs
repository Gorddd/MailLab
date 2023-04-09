using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ViewModel.Dtos
{
    public class ViewEmailDto
    {
        public string Subject { get; set; } = null!;
        public string? From { get; set; }
        public string? To { get; set; }
        public string? Body { get; set; }
        public bool IsSent { get; set; }
        public Visibility SendPosibility { get; set; } = Visibility.Hidden;
    }
}
