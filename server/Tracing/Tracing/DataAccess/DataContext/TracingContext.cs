﻿using Microsoft.EntityFrameworkCore;
using System.ComponentModel;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.DataContext
{
    public class TracingContext : DbContext 
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public TracingContext(DbContextOptions options) : base(options)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {}

        public DbSet<Owner> Owners { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(p => 
            {
                p.ToContainer("Owner");
                p.HasPartitionKey(x => x.OwnerId);
               // p.OwnsMany(c => c.Components);
                p.OwnsMany(b => b.Bikes, n =>
                {
                    n.OwnsMany(c => c.Components);
                });
                p.HasKey(c => c.OwnerId);
            });
           // base.OnModelCreating(modelBuilder);
        }
    }
}
