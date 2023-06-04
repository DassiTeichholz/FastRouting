using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ITheCenterPhotoService
    {
        Task<List<TheCenterPhotoDTO>> GetAllAsync();
        Task<List<TheCenterPhotoDTO>> GetByZAsync(int z, int centerId);
        Task<TheCenterPhotoDTO> GetByIDAsync(int ID);
        Task<TheCenterPhotoDTO> AddAsync(TheCenterPhotoDTO TheCenterPhotoRepository);
        Task<TheCenterPhotoDTO> UpdateAsync(TheCenterPhotoDTO TheCenterPhotoRepository);
        Task DeleteAsync(int Id);//מחיקה לפי מזהה הצטלבות
    }
}
