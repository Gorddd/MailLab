using Microsoft.VisualBasic;
using Model.Commands;
using Model.Dtos;
using Model.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Xml.Linq;
using ViewModel.Dtos;
using ViewModel.Helpers;

namespace ViewModel.ViewModels
{
    public class EmailViewModel : INotifyPropertyChanged
    {
        public IEmailService EmailService { get; }
        public EmailViewModel(IEmailService emailService)
        {
            EmailService = emailService;

            InitializeEmails();
        }

        private void InitializeEmails()
        {
            var allEmails = EmailService.GetAll();
            allEmails
                .Select(e => e.ToViewEmailDto())
                .ToList().ForEach(e =>
                {
                    if (e.IsSent)
                        SentEmails.Add(e);
                    else
                        ReceivedEmails.Add(e);
                });
        }

        public ObservableCollection<ViewEmailDto> SentEmails { get; set; } = new();
        public ObservableCollection<ViewEmailDto> ReceivedEmails { get; set; } = new();
        public ObservableCollection<ViewEmailDto> Drafts { get; set; } = new();

        private ViewEmailDto selectedEmail = new();
        public ViewEmailDto SelectedEmail
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

        private NewDraftCommand? newDraftCommand;
        public NewDraftCommand NewDraftCommand
        {
            get
            {
                return newDraftCommand ??
                    (newDraftCommand = new NewDraftCommand(obj =>
                    {
                        var newDraft = new ViewEmailDto();
                        newDraft.Subject = "New email";
                        newDraft.SendPosibility = Visibility.Visible;
                        selectedEmail = newDraft;
                        Drafts.Add(selectedEmail);
                    }));
            }
        }
    }
}
