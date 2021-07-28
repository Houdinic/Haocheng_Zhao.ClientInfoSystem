using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.RepositoryInterface;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.ServiceInterface;
using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Service;
using Haocheng_Zhao.ClientInfoSystem.Infrastructure.Repository;
using Haocheng_Zhao.ClientInfoSystem.ApplicationCore.Entity;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Haocheng_Zhao.ClientInfoSystem.MVC
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

            services.AddScoped<IClientRepository, ClientRepository>();
            services.AddScoped<IAsyncRepository<Interactions>, EfRepository<Interactions>>();
            services.AddScoped<IClientService, ClientService>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();
            services.AddScoped<IInteractionService, InteractionService>();
            services.AddScoped<ICurrentEmployeeService, CurrentEmpService>();

            services.AddHttpContextAccessor();

            services.AddDbContext<ClientInfoSystemDbContext>(options => {
                options.UseSqlServer(Configuration.GetConnectionString("ClientInforSystemConnection"));
            });

            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(options =>
                {
                    options.Cookie.Name = "EmployeeAuth";
                    options.ExpireTimeSpan = TimeSpan.FromHours(1);
                    options.LoginPath = "/Employee/Login";
                });
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
