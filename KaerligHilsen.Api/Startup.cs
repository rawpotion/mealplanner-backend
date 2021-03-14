using KaerligHilsen.Api.Database;
using KaerligHilsen.Api.Features.Orders;
using KaerligHilsen.Api.Features.Orders.Mutations;
using KaerligHilsen.Api.Features.Orders.Queries;
using KaerligHilsen.Api.Features.Products;
using KaerligHilsen.Api.Features.Products.Query;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace KaerligHilsen.Api
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
            => services
                .AddControllers().Services
                .AddTransient<IProductsRepository, ProductsRepository>()
                .AddTransient<IOrderRepository, OrderRepository>()
                .AddDbContextPool<ApplicationDbContext>(
                    options => options.UseSqlite("Data Source=kaerlighilsen.db"))
                .AddCors(options => options
                    .AddDefaultPolicy(policy
                        => policy
                            .WithOrigins("http://localhost")
                            .AllowCredentials()
                            .AllowAnyHeader()
                            .AllowAnyMethod()))
                .AddGraphQLServer()
                .AddQueryType(d => d.Name("Query"))
                .AddTypeExtension<ProductsQuery>()
                .AddTypeExtension<OrdersQuery>()
                .AddMutationType(d => d.Name("Mutation"))
                .AddTypeExtension<ProductsMutation>()
                .AddTypeExtension<OrderMutation>()
                .AddDataLoader<ProductByIdDataLoader>();

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseCors(options => options.WithOrigins("http://localhost:3000", "http://localhost").AllowAnyHeader().AllowAnyMethod().AllowCredentials());
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapGraphQL();
            });
        }
    }
}