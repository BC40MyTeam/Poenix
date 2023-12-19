using Phoenix.Business.Interfaces;
using Phoenix.Business.Repositories;
using Phoenix.Presentation.Web.Services;

namespace Phoenix.Presentation.Web.Configurations
{
    public static class ConfigurationBusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection service)
        {
            //Repository
            service.AddScoped<IAuthRepository, AuthRepository>();
            service.AddScoped<IAdminRepository, AdminRepository>();

            //Service
            service.AddScoped<AdminService>();
            //Web

            
            //Api




            return service;
        }
    }
}
