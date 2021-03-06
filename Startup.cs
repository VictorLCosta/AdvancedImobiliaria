using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdvancedImobiliaria.Database.Common;
using AdvancedImobiliaria.Interfaces;
using AdvancedImobiliaria.Repositories;
using AdvancedImobiliaria.Repositories.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using FluentValidation.AspNetCore;
using AdvancedImobiliaria.Services.Hasher;

namespace AdvancedImobiliaria
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                .AddCookie(opt => {
                    opt.Cookie.Name = "UserLogin";
                    opt.Cookie.MaxAge = new TimeSpan(10, 0, 0, 0);
                    opt.AccessDeniedPath = "/Home/Login";
                });

            services.AddAuthorization(options => {
                options.AddPolicy("OnlyClients", policy => 
                                    policy.RequireClaim("Client"));

                options.AddPolicy("OnlyEmployees", policy => 
                                    policy.RequireClaim("Employee"));

                options.AddPolicy("OnlyAdmins", policy => 
                                    policy.RequireClaim("Admin"));
            });

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddDbContext<ImobiliariaContext>(opt => opt.UseSqlServer(
                Configuration.GetConnectionString("AdvancedImobiliaria")
            ));

            services.AddScoped<PasswordHasher>();

            #region Repositories
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<IPhysicalPersonRepository, PhysicalPersonRepository>();
            services.AddTransient<IImovelRepository, ImovelRepository>();
            #endregion

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddMvc()
                .AddFluentValidation(fvc => 
                    fvc.RegisterValidatorsFromAssemblyContaining<Startup>());

            services.AddControllersWithViews();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
    
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
