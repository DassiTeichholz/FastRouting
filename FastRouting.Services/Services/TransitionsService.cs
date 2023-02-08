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
    public class TransitionsService : ITransitionsService
    {
        private readonly ITransitionsRepository _TransitionsRepository;
        private readonly IMapper _mapper;
        public TransitionsService(ITransitionsRepository TransitionsRepository, IMapper mapper)
        {
            _TransitionsRepository = TransitionsRepository;
            _mapper = mapper;
        }

        public async Task<TransitionsDTO> AddAsync(TransitionsDTO Transitions)
        {
            return _mapper.Map<TransitionsDTO>(await _TransitionsRepository.AddAsync(_mapper.Map<Transition>(Transitions)));

        }

        public async Task DeleteAsync(int id)
        {
            await _TransitionsRepository.DeleteAsync(id);
        }

        public async Task<List<TransitionsDTO>> GetAllAsync()
        {
            return _mapper.Map<List<TransitionsDTO>>(await _TransitionsRepository.GetAllAsync());

        }

        public async Task<TransitionsDTO> GetByIdAsync(int id)
        {
            return _mapper.Map<TransitionsDTO>(await _TransitionsRepository.GetByIdAsync(id));

        }

        public async Task<TransitionsDTO> UpdateAsync(TransitionsDTO Transitions)
        {
            return _mapper.Map<TransitionsDTO>(await _TransitionsRepository.UpdateAsync(_mapper.Map<Transition>(Transitions)));

        }
    }
}
