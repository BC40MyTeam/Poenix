using Phoenix.Business;
using Phoenix.Presentation.Web.Services;

namespace Phoenix.Presentation.Web.Configurations
{
    public static class ConfigurationBusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection service)
        {
            service.AddScoped<IReservationRepository, ReservationRepository>();
            return service;
        }
    }
}
