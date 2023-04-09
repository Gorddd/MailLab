using Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace Model.Services
{
    public interface IConfigService
    {
        public Task AddUpdateConfigAsync(ConfigDto config, string password);
        public Task RemoveConfigAsync(ConfigDto config);
        public Task<IEnumerable<ConfigDto>> GetAllAsync();
        public Task SignIn(ConfigDto singInConfig, string password);
    }
}
