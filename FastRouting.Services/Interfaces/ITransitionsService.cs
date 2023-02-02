﻿using FastRouting.Repositories.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Services.Interfaces
{
    public interface ITransitionsService
    {
        Task<List<Transitions>> GetAllAsync();
        Task<Transitions> GetByIdAsync(int id);

        Task<Transitions> AddAsync(Transitions Transitions);
        Task<Transitions> UpdateAsync(Transitions Transitions);
        Task DeleteAsync(int id);
    }
}
