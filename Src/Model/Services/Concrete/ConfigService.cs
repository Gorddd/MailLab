using Microsoft.EntityFrameworkCore;
using Model.EfCode;
using Model.Entities;
using Model.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ViewModel.Dtos;

namespace Model.Services.Concrete
{
    public class ConfigService : IConfigService
    {
        private EfCoreContext context;

        public ConfigService(EfCoreContext context)
        {
            this.context = context;
        }

        public async Task AddUpdateConfigAsync(ConfigDto configDto, string password)
        {
            var dbConfig = await context.Configs.FirstOrDefaultAsync(c => c.Email == configDto.Email);
            if (dbConfig != null)
            {
                var configToUpdate = configDto.ToConfig();
                configToUpdate.Id = dbConfig.Id;
                configToUpdate.Password = password;
                context.Configs.Update(configToUpdate);
            }
            else
            {
                var configToAdd = configDto.ToConfig();
                configToAdd.Password = password;
                await context.Configs.AddAsync(configToAdd);
            }

            await context.SaveChangesAsync();
        }

        public async Task RemoveConfigAsync(ConfigDto configDto)
        {
            var dbConfig = await context.Configs.FirstOrDefaultAsync(c => c.Email == configDto.Email);
            if (dbConfig != null )
            {
                context.Configs.Remove(dbConfig);
            }

            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ConfigDto>> GetAllAsync()
        {
            return await context.Configs.Select(c => c.ToDto()).ToListAsync();
        }

        public async Task SignIn(ConfigDto singInConfig)
        {
            var dbConfig = await context.Configs.FirstOrDefaultAsync(c => c.Email == singInConfig.Email);
            if (dbConfig != null)
            {
                var configToUpdate = singInConfig.ToConfig();
                configToUpdate.Id = dbConfig.Id;
                configToUpdate.IsCurrent = true;
                context.Configs.Update(configToUpdate);
            }

            await context.SaveChangesAsync();
        }
    }
}
