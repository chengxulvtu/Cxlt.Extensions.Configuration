using System;
using Microsoft.EntityFrameworkCore;

namespace Cxlt.Extensions.Configuration.EF
{
    internal class ConfigurationDbContext : DbContext
    {

        public ConfigurationDbContext(DbContextOptions<ConfigurationDbContext> options) : base(options)
        {

        }

        public DbSet<Configuration> Configurations { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Configuration>(b =>
            {
                b.HasKey(t => t.Key);
                b.Property(t => t.Key).ValueGeneratedNever();
            });
        }
    }
}
