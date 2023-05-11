using FastRouting.Repositories.Interfaces;
using FastRouting.Repositories.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories
{
     public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ICoordinateRepository, CoordinateRepository>();
            services.AddScoped<IEdgesRepository, EdgesRepository>();
            services.AddScoped<IIntersectionsRepository, IntersectionsRepository>();
            services.AddScoped<ILocationsRepository, LocationsRepository>();
            services.AddScoped<ILocationTypesRepository, LocationTypesRepository>();
            services.AddScoped<ITransitionsRepository, TransitionsRepository>();
            services.AddScoped<ITransitionsToIntersectionsRepository, TransitionsToIntersectionsRepository>();
            services.AddScoped<ICentersRepository, CentersRepository>();
            services.AddScoped<ITheCenterPhotoRepository, TheCenterPhotoRepository>();
            return services;
        }
    }
}
