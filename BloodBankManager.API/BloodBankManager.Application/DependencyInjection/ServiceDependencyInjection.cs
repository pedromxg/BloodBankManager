using BloodBankManager.Application.Services.Implementations;
using BloodBankManager.Application.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BloodBankManager.Application.DependencyInjection
{
    public static class ServiceDependencyInjection
    {
        public static void AddServiceDependencyInjection(this IServiceCollection services)
        {
            services.AddScoped<IDonorService, DonorService>();
            services.AddScoped<IDonationAppService, DonationAppService>();
        }
    }
}
