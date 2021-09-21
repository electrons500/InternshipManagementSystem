using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using OnlineInternshipPortal.Models;
using OnlineInternshipPortal.Models.Data;
using OnlineInternshipPortal.Models.Data.OnlineInternshipContext;
using OnlineInternshipPortal.Models.Data.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineInternshipPortal
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages().AddRazorRuntimeCompilation().AddViewOptions( o =>
            {
                o.HtmlHelperOptions.ClientValidationEnabled = true; //set to false to stop client side validation with jquery-validate and jquery-obtrusive js

             });



            services.AddIdentity<ApplicationUser, IdentityRole>()
                    .AddEntityFrameworkStores<OnlineInternshipContext>()
                    .AddDefaultTokenProviders();

            services.Configure<IdentityOptions>(options =>
            {
                // Password settings.
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireNonAlphanumeric = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 1;

                // Lockout settings.
                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
                options.Lockout.MaxFailedAccessAttempts = 5;
                options.Lockout.AllowedForNewUsers = true;

                // User settings.
                options.User.AllowedUserNameCharacters =
                "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+";
                options.User.RequireUniqueEmail = false;
            });

            services.ConfigureApplicationCookie(options =>
            {
                // Cookie settings
                options.Cookie.HttpOnly = true;
                options.ExpireTimeSpan = TimeSpan.FromMinutes(30);

                options.LoginPath = "/Account/Login";
                options.AccessDeniedPath = "/Identity/Account/AccessDenied";
                options.SlidingExpiration = true;
            });



            services.AddDbContext<OnlineInternshipContext>(o =>
            {
                o.UseSqlServer(Configuration.GetConnectionString("Conn"));
            });

            //Inject services classes
            services.AddScoped<AccountRegistrationService>();
            services.AddScoped<HomeService>();
            services.AddScoped<IndustryService>();
            services.AddScoped<DesignationService>();
            services.AddScoped<CompanyService>();
            services.AddScoped<SectorService>();
            services.AddScoped<VerifiedCategoryService>();
            services.AddScoped<VerifyCompanyService>();
            services.AddScoped<InternshipStatusService>();
            services.AddScoped<RemoteInternshipService>();
            services.AddScoped<PublicizedService>();
            services.AddScoped<InternshipService>();
            services.AddScoped<SchoolService>();
            services.AddScoped<InternService>();
            services.AddScoped<ApplicatonService>();
            services.AddScoped<HiredInternService>();
            services.AddScoped<SentMailService>();
            services.AddScoped<ReceivedMsgFromCompanyService>();
            services.AddScoped<UsersService>();


            //for pagination
            services.AddCloudscribePagination();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
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

            app.UseAuthentication();
            app.UseAuthorization();
            

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
