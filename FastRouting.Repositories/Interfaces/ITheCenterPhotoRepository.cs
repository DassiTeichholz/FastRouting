using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ITheCenterPhotoRepository
    {
        Task<List<TheCenterPhoto>> GetAllAsync();
        Task<List<TheCenterPhoto>> GetByZAsync(int z,int centerId);
        Task<TheCenterPhoto> GetByIdAsync(int id);
        Task<TheCenterPhoto> AddAsync(TheCenterPhoto TheCenterPhoto);
        Task<TheCenterPhoto> UpdateAsync(TheCenterPhoto TheCenterPhoto);
        Task DeleteAsync(int id);
    }
}
