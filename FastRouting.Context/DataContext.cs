﻿using FastRouting.Repositories;
using FastRouting.Repositories.Entities;
using Microsoft.EntityFrameworkCore;

namespace FastRouting.Context
{
    public class DataContext : DbContext, IContext
    {
        public DbSet<Coordinate> Coordinate { get; set; }
        public DbSet<Edges> Edges { get; set; }
        public DbSet<Intersections> Intersections { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<LocationTypes> LocationTypes { get; set; }
        public DbSet<Transition> Transitions { get; set; }
        public DbSet<TransitionsToIntersections> TransitionsToIntersections { get; set; }
        public DbSet<Centers> Centers { get; set; }
        public DbSet<TheCenterPhoto> TheCenterPhoto { get ; set ; }

        public DataContext(DbContextOptions<DataContext> options)
       : base(options)
        {
        }
    }
}