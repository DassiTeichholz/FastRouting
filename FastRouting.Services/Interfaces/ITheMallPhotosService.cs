using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    internal interface ITheMallPhotosService
    {
        Task<List<TheMallPhotosRepositoryDTO>> GetAllAsync();
        Task<TheMallPhotosRepositoryDTO> GetByIDAsync(int ID);
        Task<TheMallPhotosRepositoryDTO> AddAsync(TheMallPhotosRepositoryDTO TheMallPhotosRepository);
        Task<TheMallPhotosRepositoryDTO> UpdateAsync(TheMallPhotosRepositoryDTO TheMallPhotosRepository);
        Task DeleteAsync(int Id);//מחיקה לפי מזהה הצטלבות
    }
}
