using FastRouting.Common.DTO;
using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface IEdgesService
    {
        Task<List<EdgesDTO>> GetAllAsync();
        Task<EdgesDTO> GetByIdAsync(int Id);
        Task<EdgesDTO> AddAsync(EdgesDTO Edges);
        Task<EdgesDTO> UpdateAsync(EdgesDTO Edges);
        Task DeleteAsync(int LocationIdA);
    }
}
