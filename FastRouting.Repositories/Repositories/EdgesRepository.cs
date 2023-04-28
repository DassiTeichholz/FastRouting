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
    public class EdgesRepository : IEdgesRepository
    {
        private readonly IContext _context;
        public EdgesRepository(IContext context)
        {
            _context = context;
        }

        public async Task<Edges> AddAsync(Edges Edges)
        {
            await _context.Edges.AddAsync(Edges);
            await _context.SaveChangesAsync();
            return Edges;
        }

        public async Task DeleteAsync(int Id)
        {
            var Edges = await GetByLocationIdAAsync(Id);
            _context.Edges.Remove(Edges);
            await _context.SaveChangesAsync();
        }

        public async Task  DeleteEdgesOfIdAsync(int id)
        {
            var Edges = await GetByLocationIdAAsync(id);
            _context.Edges.Remove(Edges);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Edges>> GetAllAsync()
        {
            return await _context.Edges.ToListAsync();
        }
        public async Task<List<Edges>> GetByCenterIdAsync(int id)
        {
            return await _context.Edges.Where(x=>x.centerId==id).ToListAsync();
        }

        public async Task<Edges> GetByLocationIdAAsync(int Id)
        {
            return  _context.Edges.FirstOrDefault(x=>x.locationIdA==Id);
        }
        public async Task<Edges> GetByLocationIdBAsync(int Id)
        {
            return  _context.Edges.FirstOrDefault(x => x.locationIdB == Id);
        }
        public async Task<Edges> UpdateAsync(Edges Edges)
        {
            var Edge = _context.Edges.Update(Edges);
            await _context.SaveChangesAsync();
            return Edge.Entity;
        }
    }
}
