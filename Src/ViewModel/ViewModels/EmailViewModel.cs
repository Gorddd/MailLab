using Model.Dtos;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ViewModel.ViewModels
{
    public class EmailViewModel : INotifyPropertyChanged
    {
        public EmailViewModel(ObservableCollection<EmailDto> sentEmails, ObservableCollection<EmailDto> receivedEmails)
        {
            SentEmails = sentEmails;
            ReceivedEmails = receivedEmails;


        }

        public ObservableCollection<EmailDto> SentEmails { get; set; }
        public ObservableCollection<EmailDto> ReceivedEmails { get; set; }

        private EmailDto selectedEmail = new();
        public EmailDto SelectedEmail
        {
            get => selectedEmail;
            set
            {
                selectedEmail = value;
                OnPropertyChanged(nameof(SelectedEmail));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(prop));
        }
    }
}
