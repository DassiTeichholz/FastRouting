﻿using FastRouting.Repositories;
using FastRouting.Services.Interfaces;
using FastRouting.Services.Interfaces.ILogic;
using FastRouting.Services.Services;
using FastRouting.Services.Services.Logic;
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
            services.AddScoped<ICentersService, CentersService>();

            services.AddScoped<ITransitionsService, TransitionsService>();
            
            services.AddScoped<ITransitionsToIntersectionsService, TransitionsToIntersectionsServer>();
            services.AddScoped<ITheCenterPhotoService, TheCenterPhotoService>();
            services.AddScoped<IAddingACenter, AddingACenter>();
            services.AddScoped<IRouteCalculation, RouteCalculation>();

            services.AddAutoMapper(typeof(MappingProfile));

            return services;
        }
    }
}
