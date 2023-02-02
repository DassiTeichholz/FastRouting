using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FastRouting.Services.Interfaces;
using FastRouting.Common.DTO;



namespace FastRouting.Services.Interfaces
{
    public interface ICoordinateDTOService
    {
        Task<List<CoordinateDTO>> GetAllAsync();
        Task<CoordinateDTO> GetByIdAsync(int id);
        Task<CoordinateDTO> AddAsync(CoordinateDTO CoordinateDTO);
        Task<CoordinateDTO> UpdateAsync(CoordinateDTO CoordinateDTO);
        Task DeleteAsync(int id);
    }
}
