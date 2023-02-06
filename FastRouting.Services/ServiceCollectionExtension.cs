using FastRouting.Repositories;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services
{
     public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddRepositories();
            services.AddScoped<ICoordinateService, CoordinateService>();
            services.AddScoped<IEdgesService, EdgesService>();
            services.AddScoped<IIntersectionsService, IntersectionsService>();
            services.AddScoped<ILocationsService, LocationsService>();
            services.AddScoped<ILocationTypesService, LocationTypesService>();
            services.AddScoped<IshoppingMallsService, shoppingMallsService>();

            services.AddScoped<ITransitionsService, TransitionsService>();
            
            services.AddScoped<ITransitionsToIntersectionsService, TransitionsToIntersectionsServer>();
            services.AddScoped<ITheMallPhotosService, TheMallPhotosService>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
