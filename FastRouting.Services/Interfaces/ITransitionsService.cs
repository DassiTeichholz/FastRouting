using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ITransitionsService
    {
        Task<List<TransitionsDTO>> GetAllAsync();
        Task<TransitionsDTO> GetByIdAsync(int id);

        Task<TransitionsDTO> AddAsync(TransitionsDTO Transitions);
        Task<TransitionsDTO> UpdateAsync(TransitionsDTO Transitions);
        Task DeleteAsync(int id);
    }
}
