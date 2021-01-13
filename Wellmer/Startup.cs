using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.EntityFrameworkCore;
using Wellmer.Domain;
using Wellmer.Domain.Repositories.Abstract;
using Wellmer.Domain.Repositories.EntityFramework;
using Wellmer.Service;

namespace Wellmer
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;
        public void ConfigureServices(IServiceCollection services)
        {
            // apjungiam appsettings ir config
            Configuration.Bind("Project", new Config());

            // pridedam reikalingus servisus (Dependency Injection)
            services.AddTransient<ITextFieldsRepository, EFTextFieldsRepository>();
            services.AddTransient<IServiceItemsRepository, EFServiceItemsRepository>();
            services.AddTransient<DataManager>();

            //DB context
            services.AddDbContext<AppDbContext>(x => x.UseSqlServer(Config.ConnectionString));

            //identity konfiguracija
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.User.RequireUniqueEmail = true;
                options.Password.RequiredLength = 6;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireDigit = false;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            //authentication cookie
            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "WellmerAuth";
                options.Cookie.HttpOnly = true;
                options.LoginPath = "/account/login";
                options.AccessDeniedPath = "/account/accessdenied";
                options.SlidingExpiration = true;
            });

            //authorization. I admin area ileidziama tik su admin role.
            services.AddAuthorization (x =>
            {
                x.AddPolicy("AdminArea", policy => { policy.RequireRole("admin"); });
            });

            services.AddControllersWithViews(x =>
            {
                x.Conventions.Add(new AdminAreaAuthorization("Admin", "AdminArea"));
            })
                //compatibility set asp.net core 3.0
                .SetCompatibilityVersion(Microsoft.AspNetCore.Mvc.CompatibilityVersion.Version_3_0).AddSessionStateTempDataProvider();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //pilnas klaidos aprasymas in Development
            if (env.IsDevelopment())
                app.UseDeveloperExceptionPage();

            //naudosim Routing
            app.UseRouting();

            //Static files (css, js, img, etc..)
            app.UseStaticFiles();

            //authentification and authorisation
            app.UseCookiePolicy();
            app.UseAuthentication();
            app.UseAuthorization();

            //set endpoints
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute("admin", "{area:exists}/{controller=Home}/{action=Index}/{id?}");
                endpoints.MapControllerRoute("default", "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
