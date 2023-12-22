using Phoenix.Business.Interfaces;
using Phoenix.Business.Repositories;

namespace Phoenix.Presentation.Web.Configurations
{
    public static class ConfigurationBusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection service)
        {
            //Repository


            //Web
            service.AddScoped<IRoomServiceRepository, RoomServiceRepository>();
            
            //Api



            return service;
        }
    }
}
