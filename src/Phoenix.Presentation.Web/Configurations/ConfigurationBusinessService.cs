using Phoenix.Business;
namespace Phoenix.Presentation.Web.Configurations
{
    public static class ConfigurationBusinessService
    {
        public static IServiceCollection AddBusinessService(this IServiceCollection service)
        {
            service.AddScoped<IReservationRepository, ReservationRepository>();

            //Web

            
            //Api



            return service;
        }
    }
}
