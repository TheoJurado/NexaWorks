using Microsoft.EntityFrameworkCore;
using NexaWorks.Models;
using System.Collections.Generic;

namespace NexaWorks.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<OS> OSs { get; set; }
        public DbSet<NexaWorks.Models.Version> Versions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Version_OS> Targets { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Version_OS>().ToTable("Version_OS");/**/

            modelBuilder.Entity<Version_OS>()
                .HasOne(vos => vos.VersionKey) // One Version_OS is linked to one Version
                .WithMany(v => v.AssociatedVersionOS) // one Version is linked to many Version_OS
                .HasForeignKey(c => c.VersionKeyId); // Version key in Version_OS

            modelBuilder.Entity<Version_OS>()
                .HasOne(vos => vos.OSKey) // one Version_OS is linked to one OS
                .WithMany(o => o.AssociatedVersionOS) // one OS is linked to many Version_OS
                .HasForeignKey(c => c.OSKeyId); // OS key in Version_OS

            modelBuilder.Entity<Ticket>()
                .HasOne(t => t.AssociatedVersionOSKey) // one Ticket is linked to one Version_OS
                .WithMany(vos => vos.Tickets) // one Version_OS is linked to many Tickets
                .HasForeignKey(t => t.AssociatedVersionOSId); // Version_OS key in Ticket

            modelBuilder.Entity<NexaWorks.Models.Version>()
                .HasOne(v => v.ProductKey) // one Version is linked to one Product
                .WithMany(p => p.Versions) // one Product is linked to many Version
                .HasForeignKey(v => v.ProductKeyId); // Product key in Version
        }
    }
}
