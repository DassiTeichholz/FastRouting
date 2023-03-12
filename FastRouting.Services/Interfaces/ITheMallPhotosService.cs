using FastRouting.Common.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ITheMallPhotosService
    {
        Task<List<TheMallPhotosDTO>> GetAllAsync();
        Task<TheMallPhotosDTO> GetByIDAsync(int ID);
        Task<TheMallPhotosDTO> AddAsync(TheMallPhotosDTO TheMallPhotosRepository);
        Task<TheMallPhotosDTO> UpdateAsync(TheMallPhotosDTO TheMallPhotosRepository);
        Task DeleteAsync(int Id);//מחיקה לפי מזהה הצטלבות
    }
}
