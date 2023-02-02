using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ICoordinateRepository
    {
        Task<List<Coordinate>> GetAllAsync();
        Task<Coordinate> GetByIdAsync(int id);
        Task<Coordinate> AddAsync(Coordinate Coordinate);
        Task<Coordinate> UpdateAsync(Coordinate Coordinate);
        Task DeleteAsync(int id);

        
    }
}
