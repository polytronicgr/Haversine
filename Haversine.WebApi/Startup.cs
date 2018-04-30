using AutoMapper;
using Haversine.Data;
using Haversine.Service;
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

            services.AddScoped<ILocationRepository, LocationRepository>();
            services.AddScoped<ILocator, Locator>();

            services.AddMvc();
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
                config.CreateMap<Service.Models.Location, Data.Entities.Location>()
                    .ForMember(m => m.Latitude, opt => opt.MapFrom(e => e.Coordinate.Latitude))
                    .ForMember(m => m.Longitude, opt => opt.MapFrom(e => e.Coordinate.Longitude))
                    .ReverseMap();

                config.CreateMap<Service.Models.LocationDistance, Destination>()
                    .ForMember(m => m.Name, opt => opt.MapFrom(e => e.Location.Name))
                    .ForMember(m => m.Latitude, opt => opt.MapFrom(e => e.Location.Coordinate.Latitude))
                    .ForMember(m => m.Longitude, opt => opt.MapFrom(e => e.Location.Coordinate.Longitude))
                    .ReverseMap();

                config.CreateMap<Origin, Service.Models.Coordinate>()
                    .ReverseMap();

                config.CreateMap<Location, Data.Entities.Location>()
                    .ReverseMap();
            });

            app.UseMvc();
        }
    }
}
