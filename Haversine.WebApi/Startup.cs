using AutoMapper;
using Haversine.Data;
using Haversine.Service.Models;
using Haversine.WebApi.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Haversine.WebApi
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
            var connectionString = Configuration.GetConnectionString("DefaultConnection");

            services.AddSingleton(Configuration);

            services.AddDbContext<HaversineDbContext>(opt => opt.UseSqlServer(connectionString));

            services.AddMvc();

            services.AddScoped<ILocationRepository, LocationRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            Mapper.Initialize(config =>
            {
                config.CreateMap<Origin, Coordinate>();
                config.CreateMap<Destination, LocationDistance>(); // TODO: Reverse this?
            });

            app.UseMvc();
        }
    }
}
