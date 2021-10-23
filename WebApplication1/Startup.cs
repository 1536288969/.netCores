using Autofac;
using Autofac.Extensions.DependencyInjection;
using Common;
using Common.AutofacManager;
using Common.Repository;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Service.IService;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Utility;

namespace WebApplication1
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        private IServiceCollection Services { get; set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            Services = services;
            //builder.RegisterGeneric(typeof(Repository<>)).As(typeof(IRepository<>)).InstancePerDependency();
            services.AddRazorPages();
            services.AddDbContext<DataDBContext>(opt => opt.UseSqlServer(Configuration.GetSection("Connection:DbConnectionString").Value));
            services.AddHttpContextAccessor();
            services.AddControllers().AddControllersAsServices();
            services.AddMvc().AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<IValidator>()).SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
            services.AddSession();
            services.AddMemoryCache();
            services.AddControllersWithViews().AddControllersAsServices();
           
            //return new AutofacServiceProvider(contaner);
            //services.AddSingleton<IStudentRepository, MockStudentRepository>();
            //services.AddScoped<IManagerRepository, ManagerRepository>();
            //var connection = Configuration.GetConnectionString("sqlserver");
            //services.AddDbContextPool<DataDBContext>(options => options.UseSqlServer(connection));
        }
        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DefaultModuleRegister>();
            //Services.AddModule(builder, Configuration);
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
