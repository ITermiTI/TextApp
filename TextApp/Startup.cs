using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TextApp.Domain.Roles;
using TextApp.Domain.Text;
using TextApp.Domain.User;
using TextApp.Infrastructure;
using TextApp.Infrastructure.Users;
using TextApp.Presentation.Text;
using TextApp.Presentation.User;

namespace TextApp
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
            services.AddMvc();
            services.AddDbContext<TextDBContext>(item => item.UseSqlServer(Configuration.GetConnectionString("dbconn")));
            services.AddIdentity<User, IdentityRole>().AddEntityFrameworkStores<TextDBContext>();
            services.AddAuthentication();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireDigit = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;

                options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(15);
                options.Lockout.MaxFailedAccessAttempts = 20;
                options.Lockout.AllowedForNewUsers = true;

            });

            services.ConfigureApplicationCookie(options =>
           {
               options.Cookie.HttpOnly = true;
               options.ExpireTimeSpan = TimeSpan.FromMinutes(15);
               options.SlidingExpiration = true;
               options.LoginPath = "/login";
               options.AccessDeniedPath = "/unauthorized";
               options.LogoutPath = "/";
           });

            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITextRepository, TextRepository>();
            services.AddScoped<IUserPresentationRepository, UserPresentationRepository>();
            services.AddScoped<ITextPresentationRepository, TextPresentationRepository>();

            services.AddHttpContextAccessor();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetRequiredService<TextDBContext>();
                context.Database.Migrate();
            }
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
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
                endpoints.MapDefaultControllerRoute();
            });
        }
    }
}
