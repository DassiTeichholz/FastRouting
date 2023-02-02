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
    public class TransitionsToIntersectionsServer : ITransitionsToIntersectionsService
    {
        private readonly ITransitionsToIntersectionsRepository _TransitionsToIntersectionsRepository;
        private readonly IMapper _mapper;
        public TransitionsToIntersectionsServer(ITransitionsToIntersectionsRepository TransitionsToIntersectionsRepository, IMapper mapper)
        {
            _TransitionsToIntersectionsRepository = TransitionsToIntersectionsRepository;
            _mapper = mapper;
        }

        public async Task<TransitionsToIntersectionsDTO> AddAsync(TransitionsToIntersectionsDTO TransitionsToIntersections)
        {
            return _mapper.Map<TransitionsToIntersectionsDTO>(await _TransitionsToIntersectionsRepository.AddAsync(_mapper.Map<TransitionsToIntersections>(TransitionsToIntersections)));

        }

        public async Task DeleteByIdIdAsync(int IntersectionID, int TransitionId)
        {
            await _TransitionsToIntersectionsRepository.DeleteByIdIdAsync(IntersectionID, TransitionId);
        }

        public async Task<List<TransitionsToIntersectionsDTO>> GetAllAsync()
        {
            return _mapper.Map<List<TransitionsToIntersectionsDTO>>(await _TransitionsToIntersectionsRepository.GetAllAsync());
        }

        public async Task<TransitionsToIntersectionsDTO> GetByIdIdAsync(int IntersectionID, int TransitionId)
        {
            return _mapper.Map<TransitionsToIntersectionsDTO>(await _TransitionsToIntersectionsRepository.GetByIdIdAsync(IntersectionID,  TransitionId));
        }

        public async Task<TransitionsToIntersectionsDTO> UpdateAsync(TransitionsToIntersectionsDTO TransitionsToIntersections)
        {
            return _mapper.Map<TransitionsToIntersectionsDTO>(await _TransitionsToIntersectionsRepository.UpdateAsync(_mapper.Map<TransitionsToIntersections>(TransitionsToIntersections)));

        }
    }
}
