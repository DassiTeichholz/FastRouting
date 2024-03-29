﻿using FastRouting.Repositories.Entities;
using FastRouting.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FastRouting.Repositories.Repositories
{
    public class CoordinateRepository : ICoordinateRepository
    {
        private readonly IContext _context;

        public CoordinateRepository(IContext context)
        {
            _context = context;
        }

        //public async Task<Subject> AddAsync(Subject subject)
        //{
        //    var addedSubject = await _context.Subjects.AddAsync(subject);
        //    await _context.SaveChangesAsync();
        //    return addedSubject.Entity;
        //}
        public async Task<Coordinate> AddAsync(Coordinate Coordinate)
        {
             var item=await _context.Coordinate.AddAsync(Coordinate);
            await _context.SaveChangesAsync();
            return item.Entity;
        }

        public async Task DeleteAsync(int id)
        {

            var Coordinate = await GetByIdAsync(id);
            _context.Coordinate.Remove(Coordinate);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Coordinate>> GetAllAsync()
        {
            return await _context.Coordinate.ToListAsync();
        }

        public async Task<Coordinate> GetByIdAsync(int id)
        {
            return await _context.Coordinate.FindAsync(id);
        }

        public async Task<Coordinate> UpdateAsync(Coordinate Coordinate)
        {
            var updatedCoordinate = _context.Coordinate.Update(Coordinate);
            await _context.SaveChangesAsync();
            return updatedCoordinate.Entity;
        }
    }
}
