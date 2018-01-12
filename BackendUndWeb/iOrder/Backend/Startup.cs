using Backend.Converters;
using Backend.Converters.EntityBusiness;
using Backend.Models.Business;
using Backend.Models.Entity;
using Backend.Repositories.Implementation;
using Backend.Repositories.Interface;
using Backend.Services.Implementation;
using Backend.Services.Interface;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Backend
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = (IConfigurationRoot)configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {

            // add dependecy injection 

            services.AddScoped<IConverter<RoleEntity, Role>, RoleEntityToModelConverter>();
            services.AddScoped<IConverter<Role, RoleEntity>, RoleModelToEntityConverter>();
            services.AddScoped<IRoleRepository, RoleRepository>();

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

            services.AddScoped<IConverter<OwnerEntity, Owner>, OwnerEntityToModelConverter>();
            services.AddScoped<IConverter<Owner, OwnerEntity>, OwnerModelToEntityConverter>();
            services.AddScoped<IOwnerRepository, OwnerRepository>();

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


            services.AddScoped<IConverter<OrderPairEntity, OrderPair>, OrderPairEntityToModelConverter>();
            services.AddScoped<IConverter<OrderPair, OrderPairEntity>, OrderPairModelToEntityConverter>();

            services.AddScoped<IRoleService, RoleService>();


            // add Authentication

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

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole();
            loggerFactory.AddDebug();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseAuthentication();
            app.UseMvc();
        }
    }
}
