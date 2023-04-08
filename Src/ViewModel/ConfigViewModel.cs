using Model.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace ViewModel
{
    public class ConfigViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<ConfigDto> Configs { get; set; }

        private ConfigDto selectedConfig = new();
        public ConfigDto SelectedConfig
        {
            get => selectedConfig;
            set
            {
                selectedConfig = value;
                OnPropertyChagned(nameof(SelectedConfig));
            }
        }

        private string password;
        public string Password {
            get => password; 
            set
            {
                password = value;
                OnPropertyChagned(nameof(Password));
            }
        }

        public ConfigViewModel()
        {
            Configs = new ObservableCollection<ConfigDto>
            {
                new ConfigDto { Email = "fuck@mail.ru", ImapPort = 1, ImapServer = "serv", SmtpPort = 2, SmtpServer = "fu" },
                new ConfigDto { Email = "new@gmail.com", ImapPort = 2, ImapServer = "mapserv", SmtpPort = 3, SmtpServer = "shit" },
            };
        }


        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChagned(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
