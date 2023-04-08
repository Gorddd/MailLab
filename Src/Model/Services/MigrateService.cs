using Microsoft.EntityFrameworkCore;
using Model.EfCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Services
{
    public class MigrateService
    {
        private EfCoreContext context;

        public MigrateService(EfCoreContext context)
        {
            this.context = context;
        }

        public async Task MigrateAsync()
        {
            await context.Database.MigrateAsync();
        }
    }
}
