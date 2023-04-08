using Model.Entities;
using Model.Services;
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
        public ObservableCollection<ConfigDto> Configs { get; set; } = null!;

        private ConfigDto selectedConfig = new();

        private IConfigService configService;

        public ConfigViewModel(IConfigService configService)
        {
            this.configService = configService;
        }

        public ConfigDto SelectedConfig
        {
            get => selectedConfig;
            set
            {
                selectedConfig = value;
                OnPropertyChagned(nameof(SelectedConfig));
            }
        }

        private string password = string.Empty;
        public string Password {
            get => password; 
            set
            {
                password = value;
                OnPropertyChagned(nameof(Password));
            }
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        public void OnPropertyChagned(string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public async Task BuildCollection()
        {
            if (Configs == null)
                Configs = new ObservableCollection<ConfigDto>(await configService.GetAllAsync());
        }
    }
}
