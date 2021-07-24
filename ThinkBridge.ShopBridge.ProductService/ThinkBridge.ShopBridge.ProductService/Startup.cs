using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using ThinkBridge.ShopBridge.ProductService.Data.Persistence;
using ThinkBridge.ShopBridge.ProductService.Library.Constants;
using ThinkBridge.ShopBridge.ProductService.Repository;
using ThinkBridge.ShopBridge.ProductService.Repository.Interface;

namespace ThinkBridge.ShopBridge.ProductService.Api
{
    /// <summary>
    /// Startup class register all basic components required need to registered and used by application for the project.
    /// </summary>
    public class Startup
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Startup"/> class.
        /// </summary>
        /// <param name="configuration">The configuration.</param>
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        /// <summary>
        /// Gets the entire configuration from application settings json file.
        /// </summary>
        /// <value>
        /// The configuration.
        /// </value>
        public IConfiguration Configuration { get; }

        /// <summary>
        /// Configures the services which need to be registered with container and policies etc.
        /// This method gets called by the runtime. Use this method to add services to the container.
        /// </summary>
        /// <param name="services">The services.</param>
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<ServiceDbContext>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();

            services.AddCors(options =>
            {
                options.AddPolicy(ServiceConstants.CorsPolicyName,
                    builder => builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .Build());
            });
            services.AddDistributedMemoryCache();
            services.AddSession();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc(ServiceConstants.SwaggerVersion, new OpenApiInfo()
                {
                    Title = ServiceConstants.ProjectName,
                    Version = ServiceConstants.SwaggerVersion,
                    Description = ServiceConstants.SwaggerDescription
                });
            });

            services.AddControllers().AddNewtonsoftJson(options =>
            {
                options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });
        }

        /// <summary>
        /// Configures the specified application by using register services in ConfigureServices method.
        /// This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        /// </summary>
        /// <param name="app">The application.</param>
        /// <param name="env">The environment</param>
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseAuthorization();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(ServiceConstants.SwaggerJson, ServiceConstants.ProjectName);
            });
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
