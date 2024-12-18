using Microsoft.EntityFrameworkCore;
using NexaWorks.Models;
using System.Collections.Generic;

namespace NexaWorks.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Produit> Produits { get; set; }
        public DbSet<OS> OSs { get; set; }
        public DbSet<Version> Versions { get; set; }
        public DbSet<Ticket> Tickets { get; set; }


    }
}
