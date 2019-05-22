using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Infra.Data;
using Microsoft.EntityFrameworkCore;
using App.Domain.Interface.Service;
using App.Domain.Implementation;
using App.Domain.Interface.Repository;
using Infra.Repository;

namespace UI.AppWeb
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

            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            services.AddSingleton(typeof(IValidatorService), typeof(ValidatorImplement));

            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

            services.AddTransient(typeof(IEmpresaRepository), typeof(EnpresaRepository));
            services.AddTransient(typeof(IEnderecoRepository), typeof(EnderecoRepository));

            services.AddTransient(typeof(IEmpresaService), typeof(EmpresaImplement));
            services.AddTransient(typeof(IEnderecoService), typeof(EnderecoImplement));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
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
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Empresa}/{action=Index}/{id?}");
            });
        }
    }
}
