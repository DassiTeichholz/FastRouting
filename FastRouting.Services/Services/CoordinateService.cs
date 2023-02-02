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
    public class CoordinateService : ICoordinateService
    {
        private readonly ICoordinateRepository _CoordinateRepository;
        private readonly IMapper _mapper;
        public CoordinateService(ICoordinateRepository CoordinateRepository, IMapper mapper)
        {
            _CoordinateRepository = CoordinateRepository;
            _mapper = mapper;
        }
        public async  Task<CoordinateDTO> AddAsync(CoordinateDTO CoordinateDTO)
        {
            return _mapper.Map<CoordinateDTO>(await _CoordinateRepository.AddAsync(_mapper.Map < Coordinate > (CoordinateDTO)));
        }

        public async Task DeleteAsync(int id)
        {
            await _CoordinateRepository.DeleteAsync(id);
        }

        public async Task<List<CoordinateDTO>> GetAllAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<List<CoordinateDTO>>(await _CoordinateRepository.GetAllAsync());
        }

        public async Task<CoordinateDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<CoordinateDTO>(await _CoordinateRepository.GetByIdAsync(id));
        }

        public async Task<CoordinateDTO> UpdateAsync(CoordinateDTO CoordinateDTO)
        {
            return _mapper.Map<CoordinateDTO>(await _CoordinateRepository.UpdateAsync(_mapper.Map<Coordinate>(CoordinateDTO)));
        }
    }
}
