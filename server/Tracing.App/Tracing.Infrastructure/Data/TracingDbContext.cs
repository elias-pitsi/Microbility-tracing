﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tracing.Infrastructure.Models.Data
{
    public class TracingDbContext : DbContext
    {
        public TracingDbContext(DbContextOptions<TracingDbContext> options) : base(options)
        { }

        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Components> Components { get; set; }
        public DbSet<Owner> Owners { get; set; }
        public DbSet<ComponentsHistory> ComponentsHistories { get; set; }
    }
}