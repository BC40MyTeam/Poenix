using Phoenix.DataAccess;
using Phoenix.DataAccess.Models;
using Phoenix.Presentation.Web.Configurations;
using Phoenix.Presentation.Web.ViewModels;

namespace Phoenix.Presentation.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            Dependencies.AddDataAccessServices(builder.Services, builder.Configuration);
            builder.Services.AddBusinessService();
            builder.Services.AddControllersWithViews();
            //Tinggal ditambahin kalau mau ngedit mapper baru
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<Administrator,LoginFormViewModel>();
                cfg.CreateMap<LoginFormViewModel, Administrator>();

            });
            builder.Services.AddControllers();
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (!app.Environment.IsDevelopment())
            {
                app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();
            app.UseAuthorization();
            app.UseAuthorization();
            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}");

            app.Run();
        }
    }
}