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
    public class TheCenterPhotoRepository : ITheCenterPhotoRepository
    {
        private readonly IContext _context;
        public TheCenterPhotoRepository(IContext context)
        {
            _context = context;
        }
        public async Task<TheCenterPhoto> AddAsync(TheCenterPhoto TheCenterPhoto)
        {
            await _context.TheCenterPhoto.AddAsync(TheCenterPhoto);
            await _context.SaveChangesAsync();
            return TheCenterPhoto;
        }

        public async Task DeleteAsync(int id)
        {

            var TheCenterPhoto = await GetByIdAsync(id);
            _context.TheCenterPhoto.Remove(TheCenterPhoto);
            await _context.SaveChangesAsync();

        }

        public async Task<List<TheCenterPhoto>> GetAllAsync()
        {
            return await _context.TheCenterPhoto.ToListAsync();

        }
        public async Task<List<TheCenterPhoto>> GetByZAsync(int z)
        {
            return await _context.TheCenterPhoto.Where(x=>x.floor==z).ToListAsync();

        }

        public async Task<TheCenterPhoto> GetByIdAsync(int id)
        {
            return await _context.TheCenterPhoto.FindAsync(id);

        }

        public async Task<TheCenterPhoto> UpdateAsync(TheCenterPhoto TheCenterPhoto)
        {
            var updatedTheCenterPhoto = _context.TheCenterPhoto.Update(TheCenterPhoto);
            await _context.SaveChangesAsync();
            return updatedTheCenterPhoto.Entity;

        }
    }
}
