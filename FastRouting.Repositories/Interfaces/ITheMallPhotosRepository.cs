using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ITheMallPhotosRepository
    {
        Task<List<TheMallPhotos>> GetAllAsync();
        Task<List<TheMallPhotos>> GetByZAsync(int z);
        Task<TheMallPhotos> GetByIdAsync(int id);
        Task<TheMallPhotos> AddAsync(TheMallPhotos TheMallPhotos);
        Task<TheMallPhotos> UpdateAsync(TheMallPhotos TheMallPhotos);
        Task DeleteAsync(int id);
    }
}
