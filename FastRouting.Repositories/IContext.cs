﻿using FastRouting.Repositories.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FastRouting.Repositories
{
    public interface IContext
    {
        DbSet<Coordinate> Coordinate { get; set; }

        DbSet<Edges> Edges { get; set; }

        DbSet<Intersections> Intersections { get; set; }
        DbSet<Location> Locations { get; set; }

        DbSet<LocationTypes> LocationTypes { get; set; }

        DbSet<Transition> Transitions { get; set; }

        DbSet<TransitionsToIntersections> TransitionsToIntersections { get; set; }
        DbSet<Centers> Centers { get; set; }
        DbSet<TheCenterPhoto> TheCenterPhoto { get; set; }


        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
