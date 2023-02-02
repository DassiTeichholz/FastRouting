﻿using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoordinateDTO, Coordinate>().ReverseMap();
            CreateMap<EdgesDTO, Edges>().ReverseMap();

            CreateMap<IntersectionsDTO, Intersections>().ReverseMap();

            CreateMap<LocationsDTO, Locations>().ReverseMap();

            CreateMap<LocationTypesDTO, LocationTypes>().ReverseMap();

            CreateMap<ShoppingMallsDTO, shoppingMalls>().ReverseMap();

            CreateMap<TransitionsDTO, Transitions>().ReverseMap();

            CreateMap<TransitionsToIntersectionsDTO, TransitionsToIntersections>().ReverseMap();


        }
    }
}
