using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Backend.CommunicationServices;
using Backend.CommunicationServices.Implementation;
using Backend.Converters;
using Backend.Converters.EntityBusiness;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Notifications.Observable;
using Backend.Repositories.Implementation;
using Backend.Repositories.Interface;
using Backend.Services.Implementation;
using Backend.Services.Interface;
using Frontend.Observer;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;

namespace Frontend
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
            services.AddScoped<IConverter<RoleEntity, Role>, RoleEntityToModelConverter>();
            services.AddScoped<IConverter<Role, RoleEntity>, RoleModelToEntityConverter>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IRoleService, RoleService>();

            services.AddScoped<IConverter<CategoryEntity, Category>, CategoryEntityToModelConverter>();
            services.AddScoped<IConverter<Category, CategoryEntity>, CategoryModelToEntityConverter>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<ICategoryService, CategoryService>();


            services.AddScoped<IConverter<EstablishmentEntity, Establishment>, EstablishmentEntityToModelConverter>();
            services.AddScoped<IConverter<Establishment, EstablishmentEntity>, EstablishmentModelToEntityConverter>();
            services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
            services.AddScoped<IEstablishmentService, EstablishmentService>();


            services.AddScoped<IConverter<LocationEntity, Location>, LocationEntityToModelConverter>();
            services.AddScoped<IConverter<Location, LocationEntity>, LocationModelToEntityConverter>();
            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocationService, LocationService>();


            services.AddScoped<IConverter<OrderEntity, Order>, OrderEntityToModelConverter>();
            services.AddScoped<IConverter<Order, OrderEntity>, OrderModelToEntityConverter>();
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();


            services.AddScoped<IConverter<ProductEntity, Product>, ProductEntityToModelConverter>();
            services.AddScoped<IConverter<Product, ProductEntity>, ProductModelToEntityConverter>();
            services.AddScoped<IProductRepository, ProductRepository>();
            services.AddScoped<IProductService, ProductService>();


            services.AddScoped<IConverter<UserEntity, User>, UserEntityToModelConverter>();
            services.AddScoped<IConverter<User, UserEntity>, UserModelToEntityConverter>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();


            services.AddScoped<IConverter<WarehouseEntity, Warehouse>, WarehouseEntityToModelConverter>();
            services.AddScoped<IConverter<Warehouse, WarehouseEntity>, WarehouseModelToEntityConverter>();
            services.AddScoped<IWarehouseRepository, WarehouseRepository>();
            services.AddScoped<IWarehouseService, WarehouseService>();


            services.AddScoped<IConverter<SupplierEntity, Supplier>, SupplierEntityToModelConverter>();
            services.AddScoped<IConverter<Supplier, SupplierEntity>, SupplierModelToEntityConverter>();
            services.AddScoped<ISupplierRepository, SupplierRepository>();
            services.AddScoped<ISupplierService, SupplierService>();


            services.AddScoped<IConverter<OrderPairEntity, OrderPair>, OrderPairEntityToModelConverter>();
            services.AddScoped<IConverter<OrderPair, OrderPairEntity>, OrderPairModelToEntityConverter>();

            services.AddScoped<ICommunicationService, EmailService>();

            services.AddScoped<IObservable, NotificationObservable>();

            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // SignalR support
            services.AddSignalR();
            services.AddSingleton<OrdersHub>();


            // add auth

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
                )
                .AddJwtBearer(jwtBearerOptions =>
                {
                    jwtBearerOptions.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ValidateActor = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = "iOrder.fer.hr",
                        ValidAudience = "iOrder.fer.hr",
                        IssuerSigningKey =
                            new SymmetricSecurityKey(Encoding.UTF8.GetBytes("System.ArgumentOutOfRangeException"))
                    };
                });


            services.AddMvc().AddSessionStateTempDataProvider();

            // session support
            services.AddDistributedMemoryCache();
            services.AddSession();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Orders/Error");
            }

            // SignalR hub route
            app.UseSignalR(routes =>
            {
                routes.MapHub<OrdersHub>("ordershub");
            });

            app.UseStaticFiles();
            app.UseSession();
            app.UseAuthentication();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Orders}/{action=Index}/{id?}");
            });
        }
    }
}
