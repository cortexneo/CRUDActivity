using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.AngularCli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shipping.EFCore.Domain;
using Shipping.EFCore.Infra;
using Shipping.EFCore.WebApi.Utils;
using ShippingProject.EFCore.Infra;
using Swashbuckle.AspNetCore.Swagger;
using System.Data.SqlClient;

namespace Shipping.EFCore.WebApi
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

            var onlineStoreSettings = Configuration.GetSection("ShippingSettings")
                                .Get<ShippingSettings>();

            services.AddSingleton<ShippingSettings>(onlineStoreSettings);
            services.AddMvcCore().AddApiExplorer();

            //services.AddSingleton<OnlineStoreDbContext>();
            services.AddDbContext<ShippingDbContext>(options =>
            {
                var connectionString = Configuration["ShippingSettings:ConnectionString"];
                var password = Configuration["DbPassword"];
                var builder = new SqlConnectionStringBuilder(connectionString);
                //builder.Password = password;
                var connection = builder.ConnectionString;
                options.UseSqlServer(connection);
            });

            services.AddTransient<IEmployeeRepository, EmployeeRepository>();
            services.AddTransient<ICategoryRepository, CategoryRepository>();
            services.AddTransient<ICustomerRepository, CustomerRepository>();
            services.AddTransient<IOrderDetailRepository, OrderDetailRepository>();
            services.AddTransient<IOrderRepository, OrderRepository>();
            services.AddTransient<IShipperRepository, ShipperRepository>();
            services.AddTransient<ISupplierRepository, SupplierRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IDealerRepository, DealerRepository>();
            services.AddTransient<IPersonRepository, PersonRepository>();
            services.AddTransient<ILaptopRepository, LaptopRepository>();
            services.AddTransient<IResponsibilityRepository, ResponsibilityRepository>();

            services.AddMvcCore()
                .AddAuthorization()
                .AddJsonFormatters()
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddCors(config =>
            {
                config.AddPolicy("OnlineStoreAngular6", policy =>
                {
                    policy.AllowAnyMethod();
                    policy.AllowAnyHeader();
                    policy.AllowAnyOrigin();
                    policy.AllowCredentials();
                    //policy.WithOrigins("http://localhost:4200", "http://localhost:4200/");

                });
            });

            services.AddAuthentication("Bearer")
                .AddIdentityServerAuthentication(options =>
                {
                    options.Authority = "https://localhost:44350";
                    options.RequireHttpsMetadata = true;
                    options.ApiName = "onlinestoreapi";
                });



            // Security services
            //services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            //        .AddJwtBearer(options =>
            //       {
            //           options.Authority = "";
            //           options.Audience = "";
            //       });

            // Register Swagger Generator
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1",
                    new Info { Title = "OnlineStore API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }


            app.UseHttpsRedirection();
            app.UseAuthentication();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json",
                    "OnlineStore API v1");
            });


            //app.UseCors(builder =>
            //    builder.WithOrigins("https://localhost:5001"));

            app.UseCors("OnlineStoreAngular6");
            app.UseMvc();
        }
    }
}