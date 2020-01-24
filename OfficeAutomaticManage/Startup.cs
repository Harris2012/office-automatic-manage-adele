using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MySql.Data.MySqlClient;
using Canos.OfficeAutomatic.Configure;
using Canos.OfficeAutomatic.Repository.Mysql;
using Microsoft.Net.Http.Headers;

namespace Canos.OfficeAutomatic
{
    public partial class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            var connectionString = Configuration.GetConnectionString("localhost");
            services.AddTransient(v => new MySqlConnection(connectionString));
            services.AddSingleton(new MysqlConnectionProvider(connectionString));
            services
                .AddRepositoryServices()
                .AddConvertorServices()
                .AddProviderServices()
                .AddLookupProviderServices();

            ExternalConfigureServices(services);

            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp";
            });

            var iMvcBuilder = services.AddControllers(options =>
            {
                options.Filters.Add(new GlobalExceptionFilter());
            });

            ConfigureIMvc(iMvcBuilder);
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
            }

            app.UseSpaStaticFiles();

            app.UseCors(v => v.AllowAnyOrigin().WithHeaders(HeaderNames.ContentType));

            //app.UseAuthentication();

            app.UseRouting();

            app.UseSpa(builder =>
            {
                builder.Options.SourcePath = "ClientApp";
                builder.Options.DefaultPage = "/index.html";
            });

            InternalConfigure(app, env);

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(name: "default", pattern: "api/{controller}/{action}");
            });
        }
    }
}
