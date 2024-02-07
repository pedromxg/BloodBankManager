using BloodBankManager.Infrastructure.Persistence.Interfaces;
using BloodBankManager.Infrastructure.Persistence.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BloodBankManager.Infrastructure.DependencyInjection
{
    public static class RepositoryDependencyInjection
    {
        public static void AddRepositoryDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDonorRepository, DonorRepository>();
            services.AddScoped<IDonationRepository, DonationRepository>();
        }
    }
}
