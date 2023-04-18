using AutoMapper;
using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using FastRouting.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Services
{
    public class IntersectionsService : IIntersectionsService
    {
        private readonly IIntersectionsRepository _IntersectionsRepository;
        private readonly IMapper _mapper;
        public IntersectionsService(IIntersectionsRepository IntersectionsRepository, IMapper mapper)
        {
            _IntersectionsRepository = IntersectionsRepository;
            _mapper = mapper;
        }
        public async Task<IntersectionsDTO> AddAsync(IntersectionsDTO Intersections)
        {
            return _mapper.Map<IntersectionsDTO>(await _IntersectionsRepository.AddAsync(_mapper.Map<Intersections>(Intersections)));

        }

        public async Task DeleteAsync(int IntersectionID)
        {
            await _IntersectionsRepository.DeleteAsync(IntersectionID);
        }

        public async Task<List<IntersectionsDTO>> GetAllAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<List<IntersectionsDTO>>(await _IntersectionsRepository.GetAllAsync());
        }

        public async Task<IntersectionsDTO> GetByIdAsync(int IntersectionID)
        {
            return _mapper.Map<IntersectionsDTO>(await _IntersectionsRepository.GetByIdAsync(IntersectionID));

        }
        public async Task<List<IntersectionsDTO>> GetBycenterIdAsync(int id)
        {
            return _mapper.Map<List<IntersectionsDTO>>(await _IntersectionsRepository.GetBycenterIdAsync(id));

        }

        public async Task<IntersectionsDTO> UpdateAsync(IntersectionsDTO Intersections)
        {
            return _mapper.Map<IntersectionsDTO>(await _IntersectionsRepository.UpdateAsync(_mapper.Map<Intersections>(Intersections)));

        }
        public async Task Bla(bool flag)
        {
            DataPreparation.DataPreparationFunc();
        }
    }
}
