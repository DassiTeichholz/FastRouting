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
    public class EdgesService : IEdgesService
    {
        private readonly IEdgesRepository _EdgesRepository;
        private readonly IMapper _mapper;
        public EdgesService(IEdgesRepository EdgesServiceRepository, IMapper mapper)
        {
            _EdgesRepository = EdgesServiceRepository;
            _mapper = mapper;
        }
        public async Task<EdgesDTO> AddAsync(EdgesDTO Edges)
        {
            return _mapper.Map<EdgesDTO>(await _EdgesRepository.AddAsync(_mapper.Map<Edges>(Edges)));

        }

        public async Task DeleteAsync(int LocationIdA)
        {
            await _EdgesRepository.DeleteAsync(LocationIdA);
        }

        public async Task<List<EdgesDTO>> GetAllAsync()
        {
            //לוגיקה עסקית
            return _mapper.Map<List<EdgesDTO>>(await _EdgesRepository.GetAllAsync());
        }

        public async Task<EdgesDTO> GetByIdAsync(int Id)
        {
            return _mapper.Map<EdgesDTO>(await _EdgesRepository.GetByIdAsync(Id));
          
        }

        public async Task<EdgesDTO> UpdateAsync(EdgesDTO Edges)
        {
            return _mapper.Map<EdgesDTO>(await _EdgesRepository.UpdateAsync(_mapper.Map<Edges>(Edges)));

        }
    }
}
