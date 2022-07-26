using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Mvc.Services.Logging;
using Mvc.Services.HitCounter;


namespace Mvc
{
    public class Startup
    {
        private IWebHostEnvironment env;


        public Startup(IConfiguration configuration, IWebHostEnvironment env)
        {
            Configuration = configuration;
            this.env = env;
        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            if (env.IsDevelopment() || env.IsEnvironment("Local"))
            {
                services.AddWebOptimizer(false, false);
            }
            else
            {
                services.AddWebOptimizer(options =>
                {
                    options.MinifyCssFiles();
                    options.MinifyJsFiles();

                    options.AddJavaScriptBundle("js/validations/validationCode.js", "js/validations/**/*.js");
                    options.AddJavaScriptBundle(
                        "js/validations/validationCode.js",
                        "js/validations/validators.js",
                        "js/validations/errorFormatting.js"
                        );
                });
            }

            services.AddControllersWithViews();

            services.AddScoped(typeof(IAppLogging<>), typeof(AppLogging<>));

            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            ServiceDescriptor descriptor = new(typeof(IHitCounter), new HitCounter(env.ContentRootPath));
            services.Add(descriptor);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "areaRoute",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}");

                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
