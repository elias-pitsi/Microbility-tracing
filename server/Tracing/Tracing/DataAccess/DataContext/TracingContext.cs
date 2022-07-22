using Microsoft.EntityFrameworkCore;
using Tracing.DataAccess.Models;

namespace Tracing.DataAccess.DataContext
{
    public class TracingContext : DbContext 
    {
        public TracingContext(DbContextOptions options) : base(options)
        {}

        public DbSet<Owner>? Owners { get; set; }
        public DbSet<ComponentDetails>? Components { get; set; }
        public DbSet<Bike>? Bikes { get; set; }
        public DbSet<ComponentsHistory>? ComponentsHistories { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Owner>(p => 
            {
                p.ToContainer("Owner");
                p.HasPartitionKey(x => x.OwnerId);
                p.OwnsMany(b => b.Bikes);
                p.HasKey(c => c.OwnerId);
            });
            // base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Bike>(p =>
            {
                p.ToContainer("Bike");
                p.HasPartitionKey(x => x.BikeId);
                p.OwnsMany(c => c.Components);
                p.HasKey(k => k.BikeId); 
            });

            modelBuilder.Entity<ComponentDetails>(p => 
            {
                p.ToContainer("Components");
                p.HasPartitionKey(x => x.CompId);
                p.HasKey(k => k.CompId); 
            });

            modelBuilder.Entity<ComponentsHistory>(p =>
            {
                p.ToContainer("ComponentsHistories");
                p.HasPartitionKey(x => x.CompId);
                p.HasOne(o => o.Owner); 
                p.HasKey(k => k.CompId);
            });

        }
    }
}
