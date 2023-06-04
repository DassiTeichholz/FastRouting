using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CoordinateDTO, Coordinate>().ReverseMap();
            CreateMap<EdgesDTO, Edges>().ReverseMap();

            CreateMap<IntersectionsDTO, Intersections>().ReverseMap();

            CreateMap<LocationsDTO, Location>().ReverseMap();

            CreateMap<LocationTypesDTO, LocationTypes>().ReverseMap();

            CreateMap<CentersDTO, Centers>().ReverseMap();

            CreateMap<TransitionsDTO, Transition>().ReverseMap();

            CreateMap<TransitionsToIntersectionsDTO, TransitionsToIntersections>().ReverseMap();
            CreateMap<TheCenterPhotoDTO, TheCenterPhoto>().ReverseMap();


        }
    }
}
