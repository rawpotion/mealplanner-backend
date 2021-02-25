using KaerligHilsen.Api.Database;
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
                .AddTransient<IProductsRepository, ProductsRepository>()
                .AddDbContextPool<ApplicationDbContext>(
                    options => options.UseSqlite("Data Source=kaerlighilsen.db"))
                .AddGraphQLServer()
                .AddQueryType<ProductsQuery>()
                .AddMutationType<ProductsMutation>()
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

            app.UseEndpoints(endpoints => { endpoints.MapGraphQL(); });
        }
    }
}