using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using DotnetCorp.Services;

namespace DotnetCorp
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IUserService, UserService>();
            services.AddMvc(option => option.EnableEndpointRouting = false);
        }

        public void Configure(IApplicationBuilder app, IUserService userService)
        {
            app.UseDeveloperExceptionPage();
            app.UseStaticFiles();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Users}/{action=Index}/{id?}");
            });
            userService.ResetDatabase();
            userService.SeedDatabase();
        }
    }
}
