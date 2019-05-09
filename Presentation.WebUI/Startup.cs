using ApplicationLibrary;
using ApplicationLibrary.Repository;
using CoreLibrary.Entities.Company;
using CoreLibrary.Entities.Inventories.It;
using CoreLibrary.Entities.Items;
using CoreLibrary.Entities.Relations;
using InfrastructureLibrary;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistance.RepositoryLibrary;
using PersistenceLibrary;

namespace Presentation.WebUI
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            ConfigureAdditionalServices(services);
            services.AddDbContext<DrukarniaDbContext>(options =>
                        options.UseMySql(Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<IdentityUser>()
             .AddDefaultUI(UIFramework.Bootstrap4)
             .AddEntityFrameworkStores<DrukarniaDbContext>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }
        public void ConfigureAdditionalServices(IServiceCollection services)
        {
            services.AddSingleton<IDateTime, MachineDateTime>();
            services.AddTransient<IRepositoryBase<Department>, RepositoryBase<Department>>();
            services.AddTransient<IRepositoryBase<Certificate>, RepositoryBase<Certificate>>();
            services.AddTransient<IRepositoryBase<EmployeeEquipment>, RepositoryBase<EmployeeEquipment>>();
            services.AddTransient<IRepositoryBase<DeviceInfo>, RepositoryBase<DeviceInfo>>();
            services.AddTransient<IRepositoryBase<Software>, RepositoryBase<Software>>();
            services.AddTransient<IEquipmentTypeRepository, EquipmentTypeRepository>();
            services.AddTransient<IEquipmentRepository, EquipmentRepository>();
            services.AddTransient<IEmployeeRepository, EmployeeRepository>();

        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseAuthentication();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
