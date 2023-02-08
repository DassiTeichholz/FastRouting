using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Interfaces
{
    public interface ITransitionsRepository
    {
        Task<List<Transition>> GetAllAsync();
        Task<Transition> GetByIdAsync(int id);

        Task<Transition> AddAsync(Transition Transitions);
        Task<Transition> UpdateAsync(Transition Transitions);
        Task DeleteAsync(int id);
    }
}
