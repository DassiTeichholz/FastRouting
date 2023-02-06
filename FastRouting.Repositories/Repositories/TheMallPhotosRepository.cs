using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories.Repositories
{
    public class TheMallPhotosRepository : ITheMallPhotosRepository
    {
        private readonly IContext _context;
        public async Task<TheMallPhotos> AddAsync(TheMallPhotos TheMallPhotos)
        {
            await _context.TheMallPhotos.AddAsync(TheMallPhotos);
            await _context.SaveChangesAsync();
            return TheMallPhotos;
        }

        public async Task DeleteAsync(int id)
        {

            var TheMallPhotos = await GetByIdAsync(id);
            _context.TheMallPhotos.Remove(TheMallPhotos);
            await _context.SaveChangesAsync();

        }

        public async Task<List<TheMallPhotos>> GetAllAsync()
        {
            return await _context.TheMallPhotos.ToListAsync();

        }

        public async Task<TheMallPhotos> GetByIdAsync(int id)
        {
            return await _context.TheMallPhotos.FindAsync(id);

        }

        public async Task<TheMallPhotos> UpdateAsync(TheMallPhotos TheMallPhotos)
        {
            var updatedTheMallPhotos = _context.TheMallPhotos.Update(TheMallPhotos);
            await _context.SaveChangesAsync();
            return updatedTheMallPhotos.Entity;

        }
    }
}
